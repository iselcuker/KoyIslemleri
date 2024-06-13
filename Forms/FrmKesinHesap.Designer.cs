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
            pnlKesinHesaplar = new Panel();
            btnKesinHesap1 = new Button();
            btnYazdir = new Button();
            btnKesinHesap2 = new Button();
            SuspendLayout();
            // 
            // pnlKesinHesaplar
            // 
            pnlKesinHesaplar.Location = new Point(7, 5);
            pnlKesinHesaplar.Name = "pnlKesinHesaplar";
            pnlKesinHesaplar.Size = new Size(1134, 1046);
            pnlKesinHesaplar.TabIndex = 135;
            // 
            // btnKesinHesap1
            // 
            btnKesinHesap1.Location = new Point(1147, 296);
            btnKesinHesap1.Name = "btnKesinHesap1";
            btnKesinHesap1.Size = new Size(107, 55);
            btnKesinHesap1.TabIndex = 197;
            btnKesinHesap1.Text = "Kesin Hesap 1Y";
            btnKesinHesap1.UseVisualStyleBackColor = true;
            btnKesinHesap1.Click += btnKesinHesap1_Click_1;
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
            // btnKesinHesap2
            // 
            btnKesinHesap2.Location = new Point(1145, 411);
            btnKesinHesap2.Name = "btnKesinHesap2";
            btnKesinHesap2.Size = new Size(107, 55);
            btnKesinHesap2.TabIndex = 197;
            btnKesinHesap2.Text = "Kesin Hesap 2Y";
            btnKesinHesap2.UseVisualStyleBackColor = true;
            btnKesinHesap2.Click += btnKesinHesap2_Click_1;
            // 
            // FrmKesinHesap
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1256, 1070);
            Controls.Add(btnYazdir);
            Controls.Add(btnKesinHesap2);
            Controls.Add(btnKesinHesap1);
            Controls.Add(pnlKesinHesaplar);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmKesinHesap";
            Text = "FrmKesinHesap";
            ResumeLayout(false);
        }

        #endregion
        private Panel pnlKesinHesaplar;
        private Button btnKesinHesap1;
        private Button btnYazdir;
        private Button btnKesinHesap2;
    }
}