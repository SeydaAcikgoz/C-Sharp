using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AbdullahThread
{
    class ThreadSayar

    {
        public int[,] dizi = new int[256, 256];

        public int[] dizi2 = new int[10];

        public void ThreadleriCalistir()
        {

            Thread thread1 = new Thread(new ThreadStart(Sayi));
            Thread thread2 = new Thread(new ThreadStart(Sayi2));
            Thread thread3 = new Thread(new ThreadStart(Sayi3));
            Thread thread4 = new Thread(new ThreadStart(Sayi4));

            thread2.Priority = ThreadPriority.Highest;
            thread3.Priority = ThreadPriority.BelowNormal;



            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread4.Start();
         
         


            thread1.Join();
            thread2.Join();
            thread3.Join();
            thread4.Join();



            thread1.Abort();
            thread2.Abort();
            thread3.Abort();
            thread4.Abort();



            GC.Collect();


        }


        public void Sayac()
        {


            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < 256; j++)
                {


                    int deger = dizi[i, j];

                    dizi2[deger] = dizi2[deger] + 1;


                }
            }
        }

        public void Sayi()
        {
            Random rasgele = new Random();
           
            for (int i = 0; i < 127; i++)
            {
                for (int j = 0; j < 127; j++)
                {
                    
                    
                    int deger = rasgele.Next(1, 10);

                    
                    dizi[i, j] = deger;
                   
                   
                }                
            }
        }

        public void Sayi2()
        {
            Random rasgele = new Random();

            for (int i = 128; i < 256; i++)
            {
                for (int j = 0; j < 127; j++)
                {
                    
                    int deger = rasgele.Next(1, 10);

                    dizi[i, j] = deger;
                     
                     
                }
            }
        }

        public void Sayi3()
        {
            Random rasgele = new Random();

            for (int i = 0; i < 127; i++)
            {
                for (int j = 128; j < 256; j++)
                {
                    
                    int deger = rasgele.Next(1, 10);
                    dizi[i, j] = deger;
                     
                     
                }
            }
        }

        public void Sayi4()
        {
            Random rasgele = new Random();

            for (int i = 128; i < 256; i++)
            {
                for (int j = 128; j < 256; j++)
                {
                   
                    int deger = rasgele.Next(1, 10);
                    dizi[i, j] = deger;

                     
                    
                }
            }
        }
    


    }
}
