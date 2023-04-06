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
        NhanVien GetById(string id);
        Task CreateNhanVienAsSync(NhanVien nhanVien);
        Task UpdateNhanVienAsSyncs(NhanVien nhanVien);
        Task UpdateById(string id);
        Task DeleteById(string id);
        Task DeleteNhanVien(NhanVien nhanVien);
    }
}
