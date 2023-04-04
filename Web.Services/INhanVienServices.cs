using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Entities;

namespace Web.Services
{
    public interface INhanVienServices
    {
        IEnumerable<NhanVien> GetAll();
        NhanVien GetById(int id);
        Task CreateNhanVienAsSync(NhanVien nhanVien);
        Task UpdateNhanVienAsSyncs(NhanVien nhanVien);
        Task UpdateById(int id);
        Task DeleteById(int id);
        Task DeleteNhanVien(NhanVien nhanVien);
    }
}
