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
            dgvGiderler = new DataGridView();
            listViewGiderler = new ListView();
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
            lblBaslik.Location = new Point(182, 4);
            lblBaslik.Name = "lblBaslik";
            lblBaslik.Size = new Size(351, 53);
            lblBaslik.TabIndex = 1;
            lblBaslik.Text = "GİDER İŞLEMLERİ";
            // 
            // mskTarih
            // 
            mskTarih.Cursor = Cursors.IBeam;
            mskTarih.Font = new Font("Verdana", 14.25F);
            mskTarih.Location = new Point(214, 216);
            mskTarih.Mask = "00/00/0000";
            mskTarih.Name = "mskTarih";
            mskTarih.Size = new Size(126, 31);
            mskTarih.TabIndex = 112;
            mskTarih.ValidatingType = typeof(DateTime);
            // 
            // txtEvrakNo
            // 
            txtEvrakNo.Cursor = Cursors.IBeam;
            txtEvrakNo.Font = new Font("Verdana", 14.25F);
            txtEvrakNo.Location = new Point(214, 288);
            txtEvrakNo.Name = "txtEvrakNo";
            txtEvrakNo.Size = new Size(209, 31);
            txtEvrakNo.TabIndex = 114;
            // 
            // txtAlan
            // 
            txtAlan.Cursor = Cursors.IBeam;
            txtAlan.Font = new Font("Verdana", 14.25F);
            txtAlan.Location = new Point(214, 252);
            txtAlan.Name = "txtAlan";
            txtAlan.Size = new Size(209, 31);
            txtAlan.TabIndex = 113;
            // 
            // txtTutar
            // 
            txtTutar.Cursor = Cursors.IBeam;
            txtTutar.Font = new Font("Verdana", 14.25F);
            txtTutar.Location = new Point(214, 180);
            txtTutar.Name = "txtTutar";
            txtTutar.Size = new Size(209, 31);
            txtTutar.TabIndex = 111;
            txtTutar.KeyPress += txtTutar_KeyPress;
            // 
            // lblEvrakNo
            // 
            lblEvrakNo.AutoSize = true;
            lblEvrakNo.Font = new Font("Verdana", 14.25F);
            lblEvrakNo.ImeMode = ImeMode.NoControl;
            lblEvrakNo.Location = new Point(10, 291);
            lblEvrakNo.Name = "lblEvrakNo";
            lblEvrakNo.Size = new Size(96, 23);
            lblEvrakNo.TabIndex = 118;
            lblEvrakNo.Text = "Evrak No";
            // 
            // lblTarih
            // 
            lblTarih.AutoSize = true;
            lblTarih.Font = new Font("Verdana", 14.25F);
            lblTarih.ImeMode = ImeMode.NoControl;
            lblTarih.Location = new Point(10, 219);
            lblTarih.Name = "lblTarih";
            lblTarih.Size = new Size(57, 23);
            lblTarih.TabIndex = 119;
            lblTarih.Text = "Tarih";
            // 
            // lblAlan
            // 
            lblAlan.AutoSize = true;
            lblAlan.Font = new Font("Verdana", 14.25F);
            lblAlan.ImeMode = ImeMode.NoControl;
            lblAlan.Location = new Point(10, 255);
            lblAlan.Name = "lblAlan";
            lblAlan.Size = new Size(52, 23);
            lblAlan.TabIndex = 120;
            lblAlan.Text = "Alan";
            // 
            // lblTutar
            // 
            lblTutar.AutoSize = true;
            lblTutar.Font = new Font("Verdana", 14.25F);
            lblTutar.ImeMode = ImeMode.NoControl;
            lblTutar.Location = new Point(10, 183);
            lblTutar.Name = "lblTutar";
            lblTutar.Size = new Size(58, 23);
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
            cmbGiderKategori.Location = new Point(214, 100);
            cmbGiderKategori.Name = "cmbGiderKategori";
            cmbGiderKategori.Size = new Size(396, 31);
            cmbGiderKategori.TabIndex = 110;
            cmbGiderKategori.SelectedIndexChanged += cmbGiderKategori_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Verdana", 14.25F);
            label1.ImeMode = ImeMode.NoControl;
            label1.Location = new Point(10, 103);
            label1.Name = "label1";
            label1.Size = new Size(148, 23);
            label1.TabIndex = 115;
            label1.Text = "Gider Kategori";
            // 
            // pnlGiderBaslik
            // 
            pnlGiderBaslik.Controls.Add(lblBaslik);
            pnlGiderBaslik.Dock = DockStyle.Top;
            pnlGiderBaslik.Location = new Point(0, 0);
            pnlGiderBaslik.Name = "pnlGiderBaslik";
            pnlGiderBaslik.Size = new Size(1250, 60);
            pnlGiderBaslik.TabIndex = 109;
            // 
            // lblGiderAltKategori
            // 
            lblGiderAltKategori.AutoSize = true;
            lblGiderAltKategori.Font = new Font("Verdana", 14.25F);
            lblGiderAltKategori.ImeMode = ImeMode.NoControl;
            lblGiderAltKategori.Location = new Point(10, 143);
            lblGiderAltKategori.Name = "lblGiderAltKategori";
            lblGiderAltKategori.Size = new Size(181, 23);
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
            cmbGiderAltKategori.Location = new Point(214, 140);
            cmbGiderAltKategori.Name = "cmbGiderAltKategori";
            cmbGiderAltKategori.Size = new Size(396, 31);
            cmbGiderAltKategori.TabIndex = 110;
            cmbGiderAltKategori.SelectedIndexChanged += cmbGiderAltKategori_SelectedIndexChanged;
            // 
            // pcBoxSil
            // 
            pcBoxSil.Cursor = Cursors.Hand;
            pcBoxSil.Image = (Image)resources.GetObject("pcBoxSil.Image");
            pcBoxSil.Location = new Point(305, 327);
            pcBoxSil.Name = "pcBoxSil";
            pcBoxSil.Size = new Size(85, 65);
            pcBoxSil.SizeMode = PictureBoxSizeMode.StretchImage;
            pcBoxSil.TabIndex = 122;
            pcBoxSil.TabStop = false;
            pcBoxSil.Click += pcBoxSil_Click;
            // 
            // pcBoxGuncelle
            // 
            pcBoxGuncelle.Cursor = Cursors.Hand;
            pcBoxGuncelle.Image = (Image)resources.GetObject("pcBoxGuncelle.Image");
            pcBoxGuncelle.Location = new Point(396, 328);
            pcBoxGuncelle.Name = "pcBoxGuncelle";
            pcBoxGuncelle.Size = new Size(85, 65);
            pcBoxGuncelle.SizeMode = PictureBoxSizeMode.StretchImage;
            pcBoxGuncelle.TabIndex = 123;
            pcBoxGuncelle.TabStop = false;
            pcBoxGuncelle.Click += pcBoxGuncelle_Click;
            // 
            // pcBoxKaydet
            // 
            pcBoxKaydet.Cursor = Cursors.Hand;
            pcBoxKaydet.Image = Properties.Resources.Kaydet1;
            pcBoxKaydet.Location = new Point(214, 327);
            pcBoxKaydet.Name = "pcBoxKaydet";
            pcBoxKaydet.Size = new Size(85, 65);
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
            lblToplamGider.Location = new Point(21, 363);
            lblToplamGider.Name = "lblToplamGider";
            lblToplamGider.Size = new Size(36, 24);
            lblToplamGider.TabIndex = 119;
            lblToplamGider.Text = "00";
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
            dgvGiderler.Location = new Point(12, 394);
            dgvGiderler.Name = "dgvGiderler";
            dgvGiderler.ReadOnly = true;
            dgvGiderler.RowHeadersWidth = 51;
            dgvGiderler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGiderler.Size = new Size(1226, 424);
            dgvGiderler.TabIndex = 128;
            dgvGiderler.CellDoubleClick += dgvGiderler_CellDoubleClick;
            // 
            // listViewGiderler
            // 
            listViewGiderler.BackColor = SystemColors.Control;
            listViewGiderler.BorderStyle = BorderStyle.None;
            listViewGiderler.Location = new Point(632, 66);
            listViewGiderler.Name = "listViewGiderler";
            listViewGiderler.Size = new Size(465, 317);
            listViewGiderler.TabIndex = 129;
            listViewGiderler.UseCompatibleStateImageBehavior = false;
            // 
            // FrmGider
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1250, 802);
            Controls.Add(listViewGiderler);
            Controls.Add(dgvGiderler);
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
        public DataGridView dgvGiderler;
        private ListView listViewGiderler;
    }
}