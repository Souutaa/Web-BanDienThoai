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

        public async Task DeleteById(string id)
        {
            var nhacungcap = GetById(id);
            if (nhacungcap != null)
            {
                _context.NhaCungCap.Remove(nhacungcap);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsSync(NhaCungCap nhaCungCap)
        {
            _context?.NhaCungCap.Remove(nhaCungCap);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<NhaCungCap> GetAll()
        {
            return _context.NhaCungCap.ToList();
        }

        public NhaCungCap GetById(string id)
        {
            return _context.NhaCungCap.Where(x => x.Id_NhaCungCap == id).FirstOrDefault();
        }

        public async Task UpdateById(string id)
        {
            var nhaCungCap = GetById(id);
            _context.NhaCungCap.Update(nhaCungCap);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsSyncs(NhaCungCap nhaCungCap)
        {
            _context.NhaCungCap.Update(nhaCungCap);
            await _context.SaveChangesAsync();
        }
    }
}
