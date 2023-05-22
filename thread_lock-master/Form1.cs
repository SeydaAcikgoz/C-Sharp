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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace IPD_thread2
{
    public partial class Form1 : Form
    {
        private object locker1;
        private object locker2;
        public Form1()
        {
            InitializeComponent();
            //program start edildiğinde locker1 ve locker2 intialize edilir 
            locker1 = new object();
            locker2 = new object();
        }
        //bu örnekte hakem tanımlandı ve hakemthread lerin sırayla çalışmasını sağladı

        private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            progressBar2.Value = 0;
            progressBar3.Value = 0;
            progressBar4.Value = 0;
            progressBar5.Value = 0;
            richTextBox1.Text = "";
            richTextBox2.Text = "";

            System.Windows.Forms.Form.CheckForIllegalCrossThreadCalls = false;
            //Thread thr1 = new Thread(new ThreadStart(threadFunc1));
            Thread thr1 = new Thread(new ThreadStart(threadFuncMonitor));//lock yerine monitor kullanan thread 
            Thread thr2 = new Thread(new ThreadStart(threadFunc2));
            Thread thr3 = new Thread(new ThreadStart(threadFunc3));
            Thread thr4 = new Thread(new ThreadStart(threadFunc4));
            Thread thr5 = new Thread(new ThreadStart(threadFunc5));

            thr1.Start();
            thr2.Start();
            thr3.Start();
            thr4.Start();
            thr5.Start();
        }
        //threadFunc1,threadFunc2,threadFunc3 ve threadFunc4,threadFunc5 birbirinden bağımsız çalışır
        public void threadFunc1()
        {
            lock (locker1)
            {
                while (progressBar1.Value < 100)
                {
                    progressBar1.Value++;
                    richTextBox1.Text += 'A';
                    Thread.Sleep(20);
                }
            }
        }

        //monitor örnek
        public void threadFuncMonitor()        //yuakidakinin aynısı monitorlu hali
        {
            Monitor.Enter(locker1);
            try
            {
                while (progressBar1.Value < 100)
                {
                    progressBar1.Value++;
                    richTextBox1.Text += 'A';
                    Thread.Sleep(20);
                }
            }
            finally
            {
                Monitor.Exit(locker1);
            }
        }
        /// <summary>
        /// ////////////////////// 
        /// </summary>
        public void threadFunc2()
        {
            lock (locker1)
            {
                while (progressBar2.Value < 100)
                {
                    progressBar2.Value++;
                    richTextBox1.Text += 'B';
                    Thread.Sleep(40);
                }
            }
        }

        public void threadFunc3()
        {
            lock (locker1)
            {
                while (progressBar3.Value < 100)
                {
                    progressBar3.Value++;
                    richTextBox1.Text += 'C';
                    Thread.Sleep(60);
                }
            }
        }

        public void threadFunc4()
        {
            lock (locker2)
            {
                while (progressBar4.Value < 100)
                {
                    progressBar4.Value++;
                    richTextBox2.Text += 'X';
                    Thread.Sleep(23);
                }
            }
        }

        public void threadFunc5()
        {
            lock (locker2)
            {
                while (progressBar5.Value < 100)
                {
                    progressBar5.Value++;
                    richTextBox2.Text += 'Y';
                    Thread.Sleep(42);
                }
            }
        }

        private void progressBar3_Click(object sender, EventArgs e)
        {

        }

        private void progressBar2_Click(object sender, EventArgs e)
        {

        }
    }
}
