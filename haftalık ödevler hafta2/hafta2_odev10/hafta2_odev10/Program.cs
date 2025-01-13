using System;
using System.Collections.Generic;
using System.Data;

class Program
{
    static void Main(string[] args)
    {
        int[] sayilar = { 5, 2, 3 }; // Sayı dizisi
        char[] operatorler = { '+', '-', '*', '/' }; // Operatörler
        List<string> gecerliIfadeler = new List<string>(); // Geçerli ifadeleri saklamak için liste

        GeriIzleme(sayilar, operatorler, "", 0, gecerliIfadeler, new HashSet<int>(), true); // Geri izleme başlat

        Console.WriteLine("Geçerli İfadeler:");
        foreach (var ifade in gecerliIfadeler)
        {
            Console.WriteLine(ifade); // Geçerli ifadeleri yazdır
        }
    }

    // Geri izleme algoritması
    static void GeriIzleme(int[] sayilar, char[] operatorler, string ifade, int sayiIndex, List<string> gecerliIfadeler, HashSet<int> kullanilanIndexler, bool sonEklenenSayi)
    {
        // Tüm sayılar kullanıldıysa ve ifade geçerliyse listeye ekle
        if (kullanilanIndexler.Count == sayilar.Length)
        {
            if (IsValidExpression(ifade))
            {
                gecerliIfadeler.Add(ifade);
            }
            return;
        }

        for (int i = 0; i < sayilar.Length; i++)
        {
            if (kullanilanIndexler.Contains(i))
            {
                continue; // Kullanılmışsa atla
            }

            kullanilanIndexler.Add(i); // Sayıyı kullan
            if (sonEklenenSayi)
            {
                // Eğer son eklenen bir sayıysa operatör ekle
                foreach (var op in operatorler)
                {
                    GeriIzleme(sayilar, operatorler, ifade + sayilar[i] + op, i, gecerliIfadeler, kullanilanIndexler, false);
                }
            }
            else
            {
                // Son eklenen bir operatörse sayıyı ekle
                GeriIzleme(sayilar, operatorler, ifade + sayilar[i], i, gecerliIfadeler, kullanilanIndexler, true);
            }

            kullanilanIndexler.Remove(i); // Kullanılmış sayıyı çıkar
        }
    }

    // İfadenin geçerliliğini kontrol et
    static bool IsValidExpression(string ifade)
    {
        try
        {
            var sonuc = new DataTable().Compute(ifade.TrimEnd('+', '-', '*', '/'), null); // İfadeyi hesapla
            return Convert.ToDouble(sonuc) > 0; // Sonucun sıfırdan büyük olup olmadığını kontrol et
        }
        catch
        {
            return false; // Hata durumunda geçersiz olarak döndür
        }
    }
}