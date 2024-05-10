using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject
{
    [TestClass]
    public class YazarTest 
    {
        private Yazar yazar;

        [TestInitialize]
        public void Init()
        {
            yazar = new Yazar();
        }
        [TestMethod]
        public void Yazar_Ad_Soyad_Set_Get()
        {
            //arrange
            string ad = "Dogan";
            string soyad = "Cüceloğlu";

            //act
            yazar.Ad = ad;
            yazar.Soyad = soyad;

            //Assert
            Assert.AreEqual(ad, yazar.Ad);
            Assert.AreEqual(soyad, yazar.Soyad);
        }
        [TestCleanup]
        public void Cleanup()
        {
            yazar = null;
        }
    }
    public class Yazar
    {
        public int YazarID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }       
        public int KitapID { get; set; }
        
    }

    [TestClass]
    public class KitapTest
    {
        private Kitap kitap;

        [TestInitialize]
        public void Init()
        {
            kitap = new Kitap();
        }
        [TestMethod]
        public void Kitap_Fiyat_Baslik_Set_Get()
        {
            //arrange
            string baslik = "Damga";
            decimal fiyat = 180;
            decimal ISBN = 978975108;

            //act
            kitap.Baslık = baslik; 
            kitap.Fiyat = fiyat;
            kitap.ISBN = ISBN;

            //Assert
            Assert.AreEqual(baslik, kitap.Baslık);
            Assert.AreEqual(fiyat, kitap.Fiyat);
            Assert.AreEqual(ISBN, kitap.ISBN);
        }
        [TestCleanup]
        public void Cleanup()
        {
            kitap = null;
        }
    }
    public class Kitap 
    {
        public string Baslık { get; set; }
        public decimal Fiyat { get; set; }
        public decimal ISBN { get; set; }
        public int YayineviID { get; set; }

    }
}
