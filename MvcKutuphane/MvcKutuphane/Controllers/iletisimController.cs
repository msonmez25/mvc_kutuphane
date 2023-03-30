using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class iletisimController : Controller
    {
        // GET: iletisim
        DbMvcKutuphaneEntities db = new DbMvcKutuphaneEntities();
        public ActionResult Index()
        {
            var mesajlar = db.Tbl_Iletisim.ToList();
            return View(mesajlar);
        }
    }
}