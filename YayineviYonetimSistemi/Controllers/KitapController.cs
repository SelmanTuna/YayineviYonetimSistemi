using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YayineviYonetimSistemi.Models.Entity;
using YayineviYonetimSistemi.Services;

namespace YayineviYonetimSistemi.Controllers
{
    public class KitapController : Controller
    {
        // GET: Kitap
        Db_YayineviYonetimiEntities db = new Db_YayineviYonetimiEntities();
                
        public ActionResult Index(string p)
        {
            var kitaplar = from k in db.Kitaplar select k;
            if (!string.IsNullOrEmpty(p))
            {
                kitaplar = kitaplar.Where(m => m.Yayinevleri.yayineviAdi.Contains(p));
            }           
            return View(kitaplar.ToList());
        }
        [HttpGet]
        public ActionResult KitapEkle()
        {
            List<SelectListItem> deger = (from i in db.Yayinevleri.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.yayineviAdi,
                                               Value = i.yayineviID.ToString()
                                           }).ToList();
            ViewBag.dgr = deger;           
            return View();
        }
        [HttpPost]
        public ActionResult KitapEkle(Kitaplar ktp)
        {
            var yev = db.Yayinevleri.Where(y => y.yayineviID==ktp.Yayinevleri.yayineviID).FirstOrDefault();
            ktp.Yayinevleri = yev;
            db.Kitaplar.Add(ktp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KitapSil(int id)
        {
            var kitap = db.Kitaplar.Find(id);
            db.Kitaplar.Remove(kitap);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KitapGetir(int id) 
        {
            var ktp = db.Kitaplar.Find(id);
            List<SelectListItem> deger = (from i in db.Yayinevleri.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.yayineviAdi,
                                              Value = i.yayineviID.ToString()
                                          }).ToList();
            ViewBag.dgr = deger;
            return View("KitapGetir", ktp);
        }
        public ActionResult KitapGuncelle(Kitaplar k)
        {
            var ktp = db.Kitaplar.Find(k.kitapID);
            ktp.Baslik = k.Baslik;
            ktp.Fiyat = k.Fiyat;
            ktp.ISBN = k.ISBN;
            var yev = db.Yayinevleri.Where(y => y.yayineviID == k.Yayinevleri.yayineviID).FirstOrDefault();
            ktp.Yayinevleri = yev;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}