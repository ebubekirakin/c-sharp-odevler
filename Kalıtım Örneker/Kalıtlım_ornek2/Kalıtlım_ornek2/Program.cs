using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalıtlım_ornek2
{
    class Program
    {
       

       
            static void Main(string[] args)
            {
                Console.WriteLine("Hayvan türünü seçiniz (Memeli/Kus):");
                string hayvanTuru = Console.ReadLine().ToLower();
                Hayvan hayvan = null;

                if (hayvanTuru == "memeli")
                {
                    hayvan = new Memeli();
                    Console.WriteLine("Memeli türünü giriniz:");
                    ((Memeli)hayvan).Tur = Console.ReadLine();
                    Console.WriteLine("Tüy rengini giriniz:");
                    ((Memeli)hayvan).TuyRengi = Console.ReadLine();
                }
                else if (hayvanTuru == "kus")
                {
                    hayvan = new Kus();
                    Console.WriteLine("Kuş türünü giriniz:");
                    ((Kus)hayvan).Tur = Console.ReadLine();
                    Console.WriteLine("Kanat genişliğini (cm) giriniz:");
                    ((Kus)hayvan).KanatGenisligi = Convert.ToDouble(Console.ReadLine());
                }
                else
                {
                    Console.WriteLine("Geçersiz hayvan türü.");
                    return;
                }

                // Ortak hayvan bilgilerini almak
                Console.WriteLine("Hayvanın adını giriniz:");
                hayvan.Ad = Console.ReadLine();
                Console.WriteLine("Hayvanın yaşını giriniz:");
                hayvan.Yas = Convert.ToInt32(Console.ReadLine());
                // Hayvan bilgilerini yazdırma
                Console.WriteLine($"\nHayvan Bilgileri:");
                Console.WriteLine($"Ad: {hayvan.Ad}");
                Console.WriteLine($"Tür: {hayvan.Tur}");
                Console.WriteLine($"Yaş: {hayvan.Yas} yıl");

                if (hayvan is Memeli memeli)
                {
                    Console.WriteLine($"Tüy Rengi: {memeli.TuyRengi}");
                }
                else if (hayvan is Kus kus)
                {
                    Console.WriteLine($"Kanat Genişliği: {kus.KanatGenisligi} cm");
                }

                // SesCikar metodunu çağırma
                hayvan.SesCikar();
                Console.WriteLine();
            }

        class Hayvan
        {
            public string Ad { get; set; }
            public string Tur { get; set; }
            public int Yas { get; set; }
            // SesCikar metodunun temel hali (boş)
            public virtual void SesCikar()
            {
                Console.WriteLine("Hayvan ses çıkarmıyor.");
            }
        }

        // Memeli sınıfı, Hayvan sınıfından türemektedir
        class Memeli : Hayvan
        {
            public string TuyRengi { get; set; }
            // Memeli'ye özgü SesCikar metodunun override edilmesi
            public override void SesCikar()
            {
                Console.WriteLine($"{Ad} memelisi: Grrrrr!");
            }
        }

        // Kus sınıfı, Hayvan sınıfından türemektedir
        class Kus : Hayvan
        {
            public double KanatGenisligi { get; set; }
            // Kus'a özgü SesCikar metodunun override edilmesi
            public override void SesCikar()
            {
                Console.WriteLine($"{Ad} kuşu: Cıv cıv!");
            }
        }



    }
}
