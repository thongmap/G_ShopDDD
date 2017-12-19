using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using G_Shop.DAO;
using PagedList;
using G_ShopDomain.Entities;
using G_ShopApplication;

namespace G_Shop.Controllers
{
    public class HomeController : Controller
    {
        CaTheService cathe = new CaTheService();
        // GET: Products
       
       public IEnumerable<CaThe> ListAllPageging4(int page, int pagesize)
        {
            //var model = new UserDAO().GetNewCaThe().ToPagedList(page,pagesize);
            //return model;
            return cathe.Find(x=>x.TinhTrang=="Sẵn bán").OrderByDescending(x => x.MaCaThe).ToPagedList(page, pagesize);
        }

        public ActionResult Index(int page = 1, int pagesize = 3) {

            //if (Session["user"] == null) {
            //    return View();
            //    //return RedirectToAction("Login", "Account");
            //} else {

            //if (Session["user"] == null) {
            //    var model = ListAllPageging4(page, pagesize);
            //    return View(model);
            //} else {


                var user = Session["user"] as NguoiDung;
                if(user!=null)
                    ViewBag.tennguoidung = user.TenDangNhap;
            var model = ListAllPageging4(page, pagesize);
            //var model = new UserDAO().GetNewCaThe();
            return View(model);
            //}

        }
        public IEnumerable<CaThe> ListAllPageging(int MaLoai,int page, int pagesize)
        {
            //var model = new UserDAO().GetNewCaThe().ToPagedList(page,pagesize);
            //return model;
            return cathe.Find(x=>x.MaLoai == MaLoai).OrderByDescending(x => x.MaCaThe).ToPagedList(page, pagesize);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult _Category()
        {
            var model = new UserDAO().GetAllTenLoai();
            return PartialView(model);
        }
       public ActionResult ThuCung(int MaLoai, int page = 1, int pagesize = 6) {
            //    if(Session["user"]==null)
            //    {
            //        return RedirectToAction("Login", "Account");
            //    }
            //    else
            //    {
            var user = Session["user"] as NguoiDung;
            if(user!=null)
                ViewBag.tennguoidung = user.TenDangNhap;
            var model = ListAllPageging(MaLoai, page, pagesize);
            ViewBag.TenLoai = new UserDAO().GetTenLoai_MaLoai(MaLoai);
            ViewBag.MaLoai = MaLoai;
            //var model = new UserDAO().GetNewCaThe();
            return View(model);
            // }

        }
        [HttpGet]
        public ActionResult ChiTiet(int MaLoai, int MaCaThe) {
            var user = Session["user"] as NguoiDung;
            if(user!=null)
                ViewBag.tennguoidung = user.TenDangNhap;
            var model = cathe.GetCaThe_MaLoai_MaCaThe(MaLoai, MaCaThe);
            ViewBag.TuoiCaThe = cathe.TuoiCaThe(MaCaThe);
            return View(model);
        }
        
        public ActionResult Tim(string ten)
        {
            var user = Session["user"] as NguoiDung;
            if(user != null)
                ViewBag.tennguoidung = user.TenDangNhap;
            var model = cathe.TimCaThe(ten);
            return View(model);
        }
    }
}