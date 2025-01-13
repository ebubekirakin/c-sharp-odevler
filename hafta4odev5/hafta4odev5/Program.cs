using System;
using System.Collections.Generic;

namespace KutuphaneYonetimi
{
    // Kitap Sınıfı
    public class Kitap
    {
        public string Ad { get; private set; }
        public string Yazar { get; private set; }

        public Kitap(string ad, string yazar)
        {
            Ad = ad;
            Yazar = yazar;
        }

        public string KitapBilgisi()
        {
            return $"Kitap: {Ad}, Yazar: {Yazar}";
        }
    }

    // Kütüphane Sınıfı
    public class Kutuphane
    {
        // Özellik
        public List<Kitap> Kitaplar { get; private set; }

        // Yapıcı Metot
        public Kutuphane()
        {
            Kitaplar = new List<Kitap>();
        }

        // Kitap Ekleme Metodu
        public void KitapEkle(Kitap yeniKitap)
        {
            Kitaplar.Add(yeniKitap);
            Console.WriteLine($"'{yeniKitap.Ad}' kitabı bu kütüphaneye eklendi.");
        }

        // Kitapları Listeleme Metodu
        public void KitaplariListele()
        {
            Console.WriteLine("\nKütüphanedeki Kitaplar:");
            foreach (var kitap in Kitaplar)
            {
                Console.WriteLine(kitap.KitapBilgisi());
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Kütüphane oluşturma
            Kutuphane kutuphane = new Kutuphane();

            // Kitap ekleme
            Kitap kitap1 = new Kitap("Sefiller", "Victor Hugo");
            Kitap kitap2 = new Kitap("Suç ve Ceza", "Fyodor Dostoyevski");

            kutuphane.KitapEkle(kitap1);
            kutuphane.KitapEkle(kitap2);

            // Kitapları listeleme
            kutuphane.KitaplariListele();

            Console.ReadLine(); // Konsolun açık kalmasını sağlar
        }
    }
}
