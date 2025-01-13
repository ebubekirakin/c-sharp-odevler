using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalıtım_ornek3
{
    class Program
    {
            static void Main(string[] args)
            {
                Console.WriteLine("Hesap türünü seçiniz (VadesizHesap/VadeliHesap):");
                string hesapTuru = Console.ReadLine().ToLower();

                Hesap hesap = null;

                // Hesap türüne göre nesne oluşturma
                if (hesapTuru == "vadesizhesap")
                {
                    hesap = new VadesizHesap();
                    Console.WriteLine("Ek hesap limiti giriniz:");
                    ((VadesizHesap)hesap).EkHesapLimiti = Convert.ToDouble(Console.ReadLine());
                }
                else if (hesapTuru == "vadelihesap")
                {
                    hesap = new VadeliHesap();
                    Console.WriteLine("Vade süresi (gün) giriniz:");
                    ((VadeliHesap)hesap).VadeSuresi = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Faiz oranını giriniz (%):");
                    ((VadeliHesap)hesap).FaizOrani = Convert.ToDouble(Console.ReadLine());
                }
                else
                {
                    Console.WriteLine("Geçersiz hesap türü.");
                    return;
                }

                // Hesap bilgilerini almak
                Console.WriteLine("Hesap sahibinin adını giriniz:");
                hesap.HesapSahibi = Console.ReadLine();
                Console.WriteLine("Hesap numarasını giriniz:");
                hesap.HesapNumarasi = Console.ReadLine();
                Console.WriteLine("Başlangıç bakiyesini giriniz:");
                hesap.Bakiye = Convert.ToDouble(Console.ReadLine());

                // Hesap bilgilerini yazdırma
                hesap.BilgiYazdir();
                Console.WriteLine();

                // İşlemler
                bool devam = true;
                while (devam)
                {
                    Console.WriteLine("\nİşlem Seçiniz: \n1. Para Yatır \n2. Para Çek \n3. Çıkış");
                    int islem = Convert.ToInt32(Console.ReadLine());

                    switch (islem)
                    {
                        case 1:
                            Console.WriteLine("Yatırmak istediğiniz miktarı giriniz:");
                            double yatirilanMiktar = Convert.ToDouble(Console.ReadLine());
                            hesap.ParaYatir(yatirilanMiktar);
                            break;

                        case 2:
                            Console.WriteLine("Çekmek istediğiniz miktarı giriniz:");
                            double cekilenMiktar = Convert.ToDouble(Console.ReadLine());
                            hesap.ParaCek(cekilenMiktar);
                            break;

                        case 3:
                            devam = false;
                            break;

                        default:
                            Console.WriteLine("Geçersiz işlem.");
                            break;
                    }
                }
            }


        class Hesap
        {
            public string HesapNumarasi { get; set; }
            public double Bakiye { get; set; }
            public string HesapSahibi { get; set; }

            // Hesap bilgilerini yazdırma metodu
            public virtual void BilgiYazdir()
            {
                Console.WriteLine($"Hesap Sahibi: {HesapSahibi}");
                Console.WriteLine($"Hesap Numarası: {HesapNumarasi}");
                Console.WriteLine($"Bakiye: {Bakiye} TL");
            }

            // Para yatırma metodu
            public virtual void ParaYatir(double miktar)
            {
                Bakiye += miktar;
                Console.WriteLine($"{miktar} TL para yatırıldı. Yeni bakiye: {Bakiye} TL");
            }

            // Para çekme metodu (genel olarak)
            public virtual void ParaCek(double miktar)
            {
                if (Bakiye >= miktar)
                {
                    Bakiye -= miktar;
                    Console.WriteLine($"{miktar} TL para çekildi. Yeni bakiye: {Bakiye} TL");
                }
                else
                {
                    Console.WriteLine("Yetersiz bakiye!");
                }
            }
        }

        // VadesizHesap sınıfı, Hesap sınıfından türemektedir
        class VadesizHesap : Hesap
        {
            public double EkHesapLimiti { get; set; }

            // Vadesiz hesap için para yatırma metodu
            public override void ParaYatir(double miktar)
            {
                Bakiye += miktar;
                Console.WriteLine($"{miktar} TL para vadesiz hesaba yatırıldı. Yeni bakiye: {Bakiye} TL");
            }

            // Vadesiz hesap için para çekme metodu
            public override void ParaCek(double miktar)
            {
                if (Bakiye + EkHesapLimiti >= miktar)
                {
                    Bakiye -= miktar;
                    Console.WriteLine($"{miktar} TL para vadesiz hesaptan çekildi. Yeni bakiye: {Bakiye} TL");
                }
                else
                {
                    Console.WriteLine("Yetersiz bakiye veya ek hesap limiti!");
                }
            }
        }

        // VadeliHesap sınıfı, Hesap sınıfından türemektedir
        class VadeliHesap : Hesap
        {
            public int VadeSuresi { get; set; } // Vade süresi (gün cinsinden)
            public double FaizOrani { get; set; } // Faiz oranı (yüzde)

            // Vadeli hesap için para yatırma metodu
            public override void ParaYatir(double miktar)
            {
                Bakiye += miktar;
                Console.WriteLine($"{miktar} TL para vadeli hesaba yatırıldı. Yeni bakiye: {Bakiye} TL");
            }

            // Vadeli hesap için para çekme metodu
            public override void ParaCek(double miktar)
            {
                if (VadeSuresi > 0)
                {
                    Console.WriteLine("Vade süresi dolmadan para çekemezsiniz.");
                }
                else
                {
                    if (Bakiye >= miktar)
                    {
                        Bakiye -= miktar;
                        Console.WriteLine($"{miktar} TL para vadeli hesaptan çekildi. Yeni bakiye: {Bakiye} TL");
                    }
                    else
                    {
                        Console.WriteLine("Yetersiz bakiye!");
                    }
                }
            }
        }




    }
}
