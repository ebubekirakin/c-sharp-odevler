using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kalıtım_ornek4
{


    class Program
    {
        static void Main(string[] args)
        {
            // Birikim Hesabı oluşturuluyor
            IBankaHesabi birikimHesabi = new BirikimHesabiWithInterface("12345", 5m, new DateTime(2023, 5, 1));
            birikimHesabi.HesapOzeti();
            // Para yatırma ve faiz ekleme işlemi
            ((BirikimHesabiWithInterface)birikimHesabi).ParaYatir(1000);
            birikimHesabi.HesapOzeti();

            // Vadesiz Hesap oluşturuluyor
            IBankaHesabi vadesizHesap = new VadesizHesapWithInterface("67890", 10m, new DateTime(2024, 1, 1));
            vadesizHesap.HesapOzeti();
            // Para yatırma işlemi
            ((VadesizHesapWithInterface)vadesizHesap).ParaYatir(500);
            vadesizHesap.HesapOzeti();
            // Para çekme işlemi
            ((VadesizHesapWithInterface)vadesizHesap).ParaCek(200);
            vadesizHesap.HesapOzeti();

            Console.ReadLine();
            Console.WriteLine();
        }
    }



    // Soyut Hesap sınıfı
    public abstract class Hesap
    {
        public string HesapNo { get; set; }
        public decimal Bakiye { get; protected set; }
        // Para yatırma metodu (Soyut olarak tanımlanmış, her türetilen sınıf kendine özgü implementasyon yapmalı)
        public abstract void ParaYatir(decimal miktar);
        // Para çekme metodu (Soyut olarak tanımlanmış, her türetilen sınıf kendine özgü implementasyon yapmalı)
        public abstract void ParaCek(decimal miktar);
    }

    // BirikimHesabi sınıfı, Hesap sınıfından türetiliyor
    public class BirikimHesabi : Hesap
    {
        public decimal FaizOrani { get; set; }
        public BirikimHesabi(string hesapNo, decimal faizOrani)
        {
            HesapNo = hesapNo;
            FaizOrani = faizOrani;
            Bakiye = 0; // Başlangıçta bakiye sıfır
        }

        // Para yatırma metodu: Faiz oranını da hesaba katıyor
        public override void ParaYatir(decimal miktar)
        {
            Bakiye += miktar;
            Bakiye += Bakiye * FaizOrani / 100; // Faiz ekleniyor
        }

        // Para çekme metodu: Basit şekilde bakiye kadar çekim yapılabilir
        public override void ParaCek(decimal miktar)
        {
            if (Bakiye >= miktar)
            {
                Bakiye -= miktar;
            }
            else
            {
                Console.WriteLine("Yetersiz bakiye!");
            }
        }
    }

    // VadesizHesap sınıfı, Hesap sınıfından türetiliyor
    public class VadesizHesap : Hesap
    {
        public decimal IslemUcreti { get; set; }

        public VadesizHesap(string hesapNo, decimal islemUcreti)
        {
            HesapNo = hesapNo;
            IslemUcreti = islemUcreti;
            Bakiye = 0; // Başlangıçta bakiye sıfır
        }

        // Para yatırma metodu: Yatırılan miktar bakiyeye eklenir
        public override void ParaYatir(decimal miktar)
        {
            Bakiye += miktar;
        }

        // Para çekme metodu: İşlem ücreti eklenir
        public override void ParaCek(decimal miktar)
        {
            decimal toplamMiktar = miktar + IslemUcreti; // İşlem ücreti ile birlikte
            if (Bakiye >= toplamMiktar)
            {
                Bakiye -= toplamMiktar;
            }
            else
            {
                Console.WriteLine("Yetersiz bakiye!");
            }
        }
    }

    // IBankaHesabi arayüzü
    public interface IBankaHesabi
    {
        DateTime HesapAcilisTarihi { get; set; }
        void HesapOzeti();
    }

    // BirikimHesabi sınıfı IBankaHesabi'yi implement ediyor
    public class BirikimHesabiWithInterface : BirikimHesabi, IBankaHesabi
    {
        public DateTime HesapAcilisTarihi { get; set; }

        public BirikimHesabiWithInterface(string hesapNo, decimal faizOrani, DateTime hesapAcilisTarihi)
            : base(hesapNo, faizOrani)
        {
            HesapAcilisTarihi = hesapAcilisTarihi;
        }

        public void HesapOzeti()
        {
            Console.WriteLine($"Hesap No: {HesapNo}, Bakiye: {Bakiye:C}, Faiz Oranı: {FaizOrani}%, Hesap Açılış Tarihi: {HesapAcilisTarihi.ToShortDateString()}");
        }
    }

    // VadesizHesap sınıfı IBankaHesabi'yi implement ediyor
    public class VadesizHesapWithInterface : VadesizHesap, IBankaHesabi
    {
        public DateTime HesapAcilisTarihi { get; set; }

        public VadesizHesapWithInterface(string hesapNo, decimal islemUcreti, DateTime hesapAcilisTarihi)
            : base(hesapNo, islemUcreti)
        {
            HesapAcilisTarihi = hesapAcilisTarihi;
        }

        public void HesapOzeti()
        {
            Console.WriteLine($"Hesap No: {HesapNo}, Bakiye: {Bakiye:C}, İşlem Ücreti: {IslemUcreti:C}, Hesap Açılış Tarihi: {HesapAcilisTarihi.ToShortDateString()}");
        }
    }
























}
