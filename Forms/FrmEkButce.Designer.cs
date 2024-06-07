namespace Forms
{
    partial class FrmEkButce
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEkButce));
            txtTutar = new TextBox();
            label7 = new Label();
            pnlGelirBaslik = new Panel();
            lblBaslik = new Label();
            pcBoxSil = new PictureBox();
            pcBoxGuncelle = new PictureBox();
            pcBoxKaydet = new PictureBox();
            dgvEkButceler = new DataGridView();
            pnlEkButceButonlari = new Panel();
            pcBoxEkGider = new PictureBox();
            pcBoxEkGelir = new PictureBox();
            pnlEkButceFormlari = new Panel();
            pnlGelirBaslik.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pcBoxSil).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxGuncelle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxKaydet).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvEkButceler).BeginInit();
            pnlEkButceButonlari.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pcBoxEkGider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxEkGelir).BeginInit();
            SuspendLayout();
            // 
            // txtTutar
            // 
            txtTutar.Font = new Font("Lucida Calligraphy", 14.25F);
            txtTutar.Location = new Point(177, 64);
            txtTutar.Name = "txtTutar";
            txtTutar.Size = new Size(238, 33);
            txtTutar.TabIndex = 118;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Lucida Calligraphy", 14.25F);
            label7.ImeMode = ImeMode.NoControl;
            label7.Location = new Point(2, 67);
            label7.Name = "label7";
            label7.Size = new Size(172, 24);
            label7.TabIndex = 119;
            label7.Text = "Ek Bütçe Tutarı";
            // 
            // pnlGelirBaslik
            // 
            pnlGelirBaslik.Controls.Add(lblBaslik);
            pnlGelirBaslik.Dock = DockStyle.Top;
            pnlGelirBaslik.Location = new Point(0, 0);
            pnlGelirBaslik.Name = "pnlGelirBaslik";
            pnlGelirBaslik.Size = new Size(1250, 60);
            pnlGelirBaslik.TabIndex = 133;
            // 
            // lblBaslik
            // 
            lblBaslik.AutoSize = true;
            lblBaslik.Font = new Font("321impact", 35.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblBaslik.Location = new Point(474, 3);
            lblBaslik.Name = "lblBaslik";
            lblBaslik.Size = new Size(216, 53);
            lblBaslik.TabIndex = 1;
            lblBaslik.Text = "EK BÜTÇE";
            // 
            // pcBoxSil
            // 
            pcBoxSil.Cursor = Cursors.Hand;
            pcBoxSil.Image = (Image)resources.GetObject("pcBoxSil.Image");
            pcBoxSil.Location = new Point(239, 102);
            pcBoxSil.Name = "pcBoxSil";
            pcBoxSil.Size = new Size(85, 65);
            pcBoxSil.SizeMode = PictureBoxSizeMode.StretchImage;
            pcBoxSil.TabIndex = 135;
            pcBoxSil.TabStop = false;
            pcBoxSil.Click += pcBoxSil_Click;
            // 
            // pcBoxGuncelle
            // 
            pcBoxGuncelle.Cursor = Cursors.Hand;
            pcBoxGuncelle.Image = (Image)resources.GetObject("pcBoxGuncelle.Image");
            pcBoxGuncelle.Location = new Point(330, 102);
            pcBoxGuncelle.Name = "pcBoxGuncelle";
            pcBoxGuncelle.Size = new Size(85, 65);
            pcBoxGuncelle.SizeMode = PictureBoxSizeMode.StretchImage;
            pcBoxGuncelle.TabIndex = 136;
            pcBoxGuncelle.TabStop = false;
            pcBoxGuncelle.Click += pcBoxGuncelle_Click;
            // 
            // pcBoxKaydet
            // 
            pcBoxKaydet.Cursor = Cursors.Hand;
            pcBoxKaydet.Image = Properties.Resources.Kaydet1;
            pcBoxKaydet.Location = new Point(148, 102);
            pcBoxKaydet.Name = "pcBoxKaydet";
            pcBoxKaydet.Size = new Size(85, 65);
            pcBoxKaydet.SizeMode = PictureBoxSizeMode.StretchImage;
            pcBoxKaydet.TabIndex = 137;
            pcBoxKaydet.TabStop = false;
            pcBoxKaydet.Click += pcBoxKaydet_Click;
            // 
            // dgvEkButceler
            // 
            dgvEkButceler.AllowUserToAddRows = false;
            dgvEkButceler.AllowUserToDeleteRows = false;
            dgvEkButceler.AllowUserToResizeColumns = false;
            dgvEkButceler.AllowUserToResizeRows = false;
            dgvEkButceler.BackgroundColor = SystemColors.Control;
            dgvEkButceler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEkButceler.Location = new Point(3, 174);
            dgvEkButceler.Name = "dgvEkButceler";
            dgvEkButceler.ReadOnly = true;
            dgvEkButceler.RowHeadersWidth = 51;
            dgvEkButceler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEkButceler.Size = new Size(412, 623);
            dgvEkButceler.TabIndex = 138;
            dgvEkButceler.DataSourceChanged += dgvEkButceler_DataSourceChanged;
            dgvEkButceler.CellDoubleClick += dgvEkButceler_CellDoubleClick;
            // 
            // pnlEkButceButonlari
            // 
            pnlEkButceButonlari.Controls.Add(pcBoxEkGider);
            pnlEkButceButonlari.Controls.Add(pcBoxEkGelir);
            pnlEkButceButonlari.Location = new Point(455, 64);
            pnlEkButceButonlari.Name = "pnlEkButceButonlari";
            pnlEkButceButonlari.Size = new Size(288, 104);
            pnlEkButceButonlari.TabIndex = 140;
            // 
            // pcBoxEkGider
            // 
            pcBoxEkGider.Cursor = Cursors.Hand;
            pcBoxEkGider.Image = (Image)resources.GetObject("pcBoxEkGider.Image");
            pcBoxEkGider.Location = new Point(146, 10);
            pcBoxEkGider.Name = "pcBoxEkGider";
            pcBoxEkGider.Size = new Size(130, 80);
            pcBoxEkGider.SizeMode = PictureBoxSizeMode.StretchImage;
            pcBoxEkGider.TabIndex = 115;
            pcBoxEkGider.TabStop = false;
            pcBoxEkGider.Click += pcBoxEkGider_Click;
            // 
            // pcBoxEkGelir
            // 
            pcBoxEkGelir.Cursor = Cursors.Hand;
            pcBoxEkGelir.Image = (Image)resources.GetObject("pcBoxEkGelir.Image");
            pcBoxEkGelir.Location = new Point(10, 10);
            pcBoxEkGelir.Name = "pcBoxEkGelir";
            pcBoxEkGelir.Size = new Size(130, 80);
            pcBoxEkGelir.SizeMode = PictureBoxSizeMode.StretchImage;
            pcBoxEkGelir.TabIndex = 114;
            pcBoxEkGelir.TabStop = false;
            pcBoxEkGelir.Click += pcBoxEkGelir_Click;
            // 
            // pnlEkButceFormlari
            // 
            pnlEkButceFormlari.Location = new Point(421, 174);
            pnlEkButceFormlari.Name = "pnlEkButceFormlari";
            pnlEkButceFormlari.Size = new Size(817, 764);
            pnlEkButceFormlari.TabIndex = 141;
            // 
            // FrmEkButce
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1250, 802);
            Controls.Add(pnlEkButceFormlari);
            Controls.Add(pnlEkButceButonlari);
            Controls.Add(dgvEkButceler);
            Controls.Add(pcBoxSil);
            Controls.Add(pcBoxGuncelle);
            Controls.Add(pcBoxKaydet);
            Controls.Add(pnlGelirBaslik);
            Controls.Add(txtTutar);
            Controls.Add(label7);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmEkButce";
            Text = "FrmEkButce";
            Load += FrmEkButce_Load;
            pnlGelirBaslik.ResumeLayout(false);
            pnlGelirBaslik.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pcBoxSil).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxGuncelle).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxKaydet).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvEkButceler).EndInit();
            pnlEkButceButonlari.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pcBoxEkGider).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcBoxEkGelir).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtTutar;
        private Label label7;
        private Panel pnlGelirBaslik;
        private Label lblBaslik;
        private PictureBox pcBoxSil;
        private PictureBox pcBoxGuncelle;
        private PictureBox pcBoxKaydet;
        private DataGridView dgvEkButceler;
        public Panel pnlEkButceButonlari;
        private PictureBox pcBoxEkGider;
        private PictureBox pcBoxEkGelir;
        private Panel pnlEkButceFormlari;
    }
}