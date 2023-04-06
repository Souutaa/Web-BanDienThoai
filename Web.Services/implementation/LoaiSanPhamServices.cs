using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Entities;
using Web.Persistances;

namespace Web.Services.implementation
{
    public class LoaiSanPhamServices : ILoaiSanPhamServices
    {
        private ApplicationDbContext _context;

        public LoaiSanPhamServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateNhanVienAsSync(LoaiSanPham loaiSanPham)
        {
            _context.Add(loaiSanPham);
            await _context.SaveChangesAsync();
        }

        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteNhanVien(LoaiSanPham loaiSanPham)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LoaiSanPham> GetAll()
        {
            throw new NotImplementedException();
        }

        public NhanVien GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateNhanVienAsSyncs(LoaiSanPham loaiSanPham)
        {
            throw new NotImplementedException();
        }
    }
}
