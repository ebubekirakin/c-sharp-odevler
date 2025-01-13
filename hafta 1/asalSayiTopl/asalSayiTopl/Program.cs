using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("N'e kadar olan asal sayıların toplamını bulma programına hoş geldiniz.");

        // Kullanıcıdan N değerini al
        Console.Write("Lütfen N sayısını giriniz: ");
        int N = int.Parse(Console.ReadLine());

        int toplam = 0;

        // 2'den N'e kadar olan asal sayıları bul ve topla
        for (int i = 2; i <= N; i++)
        {
            if (AsalMi(i))
            {
                toplam += i;
            }
        }

        // Toplam sonucu ekrana yazdır
        Console.WriteLine($"N'e kadar olan asal sayıların toplamı: {toplam}");
    }

    // Bir sayının asal olup olmadığını kontrol eden fonksiyon
    static bool AsalMi(int sayi)
    {
        if (sayi < 2)
            return false;

        for (int i = 2; i <= Math.Sqrt(sayi); i++)
        {
            if (sayi % i == 0)
                return false;
        }

        return true;
    }
}