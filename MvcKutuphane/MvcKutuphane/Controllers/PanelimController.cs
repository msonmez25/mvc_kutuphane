using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    
    public class PanelimController : Controller
    {
        // GET: Panelim
        DbMvcKutuphaneEntities db = new DbMvcKutuphaneEntities();
        [HttpGet]        
        public ActionResult Index()
        {
            var uyemail = (string)Session["Mail"];
            //var degerler = db.Tbl_Uyeler.FirstOrDefault(z => z.MAIL == uyemail);
            var degerler = db.Tbl_Duyuru.ToList();
            var ad = db.Tbl_Uyeler.Where(x => x.MAIL == uyemail).Select(y => y.AD).FirstOrDefault();
            ViewBag.ad1 = ad;
            var soyad = db.Tbl_Uyeler.Where(x => x.MAIL == uyemail).Select(y => y.SOYAD).FirstOrDefault();
            ViewBag.ad2 = soyad;
            var fotograf = db.Tbl_Uyeler.Where(x => x.MAIL == uyemail).Select(y => y.FOROGRAF).FirstOrDefault();
            ViewBag.fotograf3 = fotograf;
            var kullanici = db.Tbl_Uyeler.Where(x => x.MAIL == uyemail).Select(y => y.KULLANICIADI).FirstOrDefault();
            ViewBag.kullanici4 = kullanici;
            var egitim = db.Tbl_Uyeler.Where(x => x.MAIL == uyemail).Select(y => y.EGITIM).FirstOrDefault();
            ViewBag.egitim5 = egitim;
            var telefon = db.Tbl_Uyeler.Where(x => x.MAIL == uyemail).Select(y => y.TELEFON).FirstOrDefault();
            ViewBag.telefon6 = telefon;
            var mail = db.Tbl_Uyeler.Where(x => x.MAIL == uyemail).Select(y => y.MAIL).FirstOrDefault();
            ViewBag.mail7 = mail;

            var uyeid = db.Tbl_Uyeler.Where(x => x.MAIL == uyemail).Select(y => y.ID).FirstOrDefault();
            var hareket = db.Tbl_Hareket.Where(x => x.UYE == uyeid).Count();
            ViewBag.hareket8 = hareket;

            var gelenmesaj = db.Tbl_Mesajlar.Where(x => x.ALICI == uyemail).Count();
            ViewBag.gelen9 = gelenmesaj;

            var gidenmesaj = db.Tbl_Mesajlar.Where(x => x.GONDEREN == uyemail).Count();
            ViewBag.giden10 = gidenmesaj;

            var duyuru = db.Tbl_Duyuru.Count();
            ViewBag.duyuru11 = duyuru;

            return View(degerler);
        }

        [HttpPost]
        public ActionResult Index2(Tbl_Uyeler p)
        {
            var kullanici = (string)Session["Mail"];
            var uye = db.Tbl_Uyeler.FirstOrDefault(x => x.MAIL == kullanici);
            uye.SIFRE = p.SIFRE;
            uye.AD = p.AD;
            uye.SOYAD = p.SOYAD;
            uye.EGITIM = p.EGITIM;
            uye.KULLANICIADI = p.KULLANICIADI;
            uye.FOROGRAF = p.FOROGRAF;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Kitaplarim()
        {
            var kullanici = (string)Session["Mail"];
            var id = db.Tbl_Uyeler.Where(x => x.MAIL == kullanici.ToString()).Select(z => z.ID).FirstOrDefault();
            var degerler = db.Tbl_Hareket.Where(x => x.UYE == id).ToList();
            return View(degerler);
        }

        public ActionResult Duyurular()
        {
            var duyurulistesi = db.Tbl_Duyuru.ToList();
            return View(duyurulistesi);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("GirisYap","Login");
        }


        public PartialViewResult Partial1()
        {
            return PartialView();
        }

        public PartialViewResult Partial2()
        {
            var kullanici = (string)Session["Mail"];
            var id = db.Tbl_Uyeler.Where(x => x.MAIL == kullanici.ToString()).Select(z => z.ID).FirstOrDefault();
            var uyebul = db.Tbl_Uyeler.Find(id);
            return PartialView("Partial2", uyebul);
        }
    }
}