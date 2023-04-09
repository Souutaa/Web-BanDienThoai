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
            var loaiSanPham = GetById(id);
            if (loaiSanPham != null)
            {
                _context.LoaiSanPham.Remove(loaiSanPham);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsSync(LoaiSanPham loaiSanPham)
        {
            _context?.LoaiSanPham.Remove(loaiSanPham);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<LoaiSanPham> GetAll()
        {
            return _context.LoaiSanPham.ToList();
        }

        public LoaiSanPham GetById(string id)
        {
            return _context.LoaiSanPham.Where(x => x.Id_loai == id).FirstOrDefault();
        }

        public async Task UpdateById(string id)
        {
            var loaiSanPham = GetById(id);
            _context.LoaiSanPham.Update(loaiSanPham);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsSyncs(LoaiSanPham loaiSanPham)
        {
            _context.LoaiSanPham.Update(loaiSanPham);
            await _context.SaveChangesAsync();
        }
    }
}

