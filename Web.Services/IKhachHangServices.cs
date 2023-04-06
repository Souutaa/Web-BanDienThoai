using Web.Entities;

namespace Web.Services
{
    public interface IKhachHangServices
    {
        IEnumerable<KhachHang> GetAll();
        KhachHang GetById(string id);
        Task CreateAsSync(KhachHang khachHang);
        Task UpdateAsSyncs(KhachHang khachHang);
        Task UpdateById(string id);
        Task DeleteById(string id);
        Task DeleteAsSync(KhachHang khachHang);
    }
}
