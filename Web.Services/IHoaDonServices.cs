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
        NhanVien GetById(int id);
        Task CreateNhanVienAsSync(HoaDon hoaDon);
        Task UpdateNhanVienAsSyncs(HoaDon hoaDon);
        Task UpdateById(int id);
        Task DeleteById(int id);
        Task DeleteNhanVien(HoaDon hoaDon);
    }
}
