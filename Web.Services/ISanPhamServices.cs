using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Entities;

namespace Web.Services
{
    public interface ISanPhamServices
    {
        IEnumerable<SanPham> GetAll();
        NhanVien GetById(int id);
        Task CreateNhanVienAsSync(SanPham sanPham);
        Task UpdateNhanVienAsSyncs(SanPham sanPham);
        Task UpdateById(int id);
        Task DeleteById(int id);
        Task DeleteNhanVien(SanPham sanPham);
    }
}
