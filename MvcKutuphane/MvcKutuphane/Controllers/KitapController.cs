using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class KitapController : Controller
    {
        // GET: Kitap
        DbMvcKutuphaneEntities db = new DbMvcKutuphaneEntities();
        public ActionResult Index()
        {
            //var kitaplar = from k in db.Tbl_Kitap select k;
            //if(!string.IsNullOrEmpty(p))
            //{
            //    kitaplar = kitaplar.Where(m => m.AD.Contains(p));
            //}

            var kitaplar = db.Tbl_Kitap.ToList();
            return View(kitaplar);
        }


        [HttpGet]
        public ActionResult KitapEkle()
        {
            //Kategorileri getirmek için
            List<SelectListItem> deger1 = (from i in db.Tbl_Kategori.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString(),
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            //Yazarları getirmek için
            List<SelectListItem> deger2 = (from i in db.Tbl_Yazar.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD + ' ' + i.SOYAD,
                                               Value = i.ID.ToString(),
                                           }).ToList();
            ViewBag.dgr2 = deger2;

            return View();
        }

        [HttpPost]
        public ActionResult KitapEkle(Tbl_Kitap p)
        {           
            var ktg = db.Tbl_Kategori.Where(k => k.ID == p.Tbl_Kategori.ID).FirstOrDefault();
            var yzr = db.Tbl_Yazar.Where(k => k.ID == p.Tbl_Yazar.ID).FirstOrDefault();

            p.Tbl_Kategori = ktg;
            p.Tbl_Yazar = yzr;

            p.DURUM = true;

            db.Tbl_Kitap.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult KitapSil(int id)
        {
            var kitap = db.Tbl_Kitap.Find(id);
            db.Tbl_Kitap.Remove(kitap);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult KitapGetir(int id)
        {
            var kitap = db.Tbl_Kitap.Find(id);

            //Kategorileri getirmek için
            List<SelectListItem> deger1 = (from i in db.Tbl_Kategori.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString(),
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            //Yazarları getirmek için
            List<SelectListItem> deger2 = (from i in db.Tbl_Yazar.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD + ' ' + i.SOYAD,
                                               Value = i.ID.ToString(),
                                           }).ToList();
            ViewBag.dgr2 = deger2;

            return View("KitapGetir", kitap);
        }

        public ActionResult KitapGuncelle(Tbl_Kitap p)
        {
            var kitap = db.Tbl_Kitap.Find(p.ID);
            kitap.AD = p.AD;
            kitap.BASIMYIL = p.BASIMYIL;
            kitap.SAYFASAYISI = p.SAYFASAYISI;            
            kitap.YAYINEVI = p.YAYINEVI;
            kitap.KITAPRESIM = p.KITAPRESIM;
            kitap.DURUM = true;

            //Birden fazla ilişkili tabloda güncelleme işlemi
            var ktg = db.Tbl_Kategori.Where(k => k.ID == p.Tbl_Kategori.ID).FirstOrDefault();
            var yzr = db.Tbl_Yazar.Where(k => k.ID == p.Tbl_Yazar.ID).FirstOrDefault();

            kitap.KATEGORI = ktg.ID;
            kitap.YAZAR = yzr.ID;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}