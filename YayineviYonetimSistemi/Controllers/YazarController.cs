using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YayineviYonetimSistemi.Models.Entity;

namespace YayineviYonetimSistemi.Controllers
{
    public class YazarController : Controller
    {
        // GET: Yazar
        Db_YayineviYonetimiEntities db = new Db_YayineviYonetimiEntities();
        public ActionResult Index()
        {
            var degerler = db.Yazarlar.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YazarEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YazarEkle(Yazarlar z)
        {
            db.Yazarlar.Add(z);
            db.SaveChanges();
            return View();
        }
        public ActionResult YazarSil(int id)
        {
            var yazar = db.Yazarlar.Find(id);
            db.Yazarlar.Remove(yazar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YazarGetir(int id)
        {
            var yzr = db.Yazarlar.Find(id);
            return View("YazarGetir", yzr);
        }
        public ActionResult YazarGuncelle(Yazarlar z)
        {
            var yzr = db.Yazarlar.Find(z.yazarID);
            yzr.Ad = z.Ad;
            yzr.Soyad = z.Soyad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}