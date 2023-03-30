using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        DbMvcKutuphaneEntities db = new DbMvcKutuphaneEntities();
        public ActionResult Index()
        {
            var degerler = db.Tbl_Kategori.Where(x=>x.DURUM==true).ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult KategoriEkle()
        {            
            return View();
        }

        [HttpPost]
        public ActionResult KategoriEkle(Tbl_Kategori p)
        {
            if (!ModelState.IsValid)
            {
                return View("KategoriEkle");
            }
            p.DURUM = true;
            db.Tbl_Kategori.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult KategoriSil(int id)
        {
            var kategori = db.Tbl_Kategori.Find(id);
            //db.Tbl_Kategori.Remove(kategori);
            kategori.DURUM = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult KategoriGetir(int id)
        {
            var ktg = db.Tbl_Kategori.Find(id);
            return View("KategoriGetir", ktg);
        }

        public ActionResult KategoriGuncelle(Tbl_Kategori p)
        {
            var ktg = db.Tbl_Kategori.Find(p.ID);
            ktg.AD = p.AD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}