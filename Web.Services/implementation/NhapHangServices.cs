using Web.Entities;
using Web.Persistances;

namespace Web.Services.implementation
{
    public class NhapHangServices : INhapHangServices
    {
        private ApplicationDbContext _context;

        public NhapHangServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsSync(NhapHang nhapHang)
        {
            _context.Add(nhapHang);
            await _context.SaveChangesAsync();
        }

        public Task DeleteById(string id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsSync(NhapHang nhapHang)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<NhapHang> GetAll()
        {
            throw new NotImplementedException();
        }

        public NhapHang GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateById(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsSyncs(NhapHang nhapHang)
        {
            throw new NotImplementedException();
        }
    }
}
