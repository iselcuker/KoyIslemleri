namespace Forms
{
    partial class FrmTahminiGelir
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTahminiGelir));
            txtTutar = new TextBox();
            lblTutar = new Label();
            cmbGelirKategori = new ComboBox();
            lblGelirKategori = new Label();
            lblDegisiklik = new Label();
            cmbDegisiklik = new ComboBox();
            lblBaslik = new Label();
            pnlGelirBaslik = new Panel();
            pcBoxSil = new PictureBox();
            pcBoxGuncelle = new PictureBox();
            pcBoxKaydet = new PictureBox();
            dgvTahminiGelirler = new DataGridView();
            lblYeniTutar = new Label();
            lblKalanGelirTutari = new Label();
            pnlGelirBaslik.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pcBoxSil).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxGuncelle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxKaydet).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvTahminiGelirler).BeginInit();
            SuspendLayout();
            // 
            // txtTutar
            // 
            txtTutar.Cursor = Cursors.IBeam;
            txtTutar.Font = new Font("Lucida Calligraphy", 14.25F);
            txtTutar.Location = new Point(206, 171);
            txtTutar.Margin = new Padding(3, 4, 3, 4);
            txtTutar.Name = "txtTutar";
            txtTutar.Size = new Size(238, 40);
            txtTutar.TabIndex = 107;
            txtTutar.KeyPress += txtTutar_KeyPress;
            txtTutar.Leave += txtTutar_Leave;
            // 
            // lblTutar
            // 
            lblTutar.AutoSize = true;
            lblTutar.Font = new Font("Verdana", 14.25F);
            lblTutar.ImeMode = ImeMode.NoControl;
            lblTutar.Location = new Point(25, 173);
            lblTutar.Name = "lblTutar";
            lblTutar.Size = new Size(74, 29);
            lblTutar.TabIndex = 109;
            lblTutar.Text = "Tutar";
            // 
            // cmbGelirKategori
            // 
            cmbGelirKategori.BackColor = SystemColors.Control;
            cmbGelirKategori.Cursor = Cursors.Hand;
            cmbGelirKategori.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGelirKategori.Font = new Font("Verdana", 14.25F);
            cmbGelirKategori.ForeColor = SystemColors.MenuText;
            cmbGelirKategori.FormattingEnabled = true;
            cmbGelirKategori.Location = new Point(206, 81);
            cmbGelirKategori.Margin = new Padding(3, 4, 3, 4);
            cmbGelirKategori.Name = "cmbGelirKategori";
            cmbGelirKategori.Size = new Size(452, 37);
            cmbGelirKategori.TabIndex = 106;
            cmbGelirKategori.SelectedIndexChanged += cmbGelirKategori_SelectedIndexChanged;
            // 
            // lblGelirKategori
            // 
            lblGelirKategori.AutoSize = true;
            lblGelirKategori.Font = new Font("Verdana", 14.25F);
            lblGelirKategori.ImeMode = ImeMode.NoControl;
            lblGelirKategori.Location = new Point(25, 84);
            lblGelirKategori.Name = "lblGelirKategori";
            lblGelirKategori.Size = new Size(175, 29);
            lblGelirKategori.TabIndex = 108;
            lblGelirKategori.Text = "Gelir Kategori";
            // 
            // lblDegisiklik
            // 
            lblDegisiklik.AutoSize = true;
            lblDegisiklik.Font = new Font("Verdana", 14.25F);
            lblDegisiklik.ImeMode = ImeMode.NoControl;
            lblDegisiklik.Location = new Point(25, 129);
            lblDegisiklik.Name = "lblDegisiklik";
            lblDegisiklik.Size = new Size(126, 29);
            lblDegisiklik.TabIndex = 108;
            lblDegisiklik.Text = "Değişiklik";
            // 
            // cmbDegisiklik
            // 
            cmbDegisiklik.BackColor = SystemColors.Control;
            cmbDegisiklik.Cursor = Cursors.Hand;
            cmbDegisiklik.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDegisiklik.Font = new Font("Verdana", 14.25F);
            cmbDegisiklik.ForeColor = SystemColors.MenuText;
            cmbDegisiklik.FormattingEnabled = true;
            cmbDegisiklik.Location = new Point(206, 125);
            cmbDegisiklik.Margin = new Padding(3, 4, 3, 4);
            cmbDegisiklik.Name = "cmbDegisiklik";
            cmbDegisiklik.Size = new Size(452, 37);
            cmbDegisiklik.TabIndex = 106;
            // 
            // lblBaslik
            // 
            lblBaslik.AutoSize = true;
            lblBaslik.Font = new Font("321impact", 30F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblBaslik.Location = new Point(178, 5);
            lblBaslik.Name = "lblBaslik";
            lblBaslik.Size = new Size(345, 57);
            lblBaslik.TabIndex = 1;
            lblBaslik.Text = "TAHMİNİ GELİR";
            // 
            // pnlGelirBaslik
            // 
            pnlGelirBaslik.Controls.Add(lblBaslik);
            pnlGelirBaslik.Dock = DockStyle.Top;
            pnlGelirBaslik.Location = new Point(0, 0);
            pnlGelirBaslik.Margin = new Padding(3, 4, 3, 4);
            pnlGelirBaslik.Name = "pnlGelirBaslik";
            pnlGelirBaslik.Size = new Size(926, 73);
            pnlGelirBaslik.TabIndex = 121;
            // 
            // pcBoxSil
            // 
            pcBoxSil.Cursor = Cursors.Hand;
            pcBoxSil.Image = (Image)resources.GetObject("pcBoxSil.Image");
            pcBoxSil.Location = new Point(312, 219);
            pcBoxSil.Margin = new Padding(3, 4, 3, 4);
            pcBoxSil.Name = "pcBoxSil";
            pcBoxSil.Size = new Size(97, 87);
            pcBoxSil.SizeMode = PictureBoxSizeMode.StretchImage;
            pcBoxSil.TabIndex = 122;
            pcBoxSil.TabStop = false;
            pcBoxSil.Click += pcBoxSil_Click;
            // 
            // pcBoxGuncelle
            // 
            pcBoxGuncelle.Cursor = Cursors.Hand;
            pcBoxGuncelle.Image = (Image)resources.GetObject("pcBoxGuncelle.Image");
            pcBoxGuncelle.Location = new Point(416, 219);
            pcBoxGuncelle.Margin = new Padding(3, 4, 3, 4);
            pcBoxGuncelle.Name = "pcBoxGuncelle";
            pcBoxGuncelle.Size = new Size(97, 87);
            pcBoxGuncelle.SizeMode = PictureBoxSizeMode.StretchImage;
            pcBoxGuncelle.TabIndex = 123;
            pcBoxGuncelle.TabStop = false;
            pcBoxGuncelle.Click += pcBoxGuncelle_Click;
            // 
            // pcBoxKaydet
            // 
            pcBoxKaydet.Cursor = Cursors.Hand;
            pcBoxKaydet.Image = Properties.Resources.Kaydet1;
            pcBoxKaydet.Location = new Point(208, 219);
            pcBoxKaydet.Margin = new Padding(3, 4, 3, 4);
            pcBoxKaydet.Name = "pcBoxKaydet";
            pcBoxKaydet.Size = new Size(97, 87);
            pcBoxKaydet.SizeMode = PictureBoxSizeMode.StretchImage;
            pcBoxKaydet.TabIndex = 124;
            pcBoxKaydet.TabStop = false;
            pcBoxKaydet.Click += pcBoxKaydet_Click;
            // 
            // dgvTahminiGelirler
            // 
            dgvTahminiGelirler.AllowUserToAddRows = false;
            dgvTahminiGelirler.AllowUserToDeleteRows = false;
            dgvTahminiGelirler.AllowUserToResizeColumns = false;
            dgvTahminiGelirler.AllowUserToResizeRows = false;
            dgvTahminiGelirler.BackgroundColor = SystemColors.Control;
            dgvTahminiGelirler.BorderStyle = BorderStyle.Fixed3D;
            dgvTahminiGelirler.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dgvTahminiGelirler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTahminiGelirler.Location = new Point(15, 315);
            dgvTahminiGelirler.Margin = new Padding(3, 4, 3, 4);
            dgvTahminiGelirler.Name = "dgvTahminiGelirler";
            dgvTahminiGelirler.ReadOnly = true;
            dgvTahminiGelirler.RowHeadersWidth = 51;
            dgvTahminiGelirler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTahminiGelirler.Size = new Size(897, 513);
            dgvTahminiGelirler.TabIndex = 125;
            dgvTahminiGelirler.CellDoubleClick += dgvTahminiGelirler_CellDoubleClick;
            // 
            // lblYeniTutar
            // 
            lblYeniTutar.AutoSize = true;
            lblYeniTutar.Font = new Font("Verdana", 14.25F);
            lblYeniTutar.ImeMode = ImeMode.NoControl;
            lblYeniTutar.Location = new Point(752, 248);
            lblYeniTutar.Name = "lblYeniTutar";
            lblYeniTutar.Size = new Size(28, 29);
            lblYeniTutar.TabIndex = 109;
            lblYeniTutar.Text = "0";
            // 
            // lblKalanGelirTutari
            // 
            lblKalanGelirTutari.AutoSize = true;
            lblKalanGelirTutari.Font = new Font("Verdana", 14.25F);
            lblKalanGelirTutari.ImeMode = ImeMode.NoControl;
            lblKalanGelirTutari.Location = new Point(519, 248);
            lblKalanGelirTutari.Name = "lblKalanGelirTutari";
            lblKalanGelirTutari.Size = new Size(227, 29);
            lblKalanGelirTutari.TabIndex = 109;
            lblKalanGelirTutari.Text = "Kalan Gelir Tutarı:";
            // 
            // FrmTahminiGelir
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(926, 836);
            Controls.Add(dgvTahminiGelirler);
            Controls.Add(pcBoxSil);
            Controls.Add(pcBoxGuncelle);
            Controls.Add(pcBoxKaydet);
            Controls.Add(pnlGelirBaslik);
            Controls.Add(txtTutar);
            Controls.Add(lblYeniTutar);
            Controls.Add(lblKalanGelirTutari);
            Controls.Add(lblTutar);
            Controls.Add(cmbDegisiklik);
            Controls.Add(lblDegisiklik);
            Controls.Add(cmbGelirKategori);
            Controls.Add(lblGelirKategori);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmTahminiGelir";
            Text = "FrmTahminiGelir";
            Load += FrmTahminiGelir_Load;
            pnlGelirBaslik.ResumeLayout(false);
            pnlGelirBaslik.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pcBoxSil).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxGuncelle).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxKaydet).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvTahminiGelirler).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTutar;
        private Label lblTutar;
        private Label lblGelirKategori;
        private Label lblDegisiklik;
        private Label lblBaslik;
        private Panel pnlGelirBaslik;
        private PictureBox pcBoxSil;
        private PictureBox pcBoxGuncelle;
        private PictureBox pcBoxKaydet;
        public DataGridView dgvTahminiGelirler;
        private Label lblYeniTutar;
        private Label lblKalanGelirTutari;
        public ComboBox cmbGelirKategori;
        public ComboBox cmbDegisiklik;
    }
}