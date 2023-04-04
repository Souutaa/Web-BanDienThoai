using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Entities;
using Web.Persistances;

namespace Web.Services.implementation
{
    public class MauSacServices : IMauSacServices
    {
        private ApplicationDbContext _context;

        public MauSacServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateNhanVienAsSync(MauSac mauSac)
        {
            _context.Add(mauSac);
            await _context.SaveChangesAsync();
        }

        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteNhanVien(MauSac mauSac)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MauSac> GetAll()
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

        public Task UpdateNhanVienAsSyncs(MauSac mauSac)
        {
            throw new NotImplementedException();
        }
    }
}
