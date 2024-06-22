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
            lblDegisiklik.Font = new Font("Verdana", 14.25F);
            lblDegisiklik.ImeMode = ImeMode.NoControl;
            lblDegisiklik.Location = new Point(11, 191);
            lblDegisiklik.Name = "lblDegisiklik";
            lblDegisiklik.Size = new Size(126, 29);
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
            cmbDegisiklik.Location = new Point(248, 187);
            cmbDegisiklik.Margin = new Padding(3, 4, 3, 4);
            cmbDegisiklik.Name = "cmbDegisiklik";
            cmbDegisiklik.Size = new Size(452, 37);
            cmbDegisiklik.TabIndex = 146;
            // 
            // pnlGiderBaslik
            // 
            pnlGiderBaslik.Controls.Add(lblBaslik);
            pnlGiderBaslik.Dock = DockStyle.Top;
            pnlGiderBaslik.Location = new Point(0, 0);
            pnlGiderBaslik.Margin = new Padding(3, 4, 3, 4);
            pnlGiderBaslik.Name = "pnlGiderBaslik";
            pnlGiderBaslik.Size = new Size(922, 80);
            pnlGiderBaslik.TabIndex = 145;
            // 
            // lblBaslik
            // 
            lblBaslik.AutoSize = true;
            lblBaslik.Font = new Font("321impact", 35.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblBaslik.Location = new Point(326, 5);
            lblBaslik.Name = "lblBaslik";
            lblBaslik.Size = new Size(254, 67);
            lblBaslik.TabIndex = 1;
            lblBaslik.Text = "EK GİDER";
            // 
            // lblTutar
            // 
            lblTutar.AutoSize = true;
            lblTutar.Font = new Font("Verdana", 14.25F);
            lblTutar.ImeMode = ImeMode.NoControl;
            lblTutar.Location = new Point(11, 241);
            lblTutar.Name = "lblTutar";
            lblTutar.Size = new Size(74, 29);
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
            cmbGiderAltKategori.Location = new Point(248, 137);
            cmbGiderAltKategori.Margin = new Padding(3, 4, 3, 4);
            cmbGiderAltKategori.Name = "cmbGiderAltKategori";
            cmbGiderAltKategori.Size = new Size(452, 37);
            cmbGiderAltKategori.TabIndex = 135;
            cmbGiderAltKategori.SelectedIndexChanged += cmbGiderAltKategori_SelectedIndexChanged;
            // 
            // lblGiderAltKategori
            // 
            lblGiderAltKategori.AutoSize = true;
            lblGiderAltKategori.Font = new Font("Verdana", 14.25F);
            lblGiderAltKategori.ImeMode = ImeMode.NoControl;
            lblGiderAltKategori.Location = new Point(11, 141);
            lblGiderAltKategori.Name = "lblGiderAltKategori";
            lblGiderAltKategori.Size = new Size(223, 29);
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
            cmbGiderKategori.Location = new Point(248, 88);
            cmbGiderKategori.Margin = new Padding(3, 4, 3, 4);
            cmbGiderKategori.Name = "cmbGiderKategori";
            cmbGiderKategori.Size = new Size(452, 37);
            cmbGiderKategori.TabIndex = 136;
            cmbGiderKategori.SelectedIndexChanged += cmbGiderKategori_SelectedIndexChanged;
            // 
            // lblGiderKategori
            // 
            lblGiderKategori.AutoSize = true;
            lblGiderKategori.Font = new Font("Verdana", 14.25F);
            lblGiderKategori.ImeMode = ImeMode.NoControl;
            lblGiderKategori.Location = new Point(11, 92);
            lblGiderKategori.Name = "lblGiderKategori";
            lblGiderKategori.Size = new Size(184, 29);
            lblGiderKategori.TabIndex = 139;
            lblGiderKategori.Text = "Gider Kategori";
            // 
            // txtTutar
            // 
            txtTutar.Cursor = Cursors.IBeam;
            txtTutar.Font = new Font("Lucida Calligraphy", 14.25F);
            txtTutar.Location = new Point(248, 236);
            txtTutar.Margin = new Padding(3, 4, 3, 4);
            txtTutar.Name = "txtTutar";
            txtTutar.Size = new Size(238, 40);
            txtTutar.TabIndex = 137;
            // 
            // pcBoxSil
            // 
            pcBoxSil.Cursor = Cursors.Hand;
            pcBoxSil.Image = (Image)resources.GetObject("pcBoxSil.Image");
            pcBoxSil.Location = new Point(352, 288);
            pcBoxSil.Margin = new Padding(3, 4, 3, 4);
            pcBoxSil.Name = "pcBoxSil";
            pcBoxSil.Size = new Size(97, 87);
            pcBoxSil.SizeMode = PictureBoxSizeMode.StretchImage;
            pcBoxSil.TabIndex = 148;
            pcBoxSil.TabStop = false;
            pcBoxSil.Click += pcBoxSil_Click;
            // 
            // pcBoxGuncelle
            // 
            pcBoxGuncelle.Cursor = Cursors.Hand;
            pcBoxGuncelle.Image = (Image)resources.GetObject("pcBoxGuncelle.Image");
            pcBoxGuncelle.Location = new Point(456, 288);
            pcBoxGuncelle.Margin = new Padding(3, 4, 3, 4);
            pcBoxGuncelle.Name = "pcBoxGuncelle";
            pcBoxGuncelle.Size = new Size(97, 87);
            pcBoxGuncelle.SizeMode = PictureBoxSizeMode.StretchImage;
            pcBoxGuncelle.TabIndex = 149;
            pcBoxGuncelle.TabStop = false;
            pcBoxGuncelle.Click += pcBoxGuncelle_Click;
            // 
            // pcBoxKaydet
            // 
            pcBoxKaydet.Cursor = Cursors.Hand;
            pcBoxKaydet.Image = Properties.Resources.Kaydet1;
            pcBoxKaydet.Location = new Point(248, 288);
            pcBoxKaydet.Margin = new Padding(3, 4, 3, 4);
            pcBoxKaydet.Name = "pcBoxKaydet";
            pcBoxKaydet.Size = new Size(97, 87);
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
            dgvTahminiEkGiderler.Location = new Point(11, 395);
            dgvTahminiEkGiderler.Margin = new Padding(3, 4, 3, 4);
            dgvTahminiEkGiderler.Name = "dgvTahminiEkGiderler";
            dgvTahminiEkGiderler.RowHeadersWidth = 51;
            dgvTahminiEkGiderler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTahminiEkGiderler.Size = new Size(905, 433);
            dgvTahminiEkGiderler.TabIndex = 151;
            dgvTahminiEkGiderler.CellDoubleClick += dgvTahminiEkGiderler_CellDoubleClick;
            // 
            // FrmEkGider
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(922, 940);
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
            Margin = new Padding(3, 4, 3, 4);
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