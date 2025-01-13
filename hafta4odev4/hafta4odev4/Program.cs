using System;

namespace AdresDefteri
{
    public class Kisi
    {
        // Özellikler
        public string Ad { get; private set; }
        public string Soyad { get; private set; }
        public string TelefonNumarasi { get; private set; }

        // Yapıcı Metot
        public Kisi(string ad, string soyad, string telefonNumarasi)
        {
            Ad = ad;
            Soyad = soyad;
            TelefonNumarasi = telefonNumarasi;
        }

        // Metot: Kişi Bilgilerini Döndür
        public string KisiBilgisi()
        {
            return $"Ad Soyad: {Ad} {Soyad}, Telefon: {TelefonNumarasi}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Kişi oluşturma
            Kisi kisi1 = new Kisi("Ahmet", "Yılmaz", "05551234567");
            Kisi kisi2 = new Kisi("Ayşe", "Kara", "05449876543");

            // Kişi bilgilerini görüntüleme
            Console.WriteLine(kisi1.KisiBilgisi());
            Console.WriteLine(kisi2.KisiBilgisi());

            Console.ReadLine(); // Konsolun açık kalmasını sağlar
        }
    }
}
