using Microsoft.AspNetCore.Mvc;
using Web.Entities;
using Web.Services;
using Web.Services.implementation;
using Web_BanDienThoai.Models.MauSac;
using Web_BanDienThoai.Models.NhaCungCap;
using Web_BanDienThoai.Models.NhanVien;

namespace Web_BanDienThoai.Controllers
{
    public class NhaCungCapController : Controller
    {
        private INhaCungCapServices _nhacungcapService;
        private IWebHostEnvironment _webHostEnvironment;

        public NhaCungCapController(INhaCungCapServices nhacungcapService, IWebHostEnvironment webHostEnvironment)
        {
            _nhacungcapService = nhacungcapService;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index(string valueOfSearch)
        {
            var model = _nhacungcapService.GetAll().Select(nhacungcap => new IndexNhaCungCapViewModel
            {
                Id_NhaCungCap= nhacungcap.Id_NhaCungCap,
                Name = nhacungcap.Name,
                Email = nhacungcap.Email,
                Address = nhacungcap.Address,
                Phone = nhacungcap.Phone,
            }).ToList();

            if (!String.IsNullOrEmpty(valueOfSearch))
            {
                model = model.Where(cauhinh => cauhinh.Id_NhaCungCap.ToLower().Contains(valueOfSearch.ToLower())
                || cauhinh.Name.ToLower().Contains(valueOfSearch.ToLower())
                || cauhinh.Phone.ToLower().Contains(valueOfSearch.ToLower()));
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()  //Nhà Cung Cấp
        {
            var model = new CreateNhaCungCapViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateNhaCungCapViewModel model) 
        {
            if (ModelState.IsValid)
            {
                var nhacungcap = new NhaCungCap
                {
                    Id_NhaCungCap = model.Id_NhaCungCap,
                    Name = model.Name,
                    Email = model.Email,
                    Address = model.Address,
                    Phone = model.Phone,
                };
                await _nhacungcapService.CreateAsSync(nhacungcap);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Detail(string id)
        {
            var ncc = _nhacungcapService.GetById(id);
            if (ncc == null)
            {
                return NotFound();
            }
            var model = new DetailNhaCungCapViewModel
            {
                Id_NhaCungCap = ncc.Id_NhaCungCap,
                Name = ncc.Name,
                Email = ncc.Email,
                Address = ncc.Address,
                Phone = ncc.Phone,               
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            var nhacungcap = _nhacungcapService.GetById(id);
            if (nhacungcap == null)
            {
                return NotFound();
            }
            var model = new DeleteNhaCungCapViewModel
            {
                Id_NhaCungCap = nhacungcap.Id_NhaCungCap,
                Name = nhacungcap.Name,
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(DeleteNhaCungCapViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _nhacungcapService.DeleteById(model.Id_NhaCungCap);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            var nhacungcap = _nhacungcapService.GetById(id);
            if (nhacungcap == null)
            {
                return NotFound();
            }
            var model = new EditNhaCungCapViewModel
            {
                Id_NhaCungCap = nhacungcap.Id_NhaCungCap,
                Name = nhacungcap.Name,
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditNhaCungCapViewModel model)
        {
            var nhacungcap = _nhacungcapService.GetById(model.Id_NhaCungCap);
            if (nhacungcap == null)
            {
                return NotFound();
            }
            nhacungcap.Id_NhaCungCap = model.Id_NhaCungCap;
            nhacungcap.Name = model.Name;
            //return RedirectToAction("Index");

            return View();
        }
    }
}
