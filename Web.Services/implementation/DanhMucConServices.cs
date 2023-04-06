using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public IEnumerable<NhanVien> GetAll()
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

        IEnumerable<DanhMucCon> IDanhMucConServices.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
