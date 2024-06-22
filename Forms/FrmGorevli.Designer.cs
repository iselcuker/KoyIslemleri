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
            pcBoxSil.Location = new Point(306, 339);
            pcBoxSil.Margin = new Padding(3, 4, 3, 4);
            pcBoxSil.Name = "pcBoxSil";
            pcBoxSil.Size = new Size(97, 87);
            pcBoxSil.SizeMode = PictureBoxSizeMode.StretchImage;
            pcBoxSil.TabIndex = 140;
            pcBoxSil.TabStop = false;
            pcBoxSil.Click += pcBoxSil_Click;
            // 
            // pcBoxGuncelle
            // 
            pcBoxGuncelle.Cursor = Cursors.Hand;
            pcBoxGuncelle.Image = (Image)resources.GetObject("pcBoxGuncelle.Image");
            pcBoxGuncelle.Location = new Point(410, 340);
            pcBoxGuncelle.Margin = new Padding(3, 4, 3, 4);
            pcBoxGuncelle.Name = "pcBoxGuncelle";
            pcBoxGuncelle.Size = new Size(97, 87);
            pcBoxGuncelle.SizeMode = PictureBoxSizeMode.StretchImage;
            pcBoxGuncelle.TabIndex = 141;
            pcBoxGuncelle.TabStop = false;
            pcBoxGuncelle.Click += pcBoxGuncelle_Click;
            // 
            // pcBoxKaydet
            // 
            pcBoxKaydet.Cursor = Cursors.Hand;
            pcBoxKaydet.Image = Properties.Resources.Kaydet1;
            pcBoxKaydet.Location = new Point(202, 339);
            pcBoxKaydet.Margin = new Padding(3, 4, 3, 4);
            pcBoxKaydet.Name = "pcBoxKaydet";
            pcBoxKaydet.Size = new Size(97, 87);
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
            pnlGelirBaslik.Margin = new Padding(3, 4, 3, 4);
            pnlGelirBaslik.Name = "pnlGelirBaslik";
            pnlGelirBaslik.Size = new Size(922, 121);
            pnlGelirBaslik.TabIndex = 139;
            // 
            // lblBaslik
            // 
            lblBaslik.AutoSize = true;
            lblBaslik.Font = new Font("321impact", 50.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblBaslik.Location = new Point(141, 12);
            lblBaslik.Name = "lblBaslik";
            lblBaslik.Size = new Size(461, 95);
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
            dgvGorevliler.Location = new Point(0, 435);
            dgvGorevliler.Margin = new Padding(3, 4, 3, 4);
            dgvGorevliler.Name = "dgvGorevliler";
            dgvGorevliler.ReadOnly = true;
            dgvGorevliler.RowHeadersWidth = 51;
            dgvGorevliler.Size = new Size(922, 505);
            dgvGorevliler.TabIndex = 138;
            dgvGorevliler.CellDoubleClick += dgvGorevliler_CellDoubleClick;
            // 
            // lblTelefon
            // 
            lblTelefon.AutoSize = true;
            lblTelefon.Font = new Font("Verdana", 14.25F);
            lblTelefon.ImeMode = ImeMode.NoControl;
            lblTelefon.Location = new Point(11, 291);
            lblTelefon.Name = "lblTelefon";
            lblTelefon.Size = new Size(138, 29);
            lblTelefon.TabIndex = 137;
            lblTelefon.Text = "Telefon No";
            // 
            // lblUnvan
            // 
            lblUnvan.AutoSize = true;
            lblUnvan.Font = new Font("Verdana", 14.25F);
            lblUnvan.ImeMode = ImeMode.NoControl;
            lblUnvan.Location = new Point(11, 237);
            lblUnvan.Name = "lblUnvan";
            lblUnvan.Size = new Size(95, 29);
            lblUnvan.TabIndex = 144;
            lblUnvan.Text = "Ünvanı";
            // 
            // txtAdi
            // 
            txtAdi.Cursor = Cursors.IBeam;
            txtAdi.Font = new Font("Lucida Calligraphy", 14.25F);
            txtAdi.Location = new Point(202, 129);
            txtAdi.Margin = new Padding(3, 4, 3, 4);
            txtAdi.Name = "txtAdi";
            txtAdi.Size = new Size(238, 40);
            txtAdi.TabIndex = 136;
            // 
            // lblAdi
            // 
            lblAdi.AutoSize = true;
            lblAdi.Font = new Font("Verdana", 14.25F);
            lblAdi.ImeMode = ImeMode.NoControl;
            lblAdi.Location = new Point(11, 133);
            lblAdi.Name = "lblAdi";
            lblAdi.Size = new Size(50, 29);
            lblAdi.TabIndex = 137;
            lblAdi.Text = "Adı";
            // 
            // txtSoyadi
            // 
            txtSoyadi.Cursor = Cursors.IBeam;
            txtSoyadi.Font = new Font("Lucida Calligraphy", 14.25F);
            txtSoyadi.Location = new Point(202, 181);
            txtSoyadi.Margin = new Padding(3, 4, 3, 4);
            txtSoyadi.Name = "txtSoyadi";
            txtSoyadi.Size = new Size(238, 40);
            txtSoyadi.TabIndex = 136;
            // 
            // lblSoyadi
            // 
            lblSoyadi.AutoSize = true;
            lblSoyadi.Font = new Font("Verdana", 14.25F);
            lblSoyadi.ImeMode = ImeMode.NoControl;
            lblSoyadi.Location = new Point(11, 184);
            lblSoyadi.Name = "lblSoyadi";
            lblSoyadi.Size = new Size(93, 29);
            lblSoyadi.TabIndex = 137;
            lblSoyadi.Text = "Soyadı";
            // 
            // mskTelefoNo
            // 
            mskTelefoNo.Cursor = Cursors.IBeam;
            mskTelefoNo.Font = new Font("Verdana", 14.25F);
            mskTelefoNo.Location = new Point(202, 287);
            mskTelefoNo.Margin = new Padding(3, 4, 3, 4);
            mskTelefoNo.Mask = "0(999) 000-0000";
            mskTelefoNo.Name = "mskTelefoNo";
            mskTelefoNo.Size = new Size(187, 36);
            mskTelefoNo.TabIndex = 145;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.ImeMode = ImeMode.NoControl;
            pictureBox3.Location = new Point(589, 124);
            pictureBox3.Margin = new Padding(3, 4, 3, 4);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(320, 303);
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
            cmbUnvan.Location = new Point(202, 233);
            cmbUnvan.Margin = new Padding(3, 4, 3, 4);
            cmbUnvan.Name = "cmbUnvan";
            cmbUnvan.Size = new Size(238, 37);
            cmbUnvan.TabIndex = 147;
            // 
            // FrmGorevli
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(922, 940);
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
            Margin = new Padding(3, 4, 3, 4);
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