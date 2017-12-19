using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using G_Shop.Models;
using PagedList;
using G_ShopDomain;
using G_ShopDomain.Entities;

namespace G_Shop.Areas.Admin.Controllers
{
    public class LoaiController : Controller
    {
        GShopEntities db = new GShopEntities();
        // GET: Admin/Loai
        //public IPagedList<Loai> ListAllPageging4(int page, int pagesize)
        //{
        //    //var model = new UserDAO().GetNewCaThe().ToPagedList(page,pagesize);
        //    //return model;
        //    return db.Loais.OrderByDescending(x => x.MaLoai).ToPagedList(page, pagesize);
        //}
        public ActionResult Index(string message = "")
        {
            ViewBag.Message = message;
            return View();
        }
        [HttpPost]
        public JsonResult themloai(string tenloai, string mota)
        {
            try
            {
                var loai = new Loai();
                loai.TenLoai = tenloai;
                loai.MoTa =mota ;
                db.Loais.Add(loai);
                db.SaveChanges();
                return Json("ok",JsonRequestBehavior.AllowGet);

            }
            catch
            {
                return Json("error", JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult edit(int maloai)
        {
            var list = db.Loais.Find(maloai);
            return View(list);
        }
        [HttpPost]
        public JsonResult capnhat(LoaiDTO loai)
        {
            //try
            //{
                var model = db.Loais.Find(loai.MaLoai);
                model.TenLoai = loai.TenLoai;
                model.MoTa = loai.MoTa;
                db.SaveChanges();
            return Json("ok", JsonRequestBehavior.AllowGet);
           // }
           // catch
           // {
               // return Json("error", JsonRequestBehavior.AllowGet);
           // }
        }
        public JsonResult get_allLoai()
        {
            var model = (from n in db.Loais
                         select new LoaiDTO
                         {
                             MaLoai=n.MaLoai,
                             TenLoai=n.TenLoai,
                             MoTa=n.MoTa
                         }).ToList();
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        //[HttpPost]
        //public ActionResult timkiemloai(FormCollection f, int? page)
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
        //    List<Loai> listloai = db.Loais.Where(n => n.TenLoai.Contains(tukhoa)).ToList();
        //    // phân trang
        //    int pagenumber = (page ?? 1);
        //    int pagesize = 10;
        //    //if (listnguoidung.Count == 0)
        //    //{
        //    //    ViewBag.ThongBao = "Không tìm thấy bản ghi phù hợp";
        //    return View(listloai.OrderBy(n => n.MaLoai).ToPagedList(pagenumber, pagesize));
        //    //}
        //    //ViewBag.ThongBao = "Đã tìm thấy" + "    " + listnguoidung.Count + "kết quả";
        //    //return View(listnguoidung.OrderBy(n => n.MaNguoiDung).ToPagedList(pagenumber, pagesize));
        //}
        //[HttpGet]
        //public ActionResult timkiemloai(string tukhoa, int? page)
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
        //    List<Loai> listloai = db.Loais.Where(n => n.TenLoai.Contains(tukhoa)).ToList();
        //    // phân trang
        //    int pagenumber = (page ?? 1);
        //    int pagesize = 10;
        //    //ViewBag.ThongBao = "Đã tìm thấy" + listnguoidung.Count + "kết quả";
        //    return View(listloai.OrderBy(n => n.MaLoai).ToPagedList(pagenumber, pagesize));
        //}

      
    }
}