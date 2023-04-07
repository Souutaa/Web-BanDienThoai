using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Entities;

namespace Web.Services
{
    public interface INhaCungCapServices
    {
        IEnumerable<NhaCungCap> GetAll();
        NhaCungCap GetById(string id);
        Task CreateAsSync(NhaCungCap nhaCungCap);
        Task UpdateAsSyncs(NhaCungCap nhaCungCap);
        Task UpdateById(string id);
        Task DeleteById(string id);
        Task DeleteAsSync(NhaCungCap nhaCungCap);
    }
}
