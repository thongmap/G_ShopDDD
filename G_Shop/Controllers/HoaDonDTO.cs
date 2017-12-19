using System;
using G_Shop.Models;
using G_ShopDomain;
using G_ShopDomain.Entities;

namespace G_Shop.Controllers
{
    public class HoaDonDTO
    {
        public int MaHoaDon { get; set; }
        public int MaNguoiDung { get; set; }
        public DateTime? NgayMua { get; set; }
        public NguoiDung NguoiDung { get; set; }
        public int? TongTien { get; set; }
    }
}