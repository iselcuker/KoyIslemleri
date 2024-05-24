namespace Forms
{
    partial class FrmTahminiIdariIsler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTahminiIdariIsler));
            lblTutar = new Label();
            cmbIdariIslerAltKategori = new ComboBox();
            lblIdariAltKategori = new Label();
            cmbIdariIslerKategori = new ComboBox();
            lblIdariKategori = new Label();
            txtTutar = new TextBox();
            dgvTahminiIdariIsler = new DataGridView();
            lblBaslik = new Label();
            pnlGiderBaslik = new Panel();
            pcBoxSil = new PictureBox();
            pcBoxGuncelle = new PictureBox();
            pcBoxKaydet = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dgvTahminiIdariIsler).BeginInit();
            pnlGiderBaslik.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pcBoxSil).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxGuncelle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxKaydet).BeginInit();
            SuspendLayout();
            // 
            // lblTutar
            // 
            lblTutar.AutoSize = true;
            lblTutar.Font = new Font("Lucida Calligraphy", 14.25F);
            lblTutar.ImeMode = ImeMode.NoControl;
            lblTutar.Location = new Point(10, 192);
            lblTutar.Name = "lblTutar";
            lblTutar.Size = new Size(70, 24);
            lblTutar.TabIndex = 138;
            lblTutar.Text = "Tutar";
            // 
            // cmbIdariIslerAltKategori
            // 
            cmbIdariIslerAltKategori.BackColor = SystemColors.Control;
            cmbIdariIslerAltKategori.Cursor = Cursors.Hand;
            cmbIdariIslerAltKategori.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbIdariIslerAltKategori.Font = new Font("Verdana", 14.25F);
            cmbIdariIslerAltKategori.ForeColor = SystemColors.MenuText;
            cmbIdariIslerAltKategori.FormattingEnabled = true;
            cmbIdariIslerAltKategori.Location = new Point(217, 150);
            cmbIdariIslerAltKategori.Name = "cmbIdariIslerAltKategori";
            cmbIdariIslerAltKategori.Size = new Size(396, 31);
            cmbIdariIslerAltKategori.TabIndex = 133;
            // 
            // lblIdariAltKategori
            // 
            lblIdariAltKategori.AutoSize = true;
            lblIdariAltKategori.Font = new Font("Lucida Calligraphy", 14.25F);
            lblIdariAltKategori.ImeMode = ImeMode.NoControl;
            lblIdariAltKategori.Location = new Point(10, 155);
            lblIdariAltKategori.Name = "lblIdariAltKategori";
            lblIdariAltKategori.Size = new Size(196, 24);
            lblIdariAltKategori.TabIndex = 136;
            lblIdariAltKategori.Text = "İdari Alt Kategori";
            // 
            // cmbIdariIslerKategori
            // 
            cmbIdariIslerKategori.BackColor = SystemColors.Control;
            cmbIdariIslerKategori.Cursor = Cursors.Hand;
            cmbIdariIslerKategori.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbIdariIslerKategori.Font = new Font("Verdana", 14.25F);
            cmbIdariIslerKategori.ForeColor = SystemColors.MenuText;
            cmbIdariIslerKategori.FormattingEnabled = true;
            cmbIdariIslerKategori.Location = new Point(217, 112);
            cmbIdariIslerKategori.Name = "cmbIdariIslerKategori";
            cmbIdariIslerKategori.Size = new Size(396, 31);
            cmbIdariIslerKategori.TabIndex = 134;
            cmbIdariIslerKategori.SelectedIndexChanged += cmbIdariIslerKategori_SelectedIndexChanged_1;
            // 
            // lblIdariKategori
            // 
            lblIdariKategori.AutoSize = true;
            lblIdariKategori.Font = new Font("Lucida Calligraphy", 14.25F);
            lblIdariKategori.ImeMode = ImeMode.NoControl;
            lblIdariKategori.Location = new Point(10, 120);
            lblIdariKategori.Name = "lblIdariKategori";
            lblIdariKategori.Size = new Size(202, 24);
            lblIdariKategori.TabIndex = 137;
            lblIdariKategori.Text = "İdari İşler Kategori";
            // 
            // txtTutar
            // 
            txtTutar.Cursor = Cursors.IBeam;
            txtTutar.Font = new Font("Lucida Calligraphy", 14.25F);
            txtTutar.Location = new Point(217, 190);
            txtTutar.Name = "txtTutar";
            txtTutar.Size = new Size(209, 33);
            txtTutar.TabIndex = 135;
            // 
            // dgvTahminiIdariIsler
            // 
            dgvTahminiIdariIsler.BackgroundColor = SystemColors.Control;
            dgvTahminiIdariIsler.BorderStyle = BorderStyle.Fixed3D;
            dgvTahminiIdariIsler.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dgvTahminiIdariIsler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTahminiIdariIsler.Dock = DockStyle.Bottom;
            dgvTahminiIdariIsler.Location = new Point(0, 315);
            dgvTahminiIdariIsler.Name = "dgvTahminiIdariIsler";
            dgvTahminiIdariIsler.Size = new Size(807, 390);
            dgvTahminiIdariIsler.TabIndex = 142;
            // 
            // lblBaslik
            // 
            lblBaslik.AutoSize = true;
            lblBaslik.Font = new Font("321impact", 50.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblBaslik.Location = new Point(84, 9);
            lblBaslik.Name = "lblBaslik";
            lblBaslik.Size = new Size(641, 76);
            lblBaslik.TabIndex = 1;
            lblBaslik.Text = "TAHMİNİ İDARİ İŞLER";
            // 
            // pnlGiderBaslik
            // 
            pnlGiderBaslik.Controls.Add(lblBaslik);
            pnlGiderBaslik.Dock = DockStyle.Top;
            pnlGiderBaslik.Location = new Point(0, 0);
            pnlGiderBaslik.Name = "pnlGiderBaslik";
            pnlGiderBaslik.Size = new Size(807, 91);
            pnlGiderBaslik.TabIndex = 143;
            // 
            // pcBoxSil
            // 
            pcBoxSil.Cursor = Cursors.Hand;
            pcBoxSil.Image = (Image)resources.GetObject("pcBoxSil.Image");
            pcBoxSil.Location = new Point(308, 229);
            pcBoxSil.Name = "pcBoxSil";
            pcBoxSil.Size = new Size(85, 65);
            pcBoxSil.SizeMode = PictureBoxSizeMode.StretchImage;
            pcBoxSil.TabIndex = 144;
            pcBoxSil.TabStop = false;
            // 
            // pcBoxGuncelle
            // 
            pcBoxGuncelle.Cursor = Cursors.Hand;
            pcBoxGuncelle.Image = (Image)resources.GetObject("pcBoxGuncelle.Image");
            pcBoxGuncelle.Location = new Point(399, 230);
            pcBoxGuncelle.Name = "pcBoxGuncelle";
            pcBoxGuncelle.Size = new Size(85, 65);
            pcBoxGuncelle.SizeMode = PictureBoxSizeMode.StretchImage;
            pcBoxGuncelle.TabIndex = 145;
            pcBoxGuncelle.TabStop = false;
            // 
            // pcBoxKaydet
            // 
            pcBoxKaydet.Cursor = Cursors.Hand;
            pcBoxKaydet.Image = Properties.Resources.Kaydet1;
            pcBoxKaydet.Location = new Point(217, 229);
            pcBoxKaydet.Name = "pcBoxKaydet";
            pcBoxKaydet.Size = new Size(85, 65);
            pcBoxKaydet.SizeMode = PictureBoxSizeMode.StretchImage;
            pcBoxKaydet.TabIndex = 146;
            pcBoxKaydet.TabStop = false;
            // 
            // FrmTahminiIdariIsler
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(807, 705);
            Controls.Add(pcBoxSil);
            Controls.Add(pcBoxGuncelle);
            Controls.Add(pcBoxKaydet);
            Controls.Add(lblTutar);
            Controls.Add(cmbIdariIslerAltKategori);
            Controls.Add(lblIdariAltKategori);
            Controls.Add(cmbIdariIslerKategori);
            Controls.Add(lblIdariKategori);
            Controls.Add(txtTutar);
            Controls.Add(dgvTahminiIdariIsler);
            Controls.Add(pnlGiderBaslik);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmTahminiIdariIsler";
            Text = "FrmTahminiIdariIsler";
            Load += FrmTahminiIdariIsler_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTahminiIdariIsler).EndInit();
            pnlGiderBaslik.ResumeLayout(false);
            pnlGiderBaslik.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pcBoxSil).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxGuncelle).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxKaydet).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblTutar;
        private ComboBox cmbIdariIslerAltKategori;
        private Label lblIdariAltKategori;
        private ComboBox cmbIdariIslerKategori;
        private Label lblIdariKategori;
        private TextBox txtTutar;
        public DataGridView dgvTahminiIdariIsler;
        private Label lblBaslik;
        private Panel pnlGiderBaslik;
        private PictureBox pcBoxSil;
        private PictureBox pcBoxGuncelle;
        private PictureBox pcBoxKaydet;
    }
}