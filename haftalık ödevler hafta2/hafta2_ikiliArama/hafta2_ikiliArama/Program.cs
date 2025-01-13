using System;

class Program
{
    static void Main()
    {
        // Kullanıcıdan dizi elemanlarını al
        Console.Write("Kaç adet sayı gireceksiniz?: ");
        int n = int.Parse(Console.ReadLine());

        int[] numbers = new int[n];
        Console.WriteLine("Dizi elemanlarını giriniz:");

        for (int i = 0; i < n; i++)
        {
            Console.Write("Sayı {0}: ", i + 1);
            numbers[i] = int.Parse(Console.ReadLine());
        }

        // Diziyi sırala
        Array.Sort(numbers);
        Console.WriteLine("Sıralanmış Dizi: " + string.Join(", ", numbers));

        // Kullanıcıdan aramak istediği sayıyı al
        Console.Write("Aramak istediğiniz sayıyı girin: ");
        int target = int.Parse(Console.ReadLine());

        // İkili arama ile sayıyı bulma
        bool found = BinarySearch(numbers, target);

        if (found)
            Console.WriteLine("Sayı dizide bulundu.");
        else
            Console.WriteLine("Sayı dizide bulunamadı.");
    }

    // İkili arama algoritması
    static bool BinarySearch(int[] array, int target)
    {
        int left = 0;
        int right = array.Length - 1;

        while (left <= right)
        {
            int mid = (left + right) / 2;

            if (array[mid] == target)
                return true;
            else if (array[mid] < target)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return false;
    }
}