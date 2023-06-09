﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web_BanDienThoai.Models.TaiKhoan;
using Web.Entities;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.AspNetCore.Authorization;

namespace Web_BanDienThoai.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<TaiKhoan> _userManager;
        private readonly SignInManager<TaiKhoan> _signInManager;
        public UserController(UserManager<TaiKhoan> userManager, SignInManager<TaiKhoan> signInManager) {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            CreateTaiKhoanViewModel model = new CreateTaiKhoanViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(CreateTaiKhoanViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newUser = new TaiKhoan();
                newUser.FullName = model.FullName;
                newUser.UserName = model.UserName;
                newUser.Email = model.Email;
                var result = await _userManager.CreateAsync(newUser, model.Password);
                if (result.Succeeded && !_signInManager.IsSignedIn(User))
                {
                    return RedirectToAction("Login");
                } else if (result.Succeeded && _signInManager.IsSignedIn(User))
                {
                    return RedirectToAction("listusers", "administration");
                } else 
                {
                    throw new Exception(result.Errors.ToString());
                }
            }
            return View();
        }
            
        [HttpGet]
        public IActionResult Login() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginTaiKhoanViewModel model, string returnUrl = null)
        {
  
            if (ModelState.IsValid)
            {
                var checkResult = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);
                if (checkResult.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("index", "sanpham");
                    }
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("index", "sanpham");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View("error");
        }
    }
}
