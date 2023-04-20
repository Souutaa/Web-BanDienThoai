using Microsoft.AspNetCore.Mvc;
using Web.Entities;
using Web.Services;
using Web_BanDienThoai.Models.KhachHang;
using Web_BanDienThoai.Models.NhanVien;

namespace Web_BanDienThoai.Controllers
{
    public class KhachHangController : Controller
    {
        private IKhachHangServices _khachhangService;
        private IWebHostEnvironment _webHostEnvironment;

        public KhachHangController(IKhachHangServices khachhangService, IWebHostEnvironment webHostEnvironment)
        {
            _khachhangService = khachhangService;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index(string valueOfSearch)
        {
            var model = _khachhangService.GetAll().Select(people => new IndexKhachHangViewModel
            {
                Id_KhacHang = people.Id_KhacHang,
                FirstName = people.FirstName,
                LastName = people.LastName,
                FullName = people.FullName,
                Gender = people.Gender,
                DOB = people.DOB,
                Email = people.Email,
                Address = people.Address,
                Phone = people.Phone,
            });
            if (!String.IsNullOrEmpty(valueOfSearch))
            {
                model = model.Where(people => people.FullName.ToLower().Contains(valueOfSearch.ToLower()) || people.Phone.ToLower().Contains(valueOfSearch.ToLower()));
            }
            return View(model.ToList());
        }

        [HttpGet]
        public IActionResult Create()  //Cấu Hình
        {
            var model = new CreateKhachHangViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateKhachHangViewModel model)
        {
            if (ModelState.IsValid)
            {
                var people = new KhachHang
                {
                    Id_KhacHang = model.Id_KhacHang,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    FullName = model.FullName,
                    Gender = model.Gender,
                    DOB = model.DOB,
                    Email = model.Email,
                    Address = model.Address,
                    Phone = model.Phone,
                };
                await _khachhangService.CreateAsSync(people);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Detail(string id)
        {
            var people = _khachhangService.GetById(id);
            if (people == null)
            {
                return NotFound();
            }
            var model = new DetailKhachHangViewModel
            {
                Id_KhacHang = people.Id_KhacHang,
                FullName = people.FullName,
                Gender = people.Gender,
                DOB = people.DOB,
                Email = people.Email,
                Address = people.Address,
                Phone = people.Phone,
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            var people = _khachhangService.GetById(id);
            if (people == null)
            {
                return NotFound();
            }
            var model = new DeleteKhachHangViewModel
            {
                Id_KhacHang = people.Id_KhacHang,
                FullName = people.FullName,
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(DeleteKhachHangViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _khachhangService.DeleteById(model.Id_KhacHang);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            var people = _khachhangService.GetById(id);
            if (people == null)
            {
                return NotFound();
            }
            var model = new EditKhachHangViewModel
            {
                Id_KhacHang = people.Id_KhacHang,
                FirstName = people.FirstName,
                LastName = people.LastName,                
                Gender = people.Gender,
                DOB = people.DOB,
                Email = people.Email,
                Address = people.Address,
                Phone = people.Phone,
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditKhachHangViewModel model)
        {
            var people = _khachhangService.GetById(model.Id_KhacHang);
            if (people == null)
            {
                return NotFound();
            }
            people.Id_KhacHang = model.Id_KhacHang;
            people.FirstName = model.FirstName;
            people.LastName = model.LastName;
            people.FullName = model.FullName;
            people.Gender = model.Gender;
            people.DOB = model.DOB;
            people.Email = model.Email;
            people.Address = model.Address;
            people.Phone = model.Phone;

            await _khachhangService.UpdateAsSyncs(people);
            //return RedirectToAction("Index");

            return View();
        }
    }
}

