using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Entities;

namespace Web.Services
{
    public interface ILoaiSanPhamServices
    {
        IEnumerable<LoaiSanPham> GetAll();
        NhanVien GetById(int id);
        Task CreateNhanVienAsSync(LoaiSanPham loaiSanPham);
        Task UpdateNhanVienAsSyncs(LoaiSanPham loaiSanPham);
        Task UpdateById(int id);
        Task DeleteById(int id);
        Task DeleteNhanVien(LoaiSanPham loaiSanPham);
    }
}
