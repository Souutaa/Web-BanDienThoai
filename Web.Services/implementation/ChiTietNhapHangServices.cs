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
    public class ChiTietNhapHangServices : IChiTietNhapHangServices
    {
        private ApplicationDbContext _context;
        public ChiTietNhapHangServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsSync(ChiTietNhapHang ctnh)
        {
            _context.Add(ctnh);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteById(string id)
        {
            var ctnh = GetById(id);
            if (ctnh != null)
            {
                _context.ChiTietNhapHang.Remove(ctnh);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsSync(ChiTietNhapHang ctnh)
        {
            _context?.ChiTietNhapHang.Remove(ctnh);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<ChiTietNhapHang> GetAll()
        {
            return _context.ChiTietNhapHang.ToList();
        }

        public ChiTietNhapHang GetById(string id)
        {
            return _context.ChiTietNhapHang.Where(x => x.Id_NhapHang == id).FirstOrDefault();
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
            var ctnh = GetById(id);
            _context.ChiTietNhapHang.Update(ctnh);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsSyncs(ChiTietNhapHang ctnh)
        {
            _context.ChiTietNhapHang.Update(ctnh);
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

        public IEnumerable<SelectListItem> GetID(string id)
        {
            throw new NotImplementedException();
        }
    }
}