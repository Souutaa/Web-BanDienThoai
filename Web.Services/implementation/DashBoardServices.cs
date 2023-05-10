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

        public IEnumerable<NhaCungCap> GetAllNhaCungCap()
        {
            return _context.NhaCungCap.ToList();
        }     

        public IEnumerable<NhapHang> GetAllNhapHang()
        {
            return _context.NhapHang.ToList();
        }

        public IEnumerable<SanPham> GetAllSanPham()
        {
            return _context.SanPham.ToList();
        }

        public HoaDon GetByIdHoaDon(string id)
        {
            return _context.HoaDon.Where(x => x.Id_HoaDon == id).FirstOrDefault();
        }

        public NhaCungCap GetByIdNhaCungCap(string id)
        {
            return _context.NhaCungCap.Where(x => x.Id_NhaCungCap == id).FirstOrDefault();
        }

        public NhapHang GetByIdNhapHang(string id)
        {
            return _context.NhapHang.Where(x => x.Id_NhapHang == id).FirstOrDefault();
        }

        public SanPham GetByIdSanPham(string id)
        {
            return _context.SanPham.Where(x => x.Id_SanPham == id).FirstOrDefault();
        }

        public int GetNhaCungCapCount()
        {
            return _context.NhaCungCap.Count();
        }

        public int GetNguoiDungCount()
        {
            return _context.TaiKhoans.Count();
        }

        public int GetLoaiCount()
        {
            return _context.LoaiSanPham.Count();
        }

        public int GetCauHinhCount()
        {
            return _context.CauHinh.Count();
        }
    }
}
