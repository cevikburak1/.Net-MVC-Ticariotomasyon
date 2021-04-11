using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5_Ticari_Otomasyon.Models.Sınıflar;

namespace MVC5_Ticari_Otomasyon.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        Context c = new Context();
        public ActionResult Index()
        {
            var personel = c.Personels.Where(x => x.Durum == true).ToList();
            return View(personel);
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> kgb = (from x in c.Departmens.ToList() select new SelectListItem { Text = x.DepartmanAd, Value = x.DepartmanId.ToString() }).ToList();
            ViewBag.drop = kgb;
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(Personel p)
        {
           
            var kgb = c.Departmens.Where(x => x.DepartmanId == p.Departmanid).FirstOrDefault();
            p.Departman = kgb;
            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelSil(int id)
        {
            var perbul = c.Personels.Find(id);
            perbul.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> kgb = (from x in c.Departmens.ToList() select new SelectListItem { Text = x.DepartmanAd, Value = x.DepartmanId.ToString() }).ToList();
            ViewBag.drop = kgb;
            var perdeger = c.Personels.Find(id);
            return View("PersonelGetir", perdeger);

        }
        public ActionResult PersonelGuncelle(Personel p)
        {
            var pre = c.Personels.Find(p.PersonelId);
            pre.PersonelAd = p.PersonelAd;
            pre.PersonelSoyad = p.PersonelSoyad;
            pre.PersonelGörsel = p.PersonelGörsel;
            pre.Departmanid = p.Departmanid;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelList()
        {
            var sorgu = c.Personels.ToList();
            return View(sorgu);
        }
    }
}