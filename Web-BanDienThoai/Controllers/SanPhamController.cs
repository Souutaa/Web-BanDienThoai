using Microsoft.AspNetCore.Mvc;
using Web.Entities;
using Web.Services;
using Web.Services.implementation;
using Web_BanDienThoai.Models.SanPham;

namespace Web_BanDienThoai.Controllers

{
    public class SanPhamController : Controller
    {
        private ISanPhamServices _sanphamService;
        private IWebHostEnvironment _webHostEnvironment;
        public SanPhamController(ISanPhamServices sanphamService, IWebHostEnvironment webHostEnvironment)
        {
            _sanphamService = sanphamService;           
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
            if (id.ToString() == null)
            {
                return NotFound();
            }
            var model = _sanphamService.GetById(id);
            _sanphamService.DeleteAsSync(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(DeleteSanPhamViewModel model)
        {
            if (ModelState.IsValid)
            {
                var employee = new SanPham
                {
                    Id_SanPham = model.Id_SanPham,
                    Ten_SanPham = model.Ten_SanPham,
                };
                _sanphamService.DeleteAsSync(employee);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditSanPhamViewModel model)
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
    }
}
