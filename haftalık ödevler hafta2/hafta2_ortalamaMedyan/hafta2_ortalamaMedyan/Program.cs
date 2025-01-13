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

        // Ortalama hesapla
        double average = CalculateAverage(numbers);
        Console.WriteLine("Ortalama: " + average);

        // Medyan hesapla
        double median = CalculateMedian(numbers);
        Console.WriteLine("Medyan: " + median);
    }

    // Ortalama hesaplama fonksiyonu
    static double CalculateAverage(List<int> numbers)
    {
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        return (double)sum / numbers.Count;
    }

    // Medyan hesaplama fonksiyonu
    static double CalculateMedian(List<int> numbers)
    {
        numbers.Sort();
        int count = numbers.Count;

        if (count % 2 == 1)
        {
            // Tek sayıda eleman varsa ortadaki eleman medyan
            return numbers[count / 2];
        }
        else
        {
            // Çift sayıda eleman varsa ortadaki iki elemanın ortalaması medyan
            int mid1 = numbers[(count / 2) - 1];
            int mid2 = numbers[count / 2];
            return (mid1 + mid2) / 2.0;
        }
    }
}
