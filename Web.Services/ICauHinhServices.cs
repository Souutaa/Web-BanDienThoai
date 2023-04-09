using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Entities;

namespace Web.Services
{
    public interface ICauHinhServices
    {
        IEnumerable<CauHinh> GetAll();
        CauHinh GetById(string id);
        Task CreateAsSync(CauHinh cauHinh);
        Task UpdateAsSyncs(CauHinh cauHinh);
        Task UpdateById(string id);
        Task DeleteById(string id);
        Task DeleteAsSync(CauHinh cauHinh);
    }
}
