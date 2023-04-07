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
        public async Task CreateAsSync(DanhMucCon danhMucCon)
        {
            _context.Add(danhMucCon);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsSync(DanhMucCon danhMucCon)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DanhMucCon> GetAll()
        {
            throw new NotImplementedException();
        }

        public DanhMucCon GetById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsSyncs(DanhMucCon danhMucCon)
        {
            throw new NotImplementedException();
        }
    }
}
