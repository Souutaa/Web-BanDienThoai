using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Newtonsoft.Json.Linq;
using NuGet.Protocol;
using System.Data;
using System.Web.Helpers;
using Web.Entities;
using Web.Persistances;
using Web.Services;
using Web.Services.implementation;
using Web_BanDienThoai.Models.ChiTietHoaDon;
using Web_BanDienThoai.Models.HoaDon;

namespace Web_BanDienThoai.Controllers
{
    [Authorize]
    public class HoaDonController : Controller
    {
        private ISanPhamServices _sanphamService;
        private IChiTietHoaDonServices _cthdServices;
        private IWebHostEnvironment _webHostEnvironment;
        private IHoaDonServices _hoadonService;
        private readonly RoleManager<IdentityRole> roleManager;
        private UserManager<TaiKhoan> userManager;
        private SignInManager<TaiKhoan> signInManager;
        public HoaDonController(IHoaDonServices hoadonService, ISanPhamServices sanphamService,
            IChiTietHoaDonServices cthdServices,
            IWebHostEnvironment webHostEnvironment, UserManager<TaiKhoan> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<TaiKhoan> signInManager
            )
        {
            _hoadonService = hoadonService;
            _sanphamService = sanphamService;
            _cthdServices = cthdServices;
            _webHostEnvironment = webHostEnvironment;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index(string valueOfSearch)
        {
            var model = _hoadonService.GetAll().Select(hoadon => new IndexHoaDonViewModel
            {
                Id_HoaDon = hoadon.Id_HoaDon,
                NgayLapHoaDon = hoadon.NgayLapHoaDon,
                id_khachhang = hoadon.Id_khachhang,
                id_NhanVien = hoadon.Id_NhanVien,
                TongTien = hoadon.TongTien,
                status = hoadon.status,
            });

            if (!String.IsNullOrEmpty(valueOfSearch))
            {
                model = model.Where(people => people.Id_HoaDon.Contains(valueOfSearch)
                || people.id_khachhang.Contains(valueOfSearch)
                || people.NgayLapHoaDon.Equals(valueOfSearch)
                || people.id_NhanVien.Contains(valueOfSearch));
            }

            return View(model.ToList());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new CreateHoaDonViewModel();

            foreach (var user in userManager.Users)
            {
                var item = new SelectListItem
                {
                    Text = user.UserName,
                    Value = user.Id
                };
                if (await userManager.IsInRoleAsync(user, "Admin"))
                {
                    model.Staffs.Add(item);
                }
                else
                {
                    model.Users.Add(item);
                }
            }

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateHoaDonViewModel model) //Màu Sắc
        {
            if (ModelState.IsValid)
            {
                var hoadon = new HoaDon
                {
                    Id_HoaDon = model.Id_HoaDon,
                    NgayLapHoaDon = model.NgayLapHoaDon,
                    Id_khachhang = model.Id_khachhang,
                    Id_NhanVien = model.Id_NhanVien,
                    TongTien = model.TongTien,
                };
                await _hoadonService.CreateAsSync(hoadon);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Detail(string id)
        {
            var hoadon = _hoadonService.GetById(id);
            if (hoadon == null)
            {
                return NotFound();
            }

            //var sanphamchitiet = _cthdServices.GetID(hoadon.Id_HoaDon);
            //List<string> list = new List<string>();
            //foreach(var item in sanphamchitiet)
            //{
            //    string id_sp = item.Text;
            //    SanPham SanPham = _sanphamService.GetById(id_sp);
            //    list.Add(SanPham.Ten_SanPham);              


            var model = new DetailHoaDonViewModel
            {
                //Id_HoaDon = hoadon.Id_HoaDon,
                //NgayLapHoaDon = hoadon.NgayLapHoaDon,
                //Id_khachhang = hoadon.Id_khachhang,
                //Id_NhanVien = hoadon.Id_NhanVien,
                //TongTien = hoadon.TongTien,

            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var hoadon = _hoadonService.GetById(id);
            if (hoadon == null)
            {
                return NotFound();
            }

            var model = new DeleteHoaDonViewModel
            {
                Id_HoaDon = hoadon.Id_HoaDon,
                Id_KhachHang = hoadon.Id_khachhang,
                Id_NhanVien = hoadon.Id_NhanVien,
                CreatedAt = hoadon.NgayLapHoaDon,
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(DeleteHoaDonViewModel model)
        {
            if (ModelState.IsValid)
            {

                var cthd = _cthdServices.GetAll().Select(cthd => new IndexChiTietHoaDonViewModel
                {
                    Id_HoaDon = cthd.Id_HoaDon,
                    Id_SanPham = cthd.Id_SanPham,
                    SoLuong = cthd.SoLuong,
                    DonGia = cthd.DonGia,
                    ThanhTien = cthd.ThanhTien
                }).Where(x => x.Id_HoaDon == model.Id_HoaDon).ToList();

               
                foreach (var t in cthd)
                {
                    var sanphamcapnhat = _sanphamService.GetById(t.Id_SanPham);
                    sanphamcapnhat.SoLuong += t.SoLuong;
                }


                await _hoadonService.DeleteById(model.Id_HoaDon);
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpGet]
        public async Task<ActionResult> Edit(string id)
        {
            var hoadon = _hoadonService.GetById(id);
            if (hoadon == null)
            {
                return NotFound();
            }
            var model = new EditHoaDonViewModel();
            model.Id_HoaDon = hoadon.Id_HoaDon;
            model.NgayLapHoaDon = hoadon.NgayLapHoaDon;
            model.Id_customer = hoadon.Id_khachhang;
            model.Id_staff = hoadon.Id_NhanVien;
            model.TongTien = hoadon.TongTien;
            model.status = hoadon.status;

            foreach (var user in userManager.Users)
            {
                var item = new SelectListItem
                {
                    Text = user.UserName,
                    Value = user.Id
                };
                if (await userManager.IsInRoleAsync(user, "Admin"))
                {
                    model.Staffs.Add(item);
                }
                else
                {
                    model.Customers.Add(item);
                }
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditHoaDonViewModel model)
        {
            var hoadon = _hoadonService.GetById(model.Id_HoaDon);
            if (hoadon == null)
            {
                return NotFound();
            }
            hoadon.NgayLapHoaDon = model.NgayLapHoaDon;
            hoadon.Id_khachhang = model.Id_customer;
            hoadon.Id_NhanVien = model.Id_staff;
            hoadon.TongTien = model.TongTien;
            hoadon.status = model.status;

            await _hoadonService.UpdateAsSyncs(hoadon);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<JsonResult> CreateUserOrder(string json)
        {
            dynamic items = JObject.Parse(json);

            var productList = new List<SanPham>();
            double ThanhTien = 0;
            foreach (var item in items)
            {
                var product = _sanphamService.GetById(item.Path);
                ThanhTien += double.Parse(item.Value.Value.ToString()) * product.GiaTien;
            }

            var user = await userManager.GetUserAsync(User);

            var hoaDon = new HoaDon
            {
                Id_HoaDon = Guid.NewGuid().ToString("N"),
                NgayLapHoaDon = DateTime.Now,
                Id_khachhang = user.Id,
                TongTien = ThanhTien,
            };

            await _hoadonService.CreateAsSync(hoaDon);

            CreateChiTietHoaDonViewModel model = new CreateChiTietHoaDonViewModel();
            foreach (var item in items)
            {
                var product = _sanphamService.GetById(item.Path);
                var cthd = new ChiTietHoaDon();
                cthd.Id_HoaDon = hoaDon.Id_HoaDon;
                cthd.Id_SanPham = product.Id_SanPham;
                cthd.SoLuong = int.Parse(item.Value.Value.ToString());
                cthd.DonGia = product.GiaTien;
                cthd.SoLuongThayDoi = cthd.SoLuong;
                cthd.ThanhTien = double.Parse(item.Value.Value.ToString()) * product.GiaTien;

                await _cthdServices.CreateAsSync(cthd);

                var sanphamcapnhat = _sanphamService.GetById(product.Id_SanPham);  //
                sanphamcapnhat.SoLuong -= cthd.SoLuong;                           // Cập nhật số lượng


                cthd.SoLuongThayDoi = cthd.SoLuong;
                await _sanphamService.UpdateAsSyncs(sanphamcapnhat);           //
            }

            return Json("success".ToJson());
        }
    }
}
