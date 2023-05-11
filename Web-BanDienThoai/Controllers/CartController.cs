using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Newtonsoft.Json.Linq;
using NuGet.Packaging.Licenses;
using NuGet.Protocol;
using Web.Entities;
using Web.Persistances;
using Web.Services;
using Web_BanDienThoai.Models.Cart;

namespace Web_BanDienThoai.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private ISanPhamServices sanPhamServices;
        public List<CartProductViewModel> cartProductViewModels = new List<CartProductViewModel>();
        public CartController(ApplicationDbContext dbContext, ISanPhamServices sanPhamServices)
        {
            this.dbContext = dbContext;
            this.sanPhamServices = sanPhamServices;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult test(string json)
        {
            dynamic items = JObject.Parse(json);

            foreach (var item in items)
            {
                var product = sanPhamServices.GetById(item.Path);
                long quantity = long.Parse(item.Value.Value.ToString());
                double subTotal = (product.GiaTien * quantity);

                var cartItem = new CartProductViewModel
                {
                    Id_SanPham = product.Id_SanPham,
                    SoLuongSanPham = quantity,
                    SubTotal = subTotal,
                };
            }

            return Json(items);
        }

        [HttpGet]
        public JsonResult RenderCart(string json)
        {
            dynamic items = JObject.Parse(json);

            var productList = new List<SanPham>();

            foreach (var item in items)
            {
                var product = sanPhamServices.GetById(item.Path);
                //long quantity = (item.Value.Value);
                //double subTotal = (product.GiaTien * quantity);

                //var cartItem = new CartProductViewModel
                //{
                //    Id_SanPham = product.Id_SanPham,
                //    SoLuongSanPham = quantity,
                //    SubTotal = subTotal,
                //};

                productList.Add(product);
            }
            return Json(productList.ToJson());
        }
    }
}