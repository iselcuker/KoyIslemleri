namespace Forms
{
    partial class FrmGorevli
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGorevli));
            pcBoxSil = new PictureBox();
            pcBoxGuncelle = new PictureBox();
            pcBoxKaydet = new PictureBox();
            pnlGelirBaslik = new Panel();
            lblBaslik = new Label();
            dgvGorevliler = new DataGridView();
            lblTelefon = new Label();
            lblUnvan = new Label();
            txtAdi = new TextBox();
            lblAdi = new Label();
            txtSoyadi = new TextBox();
            lblSoyadi = new Label();
            mskTelefoNo = new MaskedTextBox();
            pictureBox3 = new PictureBox();
            cmbUnvan = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)pcBoxSil).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxGuncelle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxKaydet).BeginInit();
            pnlGelirBaslik.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGorevliler).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // pcBoxSil
            // 
            pcBoxSil.Cursor = Cursors.Hand;
            pcBoxSil.Image = (Image)resources.GetObject("pcBoxSil.Image");
            pcBoxSil.Location = new Point(268, 254);
            pcBoxSil.Name = "pcBoxSil";
            pcBoxSil.Size = new Size(85, 65);
            pcBoxSil.SizeMode = PictureBoxSizeMode.StretchImage;
            pcBoxSil.TabIndex = 140;
            pcBoxSil.TabStop = false;
            pcBoxSil.Click += pcBoxSil_Click;
            // 
            // pcBoxGuncelle
            // 
            pcBoxGuncelle.Cursor = Cursors.Hand;
            pcBoxGuncelle.Image = (Image)resources.GetObject("pcBoxGuncelle.Image");
            pcBoxGuncelle.Location = new Point(359, 255);
            pcBoxGuncelle.Name = "pcBoxGuncelle";
            pcBoxGuncelle.Size = new Size(85, 65);
            pcBoxGuncelle.SizeMode = PictureBoxSizeMode.StretchImage;
            pcBoxGuncelle.TabIndex = 141;
            pcBoxGuncelle.TabStop = false;
            pcBoxGuncelle.Click += pcBoxGuncelle_Click;
            // 
            // pcBoxKaydet
            // 
            pcBoxKaydet.Cursor = Cursors.Hand;
            pcBoxKaydet.Image = Properties.Resources.Kaydet1;
            pcBoxKaydet.Location = new Point(177, 254);
            pcBoxKaydet.Name = "pcBoxKaydet";
            pcBoxKaydet.Size = new Size(85, 65);
            pcBoxKaydet.SizeMode = PictureBoxSizeMode.StretchImage;
            pcBoxKaydet.TabIndex = 142;
            pcBoxKaydet.TabStop = false;
            pcBoxKaydet.Click += pcBoxKaydet_Click;
            // 
            // pnlGelirBaslik
            // 
            pnlGelirBaslik.Controls.Add(lblBaslik);
            pnlGelirBaslik.Dock = DockStyle.Top;
            pnlGelirBaslik.Location = new Point(0, 0);
            pnlGelirBaslik.Name = "pnlGelirBaslik";
            pnlGelirBaslik.Size = new Size(807, 91);
            pnlGelirBaslik.TabIndex = 139;
            // 
            // lblBaslik
            // 
            lblBaslik.AutoSize = true;
            lblBaslik.Font = new Font("321impact", 50.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblBaslik.Location = new Point(123, 9);
            lblBaslik.Name = "lblBaslik";
            lblBaslik.Size = new Size(367, 76);
            lblBaslik.TabIndex = 1;
            lblBaslik.Text = "GÖREVLİLER";
            // 
            // dgvGorevliler
            // 
            dgvGorevliler.AllowUserToAddRows = false;
            dgvGorevliler.AllowUserToDeleteRows = false;
            dgvGorevliler.BackgroundColor = SystemColors.Control;
            dgvGorevliler.BorderStyle = BorderStyle.Fixed3D;
            dgvGorevliler.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dgvGorevliler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGorevliler.Dock = DockStyle.Bottom;
            dgvGorevliler.Location = new Point(0, 326);
            dgvGorevliler.Name = "dgvGorevliler";
            dgvGorevliler.ReadOnly = true;
            dgvGorevliler.Size = new Size(807, 379);
            dgvGorevliler.TabIndex = 138;
            dgvGorevliler.CellDoubleClick += dgvGorevliler_CellDoubleClick;
            // 
            // lblTelefon
            // 
            lblTelefon.AutoSize = true;
            lblTelefon.Font = new Font("Lucida Calligraphy", 14.25F);
            lblTelefon.ImeMode = ImeMode.NoControl;
            lblTelefon.Location = new Point(10, 218);
            lblTelefon.Name = "lblTelefon";
            lblTelefon.Size = new Size(120, 24);
            lblTelefon.TabIndex = 137;
            lblTelefon.Text = "Telefon No";
            // 
            // lblUnvan
            // 
            lblUnvan.AutoSize = true;
            lblUnvan.Font = new Font("Lucida Calligraphy", 14.25F);
            lblUnvan.ImeMode = ImeMode.NoControl;
            lblUnvan.Location = new Point(10, 178);
            lblUnvan.Name = "lblUnvan";
            lblUnvan.Size = new Size(90, 24);
            lblUnvan.TabIndex = 144;
            lblUnvan.Text = "Ünvanı";
            // 
            // txtAdi
            // 
            txtAdi.Cursor = Cursors.IBeam;
            txtAdi.Font = new Font("Lucida Calligraphy", 14.25F);
            txtAdi.Location = new Point(177, 97);
            txtAdi.Name = "txtAdi";
            txtAdi.Size = new Size(209, 33);
            txtAdi.TabIndex = 136;
            // 
            // lblAdi
            // 
            lblAdi.AutoSize = true;
            lblAdi.Font = new Font("Lucida Calligraphy", 14.25F);
            lblAdi.ImeMode = ImeMode.NoControl;
            lblAdi.Location = new Point(10, 100);
            lblAdi.Name = "lblAdi";
            lblAdi.Size = new Size(49, 24);
            lblAdi.TabIndex = 137;
            lblAdi.Text = "Adı";
            // 
            // txtSoyadi
            // 
            txtSoyadi.Cursor = Cursors.IBeam;
            txtSoyadi.Font = new Font("Lucida Calligraphy", 14.25F);
            txtSoyadi.Location = new Point(177, 136);
            txtSoyadi.Name = "txtSoyadi";
            txtSoyadi.Size = new Size(209, 33);
            txtSoyadi.TabIndex = 136;
            // 
            // lblSoyadi
            // 
            lblSoyadi.AutoSize = true;
            lblSoyadi.Font = new Font("Lucida Calligraphy", 14.25F);
            lblSoyadi.ImeMode = ImeMode.NoControl;
            lblSoyadi.Location = new Point(10, 138);
            lblSoyadi.Name = "lblSoyadi";
            lblSoyadi.Size = new Size(78, 24);
            lblSoyadi.TabIndex = 137;
            lblSoyadi.Text = "Soyadı";
            // 
            // mskTelefoNo
            // 
            mskTelefoNo.Cursor = Cursors.IBeam;
            mskTelefoNo.Font = new Font("Lucida Calligraphy", 14.25F);
            mskTelefoNo.Location = new Point(177, 215);
            mskTelefoNo.Mask = "0(999) 000-0000";
            mskTelefoNo.Name = "mskTelefoNo";
            mskTelefoNo.Size = new Size(164, 33);
            mskTelefoNo.TabIndex = 145;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.ImeMode = ImeMode.NoControl;
            pictureBox3.Location = new Point(515, 93);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(280, 227);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 146;
            pictureBox3.TabStop = false;
            // 
            // cmbUnvan
            // 
            cmbUnvan.BackColor = SystemColors.Control;
            cmbUnvan.Cursor = Cursors.Hand;
            cmbUnvan.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUnvan.Font = new Font("Verdana", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbUnvan.ForeColor = SystemColors.MenuText;
            cmbUnvan.FormattingEnabled = true;
            cmbUnvan.Location = new Point(177, 175);
            cmbUnvan.Name = "cmbUnvan";
            cmbUnvan.Size = new Size(209, 31);
            cmbUnvan.TabIndex = 147;
            // 
            // FrmGorevli
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(807, 705);
            Controls.Add(cmbUnvan);
            Controls.Add(pictureBox3);
            Controls.Add(mskTelefoNo);
            Controls.Add(lblUnvan);
            Controls.Add(pcBoxSil);
            Controls.Add(pcBoxGuncelle);
            Controls.Add(pcBoxKaydet);
            Controls.Add(pnlGelirBaslik);
            Controls.Add(dgvGorevliler);
            Controls.Add(lblAdi);
            Controls.Add(txtAdi);
            Controls.Add(lblSoyadi);
            Controls.Add(txtSoyadi);
            Controls.Add(lblTelefon);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmGorevli";
            Text = "FrmGorevli";
            Load += FrmGorevli_Load;
            ((System.ComponentModel.ISupportInitialize)pcBoxSil).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxGuncelle).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxKaydet).EndInit();
            pnlGelirBaslik.ResumeLayout(false);
            pnlGelirBaslik.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGorevliler).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pcBoxSil;
        private PictureBox pcBoxGuncelle;
        private PictureBox pcBoxKaydet;
        private Panel pnlGelirBaslik;
        private Label lblBaslik;
        public DataGridView dgvGorevliler;
        private Label lblTelefon;
        private Label lblUnvan;
        private TextBox txtAdi;
        private Label lblAdi;
        private TextBox txtSoyadi;
        private Label lblSoyadi;
        private MaskedTextBox mskTelefoNo;
        private PictureBox pictureBox3;
        private ComboBox cmbUnvan;
    }
}