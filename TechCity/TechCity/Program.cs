using System;
using System.Collections.Generic;

class TechCity
{
    // Yönler: Yukarı, Aşağı, Sol, Sağ
    static int[] dx = { -1, 1, 0, 0 };
    static int[] dy = { 0, 0, -1, 1 };

    
    static void Main()
    {

        // Grid tanımlama
        int[,] grid = {
            { 1, 1, 0, 1 },
            { 0, 1, 0, 0 },
            { 1, 1, 1, 0 },
            { 0, 0, 1, 1 }
        };

        // Robotların başlangıç pozisyonları
        List<(int, int)> robotPositions = new List<(int, int)> {
            (0, 0), // Robot 1
            (2, 2), // Robot 2
            (3, 3)  // Robot 3
        };

        // Grid boyutları
        int n = grid.GetLength(0);
        bool[,] visited = new bool[n, n]; // Ziyaret edilen düğümler
        int totalRescuedNodes = 0; // Toplam kurtarılan düğüm sayısı

        // Her robot için BFS ile düğümleri ziyaret et
        foreach (var robot in robotPositions)
        {
            int rescuedNodes = Bfs(grid, visited, robot.Item1, robot.Item2, n);
            Console.WriteLine($"Robot ({robot.Item1}, {robot.Item2}) {rescuedNodes} düğüm kurtardı.");
            totalRescuedNodes += rescuedNodes;
        }

        Console.WriteLine($"Toplam kurtarılan düğüm sayısı: {totalRescuedNodes}");
    }

    // BFS ile bir robotun kaç düğüm kurtarabileceğini hesaplar
    static int Bfs(int[,] grid, bool[,] visited, int startX, int startY, int n)
    {
        if (grid[startX, startY] == 0 || visited[startX, startY])
            return 0; // Zarar görmüş düğüm veya daha önce ziyaret edilmişse

        int rescuedNodes = 0; // Kurtarılan düğüm sayısı
        Queue<(int, int)> queue = new Queue<(int, int)>();
        queue.Enqueue((startX, startY));
        visited[startX, startY] = true; // Başlangıç düğümünü ziyaret edilmiş olarak işaretle
        rescuedNodes++;

        // BFS döngüsü
        while (queue.Count > 0)
        {
            var (x, y) = queue.Dequeue();

            // Komşu düğümlere git
            for (int i = 0; i < 4; i++)
            {
                int newX = x + dx[i];
                int newY = y + dy[i];

                // Grid sınırları içinde mi ve düğüm daha önce ziyaret edilmemiş mi?
                if (newX >= 0 && newX < n && newY >= 0 && newY < n && !visited[newX, newY] && grid[newX, newY] == 1)
                {
                    queue.Enqueue((newX, newY));
                    visited[newX, newY] = true;
                    rescuedNodes++;
                }
            }
        }

        return rescuedNodes;
    }

} 
