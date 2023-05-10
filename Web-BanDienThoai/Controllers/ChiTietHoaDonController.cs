using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Identity.Client;
using System.Linq;
using System.Net.WebSockets;
using Web.Entities;
using Web.Persistances;
using Web.Services;
using Web.Services.implementation;
using Web_BanDienThoai.Models.ChiTietHoaDon;
using Web_BanDienThoai.Models.HoaDon;

namespace Web_BanDienThoai.Controllers
{
    public class ChiTietHoaDonController : Controller
    {
        private ISanPhamServices _sanphamService;
        private IChiTietHoaDonServices _cthdService;
        private IWebHostEnvironment _webHostEnvironment;
        private IHoaDonServices _hoadonService;
        public static string idtimkiem;
        public static int soluongdamua = 0;
        public ChiTietHoaDonController(IHoaDonServices hoadonService, ISanPhamServices sanphamService,
            IChiTietHoaDonServices cthdService,
        IWebHostEnvironment webHostEnvironment)
        {
            _hoadonService = hoadonService;
            _sanphamService = sanphamService;
            _cthdService = cthdService;
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

            var model = _cthdService.GetAll().Select(cthd => new IndexChiTietHoaDonViewModel
            {
                Id_HoaDon = cthd.Id_HoaDon,
                Id_SanPham = cthd.Id_SanPham,
                SoLuong = cthd.SoLuong,
                DonGia = cthd.DonGia,
                ThanhTien = cthd.ThanhTien
            }).Where(x => x.Id_HoaDon == id);
            idtimkiem = id;

            //Tính tổng tiền và tổng số lượng ở CHI TIẾT HÓA ĐƠN và cập nhật đến bảng HÓA ĐƠN 
            // VÍ dụ: HD01 có nhập 2 sản phẩm ở trong CTHD thì 2 sản phẩm có số lượng và tiền.
            // Ta lấy tiền (SP1 + SP2) và số lượng (SP1 + SP2) sau đó đưa lên Tổng Tiền và Tổng Số Lượng lên bảng HÓA ĐƠN
            var tongsoluong_tien = _hoadonService.GetById(id);
            //tongsoluong.TongSoLuong = soluong.SoLuong + soluong.SoLuong;
            //tongsoluong_tien.TongSoLuong = 0;
            tongsoluong_tien.TongTien = 0;
            await _hoadonService.UpdateAsSyncs(tongsoluong_tien);

            //tongsoluong_tien.TongTien = 0;

            foreach (var t in model)
            {
                //tongsoluong_tien.TongSoLuong += t.SoLuong;
                tongsoluong_tien.TongTien += t.ThanhTien;
                await _hoadonService.UpdateAsSyncs(tongsoluong_tien);
            }
            return View(model.ToList());
        }



        [HttpGet]
        public IActionResult Create()
        {
            var model = new CreateChiTietHoaDonViewModel();

            //List<SelectListItem> listHoaDon = _hoadonService.GetAll().
            //    Select(c => new SelectListItem
            //    {
            //        Value = c.Id_HoaDon.ToString(),
            //        Text = c.Id_HoaDon,
            //    }).ToList();
            //model.HoaDon = listHoaDon;
            var getidhoadon = _hoadonService.GetById(idtimkiem);
            model.Id_HoaDon = getidhoadon.Id_HoaDon;

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

                var check = _cthdService.GetAll().Where(s => s.Id_HoaDon == model.Id_HoaDon).ToList();

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
                    var sanphamcapnhat = _sanphamService.GetById(model.Id_SanPham);  //
                    if (model.SoLuong > sanphamcapnhat.SoLuong) 
                    {
                        ViewBag.error = "Số lượng trong kho không đủ!! vui lòng liên hệ SĐT của shop: 0929358925";
                        return View(model);
                    }
                    else {
                        var cthd = new ChiTietHoaDon
                        {
                            Id_HoaDon = model.Id_HoaDon.ToUpper(),
                            Id_SanPham = model.Id_SanPham,
                            SoLuong = model.SoLuong,
                            SoLuongThayDoi = model.SoLuong,
                            DonGia = model.DonGia,
                            ThanhTien = model.ThanhTien,
                        };
                        await _cthdService.CreateAsSync(cthd);

                        sanphamcapnhat.SoLuong -= model.SoLuong;                        // Cập nhật số lượng
                                                                                        // soluongdamua = model.SoLuong;  

                        cthd.SoLuongThayDoi = model.SoLuong;
                        await _sanphamService.UpdateAsSyncs(sanphamcapnhat);          //

                        return RedirectToAction("Index", new { id = idtimkiem });
                    }
                    
                }
                else
                {
                    ViewData["ErrorMessage"] = "Sản phẩm này đã được tồn tại trong giỏ hàng";
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
        public IActionResult Delete(string id, string id_sanpham)
        {
            var cthd = _cthdService.GetbyID_sp(id, id_sanpham);
            if (cthd == null)
            {
                return NotFound();
            }
            var model = new DeleteChiTietHoaDonViewModel
            {
                Id_HoaDon = cthd.Id_HoaDon,
                Id_SanPham = cthd.Id_SanPham,
                SoLuong = cthd.SoLuong,
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

                var sanphamcapnhat = _sanphamService.GetById(model.Id_SanPham);
                sanphamcapnhat.SoLuong = sanphamcapnhat.SoLuong + model.SoLuong;
                await _sanphamService.UpdateAsSyncs(sanphamcapnhat);
                return RedirectToAction("Index", new { id = idtimkiem });
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(string id, string id_sanpham)
        {
            
            var cthd = _cthdService.GetbyID_sp(id,id_sanpham);
            
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

                };
                List<SelectListItem> listSanPham = _sanphamService.GetAll().
                    Select(c => new SelectListItem
                    {
                        Value = c.Id_SanPham.ToString(),
                        Text = c.Ten_SanPham
                    }).ToList();
                model.SanPham = listSanPham;

                return View(model);
            //}
            //return View();
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
            await _cthdService.UpdateAsSyncs(cthd);

            var sanphamcapnhat = _sanphamService.GetById(model.Id_SanPham);     //
            sanphamcapnhat.SoLuong = sanphamcapnhat.SoLuong + cthd.SoLuongThayDoi; //+soluongdamua;    // Cập nhật số lượng sản phẩm
            sanphamcapnhat.SoLuong -= model.SoLuong;
            await _sanphamService.UpdateAsSyncs(sanphamcapnhat);

            cthd.SoLuongThayDoi = model.SoLuong;
            //soluongdamua = model.SoLuong;
            await _cthdService.UpdateAsSyncs(cthd);
            return RedirectToAction("Index", new { id = idtimkiem });

        }
    }
}