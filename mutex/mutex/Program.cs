using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Threading;

class Program
{
    static List<int> sayilar = new List<int>();
    static List<int> ciftler = new List<int>();
    static List<int> tekler = new List<int>();
    static List<int> asallar = new List<int>();

    static Mutex mutex = new Mutex();

    static void Main()
    {
        for (int i = 1; i <= 1000000; i++)
        {
            sayilar.Add(i);
        }

        //liste 4 parçaya ayrıldı
        int parcaSayisi = sayilar.Count / 4;

        List<int>[] parcalar = new List<int>[4];

        for (int i = 0; i < 4; i++)
        {
            parcalar[i] = sayilar.GetRange(i * parcaSayisi, parcaSayisi);
        }

        // Her bir parça için ayrı bir Thread tasarla
        Thread[] threads = new Thread[4];

        for (int i = 0; i < 4; i++)
        {
            int threadIndex = i;
            threads[i] = new Thread(() => Kontrol(parcalar[threadIndex]));
        }

        // Thread'leri başlat
        foreach (var thread in threads)
        {
            thread.Start();
        }

        // Thread'lerin bitmesini bekle
        foreach (var thread in threads)
        {
            thread.Join();
        }

        Console.WriteLine("İşlem tamamlandı.");

        

        Console.WriteLine("\nÇift Sayılar: " + string.Join(", ", ciftler));
        Console.WriteLine("\nTek Sayılar: " + string.Join(", ", tekler));
        Console.WriteLine("\nAsal Sayılar: " + string.Join(", ", asallar));

    }

    static void Kontrol(List<int> parca)
    {
        Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} basladi.");

        foreach (var number in parca)
        {
            if (CiftMi(number))
            {
                mutex.WaitOne();
                ciftler.Add(number);
                mutex.ReleaseMutex();
            }
            else
            {
                mutex.WaitOne();
                tekler.Add(number);
                mutex.ReleaseMutex();
            }

            if (AsalMi(number))
            {
                mutex.WaitOne();
                asallar.Add(number);
                mutex.ReleaseMutex();
            }
        }

        Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} bitti.");
    }

    static bool CiftMi(int number)
    {
        return number % 2 == 0;
    }

    static bool AsalMi(int number)
    {
        if (number < 2)
            return false;

        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
                return false;
        }

        return true;
    }
}