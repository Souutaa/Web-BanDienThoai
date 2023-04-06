using Web.Entities;

namespace Web.Services
{
    public interface INhapHangServices
    {
        IEnumerable<NhapHang> GetAll();
        NhapHang GetById(string id);
        Task CreateAsSync(NhapHang nhapHang);
        Task UpdateAsSyncs(NhapHang nhapHang);
        Task UpdateById(string id);
        Task DeleteById(string id);
        Task DeleteAsSync(NhapHang nhapHang);
    }
}
