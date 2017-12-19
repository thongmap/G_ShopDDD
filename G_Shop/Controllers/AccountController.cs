using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using G_Shop.DAO;
using G_Shop.Models;
using G_ShopDomain;
using G_ShopDomain.Entities;

namespace G_Shop.Controllers {
    public class AccountController : Controller {
        GShopEntities db = new GShopEntities();
        // GET: Account
        public ActionResult Login() {
            var cki = Request.Cookies["user"];
            if(cki != null) {
                ViewBag.Id = cki.Values["Id"];
                ViewBag.Password = cki.Values["Pw"];
            }
            return View();
        }
        [HttpPost]
        public ActionResult Login(ModelLogin nd) {

            var user = db.NguoiDungs.Where(n => n.TenDangNhap.Equals(nd.UserName)).FirstOrDefault();

            if(user == null) {
                ModelState.AddModelError("", "Sai tên đăng nhập !");
            } else if(user.MatKhau != nd.Password) {
                ModelState.AddModelError("", "Sai mật khẩu !");
            } else {
                Session["user"] = user;
                //ModelState.AddModelError("", "Đăng nhập thành công !");
                return RedirectToAction("Index", "Home");

            }
            // Quay trở lại trang được yêu cầu trước đó

            return View();
        }
        public ActionResult Logoff() {
            Session.Remove("user");
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register() {
            return View();
        }

        [HttpPost]
        public ActionResult Register(NguoiDung model) {
            model.Email = Request.Form["email"];
            try {
                model.VaiTro = "Khách hàng";
                db.NguoiDungs.Add(model);
                db.SaveChanges();
                //ModelState.AddModelError("", "Đăng ký thành công. Vui lòng nhận email và kích hoạt tài khoản !");

                //var url = Request.Url.AbsoluteUri.Replace("Register", "") + "Activate/" + model.Id.ToBase64();
                //var body = @"Click vào liên kết sau để kích hoạt tài khoản: <a href='" + url + "'>Activate</a>";
                //XMail.Send(model.Email, "Welcome mail", body);
            } catch(Exception ex) {
                ModelState.AddModelError("", "Đăng ký thất bại !" + ex);
            }
            return RedirectToAction("Login", "Account");
        }
        public ActionResult editprofile() {
            var user = Session["user"] as NguoiDung;
            ViewBag.tennguoidung = user.TenDangNhap;
            var model = db.NguoiDungs.Find(user.MaNguoiDung);
            return View(model);
        }
        [HttpPost]
        public ActionResult editprofile(NguoiDung model) {
            NguoiDung nd = db.NguoiDungs.Find(model.MaNguoiDung);
            nd.Email = model.Email;
            nd.GioiTinh = model.GioiTinh;
            //nd.NgaySinh = model.NgaySinh;
            nd.TenNguoiDung = model.TenNguoiDung;
            nd.GioiTinh = model.GioiTinh;
            nd.SoDienThoai = model.SoDienThoai;
            nd.DiaChi = model.DiaChi;
            db.SaveChanges();
            ViewBag.Message = "Sửa thành công.";
            return View(model);
        }
        public ActionResult editPassword(string message = "") {
            var user = Session["user"] as NguoiDung;
            ViewBag.tennguoidung = user.TenDangNhap;
            var model = db.NguoiDungs.Find(user.MaNguoiDung);
            ViewBag.message = message;
            return View(model);
        }
        [HttpPost]
        public ActionResult editPassword(NguoiDung nguoiDung, string oldPassword, string newPassword) {
            if(new UserDAO().changePassword(nguoiDung.MaNguoiDung, oldPassword, newPassword)) {
                return RedirectToAction("editprofile", "Account");
            }
            return RedirectToAction("editpassword", "Account", new { message = "Thông tin không chính xác, vui lòng nhập lại" });
        }
    }
}