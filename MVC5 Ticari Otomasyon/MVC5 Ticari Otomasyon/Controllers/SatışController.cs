using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5_Ticari_Otomasyon.Models.Sınıflar;

namespace MVC5_Ticari_Otomasyon.Controllers
{
    public class SatışController : Controller
    {
        // GET: Satış
        Context c = new Context();
        public ActionResult Index()
        {
            var bul = c.SatışHarekets.Where(x => x.Durum == true).ToList();
            return View(bul);
        }
      public ActionResult SatışIptal(int id)
        {
            var pıt = c.SatışHarekets.Find(id);
            pıt.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YeniSatış()
        {
            List<SelectListItem> kgb = (from x in c.Personels.ToList() select new SelectListItem { Text = x.PersonelAd, Value = x.PersonelId.ToString() }).ToList();
            List<SelectListItem> mab = (from x in c.Ürünlers.ToList() select new SelectListItem { Text = x.UrunAd, Value = x.UrunId.ToString() }).ToList();
            List<SelectListItem> tab = (from x in c.Carilers.ToList() select new SelectListItem { Text = x.CariAd, Value = x.CarilId.ToString() }).ToList();
            ViewBag.drop = kgb;
            ViewBag.dro = mab;
            ViewBag.dr = tab;
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatış(SatışHareket s)
        {
            var kgb = c.Personels.Where(x => x.PersonelId == s.Personelid).FirstOrDefault();
            var mab = c.Ürünlers.Where(x => x.UrunId == s.Urunid).FirstOrDefault();
            var tab = c.Carilers.Where(x => x.CarilId == s.Carilerid).FirstOrDefault();
            s.Personel = kgb;
            s.Ürünler = mab;
            s.Cariler = tab;
            c.SatışHarekets.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatısDetay(int id)
        {
            var degerler = c.SatışHarekets.Where(x => x.Satışıd == id).ToList();
            return View(degerler);
        }
    }
}