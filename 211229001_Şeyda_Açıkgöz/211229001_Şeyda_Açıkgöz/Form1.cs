using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _211229001_Şeyda_Açıkgöz
{
    public partial class Form1 : Form
    {
        ThreadSayar s = new ThreadSayar();
        public Form1()
        {
            InitializeComponent();
            s.ListeOlustur();
            button1.Text = "Tek Sayıları Yaz";
            button2.Text = "Çift Sayıları Yaz";
            button3.Text = "Asal Sayıları Yaz";
            button4.Text = "Threadları Çalıştır";

            label1.Text = "Eleman Sayısı";
            label3.Text = "Eleman Sayısı";
            label5.Text = "Eleman Sayısı";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            s.ThreadCalistir();
            label7.Text = "Threadlar Çalıştı";
        }

        public void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            dataGridView1.Columns.Add("Tek Sayılar", "Tek Sayılar");

            for (int i = 0; i < s.tekler.Count(); ++i)
            {
                var row = new DataGridViewRow();

                    row.Cells.Add(new DataGridViewTextBoxCell()
                    {
                        Value = s.tekler[i]
                    });
                

                dataGridView1.Rows.Add(row);
            }

            label2.Text = s.tekler.Count().ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            dataGridView2.Refresh();

            dataGridView2.Columns.Add("Çift Sayılar", "Çift Sayılar");

            for (int rowIndex = 0; rowIndex < s.ciftler.Count(); ++rowIndex)
            {
                var row = new DataGridViewRow();

                    row.Cells.Add(new DataGridViewTextBoxCell()
                    {
                        Value = s.ciftler[rowIndex]
                    });
                
                dataGridView2.Rows.Add(row);
            }

            label4.Text = s.ciftler.Count().ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            dataGridView3.Rows.Clear();
            dataGridView3.Refresh();


            dataGridView3.Columns.Add("Asal Sayılar", "Asal Sayılar");


            for (int rowIndex = 0; rowIndex < s.asallar.Count(); ++rowIndex)
            {
                var row = new DataGridViewRow();

                    row.Cells.Add(new DataGridViewTextBoxCell()
                    {
                        Value = s.asallar[rowIndex]
                    });
                
                dataGridView3.Rows.Add(row);
            }

            label6.Text = s.asallar.Count().ToString();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void fileSystemWatcher1_Changed(object sender, System.IO.FileSystemEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
