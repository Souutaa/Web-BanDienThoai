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
        public List<object> GetDataDashboard() 
        {
            List<object> data = new List<object>();

            List<string> labels = _dashboardService.GetAll().Select(x => x.Id_HoaDon).ToList();
            data.Add(labels);

            List<double> Tongtien = _dashboardService.GetAll().Select(x => x.TongTien).ToList();
            data.Add(Tongtien);

            return data;
        }
    }
}
