using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int M = 5; // Labirent satır sayısı (Örneğin)
        int N = 5; // Labirent sütun sayısı (Örneğin)

        if (LabirentCoz(M, N))
            Console.WriteLine("Hedefe ulaşan bir yol bulundu.");
        else
            Console.WriteLine("Şehir kayboldu!");
    }

    static bool LabirentCoz(int M, int N)
    {
        Queue<(int, int, List<(int, int)>)> kuyruk = new Queue<(int, int, List<(int, int)>)>();
        bool[,] ziyaretEdildi = new bool[M, N];

        kuyruk.Enqueue((0, 0, new List<(int, int)>() { (0, 0) }));
        ziyaretEdildi[0, 0] = true;

        int[] dx = { 1, -1, 0, 0 };
        int[] dy = { 0, 0, 1, -1 };

        while (kuyruk.Count > 0)
        {
            var (x, y, yol) = kuyruk.Dequeue();

            if (x == M - 1 && y == N - 1)
            {
                Console.WriteLine("Şehre ulaşan yol:");
                foreach (var adim in yol)
                    Console.Write($"({adim.Item1}, {adim.Item2}) ");
                Console.WriteLine();
                return true;
            }

            for (int i = 0; i < 4; i++)
            {
                int yeniX = x + dx[i];
                int yeniY = y + dy[i];

                if (yeniX >= 0 && yeniX < M && yeniY >= 0 && yeniY < N && !ziyaretEdildi[yeniX, yeniY])
                {
                    if (KapıAcilabilirMi(yeniX, yeniY))
                    {
                        ziyaretEdildi[yeniX, yeniY] = true;
                        var yeniYol = new List<(int, int)>(yol) { (yeniX, yeniY) };
                        kuyruk.Enqueue((yeniX, yeniY, yeniYol));
                    }
                }
            }
        }
        return false;
    }

    static bool KapıAcilabilirMi(int x, int y)
    {
        return AsalBasamaklarMi(x) && AsalBasamaklarMi(y) && GecisIzniVarMi(x, y);
    }

    static bool AsalBasamaklarMi(int sayi)
    {
        int[] asalBasamaklar = { 2, 3, 5, 7 };
        while (sayi > 0)
        {
            int basamak = sayi % 10;
            if (Array.IndexOf(asalBasamaklar, basamak) == -1)
                return false;
            sayi /= 10;
        }
        return true;
    }

    static bool GecisIzniVarMi(int x, int y)
    {
        int toplam = x + y;
        int carpim = x * y;
        return carpim != 0 && toplam % carpim == 0;
    }
}