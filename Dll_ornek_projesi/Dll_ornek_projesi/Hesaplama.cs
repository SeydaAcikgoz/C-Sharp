using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dll_ornek_projesi
{
    public class Hesaplama
    {
        private int Topla(int sayi1, int sayi2)
        {
            return sayi1 + sayi2;
        }

        private int Cikar(int sayi1, int sayi2)
        {
            return sayi1 - sayi2;
        }

        private int Carp(int sayi1, int sayi2)
        {
            return sayi1 * sayi2;
        }

        private double Bol(double sayi1, double sayi2)
        {
            return sayi1 / sayi2;
        }

        public double islem_hesapla(int a, int b)
        {
            return Bol((double)Carp(Topla(Carp(a, a), Carp(b, b)), Cikar(a, b)), (double)Carp(a, b));//(a2+b2)*(a-b)/a*b
        }
    }
}
