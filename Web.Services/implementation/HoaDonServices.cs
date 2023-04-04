using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Entities;
using Web.Persistances;

namespace Web.Services.implementation
{
    public class HoaDonServices : IHoaDonServices
    {
        private ApplicationDbContext _context;

        public HoaDonServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateNhanVienAsSync(HoaDon hoaDon)
        {
            _context.Add(hoaDon);
            await _context.SaveChangesAsync();
        }

        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteNhanVien(HoaDon hoaDon)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<HoaDon> GetAll()
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

        public Task UpdateNhanVienAsSyncs(HoaDon hoaDon)
        {
            throw new NotImplementedException();
        }
    }
}
