using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using G_Shop.Models;
using PagedList.Mvc;
using PagedList;
using G_ShopDomain;
using G_ShopDomain.Entities;

namespace G_Shop.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        GShopEntities db = new GShopEntities();
        // GET: Admin/User
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
        //public IPagedList<NguoiDung> ListAllPageging4(int page, int pagesize)
        //{
        //    //var model = new UserDAO().GetNewCaThe().ToPagedList(page,pagesize);
        //    //return model;
        //    return db.NguoiDungs.OrderByDescending(x => x.MaNguoiDung).ToPagedList(page, pagesize);
        //}

        //public ActionResult timkiemnguoidung(FormCollection f, int? page)
        //{
        //    //if (SessionHandler.User != null)
        //    //{
        //    //    var user = SessionHandler.User;
        //    //}
        //    //else
        //    //{
        //    //    return RedirectToAction("Login", "Account");
        //    //}
        //    string tukhoa = f["txttimkiem"].ToString();
        //    ViewBag.tukhoa = tukhoa;
        //    List<NguoiDung> listnguoidung = db.NguoiDungs.Where(n => n.TenDangNhap.Contains(tukhoa)).ToList();
        //    // phân trang
        //    int pagenumber = (page ?? 1);
        //    int pagesize = 10;
        //    //if (listnguoidung.Count == 0)
        //    //{
        //    //    ViewBag.ThongBao = "Không tìm thấy bản ghi phù hợp";
        //    return View(listnguoidung.OrderBy(n => n.MaNguoiDung).ToPagedList(pagenumber, pagesize));
        //    //}
        //    //ViewBag.ThongBao = "Đã tìm thấy" + "    " + listnguoidung.Count + "kết quả";
        //    //return View(listnguoidung.OrderBy(n => n.MaNguoiDung).ToPagedList(pagenumber, pagesize));
        //}
        //[HttpGet]
        //public ActionResult timkiemnguoidung(string tukhoa, int? page)
        //{
        //    //if (SessionHandler.User != null)
        //    //{
        //    //    var user = SessionHandler.User;
        //    //}
        //    //else
        //    //{
        //    //    return RedirectToAction("Login", "Account");
        //    //}
        //    string tukhoa1 = tukhoa;
        //    ViewBag.tukhoa = tukhoa1;
        //    List<NguoiDung> listnguoidung = db.NguoiDungs.Where(n => n.TenDangNhap.Contains(tukhoa)).ToList();
        //    // phân trang
        //    int pagenumber = (page ?? 1);
        //    int pagesize = 10;
        //    //ViewBag.ThongBao = "Đã tìm thấy" + listnguoidung.Count + "kết quả";
        //    return View(listnguoidung.OrderBy(n => n.MaNguoiDung).ToPagedList(pagenumber, pagesize));
        //}

        public ActionResult Index(string message = "")
        {
            //var user = Session["Admin"] as NguoiDung;
            //if(user==null)
            //{
            //    return RedirectToAction("Login", "AdminHome");
            //}
            //else
            //{
            //ViewBag.tennguoidung = user.TenDangNhap;
            var list = db.NguoiDungs.ToList();
            ViewBag.tongso = list.Count;
            ViewBag.Message = message;
            return View();
           // }
        }
         [HttpGet]
         public JsonResult Get_nguoidung()
       {
            var list = (from n in db.NguoiDungs
                         select new NguoiDungDTO
                         {
                             MaNguoiDung=n.MaNguoiDung,
                             TenNguoiDung=n.TenNguoiDung,
                             DiaChi=n.DiaChi,
                             TenDangNhap=n.TenDangNhap,
                             SoDienThoai=n.SoDienThoai,
                             MatKhau=n.MatKhau,
                             Email=n.Email,
                             VaiTro=n.VaiTro,
                             GioiTinh=n.GioiTinh,
                             NgaySinh=n.NgaySinh

                         }).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        
        //[HttpPost]
        public JsonResult Loc_nguoidung(string i)
        {
            List<NguoiDungDTO> list = new List<NguoiDungDTO>();
            string vai_tro=null;
            if (i == null || i=="0")
            {
                list = (from n in db.NguoiDungs
                            select new NguoiDungDTO
                            {
                                MaNguoiDung = n.MaNguoiDung,
                                TenNguoiDung = n.TenNguoiDung,
                                DiaChi = n.DiaChi,
                                TenDangNhap = n.TenDangNhap,
                                SoDienThoai = n.SoDienThoai,
                                MatKhau = n.MatKhau,
                                Email = n.Email,
                                VaiTro = n.VaiTro,
                                GioiTinh = n.GioiTinh,
                                NgaySinh = n.NgaySinh

                            }).ToList();
            }
            else
            { 
                if (i == "1")
                    vai_tro = "Quản trị viên";
                if (i == "2")
                    vai_tro = "Khách hàng";
                list = (from n in db.NguoiDungs
                            where n.VaiTro == vai_tro
                            select new NguoiDungDTO
                            {
                                MaNguoiDung = n.MaNguoiDung,
                                TenNguoiDung = n.TenNguoiDung,
                                DiaChi = n.DiaChi,
                                TenDangNhap = n.TenDangNhap,
                                SoDienThoai = n.SoDienThoai,
                                MatKhau = n.MatKhau,
                                Email = n.Email,
                                VaiTro = n.VaiTro,
                                GioiTinh = n.GioiTinh,
                                NgaySinh = n.NgaySinh

                            }).ToList();
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        //public ActionResult sua(int ma)
        //{
        //    var model = db.NguoiDungs.Find(ma);
        //    return Json(model, JsonRequestBehavior.AllowGet);

        //}
        [HttpPost]
        public JsonResult capnhat(NguoiDungDTO model)
        {
           // try
           // {
             
                NguoiDung nd = db.NguoiDungs.Find(model.MaNguoiDung);
                //nd.TenDangNhap = model.TenDangNhap;
                nd.MatKhau = model.MatKhau;
                nd.TenNguoiDung = model.TenNguoiDung;
                nd.DiaChi = model.DiaChi;
                nd.Email = model.Email;
                nd.SoDienThoai = model.SoDienThoai;
                nd.GioiTinh = model.GioiTinh;
                //nd.NgaySinh = model.NgaySinh;
                nd.VaiTro = model.VaiTro;
                db.SaveChanges();
                return Json("ok", JsonRequestBehavior.AllowGet);
           // }
          //  catch
          //  {
              //  return Json("error", JsonRequestBehavior.AllowGet);
         //   }
               
            //return View("Index", model);
        }
        [HttpPost]
        public JsonResult themnguoidung(string tendangnhap,string diachi,string tennguoidung, string sodienthoai,string matkhau, string gioitinh, string ngaysinh, string email, string vaitro)
        {
           // try
           // {
                NguoiDung nd = new NguoiDung();
                nd.Email = email;
                nd.DiaChi = diachi;
                nd.TenNguoiDung = tennguoidung;
                nd.MatKhau = matkhau ;
                nd.TenDangNhap = tendangnhap;
                nd.SoDienThoai = sodienthoai;
                nd.VaiTro = vaitro;
                nd.NgaySinh = Convert.ToDateTime(ngaysinh);
                nd.GioiTinh = gioitinh;
                db.NguoiDungs.Add(nd);
                db.SaveChanges();
                return Json("ok");
           // }
           // catch
           // {
              //  return Json("error");
            //}
        }
     
    }
}