using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _211229001_Şeyda_Açıkgöz
{
    public class ThreadSayar
    {
        public List<int> sayilar = new List<int>();
        public List<int> ciftler = new List<int>();
        public List<int> tekler = new List<int>();
        public List<int> asallar = new List<int>();

        static Mutex mutex = new Mutex();
        List<int>[] parcalar = new List<int>[4];
        public void ListeOlustur()
        {
            for (int i = 1; i <= 1000000; i++)
            {
                sayilar.Add(i);
            }

            //liste 4 parçaya ayrıldı
            int parcaSayisi = sayilar.Count / 4;

            

            for (int i = 0; i < 4; i++)
            {
                parcalar[i] = sayilar.GetRange(i * parcaSayisi, parcaSayisi);
            }

        }

        public void ThreadCalistir()
        {

            Thread thread1 = new Thread(() => Kontrol(parcalar[0]));
            Thread thread2 = new Thread(() => Kontrol(parcalar[1]));
            Thread thread3 = new Thread(() => Kontrol(parcalar[2]));
            Thread thread4 = new Thread(() => Kontrol(parcalar[3]));


            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread4.Start();

            thread1.Join();
            thread2.Join();
            thread3.Join();
            thread4.Join();

        }

        public void Kontrol(List<int> parca)
        {
            foreach (var number in parca)
            {
                try
                {
                    mutex.WaitOne();    // Mutex kilidini almaya çalışır

                    if (CiftMi(number))
                    {
                        ciftler.Add(number);
                    }
                    else
                    {
                        tekler.Add(number);
                    }

                    if (AsalMi(number))
                    {
                        asallar.Add(number);
                    }
                }
                finally
                {
                    mutex.ReleaseMutex();   // Mutex kilidini serbest bırakır
                }
            }
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
}
