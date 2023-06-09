﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.Entities;
using Web.Persistances;
using Web.Services;
using Web_BanDienThoai.Models.DanhMucCon;
using Web_BanDienThoai.Models.LoaiSanPham;

namespace Web_BanDienThoai.Controllers
{
    public class LoaiSanPhamController : Controller
    {
        private ILoaiSanPhamServices _loaisanphamService;
        private IMauSacServices _mausacService;
        private IDanhMucConServices _danhmucconService;
        private IWebHostEnvironment _webHostEnvironment;
        private readonly ApplicationDbContext _context;

        public LoaiSanPhamController(ApplicationDbContext context, ILoaiSanPhamServices loaisanphamService, 
            IMauSacServices mausacService, IWebHostEnvironment webHostEnvironment, IDanhMucConServices danhmucconService)
        {
            _context = context;
            _loaisanphamService = loaisanphamService;
            _mausacService = mausacService;
            _webHostEnvironment = webHostEnvironment;
            _danhmucconService = danhmucconService;
        }

        public IActionResult Index(string valueOfSearch)
        {
            var DanhMucIds = _danhmucconService.GetAll().Select(dm => dm.Id_DanhMucCon).ToList();
            var MauSacIds = _mausacService.GetAll().Select(ms => ms.Id_MauSac).ToList();

            var model = _loaisanphamService.GetAll().Select(loaisanpham => new IndexLoaiSanPhamViewModel
            {
                Id_loai = loaisanpham.Id_loai,
                TenLoai = loaisanpham.TenLoai,
                Id_DanhMucCon = loaisanpham.Id_DanhMucCon,
                Id_MauSac = loaisanpham.Id_MauSac,               
            });

            if (!String.IsNullOrEmpty(valueOfSearch))
            {
                model = model.Where(cauhinh => cauhinh.Id_loai.ToLower().Contains(valueOfSearch.ToLower())
                || cauhinh.TenLoai.ToLower().Contains(valueOfSearch.ToLower())
                || cauhinh.Id_DanhMucCon.ToLower().Contains(valueOfSearch.ToLower())
                || cauhinh.Id_MauSac.ToLower().Contains(valueOfSearch.ToLower()));
            }
            return View(model.ToList());

        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new CreateLoaiSanPhamViewModel();
            List<SelectListItem> listDanhMucCon = _danhmucconService.GetAll().
                Select(c => new SelectListItem
                {
                    Value = c.Id_DanhMucCon.ToString(),
                    Text = c.TenDanhMuc
                }).ToList();
            model.DanhMucCon = listDanhMucCon;

            List<SelectListItem> listMauSac = _mausacService.GetAll().
                Select(c => new SelectListItem
            {
                Value = c.Id_MauSac.ToString(),
                Text = c.TenMauSac
            }).ToList();
            model.MauSac = listMauSac;
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateLoaiSanPhamViewModel model) //Màu Sắc
        {
            if (ModelState.IsValid)
            {
                var tenmausac = _mausacService.GetById(model.Id_MauSac);
                var tendanhmuc = _danhmucconService.GetById(model.Id_DanhMucCon);
                var check = _loaisanphamService.GetAll().FirstOrDefault(s => s.Id_loai == model.Id_loai);
                if (check == null)
                {                    
                    var loaisanpham = new LoaiSanPham
                    {
                        Id_loai = model.Id_loai.ToUpper(),
                        TenLoai = tendanhmuc.TenDanhMuc +" ("+ tenmausac.TenMauSac +")",
                        Id_DanhMucCon = model.Id_DanhMucCon,
                        Id_MauSac = model.Id_MauSac,
                    };
                    await _loaisanphamService.CreateAsSync(loaisanpham);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Error = "Mã Loại Sản Phẩm này đã được tồn tại! Vui lòng tạo Mã Loại Sản Phẩm khác";
                    return View(model);
                }
            }            
            return View();
        }

        public IActionResult Detail(string id)
        {
            var lsp = _loaisanphamService.GetById(id);
            if (lsp == null)
            {
                return NotFound();
            }
            var model = new DetailLoaiSanPhamViewModel
            {
                Id_loai = lsp.Id_loai,
                TenLoai = lsp.TenLoai,
                Id_DanhMucCon = lsp.Id_DanhMucCon,
                Id_MauSac = lsp.Id_MauSac,
            };
            return View(model);
        }


        [HttpGet]
        public IActionResult Delete(string id)
        {
            var loaisanpham = _loaisanphamService.GetById(id);
            if (loaisanpham == null)
            {
                return NotFound();
            }
            var model = new DeleteLoaiSanPhamViewModel
            {
                Id_loai = loaisanpham.Id_loai,
                TenLoai = loaisanpham.TenLoai,
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(DeleteLoaiSanPhamViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _loaisanphamService.DeleteById(model.Id_loai);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            var loaisanpham = _loaisanphamService.GetById(id);
            if (loaisanpham == null)
            {
                return NotFound();
            }
            var model = new EditLoaiSanPhamViewModel
            {
                Id_loai = loaisanpham.Id_loai,
                TenLoai = loaisanpham.TenLoai,
                Id_DanhMucCon = loaisanpham.Id_DanhMucCon,
                Id_MauSac = loaisanpham.Id_MauSac,
            };
            List<SelectListItem> listDanhMucCon = _danhmucconService.GetAll().
                Select(c => new SelectListItem
                {
                    Value = c.Id_DanhMucCon.ToString(),
                    Text = c.TenDanhMuc
                }).ToList();
            model.DanhMucCon = listDanhMucCon;

            List<SelectListItem> listMauSac = _mausacService.GetAll().
                Select(c => new SelectListItem
                {
                    Value = c.Id_MauSac.ToString(),
                    Text = c.TenMauSac
                }).ToList();
            model.MauSac = listMauSac;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditLoaiSanPhamViewModel model)
        {
            var loaisanpham = _loaisanphamService.GetById(model.Id_loai);
            var tenmausac = _mausacService.GetById(model.Id_MauSac);
            var tendanhmuc = _danhmucconService.GetById(model.Id_DanhMucCon);
            if (loaisanpham == null)
            {
                return NotFound();
            }
            loaisanpham.Id_loai = model.Id_loai;
            loaisanpham.TenLoai = tendanhmuc.TenDanhMuc + " (" + tenmausac.TenMauSac + ")";
            loaisanpham.Id_DanhMucCon = model.Id_DanhMucCon;
            loaisanpham.Id_MauSac = model.Id_MauSac;
            await _loaisanphamService.UpdateAsSyncs(loaisanpham);

            return RedirectToAction("Index");

            //return View(model);
        }
    }
}