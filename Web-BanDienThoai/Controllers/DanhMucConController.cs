using Microsoft.AspNetCore.Mvc;
using Web.Entities;
using Web.Services;
using Web_BanDienThoai.Models.DanhMucCon;
namespace Web_BanDienThoai.Controllers
{
    public class DanhMucConController : Controller
    {
        private IDanhMucConServices _danhmucconService;
        private IWebHostEnvironment _webHostEnvironment;

        public DanhMucConController(IDanhMucConServices danhmucconService, IWebHostEnvironment webHostEnvironment)
        {
            _danhmucconService = danhmucconService;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var model = _danhmucconService.GetAll().Select(danhmucon => new IndexDanhMucConViewModel
            {
                Id_DanhMucCon = danhmucon.Id_DanhMucCon,
                TenDanhMuc = danhmucon.TenDanhMuc,
                Id_CauHinh = danhmucon.Id_CauHinh,
            }).ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()  //Cấu Hình
        {
            var model = new CreateDanhMucConViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateDanhMucConViewModel model) //Màu Sắc
        {
            if (ModelState.IsValid)
            {
                var danhMucCon = new DanhMucCon
                {
                    Id_DanhMucCon = model.Id_DanhMucCon,
                    TenDanhMuc = model.TenDanhMuc,
                    Id_CauHinh = model.Id_CauHinh,
                };
                await _danhmucconService.CreateAsSync(danhMucCon);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            if (id.ToString() == null)
            {
                return NotFound();
            }
            var model = _danhmucconService.GetById(id);
            _danhmucconService.DeleteAsSync(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(DeleteDanhMucConViewModel model)
        {
            if (ModelState.IsValid)
            {
                var danhMucCon = new DanhMucCon
                {
                    Id_DanhMucCon = model.Id_DanhMucCon,
                    TenDanhMuc = model.TenDanhMuc,
                };
                _danhmucconService.DeleteAsSync(danhMucCon);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditDanhMucConViewModel model)
        {
            if (ModelState.IsValid)
            {
                var danhMucCon = new DanhMucCon
                {
                    Id_DanhMucCon = model.Id_DanhMucCon,
                    TenDanhMuc = model.TenDanhMuc,
                    Id_CauHinh = model.Id_CauHinh,
                };
                await _danhmucconService.CreateAsSync(danhMucCon);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}