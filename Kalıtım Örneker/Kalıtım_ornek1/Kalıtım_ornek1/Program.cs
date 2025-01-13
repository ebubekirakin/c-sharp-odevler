using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalıtım_ornek1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Çalışan türünü seçiniz (Yazilimci/Muhasebeci):");
            string calisanTuru = Console.ReadLine().ToLower();

            Calisan calisan = null;

            if (calisanTuru == "yazilimci")
            {
                calisan = new Yazilimci();
                Console.WriteLine("Yazılım dili bilgisi giriniz:");
                ((Yazilimci)calisan).YazilimDili = Console.ReadLine();
            }
            else if (calisanTuru == "muhasebeci")
            {
                calisan = new Muhasebeci();
                Console.WriteLine("Kullandığı muhasebe yazılımını giriniz:");
                ((Muhasebeci)calisan).MuhasebeYazilimi = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Geçersiz çalışan türü.");
                return;
            }

            // Ortak çalışan bilgilerini almak
            Console.WriteLine("Adınızı giriniz:");
            calisan.Ad = Console.ReadLine();
            Console.WriteLine("Soyadınızı giriniz:");
            calisan.Soyad = Console.ReadLine();
            Console.WriteLine("Maaşınızı giriniz:");
            calisan.Maas = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Pozisyonunuzu giriniz:");
            calisan.Pozisyon = Console.ReadLine();

            // BilgiYazdir metodunu çağırma
            calisan.BilgiYazdir();
            Console.WriteLine();
        }



        class Calisan
        {
            public string Ad { get; set; }
            public string Soyad { get; set; }
            public double Maas { get; set; }
            public string Pozisyon { get; set; }

            // BilgiYazdir metodunun temel hali
            public virtual void BilgiYazdir()
            {
                Console.WriteLine($"Ad: {Ad}");
                Console.WriteLine($"Soyad: {Soyad}");
                Console.WriteLine($"Maaş: {Maas} TL");
                Console.WriteLine($"Pozisyon: {Pozisyon}");
            }
        }

        // Yazilimci sınıfı, Calisan sınıfından türemektedir
        class Yazilimci : Calisan
        {
            public string YazilimDili { get; set; }

            // Yazilimci'ye özgü BilgiYazdir metodunun override edilmesi
            public override void BilgiYazdir()
            {
                base.BilgiYazdir();
                Console.WriteLine($"Yazılım Dili: {YazilimDili}");
            }
        }

        // Muhasebeci sınıfı, Calisan sınıfından türemektedir
        class Muhasebeci : Calisan
        {
            public string MuhasebeYazilimi { get; set; }
            // Muhasebeci'ye özgü BilgiYazdir metodunun override edilmesi
            public override void BilgiYazdir()
            {
                base.BilgiYazdir();
                Console.WriteLine($"Kullandığı Muhasebe Yazılımı: {MuhasebeYazilimi}");
            }
        }



    }
}
