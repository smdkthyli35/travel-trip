using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTravelProje.Models.Siniflar;

namespace MvcTravelProje.Controllers
{
    public class IletisimController : Controller
    {
        Context c = new Context();
        // GET: Iletisim

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Iletisim i)
        {
            c.Iletisims.Add(i);
            c.SaveChanges();
            return View();
        }

        public PartialViewResult Adres()
        {
            var adres = c.AdresBlogs.ToList();
            return PartialView(adres);
        }
    }
}