using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using G_Shop.Models;
using G_Shop.Controllers;
using G_ShopDomain;
using G_ShopDomain.Entities;

namespace G_Shop.Areas.Admin.Controllers
{
    public class RevenueController : Controller
    {
        GShopEntities db = new GShopEntities();
        // GET: Admin/Revenue
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Cathe()
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("Login", "AdminHome");
            }
            return View();
        }
        public ActionResult Loai()
        {

            if (Session["Admin"] == null)
            {
                return RedirectToAction("Login", "AdminHome");
            }
            return View();
        }
        public ActionResult KhachHang()
        {

            if (Session["Admin"] == null)
            {
                return RedirectToAction("Login", "AdminHome");
            }
            return View();
        }

        [HttpPost]
        public ActionResult CaThe(FormCollection form)
        {
            string ngaybd = form["ngaybd"];
            string ngaykt = form["ngaykt"];

            DateTime ngaybd1 = Convert.ToDateTime(ngaybd);
            DateTime ngaykt1 = Convert.ToDateTime(ngaykt);
            var model = db.ChiTietHoaDons.
                Where(p => p.HoaDon.NgayMua >= ngaybd1 && p.HoaDon.NgayMua <= ngaykt1).
                GroupBy(p => p.CaThe)
                .Select(g => new ReportInfo
                {
                    Group = g.Key.TenCaThe,
                    Count = g.Sum(p => p.MaCaThe),
                    Total = g.Sum(p => p.CaThe.GiaBan * 1),
                    MinPrice = g.Min(p => p.CaThe.GiaBan),
                    MaxPrice = g.Max(p => p.CaThe.GiaBan),
                    AvgPrice = g.Average(p => p.CaThe.GiaBan)
                });
            ViewBag.ngaybd = ngaybd;
            ViewBag.ngaykt = ngaykt;
            ViewBag.Group = "Cá thể";
            return View("Index", model);
        }
        [HttpPost]
        public ActionResult Loai(FormCollection form)
        {
            string ngaybd = form["ngaybd"];
            string ngaykt = form["ngaykt"];
            string[] angaybatdau = ngaybd.Split(new Char[] { '/' });
            string[] angaykethuc = ngaykt.Split(new Char[] { '/' });
            string ngaybatdau2 = angaybatdau[1] + "/" + angaybatdau[0] + "/" + angaybatdau[2];
            string ngaykethuc2 = angaykethuc[1] + "/" + angaykethuc[0] + "/" + angaykethuc[2];

            DateTime ngaybd1 = Convert.ToDateTime(ngaybatdau2);
            DateTime ngaykt1 = Convert.ToDateTime(ngaykethuc2);

            if (ngaykt1 < ngaybd1)
            {
                ModelState.AddModelError("", "Ngày bắt đầu phải lớn hơn ngày kết thúc");
                return View();
            }
            var model = db.ChiTietHoaDons.
                Where(h => h.HoaDon.NgayMua >= ngaybd1 && h.HoaDon.NgayMua <= ngaykt1).
                GroupBy(p => p.CaThe.Loai)
                .Select(g => new ReportInfo
                {
                    Group = g.Key.TenLoai,
                    Count = g.Sum(p => p.CaThe.Loai.MaLoai),
                    Total = g.Sum(p => p.CaThe.GiaBan * 1),
                    MinPrice = g.Min(p => p.CaThe.GiaBan),
                    MaxPrice = g.Max(p => p.CaThe.GiaBan),
                    AvgPrice = g.Average(p => p.CaThe.GiaBan)
                });
            ViewBag.ngaybd = ngaybatdau2;
            ViewBag.ngaykt = ngaykethuc2;
            //ViewBag.Group = "Loài";
            return View(model);
        }
        [HttpPost]
        public ActionResult KhachHang(FormCollection form)
        {
            string ngaybd = form["ngaybd"];
            string ngaykt = form["ngaykt"];
            string[] angaybatdau = ngaybd.Split(new Char[] { '/' });
            string[] angaykethuc = ngaykt.Split(new Char[] { '/' });
            string ngaybatdau2 = angaybatdau[1] + "/" + angaybatdau[0] + "/" + angaybatdau[2];
            string ngaykethuc2 = angaykethuc[1] + "/" + angaykethuc[0] + "/" + angaykethuc[2];
            DateTime ngaybd1 = Convert.ToDateTime(ngaybatdau2);
            DateTime ngaykt1 = Convert.ToDateTime(ngaykethuc2);
            if (ngaykt1 < ngaybd1)
            {
                ModelState.AddModelError("", "Ngày bắt đầu phải lớn hơn ngày kết thúc");
                return View();
            }
            var model = db.HoaDons.
                Where(p => p.NgayMua >= ngaybd1 && p.NgayMua <= ngaykt1).
                GroupBy(p => p.NguoiDung)
                .Select(g => new ReportInfo
                {
                    Group = g.Key.TenNguoiDung,
                    Count = g.Sum(p => p.MaHoaDon),
                    Total = g.Sum(p => p.TongTien),
                    MinPrice = g.Min(p => p.TongTien),
                    MaxPrice = g.Max(p => p.TongTien),
                    AvgPrice = g.Average(p => p.TongTien)
                }).
                OrderByDescending(g => g.Total)
                .Take(5);
            ViewBag.ngaybd = ngaybatdau2;
            ViewBag.ngaykt = ngaykethuc2;
            //ViewBag.Group = "Khách hàng";
            return View(model);
        }
        //[HttpPost]
        public ActionResult Thang()
        {
            var model = db.HoaDons.
                GroupBy(p => p.NgayMua.Month)
                .Select(g => new ReportInfo
                {
                    Group = g.Key.ToString(),
                    Count = g.Sum(p => p.MaHoaDon),
                    Total = g.Sum(p => p.TongTien),
                    MinPrice = g.Min(p => p.TongTien),
                    MaxPrice = g.Max(p => p.TongTien),
                    AvgPrice = g.Average(p => p.TongTien)
                })
                .OrderBy(r => r.Group); ;
            ViewBag.Group = "Tháng";
            return View("Index", model);
        }
        public ActionResult thongkehoadon() {
            return View();
        }
        [HttpPost]
        public ActionResult thongkehoadon(FormCollection form) {
            var ngaybatdau = form["ngaybd"];
            var ngayketthuc = form["ngaykt"];
            string[] angaybatdau = ngaybatdau.Split(new Char[] { '/' });
            string[] angaykethuc = ngayketthuc.Split(new Char[] { '/' });
            string ngaybatdau2 = angaybatdau[1] + "/" + angaybatdau[0] + "/" + angaybatdau[2];
            string ngaykethuc2 = angaykethuc[1] + "/" + angaykethuc[0] + "/" + angaykethuc[2];
            DateTime ngaybd = Convert.ToDateTime(ngaybatdau2);
            DateTime ngaykt = Convert.ToDateTime(ngaykethuc2);
            var model = db.HoaDons
                         .Where(p => p.NgayMua >= ngaybd && p.NgayMua <= ngaykt)
                         .Select(g => new HoaDonDTO1 {
                             MaHoaDon = g.MaHoaDon,
                             TenNguoiMua = g.NguoiDung.TenNguoiDung,
                             NgayMua = g.NgayMua,
                             TongTien = g.TongTien,
                             TinhTrang=g.TinhTrang
                         });
            float? tongtien = 0;
            int dem = 0;
            foreach(var item in model) {
                tongtien = tongtien + item.TongTien;
                dem = dem + 1;
            }
            ViewBag.tongtien = tongtien.ToString();
            ViewBag.tongso = dem.ToString();
            return View(model);
        }
        public ActionResult ChiTiet(int id) {
            var model = db.HoaDons.Find(id);
            return View(model); 
        }


    }

   
}