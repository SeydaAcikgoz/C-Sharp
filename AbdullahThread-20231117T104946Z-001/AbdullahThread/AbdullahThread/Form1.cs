using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace AbdullahThread
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var watch = Stopwatch.StartNew();
            // the code that you want to measure comes here

            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView1.Refresh();
            dataGridView2.Refresh();
            
            ThreadSayar s = new ThreadSayar();


            s.ThreadleriCalistir();
            s.Sayac();
           
            dataGridView1.ColumnCount = 256;
            dataGridView2.ColumnCount = 2;

            var rowCount = s.dizi.GetLength(0);
            var rowLength = s.dizi.GetLength(1);

            for (int rowIndex = 0; rowIndex < rowCount; ++rowIndex)
            {
                var row = new DataGridViewRow();

                for(int columnIndex = 0; columnIndex < rowLength; ++columnIndex)
                {
                row.Cells.Add(new DataGridViewTextBoxCell()
            {
                Value = s.dizi[rowIndex, columnIndex]
            });
                }

            dataGridView1.Rows.Add(row);
                


            }

            rowCount = s.dizi2.GetLength(0);
            rowLength = 0;

            for (int rowIndex2 = 1; rowIndex2 < rowCount; ++rowIndex2)
            {
                var row2 = new DataGridViewRow();


                row2.Cells.Add(new DataGridViewTextBoxCell()
                {
                    Value = rowIndex2
                });

                
                    row2.Cells.Add(new DataGridViewTextBoxCell()
                    {
                        Value = s.dizi2[rowIndex2]
                    });

                    dataGridView2.Rows.Add(row2);
                
            }


            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            label3.Text = elapsedMs.ToString();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
