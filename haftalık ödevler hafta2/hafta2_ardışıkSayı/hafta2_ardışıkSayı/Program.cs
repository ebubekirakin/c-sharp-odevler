using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int>();
        int input;

        Console.WriteLine("Pozitif tam sayılar girin (Durdurmak için 0 girin):");

        // Kullanıcıdan sayıları al
        do
        {
            Console.Write("Sayı: ");
            input = int.Parse(Console.ReadLine());

            if (input > 0)
            {
                numbers.Add(input);
            }

        } while (input != 0);

        // Eğer sayı girilmediyse işlemi durdur
        if (numbers.Count == 0)
        {
            Console.WriteLine("Hiç sayı girilmedi.");
            return;
        }

        // Diziyi sırala
        numbers.Sort();

        // Ardışık sayı gruplarını bul ve ekrana yazdır
        Console.WriteLine("Ardışık sayı grupları:");
        FindConsecutiveGroups(numbers);
    }

    // Ardışık sayı gruplarını bulan fonksiyon
    static void FindConsecutiveGroups(List<int> numbers)
    {
        int start = numbers[0];
        int end = start;

        for (int i = 1; i < numbers.Count; i++)
        {
            if (numbers[i] == end + 1)
            {
                // Ardışık sayılar devam ediyor
                end = numbers[i];
            }
            else
            {
                // Ardışık grup sona erdi, grubu yazdır
                PrintGroup(start, end);
                // Yeni grup başlat
                start = numbers[i];
                end = start;
            }
        }

        // Son grubu yazdır
        PrintGroup(start, end);
    }

    // Grup yazdırma fonksiyonu
    static void PrintGroup(int start, int end)
    {
        if (start == end)
        {
            Console.WriteLine(start);
        }
        else
        {
            Console.WriteLine($"{start}-{end}");
        }
    }
}