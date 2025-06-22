using System;

class SpiralMatrix
{
    
    static void Main()
    {
        Console.Write("Matrisin boyutunu girin (N): ");
        int n = int.Parse(Console.ReadLine());
        int[,] matris = new int[n, n];

        int value = 1;
        int minRow = 0, maxRow = n - 1;
        int minCol = 0, maxCol = n - 1;

        while (value <= n * n)
        {
            // Üst sırayı doldur
            for (int i = minCol; i <= maxCol; i++)
            {
                matris[minRow, i] = value++;
            }
            minRow++;

            // Sağ sütunu doldur
            for (int i = minRow; i <= maxRow; i++)
            {
                matris[i, maxCol] = value++;
            }
            maxCol--;

            // Alt sırayı doldur
            for (int i = maxCol; i >= minCol; i--)
            {
                matris[maxRow, i] = value++;
            }
            maxRow--;

            // Sol sütunu doldur
            for (int i = maxRow; i >= minRow; i--)
            {
                matris[i, minCol] = value++;
            }
            minCol++;
        }

        // Matrisi yazdır
        Console.WriteLine("Spiral Matris:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(matris[i, j].ToString().PadLeft(4) + " ");
            }
            Console.WriteLine();
        }
    }
}
