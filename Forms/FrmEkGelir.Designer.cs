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
            label6 = new Label();
            cmbDegisiklik = new ComboBox();
            lblDegisiklik = new Label();
            cmbGelirKategori = new ComboBox();
            label1 = new Label();
            txtTutar = new TextBox();
            pcBoxSil = new PictureBox();
            pcBoxGuncelle = new PictureBox();
            pcBoxKaydet = new PictureBox();
            dgvTahminiEkGelirler = new DataGridView();
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
            pnlGelirBaslik.Name = "pnlGelirBaslik";
            pnlGelirBaslik.Size = new Size(807, 60);
            pnlGelirBaslik.TabIndex = 132;
            // 
            // lblBaslik
            // 
            lblBaslik.AutoSize = true;
            lblBaslik.Font = new Font("321impact", 35.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblBaslik.Location = new Point(275, 3);
            lblBaslik.Name = "lblBaslik";
            lblBaslik.Size = new Size(195, 53);
            lblBaslik.TabIndex = 1;
            lblBaslik.Text = "EK GELİR";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Verdana", 14.25F);
            label6.ImeMode = ImeMode.NoControl;
            label6.Location = new Point(9, 148);
            label6.Name = "label6";
            label6.Size = new Size(58, 23);
            label6.TabIndex = 127;
            label6.Text = "Tutar";
            // 
            // cmbDegisiklik
            // 
            cmbDegisiklik.BackColor = SystemColors.Control;
            cmbDegisiklik.Cursor = Cursors.Hand;
            cmbDegisiklik.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDegisiklik.Font = new Font("Verdana", 14.25F);
            cmbDegisiklik.ForeColor = SystemColors.MenuText;
            cmbDegisiklik.FormattingEnabled = true;
            cmbDegisiklik.Location = new Point(176, 106);
            cmbDegisiklik.Name = "cmbDegisiklik";
            cmbDegisiklik.Size = new Size(396, 31);
            cmbDegisiklik.TabIndex = 122;
            // 
            // lblDegisiklik
            // 
            lblDegisiklik.AutoSize = true;
            lblDegisiklik.Font = new Font("Verdana", 14.25F);
            lblDegisiklik.ImeMode = ImeMode.NoControl;
            lblDegisiklik.Location = new Point(9, 111);
            lblDegisiklik.Name = "lblDegisiklik";
            lblDegisiklik.Size = new Size(104, 23);
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
            cmbGelirKategori.Location = new Point(176, 66);
            cmbGelirKategori.Name = "cmbGelirKategori";
            cmbGelirKategori.Size = new Size(396, 31);
            cmbGelirKategori.TabIndex = 123;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Verdana", 14.25F);
            label1.ImeMode = ImeMode.NoControl;
            label1.Location = new Point(9, 74);
            label1.Name = "label1";
            label1.Size = new Size(142, 23);
            label1.TabIndex = 126;
            label1.Text = "Gelir Kategori";
            // 
            // txtTutar
            // 
            txtTutar.Cursor = Cursors.IBeam;
            txtTutar.Font = new Font("Lucida Calligraphy", 14.25F);
            txtTutar.Location = new Point(176, 146);
            txtTutar.Name = "txtTutar";
            txtTutar.Size = new Size(209, 33);
            txtTutar.TabIndex = 124;
            // 
            // pcBoxSil
            // 
            pcBoxSil.Cursor = Cursors.Hand;
            pcBoxSil.Image = (Image)resources.GetObject("pcBoxSil.Image");
            pcBoxSil.Location = new Point(267, 185);
            pcBoxSil.Name = "pcBoxSil";
            pcBoxSil.Size = new Size(85, 65);
            pcBoxSil.SizeMode = PictureBoxSizeMode.StretchImage;
            pcBoxSil.TabIndex = 133;
            pcBoxSil.TabStop = false;
            // 
            // pcBoxGuncelle
            // 
            pcBoxGuncelle.Cursor = Cursors.Hand;
            pcBoxGuncelle.Image = (Image)resources.GetObject("pcBoxGuncelle.Image");
            pcBoxGuncelle.Location = new Point(358, 186);
            pcBoxGuncelle.Name = "pcBoxGuncelle";
            pcBoxGuncelle.Size = new Size(85, 65);
            pcBoxGuncelle.SizeMode = PictureBoxSizeMode.StretchImage;
            pcBoxGuncelle.TabIndex = 134;
            pcBoxGuncelle.TabStop = false;
            // 
            // pcBoxKaydet
            // 
            pcBoxKaydet.Cursor = Cursors.Hand;
            pcBoxKaydet.Image = Properties.Resources.Kaydet1;
            pcBoxKaydet.Location = new Point(176, 185);
            pcBoxKaydet.Name = "pcBoxKaydet";
            pcBoxKaydet.Size = new Size(85, 65);
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
            dgvTahminiEkGelirler.Location = new Point(9, 257);
            dgvTahminiEkGelirler.Name = "dgvTahminiEkGelirler";
            dgvTahminiEkGelirler.ReadOnly = true;
            dgvTahminiEkGelirler.RowHeadersWidth = 51;
            dgvTahminiEkGelirler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTahminiEkGelirler.Size = new Size(785, 366);
            dgvTahminiEkGelirler.TabIndex = 136;
            // 
            // FrmEkGelir
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(807, 705);
            Controls.Add(dgvTahminiEkGelirler);
            Controls.Add(pcBoxSil);
            Controls.Add(pcBoxGuncelle);
            Controls.Add(pcBoxKaydet);
            Controls.Add(pnlGelirBaslik);
            Controls.Add(label6);
            Controls.Add(cmbDegisiklik);
            Controls.Add(lblDegisiklik);
            Controls.Add(cmbGelirKategori);
            Controls.Add(label1);
            Controls.Add(txtTutar);
            FormBorderStyle = FormBorderStyle.None;
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
        private Label label6;
        private ComboBox cmbDegisiklik;
        private Label lblDegisiklik;
        private ComboBox cmbGelirKategori;
        private Label label1;
        private TextBox txtTutar;
        private PictureBox pcBoxSil;
        private PictureBox pcBoxGuncelle;
        private PictureBox pcBoxKaydet;
        //public DataGridView dgvTahminiEkGelirler;
    }
}