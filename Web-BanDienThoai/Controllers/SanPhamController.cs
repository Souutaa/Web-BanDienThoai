using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.Entities;
using Web.Services;
using Web.Services.implementation;
using Web_BanDienThoai.Models.NhanVien;
using Web_BanDienThoai.Models.SanPham;
using PagedList;

namespace Web_BanDienThoai.Controllers

{
    public class SanPhamController : Controller
    {
        private ISanPhamServices _sanphamService;
        private ILoaiSanPhamServices _loaisanphamService;
        private IWebHostEnvironment _webHostEnvironment;
        public SanPhamController(ISanPhamServices sanphamService, IWebHostEnvironment webHostEnvironment, ILoaiSanPhamServices loaisanphamService)
        {
            _sanphamService = sanphamService;
            _loaisanphamService = loaisanphamService;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index(/*string valueOfSearch,*/ int? page) //Sản Phẩm
        {           
            int pageSize = 1;

            if(page == null)
            {
                page = 1;
            }           

            var model = _sanphamService.GetAll().Select(sanpham => new IndexSanPhamViewModel
            {
                Id_SanPham = sanpham.Id_SanPham,
                Ten_SanPham = sanpham.Ten_SanPham,
                ImageUrl = sanpham.ImageUrl,
                GiaTien = sanpham.GiaTien,
            }).OrderBy(x => x.Id_SanPham).ToList();

            //if (!String.IsNullOrEmpty(valueOfSearch))
            //{
            //    model = model.Where(people => people.Id_SanPham.ToLower().Contains(valueOfSearch.ToLower())
            //    || people.Ten_SanPham.ToLower().Contains(valueOfSearch.ToLower())
            //    || people.GiaTien.Equals(valueOfSearch));
            //}
           
            return View(model.ToPagedList((int)page, pageSize));
        }


       
        [HttpGet]
        public IActionResult Create() //Sản Phẩm
        {
            var model = new CreateSanPhamViewModel();
            List<SelectListItem> listLoaiSanPham = /*_context.CauHinh*/_loaisanphamService.GetAll().
                Select(c => new SelectListItem
                {
                    Value = c.Id_loai,
                    Text = c.TenLoai,
                }).ToList();

            model.LoaiSanPham = listLoaiSanPham;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateSanPhamViewModel model) //Sản Phẩm
        {
            if (ModelState.IsValid)
            {
                
                    var check = _sanphamService.GetAll().FirstOrDefault(s => s.Id_SanPham == model.Id_SanPham);
                //var checkLoai = _sanphamService.GetAll().FirstOrDefault(s => s.Id_loai == model.Id_loai);
                if (check == null /*&& (checkLoai == null || checkLoai != null)*/)
                {
                    var sanpham = new SanPham
                    {
                        Id_SanPham = model.Id_SanPham,
                        Ten_SanPham = model.Ten_SanPham,
                        GiaTien = model.GiaTien,
                        SoLuong = model.SoLuong,
                        Id_loai = model.Id_loai,
                        Rom = model.Rom,
                    };

                    if (model.ImageUrl != null && model.ImageUrl.Length > 0)
                    {

                        var uploadDir = @"images/SanPham";
                        var fileName = Path.GetFileNameWithoutExtension(model.ImageUrl.FileName);
                        var extension = Path.GetExtension(model.ImageUrl.FileName);
                        var webRootPath = _webHostEnvironment.WebRootPath;
                        fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extension;
                        var path = Path.Combine(webRootPath, uploadDir, fileName);
                        await model.ImageUrl.CopyToAsync(new FileStream(path, FileMode.Create));
                        sanpham.ImageUrl = "/" + uploadDir + "/" + fileName;
                        await _sanphamService.CreateAsSync(sanpham);
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    ViewBag.Error = "Mã Sản Phẩm này đã được tồn tại! Vui lòng tạo Mã Sản Phẩm khác";
                    return View(model);
                }

                    
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Detail(string id)
        {
            var sp = _sanphamService.GetById(id);
            if (sp == null)
            {
                return NotFound();
            }
            var model = new DetailSanPhamViewModel
            {
                Id_SanPham = sp.Id_SanPham,
                Ten_SanPham = sp.Ten_SanPham,
                GiaTien = sp.GiaTien,
                SoLuong = sp.SoLuong,
                Id_loai = sp.Id_loai,
                Rom = sp.Rom,
                ImageUrl = sp.ImageUrl
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            var sanpham = _sanphamService.GetById(id);
            if (sanpham == null)
            {
                return NotFound();
            }
            var model = new DeleteSanPhamViewModel
            {
                Id_SanPham = sanpham.Id_SanPham,
                Ten_SanPham = sanpham.Ten_SanPham,
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(DeleteSanPhamViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _sanphamService.DeleteById(model.Id_SanPham);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            var sanpham = _sanphamService.GetById(id);
            if (sanpham == null)
            {
                return NotFound();
            }
            var model = new EditSanPhamViewModel
            {
                Id_SanPham = sanpham.Id_SanPham,
                Ten_SanPham = sanpham.Ten_SanPham,
                GiaTien = sanpham.GiaTien,
                SoLuong = sanpham.SoLuong,
                Id_loai = sanpham.Id_loai,
                Rom = sanpham.Rom,
            };

            List<SelectListItem> listLoaiSanPham = /*_context.CauHinh*/_loaisanphamService.GetAll().
               Select(c => new SelectListItem
               {
                   Value = c.Id_loai,
                   Text = c.TenLoai,
               }).ToList();

            model.LoaiSanPham = listLoaiSanPham;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditSanPhamViewModel model)
        {
            var sanpham = _sanphamService.GetById(model.Id_SanPham);
            if (sanpham == null)
            {
                return NotFound();
            }
            sanpham.Id_SanPham = model.Id_SanPham;
            sanpham.Ten_SanPham = model.Ten_SanPham;
            sanpham.GiaTien = model.GiaTien;
            sanpham.SoLuong = model.SoLuong;
            sanpham.Id_loai = model.Id_loai;
            sanpham.Rom = model.Rom;


            if (model.ImageUrl != null && model.ImageUrl.Length > 0)
            {

                var uploadDir = @"images/SanPham";
                var fileName = Path.GetFileNameWithoutExtension(model.ImageUrl.FileName);
                var extension = Path.GetExtension(model.ImageUrl.FileName);
                var webRootPath = _webHostEnvironment.WebRootPath;
                fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extension;
                var path = Path.Combine(webRootPath, uploadDir, fileName);
                await model.ImageUrl.CopyToAsync(new FileStream(path, FileMode.Create));
                sanpham.ImageUrl = "/" + uploadDir + "/" + fileName;
                await _sanphamService.UpdateAsSyncs(sanpham);
                return RedirectToAction("Index");
            }

            return View();
        }

    }
}