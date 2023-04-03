using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Entities
{
    public class MauSac
    {
        [Key] public int Id { get; set; }
        public string Id_MauSac { get; set; }
        public string TenMauSac { get;set; }
    }
}
