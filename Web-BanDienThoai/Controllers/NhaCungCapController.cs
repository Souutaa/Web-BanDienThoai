using Microsoft.AspNetCore.Mvc;
using Web.Entities;
using Web.Services;
using Web_BanDienThoai.Models.NhaCungCap;

namespace Web_BanDienThoai.Controllers
{
    public class NhaCungCapController : Controller
    {
        private INhaCungCapServices _nhacungcapService;
        private IWebHostEnvironment _webHostEnvironment;

        public NhaCungCapController()
        {
        }

        public NhaCungCapController(INhaCungCapServices nhacungcapService, IWebHostEnvironment webHostEnvironment)
        {
            _nhacungcapService = nhacungcapService;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var model = _nhacungcapService.GetAll().Select(nhacungcap => new IndexNhaCungCapViewModel
            {
                Name = nhacungcap.Name,
                Email = nhacungcap.Email,
                Address = nhacungcap.Address,
                Phone = nhacungcap.Phone,
            }).ToList();
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
        public async Task<IActionResult> Create(CreateNhaCungCapViewModel model) //Màu Sắc
        {
            if (ModelState.IsValid)
            {
                var nhacungcap = new NhaCungCap
                {
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

        [HttpGet]
        public IActionResult Delete(string id)
        {
            if (id.ToString() == null)
            {
                return NotFound();
            }
            var model = _nhacungcapService.GetById(id);
            _nhacungcapService.DeleteAsSync(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(DeleteNhaCungCapViewModel model)
        {
            if (ModelState.IsValid)
            {
                var nhacungcap = new NhaCungCap
                {
                    Id_NhaCungCap = model.Id_NhaCungCap,
                    Name = model.Name,
                };
                _nhacungcapService.DeleteAsSync(nhacungcap);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditNhaCungCapViewModel model)
        {
            if (ModelState.IsValid)
            {
                var nhacungcap = new NhaCungCap
                {
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
    }
}

