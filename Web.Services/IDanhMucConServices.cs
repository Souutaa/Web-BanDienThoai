using Web.Entities;

namespace Web.Services
{
    public interface IDanhMucConServices
    {
        IEnumerable<DanhMucCon> GetAll();
        DanhMucCon GetById(string id); 
        Task CreateAsSync(DanhMucCon danhMucCon); 
        Task UpdateAsSyncs(DanhMucCon danhMucCon); 
        Task UpdateById(string id); 
        Task DeleteById(string id); 
        Task DeleteAsSync(DanhMucCon danhMucCon);
    }
}
