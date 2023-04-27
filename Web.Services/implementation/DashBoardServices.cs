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
        public IEnumerable<HoaDon> GetAll()
        {
            return _context.HoaDon.ToList();
        }

        public HoaDon GetById(string id)
        {
            return _context.HoaDon.Where(x => x.Id_HoaDon == id).FirstOrDefault();
        }
    }
}
