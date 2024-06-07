namespace Forms
{
    partial class FrmTahminiGider
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTahminiGider));
            pnlGiderBaslik = new Panel();
            lblBaslik = new Label();
            dgvTahminiGiderler = new DataGridView();
            lblTutar = new Label();
            cmbGiderAltKategori = new ComboBox();
            lblGiderAltKategori = new Label();
            cmbGiderKategori = new ComboBox();
            lblGiderKategori = new Label();
            txtTutar = new TextBox();
            cmbDegisiklik = new ComboBox();
            lblDegisiklik = new Label();
            pcBoxSil = new PictureBox();
            pcBoxGuncelle = new PictureBox();
            pcBoxKaydet = new PictureBox();
            label1 = new Label();
            lblYeniTutar = new Label();
            pnlGiderBaslik.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTahminiGiderler).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxSil).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxGuncelle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxKaydet).BeginInit();
            SuspendLayout();
            // 
            // pnlGiderBaslik
            // 
            pnlGiderBaslik.Controls.Add(lblBaslik);
            pnlGiderBaslik.Dock = DockStyle.Top;
            pnlGiderBaslik.Location = new Point(0, 0);
            pnlGiderBaslik.Name = "pnlGiderBaslik";
            pnlGiderBaslik.Size = new Size(810, 55);
            pnlGiderBaslik.TabIndex = 132;
            // 
            // lblBaslik
            // 
            lblBaslik.AutoSize = true;
            lblBaslik.Font = new Font("321impact", 30F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblBaslik.Location = new Point(156, 5);
            lblBaslik.Name = "lblBaslik";
            lblBaslik.Size = new Size(280, 46);
            lblBaslik.TabIndex = 1;
            lblBaslik.Text = "TAHMİNİ GİDER";
            // 
            // dgvTahminiGiderler
            // 
            dgvTahminiGiderler.AllowUserToAddRows = false;
            dgvTahminiGiderler.AllowUserToDeleteRows = false;
            dgvTahminiGiderler.AllowUserToResizeColumns = false;
            dgvTahminiGiderler.AllowUserToResizeRows = false;
            dgvTahminiGiderler.BackgroundColor = SystemColors.Control;
            dgvTahminiGiderler.BorderStyle = BorderStyle.None;
            dgvTahminiGiderler.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dgvTahminiGiderler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTahminiGiderler.Location = new Point(8, 283);
            dgvTahminiGiderler.Name = "dgvTahminiGiderler";
            dgvTahminiGiderler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTahminiGiderler.Size = new Size(795, 330);
            dgvTahminiGiderler.TabIndex = 131;
            dgvTahminiGiderler.CellDoubleClick += dgvTahminiGiderler_CellDoubleClick;
            // 
            // lblTutar
            // 
            lblTutar.AutoSize = true;
            lblTutar.Font = new Font("Lucida Calligraphy", 14.25F);
            lblTutar.ImeMode = ImeMode.NoControl;
            lblTutar.Location = new Point(10, 174);
            lblTutar.Name = "lblTutar";
            lblTutar.Size = new Size(70, 24);
            lblTutar.TabIndex = 127;
            lblTutar.Text = "Tutar";
            // 
            // cmbGiderAltKategori
            // 
            cmbGiderAltKategori.BackColor = SystemColors.Control;
            cmbGiderAltKategori.Cursor = Cursors.Hand;
            cmbGiderAltKategori.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGiderAltKategori.Font = new Font("Verdana", 14.25F);
            cmbGiderAltKategori.ForeColor = SystemColors.MenuText;
            cmbGiderAltKategori.FormattingEnabled = true;
            cmbGiderAltKategori.Location = new Point(217, 97);
            cmbGiderAltKategori.Name = "cmbGiderAltKategori";
            cmbGiderAltKategori.Size = new Size(396, 31);
            cmbGiderAltKategori.TabIndex = 122;
            cmbGiderAltKategori.SelectedIndexChanged += cmbGiderAltKategori_SelectedIndexChanged;
            // 
            // lblGiderAltKategori
            // 
            lblGiderAltKategori.AutoSize = true;
            lblGiderAltKategori.Font = new Font("Lucida Calligraphy", 14.25F);
            lblGiderAltKategori.ImeMode = ImeMode.NoControl;
            lblGiderAltKategori.Location = new Point(10, 102);
            lblGiderAltKategori.Name = "lblGiderAltKategori";
            lblGiderAltKategori.Size = new Size(203, 24);
            lblGiderAltKategori.TabIndex = 125;
            lblGiderAltKategori.Text = "Gider Alt Kategori";
            // 
            // cmbGiderKategori
            // 
            cmbGiderKategori.BackColor = SystemColors.Control;
            cmbGiderKategori.Cursor = Cursors.Hand;
            cmbGiderKategori.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGiderKategori.Font = new Font("Verdana", 14.25F);
            cmbGiderKategori.ForeColor = SystemColors.MenuText;
            cmbGiderKategori.FormattingEnabled = true;
            cmbGiderKategori.Location = new Point(217, 60);
            cmbGiderKategori.Name = "cmbGiderKategori";
            cmbGiderKategori.Size = new Size(396, 31);
            cmbGiderKategori.TabIndex = 123;
            cmbGiderKategori.SelectedIndexChanged += cmbGiderKategori_SelectedIndexChanged;
            // 
            // lblGiderKategori
            // 
            lblGiderKategori.AutoSize = true;
            lblGiderKategori.Font = new Font("Lucida Calligraphy", 14.25F);
            lblGiderKategori.ImeMode = ImeMode.NoControl;
            lblGiderKategori.Location = new Point(10, 68);
            lblGiderKategori.Name = "lblGiderKategori";
            lblGiderKategori.Size = new Size(163, 24);
            lblGiderKategori.TabIndex = 126;
            lblGiderKategori.Text = "Gider Kategori";
            // 
            // txtTutar
            // 
            txtTutar.Cursor = Cursors.IBeam;
            txtTutar.Font = new Font("Lucida Calligraphy", 14.25F);
            txtTutar.Location = new Point(217, 172);
            txtTutar.Name = "txtTutar";
            txtTutar.Size = new Size(209, 33);
            txtTutar.TabIndex = 124;
            // 
            // cmbDegisiklik
            // 
            cmbDegisiklik.BackColor = SystemColors.Control;
            cmbDegisiklik.Cursor = Cursors.Hand;
            cmbDegisiklik.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDegisiklik.Font = new Font("Verdana", 14.25F);
            cmbDegisiklik.ForeColor = SystemColors.MenuText;
            cmbDegisiklik.FormattingEnabled = true;
            cmbDegisiklik.Location = new Point(217, 134);
            cmbDegisiklik.Name = "cmbDegisiklik";
            cmbDegisiklik.Size = new Size(396, 31);
            cmbDegisiklik.TabIndex = 133;
            // 
            // lblDegisiklik
            // 
            lblDegisiklik.AutoSize = true;
            lblDegisiklik.Font = new Font("Lucida Calligraphy", 14.25F);
            lblDegisiklik.ImeMode = ImeMode.NoControl;
            lblDegisiklik.Location = new Point(10, 139);
            lblDegisiklik.Name = "lblDegisiklik";
            lblDegisiklik.Size = new Size(109, 24);
            lblDegisiklik.TabIndex = 134;
            lblDegisiklik.Text = "Değişiklik";
            // 
            // pcBoxSil
            // 
            pcBoxSil.Cursor = Cursors.Hand;
            pcBoxSil.Image = (Image)resources.GetObject("pcBoxSil.Image");
            pcBoxSil.Location = new Point(308, 171);
            pcBoxSil.Name = "pcBoxSil";
            pcBoxSil.Size = new Size(85, 65);
            pcBoxSil.SizeMode = PictureBoxSizeMode.StretchImage;
            pcBoxSil.TabIndex = 135;
            pcBoxSil.TabStop = false;
            pcBoxSil.Click += pcBoxSil_Click;
            // 
            // pcBoxGuncelle
            // 
            pcBoxGuncelle.Cursor = Cursors.Hand;
            pcBoxGuncelle.Image = (Image)resources.GetObject("pcBoxGuncelle.Image");
            pcBoxGuncelle.Location = new Point(399, 171);
            pcBoxGuncelle.Name = "pcBoxGuncelle";
            pcBoxGuncelle.Size = new Size(85, 65);
            pcBoxGuncelle.SizeMode = PictureBoxSizeMode.StretchImage;
            pcBoxGuncelle.TabIndex = 136;
            pcBoxGuncelle.TabStop = false;
            pcBoxGuncelle.Click += pcBoxGuncelle_Click;
            // 
            // pcBoxKaydet
            // 
            pcBoxKaydet.Cursor = Cursors.Hand;
            pcBoxKaydet.Image = Properties.Resources.Kaydet1;
            pcBoxKaydet.Location = new Point(217, 171);
            pcBoxKaydet.Name = "pcBoxKaydet";
            pcBoxKaydet.Size = new Size(85, 65);
            pcBoxKaydet.SizeMode = PictureBoxSizeMode.StretchImage;
            pcBoxKaydet.TabIndex = 137;
            pcBoxKaydet.TabStop = false;
            pcBoxKaydet.Click += pcBoxKaydet_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 12F);
            label1.ImeMode = ImeMode.NoControl;
            label1.Location = new Point(547, 179);
            label1.Name = "label1";
            label1.Size = new Size(129, 19);
            label1.TabIndex = 127;
            label1.Text = "Kalan Gider Tutarı:";
            // 
            // lblYeniTutar
            // 
            lblYeniTutar.AutoSize = true;
            lblYeniTutar.Font = new Font("Calibri", 12F);
            lblYeniTutar.ImeMode = ImeMode.NoControl;
            lblYeniTutar.Location = new Point(682, 179);
            lblYeniTutar.Name = "lblYeniTutar";
            lblYeniTutar.Size = new Size(17, 19);
            lblYeniTutar.TabIndex = 127;
            lblYeniTutar.Text = "0";
            // 
            // FrmTahminiGider
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(810, 686);
            Controls.Add(pcBoxSil);
            Controls.Add(pcBoxGuncelle);
            Controls.Add(pcBoxKaydet);
            Controls.Add(cmbDegisiklik);
            Controls.Add(lblDegisiklik);
            Controls.Add(pnlGiderBaslik);
            Controls.Add(dgvTahminiGiderler);
            Controls.Add(lblYeniTutar);
            Controls.Add(label1);
            Controls.Add(lblTutar);
            Controls.Add(cmbGiderAltKategori);
            Controls.Add(lblGiderAltKategori);
            Controls.Add(cmbGiderKategori);
            Controls.Add(lblGiderKategori);
            Controls.Add(txtTutar);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmTahminiGider";
            Text = "FrmTahminiGider";
            Load += FrmTahminiGider_Load;
            pnlGiderBaslik.ResumeLayout(false);
            pnlGiderBaslik.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTahminiGiderler).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxSil).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxGuncelle).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxKaydet).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlGiderBaslik;
        private Label lblBaslik;
        public DataGridView dgvTahminiGiderler;
        private Label lblTutar;
        private ComboBox cmbGiderAltKategori;
        private Label lblGiderAltKategori;
        private ComboBox cmbGiderKategori;
        private Label lblGiderKategori;
        private TextBox txtTutar;
        private ComboBox cmbDegisiklik;
        private Label lblDegisiklik;
        private PictureBox pcBoxSil;
        private PictureBox pcBoxGuncelle;
        private PictureBox pcBoxKaydet;
        private Label label1;
        private Label lblYeniTutar;
    }
}