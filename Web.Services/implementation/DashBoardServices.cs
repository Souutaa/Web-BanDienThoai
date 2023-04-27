using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Entities;
using Web.Persistances;

namespace Web.Services.implementation
{
    public class DashBoardServices : IDashBoardServices
    {
        private ApplicationDbContext _context;

        public DashBoardServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<HoaDon> GetAllHoaDon()
        {
            return _context.HoaDon.ToList();
        }

        public IEnumerable<NhapHang> GetAllNhapHang()
        {
            return _context.NhapHang.ToList();
        }

        public HoaDon GetByIdHoaDon(string id)
        {
            return _context.HoaDon.Where(x => x.Id_HoaDon == id).FirstOrDefault();
        }

        public NhapHang GetByIdNhapHang(string id)
        {
            return _context.NhapHang.Where(x => x.Id_NhapHang == id).FirstOrDefault();
        }
    }
}
