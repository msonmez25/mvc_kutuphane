using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;


namespace MvcKutuphane.Controllers
{
    public class OduncController : Controller
    {
        // GET: Odunc
        DbMvcKutuphaneEntities db = new DbMvcKutuphaneEntities();
        [Authorize(Roles ="A")]
        public ActionResult Index()
        {
            var degerler = db.Tbl_Hareket.Where(x => x.ISLEMDURUM == false).ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult OduncVer()
        {
            //Kitap getirmek için
            List<SelectListItem> deger1 = (from i in db.Tbl_Kitap.Where(x => x.DURUM == true).OrderBy(p=>p.AD).ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString(),
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            //Üye getirmek için
            List<SelectListItem> deger2 = (from i in db.Tbl_Uyeler.OrderBy(p => p.AD).ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD + ' ' + i.SOYAD,
                                               Value = i.ID.ToString(),
                                           }).ToList();
            ViewBag.dgr2 = deger2;

            //Personel getirmek için
            List<SelectListItem> deger3 = (from i in db.Tbl_Personel.OrderBy(p => p.PERSONEL).ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.PERSONEL,
                                               Value = i.ID.ToString(),
                                           }).ToList();
            ViewBag.dgr3 = deger3;

            return View();
        }

        [HttpPost]
        public ActionResult OduncVer(Tbl_Hareket p)
        {
            var ktp = db.Tbl_Kitap.Where(k => k.ID == p.Tbl_Kitap.ID).FirstOrDefault();
            var uye = db.Tbl_Uyeler.Where(k => k.ID == p.Tbl_Uyeler.ID).FirstOrDefault();
            var prs = db.Tbl_Personel.Where(k => k.ID == p.Tbl_Personel.ID).FirstOrDefault();

            p.Tbl_Kitap = ktp;
            p.Tbl_Uyeler = uye;
            p.Tbl_Personel = prs;

            p.ISLEMDURUM = false;

            db.Tbl_Hareket.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult OduncIade(Tbl_Hareket p)
        {
            var odnc = db.Tbl_Hareket.Find(p.ID);
            DateTime d1 = DateTime.Parse(odnc.IADETARIH.ToString());
            DateTime d2 = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            TimeSpan d3 = d2 - d1;

            ViewBag.dgr = d3.TotalDays;
            return View("OduncIade", odnc);
        }


        public ActionResult OduncGuncelle(Tbl_Hareket p)
        {
            var hrk = db.Tbl_Hareket.Find(p.ID);
            hrk.UYEGETIRTARIH = p.UYEGETIRTARIH;
            hrk.ISLEMDURUM = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}