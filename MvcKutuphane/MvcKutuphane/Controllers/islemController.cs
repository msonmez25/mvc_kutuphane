using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class islemController : Controller
    {
        // GET: islem
        DbMvcKutuphaneEntities db = new DbMvcKutuphaneEntities();
        public ActionResult Index()
        {
            var degerler = db.Tbl_Hareket.Where(x => x.ISLEMDURUM == true).ToList();
            return View(degerler);
        }
    }
}