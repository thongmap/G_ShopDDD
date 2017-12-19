using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using G_Shop.Models;
using G_Shop.DAO;
using System.Globalization;
using G_ShopDomain;
using G_ShopDomain.Entities;

namespace G_Shop.Controllers {
    public class OrderController : Controller {
        GShopEntities db = new GShopEntities();
        // GET: Order

        public ActionResult Checkout() {
            if(Session["user"] == null) {
                return RedirectToAction("Login", "Account");
            } else {
                int? tongtien = 0;
                var user = Session["user"] as NguoiDung;
                foreach(var p in ShoppingCart.Cart.Items) {
                    tongtien = tongtien + p.GiaBan;
                }
                var model = new HoaDon();
                model.TongTien = tongtien;
                model.NgayMua = DateTime.Now;
                model.MaNguoiDung = user.MaNguoiDung;
                model.NguoiDung = user;
                model.DiaChi = user.DiaChi;
                ViewBag.tennguoidung = user.TenDangNhap;
                return View(model);
            }

        }

        [HttpPost]
        public ActionResult Checkout(HoaDon order, FormCollection form) {
            order.TinhTrang = "Mới đặt hàng";
            order.GioGiaoHang = Request.Form["gioGiaoHang"] + ":" + Request.Form["phutGiaoHang"] + " " + Request.Form["buoiGiaoHang"];
            CultureInfo provider = CultureInfo.InvariantCulture;
            string format = "dd/MM/yyyy";
            order.NgayGiaoHang = DateTime.ParseExact(Request.Form["ngayGiaoHang"], format, provider);
            //order.NgayGiaoHang = Convert.ToDateTime(form["ngaygiaohang"], );
            db.HoaDons.Add(order); // insert order
            UserDAO userDAO = new UserDAO();
            foreach(var p in ShoppingCart.Cart.Items) {
                var detail = new ChiTietHoaDon {
                    HoaDon = order,
                    MaCaThe = p.MaCaThe,
                };
                userDAO.BanCaThe(p.MaCaThe);
                db.ChiTietHoaDons.Add(detail); // insert orderdetail
            }
            db.SaveChanges();

            ShoppingCart.Cart.Clear();
            return RedirectToAction("Detail", "Order", new { id = order.MaHoaDon });
            //return RedirectToAction("List", "Order");
        }

        public ActionResult List() {
            if(Session["user"] == null) {
                return RedirectToAction("Login", "Account");
            } else {
                var user = Session["user"] as NguoiDung;
                var model = (from n in db.HoaDons
                             where n.MaNguoiDung.Equals(user.MaNguoiDung)
                             select new HoaDonDTO {
                                 MaHoaDon = n.MaHoaDon,
                                 MaNguoiDung = n.MaNguoiDung,
                                 NgayMua = n.NgayMua,
                                 TongTien = n.TongTien,
                                 NguoiDung = n.NguoiDung

                             }).ToList();

                ViewBag.tennguoidung = user.TenDangNhap;
                return View(model);
            }

        }

        public ActionResult Detail(int Id) {
            if(Session["user"] == null) {
                return RedirectToAction("Login", "Account");
            } else {
                var user = Session["user"] as NguoiDung;
                ViewBag.tennguoidung = user.TenDangNhap;
                var model = db.HoaDons.Find(Id);
                return View(model);
            }

        }

        //public ActionResult Items()
        //{
        //    var user = Session["user"] as NguoiDung;
        //    var model = db.ChiTietHoaDons
        //        .Where(d => d.HoaDon.MaNguoiDung == user.MaNguoiDung)
        //        .Select(d => d.CaThe)
        //        .Distinct().ToList();
        //    return View("../Product/List", model);
        //}
    }
}