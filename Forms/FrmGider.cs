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

            txtBul.TextChanged += new EventHandler(txtBul_TextChanged); //ARAMA İŞLEMİ İÇİN
            dgvGiderler.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgvGiderler_DataBindingComplete);//ARAMA İŞLEMİ İÇİN

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

        // GelirKategoriId'ye göre kategori adını dönen yardımcı bir metot
        private string GetGiderAltKategoriAdi(byte kategoriId)
        {
            switch (kategoriId)
            {
                case 1: return "Aylık ve Yıllıklar";
                case 2: return "İdari Masraflar";
                case 3: return "Sulama Harkları Açma ve Onarım Masrafı";
                case 4: return "Ağaçlama, Aşılama ve Fidan Yetiştirme";
                case 5: return "Damızlık";
                case 6: return "Örnek Tarla, Bahçe vb. Masrafları";
                case 7: return "Zararlı Hayvanlar ve Nebat Hastalıkları İle Mücadele Masrafı";
                case 8: return "Pazar, Çarşı vb. Yerler Masrafı";
                case 9: return "Küçük Endüstri ve Ziraat Makinaları Masrafı";
                case 10: return "Okul ve Öğretmenevi İnşa ve Tamir Masrafı";
                case 11: return "Okul Daimi Masrafları";
                case 12: return "Okuma Odası Masrafları";
                case 13: return "Kurs Masrafları";
                case 14: return "Okul Uygulama Bahçesi Masrafları";
                case 15: return "İçme Suları Masrafı";
                case 16: return "Temizlik ve Sağlık Tesisleri Masrafı";
                case 17: return "Spor İşleri Masrafı";
                case 18: return "İçtimai Yardım Masrafı";
                case 19: return "Yol, Köprü, Maydan İnşa ve Tamir Masrafı";
                case 20: return "Köye Ait Akar ve Emlak İnşa ve Tamir Masrafı";
                case 21: return "Yangın Vesaiti Masrafı";
                case 22: return "Aydınlatma Masrafı";
                case 23: return "Mezarlık Masrafı";
                case 24: return "Türlü Masraflar";
                case 25: return "Vergi ve Sigorta Masrafı";
                case 26: return "Köy Borçları, İstikraz Taksit ve Faizleri";
                case 27: return "Mahkeme ve Keşif Masrafları";
                case 28: return "İstimlak Masrafları";
                case 29: return "Umulmadık Masraflar";

                default: return "Bilinmeyen Kategori";
            }
        }
        private void HesaplaVeYazdir()
        {
            // Toplam miktarları saklamak için bir sözlük oluştur
            Dictionary<byte, decimal> toplamMiktarlar = new Dictionary<byte, decimal>();

            // dgvGelirler'deki satırları kontrol et
            foreach (DataGridViewRow row in dgvGiderler.Rows)
            {
                byte giderAltKategoriId;
                decimal tutar;

                // Her satırın GelirKategoriId ve Tutar değerlerini al
                if (byte.TryParse(row.Cells["GiderAltKategoriId"].Value?.ToString(), out giderAltKategoriId) &&
                    decimal.TryParse(row.Cells["Tutar"].Value?.ToString(), out tutar))
                {
                    // Toplam miktarları sözlükte ilgili kategoriye göre topla
                    if (!toplamMiktarlar.ContainsKey(giderAltKategoriId))
                    {
                        toplamMiktarlar[giderAltKategoriId] = 0;
                    }

                    toplamMiktarlar[giderAltKategoriId] += tutar;
                }
            }

            // ListView'i temizle
            listViewGiderler.Items.Clear();

            // Her kategori için ListViewItem oluştur ve ekle
            foreach (var giderAltKategori in toplamMiktarlar)
            {
                ListViewItem item = new ListViewItem();
                item.Text = GetGiderAltKategoriAdi(giderAltKategori.Key); // Kategori adını al
                item.SubItems.Add(string.Format("{0:#,0.00}", giderAltKategori.Value));
                listViewGiderler.Items.Add(item);
            }

            // Toplam miktarı hesapla
            decimal toplam = toplamMiktarlar.Values.Sum();
            ListViewItem toplamItem = new ListViewItem();
            toplamItem.Text = "TOPLAM";
            toplamItem.SubItems.Add(string.Format("{0:#,0.00}", toplam));
            listViewGiderler.Items.Add(toplamItem);
        }


        //Giderleri DatagridView'e yükleyecek metot
        private void Giderler(int yeniGiderId = -1)
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

                // Tutar kolonundaki sayıları formatlamak için
                dgvGiderler.Columns["Tutar"].DefaultCellStyle.Format = "#,0.00";

                // Tarih kolonundaki tarihi formatlamak için
                dgvGiderler.Columns["Tarih"].DefaultCellStyle.Format = "dd.MM.yyyy";

                ToplamGider(); // Veriler yenilendiğinde toplamı hesapla

                // Yeni kaydın indeksini bul ve seç
                if (yeniGiderId != -1)
                {
                    foreach (DataGridViewRow row in dgvGiderler.Rows)
                    {
                        if (Convert.ToInt32(row.Cells["GiderId"].Value) == yeniGiderId)
                        {
                            row.Selected = true;
                            dgvGiderler.FirstDisplayedScrollingRowIndex = row.Index;
                            break;
                        }
                    }
                }
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

        private void SetupListView()
        {
            // ListView'in görünümünü Details olarak ayarla
            listViewGiderler.View = System.Windows.Forms.View.Details;

            // Sütunları ekle
            listViewGiderler.Columns.Add("GİDER ALT KATEGORİ", 250);
            listViewGiderler.Columns.Add("TUTAR", 100);

            // FullRowSelect özelliğini aktif et
            listViewGiderler.FullRowSelect = true;
            //// Başlık stilini ayarla
            //listViewGiderler.Font = new Font("Arial", 10, FontStyle.Bold); // Başlık fontunu ve kalın stilini ayarlayabilirsiniz
            listViewGiderler.HeaderStyle = ColumnHeaderStyle.Nonclickable; // Tıklanabilir olmasını istemiyorsanız Nonclickable olarak ayarlayabilirsiniz
            listViewGiderler.BackColor = SystemColors.Control; // Arka plan rengini control rengine (varsayılan tema rengi) ayarlayabilirsiniz
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
                SetupListView();
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
                    Giderler(yeniGider.Id); // Verileri yeniden yükle ve yeni girilen kaydın id'sini geçir
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
            //if (e.RowIndex >= 0)
            //{
            //    // Sadece double click yapılan satırı seç
            //    dgvGiderler.Rows[e.RowIndex].Selected = true;

            //    // Seçilen satırın görünürlüğünü sağla
            //    dgvGiderler.FirstDisplayedScrollingRowIndex = e.RowIndex;
            //    dgvGiderler.Rows[e.RowIndex].Cells[0].Selected = true;

            //    // Seçilen satırın bilgilerini al ve ilgili alanlara aktar
            //    DataGridViewRow row = dgvGiderler.Rows[e.RowIndex];

            //    // cmbGiderKategori için
            //    foreach (var item in cmbGiderKategori.Items.Cast<GiderKategori>())
            //    {
            //        if (item.Id == Convert.ToByte(row.Cells["GiderKategoriId"].Value))
            //        {
            //            cmbGiderKategori.SelectedItem = item;
            //            break;
            //        }
            //    }

            //    // cmbGiderAltKategori için
            //    foreach (var item in cmbGiderAltKategori.Items.Cast<GiderAltKategori>())
            //    {
            //        if (item.Id == Convert.ToByte(row.Cells["GiderAltKategoriId"].Value))
            //        {
            //            cmbGiderAltKategori.SelectedItem = item;
            //            break;
            //        }
            //    }

            //    // Diğer alanlar ilgili hücrelerden alınıyor
            //    txtTutar.Text = row.Cells["Tutar"].Value.ToString();
            //    mskTarih.Text = Convert.ToDateTime(row.Cells["Tarih"].Value).ToString("dd/MM/yyyy");
            //    txtAlan.Text = row.Cells["Alan"].Value.ToString();
            //    txtEvrakNo.Text = row.Cells["EvrakNo"].Value.ToString();
            //}
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

                // Tarihi doğru formatta al
                if (row.Cells["Tarih"].Value != null && DateTime.TryParse(row.Cells["Tarih"].Value.ToString(), out DateTime tarih))
                {
                    mskTarih.Text = tarih.ToString("dd/MM/yyyy");
                }
                else
                {
                    mskTarih.Text = "";
                }

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

        private void txtAlan_TextChanged(object sender, EventArgs e)
        {
            txtAlan.Text = txtAlan.Text.ToUpper();
            txtAlan.SelectionStart = txtAlan.Text.Length; // Metnin sonuna atlamak için
        }

        private void txtBul_TextChanged(object sender, EventArgs e)
        {
            // TextBox'taki metni al
            string aramaMetni = txtBul.Text;

            // TextBox'ın mevcut metnini büyük harfe çevir
            txtBul.Text = txtBul.Text.ToUpper();

            // İmleci son karakterin sonrasına taşı
            txtBul.SelectionStart = txtBul.Text.Length; // Metnin sonuna atlamak için

            // Eğer metin boş değilse arama yap
            if (!string.IsNullOrEmpty(aramaMetni))
            {
                // GelirManager'den arama sonuçlarını al
                var sonucListesi = giderManager.GetListByAlan(_seciliKoyIndex, _seciliDonemIndex, aramaMetni);

                // DataGridView'i güncelle
                dgvGiderler.DataSource = sonucListesi;
            }
            else
            {
                // Eğer metin boşsa, tüm kayıtları göster veya önceki duruma döndür
                dgvGiderler.DataSource = giderManager.GetListGiderDetailsKoyAndDonemId(_seciliKoyIndex, _seciliDonemIndex);
            }
        }

        private void dgvGiderler_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvGiderler.Columns["GiderId"] != null)
            {
                dgvGiderler.Columns["GiderId"].Visible = false;
            }
            if (dgvGiderler.Columns["KoyId"] != null)
            {
                dgvGiderler.Columns["KoyId"].Visible = false;
            }
            if (dgvGiderler.Columns["DonemId"] != null)
            {
                dgvGiderler.Columns["DonemId"].Visible = false;
            }
            if (dgvGiderler.Columns["GiderKategoriId"] != null)
            {
                dgvGiderler.Columns["GiderKategoriId"].Visible = false;
            }
            if (dgvGiderler.Columns["GiderAltKategoriId"] != null)
            {
                dgvGiderler.Columns["GiderAltKategoriId"].Visible = false;
            }
        }
    }
}
