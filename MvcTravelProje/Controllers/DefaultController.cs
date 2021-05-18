using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTravelProje.Models.Siniflar;

namespace MvcTravelProje.Controllers
{
    public class DefaultController : Controller
    {
        Context c = new Context();
        // GET: Default
        public ActionResult Index()
        {
            var bloglar = c.Blogs.Take(10).ToList();
            return View(bloglar);
        }

        public ActionResult About()
        {
            return View();
        }

        public PartialViewResult Partial1()
        {
            var bloglar = c.Blogs.OrderByDescending(x => x.ID).Take(3).ToList();
            return PartialView(bloglar);
        }

        public PartialViewResult Partial2()
        {
            var topon = c.Blogs.OrderByDescending(x=>x.ID).Take(10).ToList();
            return PartialView(topon);
        }

        public PartialViewResult Partial3()
        {
            var deger = c.Blogs.Take(3).ToList();
            return PartialView(deger);
        }

        public PartialViewResult Partial4()
        {
            var deger = c.Blogs.OrderByDescending(x => x.ID).Take(3).ToList();
            return PartialView(deger);
        }
    }
}