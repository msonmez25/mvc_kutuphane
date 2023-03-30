using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class DuyuruController : Controller
    {
        // GET: Duyuru
        DbMvcKutuphaneEntities db = new DbMvcKutuphaneEntities();
        public ActionResult Index()
        {
            var degerler = db.Tbl_Duyuru.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult DuyuruEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DuyuruEkle(Tbl_Duyuru p)
        {
            db.Tbl_Duyuru.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DuyuruSil(int id)
        {
            var duyuru = db.Tbl_Duyuru.Find(id);
            db.Tbl_Duyuru.Remove(duyuru);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult DuyuruDetay(Tbl_Duyuru t)
        {
            var duyuru = db.Tbl_Duyuru.Find(t.ID);
            return View("DuyuruDetay",duyuru);
        }

        public ActionResult DuyuruGuncelle(Tbl_Duyuru d)
        {
            var duyuru = db.Tbl_Duyuru.Find(d.ID);
            duyuru.KATEGORI = d.KATEGORI;
            duyuru.ICERIK = d.ICERIK;
            duyuru.ILANTARIH = d.ILANTARIH;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}