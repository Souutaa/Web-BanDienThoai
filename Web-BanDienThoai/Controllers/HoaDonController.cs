using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.Entities;
using Web.Services;
using Web.Services.implementation;
using Web_BanDienThoai.Models.ChiTietHoaDon;
using Web_BanDienThoai.Models.HoaDon;

namespace Web_BanDienThoai.Controllers
{
    public class HoaDonController : Controller
    {
        private IKhachHangServices _khachhangService;
        private INhanVienServices _nhanvienService;
        private ISanPhamServices _sanphamService;
        private IChiTietHoaDonServices _cthdServices;
        private IWebHostEnvironment _webHostEnvironment;
        private IHoaDonServices _hoadonService;

        public HoaDonController(IHoaDonServices hoadonService, ISanPhamServices sanphamService,
            IKhachHangServices khachhangService, INhanVienServices nhanvienService, IChiTietHoaDonServices cthdServices,
            IWebHostEnvironment webHostEnvironment)
        {            
            _khachhangService = khachhangService;
            _nhanvienService = nhanvienService;
            _hoadonService = hoadonService;
            _sanphamService = sanphamService;
            _cthdServices = cthdServices;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index(string valueOfSearch)
        {
            
            var model = _hoadonService.GetAll().Select(hoadon => new IndexHoaDonViewModel
            {
                Id_HoaDon = hoadon.Id_HoaDon,
                NgayLapHoaDon = hoadon.NgayLapHoaDon,
                Id_khachhang = hoadon.Id_khachhang,
                Id_NhanVien = hoadon.Id_NhanVien,
                TongTien   = hoadon.TongTien,
            });

            if (!String.IsNullOrEmpty(valueOfSearch))
            {
                model = model.Where(cauhinh => cauhinh.Id_HoaDon.ToLower().Contains(valueOfSearch.ToLower())
                || cauhinh.Id_khachhang.ToLower().Contains(valueOfSearch.ToLower())
                || cauhinh.Id_NhanVien.ToLower().Contains(valueOfSearch.ToLower()));
            }
            return View(model.ToList());
           
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new CreateHoaDonViewModel();
            List<SelectListItem> listKhachHang = /*_context.CauHinh*/_khachhangService.GetAll().
                Select(c => new SelectListItem
                {
                    Value = c.Id_KhacHang.ToString(),
                    Text = c.FullName,
                }).ToList();
            model.KhachHang = listKhachHang;

            List<SelectListItem> listNhanVien = _nhanvienService.GetAll().
                Select(c => new SelectListItem
                {
                    Value = c.Id_NhanVien.ToString(),
                    Text = c.FullName
                }).ToList();
            model.NhanVien = listNhanVien;

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateHoaDonViewModel model) //Màu Sắc
        {
            if (ModelState.IsValid)
            {
                var check = _hoadonService.GetAll().FirstOrDefault(s => s.Id_HoaDon == model.Id_HoaDon);
                if (check == null)
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
                else
                {
                    ViewBag.Error = "Mã Hóa Đơn này đã được tồn tại! Vui lòng tạo Mã Hóa Đơn khác";
                    return View(model);
                }
            }
            return View();
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
                Id_HoaDon = hoadon.Id_HoaDon,
                NgayLapHoaDon = hoadon.NgayLapHoaDon,
                Id_khachhang = hoadon.Id_khachhang,
                Id_NhanVien = hoadon.Id_NhanVien,
                TongTien = hoadon.TongTien,
                            
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
                Id_HoaDon = hoadon.Id_HoaDon,
                Id_khachhang = hoadon.Id_khachhang,
                Id_NhanVien = hoadon.Id_NhanVien,
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
                Id_khachhang = hoadon.Id_khachhang, /*cauHinhIds*/
                Id_NhanVien = hoadon.Id_NhanVien,
                TongTien = hoadon.TongTien,
            };

            List<SelectListItem> listKhachHang = /*_context.CauHinh*/_khachhangService.GetAll().
                Select(c => new SelectListItem
                {
                    Value = c.Id_KhacHang.ToString(),
                    Text = c.FullName,
                }).ToList();
            model.KhachHang = listKhachHang;

            List<SelectListItem> listNhanVien = _nhanvienService.GetAll().
                Select(c => new SelectListItem
                {
                    Value = c.Id_NhanVien.ToString(),
                    Text = c.FullName
                }).ToList();
            model.NhanVien = listNhanVien;

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
            hoadon.Id_HoaDon = model.Id_HoaDon;
            hoadon.NgayLapHoaDon = model.NgayLapHoaDon;
            hoadon.Id_khachhang = model.Id_khachhang;
            hoadon.Id_NhanVien = model.Id_NhanVien;
            hoadon.TongTien = model.TongTien;

            await _hoadonService.UpdateAsSyncs(hoadon);
            //return RedirectToAction("Index");

            return View();
        }
    }
}
