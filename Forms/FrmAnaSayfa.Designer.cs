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
            pnlBaslik.Name = "pnlBaslik";
            pnlBaslik.Size = new Size(1677, 90);
            pnlBaslik.TabIndex = 0;
            pnlBaslik.Paint += pnlBaslik_Paint;
            // 
            // lblBaslik
            // 
            lblBaslik.AutoSize = true;
            lblBaslik.Font = new Font("321impact", 50.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblBaslik.Location = new Point(760, 9);
            lblBaslik.Name = "lblBaslik";
            lblBaslik.Size = new Size(0, 76);
            lblBaslik.TabIndex = 0;
            // 
            // pcBoxClose
            // 
            pcBoxClose.Cursor = Cursors.Hand;
            pcBoxClose.Image = Properties.Resources.Creative_Freedom_Free_Funktional_14_Delete_48;
            pcBoxClose.Location = new Point(1628, 0);
            pcBoxClose.Name = "pcBoxClose";
            pcBoxClose.Size = new Size(50, 50);
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
            pnlYanEkran.Location = new Point(0, 89);
            pnlYanEkran.Name = "pnlYanEkran";
            pnlYanEkran.Size = new Size(423, 900);
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
            grpSonDurum.Location = new Point(12, 593);
            grpSonDurum.Name = "grpSonDurum";
            grpSonDurum.Size = new Size(395, 269);
            grpSonDurum.TabIndex = 9;
            grpSonDurum.TabStop = false;
            grpSonDurum.Text = "SON DURUM";
            // 
            // lblFark
            // 
            lblFark.AutoSize = true;
            lblFark.Font = new Font("Monotype Corsiva", 18F, FontStyle.Bold | FontStyle.Italic);
            lblFark.Location = new Point(142, 128);
            lblFark.Name = "lblFark";
            lblFark.Size = new Size(36, 28);
            lblFark.TabIndex = 3;
            lblFark.Text = "00";
            // 
            // lblToplamGider
            // 
            lblToplamGider.AutoSize = true;
            lblToplamGider.Font = new Font("Monotype Corsiva", 18F, FontStyle.Bold | FontStyle.Italic);
            lblToplamGider.Location = new Point(142, 77);
            lblToplamGider.Name = "lblToplamGider";
            lblToplamGider.Size = new Size(36, 28);
            lblToplamGider.TabIndex = 3;
            lblToplamGider.Text = "00";
            // 
            // lblToplamGelir
            // 
            lblToplamGelir.AutoSize = true;
            lblToplamGelir.Font = new Font("Monotype Corsiva", 18F, FontStyle.Bold | FontStyle.Italic);
            lblToplamGelir.Location = new Point(142, 38);
            lblToplamGelir.Name = "lblToplamGelir";
            lblToplamGelir.Size = new Size(36, 28);
            lblToplamGelir.TabIndex = 3;
            lblToplamGelir.Text = "00";
            // 
            // lblGenelSonuc
            // 
            lblGenelSonuc.AutoSize = true;
            lblGenelSonuc.Font = new Font("Monotype Corsiva", 18F, FontStyle.Bold | FontStyle.Italic);
            lblGenelSonuc.Location = new Point(24, 188);
            lblGenelSonuc.Name = "lblGenelSonuc";
            lblGenelSonuc.Size = new Size(24, 28);
            lblGenelSonuc.TabIndex = 2;
            lblGenelSonuc.Text = "0";
            // 
            // lblSonuc
            // 
            lblSonuc.AutoSize = true;
            lblSonuc.Font = new Font("Monotype Corsiva", 18F, FontStyle.Bold | FontStyle.Italic);
            lblSonuc.Location = new Point(49, 128);
            lblSonuc.Name = "lblSonuc";
            lblSonuc.Size = new Size(89, 28);
            lblSonuc.TabIndex = 2;
            lblSonuc.Text = "SONUÇ";
            // 
            // lblGider
            // 
            lblGider.AutoSize = true;
            lblGider.Font = new Font("Monotype Corsiva", 18F, FontStyle.Bold | FontStyle.Italic);
            lblGider.Location = new Point(49, 77);
            lblGider.Name = "lblGider";
            lblGider.Size = new Size(87, 28);
            lblGider.TabIndex = 2;
            lblGider.Text = "GİDER";
            // 
            // pctSonuc
            // 
            pctSonuc.Image = (Image)resources.GetObject("pctSonuc.Image");
            pctSonuc.Location = new Point(9, 126);
            pctSonuc.Name = "pctSonuc";
            pctSonuc.Size = new Size(43, 33);
            pctSonuc.SizeMode = PictureBoxSizeMode.Zoom;
            pctSonuc.TabIndex = 1;
            pctSonuc.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(9, 36);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(43, 33);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // pctGider
            // 
            pctGider.Image = (Image)resources.GetObject("pctGider.Image");
            pctGider.Location = new Point(9, 75);
            pctGider.Name = "pctGider";
            pctGider.Size = new Size(43, 33);
            pctGider.SizeMode = PictureBoxSizeMode.Zoom;
            pctGider.TabIndex = 1;
            pctGider.TabStop = false;
            // 
            // lblGelir
            // 
            lblGelir.AutoSize = true;
            lblGelir.Font = new Font("Monotype Corsiva", 18F, FontStyle.Bold | FontStyle.Italic);
            lblGelir.Location = new Point(49, 38);
            lblGelir.Name = "lblGelir";
            lblGelir.Size = new Size(84, 28);
            lblGelir.TabIndex = 2;
            lblGelir.Text = "GELİR";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(4, 89);
            label1.Name = "label1";
            label1.Size = new Size(304, 32);
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
            grpNot.Location = new Point(12, 220);
            grpNot.Name = "grpNot";
            grpNot.Size = new Size(395, 356);
            grpNot.TabIndex = 8;
            grpNot.TabStop = false;
            grpNot.Text = "NOT";
            // 
            // pcBoxSil
            // 
            pcBoxSil.Cursor = Cursors.Hand;
            pcBoxSil.Image = (Image)resources.GetObject("pcBoxSil.Image");
            pcBoxSil.Location = new Point(142, 270);
            pcBoxSil.Name = "pcBoxSil";
            pcBoxSil.Size = new Size(85, 65);
            pcBoxSil.SizeMode = PictureBoxSizeMode.StretchImage;
            pcBoxSil.TabIndex = 124;
            pcBoxSil.TabStop = false;
            pcBoxSil.Click += pcBoxSil_Click;
            // 
            // rchBoxNot
            // 
            rchBoxNot.Font = new Font("Tahoma", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rchBoxNot.Location = new Point(5, 28);
            rchBoxNot.Name = "rchBoxNot";
            rchBoxNot.Size = new Size(384, 225);
            rchBoxNot.TabIndex = 0;
            rchBoxNot.Text = "";
            // 
            // pcBoxGuncelle
            // 
            pcBoxGuncelle.Cursor = Cursors.Hand;
            pcBoxGuncelle.Image = (Image)resources.GetObject("pcBoxGuncelle.Image");
            pcBoxGuncelle.Location = new Point(304, 270);
            pcBoxGuncelle.Name = "pcBoxGuncelle";
            pcBoxGuncelle.Size = new Size(85, 65);
            pcBoxGuncelle.SizeMode = PictureBoxSizeMode.StretchImage;
            pcBoxGuncelle.TabIndex = 125;
            pcBoxGuncelle.TabStop = false;
            pcBoxGuncelle.Click += pcBoxGuncelle_Click;
            // 
            // pcBoxKaydet
            // 
            pcBoxKaydet.Cursor = Cursors.Hand;
            pcBoxKaydet.Image = Properties.Resources.Kaydet1;
            pcBoxKaydet.Location = new Point(9, 270);
            pcBoxKaydet.Name = "pcBoxKaydet";
            pcBoxKaydet.Size = new Size(85, 65);
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
            cmbDonem.Location = new Point(120, 93);
            cmbDonem.Name = "cmbDonem";
            cmbDonem.Size = new Size(287, 39);
            cmbDonem.TabIndex = 3;
            cmbDonem.SelectedIndexChanged += cmbDonem_SelectedIndexChanged;
            // 
            // lblDonem
            // 
            lblDonem.AutoSize = true;
            lblDonem.Font = new Font("Microsoft Sans Serif", 20.25F);
            lblDonem.Location = new Point(6, 96);
            lblDonem.Name = "lblDonem";
            lblDonem.Size = new Size(115, 31);
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
            cmbKoy.Location = new Point(120, 48);
            cmbKoy.Name = "cmbKoy";
            cmbKoy.Size = new Size(287, 39);
            cmbKoy.TabIndex = 2;
            cmbKoy.SelectedIndexChanged += cmbKoy_SelectedIndexChanged;
            // 
            // lblKoy
            // 
            lblKoy.AutoSize = true;
            lblKoy.Font = new Font("Microsoft Sans Serif", 20.25F);
            lblKoy.Location = new Point(6, 51);
            lblKoy.Name = "lblKoy";
            lblKoy.Size = new Size(71, 31);
            lblKoy.TabIndex = 3;
            lblKoy.Text = "KÖY";
            // 
            // cmbIlce
            // 
            cmbIlce.BackColor = SystemColors.Control;
            cmbIlce.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbIlce.Font = new Font("Microsoft Sans Serif", 20.25F);
            cmbIlce.FormattingEnabled = true;
            cmbIlce.Location = new Point(120, 3);
            cmbIlce.Name = "cmbIlce";
            cmbIlce.Size = new Size(287, 39);
            cmbIlce.TabIndex = 1;
            cmbIlce.SelectedIndexChanged += cmbIlce_SelectedIndexChanged;
            // 
            // lblIlce
            // 
            lblIlce.AutoSize = true;
            lblIlce.Font = new Font("Microsoft Sans Serif", 20.25F);
            lblIlce.Location = new Point(6, 6);
            lblIlce.Name = "lblIlce";
            lblIlce.Size = new Size(75, 31);
            lblIlce.TabIndex = 4;
            lblIlce.Text = "İLÇE";
            // 
            // pnlFormlar
            // 
            pnlFormlar.Location = new Point(425, 191);
            pnlFormlar.Name = "pnlFormlar";
            pnlFormlar.Size = new Size(1252, 798);
            pnlFormlar.TabIndex = 2;
            // 
            // pnlButonlar
            // 
            pnlButonlar.Controls.Add(pcBoxGorevliler);
            pnlButonlar.Controls.Add(pcBoxKesinHesap);
            pnlButonlar.Controls.Add(pcBoxTahminiButce);
            pnlButonlar.Controls.Add(pcBoxGider);
            pnlButonlar.Controls.Add(pcBoxGelir);
            pnlButonlar.Location = new Point(422, 90);
            pnlButonlar.Name = "pnlButonlar";
            pnlButonlar.Size = new Size(1255, 100);
            pnlButonlar.TabIndex = 3;
            // 
            // pcBoxGorevliler
            // 
            pcBoxGorevliler.BorderStyle = BorderStyle.FixedSingle;
            pcBoxGorevliler.Cursor = Cursors.Hand;
            pcBoxGorevliler.Image = (Image)resources.GetObject("pcBoxGorevliler.Image");
            pcBoxGorevliler.Location = new Point(567, 2);
            pcBoxGorevliler.Name = "pcBoxGorevliler";
            pcBoxGorevliler.Size = new Size(136, 90);
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
            pcBoxKesinHesap.Location = new Point(429, 3);
            pcBoxKesinHesap.Name = "pcBoxKesinHesap";
            pcBoxKesinHesap.Size = new Size(136, 90);
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
            pcBoxTahminiButce.Location = new Point(287, 3);
            pcBoxTahminiButce.Name = "pcBoxTahminiButce";
            pcBoxTahminiButce.Size = new Size(136, 90);
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
            pcBoxGider.Location = new Point(146, 3);
            pcBoxGider.Name = "pcBoxGider";
            pcBoxGider.Size = new Size(136, 90);
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
            pcBoxGelir.Location = new Point(7, 3);
            pcBoxGelir.Name = "pcBoxGelir";
            pcBoxGelir.Size = new Size(136, 90);
            pcBoxGelir.SizeMode = PictureBoxSizeMode.StretchImage;
            pcBoxGelir.TabIndex = 0;
            pcBoxGelir.TabStop = false;
            pcBoxGelir.Click += pcBoxGelir_Click;
            // 
            // FrmAnaSayfa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1680, 1010);
            Controls.Add(pcBoxClose);
            Controls.Add(pnlButonlar);
            Controls.Add(pnlFormlar);
            Controls.Add(pnlYanEkran);
            Controls.Add(pnlBaslik);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmAnaSayfa";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "KÖY İŞLEMLERİ";
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
        private ComboBox cmbDonem;
        private Label lblDonem;
        private ComboBox cmbKoy;
        private Label lblKoy;
        private ComboBox cmbIlce;
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
    }
}
