using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.Entities;
using Web.Services;
using Web.Services.implementation;
using Web_BanDienThoai.Models.SanPham;

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
        public IActionResult Index() //Sản Phẩm
        {
            var model = _sanphamService.GetAll().Select(sanpham => new IndexSanPhamViewModel
            {
                Id_SanPham = sanpham.Id_SanPham,
                Ten_SanPham = sanpham.Ten_SanPham,
                ImageUrl = sanpham.ImageUrl,
                Rom = sanpham.Rom,
                GiaTien = sanpham.GiaTien,
            }).ToList();
            return View(model);
        }
       
        [HttpGet]
        public IActionResult Create() //Sản Phẩm
        {
            var model = new CreateSanPhamViewModel();
            List<SelectListItem> listLoaiSanPham = /*_context.CauHinh*/_loaisanphamService.GetAll().
                Select(c => new SelectListItem
                {
                    Value = c.Id_loai.ToString(),
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
                var sanpham = new SanPham
                {
                    Id_SanPham = model.Id_SanPham,
                    Ten_SanPham = model.Ten_SanPham,
                    GiaTien = model.GiaTien,
                    SoLuong = model.SoLuong,
                    Id_LoaiSanPham = model.Id_SanPham,
                    Rom = model.Rom,
                };

                if (model.ImageUrl != null && model.ImageUrl.Length > 0)
                {

                    var uploadDir = @"images/employees";
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
            return View();
        }

        

        //[HttpGet]
        //public IActionResult Detail(int id)
        //{
        //    var employee = _sanphamService.GetById(id);
        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }
        //    var model = new DetailEmployeeViewModel
        //    {

        //        Id = employee.Id,
        //        EmployeeNo = employee.EmployeeNo,
        //        FullName = employee.FullName,
        //        Gender = employee.Gender,
        //        DOB = employee.DOB,
        //        DateJoined = employee.DateJoined,
        //        Designation = employee.Designation,
        //        NationalInsuranceNo = employee.NationalInsuranceNo,
        //        Phone = employee.Phone,
        //        Email = employee.Email,
        //        PaymentMethod = employee.PaymentMethod,
        //        StudentLoan = employee.StudentLoan,
        //        UnionMember = employee.UnionMember,
        //        Address = employee.Address,
        //        City = employee.City,
        //        ImageUrl = employee.ImageUrl,
        //        Postcode = employee.Postcode
        //    };
        //    return View(model);
        //}

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
                Id_LoaiSanPham = sanpham.Id_SanPham,
                Rom = sanpham.Rom,
            };

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
            sanpham.Id_LoaiSanPham = model.Id_LoaiSanPham;
            sanpham.Rom = model.Rom;
           

            if (model.ImageUrl != null && model.ImageUrl.Length > 0)
                {

                    var uploadDir = @"images/employees";
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
            
            return View();
        }
    }
}
