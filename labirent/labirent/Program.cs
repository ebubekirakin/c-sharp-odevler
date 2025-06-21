using System;
using System.Collections.Generic;

class Labyrinth
{
    
    static int[] dx = { -1, 1, 0, 0 }; // Yukarı, Aşağı, Sol, Sağ
    static int[] dy = { 0, 0, -1, 1 };

    static void Main()
    {
        // Labirent tanımlama
        int[,] maze = {
            { 1, 0, 0, 0 },
            { 1, 1, 0, 1 },
            { 0, 1, 1, 1 },
            { 0, 0, 0, 1 }
        };

        int result = FindShortestPath(maze);
        if (result != -1)
        {
            Console.WriteLine($"En Kısa Yol: {result} adım");
        }
        else
        {
            Console.WriteLine("Yol Yok");
        }
    }

    static int FindShortestPath(int[,] maze)
    {
        int n = maze.GetLength(0);
        bool[,] visited = new bool[n, n]; // Ziyaret edilen hücreler
        int[,] distance = new int[n, n]; // Her hücreye ulaşmak için gereken adım sayısı
        Queue<(int, int)> queue = new Queue<(int, int)>();

        // Başlangıç noktasını ekle: (x, y)
        queue.Enqueue((0, 0));
        visited[0, 0] = true; // Başlangıç hücresini ziyaret edilmiş olarak işaretle
        distance[0, 0] = 0; // Başlangıç noktasındaki mesafe

        // BFS döngüsü
        while (queue.Count > 0)
        {
            var (x, y) = queue.Dequeue();

            // Hedef noktasına ulaşıldı mı?
            if (x == n - 1 && y == n - 1)
            {
                PrintMaze(maze, distance);
                return distance[n - 1, n - 1]; // Hedef hücreye ulaşmak için gereken adım sayısını döndür
            }

            // Komşu hücrelere git
            for (int i = 0; i < 4; i++)
            {
                int newX = x + dx[i];
                int newY = y + dy[i];

                // Grid sınırları içinde mi ve geçerli bir hücre mi?
                if (newX >= 0 && newX < n && newY >= 0 && newY < n && !visited[newX, newY] && maze[newX, newY] == 1)
                {
                    queue.Enqueue((newX, newY)); // Yeni hücreyi kuyrukta ekle
                    visited[newX, newY] = true; // Ziyaret et
                    distance[newX, newY] = distance[x, y] + 1; // Mesafeyi güncelle
                }
            }
        }

        return -1; // Hazineye ulaşılamıyorsa
    }

    static void PrintMaze(int[,] maze, int[,] distance)
    {
        Console.WriteLine("Labirent ve Adım Sayıları:");
        int n = maze.GetLength(0);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (maze[i, j] == 0)
                {
                    Console.Write("0 "); // Geçilemez hücre
                }
                else
                {
                    Console.Write($"{distance[i, j]} "); // Geçilebilir hücrelerde adım sayısını göster
                }
            }
            Console.WriteLine();
        }
    }
}
