using System;
using System.Globalization;

namespace hafta4odev2
{

    
    public class Urun
    {
        public string Ad { get; set; }
        public decimal Fiyat { get; set; }
        private decimal _indirim;

        // İndirim özelliği (0-50% sınırlandırılmış)
        public decimal Indirim
        {
            get { return _indirim; }
            set
            {
                if (value >= 0 && value <= 50)
                {
                    _indirim = value;
                }
                else
                {
                    Console.WriteLine("İndirim oranı 0 ile 50 arasında olmalıdır!");
                }
            }
        }

        // Yapıcı metot
        public Urun(string ad, decimal fiyat)
        {
            Ad = ad;
            Fiyat = fiyat;
            _indirim = 0; // Varsayılan indirim oranı 0%
        }

        // İndirimli fiyatı hesaplayan metot
        public decimal IndirimliFiyat()
        {
            return Fiyat * (1 - (_indirim / 100));
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Konsolun Unicode karakter desteğini etkinleştir
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Ürün oluşturma
            Urun urun = new Urun("Telefon", 15000);

            // Ürün bilgileri
            Console.WriteLine($"Ürün Adı: {urun.Ad}");
            Console.WriteLine($"Ürün Fiyatı: {urun.Fiyat:N} TL");

            // İndirim uygulama
            urun.Indirim = 25; // %25 indirim
            Console.WriteLine($"İndirim Oranı: {urun.Indirim}%");
            Console.WriteLine($"İndirimli Fiyat: {urun.IndirimliFiyat():N} TL");

            // Geçersiz indirim denemesi
            urun.Indirim = 60; // %60 indirim (hatalı)
            Console.WriteLine($"İndirim Oranı (hatalı deneme sonrası): {urun.Indirim}%");
            Console.WriteLine($"İndirimli Fiyat: {urun.IndirimliFiyat():N} TL");

            Console.ReadLine(); // Konsol açık kalsın
        }
    }
}
