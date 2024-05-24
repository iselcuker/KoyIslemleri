namespace Forms
{
    partial class FrmGelir
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGelir));
            pnlGelirBaslik = new Panel();
            lblBaslik = new Label();
            mskTarih = new MaskedTextBox();
            txtEvrakNo = new TextBox();
            txtVeren = new TextBox();
            txtTutar = new TextBox();
            lblEvrakNo = new Label();
            lblTarih = new Label();
            lblVeren = new Label();
            lblTutar = new Label();
            dgvGelirler = new DataGridView();
            cmbGelirKategori = new ComboBox();
            lblGelirKategori = new Label();
            pcBoxSil = new PictureBox();
            pcBoxGuncelle = new PictureBox();
            pcBoxKaydet = new PictureBox();
            lblToplamGelir = new Label();
            lblDevir = new Label();
            lblYardim = new Label();
            lblIstikraz = new Label();
            lblResimHarc = new Label();
            lblTurluGelir = new Label();
            lblParaCezasi = new Label();
            lblKoyVakif = new Label();
            lblHasilat = new Label();
            lblDevirYazi = new Label();
            lblYardimYazi = new Label();
            lblIstikrazYazi = new Label();
            lblTurluGelirYazi = new Label();
            lblResimHarcYazi = new Label();
            lblKoyVakifYazi = new Label();
            lblParaCezasiYazi = new Label();
            lblHasilatYazi = new Label();
            pnlGelirBaslik.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGelirler).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxSil).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxGuncelle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxKaydet).BeginInit();
            SuspendLayout();
            // 
            // pnlGelirBaslik
            // 
            pnlGelirBaslik.Controls.Add(lblBaslik);
            pnlGelirBaslik.Dock = DockStyle.Top;
            pnlGelirBaslik.Location = new Point(0, 0);
            pnlGelirBaslik.Name = "pnlGelirBaslik";
            pnlGelirBaslik.Size = new Size(1250, 60);
            pnlGelirBaslik.TabIndex = 0;
            pnlGelirBaslik.Paint += pnlGelirBaslik_Paint;
            // 
            // lblBaslik
            // 
            lblBaslik.AutoSize = true;
            lblBaslik.Font = new Font("321impact", 35.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblBaslik.Location = new Point(182, 4);
            lblBaslik.Name = "lblBaslik";
            lblBaslik.Size = new Size(345, 53);
            lblBaslik.TabIndex = 1;
            lblBaslik.Text = "GELİR İŞLEMLERİ";
            // 
            // mskTarih
            // 
            mskTarih.Cursor = Cursors.IBeam;
            mskTarih.Font = new Font("Lucida Calligraphy", 14.25F);
            mskTarih.Location = new Point(191, 173);
            mskTarih.Mask = "00/00/0000";
            mskTarih.Name = "mskTarih";
            mskTarih.Size = new Size(103, 33);
            mskTarih.TabIndex = 96;
            mskTarih.ValidatingType = typeof(DateTime);
            // 
            // txtEvrakNo
            // 
            txtEvrakNo.Cursor = Cursors.IBeam;
            txtEvrakNo.Font = new Font("Lucida Calligraphy", 14.25F);
            txtEvrakNo.Location = new Point(191, 245);
            txtEvrakNo.Name = "txtEvrakNo";
            txtEvrakNo.Size = new Size(209, 33);
            txtEvrakNo.TabIndex = 98;
            // 
            // txtVeren
            // 
            txtVeren.Cursor = Cursors.IBeam;
            txtVeren.Font = new Font("Lucida Calligraphy", 14.25F);
            txtVeren.Location = new Point(191, 209);
            txtVeren.Name = "txtVeren";
            txtVeren.Size = new Size(267, 33);
            txtVeren.TabIndex = 97;
            txtVeren.TextChanged += txtVeren_TextChanged;
            // 
            // txtTutar
            // 
            txtTutar.Cursor = Cursors.IBeam;
            txtTutar.Font = new Font("Lucida Calligraphy", 14.25F);
            txtTutar.Location = new Point(191, 137);
            txtTutar.Name = "txtTutar";
            txtTutar.Size = new Size(209, 33);
            txtTutar.TabIndex = 95;
            // 
            // lblEvrakNo
            // 
            lblEvrakNo.AutoSize = true;
            lblEvrakNo.Font = new Font("Lucida Calligraphy", 14.25F);
            lblEvrakNo.ImeMode = ImeMode.NoControl;
            lblEvrakNo.Location = new Point(10, 248);
            lblEvrakNo.Name = "lblEvrakNo";
            lblEvrakNo.Size = new Size(110, 24);
            lblEvrakNo.TabIndex = 102;
            lblEvrakNo.Text = "Evrak No";
            // 
            // lblTarih
            // 
            lblTarih.AutoSize = true;
            lblTarih.Font = new Font("Lucida Calligraphy", 14.25F);
            lblTarih.ImeMode = ImeMode.NoControl;
            lblTarih.Location = new Point(10, 176);
            lblTarih.Name = "lblTarih";
            lblTarih.Size = new Size(68, 24);
            lblTarih.TabIndex = 103;
            lblTarih.Text = "Tarih";
            // 
            // lblVeren
            // 
            lblVeren.AutoSize = true;
            lblVeren.Font = new Font("Lucida Calligraphy", 14.25F);
            lblVeren.ImeMode = ImeMode.NoControl;
            lblVeren.Location = new Point(10, 212);
            lblVeren.Name = "lblVeren";
            lblVeren.Size = new Size(72, 24);
            lblVeren.TabIndex = 104;
            lblVeren.Text = "Veren";
            // 
            // lblTutar
            // 
            lblTutar.AutoSize = true;
            lblTutar.Font = new Font("Lucida Calligraphy", 14.25F);
            lblTutar.ImeMode = ImeMode.NoControl;
            lblTutar.Location = new Point(10, 140);
            lblTutar.Name = "lblTutar";
            lblTutar.Size = new Size(70, 24);
            lblTutar.TabIndex = 105;
            lblTutar.Text = "Tutar";
            // 
            // dgvGelirler
            // 
            dgvGelirler.AllowUserToAddRows = false;
            dgvGelirler.AllowUserToDeleteRows = false;
            dgvGelirler.AllowUserToResizeColumns = false;
            dgvGelirler.AllowUserToResizeRows = false;
            dgvGelirler.BackgroundColor = SystemColors.Control;
            dgvGelirler.BorderStyle = BorderStyle.Fixed3D;
            dgvGelirler.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dgvGelirler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGelirler.Location = new Point(12, 394);
            dgvGelirler.Name = "dgvGelirler";
            dgvGelirler.ReadOnly = true;
            dgvGelirler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGelirler.Size = new Size(1226, 424);
            dgvGelirler.TabIndex = 100;
            dgvGelirler.CellDoubleClick += dgvGelirler_CellDoubleClick;
            // 
            // cmbGelirKategori
            // 
            cmbGelirKategori.BackColor = SystemColors.Control;
            cmbGelirKategori.Cursor = Cursors.Hand;
            cmbGelirKategori.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGelirKategori.Font = new Font("Verdana", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbGelirKategori.ForeColor = SystemColors.MenuText;
            cmbGelirKategori.FormattingEnabled = true;
            cmbGelirKategori.Location = new Point(191, 100);
            cmbGelirKategori.Name = "cmbGelirKategori";
            cmbGelirKategori.Size = new Size(396, 31);
            cmbGelirKategori.TabIndex = 94;
            cmbGelirKategori.SelectedIndexChanged += cmbGelirKategori_SelectedIndexChanged;
            // 
            // lblGelirKategori
            // 
            lblGelirKategori.AutoSize = true;
            lblGelirKategori.Font = new Font("Lucida Calligraphy", 14.25F);
            lblGelirKategori.ImeMode = ImeMode.NoControl;
            lblGelirKategori.Location = new Point(10, 108);
            lblGelirKategori.Name = "lblGelirKategori";
            lblGelirKategori.Size = new Size(156, 24);
            lblGelirKategori.TabIndex = 99;
            lblGelirKategori.Text = "Gelir Kategori";
            // 
            // pcBoxSil
            // 
            pcBoxSil.Cursor = Cursors.Hand;
            pcBoxSil.Image = (Image)resources.GetObject("pcBoxSil.Image");
            pcBoxSil.Location = new Point(282, 284);
            pcBoxSil.Name = "pcBoxSil";
            pcBoxSil.Size = new Size(85, 65);
            pcBoxSil.SizeMode = PictureBoxSizeMode.StretchImage;
            pcBoxSil.TabIndex = 121;
            pcBoxSil.TabStop = false;
            pcBoxSil.Click += pcBoxSil_Click;
            // 
            // pcBoxGuncelle
            // 
            pcBoxGuncelle.Cursor = Cursors.Hand;
            pcBoxGuncelle.Image = (Image)resources.GetObject("pcBoxGuncelle.Image");
            pcBoxGuncelle.Location = new Point(373, 285);
            pcBoxGuncelle.Name = "pcBoxGuncelle";
            pcBoxGuncelle.Size = new Size(85, 65);
            pcBoxGuncelle.SizeMode = PictureBoxSizeMode.StretchImage;
            pcBoxGuncelle.TabIndex = 122;
            pcBoxGuncelle.TabStop = false;
            pcBoxGuncelle.Click += pcBoxGuncelle_Click;
            // 
            // pcBoxKaydet
            // 
            pcBoxKaydet.Cursor = Cursors.Hand;
            pcBoxKaydet.Image = Properties.Resources.Kaydet1;
            pcBoxKaydet.Location = new Point(191, 284);
            pcBoxKaydet.Name = "pcBoxKaydet";
            pcBoxKaydet.Size = new Size(85, 65);
            pcBoxKaydet.SizeMode = PictureBoxSizeMode.StretchImage;
            pcBoxKaydet.TabIndex = 123;
            pcBoxKaydet.TabStop = false;
            pcBoxKaydet.Click += pcBoxKaydet_Click;
            // 
            // lblToplamGelir
            // 
            lblToplamGelir.AutoSize = true;
            lblToplamGelir.Font = new Font("Lucida Calligraphy", 14.25F);
            lblToplamGelir.ImeMode = ImeMode.NoControl;
            lblToplamGelir.Location = new Point(24, 332);
            lblToplamGelir.Name = "lblToplamGelir";
            lblToplamGelir.Size = new Size(36, 24);
            lblToplamGelir.TabIndex = 124;
            lblToplamGelir.Text = "00";
            // 
            // lblDevir
            // 
            lblDevir.AutoSize = true;
            lblDevir.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblDevir.Location = new Point(878, 250);
            lblDevir.Name = "lblDevir";
            lblDevir.Size = new Size(26, 18);
            lblDevir.TabIndex = 153;
            lblDevir.Text = "00";
            // 
            // lblYardim
            // 
            lblYardim.AutoSize = true;
            lblYardim.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblYardim.Location = new Point(878, 166);
            lblYardim.Name = "lblYardim";
            lblYardim.Size = new Size(26, 18);
            lblYardim.TabIndex = 151;
            lblYardim.Text = "00";
            // 
            // lblIstikraz
            // 
            lblIstikraz.AutoSize = true;
            lblIstikraz.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblIstikraz.Location = new Point(878, 208);
            lblIstikraz.Name = "lblIstikraz";
            lblIstikraz.Size = new Size(26, 18);
            lblIstikraz.TabIndex = 149;
            lblIstikraz.Text = "00";
            // 
            // lblResimHarc
            // 
            lblResimHarc.AutoSize = true;
            lblResimHarc.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblResimHarc.Location = new Point(878, 124);
            lblResimHarc.Name = "lblResimHarc";
            lblResimHarc.Size = new Size(26, 18);
            lblResimHarc.TabIndex = 147;
            lblResimHarc.Text = "00";
            // 
            // lblTurluGelir
            // 
            lblTurluGelir.AutoSize = true;
            lblTurluGelir.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblTurluGelir.Location = new Point(878, 229);
            lblTurluGelir.Name = "lblTurluGelir";
            lblTurluGelir.Size = new Size(26, 18);
            lblTurluGelir.TabIndex = 145;
            lblTurluGelir.Text = "00";
            // 
            // lblParaCezasi
            // 
            lblParaCezasi.AutoSize = true;
            lblParaCezasi.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblParaCezasi.Location = new Point(878, 145);
            lblParaCezasi.Name = "lblParaCezasi";
            lblParaCezasi.Size = new Size(26, 18);
            lblParaCezasi.TabIndex = 143;
            lblParaCezasi.Text = "00";
            // 
            // lblKoyVakif
            // 
            lblKoyVakif.AutoSize = true;
            lblKoyVakif.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblKoyVakif.Location = new Point(878, 187);
            lblKoyVakif.Name = "lblKoyVakif";
            lblKoyVakif.Size = new Size(26, 18);
            lblKoyVakif.TabIndex = 141;
            lblKoyVakif.Text = "00";
            // 
            // lblHasilat
            // 
            lblHasilat.AutoSize = true;
            lblHasilat.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblHasilat.Location = new Point(878, 103);
            lblHasilat.Name = "lblHasilat";
            lblHasilat.Size = new Size(26, 18);
            lblHasilat.TabIndex = 140;
            lblHasilat.Text = "00";
            // 
            // lblDevirYazi
            // 
            lblDevirYazi.AutoSize = true;
            lblDevirYazi.BorderStyle = BorderStyle.FixedSingle;
            lblDevirYazi.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblDevirYazi.Location = new Point(707, 249);
            lblDevirYazi.Name = "lblDevirYazi";
            lblDevirYazi.Size = new Size(164, 20);
            lblDevirYazi.TabIndex = 138;
            lblDevirYazi.Text = "Geçen Seneden Devir";
            // 
            // lblYardimYazi
            // 
            lblYardimYazi.AutoSize = true;
            lblYardimYazi.BorderStyle = BorderStyle.FixedSingle;
            lblYardimYazi.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblYardimYazi.Location = new Point(707, 165);
            lblYardimYazi.Name = "lblYardimYazi";
            lblYardimYazi.Size = new Size(74, 20);
            lblYardimYazi.TabIndex = 136;
            lblYardimYazi.Text = "Yardımlar";
            // 
            // lblIstikrazYazi
            // 
            lblIstikrazYazi.AutoSize = true;
            lblIstikrazYazi.BorderStyle = BorderStyle.FixedSingle;
            lblIstikrazYazi.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblIstikrazYazi.Location = new Point(707, 207);
            lblIstikrazYazi.Name = "lblIstikrazYazi";
            lblIstikrazYazi.Size = new Size(75, 20);
            lblIstikrazYazi.TabIndex = 134;
            lblIstikrazYazi.Text = "İstikrazlar";
            // 
            // lblTurluGelirYazi
            // 
            lblTurluGelirYazi.AutoSize = true;
            lblTurluGelirYazi.BorderStyle = BorderStyle.FixedSingle;
            lblTurluGelirYazi.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblTurluGelirYazi.Location = new Point(707, 228);
            lblTurluGelirYazi.Name = "lblTurluGelirYazi";
            lblTurluGelirYazi.Size = new Size(97, 20);
            lblTurluGelirYazi.TabIndex = 131;
            lblTurluGelirYazi.Text = "Türlü Gelirler";
            // 
            // lblResimHarcYazi
            // 
            lblResimHarcYazi.AutoSize = true;
            lblResimHarcYazi.BorderStyle = BorderStyle.FixedSingle;
            lblResimHarcYazi.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblResimHarcYazi.Location = new Point(707, 123);
            lblResimHarcYazi.Name = "lblResimHarcYazi";
            lblResimHarcYazi.Size = new Size(96, 20);
            lblResimHarcYazi.TabIndex = 130;
            lblResimHarcYazi.Text = "Resim, Harç";
            // 
            // lblKoyVakifYazi
            // 
            lblKoyVakifYazi.AutoSize = true;
            lblKoyVakifYazi.BorderStyle = BorderStyle.FixedSingle;
            lblKoyVakifYazi.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblKoyVakifYazi.Location = new Point(707, 186);
            lblKoyVakifYazi.Name = "lblKoyVakifYazi";
            lblKoyVakifYazi.Size = new Size(75, 20);
            lblKoyVakifYazi.TabIndex = 127;
            lblKoyVakifYazi.Text = "Köy Vakıf";
            // 
            // lblParaCezasiYazi
            // 
            lblParaCezasiYazi.AutoSize = true;
            lblParaCezasiYazi.BorderStyle = BorderStyle.FixedSingle;
            lblParaCezasiYazi.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblParaCezasiYazi.Location = new Point(707, 144);
            lblParaCezasiYazi.Name = "lblParaCezasiYazi";
            lblParaCezasiYazi.Size = new Size(96, 20);
            lblParaCezasiYazi.TabIndex = 154;
            lblParaCezasiYazi.Text = "Para Cezası";
            // 
            // lblHasilatYazi
            // 
            lblHasilatYazi.AutoSize = true;
            lblHasilatYazi.BorderStyle = BorderStyle.FixedSingle;
            lblHasilatYazi.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblHasilatYazi.Location = new Point(707, 102);
            lblHasilatYazi.Name = "lblHasilatYazi";
            lblHasilatYazi.Size = new Size(57, 20);
            lblHasilatYazi.TabIndex = 155;
            lblHasilatYazi.Text = "Hasılat";
            // 
            // FrmGelir
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1250, 950);
            Controls.Add(lblDevir);
            Controls.Add(lblYardim);
            Controls.Add(lblIstikraz);
            Controls.Add(lblResimHarc);
            Controls.Add(lblTurluGelir);
            Controls.Add(lblParaCezasi);
            Controls.Add(lblKoyVakif);
            Controls.Add(lblHasilat);
            Controls.Add(lblDevirYazi);
            Controls.Add(lblYardimYazi);
            Controls.Add(lblIstikrazYazi);
            Controls.Add(lblTurluGelirYazi);
            Controls.Add(lblResimHarcYazi);
            Controls.Add(lblKoyVakifYazi);
            Controls.Add(lblParaCezasiYazi);
            Controls.Add(lblHasilatYazi);
            Controls.Add(lblToplamGelir);
            Controls.Add(pcBoxSil);
            Controls.Add(pcBoxGuncelle);
            Controls.Add(pcBoxKaydet);
            Controls.Add(mskTarih);
            Controls.Add(txtEvrakNo);
            Controls.Add(txtVeren);
            Controls.Add(txtTutar);
            Controls.Add(lblEvrakNo);
            Controls.Add(lblTarih);
            Controls.Add(lblVeren);
            Controls.Add(lblTutar);
            Controls.Add(dgvGelirler);
            Controls.Add(cmbGelirKategori);
            Controls.Add(lblGelirKategori);
            Controls.Add(pnlGelirBaslik);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmGelir";
            Text = "FrmGelir";
            Load += FrmGelir_Load;
            pnlGelirBaslik.ResumeLayout(false);
            pnlGelirBaslik.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGelirler).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxSil).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxGuncelle).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxKaydet).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlGelirBaslik;
        private Label lblBaslik;
        private MaskedTextBox mskTarih;
        private TextBox txtEvrakNo;
        private TextBox txtVeren;
        private TextBox txtTutar;
        private Label lblEvrakNo;
        private Label lblTarih;
        private Label lblVeren;
        private Label lblTutar;
        public DataGridView dgvGelirler;
        private ComboBox cmbGelirKategori;
        private Label lblGelirKategori;
        private PictureBox pcBoxSil;
        private PictureBox pcBoxGuncelle;
        private PictureBox pcBoxKaydet;
        public Label lblToplamGelir;
        private Label lblDevir;
        private Label lblYardim;
        private Label lblIstikraz;
        private Label lblResimHarc;
        private Label lblTurluGelir;
        private Label lblParaCezasi;
        private Label lblKoyVakif;
        private Label lblHasilat;
        private Label lblDevirYazi;
        private Label lblYardimYazi;
        private Label lblIstikrazYazi;
        private Label lblTurluGelirYazi;
        private Label lblResimHarcYazi;
        private Label lblKoyVakifYazi;
        private Label lblParaCezasiYazi;
        private Label lblHasilatYazi;
    }
}