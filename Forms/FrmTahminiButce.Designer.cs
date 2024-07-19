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
            lblBaslik = new Label();
            txtButceTutari = new TextBox();
            lblButceTutari = new Label();
            dgvTahminiButceler = new DataGridView();
            pnlButceButonlari = new Panel();
            pcBoxIdariIsler = new PictureBox();
            pcBoxTahminiGider = new PictureBox();
            pcBoxTahminiGelir = new PictureBox();
            pnlButceFormlari = new Panel();
            pcBoxKaydet = new PictureBox();
            pcBoxGuncelle = new PictureBox();
            pcBoxSil = new PictureBox();
            pnlGelirBaslik.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTahminiButceler).BeginInit();
            pnlButceButonlari.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pcBoxIdariIsler).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxTahminiGider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxTahminiGelir).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxKaydet).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxGuncelle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxSil).BeginInit();
            SuspendLayout();
            // 
            // pnlGelirBaslik
            // 
            pnlGelirBaslik.Controls.Add(lblBaslik);
            pnlGelirBaslik.Dock = DockStyle.Top;
            pnlGelirBaslik.Location = new Point(0, 0);
            pnlGelirBaslik.Name = "pnlGelirBaslik";
            pnlGelirBaslik.Size = new Size(1250, 60);
            pnlGelirBaslik.TabIndex = 1;
            // 
            // lblBaslik
            // 
            lblBaslik.AutoSize = true;
            lblBaslik.Font = new Font("321impact", 35.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblBaslik.Location = new Point(182, 4);
            lblBaslik.Name = "lblBaslik";
            lblBaslik.Size = new Size(555, 53);
            lblBaslik.TabIndex = 1;
            lblBaslik.Text = "TAHMİNİ BÜTÇE İŞLEMLERİ";
            // 
            // txtButceTutari
            // 
            txtButceTutari.Font = new Font("Verdana", 14.25F);
            txtButceTutari.Location = new Point(148, 64);
            txtButceTutari.Name = "txtButceTutari";
            txtButceTutari.Size = new Size(267, 31);
            txtButceTutari.TabIndex = 108;
            // 
            // lblButceTutari
            // 
            lblButceTutari.AutoSize = true;
            lblButceTutari.Font = new Font("Verdana", 14.25F);
            lblButceTutari.ImeMode = ImeMode.NoControl;
            lblButceTutari.Location = new Point(2, 67);
            lblButceTutari.Name = "lblButceTutari";
            lblButceTutari.Size = new Size(124, 23);
            lblButceTutari.TabIndex = 109;
            lblButceTutari.Text = "Bütçe Tutarı";
            // 
            // dgvTahminiButceler
            // 
            dgvTahminiButceler.AllowUserToAddRows = false;
            dgvTahminiButceler.AllowUserToDeleteRows = false;
            dgvTahminiButceler.BackgroundColor = SystemColors.Control;
            dgvTahminiButceler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTahminiButceler.Location = new Point(3, 187);
            dgvTahminiButceler.Name = "dgvTahminiButceler";
            dgvTahminiButceler.ReadOnly = true;
            dgvTahminiButceler.RowHeadersWidth = 51;
            dgvTahminiButceler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTahminiButceler.Size = new Size(412, 611);
            dgvTahminiButceler.TabIndex = 117;
            dgvTahminiButceler.DataSourceChanged += dgvTahminiButceler_DataSourceChanged;
            dgvTahminiButceler.CellDoubleClick += dgvTahminiButceler_CellDoubleClick;
            // 
            // pnlButceButonlari
            // 
            pnlButceButonlari.Controls.Add(pcBoxIdariIsler);
            pnlButceButonlari.Controls.Add(pcBoxTahminiGider);
            pnlButceButonlari.Controls.Add(pcBoxTahminiGelir);
            pnlButceButonlari.Location = new Point(455, 64);
            pnlButceButonlari.Name = "pnlButceButonlari";
            pnlButceButonlari.Size = new Size(481, 104);
            pnlButceButonlari.TabIndex = 118;
            // 
            // pcBoxIdariIsler
            // 
            pcBoxIdariIsler.Cursor = Cursors.Hand;
            pcBoxIdariIsler.Image = (Image)resources.GetObject("pcBoxIdariIsler.Image");
            pcBoxIdariIsler.Location = new Point(334, 10);
            pcBoxIdariIsler.Name = "pcBoxIdariIsler";
            pcBoxIdariIsler.Size = new Size(130, 80);
            pcBoxIdariIsler.SizeMode = PictureBoxSizeMode.StretchImage;
            pcBoxIdariIsler.TabIndex = 116;
            pcBoxIdariIsler.TabStop = false;
            pcBoxIdariIsler.Click += pcBoxIdariIsler_Click;
            // 
            // pcBoxTahminiGider
            // 
            pcBoxTahminiGider.Cursor = Cursors.Hand;
            pcBoxTahminiGider.Image = (Image)resources.GetObject("pcBoxTahminiGider.Image");
            pcBoxTahminiGider.Location = new Point(172, 10);
            pcBoxTahminiGider.Name = "pcBoxTahminiGider";
            pcBoxTahminiGider.Size = new Size(130, 80);
            pcBoxTahminiGider.SizeMode = PictureBoxSizeMode.StretchImage;
            pcBoxTahminiGider.TabIndex = 115;
            pcBoxTahminiGider.TabStop = false;
            pcBoxTahminiGider.Click += pcBoxTahminiGider_Click;
            // 
            // pcBoxTahminiGelir
            // 
            pcBoxTahminiGelir.Cursor = Cursors.Hand;
            pcBoxTahminiGelir.Image = (Image)resources.GetObject("pcBoxTahminiGelir.Image");
            pcBoxTahminiGelir.Location = new Point(10, 10);
            pcBoxTahminiGelir.Name = "pcBoxTahminiGelir";
            pcBoxTahminiGelir.Size = new Size(130, 80);
            pcBoxTahminiGelir.SizeMode = PictureBoxSizeMode.StretchImage;
            pcBoxTahminiGelir.TabIndex = 114;
            pcBoxTahminiGelir.TabStop = false;
            pcBoxTahminiGelir.Click += pcBoxTahminiGelir_Click;
            // 
            // pnlButceFormlari
            // 
            pnlButceFormlari.Location = new Point(421, 174);
            pnlButceFormlari.Name = "pnlButceFormlari";
            pnlButceFormlari.Size = new Size(817, 764);
            pnlButceFormlari.TabIndex = 119;
            // 
            // pcBoxKaydet
            // 
            pcBoxKaydet.Cursor = Cursors.Hand;
            pcBoxKaydet.Image = Properties.Resources.Kaydet1;
            pcBoxKaydet.Location = new Point(148, 102);
            pcBoxKaydet.Name = "pcBoxKaydet";
            pcBoxKaydet.Size = new Size(85, 65);
            pcBoxKaydet.SizeMode = PictureBoxSizeMode.StretchImage;
            pcBoxKaydet.TabIndex = 120;
            pcBoxKaydet.TabStop = false;
            pcBoxKaydet.Click += pcBoxKaydet_Click;
            // 
            // pcBoxGuncelle
            // 
            pcBoxGuncelle.Cursor = Cursors.Hand;
            pcBoxGuncelle.Image = (Image)resources.GetObject("pcBoxGuncelle.Image");
            pcBoxGuncelle.Location = new Point(330, 102);
            pcBoxGuncelle.Name = "pcBoxGuncelle";
            pcBoxGuncelle.Size = new Size(85, 65);
            pcBoxGuncelle.SizeMode = PictureBoxSizeMode.StretchImage;
            pcBoxGuncelle.TabIndex = 120;
            pcBoxGuncelle.TabStop = false;
            pcBoxGuncelle.Click += pcBoxGuncelle_Click;
            // 
            // pcBoxSil
            // 
            pcBoxSil.Cursor = Cursors.Hand;
            pcBoxSil.Image = (Image)resources.GetObject("pcBoxSil.Image");
            pcBoxSil.Location = new Point(239, 102);
            pcBoxSil.Name = "pcBoxSil";
            pcBoxSil.Size = new Size(85, 65);
            pcBoxSil.SizeMode = PictureBoxSizeMode.StretchImage;
            pcBoxSil.TabIndex = 120;
            pcBoxSil.TabStop = false;
            pcBoxSil.Click += pcBoxSil_Click;
            // 
            // FrmTahminiButce
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1250, 802);
            Controls.Add(pnlButceButonlari);
            Controls.Add(pcBoxSil);
            Controls.Add(pcBoxGuncelle);
            Controls.Add(pcBoxKaydet);
            Controls.Add(pnlButceFormlari);
            Controls.Add(dgvTahminiButceler);
            Controls.Add(txtButceTutari);
            Controls.Add(lblButceTutari);
            Controls.Add(pnlGelirBaslik);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmTahminiButce";
            Text = "FrmTahminiButce";
            Load += FrmTahminiButce_Load;
            pnlGelirBaslik.ResumeLayout(false);
            pnlGelirBaslik.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTahminiButceler).EndInit();
            pnlButceButonlari.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pcBoxIdariIsler).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxTahminiGider).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxTahminiGelir).EndInit();
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
        private PictureBox pcBoxTahminiGelir;
        private PictureBox pcBoxTahminiGider;
        private PictureBox pcBoxIdariIsler;
        private PictureBox pcBoxKaydet;
        private PictureBox pcBoxGuncelle;
        private PictureBox pcBoxSil;
    }
}