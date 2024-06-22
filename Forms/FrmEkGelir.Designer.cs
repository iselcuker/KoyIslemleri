namespace Forms
{
    partial class FrmEkGelir
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEkGelir));
            pnlGelirBaslik = new Panel();
            lblBaslik = new Label();
            lblTutar = new Label();
            cmbDegisiklik = new ComboBox();
            lblDegisiklik = new Label();
            cmbGelirKategori = new ComboBox();
            lblGelirKategori = new Label();
            txtTutar = new TextBox();
            pcBoxSil = new PictureBox();
            pcBoxGuncelle = new PictureBox();
            pcBoxKaydet = new PictureBox();
            dgvTahminiEkGelirler = new DataGridView();
            lblKalanTutar = new Label();
            lblKalan = new Label();
            pnlGelirBaslik.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pcBoxSil).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxGuncelle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxKaydet).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvTahminiEkGelirler).BeginInit();
            SuspendLayout();
            // 
            // pnlGelirBaslik
            // 
            pnlGelirBaslik.Controls.Add(lblBaslik);
            pnlGelirBaslik.Dock = DockStyle.Top;
            pnlGelirBaslik.Location = new Point(0, 0);
            pnlGelirBaslik.Margin = new Padding(3, 4, 3, 4);
            pnlGelirBaslik.Name = "pnlGelirBaslik";
            pnlGelirBaslik.Size = new Size(922, 80);
            pnlGelirBaslik.TabIndex = 132;
            // 
            // lblBaslik
            // 
            lblBaslik.AutoSize = true;
            lblBaslik.Font = new Font("321impact", 35.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblBaslik.Location = new Point(314, 4);
            lblBaslik.Name = "lblBaslik";
            lblBaslik.Size = new Size(246, 67);
            lblBaslik.TabIndex = 1;
            lblBaslik.Text = "EK GELİR";
            // 
            // lblTutar
            // 
            lblTutar.AutoSize = true;
            lblTutar.Font = new Font("Verdana", 14.25F);
            lblTutar.ImeMode = ImeMode.NoControl;
            lblTutar.Location = new Point(10, 197);
            lblTutar.Name = "lblTutar";
            lblTutar.Size = new Size(74, 29);
            lblTutar.TabIndex = 127;
            lblTutar.Text = "Tutar";
            // 
            // cmbDegisiklik
            // 
            cmbDegisiklik.BackColor = SystemColors.Control;
            cmbDegisiklik.Cursor = Cursors.Hand;
            cmbDegisiklik.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDegisiklik.Font = new Font("Verdana", 14.25F);
            cmbDegisiklik.ForeColor = SystemColors.MenuText;
            cmbDegisiklik.FormattingEnabled = true;
            cmbDegisiklik.Location = new Point(201, 141);
            cmbDegisiklik.Margin = new Padding(3, 4, 3, 4);
            cmbDegisiklik.Name = "cmbDegisiklik";
            cmbDegisiklik.Size = new Size(452, 37);
            cmbDegisiklik.TabIndex = 122;
            cmbDegisiklik.SelectedIndexChanged += cmbDegisiklik_SelectedIndexChanged;
            // 
            // lblDegisiklik
            // 
            lblDegisiklik.AutoSize = true;
            lblDegisiklik.Font = new Font("Verdana", 14.25F);
            lblDegisiklik.ImeMode = ImeMode.NoControl;
            lblDegisiklik.Location = new Point(10, 148);
            lblDegisiklik.Name = "lblDegisiklik";
            lblDegisiklik.Size = new Size(126, 29);
            lblDegisiklik.TabIndex = 125;
            lblDegisiklik.Text = "Değişiklik";
            // 
            // cmbGelirKategori
            // 
            cmbGelirKategori.BackColor = SystemColors.Control;
            cmbGelirKategori.Cursor = Cursors.Hand;
            cmbGelirKategori.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGelirKategori.Font = new Font("Verdana", 14.25F);
            cmbGelirKategori.ForeColor = SystemColors.MenuText;
            cmbGelirKategori.FormattingEnabled = true;
            cmbGelirKategori.Location = new Point(201, 88);
            cmbGelirKategori.Margin = new Padding(3, 4, 3, 4);
            cmbGelirKategori.Name = "cmbGelirKategori";
            cmbGelirKategori.Size = new Size(452, 37);
            cmbGelirKategori.TabIndex = 123;
            cmbGelirKategori.SelectedIndexChanged += cmbGelirKategori_SelectedIndexChanged;
            // 
            // lblGelirKategori
            // 
            lblGelirKategori.AutoSize = true;
            lblGelirKategori.Font = new Font("Verdana", 14.25F);
            lblGelirKategori.ImeMode = ImeMode.NoControl;
            lblGelirKategori.Location = new Point(10, 99);
            lblGelirKategori.Name = "lblGelirKategori";
            lblGelirKategori.Size = new Size(175, 29);
            lblGelirKategori.TabIndex = 126;
            lblGelirKategori.Text = "Gelir Kategori";
            // 
            // txtTutar
            // 
            txtTutar.Cursor = Cursors.IBeam;
            txtTutar.Font = new Font("Verdana", 14.25F);
            txtTutar.Location = new Point(201, 195);
            txtTutar.Margin = new Padding(3, 4, 3, 4);
            txtTutar.Name = "txtTutar";
            txtTutar.Size = new Size(238, 36);
            txtTutar.TabIndex = 124;
            // 
            // pcBoxSil
            // 
            pcBoxSil.Cursor = Cursors.Hand;
            pcBoxSil.Image = (Image)resources.GetObject("pcBoxSil.Image");
            pcBoxSil.Location = new Point(305, 247);
            pcBoxSil.Margin = new Padding(3, 4, 3, 4);
            pcBoxSil.Name = "pcBoxSil";
            pcBoxSil.Size = new Size(97, 87);
            pcBoxSil.SizeMode = PictureBoxSizeMode.StretchImage;
            pcBoxSil.TabIndex = 133;
            pcBoxSil.TabStop = false;
            pcBoxSil.Click += pcBoxSil_Click;
            // 
            // pcBoxGuncelle
            // 
            pcBoxGuncelle.Cursor = Cursors.Hand;
            pcBoxGuncelle.Image = (Image)resources.GetObject("pcBoxGuncelle.Image");
            pcBoxGuncelle.Location = new Point(409, 247);
            pcBoxGuncelle.Margin = new Padding(3, 4, 3, 4);
            pcBoxGuncelle.Name = "pcBoxGuncelle";
            pcBoxGuncelle.Size = new Size(97, 87);
            pcBoxGuncelle.SizeMode = PictureBoxSizeMode.StretchImage;
            pcBoxGuncelle.TabIndex = 134;
            pcBoxGuncelle.TabStop = false;
            pcBoxGuncelle.Click += pcBoxGuncelle_Click;
            // 
            // pcBoxKaydet
            // 
            pcBoxKaydet.Cursor = Cursors.Hand;
            pcBoxKaydet.Image = Properties.Resources.Kaydet1;
            pcBoxKaydet.Location = new Point(201, 247);
            pcBoxKaydet.Margin = new Padding(3, 4, 3, 4);
            pcBoxKaydet.Name = "pcBoxKaydet";
            pcBoxKaydet.Size = new Size(97, 87);
            pcBoxKaydet.SizeMode = PictureBoxSizeMode.StretchImage;
            pcBoxKaydet.TabIndex = 135;
            pcBoxKaydet.TabStop = false;
            pcBoxKaydet.Click += pcBoxKaydet_Click;
            // 
            // dgvTahminiEkGelirler
            // 
            dgvTahminiEkGelirler.AllowUserToAddRows = false;
            dgvTahminiEkGelirler.AllowUserToDeleteRows = false;
            dgvTahminiEkGelirler.AllowUserToResizeColumns = false;
            dgvTahminiEkGelirler.AllowUserToResizeRows = false;
            dgvTahminiEkGelirler.BackgroundColor = SystemColors.Control;
            dgvTahminiEkGelirler.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dgvTahminiEkGelirler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTahminiEkGelirler.Location = new Point(10, 343);
            dgvTahminiEkGelirler.Margin = new Padding(3, 4, 3, 4);
            dgvTahminiEkGelirler.Name = "dgvTahminiEkGelirler";
            dgvTahminiEkGelirler.ReadOnly = true;
            dgvTahminiEkGelirler.RowHeadersWidth = 51;
            dgvTahminiEkGelirler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTahminiEkGelirler.Size = new Size(897, 488);
            dgvTahminiEkGelirler.TabIndex = 136;
            dgvTahminiEkGelirler.CellDoubleClick += dgvTahminiEkGelirler_CellDoubleClick;
            // 
            // lblKalanTutar
            // 
            lblKalanTutar.AutoSize = true;
            lblKalanTutar.Location = new Point(730, 99);
            lblKalanTutar.Name = "lblKalanTutar";
            lblKalanTutar.Size = new Size(84, 20);
            lblKalanTutar.TabIndex = 137;
            lblKalanTutar.Text = "Kalan Tutar";
            // 
            // lblKalan
            // 
            lblKalan.AutoSize = true;
            lblKalan.Location = new Point(755, 127);
            lblKalan.Name = "lblKalan";
            lblKalan.Size = new Size(25, 20);
            lblKalan.TabIndex = 138;
            lblKalan.Text = "00";
            // 
            // FrmEkGelir
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(922, 940);
            Controls.Add(lblKalan);
            Controls.Add(lblKalanTutar);
            Controls.Add(dgvTahminiEkGelirler);
            Controls.Add(pcBoxSil);
            Controls.Add(pcBoxGuncelle);
            Controls.Add(pcBoxKaydet);
            Controls.Add(pnlGelirBaslik);
            Controls.Add(lblTutar);
            Controls.Add(cmbDegisiklik);
            Controls.Add(lblDegisiklik);
            Controls.Add(cmbGelirKategori);
            Controls.Add(lblGelirKategori);
            Controls.Add(txtTutar);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmEkGelir";
            Text = "EkGelir";
            Load += FrmEkGelir_Load;
            pnlGelirBaslik.ResumeLayout(false);
            pnlGelirBaslik.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pcBoxSil).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxGuncelle).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxKaydet).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvTahminiEkGelirler).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlGelirBaslik;
        private Label lblBaslik;
        public DataGridView dgvTahminiEkGelirler;
        private Label lblTutar;
        private ComboBox cmbDegisiklik;
        private Label lblDegisiklik;
        private ComboBox cmbGelirKategori;
        private Label lblGelirKategori;
        private TextBox txtTutar;
        private PictureBox pcBoxSil;
        private PictureBox pcBoxGuncelle;
        private PictureBox pcBoxKaydet;
        private Label lblKalanTutar;
        private Label lblKalan;
        //public DataGridView dgvTahminiEkGelirler;
    }
}