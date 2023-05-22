namespace ileriProgramlamaDilleri_threads
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.progressBar4 = new System.Windows.Forms.ProgressBar();
            this.progressBar5 = new System.Windows.Forms.ProgressBar();
            this.progressBar6 = new System.Windows.Forms.ProgressBar();
            this.button2 = new System.Windows.Forms.Button();
            this.txtSonuc = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // progressBar4
            // 
            this.progressBar4.Location = new System.Drawing.Point(128, 12);
            this.progressBar4.Name = "progressBar4";
            this.progressBar4.Size = new System.Drawing.Size(277, 23);
            this.progressBar4.TabIndex = 0;
            // 
            // progressBar5
            // 
            this.progressBar5.Location = new System.Drawing.Point(128, 52);
            this.progressBar5.Name = "progressBar5";
            this.progressBar5.Size = new System.Drawing.Size(277, 27);
            this.progressBar5.TabIndex = 1;
            // 
            // progressBar6
            // 
            this.progressBar6.Location = new System.Drawing.Point(128, 99);
            this.progressBar6.Name = "progressBar6";
            this.progressBar6.Size = new System.Drawing.Size(277, 23);
            this.progressBar6.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(217, 145);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 22);
            this.button2.TabIndex = 3;
            this.button2.Text = "Threadları çalıştır";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // txtSonuc
            // 
            this.txtSonuc.Location = new System.Drawing.Point(128, 196);
            this.txtSonuc.Name = "txtSonuc";
            this.txtSonuc.Size = new System.Drawing.Size(277, 20);
            this.txtSonuc.TabIndex = 4;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(563, 261);
            this.Controls.Add(this.txtSonuc);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.progressBar6);
            this.Controls.Add(this.progressBar5);
            this.Controls.Add(this.progressBar4);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ProgressBar progressBar4;
        private System.Windows.Forms.ProgressBar progressBar5;
        private System.Windows.Forms.ProgressBar progressBar6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtSonuc;
    }
}

