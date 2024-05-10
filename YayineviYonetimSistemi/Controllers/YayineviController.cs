using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YayineviYonetimSistemi.Models.Entity;

namespace YayineviYonetimSistemi.Controllers
{
    public class YayineviController : Controller
    {
        // GET: Yayinevi
        Db_YayineviYonetimiEntities db = new Db_YayineviYonetimiEntities();
        public ActionResult Index()
        {
            var degerler = db.Yayinevleri.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YayineviEkle() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult YayineviEkle(Yayinevleri y)
        {
            db.Yayinevleri.Add(y);
            db.SaveChanges();
            return View();
        }
        public ActionResult YayineviSil(int id)
        {
            var yayinevi = db.Yayinevleri.Find(id);
            db.Yayinevleri.Remove(yayinevi);
            db.SaveChanges();
            return RedirectToAction("Index"); 
        }
        public ActionResult YayineviGetir(int id)
        {
            var yev = db.Yayinevleri.Find(id);
            return View("YayineviGetir", yev);
        }
        public ActionResult YayineviGuncelle(Yayinevleri y)
        {
            var yev = db.Yayinevleri.Find(y.yayineviID);
            yev.yayineviAdi = y.yayineviAdi;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}