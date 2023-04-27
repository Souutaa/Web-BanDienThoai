using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Entities;

namespace Web.Services
{
    public interface IHoaDonServices
    {
        IEnumerable<HoaDon> GetAll();
        HoaDon GetById(string id); 

        //NhanVien GetIdNV (string id);
        Task CreateAsSync(HoaDon hoaDon); 
        Task UpdateAsSyncs(HoaDon hoaDon); 
        Task UpdateById(string id); 
        Task DeleteById(string id); 
        Task DeleteAsSync(HoaDon hoaDon);
        IEnumerable<SelectListItem> GetAllSanPham();
    }
}
