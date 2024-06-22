namespace Forms
{
    partial class FrmGider
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGider));
            lblBaslik = new Label();
            mskTarih = new MaskedTextBox();
            txtEvrakNo = new TextBox();
            txtAlan = new TextBox();
            txtTutar = new TextBox();
            lblEvrakNo = new Label();
            lblTarih = new Label();
            lblAlan = new Label();
            lblTutar = new Label();
            cmbGiderKategori = new ComboBox();
            label1 = new Label();
            pnlGiderBaslik = new Panel();
            lblGiderAltKategori = new Label();
            cmbGiderAltKategori = new ComboBox();
            pcBoxSil = new PictureBox();
            pcBoxGuncelle = new PictureBox();
            pcBoxKaydet = new PictureBox();
            lblToplamGider = new Label();
            lblAylikYazi = new Label();
            lblAylik = new Label();
            lblIdariMasrafYazi = new Label();
            lblIdariMasraf = new Label();
            lblSulamaYazi = new Label();
            lblAgaclamaYazi = new Label();
            lblSulama = new Label();
            lblAgaclama = new Label();
            lblDamizlikYazi = new Label();
            lblZararliHayvanYazi = new Label();
            lblOrnetTarlaYazi = new Label();
            lblPazarCarsiYazi = new Label();
            lblDamizlik = new Label();
            lblZararliHayvan = new Label();
            lblOrnetTarla = new Label();
            lblPazarCarsi = new Label();
            lblOkulOgretmeneviYazi = new Label();
            lblKursYazi = new Label();
            lblOkulDaimiYazi = new Label();
            lblKucukEndustriYazi = new Label();
            lblIcmeSulariYazi = new Label();
            lblOkulOgretmenevi = new Label();
            lblKurs = new Label();
            lblOkulDaimi = new Label();
            lblKucukEndustri = new Label();
            lblIcmeSulari = new Label();
            lblSporYazi = new Label();
            lblYolKopruYazi = new Label();
            lblTurluMasrafYazi = new Label();
            lblTemizlikYazi = new Label();
            lblYanginVesaitiYazi = new Label();
            lblKoyBorclariYazi = new Label();
            lblKoyeAitAkarYazi = new Label();
            lblVergiSigortaYazi = new Label();
            lblIctimaiYazi = new Label();
            lblMezarlikYazi = new Label();
            lblAydinlatmaYazi = new Label();
            lblYolKopru = new Label();
            lblTurluMasraf = new Label();
            lblSpor = new Label();
            lblYanginVesaiti = new Label();
            lblKoyBorclari = new Label();
            lblTemizlik = new Label();
            lblKoyeAitAkar = new Label();
            lblVergiSigorta = new Label();
            lblIctimai = new Label();
            lblMezarlik = new Label();
            lblAydinlatma = new Label();
            lblUmulmadikMasrafYazi = new Label();
            lblIstimlakMasrafYazi = new Label();
            lblMahkemeKesifYazi = new Label();
            lblUmulmadikMasraf = new Label();
            lblIstimlakMasraf = new Label();
            lblMahkemeKesif = new Label();
            lblOkulUygulamaYazi = new Label();
            lblOkulUygulama = new Label();
            lblOkumaOdasi = new Label();
            lblOkumaOdasiYazi = new Label();
            dgvGiderler = new DataGridView();
            pnlGiderBaslik.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pcBoxSil).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxGuncelle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxKaydet).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvGiderler).BeginInit();
            SuspendLayout();
            // 
            // lblBaslik
            // 
            lblBaslik.AutoSize = true;
            lblBaslik.Font = new Font("321impact", 35.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblBaslik.Location = new Point(208, 5);
            lblBaslik.Name = "lblBaslik";
            lblBaslik.Size = new Size(444, 67);
            lblBaslik.TabIndex = 1;
            lblBaslik.Text = "GİDER İŞLEMLERİ";
            // 
            // mskTarih
            // 
            mskTarih.Cursor = Cursors.IBeam;
            mskTarih.Font = new Font("Verdana", 14.25F);
            mskTarih.Location = new Point(245, 288);
            mskTarih.Margin = new Padding(3, 4, 3, 4);
            mskTarih.Mask = "00/00/0000";
            mskTarih.Name = "mskTarih";
            mskTarih.Size = new Size(117, 36);
            mskTarih.TabIndex = 112;
            mskTarih.ValidatingType = typeof(DateTime);
            // 
            // txtEvrakNo
            // 
            txtEvrakNo.Cursor = Cursors.IBeam;
            txtEvrakNo.Font = new Font("Verdana", 14.25F);
            txtEvrakNo.Location = new Point(245, 384);
            txtEvrakNo.Margin = new Padding(3, 4, 3, 4);
            txtEvrakNo.Name = "txtEvrakNo";
            txtEvrakNo.Size = new Size(238, 36);
            txtEvrakNo.TabIndex = 114;
            // 
            // txtAlan
            // 
            txtAlan.Cursor = Cursors.IBeam;
            txtAlan.Font = new Font("Verdana", 14.25F);
            txtAlan.Location = new Point(245, 336);
            txtAlan.Margin = new Padding(3, 4, 3, 4);
            txtAlan.Name = "txtAlan";
            txtAlan.Size = new Size(238, 36);
            txtAlan.TabIndex = 113;
            // 
            // txtTutar
            // 
            txtTutar.Cursor = Cursors.IBeam;
            txtTutar.Font = new Font("Verdana", 14.25F);
            txtTutar.Location = new Point(245, 240);
            txtTutar.Margin = new Padding(3, 4, 3, 4);
            txtTutar.Name = "txtTutar";
            txtTutar.Size = new Size(238, 36);
            txtTutar.TabIndex = 111;
            // 
            // lblEvrakNo
            // 
            lblEvrakNo.AutoSize = true;
            lblEvrakNo.Font = new Font("Verdana", 14.25F);
            lblEvrakNo.ImeMode = ImeMode.NoControl;
            lblEvrakNo.Location = new Point(11, 388);
            lblEvrakNo.Name = "lblEvrakNo";
            lblEvrakNo.Size = new Size(121, 29);
            lblEvrakNo.TabIndex = 118;
            lblEvrakNo.Text = "Evrak No";
            // 
            // lblTarih
            // 
            lblTarih.AutoSize = true;
            lblTarih.Font = new Font("Verdana", 14.25F);
            lblTarih.ImeMode = ImeMode.NoControl;
            lblTarih.Location = new Point(11, 292);
            lblTarih.Name = "lblTarih";
            lblTarih.Size = new Size(70, 29);
            lblTarih.TabIndex = 119;
            lblTarih.Text = "Tarih";
            // 
            // lblAlan
            // 
            lblAlan.AutoSize = true;
            lblAlan.Font = new Font("Verdana", 14.25F);
            lblAlan.ImeMode = ImeMode.NoControl;
            lblAlan.Location = new Point(11, 340);
            lblAlan.Name = "lblAlan";
            lblAlan.Size = new Size(64, 29);
            lblAlan.TabIndex = 120;
            lblAlan.Text = "Alan";
            // 
            // lblTutar
            // 
            lblTutar.AutoSize = true;
            lblTutar.Font = new Font("Verdana", 14.25F);
            lblTutar.ImeMode = ImeMode.NoControl;
            lblTutar.Location = new Point(11, 244);
            lblTutar.Name = "lblTutar";
            lblTutar.Size = new Size(74, 29);
            lblTutar.TabIndex = 121;
            lblTutar.Text = "Tutar";
            // 
            // cmbGiderKategori
            // 
            cmbGiderKategori.BackColor = SystemColors.Control;
            cmbGiderKategori.Cursor = Cursors.Hand;
            cmbGiderKategori.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGiderKategori.Font = new Font("Verdana", 14.25F);
            cmbGiderKategori.ForeColor = SystemColors.MenuText;
            cmbGiderKategori.FormattingEnabled = true;
            cmbGiderKategori.Location = new Point(245, 133);
            cmbGiderKategori.Margin = new Padding(3, 4, 3, 4);
            cmbGiderKategori.Name = "cmbGiderKategori";
            cmbGiderKategori.Size = new Size(452, 37);
            cmbGiderKategori.TabIndex = 110;
            cmbGiderKategori.SelectedIndexChanged += cmbGiderKategori_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Verdana", 14.25F);
            label1.ImeMode = ImeMode.NoControl;
            label1.Location = new Point(11, 137);
            label1.Name = "label1";
            label1.Size = new Size(184, 29);
            label1.TabIndex = 115;
            label1.Text = "Gider Kategori";
            // 
            // pnlGiderBaslik
            // 
            pnlGiderBaslik.Controls.Add(lblBaslik);
            pnlGiderBaslik.Dock = DockStyle.Top;
            pnlGiderBaslik.Location = new Point(0, 0);
            pnlGiderBaslik.Margin = new Padding(3, 4, 3, 4);
            pnlGiderBaslik.Name = "pnlGiderBaslik";
            pnlGiderBaslik.Size = new Size(1429, 80);
            pnlGiderBaslik.TabIndex = 109;
            // 
            // lblGiderAltKategori
            // 
            lblGiderAltKategori.AutoSize = true;
            lblGiderAltKategori.Font = new Font("Verdana", 14.25F);
            lblGiderAltKategori.ImeMode = ImeMode.NoControl;
            lblGiderAltKategori.Location = new Point(11, 191);
            lblGiderAltKategori.Name = "lblGiderAltKategori";
            lblGiderAltKategori.Size = new Size(223, 29);
            lblGiderAltKategori.TabIndex = 115;
            lblGiderAltKategori.Text = "Gider Alt Kategori";
            // 
            // cmbGiderAltKategori
            // 
            cmbGiderAltKategori.BackColor = SystemColors.Control;
            cmbGiderAltKategori.Cursor = Cursors.Hand;
            cmbGiderAltKategori.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGiderAltKategori.Font = new Font("Verdana", 14.25F);
            cmbGiderAltKategori.ForeColor = SystemColors.MenuText;
            cmbGiderAltKategori.FormattingEnabled = true;
            cmbGiderAltKategori.Location = new Point(245, 187);
            cmbGiderAltKategori.Margin = new Padding(3, 4, 3, 4);
            cmbGiderAltKategori.Name = "cmbGiderAltKategori";
            cmbGiderAltKategori.Size = new Size(452, 37);
            cmbGiderAltKategori.TabIndex = 110;
            cmbGiderAltKategori.SelectedIndexChanged += cmbGiderAltKategori_SelectedIndexChanged;
            // 
            // pcBoxSil
            // 
            pcBoxSil.Cursor = Cursors.Hand;
            pcBoxSil.Image = (Image)resources.GetObject("pcBoxSil.Image");
            pcBoxSil.Location = new Point(349, 436);
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
            pcBoxGuncelle.Location = new Point(453, 437);
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
            pcBoxKaydet.Location = new Point(245, 436);
            pcBoxKaydet.Margin = new Padding(3, 4, 3, 4);
            pcBoxKaydet.Name = "pcBoxKaydet";
            pcBoxKaydet.Size = new Size(97, 87);
            pcBoxKaydet.SizeMode = PictureBoxSizeMode.StretchImage;
            pcBoxKaydet.TabIndex = 124;
            pcBoxKaydet.TabStop = false;
            pcBoxKaydet.Click += pcBoxKaydet_Click;
            // 
            // lblToplamGider
            // 
            lblToplamGider.AutoSize = true;
            lblToplamGider.Font = new Font("Lucida Calligraphy", 14.25F);
            lblToplamGider.ImeMode = ImeMode.NoControl;
            lblToplamGider.Location = new Point(24, 484);
            lblToplamGider.Name = "lblToplamGider";
            lblToplamGider.Size = new Size(46, 31);
            lblToplamGider.TabIndex = 119;
            lblToplamGider.Text = "00";
            // 
            // lblAylikYazi
            // 
            lblAylikYazi.AutoSize = true;
            lblAylikYazi.BorderStyle = BorderStyle.FixedSingle;
            lblAylikYazi.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblAylikYazi.Location = new Point(784, 92);
            lblAylikYazi.Name = "lblAylikYazi";
            lblAylikYazi.Size = new Size(153, 25);
            lblAylikYazi.TabIndex = 125;
            lblAylikYazi.Text = "Aylık ve Yıllıklar";
            // 
            // lblAylik
            // 
            lblAylik.AutoSize = true;
            lblAylik.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblAylik.Location = new Point(953, 95);
            lblAylik.Name = "lblAylik";
            lblAylik.Size = new Size(32, 23);
            lblAylik.TabIndex = 125;
            lblAylik.Text = "00";
            // 
            // lblIdariMasrafYazi
            // 
            lblIdariMasrafYazi.AutoSize = true;
            lblIdariMasrafYazi.BorderStyle = BorderStyle.FixedSingle;
            lblIdariMasrafYazi.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblIdariMasrafYazi.Location = new Point(784, 120);
            lblIdariMasrafYazi.Name = "lblIdariMasrafYazi";
            lblIdariMasrafYazi.Size = new Size(141, 25);
            lblIdariMasrafYazi.TabIndex = 125;
            lblIdariMasrafYazi.Text = "İdari Masraflar";
            // 
            // lblIdariMasraf
            // 
            lblIdariMasraf.AutoSize = true;
            lblIdariMasraf.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblIdariMasraf.Location = new Point(953, 123);
            lblIdariMasraf.Name = "lblIdariMasraf";
            lblIdariMasraf.Size = new Size(32, 23);
            lblIdariMasraf.TabIndex = 125;
            lblIdariMasraf.Text = "00";
            // 
            // lblSulamaYazi
            // 
            lblSulamaYazi.AutoSize = true;
            lblSulamaYazi.BorderStyle = BorderStyle.FixedSingle;
            lblSulamaYazi.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblSulamaYazi.Location = new Point(784, 148);
            lblSulamaYazi.Name = "lblSulamaYazi";
            lblSulamaYazi.Size = new Size(152, 25);
            lblSulamaYazi.TabIndex = 125;
            lblSulamaYazi.Text = "Sulama Harkları";
            // 
            // lblAgaclamaYazi
            // 
            lblAgaclamaYazi.AutoSize = true;
            lblAgaclamaYazi.BorderStyle = BorderStyle.FixedSingle;
            lblAgaclamaYazi.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblAgaclamaYazi.Location = new Point(784, 176);
            lblAgaclamaYazi.Name = "lblAgaclamaYazi";
            lblAgaclamaYazi.Size = new Size(181, 25);
            lblAgaclamaYazi.TabIndex = 125;
            lblAgaclamaYazi.Text = "Ağaçlama, Aşılama";
            // 
            // lblSulama
            // 
            lblSulama.AutoSize = true;
            lblSulama.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblSulama.Location = new Point(953, 151);
            lblSulama.Name = "lblSulama";
            lblSulama.Size = new Size(32, 23);
            lblSulama.TabIndex = 125;
            lblSulama.Text = "00";
            // 
            // lblAgaclama
            // 
            lblAgaclama.AutoSize = true;
            lblAgaclama.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblAgaclama.Location = new Point(953, 179);
            lblAgaclama.Name = "lblAgaclama";
            lblAgaclama.Size = new Size(32, 23);
            lblAgaclama.TabIndex = 125;
            lblAgaclama.Text = "00";
            // 
            // lblDamizlikYazi
            // 
            lblDamizlikYazi.AutoSize = true;
            lblDamizlikYazi.BorderStyle = BorderStyle.FixedSingle;
            lblDamizlikYazi.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblDamizlikYazi.Location = new Point(784, 204);
            lblDamizlikYazi.Name = "lblDamizlikYazi";
            lblDamizlikYazi.Size = new Size(88, 25);
            lblDamizlikYazi.TabIndex = 125;
            lblDamizlikYazi.Text = "Damızlık";
            // 
            // lblZararliHayvanYazi
            // 
            lblZararliHayvanYazi.AutoSize = true;
            lblZararliHayvanYazi.BorderStyle = BorderStyle.FixedSingle;
            lblZararliHayvanYazi.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblZararliHayvanYazi.Location = new Point(784, 260);
            lblZararliHayvanYazi.Name = "lblZararliHayvanYazi";
            lblZararliHayvanYazi.Size = new Size(140, 25);
            lblZararliHayvanYazi.TabIndex = 125;
            lblZararliHayvanYazi.Text = "Zararlı Hayvan";
            // 
            // lblOrnetTarlaYazi
            // 
            lblOrnetTarlaYazi.AutoSize = true;
            lblOrnetTarlaYazi.BorderStyle = BorderStyle.FixedSingle;
            lblOrnetTarlaYazi.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblOrnetTarlaYazi.Location = new Point(784, 232);
            lblOrnetTarlaYazi.Name = "lblOrnetTarlaYazi";
            lblOrnetTarlaYazi.Size = new Size(115, 25);
            lblOrnetTarlaYazi.TabIndex = 125;
            lblOrnetTarlaYazi.Text = "Örnek Tarla";
            // 
            // lblPazarCarsiYazi
            // 
            lblPazarCarsiYazi.AutoSize = true;
            lblPazarCarsiYazi.BorderStyle = BorderStyle.FixedSingle;
            lblPazarCarsiYazi.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblPazarCarsiYazi.Location = new Point(784, 288);
            lblPazarCarsiYazi.Name = "lblPazarCarsiYazi";
            lblPazarCarsiYazi.Size = new Size(117, 25);
            lblPazarCarsiYazi.TabIndex = 125;
            lblPazarCarsiYazi.Text = "Pazar Çarşı";
            // 
            // lblDamizlik
            // 
            lblDamizlik.AutoSize = true;
            lblDamizlik.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblDamizlik.Location = new Point(953, 207);
            lblDamizlik.Name = "lblDamizlik";
            lblDamizlik.Size = new Size(32, 23);
            lblDamizlik.TabIndex = 125;
            lblDamizlik.Text = "00";
            // 
            // lblZararliHayvan
            // 
            lblZararliHayvan.AutoSize = true;
            lblZararliHayvan.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblZararliHayvan.Location = new Point(953, 263);
            lblZararliHayvan.Name = "lblZararliHayvan";
            lblZararliHayvan.Size = new Size(32, 23);
            lblZararliHayvan.TabIndex = 125;
            lblZararliHayvan.Text = "00";
            // 
            // lblOrnetTarla
            // 
            lblOrnetTarla.AutoSize = true;
            lblOrnetTarla.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblOrnetTarla.Location = new Point(953, 235);
            lblOrnetTarla.Name = "lblOrnetTarla";
            lblOrnetTarla.Size = new Size(32, 23);
            lblOrnetTarla.TabIndex = 125;
            lblOrnetTarla.Text = "00";
            // 
            // lblPazarCarsi
            // 
            lblPazarCarsi.AutoSize = true;
            lblPazarCarsi.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblPazarCarsi.Location = new Point(953, 291);
            lblPazarCarsi.Name = "lblPazarCarsi";
            lblPazarCarsi.Size = new Size(32, 23);
            lblPazarCarsi.TabIndex = 125;
            lblPazarCarsi.Text = "00";
            // 
            // lblOkulOgretmeneviYazi
            // 
            lblOkulOgretmeneviYazi.AutoSize = true;
            lblOkulOgretmeneviYazi.BorderStyle = BorderStyle.FixedSingle;
            lblOkulOgretmeneviYazi.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblOkulOgretmeneviYazi.Location = new Point(784, 344);
            lblOkulOgretmeneviYazi.Name = "lblOkulOgretmeneviYazi";
            lblOkulOgretmeneviYazi.Size = new Size(170, 25);
            lblOkulOgretmeneviYazi.TabIndex = 125;
            lblOkulOgretmeneviYazi.Text = "Okul Öğretmenevi";
            // 
            // lblKursYazi
            // 
            lblKursYazi.AutoSize = true;
            lblKursYazi.BorderStyle = BorderStyle.FixedSingle;
            lblKursYazi.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblKursYazi.Location = new Point(784, 428);
            lblKursYazi.Name = "lblKursYazi";
            lblKursYazi.Size = new Size(52, 25);
            lblKursYazi.TabIndex = 125;
            lblKursYazi.Text = "Kurs";
            // 
            // lblOkulDaimiYazi
            // 
            lblOkulDaimiYazi.AutoSize = true;
            lblOkulDaimiYazi.BorderStyle = BorderStyle.FixedSingle;
            lblOkulDaimiYazi.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblOkulDaimiYazi.Location = new Point(784, 372);
            lblOkulDaimiYazi.Name = "lblOkulDaimiYazi";
            lblOkulDaimiYazi.Size = new Size(107, 25);
            lblOkulDaimiYazi.TabIndex = 125;
            lblOkulDaimiYazi.Text = "Okul Daimi";
            // 
            // lblKucukEndustriYazi
            // 
            lblKucukEndustriYazi.AutoSize = true;
            lblKucukEndustriYazi.BorderStyle = BorderStyle.FixedSingle;
            lblKucukEndustriYazi.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblKucukEndustriYazi.Location = new Point(784, 316);
            lblKucukEndustriYazi.Name = "lblKucukEndustriYazi";
            lblKucukEndustriYazi.Size = new Size(145, 25);
            lblKucukEndustriYazi.TabIndex = 125;
            lblKucukEndustriYazi.Text = "Küçük Endüstri";
            // 
            // lblIcmeSulariYazi
            // 
            lblIcmeSulariYazi.AutoSize = true;
            lblIcmeSulariYazi.BorderStyle = BorderStyle.FixedSingle;
            lblIcmeSulariYazi.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblIcmeSulariYazi.Location = new Point(1103, 92);
            lblIcmeSulariYazi.Name = "lblIcmeSulariYazi";
            lblIcmeSulariYazi.Size = new Size(112, 25);
            lblIcmeSulariYazi.TabIndex = 125;
            lblIcmeSulariYazi.Text = "İçme Suları";
            // 
            // lblOkulOgretmenevi
            // 
            lblOkulOgretmenevi.AutoSize = true;
            lblOkulOgretmenevi.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblOkulOgretmenevi.Location = new Point(953, 347);
            lblOkulOgretmenevi.Name = "lblOkulOgretmenevi";
            lblOkulOgretmenevi.Size = new Size(32, 23);
            lblOkulOgretmenevi.TabIndex = 125;
            lblOkulOgretmenevi.Text = "00";
            // 
            // lblKurs
            // 
            lblKurs.AutoSize = true;
            lblKurs.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblKurs.Location = new Point(953, 431);
            lblKurs.Name = "lblKurs";
            lblKurs.Size = new Size(32, 23);
            lblKurs.TabIndex = 125;
            lblKurs.Text = "00";
            // 
            // lblOkulDaimi
            // 
            lblOkulDaimi.AutoSize = true;
            lblOkulDaimi.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblOkulDaimi.Location = new Point(953, 375);
            lblOkulDaimi.Name = "lblOkulDaimi";
            lblOkulDaimi.Size = new Size(32, 23);
            lblOkulDaimi.TabIndex = 125;
            lblOkulDaimi.Text = "00";
            // 
            // lblKucukEndustri
            // 
            lblKucukEndustri.AutoSize = true;
            lblKucukEndustri.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblKucukEndustri.Location = new Point(953, 319);
            lblKucukEndustri.Name = "lblKucukEndustri";
            lblKucukEndustri.Size = new Size(32, 23);
            lblKucukEndustri.TabIndex = 125;
            lblKucukEndustri.Text = "00";
            // 
            // lblIcmeSulari
            // 
            lblIcmeSulari.AutoSize = true;
            lblIcmeSulari.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblIcmeSulari.Location = new Point(1285, 95);
            lblIcmeSulari.Name = "lblIcmeSulari";
            lblIcmeSulari.Size = new Size(32, 23);
            lblIcmeSulari.TabIndex = 125;
            lblIcmeSulari.Text = "00";
            // 
            // lblSporYazi
            // 
            lblSporYazi.AutoSize = true;
            lblSporYazi.BorderStyle = BorderStyle.FixedSingle;
            lblSporYazi.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblSporYazi.Location = new Point(1103, 148);
            lblSporYazi.Name = "lblSporYazi";
            lblSporYazi.Size = new Size(102, 25);
            lblSporYazi.TabIndex = 125;
            lblSporYazi.Text = "Spor İşleri";
            // 
            // lblYolKopruYazi
            // 
            lblYolKopruYazi.AutoSize = true;
            lblYolKopruYazi.BorderStyle = BorderStyle.FixedSingle;
            lblYolKopruYazi.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblYolKopruYazi.Location = new Point(1103, 204);
            lblYolKopruYazi.Name = "lblYolKopruYazi";
            lblYolKopruYazi.Size = new Size(104, 25);
            lblYolKopruYazi.TabIndex = 125;
            lblYolKopruYazi.Text = "Yol, Köprü";
            // 
            // lblTurluMasrafYazi
            // 
            lblTurluMasrafYazi.AutoSize = true;
            lblTurluMasrafYazi.BorderStyle = BorderStyle.FixedSingle;
            lblTurluMasrafYazi.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblTurluMasrafYazi.Location = new Point(1103, 344);
            lblTurluMasrafYazi.Name = "lblTurluMasrafYazi";
            lblTurluMasrafYazi.Size = new Size(147, 25);
            lblTurluMasrafYazi.TabIndex = 125;
            lblTurluMasrafYazi.Text = "Türlü Masraflar";
            // 
            // lblTemizlikYazi
            // 
            lblTemizlikYazi.AutoSize = true;
            lblTemizlikYazi.BorderStyle = BorderStyle.FixedSingle;
            lblTemizlikYazi.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblTemizlikYazi.Location = new Point(1103, 120);
            lblTemizlikYazi.Name = "lblTemizlikYazi";
            lblTemizlikYazi.Size = new Size(167, 25);
            lblTemizlikYazi.TabIndex = 125;
            lblTemizlikYazi.Text = "Temizlik ve Sağlık";
            // 
            // lblYanginVesaitiYazi
            // 
            lblYanginVesaitiYazi.AutoSize = true;
            lblYanginVesaitiYazi.BorderStyle = BorderStyle.FixedSingle;
            lblYanginVesaitiYazi.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblYanginVesaitiYazi.Location = new Point(1103, 260);
            lblYanginVesaitiYazi.Name = "lblYanginVesaitiYazi";
            lblYanginVesaitiYazi.Size = new Size(137, 25);
            lblYanginVesaitiYazi.TabIndex = 125;
            lblYanginVesaitiYazi.Text = "Yangın Vesaiti";
            // 
            // lblKoyBorclariYazi
            // 
            lblKoyBorclariYazi.AutoSize = true;
            lblKoyBorclariYazi.BorderStyle = BorderStyle.FixedSingle;
            lblKoyBorclariYazi.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblKoyBorclariYazi.Location = new Point(1103, 400);
            lblKoyBorclariYazi.Name = "lblKoyBorclariYazi";
            lblKoyBorclariYazi.Size = new Size(121, 25);
            lblKoyBorclariYazi.TabIndex = 125;
            lblKoyBorclariYazi.Text = "Köy Borçları";
            // 
            // lblKoyeAitAkarYazi
            // 
            lblKoyeAitAkarYazi.AutoSize = true;
            lblKoyeAitAkarYazi.BorderStyle = BorderStyle.FixedSingle;
            lblKoyeAitAkarYazi.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblKoyeAitAkarYazi.Location = new Point(1103, 232);
            lblKoyeAitAkarYazi.Name = "lblKoyeAitAkarYazi";
            lblKoyeAitAkarYazi.Size = new Size(131, 25);
            lblKoyeAitAkarYazi.TabIndex = 125;
            lblKoyeAitAkarYazi.Text = "Köye Ait Akar";
            // 
            // lblVergiSigortaYazi
            // 
            lblVergiSigortaYazi.AutoSize = true;
            lblVergiSigortaYazi.BorderStyle = BorderStyle.FixedSingle;
            lblVergiSigortaYazi.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblVergiSigortaYazi.Location = new Point(1103, 372);
            lblVergiSigortaYazi.Name = "lblVergiSigortaYazi";
            lblVergiSigortaYazi.Size = new Size(152, 25);
            lblVergiSigortaYazi.TabIndex = 125;
            lblVergiSigortaYazi.Text = "Vergi ve Sigorta";
            // 
            // lblIctimaiYazi
            // 
            lblIctimaiYazi.AutoSize = true;
            lblIctimaiYazi.BorderStyle = BorderStyle.FixedSingle;
            lblIctimaiYazi.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblIctimaiYazi.Location = new Point(1103, 176);
            lblIctimaiYazi.Name = "lblIctimaiYazi";
            lblIctimaiYazi.Size = new Size(139, 25);
            lblIctimaiYazi.TabIndex = 125;
            lblIctimaiYazi.Text = "İçtimai Yardım";
            // 
            // lblMezarlikYazi
            // 
            lblMezarlikYazi.AutoSize = true;
            lblMezarlikYazi.BorderStyle = BorderStyle.FixedSingle;
            lblMezarlikYazi.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblMezarlikYazi.Location = new Point(1103, 316);
            lblMezarlikYazi.Name = "lblMezarlikYazi";
            lblMezarlikYazi.Size = new Size(87, 25);
            lblMezarlikYazi.TabIndex = 125;
            lblMezarlikYazi.Text = "Mezarlık";
            // 
            // lblAydinlatmaYazi
            // 
            lblAydinlatmaYazi.AutoSize = true;
            lblAydinlatmaYazi.BorderStyle = BorderStyle.FixedSingle;
            lblAydinlatmaYazi.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblAydinlatmaYazi.Location = new Point(1103, 288);
            lblAydinlatmaYazi.Name = "lblAydinlatmaYazi";
            lblAydinlatmaYazi.Size = new Size(110, 25);
            lblAydinlatmaYazi.TabIndex = 125;
            lblAydinlatmaYazi.Text = "Aydınlatma";
            // 
            // lblYolKopru
            // 
            lblYolKopru.AutoSize = true;
            lblYolKopru.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblYolKopru.Location = new Point(1285, 207);
            lblYolKopru.Name = "lblYolKopru";
            lblYolKopru.Size = new Size(32, 23);
            lblYolKopru.TabIndex = 125;
            lblYolKopru.Text = "00";
            // 
            // lblTurluMasraf
            // 
            lblTurluMasraf.AutoSize = true;
            lblTurluMasraf.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblTurluMasraf.Location = new Point(1285, 347);
            lblTurluMasraf.Name = "lblTurluMasraf";
            lblTurluMasraf.Size = new Size(32, 23);
            lblTurluMasraf.TabIndex = 125;
            lblTurluMasraf.Text = "00";
            // 
            // lblSpor
            // 
            lblSpor.AutoSize = true;
            lblSpor.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblSpor.Location = new Point(1285, 151);
            lblSpor.Name = "lblSpor";
            lblSpor.Size = new Size(32, 23);
            lblSpor.TabIndex = 125;
            lblSpor.Text = "00";
            // 
            // lblYanginVesaiti
            // 
            lblYanginVesaiti.AutoSize = true;
            lblYanginVesaiti.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblYanginVesaiti.Location = new Point(1285, 263);
            lblYanginVesaiti.Name = "lblYanginVesaiti";
            lblYanginVesaiti.Size = new Size(32, 23);
            lblYanginVesaiti.TabIndex = 125;
            lblYanginVesaiti.Text = "00";
            // 
            // lblKoyBorclari
            // 
            lblKoyBorclari.AutoSize = true;
            lblKoyBorclari.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblKoyBorclari.Location = new Point(1285, 403);
            lblKoyBorclari.Name = "lblKoyBorclari";
            lblKoyBorclari.Size = new Size(32, 23);
            lblKoyBorclari.TabIndex = 125;
            lblKoyBorclari.Text = "00";
            // 
            // lblTemizlik
            // 
            lblTemizlik.AutoSize = true;
            lblTemizlik.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblTemizlik.Location = new Point(1285, 123);
            lblTemizlik.Name = "lblTemizlik";
            lblTemizlik.Size = new Size(32, 23);
            lblTemizlik.TabIndex = 125;
            lblTemizlik.Text = "00";
            // 
            // lblKoyeAitAkar
            // 
            lblKoyeAitAkar.AutoSize = true;
            lblKoyeAitAkar.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblKoyeAitAkar.Location = new Point(1285, 235);
            lblKoyeAitAkar.Name = "lblKoyeAitAkar";
            lblKoyeAitAkar.Size = new Size(32, 23);
            lblKoyeAitAkar.TabIndex = 125;
            lblKoyeAitAkar.Text = "00";
            // 
            // lblVergiSigorta
            // 
            lblVergiSigorta.AutoSize = true;
            lblVergiSigorta.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblVergiSigorta.Location = new Point(1285, 375);
            lblVergiSigorta.Name = "lblVergiSigorta";
            lblVergiSigorta.Size = new Size(32, 23);
            lblVergiSigorta.TabIndex = 125;
            lblVergiSigorta.Text = "00";
            // 
            // lblIctimai
            // 
            lblIctimai.AutoSize = true;
            lblIctimai.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblIctimai.Location = new Point(1285, 179);
            lblIctimai.Name = "lblIctimai";
            lblIctimai.Size = new Size(32, 23);
            lblIctimai.TabIndex = 125;
            lblIctimai.Text = "00";
            // 
            // lblMezarlik
            // 
            lblMezarlik.AutoSize = true;
            lblMezarlik.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblMezarlik.Location = new Point(1285, 319);
            lblMezarlik.Name = "lblMezarlik";
            lblMezarlik.Size = new Size(32, 23);
            lblMezarlik.TabIndex = 125;
            lblMezarlik.Text = "00";
            // 
            // lblAydinlatma
            // 
            lblAydinlatma.AutoSize = true;
            lblAydinlatma.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblAydinlatma.Location = new Point(1285, 291);
            lblAydinlatma.Name = "lblAydinlatma";
            lblAydinlatma.Size = new Size(32, 23);
            lblAydinlatma.TabIndex = 125;
            lblAydinlatma.Text = "00";
            // 
            // lblUmulmadikMasrafYazi
            // 
            lblUmulmadikMasrafYazi.AutoSize = true;
            lblUmulmadikMasrafYazi.BorderStyle = BorderStyle.FixedSingle;
            lblUmulmadikMasrafYazi.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblUmulmadikMasrafYazi.Location = new Point(1103, 484);
            lblUmulmadikMasrafYazi.Name = "lblUmulmadikMasrafYazi";
            lblUmulmadikMasrafYazi.Size = new Size(199, 25);
            lblUmulmadikMasrafYazi.TabIndex = 125;
            lblUmulmadikMasrafYazi.Text = "Umulmadık Masraflar";
            // 
            // lblIstimlakMasrafYazi
            // 
            lblIstimlakMasrafYazi.AutoSize = true;
            lblIstimlakMasrafYazi.BorderStyle = BorderStyle.FixedSingle;
            lblIstimlakMasrafYazi.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblIstimlakMasrafYazi.Location = new Point(1103, 456);
            lblIstimlakMasrafYazi.Name = "lblIstimlakMasrafYazi";
            lblIstimlakMasrafYazi.Size = new Size(175, 25);
            lblIstimlakMasrafYazi.TabIndex = 125;
            lblIstimlakMasrafYazi.Text = "İstimlak Masrafları";
            // 
            // lblMahkemeKesifYazi
            // 
            lblMahkemeKesifYazi.AutoSize = true;
            lblMahkemeKesifYazi.BorderStyle = BorderStyle.FixedSingle;
            lblMahkemeKesifYazi.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblMahkemeKesifYazi.Location = new Point(1103, 428);
            lblMahkemeKesifYazi.Name = "lblMahkemeKesifYazi";
            lblMahkemeKesifYazi.Size = new Size(174, 25);
            lblMahkemeKesifYazi.TabIndex = 125;
            lblMahkemeKesifYazi.Text = "Mahkeme ve Keşif";
            // 
            // lblUmulmadikMasraf
            // 
            lblUmulmadikMasraf.AutoSize = true;
            lblUmulmadikMasraf.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblUmulmadikMasraf.Location = new Point(1285, 487);
            lblUmulmadikMasraf.Name = "lblUmulmadikMasraf";
            lblUmulmadikMasraf.Size = new Size(32, 23);
            lblUmulmadikMasraf.TabIndex = 125;
            lblUmulmadikMasraf.Text = "00";
            // 
            // lblIstimlakMasraf
            // 
            lblIstimlakMasraf.AutoSize = true;
            lblIstimlakMasraf.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblIstimlakMasraf.Location = new Point(1285, 459);
            lblIstimlakMasraf.Name = "lblIstimlakMasraf";
            lblIstimlakMasraf.Size = new Size(32, 23);
            lblIstimlakMasraf.TabIndex = 125;
            lblIstimlakMasraf.Text = "00";
            // 
            // lblMahkemeKesif
            // 
            lblMahkemeKesif.AutoSize = true;
            lblMahkemeKesif.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblMahkemeKesif.Location = new Point(1285, 431);
            lblMahkemeKesif.Name = "lblMahkemeKesif";
            lblMahkemeKesif.Size = new Size(32, 23);
            lblMahkemeKesif.TabIndex = 125;
            lblMahkemeKesif.Text = "00";
            // 
            // lblOkulUygulamaYazi
            // 
            lblOkulUygulamaYazi.AutoSize = true;
            lblOkulUygulamaYazi.BorderStyle = BorderStyle.FixedSingle;
            lblOkulUygulamaYazi.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblOkulUygulamaYazi.Location = new Point(784, 456);
            lblOkulUygulamaYazi.Name = "lblOkulUygulamaYazi";
            lblOkulUygulamaYazi.Size = new Size(144, 25);
            lblOkulUygulamaYazi.TabIndex = 125;
            lblOkulUygulamaYazi.Text = "Okul Uygulama";
            // 
            // lblOkulUygulama
            // 
            lblOkulUygulama.AutoSize = true;
            lblOkulUygulama.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblOkulUygulama.Location = new Point(953, 459);
            lblOkulUygulama.Name = "lblOkulUygulama";
            lblOkulUygulama.Size = new Size(32, 23);
            lblOkulUygulama.TabIndex = 125;
            lblOkulUygulama.Text = "00";
            // 
            // lblOkumaOdasi
            // 
            lblOkumaOdasi.AutoSize = true;
            lblOkumaOdasi.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblOkumaOdasi.Location = new Point(953, 403);
            lblOkumaOdasi.Name = "lblOkumaOdasi";
            lblOkumaOdasi.Size = new Size(32, 23);
            lblOkumaOdasi.TabIndex = 126;
            lblOkumaOdasi.Text = "00";
            // 
            // lblOkumaOdasiYazi
            // 
            lblOkumaOdasiYazi.AutoSize = true;
            lblOkumaOdasiYazi.BorderStyle = BorderStyle.FixedSingle;
            lblOkumaOdasiYazi.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblOkumaOdasiYazi.Location = new Point(784, 400);
            lblOkumaOdasiYazi.Name = "lblOkumaOdasiYazi";
            lblOkumaOdasiYazi.Size = new Size(112, 25);
            lblOkumaOdasiYazi.TabIndex = 127;
            lblOkumaOdasiYazi.Text = "Okul Odası";
            // 
            // dgvGiderler
            // 
            dgvGiderler.AllowUserToAddRows = false;
            dgvGiderler.AllowUserToDeleteRows = false;
            dgvGiderler.AllowUserToResizeColumns = false;
            dgvGiderler.AllowUserToResizeRows = false;
            dgvGiderler.BackgroundColor = SystemColors.Control;
            dgvGiderler.BorderStyle = BorderStyle.Fixed3D;
            dgvGiderler.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dgvGiderler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGiderler.Location = new Point(14, 525);
            dgvGiderler.Margin = new Padding(3, 4, 3, 4);
            dgvGiderler.Name = "dgvGiderler";
            dgvGiderler.ReadOnly = true;
            dgvGiderler.RowHeadersWidth = 51;
            dgvGiderler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGiderler.Size = new Size(1401, 565);
            dgvGiderler.TabIndex = 128;
            dgvGiderler.CellDoubleClick += dgvGiderler_CellDoubleClick;
            // 
            // FrmGider
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1429, 1102);
            Controls.Add(dgvGiderler);
            Controls.Add(lblOkumaOdasi);
            Controls.Add(lblOkumaOdasiYazi);
            Controls.Add(lblIcmeSulari);
            Controls.Add(lblMahkemeKesif);
            Controls.Add(lblAydinlatma);
            Controls.Add(lblPazarCarsi);
            Controls.Add(lblIstimlakMasraf);
            Controls.Add(lblMezarlik);
            Controls.Add(lblKucukEndustri);
            Controls.Add(lblIctimai);
            Controls.Add(lblAgaclama);
            Controls.Add(lblVergiSigorta);
            Controls.Add(lblOkulDaimi);
            Controls.Add(lblKoyeAitAkar);
            Controls.Add(lblOrnetTarla);
            Controls.Add(lblTemizlik);
            Controls.Add(lblIdariMasraf);
            Controls.Add(lblKoyBorclari);
            Controls.Add(lblOkulUygulama);
            Controls.Add(lblKurs);
            Controls.Add(lblYanginVesaiti);
            Controls.Add(lblZararliHayvan);
            Controls.Add(lblSpor);
            Controls.Add(lblSulama);
            Controls.Add(lblUmulmadikMasraf);
            Controls.Add(lblTurluMasraf);
            Controls.Add(lblOkulOgretmenevi);
            Controls.Add(lblYolKopru);
            Controls.Add(lblDamizlik);
            Controls.Add(lblAylik);
            Controls.Add(lblIcmeSulariYazi);
            Controls.Add(lblMahkemeKesifYazi);
            Controls.Add(lblAydinlatmaYazi);
            Controls.Add(lblPazarCarsiYazi);
            Controls.Add(lblIstimlakMasrafYazi);
            Controls.Add(lblMezarlikYazi);
            Controls.Add(lblKucukEndustriYazi);
            Controls.Add(lblIctimaiYazi);
            Controls.Add(lblVergiSigortaYazi);
            Controls.Add(lblAgaclamaYazi);
            Controls.Add(lblKoyeAitAkarYazi);
            Controls.Add(lblOkulDaimiYazi);
            Controls.Add(lblKoyBorclariYazi);
            Controls.Add(lblOrnetTarlaYazi);
            Controls.Add(lblYanginVesaitiYazi);
            Controls.Add(lblOkulUygulamaYazi);
            Controls.Add(lblKursYazi);
            Controls.Add(lblTemizlikYazi);
            Controls.Add(lblUmulmadikMasrafYazi);
            Controls.Add(lblZararliHayvanYazi);
            Controls.Add(lblTurluMasrafYazi);
            Controls.Add(lblIdariMasrafYazi);
            Controls.Add(lblYolKopruYazi);
            Controls.Add(lblOkulOgretmeneviYazi);
            Controls.Add(lblSporYazi);
            Controls.Add(lblDamizlikYazi);
            Controls.Add(lblSulamaYazi);
            Controls.Add(lblAylikYazi);
            Controls.Add(pcBoxSil);
            Controls.Add(pcBoxGuncelle);
            Controls.Add(pcBoxKaydet);
            Controls.Add(mskTarih);
            Controls.Add(txtEvrakNo);
            Controls.Add(txtAlan);
            Controls.Add(txtTutar);
            Controls.Add(lblEvrakNo);
            Controls.Add(lblToplamGider);
            Controls.Add(lblTarih);
            Controls.Add(lblAlan);
            Controls.Add(lblTutar);
            Controls.Add(cmbGiderAltKategori);
            Controls.Add(lblGiderAltKategori);
            Controls.Add(cmbGiderKategori);
            Controls.Add(label1);
            Controls.Add(pnlGiderBaslik);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmGider";
            Text = "FrmGider";
            Load += FrmGider_Load;
            pnlGiderBaslik.ResumeLayout(false);
            pnlGiderBaslik.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pcBoxSil).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxGuncelle).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxKaydet).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvGiderler).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblBaslik;
        private MaskedTextBox mskTarih;
        private TextBox txtEvrakNo;
        private TextBox txtAlan;
        private TextBox txtTutar;
        private Label lblEvrakNo;
        private Label lblTarih;
        private Label lblAlan;
        private Label lblTutar;
        private Label label1;
        private Panel pnlGiderBaslik;
        private Label lblGiderAltKategori;
        private ComboBox cmbGiderAltKategori;
        private PictureBox pcBoxSil;
        private PictureBox pcBoxGuncelle;
        private PictureBox pcBoxKaydet;
        private ComboBox cmbGiderKategori;
        public Label lblToplamGider;
        private Label lblAylikYazi;
        private Label lblAylik;
        private Label lblIdariMasrafYazi;
        private Label lblIdariMasraf;
        private Label lblSulamaYazi;
        private Label lblAgaclamaYazi;
        private Label lblSulama;
        private Label lblAgaclama;
        private Label lblDamizlikYazi;
        private Label lblZararliHayvanYazi;
        private Label lblOrnetTarlaYazi;
        private Label lblPazarCarsiYazi;
        private Label lblDamizlik;
        private Label lblZararliHayvan;
        private Label lblOrnetTarla;
        private Label lblPazarCarsi;
        private Label lblOkulOgretmeneviYazi;
        private Label lblKursYazi;
        private Label lblOkulDaimiYazi;
        private Label lblKucukEndustriYazi;
        private Label lblIcmeSulariYazi;
        private Label lblOkulOgretmenevi;
        private Label lblKurs;
        private Label lblOkulDaimi;
        private Label lblKucukEndustri;
        private Label lblIcmeSulari;
        private Label lblSporYazi;
        private Label lblYolKopruYazi;
        private Label lblTurluMasrafYazi;
        private Label lblTemizlikYazi;
        private Label lblYanginVesaitiYazi;
        private Label lblKoyBorclariYazi;
        private Label lblKoyeAitAkarYazi;
        private Label lblVergiSigortaYazi;
        private Label lblIctimaiYazi;
        private Label lblMezarlikYazi;
        private Label lblAydinlatmaYazi;
        private Label lblYolKopru;
        private Label lblTurluMasraf;
        private Label lblSpor;
        private Label lblYanginVesaiti;
        private Label lblKoyBorclari;
        private Label lblTemizlik;
        private Label lblKoyeAitAkar;
        private Label lblVergiSigorta;
        private Label lblIctimai;
        private Label lblMezarlik;
        private Label lblAydinlatma;
        private Label lblUmulmadikMasrafYazi;
        private Label lblIstimlakMasrafYazi;
        private Label lblMahkemeKesifYazi;
        private Label lblUmulmadikMasraf;
        private Label lblIstimlakMasraf;
        private Label lblMahkemeKesif;
        private Label lblOkulUygulamaYazi;
        private Label lblOkulUygulama;
        private Label lblOkumaOdasi;
        private Label lblOkumaOdasiYazi;
        public DataGridView dgvGiderler;
    }
}