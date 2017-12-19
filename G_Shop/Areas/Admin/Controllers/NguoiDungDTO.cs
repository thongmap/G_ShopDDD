using System;

namespace G_Shop.Areas.Admin.Controllers
{
    public class NguoiDungDTO
    {
        public int MaNguoiDung { get; set; }
        public string Email { get; set; }
        public string GioiTinh { get;  set; }
        public string MatKhau { get; set; }
        public DateTime? NgaySinh { get;  set; }
        public string SoDienThoai { get; set; }
        public string TenDangNhap { get; set; }
        public string VaiTro { get; set; }
        public string TenNguoiDung { get; set; }
        public string DiaChi { get;  set; }
    }
}