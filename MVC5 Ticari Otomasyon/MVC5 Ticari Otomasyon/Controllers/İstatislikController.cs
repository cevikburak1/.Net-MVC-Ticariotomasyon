using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5_Ticari_Otomasyon.Models.Sınıflar;

namespace MVC5_Ticari_Otomasyon.Controllers
{
    public class İstatislikController : Controller
    {
        // GET: İstatislik
        Context c = new Context();
        public ActionResult Index()
        {
            var deger1 = c.Carilers.Count().ToString();
            ViewBag.d1 = deger1;
            var deger2 = c.Ürünlers.Count().ToString();
            ViewBag.d2 = deger2;
            var deger3 = c.Personels.Count().ToString();
            ViewBag.d3 = deger3;
            var deger4 = c.Kategoris.Count().ToString();
            ViewBag.d4 = deger4;
            var deger5 = c.Ürünlers.Sum(x=>x.Stok).ToString();
            ViewBag.d5 = deger5;
            var deger6 = (from x in c.Ürünlers select x.Marka).Distinct().Count().ToString();
            ViewBag.d6 = deger6;
            var deger7 = c.Ürünlers.Count(x => x.Stok<=500).ToString();
            ViewBag.d7 = deger7;
            var deger8 = (from x in c.Ürünlers orderby x.SatışFiyat descending select x.UrunAd).FirstOrDefault();
            ViewBag.d8 = deger8;
            var deger9 = (from x in c.Ürünlers orderby x.SatışFiyat ascending select x.UrunAd).FirstOrDefault();
            ViewBag.d9 = deger9;
            var deger10 = c.Ürünlers.Count(x => x.UrunAd == "Buzdolabı").ToString();
            ViewBag.d10 = deger10;
            var deger11 = c.Ürünlers.Count(x => x.UrunAd == "Laptop").ToString();
            ViewBag.d11 = deger11;
            var deger12 = c.Ürünlers.GroupBy(x => x.Marka).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            ViewBag.d12 = deger12;
            var deger13 = c.Ürünlers.Where(u=>u.UrunId==(c.SatışHarekets.GroupBy(x => x.Urunid).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault())).Select(k=>k.UrunAd).FirstOrDefault();
            ViewBag.d13 = deger13;
            var deger14 = c.SatışHarekets.Sum(x => x.ToplamTutar).ToString();
            ViewBag.d14 = deger14;
            DateTime bugun = DateTime.Today;
            var deger15 = c.SatışHarekets.Count(x => x.Tarih == bugun);
            ViewBag.d15 = deger15;
            var deger16 = c.SatışHarekets.Where(x => x.Tarih == bugun).Sum(y=>(double?)y.ToplamTutar).ToString();
            ViewBag.d16 = deger16;
            return View();
        }
        public ActionResult KolayTablolar()
        {
            var sorgu = from x in c.Carilers group x by x.CariSehir into g select new SınıfGrub
            {
                şehir = g.Key,
                Sayi = g.Count()
            };
            return View(sorgu.ToList());
        }
        public PartialViewResult Partial1()
        {
            var sorgu2 = from x in c.Personels
                         group x by x.Departman.DepartmanAd into g
                         select new SınıfGrub2
                         {
                             departman = g.Key,
                             sayı = g.Count()

                         };
           return PartialView(sorgu2.ToList());
    }
        public PartialViewResult Partial2()
        {
            var sorgu = c.Carilers.ToList();
            return PartialView(sorgu);
        }
        public PartialViewResult Partial3()
        {
            var sorgu1 = c.Ürünlers.ToList();
            return PartialView(sorgu1);
        }
        public PartialViewResult Partial4()
        {
            var sorgu2 = from x in c.Ürünlers
                         group x by x.Marka into g
                         select new SınıfGrub3
                         {
                             marka = g.Key,
                             sayi = g.Count()

                         };
            return PartialView(sorgu2.ToList());
        }
    }
}