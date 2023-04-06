using Web.Entities;

namespace Web.Services
{
    public interface ISanPhamServices
    {
        IEnumerable<SanPham> GetAll();
        SanPham GetById(string id);
        Task CreateAsSync(SanPham sanPham);
        Task UpdateAsSyncs(SanPham sanPham);
        Task UpdateById(string id);
        Task DeleteById(string id);
        Task DeleteAsSync(SanPham sanPham);
    }
}
