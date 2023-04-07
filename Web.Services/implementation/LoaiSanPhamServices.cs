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
        public async Task CreateAsSync(LoaiSanPham loaiSanPham)
        {
            _context.Add(loaiSanPham);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsSync(LoaiSanPham loaiSanPham)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LoaiSanPham> GetAll()
        {
            throw new NotImplementedException();
        }

        public LoaiSanPham GetById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsSyncs(LoaiSanPham loaiSanPham)
        {
            throw new NotImplementedException();
        }
    }
}
