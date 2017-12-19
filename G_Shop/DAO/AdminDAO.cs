using G_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using G_Shop.Areas.Admin.Models;
using G_ShopDomain;
using G_ShopDomain.Entities;

namespace G_Shop.DAO
{
    public class AdminDAO
    {
        GShopEntities db = null;
        public AdminDAO()
        {
            db = new GShopEntities();
        }
        public List<Loai> GetAllTenLoai()
        {
            return db.Loais.ToList();
        }

        
        public List<CaThe> GetCaThe_MaLoai(int MaLoai, int? i)
        {
            List<CaThe> model = new List<CaThe>();
            if (i == null || i==0)
                model = db.CaThes.Where(x => x.MaLoai == MaLoai).ToList();
            else  //Biến i kiểm tra điều kiện lọc hóa đơn theo tình trạng
            {
                if (i == 1)
                    model = db.CaThes.Where(x => x.TinhTrang == "Sẵn bán").ToList();
                if (i == 2)
                    model = db.CaThes.Where(x => x.TinhTrang == "Đã bán").ToList();
                if (i == 3)
                    model = db.CaThes.Where(x => x.TinhTrang == "Đã mất").ToList();
            }
            return model;
        }
        public string GetTenLoai_MaLoai(int MaLoai)
        {
            var model = db.Loais.Find(MaLoai);
            return model.TenLoai;
        }

        public void ThemCaThe(CaThe model)
        {
            db.CaThes.Add(model);
            db.SaveChanges();
        }

        public CaThe GetCaThe_MaLoai_MaCaThe(int MaLoai, int MaCaThe)
        {
            return db.CaThes.Where(x => x.MaLoai == MaLoai && x.MaCaThe == MaCaThe).FirstOrDefault();
        }

        public void SuaCaThe(CaThe cathe)
        {
            CaThe model = db.CaThes.Find(cathe.MaCaThe);
            model.TenCaThe = cathe.TenCaThe;
            model.MoTa = cathe.MoTa;
            model.NgaySinh = cathe.NgaySinh;
            model.GiaBan = cathe.GiaBan;
            model.GiaMua = cathe.GiaMua;
            model.KhuyenMai = cathe.KhuyenMai;
            model.TinhTrang = cathe.TinhTrang;
            db.SaveChanges();
        }

        public List<HoaDon> GetAllHoaDon(int? i) 
        {
            List<HoaDon> model=new List<HoaDon>();
            if (i == 0 || i==null)
                model = db.HoaDons.OrderByDescending(x => x.NgayMua).ToList();
            else  //Biến i kiểm tra điều kiện lọc hóa đơn theo tình trạng
            {
                if(i==1)
                    model=db.HoaDons.Where(x=>x.TinhTrang=="Mới đặt hàng").OrderByDescending(x => x.NgayMua).ToList();
                if (i == 2)
                    model=db.HoaDons.Where(x => x.TinhTrang == "Đã xác nhận").OrderByDescending(x => x.NgayMua).ToList();
                if (i == 3)
                    model=db.HoaDons.Where(x => x.TinhTrang == "Giao hàng thành công").OrderByDescending(x => x.NgayMua).ToList();
                if (i == 4)
                    model=db.HoaDons.Where(x => x.TinhTrang == "Thất bại").OrderByDescending(x => x.NgayMua).ToList();
            }
            return model; 
        }

        public List<CTHD> GetCTHD_MaHD(int MaHD)
        {
            var model = (from cthd in db.ChiTietHoaDons
                         join ct in db.CaThes
                         on cthd.MaCaThe equals ct.MaCaThe
                         join hd in db.HoaDons on cthd.MaHoaDon equals hd.MaHoaDon
                         where cthd.MaHoaDon == MaHD
                         select new
                         {
                             macthd = cthd.MaChiTietHoaDon,
                             mahd = cthd.MaHoaDon,
                             macathe=ct.MaCaThe,
                             tenct = ct.TenCaThe,
                             hinh = ct.HinhAnh.Substring(0, ct.HinhAnh.IndexOf("|")),
                             gia = ct.GiaBan
                         }).AsEnumerable().Select(x => new CTHD()
                         {
                             MaCTHD = x.macthd,
                             MaHD = x.mahd,
                             MaCaThe=x.macathe,
                             TenCaThe = x.tenct,
                             Hinh = x.hinh,
                             Gia = x.gia
                         }).ToList();
            return model;
        }

