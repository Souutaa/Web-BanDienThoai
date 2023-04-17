using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.Entities;
using Web.Persistances;
using Web.Services;
using Web.Services.implementation;
using Web_BanDienThoai.Models.CauHinh;
using Web_BanDienThoai.Models.DanhMucCon;
namespace Web_BanDienThoai.Controllers
{
    public class DanhMucConController : Controller
    {
        private IDanhMucConServices _danhmucconService;
        private ICauHinhServices _cauhinhService;
        private IWebHostEnvironment _webHostEnvironment;
        private readonly ApplicationDbContext _context;

        public DanhMucConController(ApplicationDbContext context, IDanhMucConServices danhmucconService, ICauHinhServices cauhinhService, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _danhmucconService = danhmucconService;
            _cauhinhService = cauhinhService;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var cauHinhIds = _cauhinhService.GetAll().Select(ch => ch.Id_CauHinh).ToList();
            var model = _danhmucconService.GetAll().Select(danhmucon => new IndexDanhMucConViewModel
            {
                Id_DanhMucCon = danhmucon.Id_DanhMucCon,
                TenDanhMuc = danhmucon.TenDanhMuc,
                Id_CauHinh = danhmucon.Id_CauHinh
            }).ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new CreateDanhMucConViewModel();
            List<SelectListItem> listCauHinh = /*_context.CauHinh*/_cauhinhService.GetAll().
                Select(c => new SelectListItem
                {
                    Value = c.Id_CauHinh.ToString(),
                    Text = c.Ram,
                }).ToList();

            model.CauHinh = listCauHinh;
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateDanhMucConViewModel model) //Màu Sắc
        {
            if (ModelState.IsValid)
            {
                var cauHinhIds = _cauhinhService.GetAll().Select(ch => ch.Id_CauHinh).ToList();
                var danhMucCon = new DanhMucCon
                {
                    Id_DanhMucCon = model.Id_DanhMucCon,
                    TenDanhMuc = model.TenDanhMuc,
                    Id_CauHinh = model.Id_CauHinh, /*cauHinhIds*/
                };
                await _danhmucconService.CreateAsSync(danhMucCon);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Detail(string id)
        {
            var dmc = _danhmucconService.GetById(id);
            if (dmc == null)
            {
                return NotFound();
            }
            var model = new DetailDanhMucConViewModel
            {

                Id_DanhMucCon = dmc.Id_CauHinh,
                TenDanhMuc = dmc.TenDanhMuc,
                Id_CauHinh = dmc.Id_CauHinh,               
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            var danhMucCon = _danhmucconService.GetById(id);
            if (danhMucCon == null)
            {
                return NotFound();
            }
            var model = new DeleteDanhMucConViewModel
            {
                Id_DanhMucCon = danhMucCon.Id_DanhMucCon,
                TenDanhMuc = danhMucCon.TenDanhMuc,
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(DeleteDanhMucConViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _danhmucconService.DeleteById(model.Id_DanhMucCon);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            var danhMucCon = _danhmucconService.GetById(id);
            if (danhMucCon == null)
            {
                return NotFound();
            }
            var model = new EditDanhMucConViewModel
            {
                Id_DanhMucCon = danhMucCon.Id_DanhMucCon,
                TenDanhMuc = danhMucCon.TenDanhMuc,
                Id_CauHinh = danhMucCon.Id_CauHinh,
            };
            List<SelectListItem> listCauHinh = /*_context.CauHinh*/_cauhinhService.GetAll().
               Select(c => new SelectListItem
               {
                   Value = c.Id_CauHinh.ToString(),
                   Text = c.Ram,
               }).ToList();

            model.CauHinh = listCauHinh;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditDanhMucConViewModel model)
        {
            var danhMucCon = _danhmucconService.GetById(model.Id_DanhMucCon);
            if (danhMucCon == null)
            {
                return NotFound();
            }
            danhMucCon.Id_DanhMucCon = model.Id_DanhMucCon;
            danhMucCon.TenDanhMuc = model.TenDanhMuc;            
            danhMucCon.Id_CauHinh = model.Id_CauHinh;

            await _danhmucconService.UpdateAsSyncs(danhMucCon);
            //return RedirectToAction("Index");

            return View();
        }
    }
}
