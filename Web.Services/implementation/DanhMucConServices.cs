using Web.Entities;
using Web.Persistances;

namespace Web.Services.implementation
{
    public class DanhMucConServices : IDanhMucConServices
    {
        private ApplicationDbContext _context;

        public DanhMucConServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateNhanVienAsSync(DanhMucCon danhMucCon)
        {
            _context.Add(danhMucCon);
            await _context.SaveChangesAsync();
        }

        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteNhanVien(DanhMucCon danhMucCon)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DanhMucCon> GetAll()
        {
            throw new NotImplementedException();
        }

        public NhanVien GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateNhanVienAsSyncs(DanhMucCon danhMucCon)
        {
            throw new NotImplementedException();
        }
    }
}
