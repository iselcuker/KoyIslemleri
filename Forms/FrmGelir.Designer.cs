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
            pnlGelirBaslik.Margin = new Padding(3, 4, 3, 4);
            pnlGelirBaslik.Name = "pnlGelirBaslik";
            pnlGelirBaslik.Size = new Size(1429, 80);
            pnlGelirBaslik.TabIndex = 0;
            pnlGelirBaslik.Paint += pnlGelirBaslik_Paint;
            // 
            // lblBaslik
            // 
            lblBaslik.AutoSize = true;
            lblBaslik.Font = new Font("321impact", 35.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblBaslik.Location = new Point(208, 5);
            lblBaslik.Name = "lblBaslik";
            lblBaslik.Size = new Size(436, 67);
            lblBaslik.TabIndex = 1;
            lblBaslik.Text = "GELİR İŞLEMLERİ";
            // 
            // mskTarih
            // 
            mskTarih.Cursor = Cursors.IBeam;
            mskTarih.Font = new Font("Lucida Calligraphy", 14.25F);
            mskTarih.Location = new Point(218, 231);
            mskTarih.Margin = new Padding(3, 4, 3, 4);
            mskTarih.Mask = "00/00/0000";
            mskTarih.Name = "mskTarih";
            mskTarih.Size = new Size(117, 40);
            mskTarih.TabIndex = 96;
            mskTarih.ValidatingType = typeof(DateTime);
            // 
            // txtEvrakNo
            // 
            txtEvrakNo.Cursor = Cursors.IBeam;
            txtEvrakNo.Font = new Font("Lucida Calligraphy", 14.25F);
            txtEvrakNo.Location = new Point(218, 327);
            txtEvrakNo.Margin = new Padding(3, 4, 3, 4);
            txtEvrakNo.Name = "txtEvrakNo";
            txtEvrakNo.Size = new Size(238, 40);
            txtEvrakNo.TabIndex = 98;
            // 
            // txtVeren
            // 
            txtVeren.Cursor = Cursors.IBeam;
            txtVeren.Font = new Font("Lucida Calligraphy", 14.25F);
            txtVeren.Location = new Point(218, 279);
            txtVeren.Margin = new Padding(3, 4, 3, 4);
            txtVeren.Name = "txtVeren";
            txtVeren.Size = new Size(305, 40);
            txtVeren.TabIndex = 97;
            txtVeren.TextChanged += txtVeren_TextChanged;
            // 
            // txtTutar
            // 
            txtTutar.Cursor = Cursors.IBeam;
            txtTutar.Font = new Font("Lucida Calligraphy", 14.25F);
            txtTutar.Location = new Point(218, 183);
            txtTutar.Margin = new Padding(3, 4, 3, 4);
            txtTutar.Name = "txtTutar";
            txtTutar.Size = new Size(238, 40);
            txtTutar.TabIndex = 95;
            // 
            // lblEvrakNo
            // 
            lblEvrakNo.AutoSize = true;
            lblEvrakNo.Font = new Font("Verdana", 14.25F);
            lblEvrakNo.ImeMode = ImeMode.NoControl;
            lblEvrakNo.Location = new Point(11, 331);
            lblEvrakNo.Name = "lblEvrakNo";
            lblEvrakNo.Size = new Size(121, 29);
            lblEvrakNo.TabIndex = 102;
            lblEvrakNo.Text = "Evrak No";
            // 
            // lblTarih
            // 
            lblTarih.AutoSize = true;
            lblTarih.Font = new Font("Verdana", 14.25F);
            lblTarih.ImeMode = ImeMode.NoControl;
            lblTarih.Location = new Point(11, 235);
            lblTarih.Name = "lblTarih";
            lblTarih.Size = new Size(70, 29);
            lblTarih.TabIndex = 103;
            lblTarih.Text = "Tarih";
            // 
            // lblVeren
            // 
            lblVeren.AutoSize = true;
            lblVeren.Font = new Font("Verdana", 14.25F);
            lblVeren.ImeMode = ImeMode.NoControl;
            lblVeren.Location = new Point(11, 283);
            lblVeren.Name = "lblVeren";
            lblVeren.Size = new Size(81, 29);
            lblVeren.TabIndex = 104;
            lblVeren.Text = "Veren";
            // 
            // lblTutar
            // 
            lblTutar.AutoSize = true;
            lblTutar.Font = new Font("Verdana", 14.25F);
            lblTutar.ImeMode = ImeMode.NoControl;
            lblTutar.Location = new Point(11, 187);
            lblTutar.Name = "lblTutar";
            lblTutar.Size = new Size(74, 29);
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
            dgvGelirler.Location = new Point(14, 525);
            dgvGelirler.Margin = new Padding(3, 4, 3, 4);
            dgvGelirler.Name = "dgvGelirler";
            dgvGelirler.ReadOnly = true;
            dgvGelirler.RowHeadersWidth = 51;
            dgvGelirler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGelirler.Size = new Size(1401, 565);
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
            cmbGelirKategori.Location = new Point(218, 133);
            cmbGelirKategori.Margin = new Padding(3, 4, 3, 4);
            cmbGelirKategori.Name = "cmbGelirKategori";
            cmbGelirKategori.Size = new Size(452, 37);
            cmbGelirKategori.TabIndex = 94;
            cmbGelirKategori.SelectedIndexChanged += cmbGelirKategori_SelectedIndexChanged;
            // 
            // lblGelirKategori
            // 
            lblGelirKategori.AutoSize = true;
            lblGelirKategori.Font = new Font("Verdana", 14.25F);
            lblGelirKategori.ImeMode = ImeMode.NoControl;
            lblGelirKategori.Location = new Point(11, 144);
            lblGelirKategori.Name = "lblGelirKategori";
            lblGelirKategori.Size = new Size(175, 29);
            lblGelirKategori.TabIndex = 99;
            lblGelirKategori.Text = "Gelir Kategori";
            // 
            // pcBoxSil
            // 
            pcBoxSil.Cursor = Cursors.Hand;
            pcBoxSil.Image = (Image)resources.GetObject("pcBoxSil.Image");
            pcBoxSil.Location = new Point(322, 379);
            pcBoxSil.Margin = new Padding(3, 4, 3, 4);
            pcBoxSil.Name = "pcBoxSil";
            pcBoxSil.Size = new Size(97, 87);
            pcBoxSil.SizeMode = PictureBoxSizeMode.StretchImage;
            pcBoxSil.TabIndex = 121;
            pcBoxSil.TabStop = false;
            pcBoxSil.Click += pcBoxSil_Click;
            // 
            // pcBoxGuncelle
            // 
            pcBoxGuncelle.Cursor = Cursors.Hand;
            pcBoxGuncelle.Image = (Image)resources.GetObject("pcBoxGuncelle.Image");
            pcBoxGuncelle.Location = new Point(426, 380);
            pcBoxGuncelle.Margin = new Padding(3, 4, 3, 4);
            pcBoxGuncelle.Name = "pcBoxGuncelle";
            pcBoxGuncelle.Size = new Size(97, 87);
            pcBoxGuncelle.SizeMode = PictureBoxSizeMode.StretchImage;
            pcBoxGuncelle.TabIndex = 122;
            pcBoxGuncelle.TabStop = false;
            pcBoxGuncelle.Click += pcBoxGuncelle_Click;
            // 
            // pcBoxKaydet
            // 
            pcBoxKaydet.Cursor = Cursors.Hand;
            pcBoxKaydet.Image = Properties.Resources.Kaydet1;
            pcBoxKaydet.Location = new Point(218, 379);
            pcBoxKaydet.Margin = new Padding(3, 4, 3, 4);
            pcBoxKaydet.Name = "pcBoxKaydet";
            pcBoxKaydet.Size = new Size(97, 87);
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
            lblToplamGelir.Location = new Point(27, 443);
            lblToplamGelir.Name = "lblToplamGelir";
            lblToplamGelir.Size = new Size(46, 31);
            lblToplamGelir.TabIndex = 124;
            lblToplamGelir.Text = "00";
            // 
            // lblDevir
            // 
            lblDevir.AutoSize = true;
            lblDevir.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblDevir.Location = new Point(1003, 333);
            lblDevir.Name = "lblDevir";
            lblDevir.Size = new Size(32, 23);
            lblDevir.TabIndex = 153;
            lblDevir.Text = "00";
            // 
            // lblYardim
            // 
            lblYardim.AutoSize = true;
            lblYardim.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblYardim.Location = new Point(1003, 221);
            lblYardim.Name = "lblYardim";
            lblYardim.Size = new Size(32, 23);
            lblYardim.TabIndex = 151;
            lblYardim.Text = "00";
            // 
            // lblIstikraz
            // 
            lblIstikraz.AutoSize = true;
            lblIstikraz.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblIstikraz.Location = new Point(1003, 277);
            lblIstikraz.Name = "lblIstikraz";
            lblIstikraz.Size = new Size(32, 23);
            lblIstikraz.TabIndex = 149;
            lblIstikraz.Text = "00";
            // 
            // lblResimHarc
            // 
            lblResimHarc.AutoSize = true;
            lblResimHarc.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblResimHarc.Location = new Point(1003, 165);
            lblResimHarc.Name = "lblResimHarc";
            lblResimHarc.Size = new Size(32, 23);
            lblResimHarc.TabIndex = 147;
            lblResimHarc.Text = "00";
            // 
            // lblTurluGelir
            // 
            lblTurluGelir.AutoSize = true;
            lblTurluGelir.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblTurluGelir.Location = new Point(1003, 305);
            lblTurluGelir.Name = "lblTurluGelir";
            lblTurluGelir.Size = new Size(32, 23);
            lblTurluGelir.TabIndex = 145;
            lblTurluGelir.Text = "00";
            // 
            // lblParaCezasi
            // 
            lblParaCezasi.AutoSize = true;
            lblParaCezasi.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblParaCezasi.Location = new Point(1003, 193);
            lblParaCezasi.Name = "lblParaCezasi";
            lblParaCezasi.Size = new Size(32, 23);
            lblParaCezasi.TabIndex = 143;
            lblParaCezasi.Text = "00";
            // 
            // lblKoyVakif
            // 
            lblKoyVakif.AutoSize = true;
            lblKoyVakif.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblKoyVakif.Location = new Point(1003, 249);
            lblKoyVakif.Name = "lblKoyVakif";
            lblKoyVakif.Size = new Size(32, 23);
            lblKoyVakif.TabIndex = 141;
            lblKoyVakif.Text = "00";
            // 
            // lblHasilat
            // 
            lblHasilat.AutoSize = true;
            lblHasilat.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblHasilat.Location = new Point(1003, 137);
            lblHasilat.Name = "lblHasilat";
            lblHasilat.Size = new Size(32, 23);
            lblHasilat.TabIndex = 140;
            lblHasilat.Text = "00";
            // 
            // lblDevirYazi
            // 
            lblDevirYazi.AutoSize = true;
            lblDevirYazi.BorderStyle = BorderStyle.FixedSingle;
            lblDevirYazi.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblDevirYazi.Location = new Point(808, 332);
            lblDevirYazi.Name = "lblDevirYazi";
            lblDevirYazi.Size = new Size(204, 25);
            lblDevirYazi.TabIndex = 138;
            lblDevirYazi.Text = "Geçen Seneden Devir";
            // 
            // lblYardimYazi
            // 
            lblYardimYazi.AutoSize = true;
            lblYardimYazi.BorderStyle = BorderStyle.FixedSingle;
            lblYardimYazi.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblYardimYazi.Location = new Point(808, 220);
            lblYardimYazi.Name = "lblYardimYazi";
            lblYardimYazi.Size = new Size(98, 25);
            lblYardimYazi.TabIndex = 136;
            lblYardimYazi.Text = "Yardımlar";
            // 
            // lblIstikrazYazi
            // 
            lblIstikrazYazi.AutoSize = true;
            lblIstikrazYazi.BorderStyle = BorderStyle.FixedSingle;
            lblIstikrazYazi.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblIstikrazYazi.Location = new Point(808, 276);
            lblIstikrazYazi.Name = "lblIstikrazYazi";
            lblIstikrazYazi.Size = new Size(97, 25);
            lblIstikrazYazi.TabIndex = 134;
            lblIstikrazYazi.Text = "İstikrazlar";
            // 
            // lblTurluGelirYazi
            // 
            lblTurluGelirYazi.AutoSize = true;
            lblTurluGelirYazi.BorderStyle = BorderStyle.FixedSingle;
            lblTurluGelirYazi.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblTurluGelirYazi.Location = new Point(808, 304);
            lblTurluGelirYazi.Name = "lblTurluGelirYazi";
            lblTurluGelirYazi.Size = new Size(127, 25);
            lblTurluGelirYazi.TabIndex = 131;
            lblTurluGelirYazi.Text = "Türlü Gelirler";
            // 
            // lblResimHarcYazi
            // 
            lblResimHarcYazi.AutoSize = true;
            lblResimHarcYazi.BorderStyle = BorderStyle.FixedSingle;
            lblResimHarcYazi.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblResimHarcYazi.Location = new Point(808, 164);
            lblResimHarcYazi.Name = "lblResimHarcYazi";
            lblResimHarcYazi.Size = new Size(120, 25);
            lblResimHarcYazi.TabIndex = 130;
            lblResimHarcYazi.Text = "Resim, Harç";
            // 
            // lblKoyVakifYazi
            // 
            lblKoyVakifYazi.AutoSize = true;
            lblKoyVakifYazi.BorderStyle = BorderStyle.FixedSingle;
            lblKoyVakifYazi.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblKoyVakifYazi.Location = new Point(808, 248);
            lblKoyVakifYazi.Name = "lblKoyVakifYazi";
            lblKoyVakifYazi.Size = new Size(97, 25);
            lblKoyVakifYazi.TabIndex = 127;
            lblKoyVakifYazi.Text = "Köy Vakıf";
            // 
            // lblParaCezasiYazi
            // 
            lblParaCezasiYazi.AutoSize = true;
            lblParaCezasiYazi.BorderStyle = BorderStyle.FixedSingle;
            lblParaCezasiYazi.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblParaCezasiYazi.Location = new Point(808, 192);
            lblParaCezasiYazi.Name = "lblParaCezasiYazi";
            lblParaCezasiYazi.Size = new Size(121, 25);
            lblParaCezasiYazi.TabIndex = 154;
            lblParaCezasiYazi.Text = "Para Cezası";
            // 
            // lblHasilatYazi
            // 
            lblHasilatYazi.AutoSize = true;
            lblHasilatYazi.BorderStyle = BorderStyle.FixedSingle;
            lblHasilatYazi.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblHasilatYazi.Location = new Point(808, 136);
            lblHasilatYazi.Name = "lblHasilatYazi";
            lblHasilatYazi.Size = new Size(73, 25);
            lblHasilatYazi.TabIndex = 155;
            lblHasilatYazi.Text = "Hasılat";
            // 
            // FrmGelir
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1429, 1102);
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
            Margin = new Padding(3, 4, 3, 4);
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