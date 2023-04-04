using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Entities;

namespace Web.Services
{
    public interface IMauSacServices
    {
        IEnumerable<MauSac> GetAll();
        NhanVien GetById(int id);
        Task CreateNhanVienAsSync(MauSac mauSac);
        Task UpdateNhanVienAsSyncs(MauSac mauSac);
        Task UpdateById(int id);
        Task DeleteById(int id);
        Task DeleteNhanVien(MauSac mauSac);
    }
}
