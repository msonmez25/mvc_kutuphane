using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class YazarController : Controller
    {
        // GET: Yazar
        DbMvcKutuphaneEntities db = new DbMvcKutuphaneEntities();
        public ActionResult Index()
        {
            var degerler = db.Tbl_Yazar.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YazarEkle()
        {
            return View();
        }


        [HttpPost]
        public ActionResult YazarEkle(Tbl_Yazar p)
        {
            if (!ModelState.IsValid)
            {
                return View("YazarEkle");
            }
            db.Tbl_Yazar.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult YazarSil(int id)
        {
            var yazar =db.Tbl_Yazar.Find(id);
            db.Tbl_Yazar.Remove(yazar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult YazarGetir(int id)
        {
            var yazar = db.Tbl_Yazar.Find(id);
            return View("YazarGetir", yazar);
        }

        public ActionResult YazarGuncelle(Tbl_Yazar p)
        {
            var yazar = db.Tbl_Yazar.Find(p.ID);
            yazar.AD = p.AD;
            yazar.SOYAD = p.SOYAD;
            yazar.DETAY = p.DETAY;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult YazarKitaplar(int id)
        {
            var yazar = db.Tbl_Kitap.Where(x => x.YAZAR == id).ToList();
            var yzrad = db.Tbl_Yazar.Where(y => y.ID == id).Select(z => z.AD + " " + z.SOYAD).FirstOrDefault();
            ViewBag.yazaradtasi = yzrad;
            return View(yazar);
        }
    }
}