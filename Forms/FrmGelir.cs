using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Forms
{
    public partial class FrmGelir : Form
    {
        GelirKategoriManager gelirKategoriManager;
        GelirManager gelirManager;

        KoyManager koyManager;
        DonemManager donemManager;

        //AnaSayfada comboboxlardan yapılan seçimlerin index lerini getirmek için
        int _seciliKoyIndex;
        byte _seciliDonemIndex;

        ////AnaSayfada comboboxlardan yapılan seçimlerin index lerini getirmek için (int seciliKoyIndex,byte seciliDonemIndex) şeklinde formun constructorunda iki parametreyi FrmGelir formuna geçiyoruz
        public FrmGelir(int seciliKoyIndex, byte seciliDonemIndex)
        {
            //_seciliKoyIndex = seciliKoyIndex;
            //_seciliDonemIndex = seciliDonemIndex;

            InitializeComponent();

            GelirKategoriManager _gelirKategoriManager = new GelirKategoriManager(new EfGelirKategoriDal());
            gelirKategoriManager = _gelirKategoriManager;

            GelirManager _gelirManager = new GelirManager(new EfGelirDal());
            gelirManager = _gelirManager;

            KoyManager _koyManager = new KoyManager(new EfKoyDal());
            koyManager = _koyManager;

            DonemManager _donemManager = new DonemManager(new EfDonemDal());
            donemManager = _donemManager;

            //AnaSayfada comboboxlardan yapılan seçimlerin index lerini getirmek için
            _seciliKoyIndex = seciliKoyIndex;
            _seciliDonemIndex = seciliDonemIndex;
        }

            private void ToplamGelir()
        {
            // Toplam değeri tutmak için değişken
            decimal toplam = 0;

            // DataGridView'deki her satır için
            foreach (DataGridViewRow row in dgvGelirler.Rows)
            {
                // "Tutar" hücresindeki değeri kontrol et ve decimal'e çevir
                if (row.Cells["Tutar"].Value != null && decimal.TryParse(row.Cells["Tutar"].Value.ToString(), out decimal tutar))
                {
                    toplam += tutar;
                }
            }

            // Toplamı lblToplamGelir label'ına yaz
            lblToplamGelir.Text = toplam.ToString("C2"); // Currency formatında
        }

        private void GelirKategoriDoldur()
        {
            try
            {
                List<GelirKategori> gelirKategoriler = gelirKategoriManager.GetAll();
                cmbGelirKategori.Items.AddRange(gelirKategoriler.ToArray());
                cmbGelirKategori.Items.Insert(0, "-Gelir Türü Seçiniz-");
                cmbGelirKategori.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Gelir Türleri Listesi Getirilirken Hata Oluştu.");
                throw;
            }
        }

        private void FrmGelir_Load(object sender, EventArgs e)
        {

            try
            {
                ToplamGelir();
                GelirKategoriDoldur();
                Gizle();
                Gelirler();
                lblToplamGelir.Visible = false;
                HesaplaVeYazdir();
            }
            catch (Exception)
            {
                throw;
            }
        }

        ////Kaydet, Sil ve Güncelle sonucunda AnaSayfadaki lblToplamGelir'in anında güncellenmesi
        private void AnaSayfaGuncelle()
        {
            // FrmAnaSayfa formunu bul
            FrmAnaSayfa frmAnaSayfa = Application.OpenForms["FrmAnaSayfa"] as FrmAnaSayfa;

            // FrmAnaSayfa formu bulunduysa ve doğruysa Sonuc() metodunu çağır
            if (frmAnaSayfa != null)
            {
                frmAnaSayfa.GuncelleGelirVeGider();
                frmAnaSayfa.Sonuc();
            }
        }

        private void HesaplaVeYazdir()
        {
            // Toplam miktarları saklamak için bir sözlük oluştur
            Dictionary<int, decimal> toplamMiktarlar = new Dictionary<int, decimal>();

            // dgvGelirler'deki satırları kontrol et
            foreach (DataGridViewRow row in dgvGelirler.Rows)
            {
                int gelirKategoriId;
                decimal tutar;

                // Her satırın GelirKategoriId ve Tutar değerlerini al
                if (int.TryParse(row.Cells["GelirKategoriId"].Value.ToString(), out gelirKategoriId) &&
                    decimal.TryParse(row.Cells["Tutar"].Value.ToString(), out tutar))
                {
                    // Toplam miktarları sözlükte ilgili kategoriye göre topla
                    if (!toplamMiktarlar.ContainsKey(gelirKategoriId))
                    {
                        toplamMiktarlar[gelirKategoriId] = 0;
                    }

                    toplamMiktarlar[gelirKategoriId] += tutar;
                }
            }

            // Elde edilen toplam miktarları ilgili label'lere yazdır
            lblHasilat.Text = toplamMiktarlar.ContainsKey(1) && toplamMiktarlar[1] != 0 ? string.Format("{0:#,0.00}.-TL", toplamMiktarlar[1]) : "";
            lblHasilatYazi.Visible = !string.IsNullOrEmpty(lblHasilat.Text);

            lblResimHarc.Text = toplamMiktarlar.ContainsKey(2) && toplamMiktarlar[2] != 0 ? string.Format("{0:#,0.00}.-TL", toplamMiktarlar[2]) : "";
            lblResimHarcYazi.Visible = !string.IsNullOrWhiteSpace(lblResimHarc.Text);

            lblParaCezasi.Text = toplamMiktarlar.ContainsKey(3) && toplamMiktarlar[3] != 0 ? string.Format("{0:#,0.00}.-TL", toplamMiktarlar[3]) : "";
            lblParaCezasiYazi.Visible = !string.IsNullOrEmpty(lblParaCezasi.Text);

            lblYardim.Text = toplamMiktarlar.ContainsKey(4) && toplamMiktarlar[4] != 0 ? string.Format("{0:#,0.00}.-TL", toplamMiktarlar[4]) : "";
            lblYardimYazi.Visible = !string.IsNullOrEmpty(lblYardim.Text);

            lblKoyVakif.Text = toplamMiktarlar.ContainsKey(5) && toplamMiktarlar[5] != 0 ? string.Format("{0:#,0.00}.-TL", toplamMiktarlar[5]) : "";
            lblKoyVakifYazi.Visible = !string.IsNullOrEmpty(lblKoyVakif.Text);

            lblIstikraz.Text = toplamMiktarlar.ContainsKey(6) && toplamMiktarlar[6] != 0 ? string.Format("{0:#,0.00}.-TL", toplamMiktarlar[6]) : "";
            lblIstikrazYazi.Visible = !string.IsNullOrEmpty(lblIstikraz.Text);

            lblTurluGelir.Text = toplamMiktarlar.ContainsKey(7) && toplamMiktarlar[7] != 0 ? string.Format("{0:#,0.00}.-TL", toplamMiktarlar[7]) : "";
            lblTurluGelirYazi.Visible = !string.IsNullOrEmpty(lblTurluGelir.Text);

            lblDevir.Text = toplamMiktarlar.ContainsKey(8) && toplamMiktarlar[8] != 0 ? string.Format("{0:#,0.00}.-TL", toplamMiktarlar[8]) : "";
            lblDevirYazi.Visible = !string.IsNullOrEmpty(lblDevir.Text);
        }

        private void pcBoxKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtTutar.Text) && !string.IsNullOrEmpty(txtVeren.Text) && !string.IsNullOrEmpty(cmbGelirKategori.Text) && !string.IsNullOrEmpty(mskTarih.Text))
                {
                    Gelir yeniGelir = new Gelir();
                    yeniGelir.KoyId = _seciliKoyIndex;
                    yeniGelir.DonemId = _seciliDonemIndex;
                    yeniGelir.GelirKategoriId = (cmbGelirKategori.SelectedItem as GelirKategori).Id;//cmbGelirKategori'den seçilen öge GelirKategori türüne dönüştürülür, yoksa null değeri alır.
                    yeniGelir.Tutar = Convert.ToDecimal(txtTutar.Text);
                    yeniGelir.Tarih = Convert.ToDateTime(mskTarih.Text);
                    yeniGelir.Veren = txtVeren.Text;
                    yeniGelir.EvrakNo = txtEvrakNo.Text;

                    gelirManager.Add(yeniGelir);
                    Gelirler();
                    Temizle();

                    ToplamGelir();
                    HesaplaVeYazdir();
                }
                else
                {
                    MessageBox.Show("Lütfen Boş Alanları Doldurunuz!");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Gelir Kaydı Yapılamadı !!!");
                throw;
            }
        }

        private void Temizle()
        {
            cmbGelirKategori.SelectedIndex = 0;
            txtTutar.Text = "";
            mskTarih.Text = "";
            txtEvrakNo.Text = "";
            txtVeren.Text = "";
            cmbGelirKategori.Focus();
        }

        private void pcBoxSil_Click(object sender, EventArgs e)
        {
            try
            {
                // Seçili satırı kontrol et
                if (dgvGelirler.SelectedRows.Count > 0)
                {
                    // Kullanıcıya silme işlemini onaylamasını sor
                    var result = MessageBox.Show("Seçili satırı silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    // Eğer kullanıcı "Evet" derse
                    if (result == DialogResult.Yes)
                    {
                        // Seçili satırın bağlı olduğu veri nesnesini al
                        var selectedRow = dgvGelirler.SelectedRows[0];
                        var gelirDetailDto = (GelirDetailDto)selectedRow.DataBoundItem;

                        // Silinecek Gelir nesnesini oluştur
                        var gelir = new Gelir
                        {
                            Id = gelirDetailDto.GelirId,
                            // Diğer özellikleri de buradan alabilirsiniz
                        };

                        // Silme işlemini gerçekleştir
                        gelirManager.Delete(gelir);

                        // Daha sonra DataGridView'i güncelleyebilirsiniz
                        Gelirler();
                        HesaplaVeYazdir();
                        AnaSayfaGuncelle();
                        Temizle();
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen silmek istediğiniz bir satır seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silme işlemi sırasında bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Gelirleri DatagridView'e yükleyecek metot
        private void Gelirler()
        {
            try
            {
                dgvGelirler.DataSource = gelirManager.GetListGelirDetailsKoyAndDonemId(_seciliKoyIndex, _seciliDonemIndex);
                dgvGelirler.Columns["GelirId"].Visible = false;
                dgvGelirler.Columns["KoyAdi"].Visible = false;
                dgvGelirler.Columns["DonemAdi"].Visible = false;
                dgvGelirler.Columns["KoyId"].Visible = false;
                dgvGelirler.Columns["DonemId"].Visible = false;
                dgvGelirler.Columns["GelirKategoriId"].Visible = false;
                dgvGelirler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//datagridview'in tüm alanı kaplamasını sağlıyor
                dgvGelirler.RowHeadersVisible = false; ///datagridview'in sol baştaki boş satırları gizliyor
                dgvGelirler.ColumnHeadersDefaultCellStyle.Font = new Font("Impact", 14);//Başlığın yazı fontu ve yazı büyüklüğü
                dgvGelirler.ColumnHeadersHeight = 40;
                dgvGelirler.EnableHeadersVisualStyles = false; //Başlık yazı rengini değiştermek için bu özelliğin false yapılması gerekir
                dgvGelirler.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray; //Başlık arka plan rengi

                dgvGelirler.Columns["GelirKategoriAdi"].HeaderText = "Kategori";
                dgvGelirler.Columns["EvrakNo"].HeaderText = "Evrak No";


                ToplamGelir(); // Veriler yenilendiğinde toplamı hesapla
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtTutar.Text) && !string.IsNullOrEmpty(txtVeren.Text) && !string.IsNullOrEmpty(cmbGelirKategori.Text) && !string.IsNullOrEmpty(mskTarih.Text))
                {
                    Gelir yeniGelir = new Gelir();
                    yeniGelir.KoyId = _seciliKoyIndex;
                    yeniGelir.DonemId = _seciliDonemIndex;
                    yeniGelir.GelirKategoriId = (cmbGelirKategori.SelectedItem as GelirKategori).Id;//cmbGelirKategori'den seçilen öge GelirKategori türüne dönüştürülür, yoksa null değeri alır.
                    yeniGelir.Tutar = Convert.ToDecimal(txtTutar.Text);
                    yeniGelir.Tarih = Convert.ToDateTime(mskTarih.Text);
                    yeniGelir.Veren = txtVeren.Text;
                    yeniGelir.EvrakNo = txtEvrakNo.Text;
                    gelirManager.Add(yeniGelir);
                    Gelirler();
                    Temizle();
                }
                else
                {
                    MessageBox.Show("Lütfen Boş Alanları Doldurunuz!");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Gelir Kayıt Edilemedi !...");
                throw;
            }
        }

        private void pnlGelirBaslik_Paint(object sender, PaintEventArgs e)
        {
            CenterLabel();
        }

        //LABEL'İN PANELİN ORTASINDA OLMASINI SAĞLAYAN METOT
        private void CenterLabel()
        {
            // Label'in boyutunu al
            int labelWidth = lblBaslik.Width;
            int labelHeight = lblBaslik.Height;

            // Panelin boyutunu al
            int panelWidth = pnlGelirBaslik.Width;
            int panelHeight = pnlGelirBaslik.Height;

            // Label'i panelin ortasına yerleştir
            int x = (panelWidth - labelWidth) / 2;
            int y = (panelHeight - labelHeight) / 2;

            lblBaslik.Location = new Point(x, y);
        }

        private void pcBoxGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                // Önceki seçili satırın indeksini sakla
                int previousRowIndex = dgvGelirler.CurrentRow.Index;

                // Seçili satırın verilerini al
                GelirDetailDto seciliGelir = (GelirDetailDto)dgvGelirler.CurrentRow.DataBoundItem;
                // Güncellenecek verileri al
                int gelirId = seciliGelir.GelirId;
                byte gelirKategoriId = (byte)cmbGelirKategori.SelectedIndex; // cmbGelirKategori'den seçilen öğenin Id'sini al
                decimal tutar = Convert.ToDecimal(txtTutar.Text);
                DateTime tarih = Convert.ToDateTime(mskTarih.Text);
                string veren = txtVeren.Text;
                string evrakNo = txtEvrakNo.Text;

                // Güncelleme işlemini yap
                Gelir guncellenecekGelir = new Gelir
                {
                    Id = gelirId,
                    Tutar = tutar,
                    Tarih = tarih,
                    Veren = veren,
                    EvrakNo = evrakNo,
                    KoyId = _seciliKoyIndex,
                    DonemId = _seciliDonemIndex,
                    GelirKategoriId = gelirKategoriId,
                };

                // Güncelleme işlemini yapmak için GelirManager üzerinden Update metodunu çağır
                gelirManager.Update(guncellenecekGelir);

                // Başarılı bir şekilde güncelleme yapıldı mesajı göster
                MessageBox.Show("Gelir başarıyla güncellendi.");

                Temizle();

                // Yeniden yükleme işlemi (opsiyonel)
                Gelirler();
                HesaplaVeYazdir();
                AnaSayfaGuncelle();

                // Tüm satırların seçiliğini kaldır
                foreach (DataGridViewRow row in dgvGelirler.Rows)
                {
                    row.Selected = false;
                }

                // Önceki seçili satırı tekrar seç
                dgvGelirler.Rows[previousRowIndex].Selected = true;

                // DataGridView'in ilgili satırını görünür alan içine kaydır
                dgvGelirler.FirstDisplayedScrollingRowIndex = previousRowIndex;
            }
            catch (Exception ex)
            {
                // Hata durumunda kullanıcıya bilgi ver
                MessageBox.Show("Gelir güncellenirken bir hata oluştu: " + ex.Message);
            }
        }

        private void dgvGelirler_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Satırın indeksini al
            int rowIndex = e.RowIndex;

            // Seçili satırın verilerini al
            if (rowIndex >= 0 && rowIndex < dgvGelirler.Rows.Count)
            {
                DataGridViewRow selectedRow = dgvGelirler.Rows[rowIndex];

                // Verileri ilgili alanlara aktar
                cmbGelirKategori.SelectedIndex = (byte)selectedRow.Cells["GelirKategoriId"].Value;
                cmbGelirKategori.SelectedText = selectedRow.Cells["GelirKategoriAdi"].Value.ToString();
                txtTutar.Text = selectedRow.Cells["Tutar"].Value.ToString();
                mskTarih.Text = selectedRow.Cells["Tarih"].Value.ToString();
                txtVeren.Text = selectedRow.Cells["Veren"].Value.ToString();
                txtEvrakNo.Text = selectedRow.Cells["EvrakNo"].Value.ToString();

                // Seçili satırı işaretle
                dgvGelirler.Rows[rowIndex].Selected = true;
            }
        }


        private void txtVeren_TextChanged(object sender, EventArgs e)
        {
            txtVeren.Text = txtVeren.Text.ToUpper();
            txtVeren.SelectionStart = txtVeren.Text.Length; // Metnin sonuna atlamak için
        }

        private void cmbGelirKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGelirKategori.SelectedIndex > 0)
            {
                txtTutar.Visible = true;
                lblTutar.Visible = true;
                mskTarih.Visible = true;
                lblTarih.Visible = true;
                txtTutar.Visible = true;
                lblTutar.Visible = true;
                txtVeren.Visible = true;
                lblVeren.Visible = true;
                txtEvrakNo.Visible = true;
                lblEvrakNo.Visible = true;
                pcBoxKaydet.Visible = true;
                pcBoxGuncelle.Visible = true;
                pcBoxSil.Visible = true;
            }
        }

        private void Gizle()
        {
            txtTutar.Visible = false;
            lblTutar.Visible = false;
            mskTarih.Visible = false;
            lblTarih.Visible = false;
            txtTutar.Visible = false;
            lblTutar.Visible = false;
            txtVeren.Visible = false;
            lblVeren.Visible = false;
            txtEvrakNo.Visible = false;
            lblEvrakNo.Visible = false;
            pcBoxKaydet.Visible = false;
            pcBoxGuncelle.Visible = false;
            pcBoxSil.Visible = false;
        }
    }
}
