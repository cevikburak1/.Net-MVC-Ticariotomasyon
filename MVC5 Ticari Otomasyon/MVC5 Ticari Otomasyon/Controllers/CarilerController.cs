using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5_Ticari_Otomasyon.Models.Sınıflar;

namespace MVC5_Ticari_Otomasyon.Controllers
{
    public class CarilerController : Controller
    {
        // GET: Cariler
        Context c = new Context();
        public ActionResult Index()
        {
            var Cariler = c.Carilers.Where(x => x.Durum == true).ToList();
            return View(Cariler);
        }
        [HttpGet]
        public ActionResult YeniCari()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniCari(Cariler ca)
        {
            c.Carilers.Add(ca);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariSil(int id)
        {
            var Caribul = c.Carilers.Find(id);
            Caribul.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

     public ActionResult CariGetir(int id)
        {
            var gt = c.Carilers.Find(id);
            return View("CariGetir", gt);
        }
        public ActionResult CariGüncelle(Cariler x)
        {
            var cr = c.Carilers.Find(x.CarilId);
            cr.CariAd = x.CariAd;
            cr.CariSoyad = x.CariSoyad;
            cr.CariSehir = x.CariSehir;
            cr.CariMail = x.CariMail;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult MusteriSatış(int id)
        {
            var degerler = c.SatışHarekets.Where(x => x.Carilerid == id).ToList();
            var cr = c.Carilers.Where(x => x.CarilId == id).Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();
            ViewBag.a = cr;
            return View(degerler);
        }
    }
}