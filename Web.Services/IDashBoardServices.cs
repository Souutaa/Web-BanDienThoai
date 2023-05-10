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
        IEnumerable<HoaDon> GetAllHoaDon();
        HoaDon GetByIdHoaDon(string id);

        IEnumerable<NhapHang> GetAllNhapHang();
        NhapHang GetByIdNhapHang(string id);

        IEnumerable<SanPham> GetAllSanPham();
        SanPham GetByIdSanPham(string id);

        IEnumerable<NhaCungCap> GetAllNhaCungCap();
        NhaCungCap GetByIdNhaCungCap(string id);
        int GetNhaCungCapCount();
        int GetNguoiDungCount();
        int GetLoaiCount();
        int GetCauHinhCount();
    }
}
