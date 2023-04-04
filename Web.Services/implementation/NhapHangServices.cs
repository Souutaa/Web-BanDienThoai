using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Entities;
using Web.Persistances;

namespace Web.Services.implementation
{
    public class NhapHangServices : INhapHangServices
    {
        private ApplicationDbContext _context;

        public NhapHangServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateNhanVienAsSync(NhapHang nhapHang)
        {
            _context.Add(nhapHang);
            await _context.SaveChangesAsync();
        }

        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteNhanVien(NhapHang nhapHang)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<NhapHang> GetAll()
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

        public Task UpdateNhanVienAsSyncs(NhapHang nhapHang)
        {
            throw new NotImplementedException();
        }
    }
}
