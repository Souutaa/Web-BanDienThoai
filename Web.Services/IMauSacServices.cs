using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Entities;

namespace Web.Services
{
    public interface IMauSacServices
    {
        IEnumerable<MauSac> GetAll();
        MauSac GetById(string id);
        Task CreateAsSync(MauSac mauSac);
        Task UpdateAsSyncs(MauSac mauSac);
        Task UpdateById(string id);
        Task DeleteById(string id);
        Task DeleteAsSync(MauSac mauSac);
    }
}
