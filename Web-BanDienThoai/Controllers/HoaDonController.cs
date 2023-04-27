using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        private readonly ApplicationDbContext context;
        public HoaDonController(IHoaDonServices hoadonService, ISanPhamServices sanphamService,
            IChiTietHoaDonServices cthdServices,
            IWebHostEnvironment webHostEnvironment, UserManager<TaiKhoan> userManager, 
            RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {            
            _hoadonService = hoadonService;
            _sanphamService = sanphamService;
            _cthdServices = cthdServices;
            _webHostEnvironment = webHostEnvironment;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string valueOfSearch)
        {

            var model = await Task.WhenAll(_hoadonService.GetAll().Select(async hoadon =>
            {
                var khachHang = await userManager.FindByIdAsync(hoadon.Id_khachhang);
                var nhanVien = await userManager.FindByIdAsync(hoadon.Id_NhanVien);
                var HoaDon = new IndexHoaDonViewModel
                {
                    Id_HoaDon = hoadon.Id_HoaDon,
                    NgayLapHoaDon = hoadon.NgayLapHoaDon,
                    FullName_khachhang = khachHang.FullName ?? nhanVien.UserName,
                    FullName_NhanVien = nhanVien.FullName ?? nhanVien.UserName,
                    TongTien = hoadon.TongTien,
                };
                return HoaDon;
            }));
            //if (!String.IsNullOrEmpty(valueOfSearch))
            //{
            //    model = model.Where(cauhinh => cauhinh.Id_HoaDon.ToLower().Contains(valueOfSearch.ToLower())
            //    || cauhinh.Id_khachhang.ToLower().Contains(valueOfSearch.ToLower())
            //    || cauhinh.Id_NhanVien.ToLower().Contains(valueOfSearch.ToLower()));
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
                    model.Users.Add(item);
                } else
                {
                    model.Staffs.Add(item);
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
        public IActionResult Delete(string id)
        {
            var hoadon = _hoadonService.GetById(id);
            if (hoadon == null)
            {
                return NotFound();
            }
            var model = new DeleteHoaDonViewModel
            {
                //Id_HoaDon = hoadon.Id_HoaDon,
                //Id_khachhang = hoadon.Id_khachhang,
                //Id_NhanVien = hoadon.Id_NhanVien,
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
        public ActionResult Edit(string id)
        {
            var hoadon = _hoadonService.GetById(id);
            if (hoadon == null)
            {
                return NotFound();
            }
            var model = new EditHoaDonViewModel
            {
                Id_HoaDon = hoadon.Id_HoaDon,
                NgayLapHoaDon = hoadon.NgayLapHoaDon,
                //Id_khachhang = hoadon.Id_khachhang, /*cauHinhIds*/
                //Id_NhanVien = hoadon.Id_NhanVien,
                TongTien = hoadon.TongTien,
            };

            //List<SelectListItem> listKhachHang = /*_context.CauHinh*/_khachhangService.GetAll().
            //    Select(c => new SelectListItem
            //    {
            //        Value = c.Id_KhacHang.ToString(),
            //        Text = c.FullName,
            //    }).ToList();
            //model.KhachHang = listKhachHang;

            //List<SelectListItem> listNhanVien = _nhanvienService.GetAll().
            //    Select(c => new SelectListItem
            //    {
            //        Value = c.Id_NhanVien.ToString(),
            //        Text = c.FullName
            //    }).ToList();
            //model.NhanVien = listNhanVien;

            return View();
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
            hoadon.Id_HoaDon = model.Id_HoaDon;
            hoadon.NgayLapHoaDon = model.NgayLapHoaDon;
            //hoadon.Id_khachhang = model.Id_khachhang;
            //hoadon.Id_NhanVien = model.Id_NhanVien;
            hoadon.TongTien = model.TongTien;

            await _hoadonService.UpdateAsSyncs(hoadon);
            return RedirectToAction("Index");

            //return View();
        }
    }
}
