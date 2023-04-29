using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Web.Entities;
using Web.Persistances;
using Web.Services;
using Web.Services.implementation;
using Web_BanDienThoai.Models.ChiTietHoaDon;
using Web_BanDienThoai.Models.HoaDon;

namespace Web_BanDienThoai.Controllers
{
    public class HoaDonController : Controller
    {
        private ISanPhamServices _sanphamService;
        private IChiTietHoaDonServices _cthdServices;
        private IWebHostEnvironment _webHostEnvironment;
        private IHoaDonServices _hoadonService;
        private readonly RoleManager<IdentityRole> roleManager;
        private UserManager<TaiKhoan> userManager;
        public HoaDonController(IHoaDonServices hoadonService, ISanPhamServices sanphamService,
            IChiTietHoaDonServices cthdServices,
            IWebHostEnvironment webHostEnvironment, UserManager<TaiKhoan> userManager, 
            RoleManager<IdentityRole> roleManager)
        {            
            _hoadonService = hoadonService;
            _sanphamService = sanphamService;
            _cthdServices = cthdServices;
            _webHostEnvironment = webHostEnvironment;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Index(string valueOfSearch)
        {
            var model = _hoadonService.GetAll().Select((hoadon) =>
            {
                return (new IndexHoaDonViewModel
                {
                    Id_HoaDon = hoadon.Id_HoaDon,
                    NgayLapHoaDon = hoadon.NgayLapHoaDon,
                    id_khachhang = hoadon.Id_khachhang,
                    id_NhanVien = hoadon.Id_NhanVien,
                    TongTien = hoadon.TongTien,
                });
            });
            //if (!String.IsNullOrEmpty(valueOfSearch))
            //{
            //    model = (IndexHoaDonViewModel[])model.Where(cauhinh => cauhinh.Id_HoaDon.ToLower().Contains(valueOfSearch.ToLower())
            //    || cauhinh.FullName_khachhang.ToLower().Contains(valueOfSearch.ToLower())
            //    || cauhinh.FullName_NhanVien.ToLower().Contains(valueOfSearch.ToLower()));
            //}
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
                } else
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

            await _hoadonService.UpdateAsSyncs(hoadon);
            return RedirectToAction("Index");
        }
    }
}
