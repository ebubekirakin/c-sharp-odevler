using System;

class MatrisCarpimi
{
    static void Main()
    {

        #region

        //Console.WriteLine("NxN boyutunda iki matrisin çarpımını gerçekleştiren programa hoş geldiniz.");

        //// Matris boyutunu kullanıcıdan al
        //Console.Write("Matrislerin boyutunu (N) giriniz: ");
        //int n = int.Parse(Console.ReadLine());

        //// İlk matrisin elemanlarını kullanıcıdan al
        //int[,] matris1 = new int[n, n];
        //Console.WriteLine("Birinci matrisin elemanlarını giriniz:");
        //for (int i = 0; i < n; i++)
        //{
        //    for (int j = 0; j < n; j++)
        //    {
        //        Console.Write($"matris1[{i},{j}] = ");
        //        matris1[i, j] = int.Parse(Console.ReadLine());
        //    }
        //}

        //// İkinci matrisin elemanlarını kullanıcıdan al
        //int[,] matris2 = new int[n, n];
        //Console.WriteLine("İkinci matrisin elemanlarını giriniz:");
        //for (int i = 0; i < n; i++)
        //{
        //    for (int j = 0; j < n; j++)
        //    {
        //        Console.Write($"matris2[{i},{j}] = ");
        //        matris2[i, j] = int.Parse(Console.ReadLine());
        //    }
        //}

        //// Matris çarpımını gerçekleştirme
        //int[,] carpimSonucu = new int[n, n];
        //for (int i = 0; i < n; i++)
        //{
        //    for (int j = 0; j < n; j++)
        //    {
        //        carpimSonucu[i, j] = 0; // Çarpım sonucunu sıfırla
        //        for (int k = 0; k < n; k++)
        //        {
        //            carpimSonucu[i, j] += matris1[i, k] * matris2[k, j];
        //        }
        //    }
        //}

        //// Sonucu ekrana yazdırma
        //Console.WriteLine("İki matrisin çarpım sonucu:");
        //for (int i = 0; i < n; i++)
        //{
        //    for (int j = 0; j < n; j++)
        //    {
        //        Console.Write(carpimSonucu[i, j] + "\t");
        //    }
        //    Console.WriteLine();

        //}

        #endregion


        int[] dizi = { 25, 78, 45, 12, 32, 98, 756, 3, 81 };

        int maxDeger = dizi[0];

        for (int i = 0; i < dizi.Length; i++)
        {

            if (dizi[i] > maxDeger)
            {

                maxDeger=dizi[i];   

            }
          
            

    }
        Console.WriteLine(maxDeger);

    }

}