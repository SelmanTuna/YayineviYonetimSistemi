using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using YayineviYonetimSistemi.Models;
using YayineviYonetimSistemi.Models.Entity;

namespace YayineviYonetimSistemi.Services
{
    public class YayineviExportService
    {
        //Db_YayineviYonetimiEntities db = new Db_YayineviYonetimiEntities();

        private string _filePath = "YayıneviExport.txt";

        public void YayineviVerileriniAktar()
        {
            using (var dbContext = new Db_YayineviYonetimiEntities())
            {
                var yayinevleri = dbContext.Yayinevleri.ToList();
                using (StreamWriter sw = new StreamWriter(_filePath))
                {
                    foreach(var yayinevi in yayinevleri)
                    {
                        sw.WriteLine($"{yayinevi.yayineviID},{yayinevi.yayineviAdi}");
                    }
                }
            }
        }
    }
}