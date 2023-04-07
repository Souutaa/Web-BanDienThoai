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
            var mausac = GetById(id);
            if (mausac != null)
            {
                _context.MauSac.Remove(mausac);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsSync(MauSac mauSac)
        {
            _context?.MauSac.Remove(mauSac);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<MauSac> GetAll()
        {
            return _context.MauSac.ToList();
        }

        public MauSac GetById(string id)
        {
            return _context.MauSac.Where(x => x.Id_MauSac == id).FirstOrDefault();
        }

        public async Task UpdateById(string id)
        {
            var mausac = GetById(id);
            _context.MauSac.Update(mausac);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsSyncs(MauSac mauSac)
        {
            _context.MauSac.Update(mauSac);
            await _context.SaveChangesAsync();
        }
    }
}
