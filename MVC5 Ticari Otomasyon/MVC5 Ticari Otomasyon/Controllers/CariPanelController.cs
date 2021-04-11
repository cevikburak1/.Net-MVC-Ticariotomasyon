using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVC5_Ticari_Otomasyon.Models.Sınıflar;
namespace MVC5_Ticari_Otomasyon.Controllers
{
    public class CariPanelController : Controller
    {
        // GET: CariPanel
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["CariMail"];
            var degerler = c.Mesajlars.Where(x => x.Alıcı == mail).ToList();
            ViewBag.m = mail;
            var mailıd = c.Carilers.Where(x => x.CariMail == mail).Select(y => y.CarilId).FirstOrDefault();
            ViewBag.mid = mailıd;
            var toplamsatıs = c.SatışHarekets.Where(x => x.Carilerid == mailıd).Count();
            ViewBag.toplamsatış = toplamsatıs;
            var toplamtutar = c.SatışHarekets.Where(x => x.Carilerid == mailıd).Sum(y => (double?)y.ToplamTutar);
            ViewBag.tutar = toplamtutar;
            var toplamadet = c.SatışHarekets.Where(x => x.Carilerid == mailıd).Sum(y => (double?)y.ToplamTutar);
            ViewBag.adet = toplamadet;
            var adsoyad = c.Carilers.Where(x => x.CariMail == mail).Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();
            ViewBag.adsoyad = adsoyad;
            var mal = c.Carilers.Where(x => x.CariMail == mail).Select(y => y.CariMail).FirstOrDefault();
            ViewBag.mal = mal;
            var sehır = c.Carilers.Where(x => x.CariMail == mail).Select(y => y.CariSehir).FirstOrDefault();
            ViewBag.sehır = sehır;
            var sıf = c.Carilers.Where(x => x.CariMail == mail).Select(y => y.Şifre).FirstOrDefault();
            ViewBag.sıf = sıf;
            return View(degerler);
        }
        public ActionResult Siparişlerim()
        {
            var mail = (string)Session["CariMail"];
            var id = c.Carilers.Where(x => x.CariMail == mail.ToString()).Select(y => y.CarilId).FirstOrDefault();
            var degerler = c.SatışHarekets.Where(x => x.Carilerid == id).ToList();
            return View(degerler);
        }
        
        public ActionResult MesajListesi()
        {
             var mail = (string)Session["CariMail"];
            var mesajlar = c.Mesajlars.Where(x=>x.Alıcı==mail).OrderByDescending(x=>x.MesajId).ToList();
            var gelensayisi = c.Mesajlars.Count(x => x.Alıcı == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = c.Mesajlars.Count(x => x.Gönderici == mail).ToString();
            ViewBag.d2 = gidensayisi;
            return View(mesajlar);
        }
        public ActionResult GidenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var mesajlar = c.Mesajlars.Where(x => x.Gönderici == mail).OrderByDescending(x => x.MesajId).ToList();
            var gidensayisi = c.Mesajlars.Count(x => x.Gönderici == mail).ToString();
            ViewBag.d2 = gidensayisi;
            var gelensayisi = c.Mesajlars.Count(x => x.Alıcı == mail).ToString();
            ViewBag.d1 = gelensayisi;
            return View(mesajlar);
        }
        public ActionResult MesajDetay(int id)
        {
            var degerler = c.Mesajlars.Where(x => x.MesajId == id).ToList();
            var mail = (string)Session["CariMail"];
            var gelensayisi = c.Mesajlars.Count(x => x.Alıcı == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = c.Mesajlars.Count(x => x.Gönderici == mail).ToString();
            ViewBag.d2 = gidensayisi;
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            var mail = (string)Session["CariMail"];
            var gelensayisi = c.Mesajlars.Count(x => x.Alıcı == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = c.Mesajlars.Count(x => x.Gönderici == mail).ToString();
            ViewBag.d2 = gidensayisi;
            return View();
        }
        [HttpPost]
        public ActionResult YeniMesaj(Mesajlar m)
        {
            var mail = (string)Session["CariMail"];
            m.Gönderici = mail;
            m.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.Mesajlars.Add(m);
            c.SaveChanges();
            return RedirectToAction("GidenMesajlar","CariPanel");
        }
        public ActionResult KargoTakip(string p)
        {

            var k = from x in c.KargoDetays select x;
            k = k.Where(y => y.TakipKodu.Contains(p));
            return View(k.ToList());
        }
        public ActionResult CariKargoDetay(string id)
        {
            var degerler = c.KargoTakips.Where(x => x.TakipKodu == id).ToList();
            return View(degerler);

        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
        public PartialViewResult Partial1()
        {
            var mail = (string)Session["CariMail"];
            var id = c.Carilers.Where(x => x.CariMail == mail).Select(y => y.CarilId).FirstOrDefault();
            var caribul = c.Carilers.Find(id);
            return PartialView("Partial1",caribul);
        }
        public PartialViewResult Partia2()
        {
            var veriler = c.Mesajlars.Where(x => x.Gönderici == "admin").ToList();
            return PartialView(veriler);
        }
        public ActionResult BilgiGuncelle(Cariler cr)
        {
            var cari = c.Carilers.Find(cr.CarilId);
            cari.CariAd = cr.CariAd;
            cari.CariSoyad = cr.CariSoyad;
            cari.CariSehir = cr.CariSehir;
            cari.CariMail = cr.CariMail;
            cari.Şifre = cr.Şifre;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}