        public List<HoaDon> HoaDon_Ngay(DateTime ngay_bd, DateTime ngay_kt,int i)
        {
            List<HoaDon> model = new List<HoaDon>();
            if (i == 0)
                model=db.HoaDons.Where(x=>x.NgayMua>=ngay_bd && x.NgayMua<=ngay_kt).OrderByDescending(x=>x.NgayMua).ToList();
            if (i == 1)
                model = db.HoaDons.Where(x => x.NgayMua >= ngay_bd && x.NgayMua <= ngay_kt && x.TinhTrang == "Mới đặt hàng").OrderByDescending(x => x.NgayMua).ToList();
            if (i == 2)
                model = db.HoaDons.Where(x => x.NgayMua >= ngay_bd && x.NgayMua <= ngay_kt && x.TinhTrang == "Đã xác nhận").OrderByDescending(x => x.NgayMua).ToList();
            if (i == 3)
                model = db.HoaDons.Where(x => x.NgayMua >= ngay_bd && x.NgayMua <= ngay_kt && x.TinhTrang == "Giao hàng thành công").OrderByDescending(x => x.NgayMua).ToList();
            if (i == 4)
                model = db.HoaDons.Where(x => x.NgayMua >= ngay_bd && x.NgayMua <= ngay_kt && x.TinhTrang == "Thất bại").OrderByDescending(x => x.NgayMua).ToList();
            return model;
        }

        public HoaDon GetHoaDon_MaHD(int MaHoaDon)
        {
            return db.HoaDons.Where(x => x.MaHoaDon == MaHoaDon).First();
        }

        public NguoiDung GetNguoiDung_MaHoaDon(int MaHoaDon)
        {
            var model = (from ngdung in db.NguoiDungs
                         join hd in db.HoaDons
                         on ngdung.MaNguoiDung equals hd.MaNguoiDung
                         where hd.MaHoaDon == MaHoaDon
                         select new
                         {
                             tennguoidung = ngdung.TenNguoiDung,
                             sdt = ngdung.SoDienThoai
                         }).AsEnumerable().Select(x => new NguoiDung()
                         {
                             TenNguoiDung = x.tennguoidung,
                             SoDienThoai = x.sdt
                         }).First();
            return model;
        }           
        
        public void SuaTinhTrang(int MaHoaDon,string TinhTrang)
        {
            var model = db.HoaDons.Find(MaHoaDon);
            model.TinhTrang = TinhTrang;
            db.SaveChanges();
        }              

        public int? CapNhatCTHD(int macathe, int mahoadon)
        {
            int? tongtien;
            var cthd = db.ChiTietHoaDons.Where(x=>x.MaCaThe==macathe && x.MaHoaDon==mahoadon).First();
            db.ChiTietHoaDons.Remove(cthd);
            var hoadon = db.HoaDons.Find(mahoadon);
            int? gia = db.CaThes.Find(macathe).GiaBan;
            tongtien = hoadon.TongTien - gia;
            hoadon.TongTien=tongtien;
            var cathe = db.CaThes.Find(macathe);
            cathe.TinhTrang = "Sẵn bán";
            db.SaveChanges();
            return tongtien;
        }

        public void SuaVideoCaThe(CaThe cathe) {
            CaThe model = db.CaThes.Find(cathe.MaCaThe);
            model.Video = cathe.Video;
            db.SaveChanges();
        }
    }
}