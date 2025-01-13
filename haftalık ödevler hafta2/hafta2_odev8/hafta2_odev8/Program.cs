using System;

class Program
{
    static void Main()
    {
        string orijinalMesaj = "Merhaba"; // Örnek orijinal mesaj
        string sifreliMesaj = Sifrele(orijinalMesaj);
        Console.WriteLine($"Şifreli Mesaj: {sifreliMesaj}");

        // Şifreli mesajı çöz
        string cozulmusMesaj = SifreCozer(sifreliMesaj);
        Console.WriteLine($"Orijinal Mesaj: {cozulmusMesaj}");
    }

    static string Sifrele(string mesaj)
    {
        string sifreliMesaj = "";

        for (int i = 0; i < mesaj.Length; i++)
        {
            char karakter = mesaj[i];
            int asciiDegeri = (int)karakter;

            int fibonacciSayisi = Fibonacci(i + 1);
            int modSonucu;

            if (IsPrime(i + 1)) // Pozisyon asal mı?
            {
                modSonucu = (asciiDegeri * fibonacciSayisi) % 100; // Asal pozisyonlar için 100'e mod
            }
            else
            {
                modSonucu = (asciiDegeri * fibonacciSayisi) % 256; // Asal olmayan pozisyonlar için 256'ya mod
            }

            // Yeni karakter oluştur
            sifreliMesaj += (char)modSonucu;
        }

        return sifreliMesaj;
    }

    static string SifreCozer(string sifreliMesaj)
    {
        string orijinalMesaj = "";

        for (int i = 0; i < sifreliMesaj.Length; i++)
        {
            char karakter = sifreliMesaj[i];
            int asciiDegeri = (int)karakter;

            int fibonacciSayisi = Fibonacci(i + 1);
            int orijinalAscii;

            if (IsPrime(i + 1)) // Pozisyon asal mı?
            {
                orijinalAscii = (asciiDegeri + 100) / fibonacciSayisi; // Asal pozisyonlar için
            }
            else
            {
                orijinalAscii = (asciiDegeri + 256) / fibonacciSayisi; // Asal olmayan pozisyonlar için
            }

            // ASCII değerini karaktere çevir
            orijinalMesaj += (char)orijinalAscii;
        }

        return orijinalMesaj;
    }

    static int Fibonacci(int n)
    {
        if (n <= 1) return n;
        return Fibonacci(n - 1) + Fibonacci(n - 2);
    }

    static bool IsPrime(int sayi)
    {
        if (sayi <= 1) return false;
        for (int i = 2; i <= Math.Sqrt(sayi); i++)
        {
            if (sayi % i == 0) return false;
        }
        return true;
    }
}
