using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5_Ticari_Otomasyon.Models.Sınıflar;

namespace MVC5_Ticari_Otomasyon.Controllers
{
    public class FaturaController : Controller
    {
        // GET: Fatura
        Context c = new Context();
        public ActionResult Index()
        {
            var liste = c.Faturas.ToList();
            return View(liste);
        }
        [HttpGet]
        public ActionResult YeniFatura()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniFatura(Fatura f)
        {
            c.Faturas.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturGetir(int id)
        {
            var faturagetir = c.Faturas.Find(id);
            return View("FaturGetir", faturagetir);
        }
        public ActionResult FaturaGuncelle(Fatura f)
        {
            var faturaguncelle = c.Faturas.Find(f.FaturaId);
            faturaguncelle.FaturaSırano = f.FaturaSırano;
            faturaguncelle.FaturaTarih = f.FaturaTarih;
            faturaguncelle.VergiDairesi = f.VergiDairesi;
            faturaguncelle.TeslimEden = f.TeslimEden;
            faturaguncelle.TeslimAlan = f.TeslimAlan;
            faturaguncelle.toplamtutar = f.toplamtutar;
            faturaguncelle.FaturaSaat = f.FaturaSaat;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult FaturaDetay(int id)
        {
            var degerler = c.FaturaKalems.Where(x => x.Faturaıd == id).ToList();
         
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKalem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKalem(FaturaKalem p)
        {
            c.FaturaKalems.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Dinamik()
        {
            Class2 cs = new Class2();
            cs.deger1 = c.Faturas.ToList();
            cs.deger2 = c.FaturaKalems.ToList();
            return View(cs);
        }
        public ActionResult FaturaKaydet(string FaturaSırano,DateTime FaturaTarih,String VergiDairesi,string TeslimEden,string TeslimAlan ,string FaturaSaat, string toplamtutar , FaturaKalem[] kalemler)
        {
            Fatura f = new Fatura();
            f.FaturaSırano = FaturaSırano;
            f.FaturaTarih = FaturaTarih;
            f.VergiDairesi = VergiDairesi;
            f.FaturaSaat = FaturaSaat;
            f.TeslimEden = TeslimEden;
            f.TeslimAlan = TeslimAlan;
            f.toplamtutar = decimal.Parse(toplamtutar);
            c.Faturas.Add(f);
            foreach (var x in kalemler)
            {
                FaturaKalem fk = new FaturaKalem();
                fk.acıklama = x.acıklama;
                fk.Birim = x.Birim;
                fk.FaturaKalemId= x.FaturaKalemId;
                fk.Miktar = x.Miktar;
                fk.Tutar = x.Tutar;
                c.FaturaKalems.Add(fk);
               
            }
            c.SaveChanges();
            return Json("İşlem Başarılı",JsonRequestBehavior.AllowGet);
        }
    }
}