using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Identity.Client;
using System.Linq;
using System.Net.WebSockets;
using Web.Entities;
using Web.Services;
using Web_BanDienThoai.Models.ChiTietHoaDon;
using Web_BanDienThoai.Models.HoaDon;

namespace Web_BanDienThoai.Controllers
{
    public class ChiTietHoaDonController : Controller
    {
        private IKhachHangServices _khachhangService;
        private INhanVienServices _nhanvienService;
        private ISanPhamServices _sanphamService;
        private IChiTietHoaDonServices _cthdService;
        private IWebHostEnvironment _webHostEnvironment;
        private IHoaDonServices _hoadonService;
        public static string idtimkiem;
        public static int soluongduocthem;
        public ChiTietHoaDonController(IHoaDonServices hoadonService, ISanPhamServices sanphamService,
            IKhachHangServices khachhangService, INhanVienServices nhanvienService, IChiTietHoaDonServices cthdService,
            IWebHostEnvironment webHostEnvironment)
        {
            _khachhangService = khachhangService;
            _nhanvienService = nhanvienService;
            _hoadonService = hoadonService;
            _sanphamService = sanphamService;
            _cthdService = cthdService;
            _webHostEnvironment = webHostEnvironment;
        }

       
        //public IActionResult Index(string id)
            public IActionResult Index(string id)
        {
            //var hoadon = _hoadonService.GetById(id);
            //if (hoadon == null)
            //{
            //    return NotFound();
            //}
            //var sanphamchitiet = _cthdService.GetById(hoadon.Id_HoaDon);

            var model = _cthdService.GetAll().Select(cthd => new IndexChiTietHoaDonViewModel
            {
                Id_HoaDon = cthd.Id_HoaDon,
                Id_SanPham = cthd.Id_SanPham,
                SoLuong = cthd.SoLuong,
                DonGia = cthd.DonGia,
                ThanhTien = cthd.ThanhTien
            }).Where(x => x.Id_HoaDon == id);            
            idtimkiem = id;
            return View(model.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new CreateChiTietHoaDonViewModel();

            List<SelectListItem> listHoaDon = _hoadonService.GetAll().
                Select(c => new SelectListItem
                {
                    Value = c.Id_HoaDon.ToString(),
                    Text = c.Id_HoaDon,
                }).ToList();
            model.HoaDon = listHoaDon;

            List<SelectListItem> listSanPham = _sanphamService.GetAll().
                Select(c => new SelectListItem
                {
                    Value = c.Id_SanPham.ToString(),
                    Text = c.Ten_SanPham
                }).ToList();
            model.SanPham = listSanPham;

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateChiTietHoaDonViewModel model) //Màu Sắc
        {           
            if (ModelState.IsValid)
            {
                //var check = _cthdService.GetAll().FirstOrDefault(s => s.Id_HoaDon == model.Id_HoaDon);
                //if(check == null) { 
                var cthd = new ChiTietHoaDon
                {
                    Id_HoaDon = model.Id_HoaDon,
                    Id_SanPham = model.Id_SanPham,
                    SoLuong = model.SoLuong,
                    DonGia = model.DonGia,
                    ThanhTien = model.ThanhTien,
                };
                await _cthdService.CreateAsSync(cthd);

                var sanphamcapnhat = _sanphamService.GetById(model.Id_SanPham);  //
                sanphamcapnhat.SoLuong += model.SoLuong;                        // Cập nhật số lượng
                soluongduocthem = model.SoLuong;                               //
                await _sanphamService.UpdateAsSyncs(sanphamcapnhat);          //

                return RedirectToAction("Index", new { id = idtimkiem});
                //}
                //else
                //{
                //    ViewBag.error = "Sản phẩm này đã được tồn tại trong giỏ hàng";
                //    return View();
                //}
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
            var cthd = _cthdService.GetById(id);
            if (cthd == null)
            {
                return NotFound();
            }
            var model = new DeleteChiTietHoaDonViewModel
            {
                Id_HoaDon = cthd.Id_HoaDon,
                Id_SanPham = cthd.Id_SanPham,               
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(DeleteChiTietHoaDonViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _cthdService.DeleteById(model.Id_HoaDon);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            var cthd = _cthdService.GetById(id);
            if (cthd == null)
            {
                return NotFound();
            }
            var model = new EditChiTietHoaDonViewModel
            {
                Id_HoaDon = cthd.Id_HoaDon,
                Id_SanPham = cthd.Id_SanPham,
                SoLuong = cthd.SoLuong,
                DonGia = cthd.DonGia,
                ThanhTien = cthd.ThanhTien
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditChiTietHoaDonViewModel model)
        {
            var cthd = _cthdService.GetById(model.Id_HoaDon);
            if (cthd == null)
            {
                return NotFound();
            }
            cthd.Id_HoaDon = model.Id_HoaDon;
            cthd.Id_SanPham = model.Id_SanPham;
            cthd.SoLuong = model.SoLuong;
            cthd.DonGia = model.DonGia;
            cthd.ThanhTien = model.ThanhTien;

            var sanphamcapnhat = _sanphamService.GetById(model.Id_SanPham);     //
            sanphamcapnhat.SoLuong = sanphamcapnhat.SoLuong - soluongduocthem; // Cập nhật số lượng sản phẩm
            sanphamcapnhat.SoLuong += model.SoLuong;                          //
            soluongduocthem = model.SoLuong;

            await _cthdService.UpdateAsSyncs(cthd);
            return RedirectToAction("Index");

        }
    }
}



