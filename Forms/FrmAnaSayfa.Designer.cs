namespace Forms
{
    partial class FrmAnaSayfa
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAnaSayfa));
            pnlBaslik = new Panel();
            lblBaslik = new Label();
            pcBoxClose = new PictureBox();
            pnlYanEkran = new Panel();
            grpSonDurum = new GroupBox();
            lblFark = new Label();
            lblToplamGider = new Label();
            lblToplamGelir = new Label();
            lblGenelSonuc = new Label();
            lblSonuc = new Label();
            lblGider = new Label();
            pctSonuc = new PictureBox();
            pictureBox1 = new PictureBox();
            pctGider = new PictureBox();
            lblGelir = new Label();
            label1 = new Label();
            grpNot = new GroupBox();
            pcBoxSil = new PictureBox();
            rchBoxNot = new RichTextBox();
            pcBoxGuncelle = new PictureBox();
            pcBoxKaydet = new PictureBox();
            cmbDonem = new ComboBox();
            lblDonem = new Label();
            cmbKoy = new ComboBox();
            lblKoy = new Label();
            cmbIlce = new ComboBox();
            lblIlce = new Label();
            pnlFormlar = new Panel();
            pnlButonlar = new Panel();
            pcBoxEkButce = new PictureBox();
            pcBoxGorevliler = new PictureBox();
            pcBoxKesinHesap = new PictureBox();
            pcBoxTahminiButce = new PictureBox();
            pcBoxGider = new PictureBox();
            pcBoxGelir = new PictureBox();
            pnlBaslik.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pcBoxClose).BeginInit();
            pnlYanEkran.SuspendLayout();
            grpSonDurum.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pctSonuc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pctGider).BeginInit();
            grpNot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pcBoxSil).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxGuncelle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxKaydet).BeginInit();
            pnlButonlar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pcBoxEkButce).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxGorevliler).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxKesinHesap).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxTahminiButce).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxGider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxGelir).BeginInit();
            SuspendLayout();
            // 
            // pnlBaslik
            // 
            pnlBaslik.Controls.Add(lblBaslik);
            pnlBaslik.Location = new Point(0, 0);
            pnlBaslik.Margin = new Padding(3, 4, 3, 4);
            pnlBaslik.Name = "pnlBaslik";
            pnlBaslik.Size = new Size(1917, 120);
            pnlBaslik.TabIndex = 0;
            pnlBaslik.Paint += pnlBaslik_Paint;
            // 
            // lblBaslik
            // 
            lblBaslik.AutoSize = true;
            lblBaslik.Font = new Font("321impact", 50.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblBaslik.Location = new Point(869, 12);
            lblBaslik.Name = "lblBaslik";
            lblBaslik.Size = new Size(0, 95);
            lblBaslik.TabIndex = 0;
            // 
            // pcBoxClose
            // 
            pcBoxClose.Cursor = Cursors.Hand;
            pcBoxClose.Image = Properties.Resources.Creative_Freedom_Free_Funktional_14_Delete_48;
            pcBoxClose.Location = new Point(1861, 0);
            pcBoxClose.Margin = new Padding(3, 4, 3, 4);
            pcBoxClose.Name = "pcBoxClose";
            pcBoxClose.Size = new Size(57, 67);
            pcBoxClose.TabIndex = 1;
            pcBoxClose.TabStop = false;
            pcBoxClose.Click += pcBoxClose_Click;
            // 
            // pnlYanEkran
            // 
            pnlYanEkran.Controls.Add(grpSonDurum);
            pnlYanEkran.Controls.Add(grpNot);
            pnlYanEkran.Controls.Add(cmbDonem);
            pnlYanEkran.Controls.Add(lblDonem);
            pnlYanEkran.Controls.Add(cmbKoy);
            pnlYanEkran.Controls.Add(lblKoy);
            pnlYanEkran.Controls.Add(cmbIlce);
            pnlYanEkran.Controls.Add(lblIlce);
            pnlYanEkran.Location = new Point(0, 119);
            pnlYanEkran.Margin = new Padding(3, 4, 3, 4);
            pnlYanEkran.Name = "pnlYanEkran";
            pnlYanEkran.Size = new Size(483, 1200);
            pnlYanEkran.TabIndex = 1;
            // 
            // grpSonDurum
            // 
            grpSonDurum.Controls.Add(lblFark);
            grpSonDurum.Controls.Add(lblToplamGider);
            grpSonDurum.Controls.Add(lblToplamGelir);
            grpSonDurum.Controls.Add(lblGenelSonuc);
            grpSonDurum.Controls.Add(lblSonuc);
            grpSonDurum.Controls.Add(lblGider);
            grpSonDurum.Controls.Add(pctSonuc);
            grpSonDurum.Controls.Add(pictureBox1);
            grpSonDurum.Controls.Add(pctGider);
            grpSonDurum.Controls.Add(lblGelir);
            grpSonDurum.Controls.Add(label1);
            grpSonDurum.Font = new Font("Stencil", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            grpSonDurum.ForeColor = SystemColors.ActiveCaptionText;
            grpSonDurum.Location = new Point(14, 791);
            grpSonDurum.Margin = new Padding(3, 4, 3, 4);
            grpSonDurum.Name = "grpSonDurum";
            grpSonDurum.Padding = new Padding(3, 4, 3, 4);
            grpSonDurum.Size = new Size(451, 359);
            grpSonDurum.TabIndex = 9;
            grpSonDurum.TabStop = false;
            grpSonDurum.Text = "SON DURUM";
            // 
            // lblFark
            // 
            lblFark.AutoSize = true;
            lblFark.Font = new Font("Monotype Corsiva", 18F, FontStyle.Bold | FontStyle.Italic);
            lblFark.Location = new Point(162, 171);
            lblFark.Name = "lblFark";
            lblFark.Size = new Size(45, 37);
            lblFark.TabIndex = 3;
            lblFark.Text = "00";
            // 
            // lblToplamGider
            // 
            lblToplamGider.AutoSize = true;
            lblToplamGider.Font = new Font("Monotype Corsiva", 18F, FontStyle.Bold | FontStyle.Italic);
            lblToplamGider.Location = new Point(162, 103);
            lblToplamGider.Name = "lblToplamGider";
            lblToplamGider.Size = new Size(45, 37);
            lblToplamGider.TabIndex = 3;
            lblToplamGider.Text = "00";
            // 
            // lblToplamGelir
            // 
            lblToplamGelir.AutoSize = true;
            lblToplamGelir.Font = new Font("Monotype Corsiva", 18F, FontStyle.Bold | FontStyle.Italic);
            lblToplamGelir.Location = new Point(162, 51);
            lblToplamGelir.Name = "lblToplamGelir";
            lblToplamGelir.Size = new Size(45, 37);
            lblToplamGelir.TabIndex = 3;
            lblToplamGelir.Text = "00";
            // 
            // lblGenelSonuc
            // 
            lblGenelSonuc.AutoSize = true;
            lblGenelSonuc.Font = new Font("Monotype Corsiva", 18F, FontStyle.Bold | FontStyle.Italic);
            lblGenelSonuc.Location = new Point(27, 251);
            lblGenelSonuc.Name = "lblGenelSonuc";
            lblGenelSonuc.Size = new Size(31, 37);
            lblGenelSonuc.TabIndex = 2;
            lblGenelSonuc.Text = "0";
            // 
            // lblSonuc
            // 
            lblSonuc.AutoSize = true;
            lblSonuc.Font = new Font("Monotype Corsiva", 18F, FontStyle.Bold | FontStyle.Italic);
            lblSonuc.Location = new Point(56, 171);
            lblSonuc.Name = "lblSonuc";
            lblSonuc.Size = new Size(113, 37);
            lblSonuc.TabIndex = 2;
            lblSonuc.Text = "SONUÇ";
            // 
            // lblGider
            // 
            lblGider.AutoSize = true;
            lblGider.Font = new Font("Monotype Corsiva", 18F, FontStyle.Bold | FontStyle.Italic);
            lblGider.Location = new Point(56, 103);
            lblGider.Name = "lblGider";
            lblGider.Size = new Size(110, 37);
            lblGider.TabIndex = 2;
            lblGider.Text = "GİDER";
            // 
            // pctSonuc
            // 
            pctSonuc.Image = (Image)resources.GetObject("pctSonuc.Image");
            pctSonuc.Location = new Point(10, 168);
            pctSonuc.Margin = new Padding(3, 4, 3, 4);
            pctSonuc.Name = "pctSonuc";
            pctSonuc.Size = new Size(49, 44);
            pctSonuc.SizeMode = PictureBoxSizeMode.Zoom;
            pctSonuc.TabIndex = 1;
            pctSonuc.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(10, 48);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(49, 44);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // pctGider
            // 
            pctGider.Image = (Image)resources.GetObject("pctGider.Image");
            pctGider.Location = new Point(10, 100);
            pctGider.Margin = new Padding(3, 4, 3, 4);
            pctGider.Name = "pctGider";
            pctGider.Size = new Size(49, 44);
            pctGider.SizeMode = PictureBoxSizeMode.Zoom;
            pctGider.TabIndex = 1;
            pctGider.TabStop = false;
            // 
            // lblGelir
            // 
            lblGelir.AutoSize = true;
            lblGelir.Font = new Font("Monotype Corsiva", 18F, FontStyle.Bold | FontStyle.Italic);
            lblGelir.Location = new Point(56, 51);
            lblGelir.Name = "lblGelir";
            lblGelir.Size = new Size(106, 37);
            lblGelir.TabIndex = 2;
            lblGelir.Text = "GELİR";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(5, 119);
            label1.Name = "label1";
            label1.Size = new Size(366, 41);
            label1.TabIndex = 0;
            label1.Text = "_____________________________";
            // 
            // grpNot
            // 
            grpNot.Controls.Add(pcBoxSil);
            grpNot.Controls.Add(rchBoxNot);
            grpNot.Controls.Add(pcBoxGuncelle);
            grpNot.Controls.Add(pcBoxKaydet);
            grpNot.FlatStyle = FlatStyle.Popup;
            grpNot.Font = new Font("Stencil", 18F, FontStyle.Bold);
            grpNot.Location = new Point(14, 293);
            grpNot.Margin = new Padding(3, 4, 3, 4);
            grpNot.Name = "grpNot";
            grpNot.Padding = new Padding(3, 4, 3, 4);
            grpNot.Size = new Size(451, 475);
            grpNot.TabIndex = 8;
            grpNot.TabStop = false;
            grpNot.Text = "NOT";
            // 
            // pcBoxSil
            // 
            pcBoxSil.Cursor = Cursors.Hand;
            pcBoxSil.Image = (Image)resources.GetObject("pcBoxSil.Image");
            pcBoxSil.Location = new Point(162, 360);
            pcBoxSil.Margin = new Padding(3, 4, 3, 4);
            pcBoxSil.Name = "pcBoxSil";
            pcBoxSil.Size = new Size(97, 87);
            pcBoxSil.SizeMode = PictureBoxSizeMode.StretchImage;
            pcBoxSil.TabIndex = 124;
            pcBoxSil.TabStop = false;
            pcBoxSil.Click += pcBoxSil_Click;
            // 
            // rchBoxNot
            // 
            rchBoxNot.Font = new Font("Tahoma", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rchBoxNot.Location = new Point(6, 37);
            rchBoxNot.Margin = new Padding(3, 4, 3, 4);
            rchBoxNot.Name = "rchBoxNot";
            rchBoxNot.Size = new Size(438, 299);
            rchBoxNot.TabIndex = 0;
            rchBoxNot.Text = "";
            // 
            // pcBoxGuncelle
            // 
            pcBoxGuncelle.Cursor = Cursors.Hand;
            pcBoxGuncelle.Image = (Image)resources.GetObject("pcBoxGuncelle.Image");
            pcBoxGuncelle.Location = new Point(347, 360);
            pcBoxGuncelle.Margin = new Padding(3, 4, 3, 4);
            pcBoxGuncelle.Name = "pcBoxGuncelle";
            pcBoxGuncelle.Size = new Size(97, 87);
            pcBoxGuncelle.SizeMode = PictureBoxSizeMode.StretchImage;
            pcBoxGuncelle.TabIndex = 125;
            pcBoxGuncelle.TabStop = false;
            pcBoxGuncelle.Click += pcBoxGuncelle_Click;
            // 
            // pcBoxKaydet
            // 
            pcBoxKaydet.Cursor = Cursors.Hand;
            pcBoxKaydet.Image = Properties.Resources.Kaydet1;
            pcBoxKaydet.Location = new Point(10, 360);
            pcBoxKaydet.Margin = new Padding(3, 4, 3, 4);
            pcBoxKaydet.Name = "pcBoxKaydet";
            pcBoxKaydet.Size = new Size(97, 87);
            pcBoxKaydet.SizeMode = PictureBoxSizeMode.StretchImage;
            pcBoxKaydet.TabIndex = 126;
            pcBoxKaydet.TabStop = false;
            pcBoxKaydet.Click += pcBoxKaydet_Click;
            // 
            // cmbDonem
            // 
            cmbDonem.BackColor = SystemColors.Control;
            cmbDonem.DropDownHeight = 200;
            cmbDonem.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDonem.DropDownWidth = 200;
            cmbDonem.Font = new Font("Microsoft Sans Serif", 20.25F);
            cmbDonem.FormattingEnabled = true;
            cmbDonem.IntegralHeight = false;
            cmbDonem.Location = new Point(137, 124);
            cmbDonem.Margin = new Padding(3, 4, 3, 4);
            cmbDonem.Name = "cmbDonem";
            cmbDonem.Size = new Size(327, 47);
            cmbDonem.TabIndex = 3;
            cmbDonem.SelectedIndexChanged += cmbDonem_SelectedIndexChanged;
            // 
            // lblDonem
            // 
            lblDonem.AutoSize = true;
            lblDonem.Font = new Font("Microsoft Sans Serif", 20.25F);
            lblDonem.Location = new Point(7, 128);
            lblDonem.Name = "lblDonem";
            lblDonem.Size = new Size(144, 39);
            lblDonem.TabIndex = 2;
            lblDonem.Text = "DÖNEM";
            // 
            // cmbKoy
            // 
            cmbKoy.BackColor = SystemColors.Control;
            cmbKoy.DropDownHeight = 250;
            cmbKoy.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbKoy.DropDownWidth = 200;
            cmbKoy.Font = new Font("Microsoft Sans Serif", 20.25F);
            cmbKoy.FormattingEnabled = true;
            cmbKoy.IntegralHeight = false;
            cmbKoy.Location = new Point(137, 64);
            cmbKoy.Margin = new Padding(3, 4, 3, 4);
            cmbKoy.Name = "cmbKoy";
            cmbKoy.Size = new Size(327, 47);
            cmbKoy.TabIndex = 2;
            cmbKoy.SelectedIndexChanged += cmbKoy_SelectedIndexChanged;
            // 
            // lblKoy
            // 
            lblKoy.AutoSize = true;
            lblKoy.Font = new Font("Microsoft Sans Serif", 20.25F);
            lblKoy.Location = new Point(7, 68);
            lblKoy.Name = "lblKoy";
            lblKoy.Size = new Size(88, 39);
            lblKoy.TabIndex = 3;
            lblKoy.Text = "KÖY";
            // 
            // cmbIlce
            // 
            cmbIlce.BackColor = SystemColors.Control;
            cmbIlce.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbIlce.Font = new Font("Microsoft Sans Serif", 20.25F);
            cmbIlce.FormattingEnabled = true;
            cmbIlce.Location = new Point(137, 4);
            cmbIlce.Margin = new Padding(3, 4, 3, 4);
            cmbIlce.Name = "cmbIlce";
            cmbIlce.Size = new Size(327, 47);
            cmbIlce.TabIndex = 1;
            cmbIlce.SelectedIndexChanged += cmbIlce_SelectedIndexChanged;
            // 
            // lblIlce
            // 
            lblIlce.AutoSize = true;
            lblIlce.Font = new Font("Microsoft Sans Serif", 20.25F);
            lblIlce.Location = new Point(7, 8);
            lblIlce.Name = "lblIlce";
            lblIlce.Size = new Size(94, 39);
            lblIlce.TabIndex = 4;
            lblIlce.Text = "İLÇE";
            // 
            // pnlFormlar
            // 
            pnlFormlar.Location = new Point(486, 255);
            pnlFormlar.Margin = new Padding(3, 4, 3, 4);
            pnlFormlar.Name = "pnlFormlar";
            pnlFormlar.Size = new Size(1431, 1064);
            pnlFormlar.TabIndex = 2;
            // 
            // pnlButonlar
            // 
            pnlButonlar.Controls.Add(pcBoxEkButce);
            pnlButonlar.Controls.Add(pcBoxGorevliler);
            pnlButonlar.Controls.Add(pcBoxKesinHesap);
            pnlButonlar.Controls.Add(pcBoxTahminiButce);
            pnlButonlar.Controls.Add(pcBoxGider);
            pnlButonlar.Controls.Add(pcBoxGelir);
            pnlButonlar.Location = new Point(482, 120);
            pnlButonlar.Margin = new Padding(3, 4, 3, 4);
            pnlButonlar.Name = "pnlButonlar";
            pnlButonlar.Size = new Size(1434, 133);
            pnlButonlar.TabIndex = 3;
            // 
            // pcBoxEkButce
            // 
            pcBoxEkButce.BorderStyle = BorderStyle.FixedSingle;
            pcBoxEkButce.Cursor = Cursors.Hand;
            pcBoxEkButce.Image = (Image)resources.GetObject("pcBoxEkButce.Image");
            pcBoxEkButce.Location = new Point(490, 4);
            pcBoxEkButce.Margin = new Padding(3, 4, 3, 4);
            pcBoxEkButce.Name = "pcBoxEkButce";
            pcBoxEkButce.Size = new Size(155, 119);
            pcBoxEkButce.SizeMode = PictureBoxSizeMode.StretchImage;
            pcBoxEkButce.TabIndex = 7;
            pcBoxEkButce.TabStop = false;
            pcBoxEkButce.Click += pcBoxEkButce_Click;
            // 
            // pcBoxGorevliler
            // 
            pcBoxGorevliler.BorderStyle = BorderStyle.FixedSingle;
            pcBoxGorevliler.Cursor = Cursors.Hand;
            pcBoxGorevliler.Image = (Image)resources.GetObject("pcBoxGorevliler.Image");
            pcBoxGorevliler.Location = new Point(873, 3);
            pcBoxGorevliler.Margin = new Padding(3, 4, 3, 4);
            pcBoxGorevliler.Name = "pcBoxGorevliler";
            pcBoxGorevliler.Size = new Size(155, 119);
            pcBoxGorevliler.SizeMode = PictureBoxSizeMode.StretchImage;
            pcBoxGorevliler.TabIndex = 8;
            pcBoxGorevliler.TabStop = false;
            pcBoxGorevliler.Click += pcBoxGorevliler_Click;
            // 
            // pcBoxKesinHesap
            // 
            pcBoxKesinHesap.BorderStyle = BorderStyle.FixedSingle;
            pcBoxKesinHesap.Cursor = Cursors.Hand;
            pcBoxKesinHesap.Image = (Image)resources.GetObject("pcBoxKesinHesap.Image");
            pcBoxKesinHesap.Location = new Point(715, 4);
            pcBoxKesinHesap.Margin = new Padding(3, 4, 3, 4);
            pcBoxKesinHesap.Name = "pcBoxKesinHesap";
            pcBoxKesinHesap.Size = new Size(155, 119);
            pcBoxKesinHesap.SizeMode = PictureBoxSizeMode.StretchImage;
            pcBoxKesinHesap.TabIndex = 7;
            pcBoxKesinHesap.TabStop = false;
            pcBoxKesinHesap.Click += pcBoxKesinHesap_Click;
            // 
            // pcBoxTahminiButce
            // 
            pcBoxTahminiButce.BorderStyle = BorderStyle.FixedSingle;
            pcBoxTahminiButce.Cursor = Cursors.Hand;
            pcBoxTahminiButce.Image = (Image)resources.GetObject("pcBoxTahminiButce.Image");
            pcBoxTahminiButce.Location = new Point(328, 4);
            pcBoxTahminiButce.Margin = new Padding(3, 4, 3, 4);
            pcBoxTahminiButce.Name = "pcBoxTahminiButce";
            pcBoxTahminiButce.Size = new Size(155, 119);
            pcBoxTahminiButce.SizeMode = PictureBoxSizeMode.StretchImage;
            pcBoxTahminiButce.TabIndex = 5;
            pcBoxTahminiButce.TabStop = false;
            pcBoxTahminiButce.Click += pcBoxTahminiButce_Click_1;
            // 
            // pcBoxGider
            // 
            pcBoxGider.BorderStyle = BorderStyle.FixedSingle;
            pcBoxGider.Cursor = Cursors.Hand;
            pcBoxGider.Image = (Image)resources.GetObject("pcBoxGider.Image");
            pcBoxGider.Location = new Point(167, 4);
            pcBoxGider.Margin = new Padding(3, 4, 3, 4);
            pcBoxGider.Name = "pcBoxGider";
            pcBoxGider.Size = new Size(155, 119);
            pcBoxGider.SizeMode = PictureBoxSizeMode.StretchImage;
            pcBoxGider.TabIndex = 4;
            pcBoxGider.TabStop = false;
            pcBoxGider.Click += pcBoxGider_Click_1;
            // 
            // pcBoxGelir
            // 
            pcBoxGelir.BorderStyle = BorderStyle.FixedSingle;
            pcBoxGelir.Cursor = Cursors.Hand;
            pcBoxGelir.Image = (Image)resources.GetObject("pcBoxGelir.Image");
            pcBoxGelir.Location = new Point(8, 4);
            pcBoxGelir.Margin = new Padding(3, 4, 3, 4);
            pcBoxGelir.Name = "pcBoxGelir";
            pcBoxGelir.Size = new Size(155, 119);
            pcBoxGelir.SizeMode = PictureBoxSizeMode.StretchImage;
            pcBoxGelir.TabIndex = 0;
            pcBoxGelir.TabStop = false;
            pcBoxGelir.Click += pcBoxGelir_Click;
            // 
            // FrmAnaSayfa
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1701, 1069);
            Controls.Add(pcBoxClose);
            Controls.Add(pnlButonlar);
            Controls.Add(pnlFormlar);
            Controls.Add(pnlYanEkran);
            Controls.Add(pnlBaslik);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmAnaSayfa";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "KÖY İŞLEMLERİ";
            WindowState = FormWindowState.Maximized;
            Load += FrmAnaSayfa_Load_1;
            pnlBaslik.ResumeLayout(false);
            pnlBaslik.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pcBoxClose).EndInit();
            pnlYanEkran.ResumeLayout(false);
            pnlYanEkran.PerformLayout();
            grpSonDurum.ResumeLayout(false);
            grpSonDurum.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pctSonuc).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pctGider).EndInit();
            grpNot.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pcBoxSil).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxGuncelle).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxKaydet).EndInit();
            pnlButonlar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pcBoxEkButce).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxGorevliler).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxKesinHesap).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxTahminiButce).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxGider).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxGelir).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlBaslik;
        private PictureBox pcBoxClose;
        private Label lblBaslik;
        private Panel pnlYanEkran;
        private Label lblDonem;
        private Label lblKoy;
        private Label lblIlce;
        private GroupBox grpSonDurum;
        private Label lblFark;
        private Label lblSonuc;
        private Label lblGider;
        private PictureBox pctSonuc;
        private PictureBox pictureBox1;
        private PictureBox pctGider;
        private Label lblGelir;
        private Label label1;
        private GroupBox grpNot;
        private RichTextBox rchBoxNot;
        private Panel pnlFormlar;
        private Panel pnlButonlar;
        private PictureBox pcBoxGelir;
        private PictureBox pcBoxGider;
        private PictureBox pcBoxTahminiButce;
        private PictureBox pcBoxKesinHesap;
        private PictureBox pcBoxGorevliler;
        private PictureBox pcBoxSil;
        private PictureBox pcBoxGuncelle;
        private PictureBox pcBoxKaydet;
        public Label lblToplamGelir;
        public Label lblToplamGider;
        private Label lblGenelSonuc;
        public ComboBox cmbDonem;
        public ComboBox cmbKoy;
        private PictureBox pcBoxEkButce;
        public ComboBox cmbIlce;
    }
}
