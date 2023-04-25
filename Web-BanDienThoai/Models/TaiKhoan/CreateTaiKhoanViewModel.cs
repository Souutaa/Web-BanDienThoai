﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using Web.Entities;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace Web_BanDienThoai.Models.TaiKhoan
{
    public class CreateTaiKhoanViewModel : Web.Entities.TaiKhoan
    {
        [Required, MinLength(6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, MinLength(6)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and password confirmation is not match!")]
        public string ConfirmPassword { get; set; }
    }
}
