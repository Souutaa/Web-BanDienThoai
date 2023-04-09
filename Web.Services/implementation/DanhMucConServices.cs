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
            var danhMucCon = GetById(id);
            if (danhMucCon != null)
            {
                _context.DanhMucCon.Remove(danhMucCon);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsSync(DanhMucCon danhMucCon)
        {
            _context?.DanhMucCon.Remove(danhMucCon);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<DanhMucCon> GetAll()
        {
            return _context.DanhMucCon.ToList();
        }

        public DanhMucCon GetById(string id)
        {
            return _context.DanhMucCon.Where(x => x.Id_DanhMucCon == id).FirstOrDefault();
        }

        public async Task UpdateById(string id)
        {
            var danhMucCon = GetById(id);
            _context.DanhMucCon.Update(danhMucCon);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsSyncs(DanhMucCon danhMucCon)
        {
            _context.DanhMucCon.Update(danhMucCon);
            await _context.SaveChangesAsync();
        }
    }
}
