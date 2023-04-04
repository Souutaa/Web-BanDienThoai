using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Entities;

namespace Web.Services
{
    public interface INhaCungCapServices
    {
        IEnumerable<NhaCungCap> GetAll();
        NhanVien GetById(int id);
        Task CreateNhanVienAsSync(NhaCungCap nhaCungCap);
        Task UpdateNhanVienAsSyncs(NhaCungCap nhaCungCap);
        Task UpdateById(int id);
        Task DeleteById(int id);
        Task DeleteNhanVien(NhaCungCap nhaCungCap);
    }
}
