using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<string> gecerliTarihler = new List<string>();
        DateTime bugun = DateTime.Today;

        for (int yil = 2000; yil <= 3000; yil++)
        {
            if (!YilGecerliMi(yil)) continue;

            for (int ay = 1; ay <= 12; ay++)
            {
                if (!AyGecerliMi(ay)) continue;

                for (int gun = 1; gun <= DateTime.DaysInMonth(yil, ay); gun++)
                {
                    if (!GunAsalMi(gun)) continue;

                    DateTime tarih = new DateTime(yil, ay, gun);
                    if (tarih <= bugun) continue;

                    gecerliTarihler.Add(tarih.ToString("dd/MM/yyyy"));
                }
            }
        }

        Console.WriteLine("Geçerli tarihler:");
        foreach (var tarih in gecerliTarihler)
        {
            Console.WriteLine(tarih);
        }
    }

    static bool GunAsalMi(int gun)
    {
        if (gun < 2) return false;
        for (int i = 2; i * i <= gun; i++)
        {
            if (gun % i == 0) return false;
        }
        return true;
    }

    static bool AyGecerliMi(int ay)
    {
        int basamakToplami = ay / 10 + ay % 10;
        return basamakToplami % 2 == 0;
    }

    static bool YilGecerliMi(int yil)
    {
        int rakamToplami = 0;
        int geciciYil = yil;
        while (geciciYil > 0)
        {
            rakamToplami += geciciYil % 10;
            geciciYil /= 10;
        }

        return rakamToplami < (yil / 4);
    }
}