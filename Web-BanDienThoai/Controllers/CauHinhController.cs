using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Web.Entities;
using Web.Services;
using Web.Services.implementation;
using Web_BanDienThoai.Models.CauHinh;

namespace Web_BanDienThoai.Controllers
{
    public class CauHinhController : Controller
    {
        private ICauHinhServices _cauhinhService;
        private IWebHostEnvironment _webHostEnvironment;

        public CauHinhController(ICauHinhServices cauhinhService, IWebHostEnvironment webHostEnvironment)
        {
            _cauhinhService = cauhinhService;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index(string valueOfSearch)
        {

            var model = _cauhinhService.GetAll().Select(cauhinh => new IndexCauHinhViewModel
            {
                Id_CauHinh = cauhinh.Id_CauHinh,
                DoPhanGiai = cauhinh.DoPhanGiai,
                CameraTruoc = cauhinh.CameraTruoc,
                CameraSau = cauhinh.CameraSau,
                Ram = cauhinh.Ram,
                Chipset = cauhinh.Chipset,
            });
            if (!String.IsNullOrEmpty(valueOfSearch))
            {
                model = model.Where(cauhinh => cauhinh.Ram.ToLower().Contains(valueOfSearch.ToLower()) || cauhinh.Chipset.ToLower().Contains(valueOfSearch.ToLower()));
            }
            return View(model.ToList());
        }

        [HttpGet]
        public IActionResult Create()  //Cấu Hình
        {
            var model = new CreateCauHinhViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCauHinhViewModel model)
        {
            if (ModelState.IsValid)
            {
                var test = _cauhinhService.GetAll();
                if (test.Equals(model))
                {
                    NotFound();
                }
                else
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
            }
            return View();
        }

        [HttpGet]
        public IActionResult Detail(string id)
        {
            var cauhinh = _cauhinhService.GetById(id);
            if (cauhinh == null)
            {
                return NotFound();
            }
            var model = new DetailCauHinhViewModel
            {

                Id_CauHinh = cauhinh.Id_CauHinh,
                CameraSau = cauhinh.CameraSau,
                CameraTruoc = cauhinh.CameraTruoc,
                DoPhanGiai = cauhinh.DoPhanGiai,
                Ram = cauhinh.Ram,
                Chipset = cauhinh.Chipset,                
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            var cauhinh = _cauhinhService.GetById(id);
            if (cauhinh == null)
            {
                return NotFound();
            }
            var model = new DeleteCauHinhViewModel
            {
                Id_CauHinh = cauhinh.Id_CauHinh,
                Chipset = cauhinh.Chipset,
            };            
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task<IActionResult> Delete(DeleteCauHinhViewModel model)
        {
            if (ModelState.IsValid)
            {             
              await _cauhinhService.DeleteById(model.Id_CauHinh);
              return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            var cauhinh = _cauhinhService.GetById(id);
            if (cauhinh == null)
            {
                return NotFound();
            }
            var model = new EditCauHinhViewModel
            {
                Id_CauHinh = cauhinh.Id_CauHinh,
                DoPhanGiai = cauhinh.DoPhanGiai,
                CameraTruoc = cauhinh.CameraTruoc,
                CameraSau = cauhinh.CameraSau,
                Ram = cauhinh.Ram,
                Chipset = cauhinh.Chipset,
            };
            return View(model);
        }
            
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditCauHinhViewModel model)
        {
            var cauhinh = _cauhinhService.GetById(model.Id_CauHinh);
            if (cauhinh == null)
            {
                return NotFound();
            }
            cauhinh.Id_CauHinh = model.Id_CauHinh;
            cauhinh.DoPhanGiai = model.DoPhanGiai;
            cauhinh.CameraTruoc = model.CameraTruoc;
            cauhinh.CameraSau = model.CameraSau;
            cauhinh.Ram = model.Ram;
            cauhinh.Chipset = model.Chipset;
            
            await _cauhinhService.UpdateAsSyncs(cauhinh);
            //return RedirectToAction("Index");
            
            return View();
        }
    }
}
