using Microsoft.AspNetCore.Mvc;
using Web.Entities;
using Web.Services;
using Web.Services.implementation;
using Web_BanDienThoai.Models.CauHinh;
using Web_BanDienThoai.Models.LoaiSanPham;
using Web_BanDienThoai.Models.MauSac;

namespace Web_BanDienThoai.Controllers
{
    public class MauSacController : Controller
    {
        private IMauSacServices _mausacService;
        private IWebHostEnvironment _webHostEnvironment;

        public MauSacController(IMauSacServices mausacService, IWebHostEnvironment webHostEnvironment)
        {
            _mausacService = mausacService;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index(string valueOfSearch)
        {
            var model = _mausacService.GetAll().Select(mausac => new IndexMauSacViewModel
            {
                Id_MauSac = mausac.Id_MauSac,
                TenMauSac = mausac.TenMauSac,
            });

            if (!String.IsNullOrEmpty(valueOfSearch))
            {
                model = model.Where(mausac => mausac.Id_MauSac.ToLower().Contains(valueOfSearch.ToLower())
                || mausac.TenMauSac.ToLower().Contains(valueOfSearch.ToLower()));
            }

            return View(model.ToList());
        }

        [HttpGet]
        public IActionResult Create() //Màu Sắc
        {
            var model = new CreateMauSacViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateMauSacViewModel model) //Màu Sắc
        {
            if (ModelState.IsValid)
            {
                var check = _mausacService.GetAll().FirstOrDefault(s => s.Id_MauSac == model.Id_MauSac);
                if (check == null)
                {
                    var mausac = new MauSac
                    {
                        Id_MauSac = model.Id_MauSac.ToUpper(),
                        TenMauSac = model.TenMauSac,
                    };
                    await _mausacService.CreateAsSync(mausac);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Error = "Mã Màu Sắc này đã được tồn tại! Vui lòng tạo Mã Nhà Màu Sắc khác";
                    return View(model);
                }
            }
            return View();
        }

        public IActionResult Detail(string id)
        {
            var ms = _mausacService.GetById(id);
            if (ms == null)
            {
                return NotFound();
            }
            var model = new DetailMauSacViewModel
            {
                Id_MauSac = ms.Id_MauSac,
                TenMauSac = ms.TenMauSac
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            var mausac = _mausacService.GetById(id);
            if (mausac == null)
            {
                return NotFound();
            }
            var model = new DeleteMauSacViewModel
            {
                Id_MauSac = mausac.Id_MauSac,
                TenMauSac = mausac.TenMauSac,
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(DeleteMauSacViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _mausacService.DeleteById(model.Id_MauSac);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            var mausac = _mausacService.GetById(id);
            if (mausac == null)
            {
                return NotFound();
            }
            var model = new EditMauSacViewModel
            {
                Id_MauSac = mausac.Id_MauSac,
                TenMauSac = mausac.TenMauSac,                
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditMauSacViewModel model)
        {
            var mausac = _mausacService.GetById(model.Id_MauSac);
            if (mausac == null)
            {
                return NotFound();
            }
            mausac.Id_MauSac = model.Id_MauSac;
            mausac.TenMauSac = model.TenMauSac;
            await _mausacService.UpdateAsSyncs(mausac);
            return RedirectToAction("Index");

            return View();
        }
    }
}