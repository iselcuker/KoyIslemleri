namespace Forms
{
    partial class FrmEkGider
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEkGider));
            lblDegisiklik = new Label();
            cmbDegisiklik = new ComboBox();
            pnlGiderBaslik = new Panel();
            lblBaslik = new Label();
            lblTutar = new Label();
            cmbGiderAltKategori = new ComboBox();
            lblGiderAltKategori = new Label();
            cmbGiderKategori = new ComboBox();
            lblGiderKategori = new Label();
            txtTutar = new TextBox();
            pcBoxSil = new PictureBox();
            pcBoxGuncelle = new PictureBox();
            pcBoxKaydet = new PictureBox();
            dgvTahminiEkGiderler = new DataGridView();
            pnlGiderBaslik.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pcBoxSil).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxGuncelle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxKaydet).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvTahminiEkGiderler).BeginInit();
            SuspendLayout();
            // 
            // lblDegisiklik
            // 
            lblDegisiklik.AutoSize = true;
            lblDegisiklik.Font = new Font("Lucida Calligraphy", 14.25F);
            lblDegisiklik.ImeMode = ImeMode.NoControl;
            lblDegisiklik.Location = new Point(10, 143);
            lblDegisiklik.Name = "lblDegisiklik";
            lblDegisiklik.Size = new Size(109, 24);
            lblDegisiklik.TabIndex = 147;
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
            cmbDegisiklik.Location = new Point(217, 140);
            cmbDegisiklik.Name = "cmbDegisiklik";
            cmbDegisiklik.Size = new Size(396, 31);
            cmbDegisiklik.TabIndex = 146;
            // 
            // pnlGiderBaslik
            // 
            pnlGiderBaslik.Controls.Add(lblBaslik);
            pnlGiderBaslik.Dock = DockStyle.Top;
            pnlGiderBaslik.Location = new Point(0, 0);
            pnlGiderBaslik.Name = "pnlGiderBaslik";
            pnlGiderBaslik.Size = new Size(807, 60);
            pnlGiderBaslik.TabIndex = 145;
            // 
            // lblBaslik
            // 
            lblBaslik.AutoSize = true;
            lblBaslik.Font = new Font("321impact", 35.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblBaslik.Location = new Point(285, 4);
            lblBaslik.Name = "lblBaslik";
            lblBaslik.Size = new Size(201, 53);
            lblBaslik.TabIndex = 1;
            lblBaslik.Text = "EK GİDER";
            // 
            // lblTutar
            // 
            lblTutar.AutoSize = true;
            lblTutar.Font = new Font("Lucida Calligraphy", 14.25F);
            lblTutar.ImeMode = ImeMode.NoControl;
            lblTutar.Location = new Point(10, 181);
            lblTutar.Name = "lblTutar";
            lblTutar.Size = new Size(70, 24);
            lblTutar.TabIndex = 140;
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
            cmbGiderAltKategori.Location = new Point(217, 103);
            cmbGiderAltKategori.Name = "cmbGiderAltKategori";
            cmbGiderAltKategori.Size = new Size(396, 31);
            cmbGiderAltKategori.TabIndex = 135;
            cmbGiderAltKategori.SelectedIndexChanged += cmbGiderAltKategori_SelectedIndexChanged;
            // 
            // lblGiderAltKategori
            // 
            lblGiderAltKategori.AutoSize = true;
            lblGiderAltKategori.Font = new Font("Lucida Calligraphy", 14.25F);
            lblGiderAltKategori.ImeMode = ImeMode.NoControl;
            lblGiderAltKategori.Location = new Point(10, 106);
            lblGiderAltKategori.Name = "lblGiderAltKategori";
            lblGiderAltKategori.Size = new Size(203, 24);
            lblGiderAltKategori.TabIndex = 138;
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
            cmbGiderKategori.Location = new Point(217, 66);
            cmbGiderKategori.Name = "cmbGiderKategori";
            cmbGiderKategori.Size = new Size(396, 31);
            cmbGiderKategori.TabIndex = 136;
            cmbGiderKategori.SelectedIndexChanged += cmbGiderKategori_SelectedIndexChanged;
            // 
            // lblGiderKategori
            // 
            lblGiderKategori.AutoSize = true;
            lblGiderKategori.Font = new Font("Lucida Calligraphy", 14.25F);
            lblGiderKategori.ImeMode = ImeMode.NoControl;
            lblGiderKategori.Location = new Point(10, 69);
            lblGiderKategori.Name = "lblGiderKategori";
            lblGiderKategori.Size = new Size(163, 24);
            lblGiderKategori.TabIndex = 139;
            lblGiderKategori.Text = "Gider Kategori";
            // 
            // txtTutar
            // 
            txtTutar.Cursor = Cursors.IBeam;
            txtTutar.Font = new Font("Lucida Calligraphy", 14.25F);
            txtTutar.Location = new Point(217, 177);
            txtTutar.Name = "txtTutar";
            txtTutar.Size = new Size(209, 33);
            txtTutar.TabIndex = 137;
            // 
            // pcBoxSil
            // 
            pcBoxSil.Cursor = Cursors.Hand;
            pcBoxSil.Image = (Image)resources.GetObject("pcBoxSil.Image");
            pcBoxSil.Location = new Point(308, 216);
            pcBoxSil.Name = "pcBoxSil";
            pcBoxSil.Size = new Size(85, 65);
            pcBoxSil.SizeMode = PictureBoxSizeMode.StretchImage;
            pcBoxSil.TabIndex = 148;
            pcBoxSil.TabStop = false;
            pcBoxSil.Click += pcBoxSil_Click;
            // 
            // pcBoxGuncelle
            // 
            pcBoxGuncelle.Cursor = Cursors.Hand;
            pcBoxGuncelle.Image = (Image)resources.GetObject("pcBoxGuncelle.Image");
            pcBoxGuncelle.Location = new Point(399, 216);
            pcBoxGuncelle.Name = "pcBoxGuncelle";
            pcBoxGuncelle.Size = new Size(85, 65);
            pcBoxGuncelle.SizeMode = PictureBoxSizeMode.StretchImage;
            pcBoxGuncelle.TabIndex = 149;
            pcBoxGuncelle.TabStop = false;
            pcBoxGuncelle.Click += pcBoxGuncelle_Click;
            // 
            // pcBoxKaydet
            // 
            pcBoxKaydet.Cursor = Cursors.Hand;
            pcBoxKaydet.Image = Properties.Resources.Kaydet1;
            pcBoxKaydet.Location = new Point(217, 216);
            pcBoxKaydet.Name = "pcBoxKaydet";
            pcBoxKaydet.Size = new Size(85, 65);
            pcBoxKaydet.SizeMode = PictureBoxSizeMode.StretchImage;
            pcBoxKaydet.TabIndex = 150;
            pcBoxKaydet.TabStop = false;
            pcBoxKaydet.Click += pcBoxKaydet_Click;
            // 
            // dgvTahminiEkGiderler
            // 
            dgvTahminiEkGiderler.BackgroundColor = SystemColors.Control;
            dgvTahminiEkGiderler.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dgvTahminiEkGiderler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTahminiEkGiderler.Location = new Point(10, 296);
            dgvTahminiEkGiderler.Name = "dgvTahminiEkGiderler";
            dgvTahminiEkGiderler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTahminiEkGiderler.Size = new Size(792, 325);
            dgvTahminiEkGiderler.TabIndex = 151;
            dgvTahminiEkGiderler.CellDoubleClick += dgvTahminiEkGiderler_CellDoubleClick;
            // 
            // FrmEkGider
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(807, 705);
            Controls.Add(dgvTahminiEkGiderler);
            Controls.Add(pcBoxSil);
            Controls.Add(pcBoxGuncelle);
            Controls.Add(pcBoxKaydet);
            Controls.Add(lblDegisiklik);
            Controls.Add(cmbDegisiklik);
            Controls.Add(pnlGiderBaslik);
            Controls.Add(lblTutar);
            Controls.Add(cmbGiderAltKategori);
            Controls.Add(lblGiderAltKategori);
            Controls.Add(cmbGiderKategori);
            Controls.Add(lblGiderKategori);
            Controls.Add(txtTutar);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmEkGider";
            Text = "FrmEkGider";
            Load += FrmEkGider_Load;
            pnlGiderBaslik.ResumeLayout(false);
            pnlGiderBaslik.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pcBoxSil).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxGuncelle).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxKaydet).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvTahminiEkGiderler).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDegisiklik;
        private ComboBox cmbDegisiklik;
        private Panel pnlGiderBaslik;
        private Label lblBaslik;
        private Label lblTutar;
        private ComboBox cmbGiderAltKategori;
        private Label lblGiderAltKategori;
        private ComboBox cmbGiderKategori;
        private Label lblGiderKategori;
        private TextBox txtTutar;
        private PictureBox pcBoxSil;
        private PictureBox pcBoxGuncelle;
        private PictureBox pcBoxKaydet;
        public DataGridView dgvTahminiEkGiderler;
    }
}