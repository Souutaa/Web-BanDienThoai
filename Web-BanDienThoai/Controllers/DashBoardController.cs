using Microsoft.AspNetCore.Mvc;
using Web.Services;
using Web.Services.implementation;

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
            return View();
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
    }
}
