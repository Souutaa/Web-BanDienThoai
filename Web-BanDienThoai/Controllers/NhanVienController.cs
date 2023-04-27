using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Numerics;
using System.Reflection;
using Web.Entities;
using Web.Services;
using Web.Services.implementation;
using Web_BanDienThoai.Models.CauHinh;
using Web_BanDienThoai.Models.NhanVien;

namespace Web_BanDienThoai.Controllers
{
    public class NhanVienController : Controller
    {
        private INhanVienServices _nhanvienService;
        private IWebHostEnvironment _webHostEnvironment;
        private IHoaDonServices _hoadonService;

        public NhanVienController(INhanVienServices nhanvienService, IWebHostEnvironment webHostEnvironment, IHoaDonServices hoadonService)
        {
            _nhanvienService = nhanvienService;
            _webHostEnvironment = webHostEnvironment;
            _hoadonService = hoadonService;
        }
        public IActionResult Index(string valueOfSearch)
        {
            var model = _nhanvienService.GetAll().Select(people => new IndexNhanVienViewModel
            {
                Id_NhanVien = people.Id_NhanVien,
                FirstName = people.FirstName,
                LastName = people.LastName,
                FullName = people.FullName,
                Gender  = people.Gender,
                DOB = people.DOB,
                Email = people.Email,
                Address = people.Address,
                Phone = people.Phone,
            });
            if (!String.IsNullOrEmpty(valueOfSearch))
            {
                model = model.Where(people => people.FullName.ToLower().Contains(valueOfSearch.ToLower()) 
                || people.Phone.ToLower().Contains(valueOfSearch.ToLower())
                || people.FirstName.ToLower().Contains(valueOfSearch.ToLower())
                || people.LastName.ToLower().Contains(valueOfSearch.ToLower())
                || people.Gender.ToLower().Contains(valueOfSearch.ToLower()));
            }
            return View(model.ToList());
        }

        [HttpGet]
        public IActionResult Create()  //Cấu Hình
        {
            var model = new CreateNhanVienViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateNhanVienViewModel model)
        {
            if (ModelState.IsValid)
            {                

                    var people = new NhanVien
                    {
                        Id_NhanVien = model.Id_NhanVien,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        FullName = model.FullName,
                        Gender = model.Gender,
                        DOB = model.DOB,
                        Email = model.Email,
                        Address = model.Address,
                        Phone = model.Phone,
                    };
                    await _nhanvienService.CreateNhanVienAsSync(people);
                    return RedirectToAction("Index");                
            }
            return View();
        }

        [HttpGet]
        public IActionResult Detail(string id)
        {
            var people = _nhanvienService.GetById(id);
            if (people == null)
            {
                return NotFound();
            }
            var model = new DetailNhanVienViewModel
            {
                Id_NhanVien = people.Id_NhanVien,                
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
            var people = _nhanvienService.GetById(id);
            if (people == null)
            {
                return NotFound();
            }
            var model = new DeleteNhanVienViewModel
            {
                Id_NhanVien = people.Id_NhanVien,
                FullName= people.FullName,
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(DeleteNhanVienViewModel model)
        {
            if (ModelState.IsValid)
            {
                var peopleinhoadon = _hoadonService.GetIdNV(model.Id_NhanVien);
                if (peopleinhoadon != null)
                {
                    ViewBag.error = "Nhân viên tồn tại trong hóa đơn nên không thể xóa";
                    return View();
                }
                await _nhanvienService.DeleteById(model.Id_NhanVien);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            var people = _nhanvienService.GetById(id);
            if (people == null)
            {
                return NotFound();
            }
            var model = new EditNhanVienViewModel
            {
                Id_NhanVien = people.Id_NhanVien,
                FirstName = people.FirstName,
                LastName = people.LastName,
                FullName = people.FullName,
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
        public async Task<IActionResult> Edit(EditNhanVienViewModel model)
        {
            var people = _nhanvienService.GetById(model.Id_NhanVien);
            if (people == null)
            {
                return NotFound();
            }
            people.Id_NhanVien = model.Id_NhanVien;
            people.FirstName = model.FirstName;
            people.LastName = model.LastName;
            people.FullName = model.FullName;
            people.Gender = model.Gender;
            people.DOB = model.DOB;
            people.Email = model.Email;
            people.Address = model.Address;
            people.Phone = model.Phone;

            await _nhanvienService.UpdateNhanVienAsSyncs(people);
            return RedirectToAction("Index");

            //return View();
        }
    }
}
        