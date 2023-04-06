using Web.Entities;
using Web.Persistances;

namespace Web.Services.implementation
{
    public class SanPhamServices : ISanPhamServices
    {
        private ApplicationDbContext _context;

        public SanPhamServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsSync(SanPham sanPham)
        {
            _context.Add(sanPham);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteById(string id)
        {
            var sanpham = GetById(id);
            if (sanpham != null)
            {
                _context.SanPham.Remove(sanpham);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsSync(SanPham sanPham)
        {
            _context?.SanPham.Remove(sanPham);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<SanPham> GetAll()
        {
            return _context.SanPham.ToList();
        }

        public SanPham GetById(string id)
        {
            return _context.SanPham.Where(x => x.Id_SanPham == id).FirstOrDefault();
        }

        public async Task UpdateById(string id)
        {
            var sanPham = GetById(id);
            _context.SanPham.Update(sanPham);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsSyncs(SanPham sanPham)
        {
            _context.SanPham.Update(sanPham);
            await _context.SaveChangesAsync();
        }
    }
}
