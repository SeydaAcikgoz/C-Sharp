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

namespace IPD_thread4_semhapore
{
    public partial class Form1 : Form
    {
        Semaphore semItem;
        public Form1()
        {
            InitializeComponent();
            semItem = new Semaphore(3, 5);//3 ile başla max 5 ol
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form.CheckForIllegalCrossThreadCalls = false;

            Thread thr1 = new Thread(new ThreadStart(threadFunc1));
            Thread thr2 = new Thread(new ThreadStart(threadFunc2));
            Thread thr3 = new Thread(new ThreadStart(threadFunc3));
            Thread thr4 = new Thread(new ThreadStart(threadFunc4));

            thr1.Start();
            thr2.Start();
            thr3.Start();
            thr4.Start();
        }

        public void threadFunc1()
        {
            semItem.WaitOne();
            try
            {
                while (progressBar1.Value < 100)
                {
                    progressBar1.Value++;
                    richTextBox1.Text += 'A';
                    Thread.Sleep(23);
                }
            }
            finally
            {
                semItem.Release();
            }

        }
        public void threadFunc2()
        {
            semItem.WaitOne();
            try
            {
                while (progressBar2.Value < 100)
                {
                    progressBar2.Value++;
                    richTextBox1.Text += 'b';
                    Thread.Sleep(42);
                }
            }
            finally
            {
                semItem.Release();
            }

        }
        public void threadFunc3()
        {
            semItem.WaitOne();
            try
            {
                while (progressBar3.Value < 100)
                {
                    progressBar3.Value++;
                    richTextBox1.Text += 'C';
                    Thread.Sleep(71);
                }
            }
            finally
            {
                semItem.Release();
            }

        }
        public void threadFunc4()
        {
            semItem.WaitOne();
            try
            {
                while (progressBar4.Value < 100)
                {
                    progressBar4.Value++;
                    richTextBox1.Text += 'D';
                    Thread.Sleep(98);
                }
            }
            finally
            {
                semItem.Release();
            }

        }
    }
}
