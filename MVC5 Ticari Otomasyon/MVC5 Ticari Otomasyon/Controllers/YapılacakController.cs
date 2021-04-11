using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5_Ticari_Otomasyon.Models.Sınıflar;

namespace MVC5_Ticari_Otomasyon.Controllers
{
    public class YapılacakController : Controller
    {
        // GET: Yapılacak
        Context c = new Context();
        public ActionResult Index()
        {
            var deger1 = c.Carilers.Count().ToString();
            ViewBag.d1 = deger1;
            var deger2 = c.Ürünlers.Count().ToString();
            ViewBag.d2 = deger2;
            var deger3 = c.Kategoris.Count().ToString();
            ViewBag.d3 = deger3;
            var deger4 = (from x in c.Carilers select x.CariSehir).Distinct().Count().ToString();
            ViewBag.d4 = deger4;
            var yapilacaklar = c.Yapılcaklars.Where(x => x.Durum == true).ToList();
            return View(yapilacaklar);
        }
        [HttpGet]
        public ActionResult YeniNot()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniNot(Yapılcaklar y)
        {
            c.Yapılcaklars.Add(y);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}