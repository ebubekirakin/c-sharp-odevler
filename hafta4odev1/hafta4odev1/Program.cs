using System;

namespace hafta4odev1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // `BankaHesabi` sınıfını kullanma
            BankaHesabi hesap = new BankaHesabi("12345678", 1000);
            hesap.BakiyeGoster();
            hesap.ParaYatir(500);
            hesap.ParaCek(200);
            hesap.BakiyeGoster();

            Console.ReadLine(); // Konsolun açık kalmasını sağlar
        }
    }

    public class BankaHesabi
    {
        // Özellikler
        public string HesapNumarasi { get; private set; }
        private decimal Bakiye { get; set; }

        // Yapıcı Metot
        public BankaHesabi(string hesapNumarasi, decimal baslangicBakiyesi)
        {
            HesapNumarasi = hesapNumarasi;
            Bakiye = baslangicBakiyesi >= 0 ? baslangicBakiyesi : 0; // Negatif bakiye kabul edilmez
        }

        // Para Yatırma Metodu
        public void ParaYatir(decimal miktar)
        {
            if (miktar > 0)
            {
                Bakiye += miktar;
                Console.WriteLine($"{miktar:N} TL yatırıldı. Güncel bakiye: {Bakiye:N} TL");
            }
            else
            {
                Console.WriteLine("Geçerli bir miktar girin.");
            }
        }

        // Para Çekme Metodu
        public void ParaCek(decimal miktar)
        {
            if (miktar > 0 && miktar <= Bakiye)
            {
                Bakiye -= miktar;
                Console.WriteLine($"{miktar:N} TL çekildi. Güncel bakiye: {Bakiye:N} TL");
            }
            else if (miktar > Bakiye)
            {
                Console.WriteLine("Yetersiz bakiye.");
            }
            else
            {
                Console.WriteLine("Geçerli bir miktar girin.");
            }
        }

        // Bakiye Görüntüleme
        public void BakiyeGoster()
        {
            Console.WriteLine($"Hesap Numarası: {HesapNumarasi}, Güncel Bakiye: {Bakiye:N} TL");
        }
    }
}