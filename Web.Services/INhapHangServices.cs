using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Entities;

namespace Web.Services
{
    public interface INhapHangServices
    {
        IEnumerable<NhapHang> GetAll();
        NhanVien GetById(int id);
        Task CreateNhanVienAsSync(NhapHang nhapHang);
        Task UpdateNhanVienAsSyncs(NhapHang nhapHang);
        Task UpdateById(int id);
        Task DeleteById(int id);
        Task DeleteNhanVien(NhapHang nhapHang);
    }
}
