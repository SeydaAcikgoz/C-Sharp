using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ileriProgramlamaDilleri_threads
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       private void button2_Click_1(object sender, EventArgs e)
        {
            //butona tıklanınca progressbarları sıfırla,textbox ı sıfırla
            progressBar4.Value = 0;
            progressBar5.Value = 0;
            progressBar6.Value = 0;
            txtSonuc.Text = "";

            System.Windows.Forms.Form.CheckForIllegalCrossThreadCalls = false;//thread controlü bizde demek,otamatik işlem yapma
            //thread tanımı
            Thread thr1 = new Thread(new ThreadStart(threadFunc1));
            Thread thr2 = new Thread(new ThreadStart(threadFunc2));
            Thread thr3 = new Thread(new ThreadStart(threadFunc3));
            
            //thread leri çalıştır
            thr1.Start();
            thr2.Start();
            thr3.Start();
        }

        public void threadFunc1()
        {
            while (progressBar4.Value < 100)
            {
                progressBar4.Value++;
                txtSonuc.Text += 'A';
                Thread.Sleep(20);//işlemini yap 20saniye bekle
            }
        }

        public void threadFunc2()
        {
            while (progressBar5.Value < 100)
            {
                progressBar5.Value++;
                txtSonuc.Text += 'B';
                Thread.Sleep(40);//işlemini yap 40saniye bekle
            }
        }

        public void threadFunc3()
        {
            while (progressBar6.Value < 100)
            {
                progressBar6.Value++;
                txtSonuc.Text += 'C';
                Thread.Sleep(60);//işlemini yap 60saniye bekle
            }
        }

        
    }
}
