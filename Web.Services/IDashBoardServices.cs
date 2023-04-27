using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Entities;

namespace Web.Services
{
    public interface IDashBoardServices
    {
        IEnumerable<HoaDon> GetAll();
        HoaDon GetById(string id);
    }
}
