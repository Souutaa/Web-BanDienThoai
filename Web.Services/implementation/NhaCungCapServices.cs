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

        public async Task CreateAsSync(NhaCungCap nhaCungCap)
        {
            _context.Add(nhaCungCap);
            await _context.SaveChangesAsync();
        }
       
        public async Task DeleteAsSync(NhaCungCap nhaCungCap)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteById(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<NhaCungCap> GetAll()
        {
            throw new NotImplementedException();
        }

        public NhaCungCap GetById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsSyncs(NhaCungCap nhaCungCap)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
