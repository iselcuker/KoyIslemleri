using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            txtBul.TextChanged += new EventHandler(txtBul_TextChanged); //ARAMA İŞLEMİ İÇİN
            dgvGelirler.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgvGelirler_DataBindingComplete);//ARAMA İŞLEMİ İÇİN

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

        public void DataGridVieweSiraNoEkle()
        {
            //// S.N kolonunu ekle, eğer zaten yoksa
            //if (!dgvGelirler.Columns.Contains("SN"))
            //{
            //    DataGridViewTextBoxColumn snColumn = new DataGridViewTextBoxColumn();
            //    snColumn.Name = "SN";
            //    snColumn.HeaderText = "S.N";
            //    snColumn.ReadOnly = true; // Sıra numarası kolonunu yalnızca okunabilir yap
            //    dgvGelirler.Columns.Insert(0, snColumn); // Kolonu en başa ekleyelim

            //    // S.N kolonunun genişliğini ayarla
            //    dgvGelirler.Columns["SN"].Width = 10; // Örneğin 50 piksel olarak ayarlayabilirsiniz
            //}

            //// Diğer DataGridView ayarları
            //dgvGelirler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dgvGelirler.RowHeadersVisible = false;
            //dgvGelirler.ColumnHeadersDefaultCellStyle.Font = new Font("Impact", 14);
            //dgvGelirler.ColumnHeadersHeight = 40;
            //dgvGelirler.EnableHeadersVisualStyles = false;
            //dgvGelirler.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;

            // S.N kolonunu ekle, eğer zaten yoksa
            if (!dgvGelirler.Columns.Contains("SN"))
            {
                DataGridViewTextBoxColumn snColumn = new DataGridViewTextBoxColumn();
                snColumn.Name = "SN";
                snColumn.HeaderText = "S.N";
                snColumn.ReadOnly = true; // Sıra numarası kolonunu yalnızca okunabilir yap
                dgvGelirler.Columns.Insert(0, snColumn); // Kolonu en başa ekleyelim

                // S.N kolonunun genişliğini ayarla
                dgvGelirler.Columns["SN"].Width = 50; // Örneğin 50 piksel olarak ayarlayabilirsiniz
            }

            // Diğer DataGridView ayarları
            dgvGelirler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvGelirler.RowHeadersVisible = false;
            dgvGelirler.ColumnHeadersDefaultCellStyle.Font = new Font("Impact", 14);
            dgvGelirler.ColumnHeadersHeight = 40;
            dgvGelirler.EnableHeadersVisualStyles = false;
            dgvGelirler.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
        }

        //SIRA NO EKLEMEK İÇİN
        private void UpdateSiraNumaralari()
        {
            for (int i = 0; i < dgvGelirler.Rows.Count; i++)
            {
                dgvGelirler.Rows[i].Cells["SN"].Value = (i + 1).ToString();
            }
        }

        private void FrmGelir_Load(object sender, EventArgs e)
        {
            try
            {

                ToplamGelir();
                GelirKategoriDoldur();
                Gizle();
                lblToplamGelir.Visible = false;


                // Sıra numarası kolonunu ekleyin ve doldurun
                DataGridVieweSiraNoEkle();
                Gelirler();
                Debug.WriteLine($"Row Count Before Updating SN: {dgvGelirler.Rows.Count}");
                UpdateSiraNumaralari();


                SetupListView();
                HesaplaVeYazdir();
                dgvGelirler.ClearSelection(); // İlk satırın seçili olmasını engelle
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
            Dictionary<byte, decimal> toplamMiktarlar = new Dictionary<byte, decimal>();

            // dgvGelirler'deki satırları kontrol et
            foreach (DataGridViewRow row in dgvGelirler.Rows)
            {
                byte gelirKategoriId;
                decimal tutar;

                // Her satırın GelirKategoriId ve Tutar değerlerini al
                if (byte.TryParse(row.Cells["GelirKategoriId"].Value?.ToString(), out gelirKategoriId) &&
                    decimal.TryParse(row.Cells["Tutar"].Value?.ToString(), out tutar))
                {
                    // Toplam miktarları sözlükte ilgili kategoriye göre topla
                    if (!toplamMiktarlar.ContainsKey(gelirKategoriId))
                    {
                        toplamMiktarlar[gelirKategoriId] = 0;
                    }

                    toplamMiktarlar[gelirKategoriId] += tutar;
                }
            }

            // ListView'i temizle
            listViewGelirler.Items.Clear();

            // Her kategori için ListViewItem oluştur ve ekle
            foreach (var kategori in toplamMiktarlar)
            {
                ListViewItem item = new ListViewItem();
                item.Text = GetGelirKategoriAdi(kategori.Key); // Kategori adını al
                item.SubItems.Add(string.Format("{0:#,0.00}", kategori.Value));
                listViewGelirler.Items.Add(item);
            }

            // Toplam miktarı hesapla
            decimal toplam = toplamMiktarlar.Values.Sum();
            ListViewItem toplamItem = new ListViewItem();
            toplamItem.Text = "TOPLAM";
            toplamItem.SubItems.Add(string.Format("{0:#,0.00}", toplam));
            listViewGelirler.Items.Add(toplamItem);
        }


        // GelirKategoriId'ye göre kategori adını dönen yardımcı bir metot
        private string GetGelirKategoriAdi(int kategoriId)
        {
            switch (kategoriId)
            {
                case 1: return "Hasılat";
                case 2: return "Resim Harcı";
                case 3: return "Para Cezası";
                case 4: return "Yardım";
                case 5: return "Köy Vakıf";
                case 6: return "İstikraz";
                case 7: return "Türlü Gelir";
                case 8: return "Devir";
                default: return "Bilinmeyen Kategori";
            }
        }

        private void SetupListView()
        {
            listViewGelirler.View = System.Windows.Forms.View.Details;
            listViewGelirler.Columns.Add("GELİR KATEGORİ", 150);
            listViewGelirler.Columns.Add("TUTAR", 100);

            // FullRowSelect özelliğini aktif et
            listViewGelirler.FullRowSelect = true;
            // Başlık stilini ayarla
            listViewGelirler.HeaderStyle = ColumnHeaderStyle.Nonclickable; // Tıklanabilir olmasını istemiyorsanız Nonclickable olarak ayarlayabilirsiniz
            listViewGelirler.BackColor = SystemColors.Control; // Arka plan rengini control rengine (varsayılan tema rengi) ayarlayabilirsiniz
        }
        private void pcBoxKaydet_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (!string.IsNullOrEmpty(txtTutar.Text) && !string.IsNullOrEmpty(txtVeren.Text) && !string.IsNullOrEmpty(cmbGelirKategori.Text) && !string.IsNullOrEmpty(mskTarih.Text))
            //    {
            //        Gelir yeniGelir = new Gelir();
            //        yeniGelir.KoyId = _seciliKoyIndex;
            //        yeniGelir.DonemId = _seciliDonemIndex;
            //        yeniGelir.GelirKategoriId = (cmbGelirKategori.SelectedItem as GelirKategori).Id; // cmbGelirKategori'den seçilen öge GelirKategori türüne dönüştürülür, yoksa null değeri alır.
            //        yeniGelir.Tutar = Convert.ToDecimal(txtTutar.Text);
            //        yeniGelir.Tarih = Convert.ToDateTime(mskTarih.Text);
            //        yeniGelir.Veren = txtVeren.Text;
            //        yeniGelir.EvrakNo = txtEvrakNo.Text;

            //        gelirManager.Add(yeniGelir);
            //        Gelirler(yeniGelir.Id);  // yeniGelir.Id'yi Gelirler metoduna geçiriyoruz
            //        Temizle();

            //        ToplamGelir();
            //        HesaplaVeYazdir();
            //        AnaSayfaGuncelle();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Lütfen Boş Alanları Doldurunuz!");
            //    }
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Gelir Kaydı Yapılamadı !!!");
            //    throw;
            //}
            try
            {
                if (!string.IsNullOrEmpty(txtTutar.Text) && !string.IsNullOrEmpty(txtVeren.Text) && !string.IsNullOrEmpty(cmbGelirKategori.Text) && !string.IsNullOrEmpty(mskTarih.Text))
                {
                    Gelir yeniGelir = new Gelir();
                    yeniGelir.KoyId = _seciliKoyIndex;
                    yeniGelir.DonemId = _seciliDonemIndex;
                    yeniGelir.GelirKategoriId = (cmbGelirKategori.SelectedItem as GelirKategori).Id; // cmbGelirKategori'den seçilen öge GelirKategori türüne dönüştürülür, yoksa null değeri alır.
                    yeniGelir.Tutar = Convert.ToDecimal(txtTutar.Text);
                    yeniGelir.Tarih = Convert.ToDateTime(mskTarih.Text);
                    yeniGelir.Veren = txtVeren.Text;
                    yeniGelir.EvrakNo = txtEvrakNo.Text;

                    gelirManager.Add(yeniGelir);
                    Gelirler(yeniGelir.Id);
                    Temizle();

                    ToplamGelir();
                    HesaplaVeYazdir();
                    AnaSayfaGuncelle();

                    // Sıra numaralarını güncelle
                    UpdateSiraNumaralari();
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
        private void Gelirler(int yeniGelirId = -1)
        {
            //try
            //{
            //    dgvGelirler.DataSource = gelirManager.GetListGelirDetailsKoyAndDonemId(_seciliKoyIndex, _seciliDonemIndex);

            //    // Sıra numarası kolonunu güncelle
            //    for (int i = 0; i < dgvGelirler.Rows.Count; i++)
            //    {
            //        dgvGelirler.Rows[i].Cells["SN"].Value = i + 1;
            //    }

            //    // Diğer kolon ayarları
            //    dgvGelirler.Columns["GelirId"].Visible = false;
            //    dgvGelirler.Columns["KoyAdi"].Visible = false;
            //    dgvGelirler.Columns["DonemAdi"].Visible = false;
            //    dgvGelirler.Columns["KoyId"].Visible = false;
            //    dgvGelirler.Columns["DonemId"].Visible = false;
            //    dgvGelirler.Columns["GelirKategoriId"].Visible = false;

            //    dgvGelirler.Columns["GelirKategoriAdi"].HeaderText = "Kategori";
            //    dgvGelirler.Columns["EvrakNo"].HeaderText = "Evrak No";

            //    // Tutar kolonundaki sayıları formatlamak için
            //    dgvGelirler.Columns["Tutar"].DefaultCellStyle.Format = "#,0.00";

            //    // Tarih kolonundaki tarihi formatlamak için
            //    dgvGelirler.Columns["Tarih"].DefaultCellStyle.Format = "dd.MM.yyyy";

            //    ToplamGelir(); // Veriler yenilendiğinde toplamı hesapla

            //    // Yeni kaydın indeksini bul ve seç
            //    if (yeniGelirId != -1)
            //    {
            //        foreach (DataGridViewRow row in dgvGelirler.Rows)
            //        {
            //            if (Convert.ToInt32(row.Cells["GelirId"].Value) == yeniGelirId)
            //            {
            //                row.Selected = true;
            //                dgvGelirler.FirstDisplayedScrollingRowIndex = row.Index;
            //                break;
            //            }
            //        }
            //    }
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
            try
            {
                var gelirListesi = gelirManager.GetListGelirDetailsKoyAndDonemId(_seciliKoyIndex, _seciliDonemIndex);

                dgvGelirler.DataSource = gelirListesi; // Gelirleri DataGridView'e bağlayın

                // Diğer kolon ayarları
                dgvGelirler.Columns["GelirId"].Visible = false;
                dgvGelirler.Columns["KoyAdi"].Visible = false;
                dgvGelirler.Columns["DonemAdi"].Visible = false;
                dgvGelirler.Columns["KoyId"].Visible = false;
                dgvGelirler.Columns["DonemId"].Visible = false;
                dgvGelirler.Columns["GelirKategoriId"].Visible = false;

                dgvGelirler.Columns["GelirKategoriAdi"].HeaderText = "Kategori";
                dgvGelirler.Columns["EvrakNo"].HeaderText = "Evrak No";

                // Tutar kolonundaki sayıları formatlamak için
                dgvGelirler.Columns["Tutar"].DefaultCellStyle.Format = "#,0.00";

                // Tarih kolonundaki tarihi formatlamak için
                dgvGelirler.Columns["Tarih"].DefaultCellStyle.Format = "dd.MM.yyyy";

                dgvGelirler.AutoGenerateColumns = false; // Bu satırı ekleyin

                // Toplam geliri hesapla
                ToplamGelir();

                // SN numaralarını güncelleyin
                UpdateSiraNumaralari(); // Burada çağırıyoruz
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gelirler yüklenirken bir hata oluştu: " + ex.Message);
                MessageBox.Show($"Hata: {ex.Message}"); // Hata mesajını göster
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
            //// Satırın indeksini al
            //int rowIndex = e.RowIndex;

            //// Seçili satırın verilerini al
            //if (rowIndex >= 0 && rowIndex < dgvGelirler.Rows.Count)
            //{
            //    DataGridViewRow selectedRow = dgvGelirler.Rows[rowIndex];

            //    // Verileri ilgili alanlara aktar
            //    cmbGelirKategori.SelectedIndex = (byte)selectedRow.Cells["GelirKategoriId"].Value;
            //    cmbGelirKategori.SelectedText = selectedRow.Cells["GelirKategoriAdi"].Value.ToString();
            //    txtTutar.Text = selectedRow.Cells["Tutar"].Value.ToString();
            //    mskTarih.Text = selectedRow.Cells["Tarih"].Value.ToString();
            //    txtVeren.Text = selectedRow.Cells["Veren"].Value.ToString();
            //    txtEvrakNo.Text = selectedRow.Cells["EvrakNo"].Value.ToString();

            //    // Seçili satırı işaretle
            //    dgvGelirler.Rows[rowIndex].Selected = true;
            //}

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

                // Tarihi doğru formatta al
                if (selectedRow.Cells["Tarih"].Value != null && DateTime.TryParse(selectedRow.Cells["Tarih"].Value.ToString(), out DateTime tarih))
                {
                    mskTarih.Text = tarih.ToString("dd.MM.yyyy");
                }
                else
                {
                    mskTarih.Text = "";
                }

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

        //ARAMA İŞLEMİ İÇİN
        private void txtBul_TextChanged(object sender, EventArgs e)
        {
            // TextBox'taki metni al
            string aramaMetni = txtBul.Text;

            // TextBox'ın mevcut metnini büyük harfe çevir
            txtBul.Text = txtBul.Text.ToUpper();

            // İmleci son karakterin sonrasına taşı
            txtBul.SelectionStart = txtBul.Text.Length;

            // Eğer metin boş değilse arama yap
            if (!string.IsNullOrEmpty(aramaMetni))
            {
                // GelirManager'den arama sonuçlarını al
                var sonucListesi = gelirManager.GetListByVeren(_seciliKoyIndex, _seciliDonemIndex, aramaMetni);

                // DataGridView'i güncelle
                dgvGelirler.DataSource = sonucListesi;
            }
            else
            {
                // Eğer metin boşsa, tüm kayıtları göster veya önceki duruma döndür
                dgvGelirler.DataSource = gelirManager.GetListGelirDetailsKoyAndDonemId(_seciliKoyIndex, _seciliDonemIndex);
            }
        }

        //ARAMA İŞLEMİ İÇİN
        private void dgvGelirler_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvGelirler.Columns["GelirId"] != null)
            {
                dgvGelirler.Columns["GelirId"].Visible = false;
            }
            if (dgvGelirler.Columns["KoyId"] != null)
            {
                dgvGelirler.Columns["KoyId"].Visible = false;
            }
            if (dgvGelirler.Columns["DonemId"] != null)
            {
                dgvGelirler.Columns["DonemId"].Visible = false;
            }
            if (dgvGelirler.Columns["GelirKategoriId"] != null)
            {
                dgvGelirler.Columns["GelirKategoriId"].Visible = false;
            }
            if (dgvGelirler.Columns["GelirKategoriAdi"] != null)
            {
                dgvGelirler.Columns["GelirKategoriAdi"].Visible = true;
            }
        }

        private void txtBul_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Eğer karakter harf ise, büyük harfe çevir
            if (char.IsLetter(e.KeyChar))
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
        }
    }
}
