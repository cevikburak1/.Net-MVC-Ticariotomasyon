using MVC5_Ticari_Otomasyon.Models.Sınıflar;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MVC5_Ticari_Otomasyon.Controllers
{
    public class GrafikController : Controller
    {
        // GET: Grafik
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            var grf = new Chart(width: 500, height: 500);
            grf.AddTitle(text: "Kategori-Ürün Stok Sayısı").AddLegend("Stok").AddSeries("Degerler", xValue: new[] { "Mobilya", "Ofis Eşyaları", "Bilgisayar" }, yValues: new[] { 85, 66, 87 }).Write();
            return File(grf.ToWebImage().GetBytes(), "image/jpeg");

        }
        Context c = new Context();
        public ActionResult Index3()
        {
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();
            var sonuclar = c.Ürünlers.ToList();
            sonuclar.ToList().ForEach(x => xvalue.Add(x.UrunAd));
            sonuclar.ToList().ForEach(y => yvalue.Add(y.Stok));
            var grafik = new Chart(width: 1000, height: 1000).
                AddTitle("Stoklar").
                AddSeries(chartType: "Pie", name: "Stok", xValue: xvalue, yValues:yvalue);
            return File(grafik.ToWebImage().GetBytes(), "image/jpeg");
        }
        public ActionResult Index4()
        {
            return View();
        }
        public ActionResult VisualizeUrunResult()
        {
            return Json(urunlistesi(), JsonRequestBehavior.AllowGet);
        }
        public List<Sınıf1> urunlistesi()
        {
            List<Sınıf1> snf = new List<Sınıf1>();
            snf.Add(new Sınıf1()
            {
                urunad = "Bilgisayar",
                stoksayısı = 120
            });
            snf.Add(new Sınıf1()
            {
                urunad = "Beyaz Eşya",
                stoksayısı = 150
            }) ;
            return snf;
        }
    }
 
}