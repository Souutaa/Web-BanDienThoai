﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Entities;

namespace Web.Services
{
    public interface IChiTietHoaDonServices
    {
        IEnumerable<ChiTietHoaDon> GetAll();
        ChiTietHoaDon GetById(string id);
        IEnumerable<SelectListItem> GetID(string id);
        List<ChiTietHoaDon> GetChiTietsID (string id);
        SanPham GetbyIDListSanPham(string id);
        Task CreateAsSync(ChiTietHoaDon cthoaDon);
        Task UpdateAsSyncs(ChiTietHoaDon hoaDon);
        Task UpdateById(string id);
        Task DeleteById(string id);
        Task DeleteAsSync(ChiTietHoaDon cthoaDon);
        IEnumerable<SelectListItem> GetAllSanPham();
    }
}
