using Microsoft.AspNetCore.Mvc;
using Web.Services;
using Web.Services.implementation;
using Web_BanDienThoai.Models.DashBoard;

namespace Web_BanDienThoai.Controllers
{
    public class DashBoardController : Controller
    {
        private IDashBoardServices _dashboardService;
        private IWebHostEnvironment _webHostEnvironment;

        public DashBoardController(IDashBoardServices dashboardService, IWebHostEnvironment webHostEnvironment)
        {
            _dashboardService = dashboardService;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            DashboardViewModel dashboard = new DashboardViewModel();
            var ncccount = _dashboardService.GetNhaCungCapCount();
            var taikhoan = _dashboardService.GetNguoiDungCount();
            var loai = _dashboardService.GetLoaiCount();
            var cauhinh = _dashboardService.GetCauHinhCount();
            dashboard.ncc_count = ncccount;
            dashboard.nguoidung_count = taikhoan;
            dashboard.loai_count = loai;
            dashboard.cauhinh_count = cauhinh;
            return View(dashboard);
        }

        [HttpPost]
        public List<object> GetDataHoaDonDashboard()
        {
            List<object> data = new List<object>();

            List<string> labels = _dashboardService.GetAllHoaDon().Select(x => x.Id_HoaDon).ToList();
            data.Add(labels);

            List<double> Tongtien = _dashboardService.GetAllHoaDon().Select(x => x.TongTien).ToList();
            data.Add(Tongtien);

            return data;
        }

        [HttpPost]
        public List<object> GetDataNhapHangDashboard()
        {
            List<object> data = new List<object>();

            List<string> labels = _dashboardService.GetAllNhapHang().Select(x => x.Id_NhapHang).ToList();
            data.Add(labels);

            List<double> Tongtien = _dashboardService.GetAllNhapHang().Select(x => x.TongTien).ToList();
            data.Add(Tongtien);

            return data;
        }

        [HttpPost]
        public List<object> GetDataSanPhamDashboard()
        {
            List<object> data = new List<object>();

            List<string> labels = _dashboardService.GetAllSanPham().Select(x => x.Id_SanPham).ToList();
            data.Add(labels);

            List<int> TongSoLuong = _dashboardService.GetAllSanPham().Select(x => x.SoLuong).ToList();
            data.Add(TongSoLuong);

            return data;
        }

        [HttpPost]
        public /*List<object>*/ int GetDataNhaCungCapDashboard()
        {
            //List<object> data = new List<object>();

            //List<string> labels = _dashboardService.GetAllNhaCungCap().Select(x => x.Id_NhaCungCap).ToList();
            //data.Add(labels);

            //List<string> TongSoLuong = _dashboardService.GetAllNhaCungCap().Select(x => x.Id_NhaCungCap).ToList();
            //int TongSoLuong = 0;
            //foreach (var item in labels)
            //{
            //    TongSoLuong++;
            //}
            //data.Add(TongSoLuong);

            //return data;
            var ncc = _dashboardService.GetAllNhaCungCap().ToList().Count();
            return ncc;
        }
    }
}
