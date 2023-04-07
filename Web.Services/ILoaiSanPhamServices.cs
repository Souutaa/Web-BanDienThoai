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
        LoaiSanPham GetById(string id); 
        Task CreateAsSync(LoaiSanPham loaiSanPham); 
        Task UpdateAsSyncs(LoaiSanPham loaiSanPham); 
        Task UpdateById(string id); 
        Task DeleteById(string id); 
        Task DeleteAsSync(LoaiSanPham loaiSanPham);
    }
}
