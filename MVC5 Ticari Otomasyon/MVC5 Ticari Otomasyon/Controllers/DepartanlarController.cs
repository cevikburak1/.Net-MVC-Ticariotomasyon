using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5_Ticari_Otomasyon.Models.Sınıflar;

namespace MVC5_Ticari_Otomasyon.Controllers
{
    public class DepartanlarController : Controller
    {
        // GET: Departanlar
        Context c = new Context();
        public ActionResult Index()
        {
            var Depratman = c.Departmens.Where(x=>x.Durum==true).ToList();
            return View(Depratman);
        }
        [HttpGet]
        public ActionResult YeniDepartman()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniDepartman(Departman d)
        {
            
            c.Departmens.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanSil(int id)
        {
            var departmanbul = c.Departmens.Find(id);
            departmanbul.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult DepartmanGetir(int id)
        {
            List<SelectListItem> dp = (from x in c.Departmens.ToList() select new SelectListItem { Text = x.DepartmanAd, Value = x.DepartmanId.ToString() }).ToList();
            ViewBag.drop = dp;
            var departmanget = c.Departmens.Find(id);
            return View("DepartmanGetir", departmanget);
        }
        public ActionResult DepartmanGuncele(Departman d)
        {
            var dprt = c.Departmens.Find(d.DepartmanId);
            dprt.DepartmanAd = d.DepartmanAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanDetay(int id)
        {
            var degerler = c.Personels.Where(x => x.Departmanid == id).ToList();
            var dpt = c.Departmens.Where(x => x.DepartmanId == id).Select(y => y.DepartmanAd).FirstOrDefault();
            ViewBag.d = dpt;
            return View(degerler);
        }
        public ActionResult DepartmanPersonelSatış(int id)
        {
            var degerler = c.SatışHarekets.Where(x => x.Personelid == id).ToList();
            var per = c.Personels.Where(x => x.PersonelId == id).Select(y => y.PersonelAd + " " + y.PersonelSoyad).FirstOrDefault();
            ViewBag.dper = per;
            return View(degerler);
        }
    }
}