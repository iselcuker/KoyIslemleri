using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Forms
{
    public partial class FrmGider : Form
    {
        // Yöneticiler ve seçili indeksler için gerekli değişkenler tanımlanıyor
        private GiderManager giderManager;
        private GiderKategoriManager giderKategoriManager;
        private GiderAltKategoriManager giderAltKategoriManager;
        private KoyManager koyManager;
        private DonemManager donemManager;
        private int _seciliKoyIndex;
        private byte _seciliDonemIndex;

        // Constructor: Form yüklendiğinde gerekli yöneticiler ve indeksler oluşturuluyor
        public FrmGider(int seciliKoyIndex, byte seciliDonemIndex)
        {
            InitializeComponent();

            // Yöneticiler oluşturuluyor ve alanlara atanıyor
            giderManager = new GiderManager(new EfGiderDal());
            giderKategoriManager = new GiderKategoriManager(new EfGiderKategoriDal());
            giderAltKategoriManager = new GiderAltKategoriManager(new EfGiderAltKategoriDal());
            koyManager = new KoyManager(new EfKoyDal());
            donemManager = new DonemManager(new EfDonemDal());

            // Parametreler sınıfın alanlarına atanıyor
            _seciliKoyIndex = seciliKoyIndex;
            _seciliDonemIndex = seciliDonemIndex;
        }

        // Gider kategorilerini doldurur
        private void GiderKategoriDoldur()
        {
            try
            {
                // ComboBox'ı temizle
                cmbGiderKategori.Items.Clear();

                // Varsayılan seçeneği eklemek için bir gider kategorisi oluştur
                GiderKategori varsayilanKategori = new GiderKategori
                {
                    Id = 0,
                    GiderKategoriAdi = "-Gider Türü Seçiniz-"
                };

                // Varsayılan seçeneği ilk sıraya ekle
                cmbGiderKategori.Items.Add(varsayilanKategori);

                // Gider kategorilerini veritabanından çek
                List<GiderKategori> giderKategoriList = giderKategoriManager.GetAll();

                // Gider kategorilerini cmbGiderKategori'ye ekle
                foreach (GiderKategori kategori in giderKategoriList)
                {
                    cmbGiderKategori.Items.Add(kategori);
                }

                // cmbGiderKategori'nin Ad özelliğini göster
                cmbGiderKategori.DisplayMember = "GiderKategoriAdi";

                // cmbGiderKategori'nin ValueMember özelliğini Id'ye ata
                cmbGiderKategori.ValueMember = "Id";

                // Varsayılan seçeneği seçili hale getir
                cmbGiderKategori.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gider kategorileri yüklenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HesaplaVeYazdir()
        {
            // Toplam miktarları saklamak için bir sözlük oluştur
            Dictionary<int, decimal> toplamMiktarlar = new Dictionary<int, decimal>();

            // dgvGiderler'deki satırları kontrol et
            foreach (DataGridViewRow row in dgvGiderler.Rows)
            {
                int giderAltKategoriId;
                decimal tutar;

                // Her satırın GiderAltKategoriId ve Tutar değerlerini al
                if (int.TryParse(row.Cells["GiderAltKategoriId"].Value.ToString(), out giderAltKategoriId) &&
                    decimal.TryParse(row.Cells["Tutar"].Value.ToString(), out tutar))
                {
                    // Toplam miktarları sözlükte ilgili kategoriye göre topla
                    if (!toplamMiktarlar.ContainsKey(giderAltKategoriId))
                    {
                        toplamMiktarlar[giderAltKategoriId] = 0;
                    }

                    toplamMiktarlar[giderAltKategoriId] += tutar;
                }
            }

            // Elde edilen toplam miktarları ilgili label'lere yazdır
            lblAylik.Text = toplamMiktarlar.ContainsKey(1) ? string.Format("{0:#,0.00}.-TL", toplamMiktarlar[1]) : "";
            lblAylikYazi.Visible = !string.IsNullOrEmpty(lblAylik.Text);

            lblIdariMasraf.Text = toplamMiktarlar.ContainsKey(2) ? string.Format("{0:#,0.00}.-TL", toplamMiktarlar[2]) : "";
            lblIdariMasrafYazi.Visible = !string.IsNullOrEmpty(lblIdariMasraf.Text);

            lblSulama.Text = toplamMiktarlar.ContainsKey(3) ? string.Format("{0:#,0.00}.-TL", toplamMiktarlar[3]) : "";
            lblSulamaYazi.Visible = !string.IsNullOrEmpty(lblSulama.Text);

            lblAgaclama.Text = toplamMiktarlar.ContainsKey(4) ? string.Format("{0:#,0.00}.-TL", toplamMiktarlar[4]) : "";
            lblAgaclamaYazi.Visible = !string.IsNullOrEmpty(lblAgaclama.Text);

            lblDamizlik.Text = toplamMiktarlar.ContainsKey(5) ? string.Format("{0:#,0.00}.-TL", toplamMiktarlar[5]) : "";
            lblDamizlikYazi.Visible = !string.IsNullOrEmpty(lblDamizlik.Text);

            lblOrnetTarla.Text = toplamMiktarlar.ContainsKey(6) ? string.Format("{0:#,0.00}.-TL", toplamMiktarlar[6]) : "";
            lblOrnetTarlaYazi.Visible = !string.IsNullOrEmpty(lblOrnetTarla.Text);

            lblZararliHayvan.Text = toplamMiktarlar.ContainsKey(7) ? string.Format("{0:#,0.00}.-TL", toplamMiktarlar[7]) : "";
            lblZararliHayvanYazi.Visible = !string.IsNullOrEmpty(lblZararliHayvan.Text);

            lblPazarCarsi.Text = toplamMiktarlar.ContainsKey(8) ? string.Format("{0:#,0.00}.-TL", toplamMiktarlar[8]) : "";
            lblPazarCarsiYazi.Visible = !string.IsNullOrEmpty(lblPazarCarsi.Text);

            lblKucukEndustri.Text = toplamMiktarlar.ContainsKey(9) ? string.Format("{0:#,0.00}.-TL", toplamMiktarlar[9]) : "";
            lblKucukEndustriYazi.Visible = !string.IsNullOrEmpty(lblKucukEndustri.Text);

            lblOkulOgretmenevi.Text = toplamMiktarlar.ContainsKey(10) ? string.Format("{0:#,0.00}.-TL", toplamMiktarlar[10]) : "";
            lblOkulOgretmeneviYazi.Visible = !string.IsNullOrEmpty(lblOkulOgretmenevi.Text);

            lblOkulDaimi.Text = toplamMiktarlar.ContainsKey(11) ? string.Format("{0:#,0.00}.-TL", toplamMiktarlar[11]) : "";
            lblOkulDaimiYazi.Visible = !string.IsNullOrEmpty(lblOkulDaimi.Text);

            lblOkumaOdasi.Text = toplamMiktarlar.ContainsKey(12) ? string.Format("{0:#,0.00}.-TL", toplamMiktarlar[12]) : "";
            lblOkumaOdasiYazi.Visible = !string.IsNullOrEmpty(lblOkumaOdasi.Text);

            lblKurs.Text = toplamMiktarlar.ContainsKey(13) ? string.Format("{0:#,0.00}.-TL", toplamMiktarlar[13]) : "";
            lblKursYazi.Visible = !string.IsNullOrEmpty(lblKurs.Text);

            lblOkulUygulama.Text = toplamMiktarlar.ContainsKey(14) ? string.Format("{0:#,0.00}.-TL", toplamMiktarlar[14]) : "";
            lblOkulUygulamaYazi.Visible = !string.IsNullOrEmpty(lblOkulUygulama.Text);
            //
            lblIcmeSulari.Text = toplamMiktarlar.ContainsKey(15) ? string.Format("{0:#,0.00}.-TL", toplamMiktarlar[15]) : "";
            lblIcmeSulariYazi.Visible = !string.IsNullOrEmpty(lblIcmeSulari.Text);

            //16
            lblTemizlik.Text = toplamMiktarlar.ContainsKey(16) ? string.Format("{0:#,0.00}.-TL", toplamMiktarlar[16]) : "";
            lblTemizlikYazi.Visible = !string.IsNullOrEmpty(lblTemizlik.Text);
            //17
            lblSpor.Text = toplamMiktarlar.ContainsKey(17) ? string.Format("{0:#,0.00}.-TL", toplamMiktarlar[17]) : "";
            lblSporYazi.Visible = !string.IsNullOrEmpty(lblSpor.Text);
            //18
            lblIctimai.Text = toplamMiktarlar.ContainsKey(18) ? string.Format("{0:#,0.00}.-TL", toplamMiktarlar[18]) : "";
            lblIctimaiYazi.Visible = !string.IsNullOrEmpty(lblIctimai.Text);
            //19
            lblYolKopru.Text = toplamMiktarlar.ContainsKey(19) ? string.Format("{0:#,0.00}.-TL", toplamMiktarlar[19]) : "";
            lblYolKopruYazi.Visible = !string.IsNullOrEmpty(lblYolKopru.Text);
            //20
            lblKoyeAitAkar.Text = toplamMiktarlar.ContainsKey(20) ? string.Format("{0:#,0.00}.-TL", toplamMiktarlar[20]) : "";
            lblKoyeAitAkarYazi.Visible = !string.IsNullOrEmpty(lblKoyeAitAkar.Text);
            //21
            lblYanginVesaiti.Text = toplamMiktarlar.ContainsKey(21) ? string.Format("{0:#,0.00}.-TL", toplamMiktarlar[21]) : "";
            lblYanginVesaitiYazi.Visible = !string.IsNullOrEmpty(lblYanginVesaiti.Text);
            //22
            lblAydinlatma.Text = toplamMiktarlar.ContainsKey(22) ? string.Format("{0:#,0.00}.-TL", toplamMiktarlar[22]) : "";
            lblAydinlatmaYazi.Visible = !string.IsNullOrEmpty(lblAydinlatma.Text);
            //23
            lblMezarlik.Text = toplamMiktarlar.ContainsKey(23) ? string.Format("{0:#,0.00}.-TL", toplamMiktarlar[23]) : "";
            lblMezarlikYazi.Visible = !string.IsNullOrEmpty(lblMezarlik.Text);
            //24
            lblTurluMasraf.Text = toplamMiktarlar.ContainsKey(24) ? string.Format("{0:#,0.00}.-TL", toplamMiktarlar[24]) : "";
            lblTurluMasrafYazi.Visible = !string.IsNullOrEmpty(lblTurluMasraf.Text);
            //25
            lblVergiSigorta.Text = toplamMiktarlar.ContainsKey(25) ? string.Format("{0:#,0.00}.-TL", toplamMiktarlar[25]) : "";
            lblVergiSigortaYazi.Visible = !string.IsNullOrEmpty(lblVergiSigorta.Text);
            //26
            lblKoyBorclari.Text = toplamMiktarlar.ContainsKey(26) ? string.Format("{0:#,0.00}.-TL", toplamMiktarlar[26]) : "";
            lblKoyBorclariYazi.Visible = !string.IsNullOrEmpty(lblKoyBorclari.Text);
            //27
            lblMahkemeKesif.Text = toplamMiktarlar.ContainsKey(27) ? string.Format("{0:#,0.00}.-TL", toplamMiktarlar[27]) : "";
            lblMahkemeKesifYazi.Visible = !string.IsNullOrEmpty(lblMahkemeKesif.Text);
            //28
            lblIstimlakMasraf.Text = toplamMiktarlar.ContainsKey(28) ? string.Format("{0:#,0.00}.-TL", toplamMiktarlar[28]) : "";
            lblIstimlakMasrafYazi.Visible = !string.IsNullOrEmpty(lblIstimlakMasraf.Text);
            //29
            lblUmulmadikMasraf.Text = toplamMiktarlar.ContainsKey(29) ? string.Format("{0:#,0.00}.-TL", toplamMiktarlar[29]) : "";
            lblUmulmadikMasrafYazi.Visible = !string.IsNullOrEmpty(lblUmulmadikMasraf.Text);
        }

        //Giderleri DatagridView'e yükleyecek metot
        private void Giderler()
        {
            try
            {
                DataGridVieweSiraNoEkle(dgvGiderler); // S.N kolonunu ekle

                var giderListesi = giderManager.GetListGiderDetailsKoyAndDonemId(_seciliKoyIndex, _seciliDonemIndex);

                dgvGiderler.DataSource = giderListesi; // Verileri bağla

                // S.N numaralarını güncelleyelim
                for (int i = 0; i < dgvGiderler.Rows.Count; i++)
                {
                    dgvGiderler.Rows[i].Cells["SN"].Value = (i + 1).ToString();
                }

                dgvGiderler.Columns["GiderId"].Visible = false;
                dgvGiderler.Columns["KoyAdi"].Visible = false;
                dgvGiderler.Columns["DonemAdi"].Visible = false;
                dgvGiderler.Columns["KoyId"].Visible = false;
                dgvGiderler.Columns["DonemId"].Visible = false;
                dgvGiderler.Columns["GiderKategoriId"].Visible = false;
                dgvGiderler.Columns["GiderAltKategoriId"].Visible = false;

                dgvGiderler.Columns["GiderKategoriAdi"].HeaderText = "Kategori";
                dgvGiderler.Columns["GiderAltKategoriAdi"].HeaderText = "Alt Kategori";
                dgvGiderler.Columns["EvrakNo"].HeaderText = "Evrak No";

                ToplamGider(); // Veriler yenilendiğinde toplamı hesapla
            }
            catch (Exception ex)
            {
                MessageBox.Show("Giderler yüklenirken bir hata oluştu: " + ex.Message);
            }
        }

        public void DataGridVieweSiraNoEkle(DataGridView dataGridView)
        {
            // S.N kolonunu ekle, eğer zaten yoksa
            if (!dataGridView.Columns.Contains("SN"))
            {
                DataGridViewTextBoxColumn snColumn = new DataGridViewTextBoxColumn();
                snColumn.Name = "SN";
                snColumn.HeaderText = "S.N";
                snColumn.ReadOnly = true; // Sıra numarası kolonunu yalnızca okunabilir yap
                dataGridView.Columns.Insert(0, snColumn); // Kolonu en başa ekleyelim
            }

            // Diğer DataGridView ayarları
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.RowHeadersVisible = false;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Impact", 14);
            dataGridView.ColumnHeadersHeight = 40;
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
        }
        private void FrmGider_Load(object sender, EventArgs e)
        {
            try
            {
                ToplamGider();
                // Gider kategorilerini doldur
                GiderKategoriDoldur();
                DataGridVieweSiraNoEkle(dgvGiderler);
                Giderler();
                lblToplamGider.Visible = false;
                HesaplaVeYazdir();
                // İlk kategoriye göre alt kategorileri yükle
                if (cmbGiderKategori.SelectedItem != null)
                {

                    GiderAltKategorileriYukle((byte)((GiderKategori)cmbGiderKategori.SelectedItem).Id);
                }

                // dgvGiderler yüklenirken birinci satırı seçili yapma
                //dgvGiderler.ClearSelection();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Form yüklenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ToplamGider()
        {
            // Toplam değeri tutmak için değişken
            decimal toplam = 0;

            // DataGridView'deki her satır için
            foreach (DataGridViewRow row in dgvGiderler.Rows)
            {
                // "Tutar" hücresindeki değeri kontrol et ve decimal'e çevir
                if (row.Cells["Tutar"].Value != null && decimal.TryParse(row.Cells["Tutar"].Value.ToString(), out decimal tutar))
                {
                    toplam += tutar;
                }
            }

            // Toplamı lblToplamGidar label'ına yaz
            lblToplamGider.Text = toplam.ToString("C2"); // Currency formatında
        }

        // Gider kategorisi değiştiğinde yapılacak işlemler
        private void cmbGiderKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGiderKategori.SelectedItem != null)
            {
                byte giderKategoriId = ((GiderKategori)cmbGiderKategori.SelectedItem).Id;
                cmbGiderAltKategori.DataSource = giderAltKategoriManager.GetByGiderKategoriId(giderKategoriId);
                cmbGiderAltKategori.DisplayMember = "GiderAltKategoriAdi";
                cmbGiderAltKategori.ValueMember = "Id";
            }
        }

        // Gider alt kategorilerini gizler
        private void Gizle()
        {
            cmbGiderAltKategori.Visible = false;
            lblGiderAltKategori.Visible = false;
            txtTutar.Visible = false;
            lblTutar.Visible = false;
            txtAlan.Visible = false;
            lblAlan.Visible = false;
            lblTutar.Visible = false;
            txtEvrakNo.Visible = false;
            lblEvrakNo.Visible = false;
            mskTarih.Visible = false;
            lblTarih.Visible = false;
            pcBoxKaydet.Visible = false;
            pcBoxSil.Visible = false;
            pcBoxGuncelle.Visible = false;
        }

        // Gider alt kategorisi değiştiğinde yapılacak işlemler
        private void cmbGiderAltKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbGiderAltKategori.Visible = true;
            lblGiderAltKategori.Visible = true;
            txtTutar.Visible = true;
            lblTutar.Visible = true;
            txtAlan.Visible = true;
            lblAlan.Visible = true;
            lblTutar.Visible = true;
            txtEvrakNo.Visible = true;
            lblEvrakNo.Visible = true;
            mskTarih.Visible = true;
            lblTarih.Visible = true;
            pcBoxKaydet.Visible = true;
            pcBoxSil.Visible = true;
            pcBoxGuncelle.Visible = true;
        }

        //Kaydet, Sil ve Güncelle sonucunda AnaSayfadaki lblToplamGider'in anında güncellenmesi
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

        // Kaydet butonuna tıklandığında yapılacak işlemler
        private void pcBoxKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                // Gerekli alanların dolu olup olmadığını kontrol eder
                if (!string.IsNullOrEmpty(txtTutar.Text) && !string.IsNullOrEmpty(txtAlan.Text) && !string.IsNullOrEmpty(mskTarih.Text))
                {
                    // Yeni bir Gider nesnesi oluşturulur ve alanları doldurulur
                    Gider yeniGider = new Gider
                    {
                        KoyId = _seciliKoyIndex,
                        DonemId = _seciliDonemIndex,
                        GiderKategoriId = ((GiderKategori)cmbGiderKategori.SelectedItem).Id,
                        GiderAltKategoriId = ((GiderAltKategori)cmbGiderAltKategori.SelectedItem).Id,
                        Tutar = Convert.ToDecimal(txtTutar.Text),
                        Tarih = Convert.ToDateTime(mskTarih.Text),
                        Alan = txtAlan.Text,
                        EvrakNo = txtEvrakNo.Text
                    };

                    // Yeni Gider nesnesi, GiderManager aracılığıyla veritabanına eklenir
                    giderManager.Add(yeniGider);

                    // Kontroller temizlenir ve yeniden başlangıç durumuna getirilir
                    Temizle();
                    AnaSayfaGuncelle();
                    Giderler(); // Verileri yeniden yükle
                    HesaplaVeYazdir();
                }
                else
                {
                    // Gerekli alanların doldurulmadığı durumda kullanıcıya uyarı verilir
                    MessageBox.Show("Lütfen Boş Alanları Doldurunuz!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gider Kaydı Yapılamadı: " + ex.Message);
            }
        }

        // Alanları temizler
        private void Temizle()
        {
            cmbGiderKategori.SelectedIndex = 0;
            cmbGiderAltKategori.SelectedIndex = -1;
            txtTutar.Text = string.Empty;
            mskTarih.Text = string.Empty;
            txtAlan.Text = string.Empty;
            txtEvrakNo.Text = string.Empty;
            cmbGiderKategori.Focus();
        }

        // Gider alt kategorilerini yükler
        private void GiderAltKategorileriYukle(byte giderKategoriId)
        {
            try
            {
                List<GiderAltKategori> giderAltKategoriList = giderAltKategoriManager.GetByGiderKategoriId(giderKategoriId);

                cmbGiderAltKategori.DataSource = giderAltKategoriList;
                cmbGiderAltKategori.DisplayMember = "GiderAltKategoriAdi";
                cmbGiderAltKategori.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gider alt kategorileri yüklenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sil butonuna tıklandığında yapılacak işlemler
        private void pcBoxSil_Click(object sender, EventArgs e)
        {
            try
            {
                // Seçili satırı alır ve ilgili GiderId'yi elde eder
                if (dgvGiderler.SelectedRows.Count > 0)
                {
                    int giderId = Convert.ToInt32(dgvGiderler.SelectedRows[0].Cells["GiderId"].Value);

                    // Gider silinir
                    giderManager.Delete(new Gider { Id = giderId });

                    AnaSayfaGuncelle();

                    // Giderler listesi yenilenir
                    Giderler();
                    HesaplaVeYazdir();
                    Temizle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gider silinirken bir hata oluştu: " + ex.Message);
            }
        }

        private void pcBoxGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                // Gerekli alanların dolu olup olmadığını kontrol eder
                if (!string.IsNullOrEmpty(txtTutar.Text) && !string.IsNullOrEmpty(txtAlan.Text) && !string.IsNullOrEmpty(mskTarih.Text))
                {
                    // Seçili satırı alır ve ilgili Gider nesnesini oluşturur
                    if (dgvGiderler.SelectedRows.Count > 0)
                    {
                        int giderId = Convert.ToInt32(dgvGiderler.SelectedRows[0].Cells["GiderId"].Value);

                        Gider guncellenecekGider = new Gider
                        {
                            Id = giderId,
                            KoyId = _seciliKoyIndex,
                            DonemId = _seciliDonemIndex,
                            GiderKategoriId = ((GiderKategori)cmbGiderKategori.SelectedItem).Id,
                            GiderAltKategoriId = ((GiderAltKategori)cmbGiderAltKategori.SelectedItem).Id,
                            Tutar = Convert.ToDecimal(txtTutar.Text),
                            Tarih = Convert.ToDateTime(mskTarih.Text),
                            Alan = txtAlan.Text,
                            EvrakNo = txtEvrakNo.Text
                        };

                        // Güncellenecek satırın indeksini sakla
                        int selectedRowIndex = dgvGiderler.SelectedRows[0].Index;

                        // Gider güncellenir
                        giderManager.Update(guncellenecekGider);

                        AnaSayfaGuncelle();

                        // DataGridView'i yenile
                        Giderler();
                        HesaplaVeYazdir();
                        Temizle();

                        // Güncellenen satırı tekrar seç
                        if (dgvGiderler.Rows.Count > selectedRowIndex)
                        {
                            // Seçili satırı tekrar seç
                            dgvGiderler.Rows[selectedRowIndex].Selected = true;

                            // DataGridView'de bir hücreye odaklan
                            dgvGiderler.Focus();

                            // Seçili satırın görünür alan içinde kalmasını sağla
                            dgvGiderler.FirstDisplayedScrollingRowIndex = selectedRowIndex;
                        }
                    }
                }
                else
                {
                    // Gerekli alanların doldurulmadığı durumda kullanıcıya uyarı verilir
                    MessageBox.Show("Lütfen Boş Alanları Doldurunuz!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gider Güncellenirken Bir Hata Oluştu: " + ex.Message);
            }
        }

        private void dgvGiderler_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Sadece double click yapılan satırı seç
                dgvGiderler.Rows[e.RowIndex].Selected = true;

                // Seçilen satırın görünürlüğünü sağla
                dgvGiderler.FirstDisplayedScrollingRowIndex = e.RowIndex;
                dgvGiderler.Rows[e.RowIndex].Cells[0].Selected = true;

                // Seçilen satırın bilgilerini al ve ilgili alanlara aktar
                DataGridViewRow row = dgvGiderler.Rows[e.RowIndex];

                // cmbGiderKategori için
                foreach (var item in cmbGiderKategori.Items.Cast<GiderKategori>())
                {
                    if (item.Id == Convert.ToByte(row.Cells["GiderKategoriId"].Value))
                    {
                        cmbGiderKategori.SelectedItem = item;
                        break;
                    }
                }

                // cmbGiderAltKategori için
                foreach (var item in cmbGiderAltKategori.Items.Cast<GiderAltKategori>())
                {
                    if (item.Id == Convert.ToByte(row.Cells["GiderAltKategoriId"].Value))
                    {
                        cmbGiderAltKategori.SelectedItem = item;
                        break;
                    }
                }

                // Diğer alanlar ilgili hücrelerden alınıyor
                txtTutar.Text = row.Cells["Tutar"].Value.ToString();
                mskTarih.Text = Convert.ToDateTime(row.Cells["Tarih"].Value).ToString("dd/MM/yyyy");
                txtAlan.Text = row.Cells["Alan"].Value.ToString();
                txtEvrakNo.Text = row.Cells["EvrakNo"].Value.ToString();
            }
        }

        private void txtTutar_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Sadece sayılar, kontrol tuşları ve kültüre göre ondalık işaret izin verilir
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != ',' && e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Kültüre göre ondalık işaret ayarlaması
            if (e.KeyChar == ',' || e.KeyChar == '.')
            {
                // Eğer zaten bir ondalık işaret varsa veya ilk karakter ondalık işaret ise geçersiz kıl
                if ((sender as System.Windows.Forms.TextBox).Text.Contains(',') || (sender as System.Windows.Forms.TextBox).Text.Contains('.'))
                {
                    e.Handled = true;
                }

                // İlk karakter olarak ondalık işaret geldiğinde de geçersiz kıl
                if ((sender as System.Windows.Forms.TextBox).Text.Length == 0)
                {
                    e.Handled = true;
                }

                // Kültüre göre ondalık işaret olarak virgülü kabul et
                e.KeyChar = ',';
            }
        }
    }
}
