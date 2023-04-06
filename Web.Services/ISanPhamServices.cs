using Web.Entities;

namespace Web.Services
{
    public interface ISanPhamServices
    {
        IEnumerable<SanPham> GetAll();
        SanPham GetById(int id);
        Task CreateSanPhamAsSync(SanPham sanPham);
        Task UpdateSanPhamAsSyncs(SanPham sanPham);
        Task UpdateById(int id);
        Task DeleteById(int id);
        Task DeleteSanPham(SanPham sanPham);
    }
}
