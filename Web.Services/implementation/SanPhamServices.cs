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
        public async Task CreateSanPhamAsSync(SanPham sanPham)
        {
            _context.Add(sanPham);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteById(int id)
        {
            var sanpham = GetById(id);
            if (sanpham != null)
            {
                _context.SanPham.Remove(sanpham);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteSanPham(SanPham sanPham)
        {
            _context?.SanPham.Remove(sanPham);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<SanPham> GetAll()
        {
            return _context.SanPham.ToList();
        }

        public SanPham GetById(int id)
        {
            return _context.SanPham.Where(x => x.Id == id).FirstOrDefault();
        }

        public async Task UpdateById(int id)
        {
            var sanPham = GetById(id);
            _context.SanPham.Update(sanPham);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSanPhamAsSyncs(SanPham sanPham)
        {
            _context.SanPham.Update(sanPham);
            await _context.SaveChangesAsync();
        }
    }
}
