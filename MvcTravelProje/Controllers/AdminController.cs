using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTravelProje.Models.Siniflar;
using System.Web.Security;

namespace MvcTravelProje.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        Context c = new Context();

        // GET: Admin
        public ActionResult Index()
        {
            var blog = c.Blogs.ToList();
            return View(blog);
        }

        [HttpGet]
        public ActionResult YeniBlog()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniBlog(Blog b)
        {
            c.Blogs.Add(b);
            c.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }

        public ActionResult BlogSil(int id)
        {
            var blog = c.Blogs.Find(id);
            c.Blogs.Remove(blog);
            c.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }

        public ActionResult BlogGetir(int id)
        {
            var blog = c.Blogs.Find(id);
            return View("BlogGetir", blog);
        }

        public ActionResult BlogGüncelle(Blog b)
        {
            var blog = c.Blogs.Find(b.ID);
            blog.Baslik = b.Baslik;
            blog.Tarih = b.Tarih;
            blog.Aciklama = b.Aciklama;
            blog.BlogImage = b.BlogImage;
            c.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }

        public ActionResult BlogDetay(int id)
        {
            var blogdetay = c.Blogs.Find(id);
            return View("BlogDetay", blogdetay);
        }

        public ActionResult YorumListesi()
        {
            var yorumlar = c.Yorumlars.ToList();
            return View(yorumlar);
        }

        public ActionResult YorumSil(int id)
        {
            var yorum = c.Yorumlars.Find(id);
            c.Yorumlars.Remove(yorum);
            c.SaveChanges();
            return RedirectToAction("YorumListesi", "Admin");
        }

        public ActionResult YorumGetir(int id)
        {
            var yorum = c.Yorumlars.Find(id);
            return View("YorumGetir", yorum);
        }

        public ActionResult YorumGuncelle(Yorumlar y)
        {
            var yorumlar = c.Yorumlars.Find(y.ID);
            yorumlar.KullaniciAdi = y.KullaniciAdi;
            yorumlar.Mail = y.Mail;
            yorumlar.Yorum = y.Yorum;
            c.SaveChanges();
            return RedirectToAction("YorumListesi", "Admin");
        }

        public ActionResult HakkimizdaListesi()
        {
            var hakkimizda = c.Hakkimizdas.ToList();
            return View(hakkimizda);
        }

        public ActionResult HakkimizdaGetir(int id)
        {
            var hakkimizda = c.Hakkimizdas.Find(id);
            return View("HakkimizdaGetir", hakkimizda);
        }

        public ActionResult HakkimizdaGuncelle(Hakkimizda h)
        {
            var hakkimizda = c.Hakkimizdas.Find(h.ID);
            hakkimizda.FotoUrl = h.FotoUrl;
            hakkimizda.Aciklama = h.Aciklama;
            c.SaveChanges();
            return RedirectToAction("HakkimizdaListesi", "Admin");
        }

        public ActionResult AdminBilgileri()
        {
            var admin = c.Admins.ToList();
            return View(admin);
        }

        public ActionResult AdminBilgiGetir(int id)
        {
            var admin = c.Admins.Find(id);
            return View("AdminBilgiGetir", admin);
        }

        public ActionResult AdminBilgiGuncelle(Admin a)
        {
            var admin = c.Admins.Find(a.ID);
            admin.Kullanici = a.Kullanici;
            admin.Sifre = a.Sifre;
            c.SaveChanges();
            return RedirectToAction("AdminBilgileri", "Admin");
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "GirisYap");
        }
    }
}