using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Construction;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
        private ISanPhamServices _sanphamService;
        private IChiTietNhapHangServices _ctnhService;
        private INhapHangServices _nhaphangService;
        private IWebHostEnvironment _webHostEnvironment;
        private IHoaDonServices _hoadonService;
        public static string idtimkiem;
        public static int soluongduocthem = 0;
        public ChiTietNhapHangController(IHoaDonServices hoadonService, ISanPhamServices sanphamService,
            IChiTietNhapHangServices ctnhService,
            IWebHostEnvironment webHostEnvironment, INhapHangServices nhaphangService)
        {
            _ctnhService = ctnhService;
            _hoadonService = hoadonService;
            _sanphamService = sanphamService;
            _nhaphangService = nhaphangService;
            _webHostEnvironment = webHostEnvironment;
        }


        //public IActionResult Index(string id)
        public async Task<IActionResult> Index(string id)
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

            //Tính tổng tiền và tổng số lượng ở CHI TIẾT NHẬP HÀNG và cập nhật đến bảng NHẬP HÀNG 
            // VÍ dụ: NH01 có nhập 2 sản phẩm ở trong CTNH thì 2 sản phẩm có số lượng và tiền.
            // Ta lấy tiền (SP1 + SP2) và số lượng (SP1 + SP2) sau đó đưa lên Tổng Tiền và Tổng Số Lượng lên bảng NHẬP HÀNG
            var tongsoluong_tien = _nhaphangService.GetById(id);
            //tongsoluong.TongSoLuong = soluong.SoLuong + soluong.SoLuong;
            tongsoluong_tien.TongSoLuong = 0;
            tongsoluong_tien.TongTien = 0;
            await _nhaphangService.UpdateAsSyncs(tongsoluong_tien);

            foreach (var t in model)
            {
                tongsoluong_tien.TongSoLuong += t.SoLuong;
                tongsoluong_tien.TongTien += t.ThanhTien;
                await _nhaphangService.UpdateAsSyncs(tongsoluong_tien);
            }


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
                var check = _ctnhService.GetAll().Where(s => s.Id_NhapHang == model.Id_NhapHang).ToList();

                bool tao = true;
                foreach (var item in check)
                {
                    if (model.Id_SanPham == item.Id_SanPham)
                    {
                        tao = false;
                    }

                }

                if (tao == true)
                {
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
                                                                               //
                sanphamcapnhat.GiaTien = model.DonGia;                       // Cập nhật giá tiền
                                                                             //
                await _sanphamService.UpdateAsSyncs(sanphamcapnhat);       //               
                return RedirectToAction("Index", new { id = idtimkiem });
                }
                else
                {
                    ViewBag.error = "Sản phẩm này đã được tồn tại trong giỏ hàng";
                    return View(model);
                }
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
        public IActionResult Delete(string id, string id_sanpham)
        {
            var cthd = _ctnhService.GetbyID_sp(id,id_sanpham);
            if (cthd == null)
            {
                return NotFound();
            }
            var model = new DeleteChiTietNhapHangViewModel
            {
                Id_NhapHang = cthd.Id_NhapHang,
                Id_SanPham = cthd.Id_SanPham,
                SoLuong = cthd.SoLuong,
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
                return RedirectToAction("Index", new { id = idtimkiem });
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(string id, string id_sanpham)
        {
            var ctnh = _ctnhService.GetbyID_sp(id,id_sanpham);
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

            var trangthainhaphang = _nhaphangService.GetById(model.Id_NhapHang);
            var sanphamcapnhat = _sanphamService.GetById(model.Id_SanPham);


            sanphamcapnhat.SoLuong = sanphamcapnhat.SoLuong - soluongduocthem; // Cập nhật số lượng sản phẩm
            sanphamcapnhat.SoLuong += model.SoLuong;                          //
            soluongduocthem = model.SoLuong;                                 //
                                                                             //
            sanphamcapnhat.GiaTien = model.DonGia;                         // Cập nhật giá tiền

            await _sanphamService.UpdateAsSyncs(sanphamcapnhat);

            return RedirectToAction("Index", new { id = idtimkiem });

            //return View();
        }
    }
}
