using Microsoft.AspNetCore.Mvc;

namespace Web_BanDienThoai.Controllers
{
    public class DashBoardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
