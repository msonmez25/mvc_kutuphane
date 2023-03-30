using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class AyarlarController : Controller
    {
        // GET: Ayarlar
        DbMvcKutuphaneEntities db = new DbMvcKutuphaneEntities();
        
        public ActionResult Index2()
        {
            var kullanici = db.Tbl_Admin.ToList();
            return View(kullanici);
        }

        [HttpGet]
        public ActionResult YeniAdmin()
        {
            return View();
        }


        [HttpPost]
        public ActionResult YeniAdmin(Tbl_Admin p)
        {
            db.Tbl_Admin.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index2");
        }

        public ActionResult AdminSil(int id)
        {
            var kullanici = db.Tbl_Admin.Find(id);
            db.Tbl_Admin.Remove(kullanici);
            db.SaveChanges();
            return RedirectToAction("Index2");
        }

        
        public ActionResult AdminGetir(int id)
        {
            var admin = db.Tbl_Admin.Find(id);
            return View("AdminGetir", admin);
        }

       
        public ActionResult AdminGuncelle(Tbl_Admin p)
        {
            var admin = db.Tbl_Admin.Find(p.ID);
            admin.AD = p.AD;
            admin.SOYAD = p.SOYAD;
            admin.FOTOGRAF = p.FOTOGRAF;
            admin.EGITIM = p.EGITIM;
            admin.TELEFON = p.TELEFON;
            admin.MAIL = p.MAIL;
            admin.KULLANICI = p.KULLANICI;
            admin.SIFRE = p.SIFRE;
            admin.YETKI = p.YETKI;            
            db.SaveChanges();
            return RedirectToAction("Index2");
        }
    }
}