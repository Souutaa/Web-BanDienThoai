using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Entities;

namespace Web.Services
{
    public interface IDanhMucConServices
    {
        IEnumerable<DanhMucCon> GetAll();
        NhanVien GetById(int id);
        Task CreateNhanVienAsSync(DanhMucCon danhMucCon);
        Task UpdateNhanVienAsSyncs(DanhMucCon danhMucCon);
        Task UpdateById(int id);
        Task DeleteById(int id);
        Task DeleteNhanVien(DanhMucCon danhMucCon);
    }
}
