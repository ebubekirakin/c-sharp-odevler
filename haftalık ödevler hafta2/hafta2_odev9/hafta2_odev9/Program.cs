using System;

class Program
{
    static void Main(string[] args)
    {
        int[,] enerjiMaliyeti = {
            { 1, 3, 5, 8 },
            { 4, 2, 1, 7 },
            { 1, 3, 4, 2 },
            { 6, 1, 2, 3 }
        };

        int n = enerjiMaliyeti.GetLength(0);
        int[,] dp = new int[n, n];

        // İlk hücreyi başlat
        dp[0, 0] = enerjiMaliyeti[0, 0];

        // İlk satır
        for (int j = 1; j < n; j++)
        {
            dp[0, j] = dp[0, j - 1] + enerjiMaliyeti[0, j];
        }

        // İlk sütun
        for (int i = 1; i < n; i++)
        {
            dp[i, 0] = dp[i - 1, 0] + enerjiMaliyeti[i, 0];
        }

        // Diğer hücreler için
        for (int i = 1; i < n; i++)
        {
            for (int j = 1; j < n; j++)
            {
                dp[i, j] = Math.Min(dp[i - 1, j], Math.Min(dp[i, j - 1], dp[i - 1, j - 1])) + enerjiMaliyeti[i, j];
            }
        }

        // Sonuç
        Console.WriteLine($"Minimum enerji maliyeti: {dp[n - 1, n - 1]}");
    }
}
