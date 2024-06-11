namespace Forms
{
    partial class FrmKesinHesap
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnKesinHesap1 = new Button();
            btnKesinHesap2 = new Button();
            pnlKesinHesaplar = new Panel();
            btnYazdir1 = new Button();
            btnKesinHesap = new Button();
            btnYazdir = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // btnKesinHesap1
            // 
            btnKesinHesap1.Location = new Point(1145, 12);
            btnKesinHesap1.Name = "btnKesinHesap1";
            btnKesinHesap1.Size = new Size(109, 35);
            btnKesinHesap1.TabIndex = 134;
            btnKesinHesap1.Text = "Kesin Hesap 1";
            btnKesinHesap1.UseVisualStyleBackColor = true;
            btnKesinHesap1.Click += btnKesinHesap1_Click;
            // 
            // btnKesinHesap2
            // 
            btnKesinHesap2.Location = new Point(1145, 225);
            btnKesinHesap2.Name = "btnKesinHesap2";
            btnKesinHesap2.Size = new Size(109, 35);
            btnKesinHesap2.TabIndex = 134;
            btnKesinHesap2.Text = "Kesin Hesap 2";
            btnKesinHesap2.UseVisualStyleBackColor = true;
            btnKesinHesap2.Click += btnKesinHesap2_Click;
            // 
            // pnlKesinHesaplar
            // 
            pnlKesinHesaplar.Location = new Point(7, 5);
            pnlKesinHesaplar.Name = "pnlKesinHesaplar";
            pnlKesinHesaplar.Size = new Size(1134, 1046);
            pnlKesinHesaplar.TabIndex = 135;
            // 
            // btnYazdir1
            // 
            btnYazdir1.Location = new Point(1147, 53);
            btnYazdir1.Name = "btnYazdir1";
            btnYazdir1.Size = new Size(107, 41);
            btnYazdir1.TabIndex = 196;
            btnYazdir1.Text = "Kesin Hesap 1 Yazdır";
            btnYazdir1.UseVisualStyleBackColor = true;
            // 
            // btnKesinHesap
            // 
            btnKesinHesap.Location = new Point(1147, 296);
            btnKesinHesap.Name = "btnKesinHesap";
            btnKesinHesap.Size = new Size(107, 55);
            btnKesinHesap.TabIndex = 197;
            btnKesinHesap.Text = "Kesin Hesap 1Y";
            btnKesinHesap.UseVisualStyleBackColor = true;
            btnKesinHesap.Click += button1_Click;
            // 
            // btnYazdir
            // 
            btnYazdir.Location = new Point(1161, 371);
            btnYazdir.Name = "btnYazdir";
            btnYazdir.Size = new Size(75, 23);
            btnYazdir.TabIndex = 198;
            btnYazdir.Text = "Yazdır";
            btnYazdir.UseVisualStyleBackColor = true;
            btnYazdir.Click += btnYazdir_Click;
            // 
            // button2
            // 
            button2.Location = new Point(1145, 411);
            button2.Name = "button2";
            button2.Size = new Size(107, 55);
            button2.TabIndex = 197;
            button2.Text = "Kesin Hesap 2Y";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button1_Click;
            // 
            // FrmKesinHesap
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1256, 1070);
            Controls.Add(btnYazdir);
            Controls.Add(button2);
            Controls.Add(btnKesinHesap);
            Controls.Add(btnYazdir1);
            Controls.Add(pnlKesinHesaplar);
            Controls.Add(btnKesinHesap2);
            Controls.Add(btnKesinHesap1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmKesinHesap";
            Text = "FrmKesinHesap";
            ResumeLayout(false);
        }

        #endregion
        private Button btnKesinHesap1;
        private Button btnKesinHesap2;
        private Panel pnlKesinHesaplar;
        private Button btnYazdir1;
        private Button btnKesinHesap;
        private Button btnYazdir;
        private Button button2;
    }
}