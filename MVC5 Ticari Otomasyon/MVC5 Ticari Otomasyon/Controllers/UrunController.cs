using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5_Ticari_Otomasyon.Models.Sınıflar;

namespace MVC5_Ticari_Otomasyon.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        Context c = new Context();
        public ActionResult Index()
        {
            var Ürünler = c.Ürünlers.Where(x => x.Durum == true).ToList();
            return View(Ürünler);
        }
        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> kgb = (from x in c.Kategoris.ToList() select new SelectListItem { Text = x.KategoriAd, Value = x.KategoriId.ToString() }).ToList();
            ViewBag.drop = kgb;
            return View();
        }
        [HttpPost]
        public ActionResult UrunEkle(Ürünler ü)
        {
            var kgb = c.Kategoris.Where(x => x.KategoriId == ü.KategoriId).FirstOrDefault();
            ü.Kategori = kgb;
            c.Ürünlers.Add(ü);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunSıl(int id)
        {
            var urunbul = c.Ürünlers.Find(id);
            urunbul.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> kgb = (from x in c.Kategoris.ToList() select new SelectListItem { Text = x.KategoriAd, Value = x.KategoriId.ToString() }).ToList();
            ViewBag.drop = kgb;
            var urundeger = c.Ürünlers.Find(id);
            return View("UrunGetir", urundeger);

        }
       
            public ActionResult UrunGuncelle(Ürünler ü)
            {
                var urn = c.Ürünlers.Find(ü.UrunId);
            urn.UrunAd = ü.UrunAd;
            urn.Marka = ü.Marka;
            urn.Stok = ü.Stok;
            urn.AlışFiyat = ü.AlışFiyat;
            urn.SatışFiyat = ü.SatışFiyat;
            urn.UrunGorsel = ü.UrunGorsel;
            urn.UrunAd = ü.UrunAd;
            urn.KategoriId = ü.KategoriId;
            c.SaveChanges();
            return RedirectToAction("Index");

            }
        public ActionResult UrunListesi()
        {
            var degerler = c.Ürünlers.ToList();
            return View(degerler);
        }
        }
     
    }
