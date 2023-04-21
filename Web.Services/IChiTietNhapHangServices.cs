using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Entities;

namespace Web.Services
{
    public interface IChiTietNhapHangServices
    {
        IEnumerable<ChiTietNhapHang> GetAll();
        ChiTietNhapHang GetById(string id);
        IEnumerable<SelectListItem> GetID(string id);
        SanPham GetbyIDListSanPham(string id);
        Task CreateAsSync(ChiTietNhapHang ctnh);
        Task UpdateAsSyncs(ChiTietNhapHang ctnh);
        Task UpdateById(string id);
        Task DeleteById(string id);
        Task DeleteAsSync(ChiTietNhapHang ctnh);
        IEnumerable<SelectListItem> GetAllSanPham();
    }
}
