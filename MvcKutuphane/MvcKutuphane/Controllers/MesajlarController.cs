using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class MesajlarController : Controller
    {
        // GET: Mesajlar
        DbMvcKutuphaneEntities db = new DbMvcKutuphaneEntities();
        public ActionResult Index()
        {
            var uyemail = (string)Session["Mail"].ToString();
            var mesajlar = db.Tbl_Mesajlar.Where(x => x.ALICI == uyemail.ToString()).ToList();
            return View(mesajlar);
        }


        public ActionResult Giden()
        {
            var uyemail = (string)Session["Mail"].ToString();
            var mesajlar = db.Tbl_Mesajlar.Where(x => x.GONDEREN == uyemail.ToString()).ToList();
            return View(mesajlar);
        }


        [HttpGet]
        public ActionResult YeniMesaj()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMesaj(Tbl_Mesajlar t)
        {
            var uyemail = (string)Session["Mail"].ToString();
            t.GONDEREN = uyemail.ToString();
            t.TARIH = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Tbl_Mesajlar.Add(t);
            db.SaveChanges();
            return RedirectToAction("Giden", "Mesajlar");
        }

        public PartialViewResult Partial1()
        {
            var uyemail = (string)Session["Mail"].ToString();

            var gelensayisi = db.Tbl_Mesajlar.Where(x => x.ALICI == uyemail).Count();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = db.Tbl_Mesajlar.Where(x => x.GONDEREN == uyemail).Count();
            ViewBag.d2 = gidensayisi;

            return PartialView();
        }


        public ActionResult MesajDetay(int id)
        {
            var degerler = db.Tbl_Mesajlar.Where(x => x.ID == id).ToList();

            var uyemail = (string)Session["Mail"].ToString();
            var gelensayisi = db.Tbl_Mesajlar.Where(x => x.ALICI == uyemail).ToString();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = db.Tbl_Mesajlar.Where(x => x.GONDEREN == uyemail).ToString();
            ViewBag.d2 = gidensayisi;
            return View(degerler);
        }
    }
}