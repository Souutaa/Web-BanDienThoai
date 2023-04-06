using Web.Entities;
using Web.Persistances;

namespace Web.Services.implementation
{
    public class KhachHangServices : IKhachHangServices
    {
        private ApplicationDbContext _context;

        public KhachHangServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsSync(KhachHang khachHang)
        {
            _context.Add(khachHang);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteById(string id)
        {
            var khachHang = GetById(id);
            if (khachHang != null)
            {
                _context.KhachHang.Remove(khachHang);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsSync(KhachHang khachHang)
        {
            _context?.KhachHang.Remove(khachHang);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<KhachHang> GetAll()
        {
            return _context.KhachHang.ToList();
        }

        public KhachHang GetById(string id)
        {
            return _context.KhachHang.Where(x => x.Id_KhacHang == id).FirstOrDefault();
        }

        public async Task UpdateById(string id)
        {
            var khachHang = GetById(id);
            _context.KhachHang.Update(khachHang);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsSyncs(KhachHang khachHang)
        {
            _context.KhachHang.Update(khachHang);
            await _context.SaveChangesAsync();
        }
    }
}
