using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Entities;
using Web.Persistances;

namespace Web.Services.implementation
{
    public class ChiTietHoaDonServices : IChiTietHoaDonServices
    {
        private ApplicationDbContext _context;
        public ChiTietHoaDonServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsSync(ChiTietHoaDon cthoaDon)
        {
            _context.Add(cthoaDon);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteById(string id)
        {
            var cthoaDon = GetById(id);
            if (cthoaDon != null)
            {
                _context.ChiTietHoaDon.Remove(cthoaDon);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsSync(ChiTietHoaDon cthoaDon)
        {
            _context?.ChiTietHoaDon.Remove(cthoaDon);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<ChiTietHoaDon> GetAll()
        {
            return _context.ChiTietHoaDon.ToList();
        }

        public ChiTietHoaDon GetById(string id)
        {
            return _context.ChiTietHoaDon.Where(x => x.Id_HoaDon == id).FirstOrDefault();
        }

        public IEnumerable<SelectListItem> GetID(string id)
        {
            var ListSanPhamforDetail = _context.ChiTietHoaDon.Select(t => new SelectListItem
            {
                Value = t.Id_HoaDon,
                Text = t.Id_SanPham,                
            }).Where(x => x.Value == id);
            return ListSanPhamforDetail;
        }
        public IEnumerable<SelectListItem> GetbyIDList(string id)
        {
            var ListSanPhamforDetail = _context.ChiTietHoaDon.Select(t => new SelectListItem
            {
                Value = t.Id_HoaDon,
                Text = t.Id_SanPham
            }).Where(x => x.Value == id).ToList();

            Console.WriteLine(ListSanPhamforDetail);
            return ListSanPhamforDetail;         
        }
    
        public SanPham GetbyIDListSanPham(string id)
        {
            var ListSanPhamforDetail = _context.SanPham.Select(t => new SelectListItem
            {
                Value = t.Id_SanPham,
                Text = t.Ten_SanPham
            }).Where(x => x.Value == id);
           
            return (SanPham)ListSanPhamforDetail;
        }

        public async Task UpdateById(string id)
        {
            var cthoaDon = GetById(id);
            _context.ChiTietHoaDon.Update(cthoaDon);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsSyncs(ChiTietHoaDon cthoaDon)
        {
            _context.ChiTietHoaDon.Update(cthoaDon);
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

        public List<ChiTietHoaDon> GetChiTietsID(string id)
        {
            throw new NotImplementedException();
        }
    }
}