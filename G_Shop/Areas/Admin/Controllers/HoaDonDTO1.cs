using System;

namespace G_Shop.Areas.Admin.Controllers {
    public class HoaDonDTO1 {
        public int MaHoaDon { get; set; }
        public DateTime NgayMua { get; set; }
        public string TenNguoiMua { get; set; }
        public string TinhTrang { get; set; }
        public int? TongTien { get; set; }
    }
}