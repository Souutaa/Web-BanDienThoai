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
        public async Task CreateAsSync(MauSac mauSac)
        {
            _context.Add(mauSac);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsSync(MauSac mauSac)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MauSac> GetAll()
        {
            throw new NotImplementedException();
        }

        public MauSac GetById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsSyncs(MauSac mauSac)
        {
            throw new NotImplementedException();
        }
    }
}
