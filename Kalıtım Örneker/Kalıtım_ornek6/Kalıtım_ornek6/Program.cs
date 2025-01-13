using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalıtım_ornek6
{

    class Program
    {
        static void Main(string[] args)
        {
            // Yayıncıyı oluşturuyoruz
            Yayinci yayinci = new Yayinci();

            // Aboneleri oluşturuyoruz
            Abone abone1 = new Abone("Bekir");
            Abone abone2 = new Abone("Kerem");
            Abone abone3 = new Abone("Sefa");

            // Aboneleri yayına ekliyoruz
            yayinci.AboneEkle(abone1);
            yayinci.AboneEkle(abone2);
            yayinci.AboneEkle(abone3);

            // Yayıncı mesaj gönderiyor
            yayinci.MesajYaz("Yeni ürünler mağazaya geldi! Büyük indirim fırsatını kaçırmayın!");

            // Abonelerden birini çıkaralım
            yayinci.AboneCikar(abone2);

            // Yayıncı başka bir mesaj gönderiyor
            yayinci.MesajYaz("Yeni kampanya başlatıldı! Sadece bu hafta geçerli!");

            Console.ReadLine();
            Console.WriteLine();
        }  
    }





    // IYayinci arayüzü
    public interface IYayinci
    {
        void AboneEkle(IAbone abone);
        void AboneCikar(IAbone abone);
        void AbonelereBildirimGonder();
    }

    // IAbone arayüzü
    public interface IAbone
    {
        void BilgiAl(string mesaj);
    }

    // Yayinci sınıfı, IYayinci arayüzünü implement eder
    public class Yayinci : IYayinci
    {
        private List<IAbone> aboneler = new List<IAbone>();
        private string mesaj;

        // Abone ekleme
        public void AboneEkle(IAbone abone)
        {
            aboneler.Add(abone);
        }

        // Abone çıkarma
        public void AboneCikar(IAbone abone)
        {
            aboneler.Remove(abone);
        }

        // Tüm abonelere bildirim gönderme
        public void AbonelereBildirimGonder()
        {
            foreach (var abone in aboneler)
            {
                abone.BilgiAl(mesaj); // Her aboneye mesaj gönderilir
            }
        }

        // Yayıncı mesajı ayarlama
        public void MesajYaz(string mesaj)
        {
            this.mesaj = mesaj;
            AbonelereBildirimGonder(); // Yeni mesaj gönderildikten sonra bildirim yapılır
        }
    }

    // Abone sınıfı, IAbone arayüzünü implement eder
    public class Abone : IAbone
    {
        public string Ad { get; set; }

        public Abone(string ad)
        {
            Ad = ad;
        }

        // Abonenin aldığı mesajı ekrana yazdırma
        public void BilgiAl(string mesaj)
        {
            Console.WriteLine($"{Ad} abonesi yeni bir mesaj aldı: {mesaj}");
        }
    }


}
