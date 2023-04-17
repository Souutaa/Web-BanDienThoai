using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Entities;
using Web.Persistances;

namespace Web.Services.implementation
{
    public class HoaDonServices : IHoaDonServices
    {
        private ApplicationDbContext _context;

        public HoaDonServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsSync(HoaDon hoaDon)
        {
            _context.Add(hoaDon);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteById(string id)
        {
            var hoaDon = GetById(id);
            if (hoaDon != null)
            {
                _context.HoaDon.Remove(hoaDon);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsSync(HoaDon hoaDon)
        {
            _context?.HoaDon.Remove(hoaDon);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<HoaDon> GetAll()
        {
            return _context.HoaDon.ToList();
        }

        public HoaDon GetById(string id)
        {
            return _context.HoaDon.Where(x => x.Id_HoaDon == id).FirstOrDefault();
        }

        public async Task UpdateById(string id)
        {
            var hoaDon = GetById(id);
            _context.HoaDon.Update(hoaDon);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsSyncs(HoaDon hoaDon)
        {
            _context.HoaDon.Update(hoaDon);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<SelectListItem> GetAllSanPham()
        {
            var ListSanPhamforDetail = _context.SanPham.Select(e => new SelectListItem
            {
                Text = e.Id_SanPham.ToString(),
                Value = e.Ten_SanPham
            });
            return ListSanPhamforDetail;
        }
    }
}

