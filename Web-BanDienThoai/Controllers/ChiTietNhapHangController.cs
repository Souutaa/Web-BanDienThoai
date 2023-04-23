using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.Entities;
using Web.Services;
using Web_BanDienThoai.Models.ChiTietHoaDon;
using Web_BanDienThoai.Models.ChiTietNhapHang;
using Web_BanDienThoai.Models.HoaDon;
using Web_BanDienThoai.Models.NhapHang;

namespace Web_BanDienThoai.Controllers
{
    public class ChiTietNhapHangController : Controller
    {       
        private INhanVienServices _nhanvienService;
        private ISanPhamServices _sanphamService;
        private IChiTietNhapHangServices _ctnhService;
        private INhapHangServices _nhaphangService;
        private IWebHostEnvironment _webHostEnvironment;
        private IHoaDonServices _hoadonService;
        public static string idtimkiem;
        public static int soluongduocthem;
        public ChiTietNhapHangController(IHoaDonServices hoadonService, ISanPhamServices sanphamService,
            INhanVienServices nhanvienService, IChiTietNhapHangServices ctnhService,
            IWebHostEnvironment webHostEnvironment, INhapHangServices nhaphangService)
        {
            _ctnhService = ctnhService;
            _nhanvienService = nhanvienService;
            _hoadonService = hoadonService;
            _sanphamService = sanphamService;
            _nhaphangService = nhaphangService;
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

            var model = _ctnhService.GetAll().Select(cthd => new IndexChiTietNhapHangViewModel
            {
                Id_NhapHang = cthd.Id_NhapHang,
                Id_SanPham = cthd.Id_SanPham,
                SoLuong = cthd.SoLuong,
                DonGia = cthd.DonGia,
                ThanhTien = cthd.ThanhTien
            }).Where(x => x.Id_NhapHang == id);
            idtimkiem = id;
            return View(model.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new CreateChiTietNhapHangViewModel();

            List<SelectListItem> listNhapHang = _nhaphangService.GetAll().
                Select(c => new SelectListItem
                {
                    Value = c.Id_NhapHang.ToString(),
                    Text = c.Id_NhapHang,
                }).ToList();
            model.NhapHang = listNhapHang;

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
        public async Task<IActionResult> Create(CreateChiTietNhapHangViewModel model) //Màu Sắc
        {
            if (ModelState.IsValid)
            {
                //var check = _cthdService.GetAll().FirstOrDefault(s => s.Id_HoaDon == model.Id_HoaDon);
                //if(check == null) { 
                var ctnh = new ChiTietNhapHang
                {
                    Id_NhapHang = model.Id_NhapHang,
                    Id_SanPham = model.Id_SanPham,                   
                    SoLuong = model.SoLuong,
                    DonGia = model.DonGia,
                    ThanhTien = model.ThanhTien,
                };
                await _ctnhService.CreateAsSync(ctnh);
                
                var sanphamcapnhat = _sanphamService.GetById(model.Id_SanPham);  //
                sanphamcapnhat.SoLuong += model.SoLuong;                        // Cập nhật số lượng
                soluongduocthem = model.SoLuong;                               //
                await _sanphamService.UpdateAsSyncs(sanphamcapnhat);          //

                return RedirectToAction("Index", new { id = idtimkiem });
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
            var ctnh = _ctnhService.GetById(id);
            if (ctnh == null)
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


            var model = new DetailChiTietNhapHangViewModel
            {
                
                         
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            var cthd = _ctnhService.GetById(id);
            if (cthd == null)
            {
                return NotFound();
            }
            var model = new DeleteChiTietNhapHangViewModel
            {
                Id_NhapHang = cthd.Id_NhapHang,
                Id_SanPham = cthd.Id_SanPham,               
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(DeleteChiTietNhapHangViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _ctnhService.DeleteById(model.Id_NhapHang);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            var ctnh = _ctnhService.GetById(id);
            if (ctnh == null)
            {
                return NotFound();
            }
            var model = new EditChiTietNhapHangViewModel
            {
                Id_NhapHang = ctnh.Id_NhapHang,
                Id_SanPham = ctnh.Id_SanPham,
                SoLuong = ctnh.SoLuong,
                DonGia = ctnh.DonGia,
                    
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditChiTietNhapHangViewModel model)
        {
            var cthd = _ctnhService.GetById(model.Id_NhapHang);
            if (cthd == null)
            {
                return NotFound();
            }
            cthd.Id_NhapHang = model.Id_NhapHang;
            cthd.Id_SanPham = model.Id_SanPham;
            cthd.SoLuong = model.SoLuong;
            cthd.DonGia = model.DonGia;
            cthd.ThanhTien = model.ThanhTien;

            await _ctnhService.UpdateAsSyncs(cthd);

            var sanphamcapnhat = _sanphamService.GetById(model.Id_SanPham);     //
            sanphamcapnhat.SoLuong = sanphamcapnhat.SoLuong - soluongduocthem; // Cập nhật số lượng sản phẩm
            sanphamcapnhat.SoLuong += model.SoLuong;                          //
            soluongduocthem = model.SoLuong;                                 //

            await _sanphamService.UpdateAsSyncs(sanphamcapnhat);
            return RedirectToAction("Index", new { id = idtimkiem });

            //return View();
        }
    }
}
