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
        public async Task CreateAsSync(HoaDon hoaDon)
        {
            _context.Add(hoaDon);
            await _context.SaveChangesAsync();
        }

        public Task DeleteById(string id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsSync(HoaDon hoaDon)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<HoaDon> GetAll()
        {
            throw new NotImplementedException();
        }

        public HoaDon GetById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsSyncs(HoaDon hoaDon)
        {
            throw new NotImplementedException();
        }
    }
}
