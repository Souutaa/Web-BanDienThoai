﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.Entities;
using Web.Persistances;
using Web.Services;
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

        public IActionResult Index()
        {
            var DanhMucIds = _danhmucconService.GetAll().Select(dm => dm.Id_DanhMucCon).ToList();
            var MauSacIds = _mausacService.GetAll().Select(ms => ms.Id_MauSac).ToList();
            var model = _loaisanphamService.GetAll().Select(loaisanpham => new IndexLoaiSanPhamViewModel
            {
                Id_loai = loaisanpham.Id_loai,
                TenLoai = loaisanpham.TenLoai,
                Id_DanhMucCon = loaisanpham.Id_DanhMucCon,
                Id_MauSac = loaisanpham.Id_MauSac,               
            }).ToList();
            return View(model);
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
                var DanhMucIds = _danhmucconService.GetAll().Select(dm => dm.Id_DanhMucCon).ToList();
                var MauSacIds = _mausacService.GetAll().Select(ms => ms.Id_MauSac).ToList();
                var loaisanpham = new LoaiSanPham
                {
                    Id_loai = model.Id_loai,
                    TenLoai = model.TenLoai,
                    Id_DanhMucCon = model.Id_DanhMucCon,
                    Id_MauSac = model.Id_MauSac,
                    /*cauHinhIds*/
                };
                await _loaisanphamService.CreateAsSync(loaisanpham);
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
            var model = _danhmucconService.GetById(id);
            _danhmucconService.DeleteAsSync(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(DeleteLoaiSanPhamViewModel model)
        {
            if (ModelState.IsValid)
            {
                var loaisanpham = new LoaiSanPham
                {
                    Id_loai = model.Id_loai,
                    TenLoai = model.TenLoai,
                };
                _loaisanphamService.DeleteAsSync(loaisanpham);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditLoaiSanPhamViewModel model)
        {
            if (ModelState.IsValid)
            {
                var DanhMucIds = _danhmucconService.GetAll().Select(dm => dm.Id_DanhMucCon).ToList();
                var MauSacIds = _mausacService.GetAll().Select(ms => ms.Id_MauSac).ToList();
                var loaisanpham = new LoaiSanPham
                {
                    Id_loai = model.Id_loai,
                    TenLoai = model.TenLoai,
                    Id_DanhMucCon = model.Id_DanhMucCon,
                    Id_MauSac = model.Id_MauSac,
                    /*cauHinhIds*/
                };
                await _loaisanphamService.CreateAsSync(loaisanpham);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}