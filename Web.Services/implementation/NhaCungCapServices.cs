using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Entities;
using Web.Persistances;

namespace Web.Services.implementation
{
    public class NhaCungCapServices : INhaCungCapServices
    {
        private ApplicationDbContext _context;

        public NhaCungCapServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateNhanVienAsSync(NhaCungCap nhaCungCap)
        {
            _context.Add(nhaCungCap);
            await _context.SaveChangesAsync();
        }

        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteNhanVien(NhaCungCap nhaCungCap)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<NhaCungCap> GetAll()
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

        public Task UpdateNhanVienAsSyncs(NhaCungCap nhaCungCap)
        {
            throw new NotImplementedException();
        }
    }
}
