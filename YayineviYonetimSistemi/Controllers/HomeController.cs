using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YayineviYonetimSistemi.Services;

namespace YayineviYonetimSistemi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private readonly YayineviExportService _yayineviExportService;
        public HomeController(YayineviExportService yayineviExportService)
        {
            _yayineviExportService = yayineviExportService;
        }
        public ActionResult Export()
        {
            _yayineviExportService.YayineviVerileriniAktar();
            return RedirectToAction("Index", "Home");
        }
    }
}