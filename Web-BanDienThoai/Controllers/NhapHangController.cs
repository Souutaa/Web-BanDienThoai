using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.Entities;
using Web.Services;
using Web_BanDienThoai.Models.ChiTietHoaDon;
using Web_BanDienThoai.Models.HoaDon;
using Web_BanDienThoai.Models.NhapHang;

namespace Web_BanDienThoai.Controllers
{
    public class NhapHangController : Controller
    {
        private INhaCungCapServices _nhacungcapService;
        private ISanPhamServices _sanphamService;        
        private IWebHostEnvironment _webHostEnvironment; 
        private INhapHangServices _nhaphangService;
        private IChiTietNhapHangServices _ctnhService;
        private readonly UserManager<TaiKhoan> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public NhapHangController(ISanPhamServices sanphamService, IChiTietNhapHangServices ctnhService,
            INhaCungCapServices nhacungCapService, 
            IWebHostEnvironment webHostEnvironment, 
            INhapHangServices nhaphangService,
            UserManager<TaiKhoan> userManager, RoleManager<IdentityRole> roleManager
            )
        {
            _nhaphangService = nhaphangService;
            _nhacungcapService = nhacungCapService;
            _sanphamService = sanphamService;
            _ctnhService = ctnhService;
            _webHostEnvironment = webHostEnvironment;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public IActionResult Index(string valueOfSearch)
        {

            var model = _nhaphangService.GetAll().Select(nhaphang => new IndexNhapHangViewModel
            {
                Id_NhapHang=nhaphang.Id_NhapHang,
                NgayLap=nhaphang.NgayLap,
                NgayGiao=nhaphang.NgayGiao,
                TrangThaiNhapHang = nhaphang.TrangThaiNhapHang,                
                TongTien = nhaphang.TongTien,
                TongSoLuong = nhaphang.TongSoLuong,
                Id_NhaCungCap = nhaphang.Id_NhaCungCap,
                Id_NhanVien = nhaphang.Id_NhanVien
                
            });

            if (!String.IsNullOrEmpty(valueOfSearch))
            {
                model = model.Where(people => people.Id_NhapHang.Contains(valueOfSearch)
                || people.NgayGiao.Equals(valueOfSearch)
                || people.NgayLap.Equals(valueOfSearch)
                || people.TrangThaiNhapHang.Equals(valueOfSearch));
            }

            return View(model.ToList());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {

            var model = new CreateNhapHangViewModel();

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
            }

            List<SelectListItem> listNhaCungCap = _nhacungcapService.GetAll().
            Select(c => new SelectListItem
            {
                Value = c.Id_NhaCungCap.ToString(),
                Text = c.Name
            }).ToList();
            model.NhaCungCap = listNhaCungCap;

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateNhapHangViewModel model) //Màu Sắc
        {
            if (ModelState.IsValid)
            {
                var check = _nhaphangService.GetAll().FirstOrDefault(s => s.Id_NhapHang == model.Id_NhapHang);
                if (check == null)
                {
                    var nhaphang = new NhapHang
                    {
                        Id_NhapHang = model.Id_NhapHang,
                        NgayLap = model.NgayLap,
                        NgayGiao = model.NgayGiao,
                        TrangThaiNhapHang = model.TrangThaiNhapHang,
                        TongSoLuong = model.TongSoLuong,
                        TongTien = model.TongTien,
                        GhiChu = model.GhiChu,
                        Id_NhaCungCap = model.Id_NhaCungCap,
                        Id_NhanVien = model.id_nhanvien
                    };
                    await _nhaphangService.CreateAsSync(nhaphang);
                    return RedirectToAction("Index");

                }
                else
                {
                    ViewBag.Error = "Mã Nhập Hàng này đã được tồn tại! Vui lòng tạo Mã Nhập Hàng khác";
                    return View(model);
                }

            }
            return View();
        }

        [HttpGet]
        public IActionResult Detail(string id)
        {
            var nhaphang = _nhaphangService.GetById(id);
            if (nhaphang == null)
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


            //var model = new DetailNhapHangViewModel
            //{
            //    Id_NhapHang = nhaphang.Id_NhapHang,
            //    NgayLap = nhaphang.NgayLap,
            //    NgayGiao = nhaphang.NgayGiao,
            //    TrangThaiNhapHang = nhaphang.TrangThaiNhapHang,
            //    TongSoLuong = nhaphang.TongSoLuong,
            //    TongTien = nhaphang.TongTien,
            //    GhiChu = nhaphang.GhiChu,
            //    Id_NhaCungCap = nhaphang.Id_NhaCungCap,
            //    Id_NhanVien = nhaphang.Id_NhanVien,
            //};

            return View();
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            var hoadon = _nhaphangService.GetById(id);
            if (hoadon == null)
            {
                return NotFound();
            }
            var model = new DeleteNhapHangViewModel
            {
                Id_NhapHang = hoadon.Id_NhapHang,
                NgayLap = hoadon.NgayLap,
                NgayGiao = hoadon.NgayGiao,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(DeleteNhapHangViewModel model)
        {
            if (ModelState.IsValid)
            {
                var ctnh = _ctnhService.GetAll().Select(ctnh => new IndexChiTietHoaDonViewModel
                {
                    Id_HoaDon = ctnh.Id_NhapHang,
                    Id_SanPham = ctnh.Id_SanPham,
                    SoLuong = ctnh.SoLuong,
                    DonGia = ctnh.DonGia,
                    ThanhTien = ctnh.ThanhTien
                }).Where(x => x.Id_HoaDon == model.Id_NhapHang).ToList();


                foreach (var t in ctnh)
                {
                    var sanphamcapnhat = _sanphamService.GetById(t.Id_SanPham);
                    sanphamcapnhat.SoLuong -= t.SoLuong;
                }

                await _nhaphangService.DeleteById(model.Id_NhapHang);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Edit(string id)
        {
            var nhaphang = _nhaphangService.GetById(id);
            if (nhaphang == null)
            {
                return NotFound();
            }
            var model = new EditNhapHangViewModel
            {
                Id_NhapHang = nhaphang.Id_NhapHang,
                NgayLap = nhaphang.NgayLap,
                NgayGiao = nhaphang.NgayGiao,
                TrangThaiNhapHang = nhaphang.TrangThaiNhapHang,
                TongTien = nhaphang.TongTien,
                TongSoLuong = nhaphang.TongSoLuong,
                GhiChu = nhaphang.GhiChu,
                Id_NhaCungCap = nhaphang.Id_NhaCungCap,
                id_staff = nhaphang.Id_NhanVien
            };

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
            }

            List<SelectListItem> listNhaCungCap = _nhacungcapService.GetAll().
                Select(c => new SelectListItem
                {
                    Value = c.Id_NhaCungCap.ToString(),
                    Text = c.Name
                }).ToList();
            model.NhaCungCap = listNhaCungCap;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditNhapHangViewModel model)
        {
            var nhaphang = _nhaphangService.GetById(model.Id_NhapHang);
            if (nhaphang == null)
            {
                return NotFound();
            }
            nhaphang.Id_NhapHang = model.Id_NhapHang;
            nhaphang.NgayLap = model.NgayLap;
            nhaphang.NgayGiao = model.NgayGiao;
            nhaphang.TrangThaiNhapHang = model.TrangThaiNhapHang;
            nhaphang.TongSoLuong = model.TongSoLuong;
            nhaphang.TongTien = model.TongTien;
            nhaphang.GhiChu = model.GhiChu;
            nhaphang.Id_NhaCungCap = model.Id_NhaCungCap;
            nhaphang.Id_NhanVien = model.id_staff;

            await _nhaphangService.UpdateAsSyncs(nhaphang);
            return RedirectToAction("Index");

            //return View();
        }
    }
}

