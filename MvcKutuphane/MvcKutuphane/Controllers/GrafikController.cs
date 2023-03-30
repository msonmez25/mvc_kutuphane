using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class GrafikController : Controller
    {
        // GET: Grafik
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GrafikOlustur()
        {
            return Json(kitapsayi(), JsonRequestBehavior.AllowGet);
        }

        public List<Class1> kitapsayi()
        {
            List<Class1> cs = new List<Class1>();
            DbMvcKutuphaneEntities db = new DbMvcKutuphaneEntities();
            cs = db.Tbl_Kitap.Select(x => new Class1
            {
                yayinevi=x.YAYINEVI,
                kitapsayi=x.ID
            }).ToList();
            return cs;
        }

       
    }
}