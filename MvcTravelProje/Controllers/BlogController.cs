using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTravelProje.Models.Siniflar;

namespace MvcTravelProje.Controllers
{
    public class BlogController : Controller
    {
        Context c = new Context();
        BlogYorum by = new BlogYorum();
        // GET: Blog
        public ActionResult Index()
        {
            //var bloglar = c.Blogs.ToList();
            by.Deger1 = c.Blogs.ToList();
            by.Deger3 = c.Blogs.OrderByDescending(x => x.ID).Take(3).ToList();
            return View(by);
        }

        public ActionResult BlogDetay(int id)
        {
            //var blog = c.Blogs.Where(x => x.ID == id).ToList();
            by.Deger1 = c.Blogs.Where(x => x.ID == id).ToList();
            by.Deger2 = c.Yorumlars.Where(x => x.Blogid == id).ToList();
            by.Deger3 = c.Blogs.OrderByDescending(x => x.ID).Take(6).ToList();
            return View(by);
        }

        public PartialViewResult SonYorumlar()
        {
            var yorumlar = c.Yorumlars.OrderByDescending(x => x.ID).Take(3).ToList();
            return PartialView(yorumlar);
        }

        [HttpGet]
        public PartialViewResult YorumYap(int id)
        {
            ViewBag.yorum = id;
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult YorumYap(Yorumlar y)
        {
            c.Yorumlars.Add(y);
            c.SaveChanges();
            return PartialView();
        }
    }
}