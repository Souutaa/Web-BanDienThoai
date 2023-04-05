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
        public async Task CreateNhanVienAsSync(KhachHang khachHang)
        {
            _context.Add(khachHang);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteById(int id)
        {
            var khachHang = GetById(id);
            if (khachHang != null)
            {
                _context.KhachHang.Remove(khachHang);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteNhanVien(KhachHang khachHang)
        {
            _context?.KhachHang.Remove(khachHang);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<KhachHang> GetAll()
        {
            return _context.KhachHang.ToList();
        }

        public KhachHang GetById(int id)
        {
            return _context.KhachHang.Where(x => x.Id == id).FirstOrDefault();
        }

        public async Task UpdateById(int id)
        {
            var khachHang = GetById(id);
            _context.KhachHang.Update(khachHang);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateNhanVienAsSyncs(KhachHang khachHang)
        {
            _context.KhachHang.Update(khachHang);
            await _context.SaveChangesAsync();
        }
    }
}
