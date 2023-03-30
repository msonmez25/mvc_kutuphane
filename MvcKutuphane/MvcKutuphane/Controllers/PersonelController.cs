using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        DbMvcKutuphaneEntities db = new DbMvcKutuphaneEntities();
        public ActionResult Index()
        {
            var degerler = db.Tbl_Personel.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult PersonelEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PersonelEkle(Tbl_Personel p)
        {
            if(!ModelState.IsValid)
            {
                return View("PersonelEkle");
            }
            db.Tbl_Personel.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult PersonelSil(int id)
        {
            var personel = db.Tbl_Personel.Find(id);
            db.Tbl_Personel.Remove(personel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult PersonelGetir(int id)
        {
            var prs = db.Tbl_Personel.Find(id);
            return View("PersonelGetir", prs);
        }

        public ActionResult PersonelGuncelle(Tbl_Personel p)
        {
            var prs = db.Tbl_Personel.Find(p.ID);
            prs.PERSONEL = p.PERSONEL;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}