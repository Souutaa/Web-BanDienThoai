using Web.Entities;

namespace Web.Services
{
    public interface IKhachHangServices
    {
        IEnumerable<KhachHang> GetAll();
        KhachHang GetById(int id);
        Task CreateNhanVienAsSync(KhachHang khachHang);
        Task UpdateNhanVienAsSyncs(KhachHang khachHang);
        Task UpdateById(int id);
        Task DeleteById(int id);
        Task DeleteNhanVien(KhachHang khachHang);
    }
}
