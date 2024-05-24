namespace Forms
{
    partial class FrmTahminiButce
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTahminiButce));
            pnlGelirBaslik = new Panel();
            pnlEkButceButonlari = new Panel();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            lblBaslik = new Label();
            txtButceTutari = new TextBox();
            lblButceTutari = new Label();
            dgvTahminiButceler = new DataGridView();
            pnlButceButonlari = new Panel();
            pcBoxIdariIsler = new PictureBox();
            pcBoxTahminiGider = new PictureBox();
            pcBoxTahminiGelir = new PictureBox();
            pnlButceFormlari = new Panel();
            panel2 = new Panel();
            pcBoxEkButce = new PictureBox();
            pcBoxKaydet = new PictureBox();
            pcBoxGuncelle = new PictureBox();
            pcBoxSil = new PictureBox();
            pnlGelirBaslik.SuspendLayout();
            pnlEkButceButonlari.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvTahminiButceler).BeginInit();
            pnlButceButonlari.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pcBoxIdariIsler).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxTahminiGider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxTahminiGelir).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pcBoxEkButce).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxKaydet).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxGuncelle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxSil).BeginInit();
            SuspendLayout();
            // 
            // pnlGelirBaslik
            // 
            pnlGelirBaslik.Controls.Add(pnlEkButceButonlari);
            pnlGelirBaslik.Controls.Add(lblBaslik);
            pnlGelirBaslik.Dock = DockStyle.Top;
            pnlGelirBaslik.Location = new Point(0, 0);
            pnlGelirBaslik.Margin = new Padding(3, 4, 3, 4);
            pnlGelirBaslik.Name = "pnlGelirBaslik";
            pnlGelirBaslik.Size = new Size(1429, 80);
            pnlGelirBaslik.TabIndex = 1;
            // 
            // pnlEkButceButonlari
            // 
            pnlEkButceButonlari.Controls.Add(pictureBox2);
            pnlEkButceButonlari.Controls.Add(pictureBox3);
            pnlEkButceButonlari.Location = new Point(1026, 4);
            pnlEkButceButonlari.Margin = new Padding(3, 4, 3, 4);
            pnlEkButceButonlari.Name = "pnlEkButceButonlari";
            pnlEkButceButonlari.Size = new Size(329, 139);
            pnlEkButceButonlari.TabIndex = 119;
            // 
            // pictureBox2
            // 
            pictureBox2.Cursor = Cursors.Hand;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(167, 13);
            pictureBox2.Margin = new Padding(3, 4, 3, 4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(149, 107);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 115;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.Cursor = Cursors.Hand;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(11, 13);
            pictureBox3.Margin = new Padding(3, 4, 3, 4);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(149, 107);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 114;
            pictureBox3.TabStop = false;
            pictureBox3.Click += pictureBox3_Click;
            // 
            // lblBaslik
            // 
            lblBaslik.AutoSize = true;
            lblBaslik.Font = new Font("321impact", 35.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblBaslik.Location = new Point(208, 5);
            lblBaslik.Name = "lblBaslik";
            lblBaslik.Size = new Size(702, 67);
            lblBaslik.TabIndex = 1;
            lblBaslik.Text = "TAHMİNİ BÜTÇE İŞLEMLERİ";
            // 
            // txtButceTutari
            // 
            txtButceTutari.Font = new Font("Lucida Calligraphy", 14.25F);
            txtButceTutari.Location = new Point(169, 85);
            txtButceTutari.Margin = new Padding(3, 4, 3, 4);
            txtButceTutari.Name = "txtButceTutari";
            txtButceTutari.Size = new Size(305, 40);
            txtButceTutari.TabIndex = 108;
            // 
            // lblButceTutari
            // 
            lblButceTutari.AutoSize = true;
            lblButceTutari.Font = new Font("Lucida Calligraphy", 14.25F);
            lblButceTutari.ImeMode = ImeMode.NoControl;
            lblButceTutari.Location = new Point(2, 89);
            lblButceTutari.Name = "lblButceTutari";
            lblButceTutari.Size = new Size(179, 31);
            lblButceTutari.TabIndex = 109;
            lblButceTutari.Text = "Bütçe Tutarı";
            // 
            // dgvTahminiButceler
            // 
            dgvTahminiButceler.AllowUserToAddRows = false;
            dgvTahminiButceler.AllowUserToDeleteRows = false;
            dgvTahminiButceler.BackgroundColor = SystemColors.Control;
            dgvTahminiButceler.BorderStyle = BorderStyle.None;
            dgvTahminiButceler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTahminiButceler.Location = new Point(3, 232);
            dgvTahminiButceler.Margin = new Padding(3, 4, 3, 4);
            dgvTahminiButceler.Name = "dgvTahminiButceler";
            dgvTahminiButceler.ReadOnly = true;
            dgvTahminiButceler.RowHeadersWidth = 51;
            dgvTahminiButceler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTahminiButceler.Size = new Size(471, 831);
            dgvTahminiButceler.TabIndex = 117;
            dgvTahminiButceler.CellDoubleClick += dgvTahminiButceler_CellDoubleClick;
            // 
            // pnlButceButonlari
            // 
            pnlButceButonlari.Controls.Add(pcBoxIdariIsler);
            pnlButceButonlari.Controls.Add(pcBoxTahminiGider);
            pnlButceButonlari.Controls.Add(pcBoxTahminiGelir);
            pnlButceButonlari.Location = new Point(520, 85);
            pnlButceButonlari.Margin = new Padding(3, 4, 3, 4);
            pnlButceButonlari.Name = "pnlButceButonlari";
            pnlButceButonlari.Size = new Size(480, 139);
            pnlButceButonlari.TabIndex = 118;
            // 
            // pcBoxIdariIsler
            // 
            pcBoxIdariIsler.Cursor = Cursors.Hand;
            pcBoxIdariIsler.Image = (Image)resources.GetObject("pcBoxIdariIsler.Image");
            pcBoxIdariIsler.Location = new Point(322, 13);
            pcBoxIdariIsler.Margin = new Padding(3, 4, 3, 4);
            pcBoxIdariIsler.Name = "pcBoxIdariIsler";
            pcBoxIdariIsler.Size = new Size(149, 107);
            pcBoxIdariIsler.SizeMode = PictureBoxSizeMode.StretchImage;
            pcBoxIdariIsler.TabIndex = 116;
            pcBoxIdariIsler.TabStop = false;
            pcBoxIdariIsler.Click += pcBoxIdariIsler_Click;
            // 
            // pcBoxTahminiGider
            // 
            pcBoxTahminiGider.Cursor = Cursors.Hand;
            pcBoxTahminiGider.Image = (Image)resources.GetObject("pcBoxTahminiGider.Image");
            pcBoxTahminiGider.Location = new Point(167, 13);
            pcBoxTahminiGider.Margin = new Padding(3, 4, 3, 4);
            pcBoxTahminiGider.Name = "pcBoxTahminiGider";
            pcBoxTahminiGider.Size = new Size(149, 107);
            pcBoxTahminiGider.SizeMode = PictureBoxSizeMode.StretchImage;
            pcBoxTahminiGider.TabIndex = 115;
            pcBoxTahminiGider.TabStop = false;
            pcBoxTahminiGider.Click += pcBoxTahminiGider_Click;
            // 
            // pcBoxTahminiGelir
            // 
            pcBoxTahminiGelir.Cursor = Cursors.Hand;
            pcBoxTahminiGelir.Image = (Image)resources.GetObject("pcBoxTahminiGelir.Image");
            pcBoxTahminiGelir.Location = new Point(11, 13);
            pcBoxTahminiGelir.Margin = new Padding(3, 4, 3, 4);
            pcBoxTahminiGelir.Name = "pcBoxTahminiGelir";
            pcBoxTahminiGelir.Size = new Size(149, 107);
            pcBoxTahminiGelir.SizeMode = PictureBoxSizeMode.StretchImage;
            pcBoxTahminiGelir.TabIndex = 114;
            pcBoxTahminiGelir.TabStop = false;
            pcBoxTahminiGelir.Click += pcBoxTahminiGelir_Click;
            // 
            // pnlButceFormlari
            // 
            pnlButceFormlari.Location = new Point(481, 232);
            pnlButceFormlari.Margin = new Padding(3, 4, 3, 4);
            pnlButceFormlari.Name = "pnlButceFormlari";
            pnlButceFormlari.Size = new Size(934, 1019);
            pnlButceFormlari.TabIndex = 119;
            // 
            // panel2
            // 
            panel2.Controls.Add(pcBoxEkButce);
            panel2.Location = new Point(1216, 85);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(173, 133);
            panel2.TabIndex = 119;
            // 
            // pcBoxEkButce
            // 
            pcBoxEkButce.Cursor = Cursors.Hand;
            pcBoxEkButce.Image = (Image)resources.GetObject("pcBoxEkButce.Image");
            pcBoxEkButce.Location = new Point(8, 7);
            pcBoxEkButce.Margin = new Padding(3, 4, 3, 4);
            pcBoxEkButce.Name = "pcBoxEkButce";
            pcBoxEkButce.Size = new Size(155, 120);
            pcBoxEkButce.SizeMode = PictureBoxSizeMode.StretchImage;
            pcBoxEkButce.TabIndex = 7;
            pcBoxEkButce.TabStop = false;
            pcBoxEkButce.Click += pcBoxEkButce_Click;
            // 
            // pcBoxKaydet
            // 
            pcBoxKaydet.Cursor = Cursors.Hand;
            pcBoxKaydet.Image = Properties.Resources.Kaydet1;
            pcBoxKaydet.Location = new Point(169, 136);
            pcBoxKaydet.Margin = new Padding(3, 4, 3, 4);
            pcBoxKaydet.Name = "pcBoxKaydet";
            pcBoxKaydet.Size = new Size(97, 87);
            pcBoxKaydet.SizeMode = PictureBoxSizeMode.StretchImage;
            pcBoxKaydet.TabIndex = 120;
            pcBoxKaydet.TabStop = false;
            pcBoxKaydet.Click += pcBoxKaydet_Click;
            // 
            // pcBoxGuncelle
            // 
            pcBoxGuncelle.Cursor = Cursors.Hand;
            pcBoxGuncelle.Image = (Image)resources.GetObject("pcBoxGuncelle.Image");
            pcBoxGuncelle.Location = new Point(377, 137);
            pcBoxGuncelle.Margin = new Padding(3, 4, 3, 4);
            pcBoxGuncelle.Name = "pcBoxGuncelle";
            pcBoxGuncelle.Size = new Size(97, 87);
            pcBoxGuncelle.SizeMode = PictureBoxSizeMode.StretchImage;
            pcBoxGuncelle.TabIndex = 120;
            pcBoxGuncelle.TabStop = false;
            pcBoxGuncelle.Click += pcBoxGuncelle_Click;
            // 
            // pcBoxSil
            // 
            pcBoxSil.Cursor = Cursors.Hand;
            pcBoxSil.Image = (Image)resources.GetObject("pcBoxSil.Image");
            pcBoxSil.Location = new Point(273, 136);
            pcBoxSil.Margin = new Padding(3, 4, 3, 4);
            pcBoxSil.Name = "pcBoxSil";
            pcBoxSil.Size = new Size(97, 87);
            pcBoxSil.SizeMode = PictureBoxSizeMode.StretchImage;
            pcBoxSil.TabIndex = 120;
            pcBoxSil.TabStop = false;
            pcBoxSil.Click += pcBoxSil_Click;
            // 
            // FrmTahminiButce
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1429, 1102);
            Controls.Add(pnlButceButonlari);
            Controls.Add(pcBoxSil);
            Controls.Add(pcBoxGuncelle);
            Controls.Add(pcBoxKaydet);
            Controls.Add(panel2);
            Controls.Add(pnlButceFormlari);
            Controls.Add(dgvTahminiButceler);
            Controls.Add(txtButceTutari);
            Controls.Add(lblButceTutari);
            Controls.Add(pnlGelirBaslik);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmTahminiButce";
            Text = "FrmTahminiButce";
            Load += FrmTahminiButce_Load;
            pnlGelirBaslik.ResumeLayout(false);
            pnlGelirBaslik.PerformLayout();
            pnlEkButceButonlari.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvTahminiButceler).EndInit();
            pnlButceButonlari.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pcBoxIdariIsler).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxTahminiGider).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxTahminiGelir).EndInit();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pcBoxEkButce).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxKaydet).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxGuncelle).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxSil).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlGelirBaslik;
        private Label lblBaslik;
        private TextBox txtButceTutari;
        private Label lblButceTutari;
        private DataGridView dgvTahminiButceler;
        private Panel pnlButceButonlari;
        private Panel pnlButceFormlari;
        private Panel panel2;
        private PictureBox pcBoxTahminiGelir;
        private PictureBox pcBoxTahminiGider;
        private PictureBox pcBoxIdariIsler;
        private PictureBox pcBoxEkButce;
        private PictureBox pcBoxKaydet;
        private PictureBox pcBoxGuncelle;
        private PictureBox pcBoxSil;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        public Panel pnlEkButceButonlari;
    }
}