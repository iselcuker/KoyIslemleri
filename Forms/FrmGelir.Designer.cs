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
            listViewGelirler = new ListView();
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
            mskTarih.Font = new Font("Verdana", 14.25F);
            mskTarih.Location = new Point(191, 140);
            mskTarih.Mask = "00/00/0000";
            mskTarih.Name = "mskTarih";
            mskTarih.Size = new Size(131, 31);
            mskTarih.TabIndex = 96;
            mskTarih.ValidatingType = typeof(DateTime);
            // 
            // txtEvrakNo
            // 
            txtEvrakNo.Cursor = Cursors.IBeam;
            txtEvrakNo.Font = new Font("Verdana", 14.25F);
            txtEvrakNo.Location = new Point(191, 212);
            txtEvrakNo.Name = "txtEvrakNo";
            txtEvrakNo.Size = new Size(209, 31);
            txtEvrakNo.TabIndex = 98;
            // 
            // txtVeren
            // 
            txtVeren.Cursor = Cursors.IBeam;
            txtVeren.Font = new Font("Verdana", 14.25F);
            txtVeren.Location = new Point(191, 176);
            txtVeren.Name = "txtVeren";
            txtVeren.Size = new Size(267, 31);
            txtVeren.TabIndex = 97;
            txtVeren.TextChanged += txtVeren_TextChanged;
            // 
            // txtTutar
            // 
            txtTutar.Cursor = Cursors.IBeam;
            txtTutar.Font = new Font("Verdana", 14.25F);
            txtTutar.Location = new Point(191, 104);
            txtTutar.Name = "txtTutar";
            txtTutar.Size = new Size(209, 31);
            txtTutar.TabIndex = 95;
            txtTutar.KeyPress += txtTutar_KeyPress;
            // 
            // lblEvrakNo
            // 
            lblEvrakNo.AutoSize = true;
            lblEvrakNo.Font = new Font("Verdana", 14.25F);
            lblEvrakNo.ImeMode = ImeMode.NoControl;
            lblEvrakNo.Location = new Point(10, 215);
            lblEvrakNo.Name = "lblEvrakNo";
            lblEvrakNo.Size = new Size(96, 23);
            lblEvrakNo.TabIndex = 102;
            lblEvrakNo.Text = "Evrak No";
            // 
            // lblTarih
            // 
            lblTarih.AutoSize = true;
            lblTarih.Font = new Font("Verdana", 14.25F);
            lblTarih.ImeMode = ImeMode.NoControl;
            lblTarih.Location = new Point(10, 143);
            lblTarih.Name = "lblTarih";
            lblTarih.Size = new Size(57, 23);
            lblTarih.TabIndex = 103;
            lblTarih.Text = "Tarih";
            // 
            // lblVeren
            // 
            lblVeren.AutoSize = true;
            lblVeren.Font = new Font("Verdana", 14.25F);
            lblVeren.ImeMode = ImeMode.NoControl;
            lblVeren.Location = new Point(10, 179);
            lblVeren.Name = "lblVeren";
            lblVeren.Size = new Size(64, 23);
            lblVeren.TabIndex = 104;
            lblVeren.Text = "Veren";
            // 
            // lblTutar
            // 
            lblTutar.AutoSize = true;
            lblTutar.Font = new Font("Verdana", 14.25F);
            lblTutar.ImeMode = ImeMode.NoControl;
            lblTutar.Location = new Point(10, 107);
            lblTutar.Name = "lblTutar";
            lblTutar.Size = new Size(58, 23);
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
            dgvGelirler.Location = new Point(12, 320);
            dgvGelirler.Name = "dgvGelirler";
            dgvGelirler.ReadOnly = true;
            dgvGelirler.RowHeadersWidth = 51;
            dgvGelirler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGelirler.Size = new Size(1226, 478);
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
            cmbGelirKategori.Location = new Point(191, 67);
            cmbGelirKategori.Name = "cmbGelirKategori";
            cmbGelirKategori.Size = new Size(396, 31);
            cmbGelirKategori.TabIndex = 94;
            cmbGelirKategori.SelectedIndexChanged += cmbGelirKategori_SelectedIndexChanged;
            // 
            // lblGelirKategori
            // 
            lblGelirKategori.AutoSize = true;
            lblGelirKategori.Font = new Font("Verdana", 14.25F);
            lblGelirKategori.ImeMode = ImeMode.NoControl;
            lblGelirKategori.Location = new Point(10, 75);
            lblGelirKategori.Name = "lblGelirKategori";
            lblGelirKategori.Size = new Size(142, 23);
            lblGelirKategori.TabIndex = 99;
            lblGelirKategori.Text = "Gelir Kategori";
            // 
            // pcBoxSil
            // 
            pcBoxSil.Cursor = Cursors.Hand;
            pcBoxSil.Image = (Image)resources.GetObject("pcBoxSil.Image");
            pcBoxSil.Location = new Point(282, 251);
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
            pcBoxGuncelle.Location = new Point(373, 252);
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
            pcBoxKaydet.Location = new Point(191, 251);
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
            lblToplamGelir.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblToplamGelir.Location = new Point(800, 283);
            lblToplamGelir.Name = "lblToplamGelir";
            lblToplamGelir.Size = new Size(26, 18);
            lblToplamGelir.TabIndex = 153;
            lblToplamGelir.Text = "00";
            // 
            // listViewGelirler
            // 
            listViewGelirler.BackColor = SystemColors.Control;
            listViewGelirler.BorderStyle = BorderStyle.None;
            listViewGelirler.Location = new Point(678, 66);
            listViewGelirler.Name = "listViewGelirler";
            listViewGelirler.Size = new Size(406, 196);
            listViewGelirler.TabIndex = 156;
            listViewGelirler.UseCompatibleStateImageBehavior = false;
            // 
            // FrmGelir
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1250, 802);
            Controls.Add(listViewGelirler);
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
        private Label lblToplamGelir;
        private ListView listViewGelirler;
    }
}