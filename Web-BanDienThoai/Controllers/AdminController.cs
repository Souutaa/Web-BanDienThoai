using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;

namespace Web_BanDienThoai.Controllers
{
    public class AdminController : Controller
    {
        public string name;
        public IActionResult Index()
        {
            return RedirectToAction("Index","SanPham","Index");
        }

        public IActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DangNhap(string user, string pass)
        {
            if(user !=null || pass != null)
            {
                TempData["user"] = "admin";
            
            if (user.ToLower() == "admin" && pass.ToLower() == "admin")

            {
                name = "admin";
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
            }else { return View(); }
        }

        public IActionResult DangXuat()
        {
            TempData.Remove("user");
            return RedirectToAction("DangNhap");
        }
    }
}
