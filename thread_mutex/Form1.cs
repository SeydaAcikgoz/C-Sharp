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

namespace IPD_mutex
{
    public partial class Form1 : Form
    {
        Mutex mutItem;
        public Form1()
        {
            InitializeComponent();
            mutItem = new Mutex();//initalize edildi
        }

        private void progressBar2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form.CheckForIllegalCrossThreadCalls = false;

            Thread thr1 = new Thread(new ThreadStart(threadFunc1));
            Thread thr2 = new Thread(new ThreadStart(threadFunc2));
            Thread thr3 = new Thread(new ThreadStart(threadFunc3));

            thr1.Start();
            thr2.Start();
            thr3.Start();
        }

        public void threadFunc1()
        {
            mutItem.WaitOne();//bayrak yarışı başlar.işletim sistemi bayrağı kime verirse o önce çalışır
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
                mutItem.ReleaseMutex();
            }

        }
        public void threadFunc2()
        {
            mutItem.WaitOne();
            try
            {
                while (progressBar2.Value < 100)
                {
                    progressBar2.Value++;
                    richTextBox1.Text += 'B';
                    Thread.Sleep(42);
                }
            }
            finally
            {
                mutItem.ReleaseMutex();
            }

        }
        public void threadFunc3()
        {
            mutItem.WaitOne();
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
                mutItem.ReleaseMutex();
            }

        }
    }
}
