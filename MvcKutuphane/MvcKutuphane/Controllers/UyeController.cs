using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
//using PagedList;
//using PagedList.Mvc;


namespace MvcKutuphane.Controllers
{
    public class UyeController : Controller
    {
        // GET: Uye
        DbMvcKutuphaneEntities db = new DbMvcKutuphaneEntities();

        // sayfalama işlemi yapabilmek için sayfa değişkeni oluşturup ilk değeri vermem gerekiyor.
        public ActionResult Index()
        {
            var degerler = db.Tbl_Uyeler.ToList();
            //var degerler = db.Tbl_Uyeler.ToList().ToPagedList(sayfa, 5);

            return View(degerler);
        }


        [HttpGet]
        public ActionResult UyeEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UyeEkle(Tbl_Uyeler p)
        {
            if (!ModelState.IsValid)
            {
                return View("UyeEkle");
            }
            db.Tbl_Uyeler.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UyeSil(int id)
        {
            var uye = db.Tbl_Uyeler.Find(id);
            db.Tbl_Uyeler.Remove(uye);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult UyeGetir(int id)
        {
            var uye = db.Tbl_Uyeler.Find(id);
            return View("UyeGetir", uye);
        }

        public ActionResult UyeGuncelle(Tbl_Uyeler p)
        {
            var uye = db.Tbl_Uyeler.Find(p.ID);
            uye.AD = p.AD;
            uye.SOYAD = p.SOYAD;
            uye.MAIL = p.MAIL;
            uye.KULLANICIADI = p.KULLANICIADI;
            uye.SIFRE = p.SIFRE;
            uye.FOROGRAF = p.FOROGRAF;
            uye.TELEFON = p.TELEFON;
            uye.EGITIM = p.EGITIM;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult UyeKitapGecmisi(int id)
        {
            var ktpgcms = db.Tbl_Hareket.Where(x => x.UYE == id).ToList();
            var uyead = db.Tbl_Uyeler.Where(y => y.ID == id).Select(z => z.AD + " " + z.SOYAD).FirstOrDefault();
            ViewBag.uyeadtasi = uyead;
            return View(ktpgcms);
        }
    }
}