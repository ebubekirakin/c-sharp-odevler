using System;

namespace AracKiralama
{
    public class KiralikArac
    {
        // Özellikler
        public string Plaka { get; private set; }
        public decimal GunlukUcret { get; private set; }
        public bool MusaitMi { get; private set; }

        // Yapıcı Metot
        public KiralikArac(string plaka, decimal gunlukUcret)
        {
            Plaka = plaka;
            GunlukUcret = gunlukUcret;
            MusaitMi = true; // Varsayılan olarak araç uygun
        }

        // Araç Kiralama Metodu
        public void AraciKirala()
        {
            if (MusaitMi)
            {
                MusaitMi = false;
                Console.WriteLine($"{Plaka} plakalı araç kiralandı.");
            }
            else
            {
                Console.WriteLine($"{Plaka} plakalı araç zaten kirada.");
            }
        }

        // Araç Teslim Etme Metodu
        public void AraciTeslimEt()
        {
            if (!MusaitMi)
            {
                MusaitMi = true;
                Console.WriteLine($"{Plaka} plakalı araç teslim alındı ve müsait.");
            }
            else
            {
                Console.WriteLine($"{Plaka} plakalı araç müsait.");
            }
        }

        // Araç Bilgisi Görüntüleme
        public void AracBilgisiGoster()
        {
            string durum = MusaitMi ? "Müsait" : "Kirada";
            Console.WriteLine($"Plaka: {Plaka}, Günlük Ücret: {GunlukUcret:N} TL, Durum: {durum}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Yeni araç oluşturma
            KiralikArac arac1 = new KiralikArac("34ABC123", 500);

            // Araç bilgisi görüntüleme
            arac1.AracBilgisiGoster();

            // Aracı kiralama
            arac1.AraciKirala();

            // Tekrar kiralama denemesi
            arac1.AraciKirala();

            // Aracı teslim etme
            arac1.AraciTeslimEt();

            // Tekrar teslim etme denemesi
            arac1.AraciTeslimEt();

            Console.ReadLine(); // Konsolun açık kalmasını sağlar
        }
    }
}
