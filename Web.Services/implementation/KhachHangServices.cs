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

        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteNhanVien(KhachHang khachHang)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<KhachHang> GetAll()
        {
            throw new NotImplementedException();
        }

        public KhachHang GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateNhanVienAsSyncs(KhachHang khachHang)
        {
            throw new NotImplementedException();
        }
    }
}
