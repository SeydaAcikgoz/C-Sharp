using Dll_ornek_projesi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dll_Statik_Cagirma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hesaplama hesaplama = new Hesaplama();
            SonucTxt.Text= hesaplama.islem_hesapla(Convert.ToInt32(Sayi1Txt.Text), Convert.ToInt32(Sayi2Txt.Text)).ToString();
        }
    }
}
