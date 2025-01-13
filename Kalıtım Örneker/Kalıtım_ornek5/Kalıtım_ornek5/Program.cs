using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalıtım_ornek5
{

    class Program
    {
        static void Main(string[] args)
        {
            // Urun türlerinde nesneler oluşturuluyor
            Kitap kitap1 = new Kitap("C# Programlamaya Giriş", 50m, "YMT LAB ÖDEVİ", "FÜ KİTAP");
            Elektronik elektronik1 = new Elektronik("Laptop", 2000m, "MONSTER", "ABRA");

            // Urun türünde bir dizi oluşturuluyor ve ürünler ekleniyor
            Urun[] urunler = new Urun[2];  // Dizi boyutu 2 olarak belirleniyor (kitap ve elektronik için)
            urunler[0] = kitap1; // Kitap nesnesini diziye ekliyoruz
            urunler[1] = elektronik1; // Elektronik nesnesini diziye ekliyoruz

            // Ürünler ve ödeme hesaplamaları ekrana yazdırılıyor
            foreach (var urun in urunler)
            {
                urun.BilgiYazdir(); // Ürün bilgilerini yazdır
                decimal odemeTutar = urun.HesaplaOdeme(); // Ödeme hesapla
                Console.WriteLine($"Ödenecek Tutar: {odemeTutar:C}\n");
            }
            Console.ReadLine();
            Console.WriteLine();
        }
    }


    public abstract class Urun
    {
        public string Ad { get; set; }
        public decimal Fiyat { get; set; }
        // Soyut hesapla ödeme metodu
        public abstract decimal HesaplaOdeme();
        // Ürün bilgilerini yazdıran metod
        public abstract void BilgiYazdir();
    }

    // Kitap sınıfı, Urun sınıfından türetiliyor
    public class Kitap : Urun
    {
        public string Yazar { get; set; }
        public string Yayinevi { get; set; }

        public Kitap(string ad, decimal fiyat, string yazar, string yayinevi)
        {
            Ad = ad;
            Fiyat = fiyat;
            Yazar = yazar;
            Yayinevi = yayinevi;
        }
        // Kitap sınıfında ödeme hesaplama: %10'luk bir vergi ekleniyor
        public override decimal HesaplaOdeme()
        {
            return Fiyat + (Fiyat * 0.10m); // %10 vergi
        }
        // Kitap bilgilerini yazdırma
        public override void BilgiYazdir()
        {
            Console.WriteLine($"Kitap Adı: {Ad}\nYazar: {Yazar}\nYayınevi: {Yayinevi}\nFiyat: {Fiyat:C}");
        }
    }

    // Elektronik sınıfı, Urun sınıfından türetiliyor
    public class Elektronik : Urun
    {
        public string Marka { get; set; }
        public string Model { get; set; }

        public Elektronik(string ad, decimal fiyat, string marka, string model)
        {
            Ad = ad;
            Fiyat = fiyat;
            Marka = marka;
            Model = model;
        }

        // Elektronik sınıfında ödeme hesaplama: %25'lik bir vergi ekleniyor
        public override decimal HesaplaOdeme()
        {
            return Fiyat + (Fiyat * 0.25m); // %25 vergi
        }

        // Elektronik ürün bilgilerini yazdırma
        public override void BilgiYazdir()
        {
            Console.WriteLine($"Elektronik Ürün Adı: {Ad}\nMarka: {Marka}\nModel: {Model}\nFiyat: {Fiyat:C}");
        }
    }

}
