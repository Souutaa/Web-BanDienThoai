using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Entities;
using Web.Persistances;

namespace Web.Services.implementation
{
    public class CauHinhServices : ICauHinhServices
    {
        private ApplicationDbContext _context;

        public CauHinhServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsSync(CauHinh cauHinh)
        {
            _context.Add(cauHinh);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteById(string id)
        {
            var cauHinh = GetById(id);
            if (cauHinh != null)
            {
                _context.CauHinh.Remove(cauHinh);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsSync(CauHinh cauHinh)
        {
            _context?.CauHinh.Remove(cauHinh);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<CauHinh> GetAll()
        {
            return _context.CauHinh.ToList();
        }

        public CauHinh GetById(string id)
        {
            return _context.CauHinh.Where(x => x.Id_CauHinh == id).FirstOrDefault();
        }

        public async Task UpdateById(string id)
        {
            var cauHinh = GetById(id);
            _context.CauHinh.Update(cauHinh);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsSyncs(CauHinh cauHinh)
        {
            _context.CauHinh.Update(cauHinh);
            await _context.SaveChangesAsync();
        }
    }
}
