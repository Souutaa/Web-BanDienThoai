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
        public async Task CreateAsSync(NhapHang nhapHang)
        {
            _context.Add(nhapHang);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteById(string id)
        {
            var nhapHang = GetById(id);
            if (nhapHang != null)
            {
                _context.NhapHang.Remove(nhapHang);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsSync(NhapHang nhapHang)
        {
            _context?.NhapHang.Remove(nhapHang);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<NhapHang> GetAll()
        {
            return _context.NhapHang.ToList();
        }

        public NhapHang GetById(string id)
        {
            return _context.NhapHang.Where(x => x.Id_NhapHang == id).FirstOrDefault();
        }

        public async Task UpdateById(string id)
        {
            var nhapHang = GetById(id);
            _context.NhapHang.Update(nhapHang);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsSyncs(NhapHang nhapHang)
        {
            _context.NhapHang.Update(nhapHang);
            await _context.SaveChangesAsync();
        }
    }
}

