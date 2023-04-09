﻿using Microsoft.AspNetCore.Mvc;
using Web.Entities;
using Web.Services;
using Web.Services.implementation;
using Web_BanDienThoai.Models.CauHinh;
using Web_BanDienThoai.Models.MauSac;

namespace Web_BanDienThoai.Controllers
{
    public class MauSacController : Controller
    {
        private IMauSacServices _mausacService;
        private IWebHostEnvironment _webHostEnvironment;

        public MauSacController(IMauSacServices mausacService, IWebHostEnvironment webHostEnvironment)
        {
            _mausacService = mausacService;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var model = _mausacService.GetAll().Select(mausac => new IndexMauSacViewModel
            {
                Id_MauSac = mausac.Id_MauSac,
                TenMauSac = mausac.TenMauSac,
            }).ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create() //Màu Sắc
        {
            var model = new CreateMauSacViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateMauSacViewModel model) //Màu Sắc
        {
            if (ModelState.IsValid)
            {
                var mausac = new MauSac
                {
                    Id_MauSac = model.Id_MauSac,
                    TenMauSac = model.TenMauSac,
                };
                await _mausacService.CreateAsSync(mausac);
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
            var model = _mausacService.GetById(id);
            _mausacService.DeleteAsSync(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(DeleteMauSacViewModel model)
        {
            if (ModelState.IsValid)
            {
                var mauSac = new MauSac
                {
                    Id_MauSac = model.Id_MauSac,
                    TenMauSac = model.TenMauSac,
                };
                _mausacService.DeleteAsSync(mauSac);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditMauSacViewModel model)
        {
            if (ModelState.IsValid)
            {
                var mausac = new MauSac
                {
                    Id_MauSac = model.Id_MauSac,
                    TenMauSac = model.TenMauSac,
                };
                await _mausacService.CreateAsSync(mausac);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}