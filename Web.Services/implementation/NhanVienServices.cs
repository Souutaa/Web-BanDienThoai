using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Entities;
using Web.Persistances;

namespace Web.Services.implementation
{
    public class NhanVienServices : INhanVienServices
    {
        private ApplicationDbContext _context;

        public NhanVienServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateNhanVienAsSync(NhanVien nhanVien)
        {
            _context.Add(nhanVien);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteById(string id)
        {
            var nhanVien = GetById(id);
            if (nhanVien != null)
            {
                _context.NhanVien.Remove(nhanVien);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteNhanVien(NhanVien nhanVien)
        {
            _context?.NhanVien.Remove(nhanVien);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<NhanVien> GetAll()
        {
            return _context.NhanVien.ToList();
        }

        public NhanVien GetById(string id)
        {
            return _context.NhanVien.Where(x => x.Id_NhanVien == id).FirstOrDefault();
        }

        public async Task UpdateById(string id)
        {
            var nhanVien = GetById(id);
            _context.NhanVien.Update(nhanVien);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateNhanVienAsSyncs(NhanVien nhanVien)
        {
            _context.NhanVien.Update(nhanVien);
            await _context.SaveChangesAsync();
        }
    }
}
