using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class istatistikController : Controller
    {
        // GET: istatistik
        DbMvcKutuphaneEntities db = new DbMvcKutuphaneEntities();
        public ActionResult Index()
        {
            var deger1 = db.Tbl_Uyeler.Count();
            var deger2 = db.Tbl_Kitap.Count();
            var deger3 = db.Tbl_Kitap.Where(x=>x.DURUM==false).Count();
            var deger4 = db.Tbl_Cezalar.Sum(x => x.PARA);

            ViewBag.dg1 = deger1;
            ViewBag.dg2 = deger2;
            ViewBag.dg3 = deger3;
            ViewBag.dg4 = deger4;
            return View();
        }

        public ActionResult Hava()
        {
            return View();
        }

        public ActionResult HavaKart()
        {
            return View();
        }

        public ActionResult Galeri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ResimYukle(HttpPostedFileBase dosya)
        {
            if (dosya.ContentLength > 0)
            {
                string dosyayolu = Path.Combine(Server.MapPath("~/web2/resimler/"), Path.GetFileName(dosya.FileName));
                dosya.SaveAs(dosyayolu);
            }
            return RedirectToAction("Galeri");
        }


        public ActionResult LinquKart()
        {
            var deger1 = db.Tbl_Kitap.Count();
            var deger2 = db.Tbl_Uyeler.Count();
            var deger3 = db.Tbl_Cezalar.Sum(x => x.PARA);
            var deger4 = db.Tbl_Kitap.Where(x => x.DURUM == false).Count();
            var deger5 = db.Tbl_Kategori.Count();
            var deger6 = db.EnAktifUye().FirstOrDefault();
            var deger7 = db.EnCokOkunanKitap().FirstOrDefault();
            var deger8 = db.EnFazlaKitapYazar().FirstOrDefault();
            var deger9 = db.EniyiYayinEvi().FirstOrDefault();
            //var deger9 = db.Tbl_Kitap.GroupBy(x=>x.YAYINEVI).OrderByDescending(z=>z.Count()).Select(y=> new { y.Key}).FirstOrDefault();
            var deger10 = db.EnBasariliPersonel().FirstOrDefault();
            var deger11 = db.Tbl_Iletisim.Count();
            var deger12 = db.Tbl_Hareket.Where(x => x.ALISTARIH == DateTime.Today).Select(c => c.KITAP).Count();


            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            ViewBag.dgr4 = deger4;
            ViewBag.dgr5 = deger5;
            ViewBag.dgr6 = deger6;
            ViewBag.dgr7 = deger7;
            ViewBag.dgr8 = deger8;
            ViewBag.dgr9 = deger9;
            ViewBag.dgr10 = deger10;
            ViewBag.dgr11 = deger11;
            ViewBag.dgr12 = deger12;
            return View();
        }

    }
}