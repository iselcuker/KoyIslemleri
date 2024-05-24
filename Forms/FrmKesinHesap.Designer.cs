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
            pnlGelirBaslik = new Panel();
            lblBaslik = new Label();
            btnKesinHesap1 = new Button();
            btnKesinHesap2 = new Button();
            pnlKesinHesaplar = new Panel();
            pnlGelirBaslik.SuspendLayout();
            SuspendLayout();
            // 
            // pnlGelirBaslik
            // 
            pnlGelirBaslik.Controls.Add(lblBaslik);
            pnlGelirBaslik.Location = new Point(0, 0);
            pnlGelirBaslik.Name = "pnlGelirBaslik";
            pnlGelirBaslik.Size = new Size(582, 80);
            pnlGelirBaslik.TabIndex = 133;
            // 
            // lblBaslik
            // 
            lblBaslik.AutoSize = true;
            lblBaslik.Font = new Font("321impact", 50.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblBaslik.Location = new Point(12, 9);
            lblBaslik.Name = "lblBaslik";
            lblBaslik.Size = new Size(517, 76);
            lblBaslik.TabIndex = 1;
            lblBaslik.Text = "KESİN HESAPLAR";
            // 
            // btnKesinHesap1
            // 
            btnKesinHesap1.Location = new Point(994, 12);
            btnKesinHesap1.Name = "btnKesinHesap1";
            btnKesinHesap1.Size = new Size(109, 35);
            btnKesinHesap1.TabIndex = 134;
            btnKesinHesap1.Text = "Kesin Hesap 1";
            btnKesinHesap1.UseVisualStyleBackColor = true;
            btnKesinHesap1.Click += btnKesinHesap1_Click;
            // 
            // btnKesinHesap2
            // 
            btnKesinHesap2.Location = new Point(1129, 12);
            btnKesinHesap2.Name = "btnKesinHesap2";
            btnKesinHesap2.Size = new Size(109, 35);
            btnKesinHesap2.TabIndex = 134;
            btnKesinHesap2.Text = "Kesin Hesap 2";
            btnKesinHesap2.UseVisualStyleBackColor = true;
            btnKesinHesap2.Click += btnKesinHesap2_Click;
            // 
            // pnlKesinHesaplar
            // 
            pnlKesinHesaplar.Location = new Point(0, 81);
            pnlKesinHesaplar.Name = "pnlKesinHesaplar";
            pnlKesinHesaplar.Size = new Size(1250, 868);
            pnlKesinHesaplar.TabIndex = 135;
            // 
            // FrmKesinHesap
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1250, 950);
            Controls.Add(pnlKesinHesaplar);
            Controls.Add(btnKesinHesap2);
            Controls.Add(btnKesinHesap1);
            Controls.Add(pnlGelirBaslik);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmKesinHesap";
            Text = "FrmKesinHesap";
            pnlGelirBaslik.ResumeLayout(false);
            pnlGelirBaslik.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlGelirBaslik;
        private Label lblBaslik;
        private Button btnKesinHesap1;
        private Button btnKesinHesap2;
        private Panel pnlKesinHesaplar;
    }
}