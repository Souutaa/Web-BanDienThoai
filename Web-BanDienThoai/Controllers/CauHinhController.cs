using Microsoft.AspNetCore.Mvc;
using Web.Entities;
using Web.Services;
using Web.Services.implementation;
using Web_BanDienThoai.Models.CauHinh;
using Web_BanDienThoai.Models.MauSac;
using Web_BanDienThoai.Models.SanPham;

namespace Web_BanDienThoai.Controllers
{
    public class CauHinhController : Controller
    {
        private ICauHinhServices _cauhinhService;
        private IWebHostEnvironment _webHostEnvironment;

        public CauHinhController()
        {           
        }

        public CauHinhController(ICauHinhServices cauhinhService, IWebHostEnvironment webHostEnvironment)
        {
            _cauhinhService = cauhinhService;
            _webHostEnvironment = webHostEnvironment;
        }        
        public IActionResult Index()
        {
            var model = _cauhinhService.GetAll().Select(cauhinh => new IndexCauHinhViewModel
            {
                Id_CauHinh = cauhinh.Id_CauHinh,
                DoPhanGiai = cauhinh.DoPhanGiai,
                CameraTruoc = cauhinh.CameraTruoc,
                CameraSau = cauhinh.CameraSau,
                Ram = cauhinh.Ram,
                Chipset = cauhinh.Chipset,
            }).ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()  //Cấu Hình
        {
            var model = new CreateCauHinhViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCauHinhViewModel model) //Màu Sắc
        {
            if (ModelState.IsValid)
            {
                var cauhinh = new CauHinh
                {
                    Id_CauHinh = model.Id_CauHinh,
                    DoPhanGiai = model.DoPhanGiai,
                    CameraTruoc = model.CameraTruoc,
                    CameraSau = model.CameraSau,
                    Ram = model.Ram,
                    Chipset = model.Chipset,
                };
                await _cauhinhService.CreateAsSync(cauhinh);
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
            var model = _cauhinhService.GetById(id);
            _cauhinhService.DeleteAsSync(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(DeleteCauHinhViewModel model)
        {
            if (ModelState.IsValid)
            {
                var cauhinh = new CauHinh
                {
                    Id_CauHinh = model.Id_CauHinh,
                    Chipset = model.Chipset,
                };
                _cauhinhService.DeleteAsSync(cauhinh);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditCauHinhViewModel model)
        {
            if (ModelState.IsValid)
            {
                var cauhinh = new CauHinh
                {
                    Id_CauHinh = model.Id_CauHinh,
                    DoPhanGiai = model.DoPhanGiai,
                    CameraTruoc = model.CameraTruoc,
                    CameraSau = model.CameraSau,
                    Ram = model.Ram,
                    Chipset = model.Chipset,
                };
                await _cauhinhService.CreateAsSync(cauhinh);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
