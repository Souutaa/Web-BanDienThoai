using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Entities;
using Web.Persistances;

namespace Web.Services.implementation
{
    public class SanPhamServices : ISanPhamServices
    {
        private ApplicationDbContext _context;

        public SanPhamServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateNhanVienAsSync(SanPham sanPham)
        {
            _context.Add(sanPham);
            await _context.SaveChangesAsync();
        }

        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteNhanVien(SanPham sanPham)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SanPham> GetAll()
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

        public Task UpdateNhanVienAsSyncs(SanPham sanPham)
        {
            throw new NotImplementedException();
        }
    }
}
