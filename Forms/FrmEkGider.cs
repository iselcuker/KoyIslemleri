﻿using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms
{
    public partial class FrmEkGider : Form
    {
        private GiderKategoriManager giderKategoriManager;
        private GiderAltKategoriManager giderAltKategoriManager;
        private DegisiklikManager degisiklikManager;
        private EkButceGiderManager ekButceGiderManager;
        private KoyManager koyManager;
        private DonemManager donemManager;

        //AnaSayfada comboboxlardan yapılan seçimlerin index lerini getirmek için
        private int _seciliKoyIndex;
        private byte _seciliDonemIndex;

        public FrmEkGider(int seciliKoyIndex, byte seciliDonemIndex)
        {
            InitializeComponent();

            ekButceGiderManager = new EkButceGiderManager(new EfEkButceGiderDal());
            giderKategoriManager = new GiderKategoriManager(new EfGiderKategoriDal());
            giderAltKategoriManager = new GiderAltKategoriManager(new EfGiderAltKategoriDal());
            degisiklikManager = new DegisiklikManager(new EfDegisiklikDal());
            koyManager = new KoyManager(new EfKoyDal());
            donemManager = new DonemManager(new EfDonemDal());

            // Ana sayfada comboboxlardan yapılan seçimlerin indexlerini getirmek için
            _seciliKoyIndex = seciliKoyIndex;
            _seciliDonemIndex = seciliDonemIndex;

            //// Combobox'ları doldurma metotlarını çağır
            FillGiderKategori();
            LoadDegisiklikler();

            // Button'ların MouseEnter ve MouseLeave olaylarını bağlayın
            AttachMouseEvents(pcBoxKaydet, new Size(100, 84), new Size(85, 65));
            AttachMouseEvents(pcBoxSil, new Size(100, 84), new Size(85, 65));
            AttachMouseEvents(pcBoxGuncelle, new Size(100, 84), new Size(85, 65));
        }

        #region Butonların üzerine mouse geldiğinde ve ayrıldığında boyut değişimi
        private void AttachMouseEvents(Control control, Size enterSize, Size leaveSize)
        {
            control.MouseEnter += (sender, e) => Control_MouseEnter(sender, e, enterSize);
            control.MouseLeave += (sender, e) => Control_MouseLeave(sender, e, leaveSize);
        }

        private void Control_MouseEnter(object sender, EventArgs e, Size size)
        {
            Control control = sender as Control;
            if (control != null)
            {
                control.Size = size;
            }
        }

        private void Control_MouseLeave(object sender, EventArgs e, Size size)
        {
            Control control = sender as Control;
            if (control != null)
            {
                control.Size = size;
            }
        }
        #endregion

        // ComboBox'ları doldurma fonksiyonlarınızı gözden geçirin
        private void FillGiderKategori()
        {
            // Gider kategorilerini yükleyin ve ComboBox'a ekleyin
            var giderKategoriler = giderKategoriManager.GetAll();
            cmbGiderKategori.DataSource = giderKategoriler;
            cmbGiderKategori.DisplayMember = "GiderKategoriAdi";
            cmbGiderKategori.ValueMember = "Id";
            cmbGiderKategori.SelectedIndex = -1; // İlk yüklemede seçili bir öğe olmasın
        }

        private void FillGiderAltKategori(byte kategoriId)
        {
            // Seçilen gider kategorisine bağlı alt kategorileri yükleyin ve ComboBox'a ekleyin
            var giderAltKategoriler = giderAltKategoriManager.GetByGiderKategoriId(kategoriId);
            cmbGiderAltKategori.DataSource = giderAltKategoriler;
            cmbGiderAltKategori.DisplayMember = "GiderAltKategoriAdi";
            cmbGiderAltKategori.ValueMember = "Id";
            cmbGiderAltKategori.SelectedIndex = -1; // İlk yüklemede seçili bir öğe olmasın
        }

        private void LoadDegisiklikler()
        {
            var degisiklikler = degisiklikManager.GetAll();

            // ComboBox'ı boşaltın
            cmbDegisiklik.Items.Clear();

            // "-Değişiklik Seçiniz-" öğesini oluşturun ve ComboBox'a ekleyin
            cmbDegisiklik.Items.Add(new Degisiklik { DegisiklikAdi = "-Değişiklik Seçiniz-", Id = 0 });

            // Diğer gelir kategorilerini ekleyin
            foreach (var degisiklik in degisiklikler)
            {
                cmbDegisiklik.Items.Add(degisiklik);
            }

            // Görüntülenecek özellik ve değer özelliğini ayarlayın
            cmbDegisiklik.DisplayMember = "DegisiklikAdi";
            cmbDegisiklik.ValueMember = "Id";

            // Varsayılan olarak "-Gelir Türü Seçiniz-" öğesini seçin
            cmbDegisiklik.SelectedIndex = 0;
        }

        private void FrmEkGider_Load(object sender, EventArgs e)
        {
            //GiderKategoriDoldur();
            FillGiderKategori();
            LoadDegisiklikler();
            EkButceGiderleri();
            lblDegisiklik.Visible = false;
            cmbDegisiklik.Visible = false;
            lblTutar.Location = new Point(10, 143);
            txtTutar.Location = new Point(217, 140);
            pcBoxKaydet.Location = new Point(217, 177);
            pcBoxSil.Location = new Point(308, 177);
            pcBoxGuncelle.Location = new Point(399, 177);
        }

        private void cmbGiderKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Temizleme: cmbGiderAltKategori'nin içeriğini temizler.
                cmbGiderAltKategori.Items.Clear();

                // Seçilen kategori index'i kontrol edilir. 
                // Eğer 0'dan büyükse (yoksa "Seçiniz" gibi bir değer seçilmiştir), işlemlere devam edilir.
                if (cmbGiderKategori.SelectedIndex >= 0)
                {
                    // Seçilen gider kategorisi cmbGiderKategori'den alınır ve GiderKategori tipine dönüştürülür.
                    GiderKategori secilenGiderKategori = cmbGiderKategori.SelectedItem as GiderKategori;

                    // Seçilen kategorinin alt kategorileri GetByGiderKategoriId metodu ile alınır.
                    List<GiderAltKategori> secilenKategorinAltKategorisi = giderAltKategoriManager.GetByGiderKategoriId(secilenGiderKategori.Id);

                    // cmbGiderAltKategori'nin öğeleri olarak seçilen kategorinin alt kategorileri eklenir.
                    cmbGiderAltKategori.Items.AddRange(secilenKategorinAltKategorisi.ToArray());


                    // İlk alt kategori seçildiğinde sadece gerekli durumlarda Degisiklik görünürlüğünü ayarla
                    GiderAltKategori ilkAltKategori = secilenKategorinAltKategorisi.FirstOrDefault();
                    if (ilkAltKategori != null &&
                        (ilkAltKategori.GiderAltKategoriAdi == "Yangın Vesaiti Masrafı" ||
                         ilkAltKategori.GiderAltKategoriAdi == "Aydınlatma Masrafı" ||
                         ilkAltKategori.GiderAltKategoriAdi == "Vergi ve Sigorta Masrafı" ||
                         ilkAltKategori.GiderAltKategoriAdi == "Köy Borçları, İstikraz Taksit ve Faizleri" ||
                         ilkAltKategori.GiderAltKategoriAdi == "Mahkeme ve Keşif Masrafları" ||
                         ilkAltKategori.GiderAltKategoriAdi == "İstimlak Masrafları" ||
                         ilkAltKategori.GiderAltKategoriAdi == "Umulmadık Masraflar"))
                    {
                        lblDegisiklik.Visible = true;
                        cmbDegisiklik.Visible = true;
                        lblTutar.Location = new Point(10, 181);
                        txtTutar.Location = new Point(217, 177);
                        pcBoxKaydet.Location = new Point(217, 216);
                        pcBoxSil.Location = new Point(308, 216);
                        pcBoxGuncelle.Location = new Point(399, 216);
                    }
                    else
                    {
                        lblDegisiklik.Visible = false;
                        cmbDegisiklik.Visible = false;
                        lblTutar.Location = new Point(10, 143);
                        txtTutar.Location = new Point(217, 140);
                        pcBoxKaydet.Location = new Point(217, 177);
                        pcBoxSil.Location = new Point(308, 177);
                        pcBoxGuncelle.Location = new Point(399, 177);
                    }
                }
            }
            catch (Exception)
            {
                // Hata durumunda hatayı yukarıya bildir.
                throw;
            }
        }

        private void Temizle()
        {
            cmbGiderKategori.SelectedIndex = -1;
            cmbGiderAltKategori.SelectedIndex = -1;
            lblDegisiklik.Visible = false;
            cmbDegisiklik.Visible = false;
            lblTutar.Location = new Point(10, 143);
            txtTutar.Location = new Point(217, 140);
            pcBoxKaydet.Location = new Point(217, 177);
            pcBoxSil.Location = new Point(308, 177);
            pcBoxGuncelle.Location = new Point(399, 177);
            txtTutar.Text = string.Empty;

            cmbGiderKategori.Focus();

            // Degisiklik ComboBox'u sıfırlama
            cmbDegisiklik.SelectedIndex = -1;
        }

        private void EkButceGiderleri()
        {
            try
            {
                // Tahmini gelirleri DataGridView'e yükler
                var ekButceGiderleri = ekButceGiderManager.GetEkButceGiderDetails(_seciliKoyIndex, _seciliDonemIndex);

                // Veriyi DataGridView'e bağla
                dgvTahminiEkGiderler.DataSource = ekButceGiderleri;

                // Gereksiz kolonları gizle
                dgvTahminiEkGiderler.Columns["EkButceGiderId"].Visible = false;
                dgvTahminiEkGiderler.Columns["KoyAdi"].Visible = false;
                dgvTahminiEkGiderler.Columns["DonemAdi"].Visible = false;
                dgvTahminiEkGiderler.Columns["KoyId"].Visible = false;
                dgvTahminiEkGiderler.Columns["DonemId"].Visible = false;
                dgvTahminiEkGiderler.Columns["GiderKategoriId"].Visible = false;
                dgvTahminiEkGiderler.Columns["GiderAltKategoriId"].Visible = false;
                dgvTahminiEkGiderler.Columns["DegisiklikId"].Visible = false; // Bu satırı kaldırın

                // Tutar kolonundaki sayıları formatlamak için
                dgvTahminiEkGiderler.Columns["EkGiderTutari"].DefaultCellStyle.Format = "#,0.00";

                // DataGridView'in görüntü ayarlarını yapar
                dgvTahminiEkGiderler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Tüm alanı kaplaması için
                dgvTahminiEkGiderler.RowHeadersVisible = false; // Sol baştaki boş satırları gizler
                dgvTahminiEkGiderler.ColumnHeadersDefaultCellStyle.Font = new Font("Impact", 14); // Başlık yazı fontu ve büyüklüğü
                dgvTahminiEkGiderler.ColumnHeadersHeight = 40; // Başlık yüksekliği
                dgvTahminiEkGiderler.EnableHeadersVisualStyles = false; // Başlık yazı rengini değiştirmek için
                dgvTahminiEkGiderler.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray; // Başlık arka plan rengi
            }
            catch (Exception ex)
            {
                // Hata oluştuğunda kullanıcıya bilgi verir
                MessageBox.Show("Veri yüklenirken bir hata oluştu: " + ex.Message);
            }
        }

        private void SelectRowInDataGridView(int ekButceGiderId)
        {
            // Eklenen veya güncellenen satırı bul ve seç
            foreach (DataGridViewRow row in dgvTahminiEkGiderler.Rows)
            {
                if ((int)row.Cells["EkButceGiderId"].Value == ekButceGiderId)
                {
                    row.Selected = true;
                    dgvTahminiEkGiderler.FirstDisplayedScrollingRowIndex = row.Index;
                    break;
                }
            }
        }

        private void pcBoxKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                // Kategorinin seçili olup olmadığını kontrol et
                if (cmbGiderKategori.SelectedIndex < 0 || !(cmbGiderKategori.SelectedItem is GiderKategori))
                {
                    MessageBox.Show("Lütfen geçerli Gider Türü seçiniz!");
                    return;
                }

                if (cmbGiderAltKategori.SelectedIndex < 0 || !(cmbGiderAltKategori.SelectedItem is GiderAltKategori))
                {
                    MessageBox.Show("Lütfen geçerli Gider Alt Türü seçiniz!");
                    return;
                }

                // Gider alt kategorisinin metinsel değerini al
                string selectedGiderAltKategori = ((GiderAltKategori)cmbGiderAltKategori.SelectedItem).GiderAltKategoriAdi;

                // Eğer seçilen gelir kategorisi belirli bir değer ise
                if (selectedGiderAltKategori == "Yangın Vesaiti Masrafı" || selectedGiderAltKategori == "Aydınlatma Masrafı" || selectedGiderAltKategori == "Vergi ve Sigorta Masrafı" || selectedGiderAltKategori == "Köy Borçları, İstikraz Taksit ve Faizleri" || selectedGiderAltKategori == "Mahkeme ve Keşif Masrafları" || selectedGiderAltKategori == "İstimlak Masrafları" || selectedGiderAltKategori == "Umulmadık Masraflar")
                {
                    // Alt kategorinin seçili olup olmadığını kontrol et
                    if (cmbDegisiklik.SelectedIndex < 0 || !(cmbDegisiklik.SelectedItem is Degisiklik))
                    {
                        MessageBox.Show("Lütfen geçerli bir Değişiklik seçiniz!");
                        return;
                    }
                }

                // Tutarın boş olup olmadığını kontrol et
                if (string.IsNullOrEmpty(txtTutar.Text))
                {
                    MessageBox.Show("Lütfen Tutarı Giriniz !!!");
                    return;
                }

                // Girilen tutarı decimal tipine dönüştür
                if (!decimal.TryParse(txtTutar.Text, out decimal girilenTutar))
                {
                    MessageBox.Show("Lütfen geçerli bir tutar giriniz!");
                    return;
                }

                // Yeni tahmini idari işler oluştur
                EkButceGider yeniEkGider = new EkButceGider
                {
                    KoyId = _seciliKoyIndex,
                    DonemId = _seciliDonemIndex,
                    EkGiderTutari = girilenTutar,
                    GiderKategoriId = ((GiderKategori)cmbGiderKategori.SelectedItem).Id,
                    GiderAltKategoriId = ((GiderAltKategori)cmbGiderAltKategori.SelectedItem).Id
                };

                // Eğer seçilen gelir kategorisi belirli bir değer ise
                if (selectedGiderAltKategori == "Yangın Vesaiti Masrafı" || selectedGiderAltKategori == "Aydınlatma Masrafı" || selectedGiderAltKategori == "Vergi ve Sigorta Masrafı" || selectedGiderAltKategori == "Köy Borçları, İstikraz Taksit ve Faizleri" || selectedGiderAltKategori == "Mahkeme ve Keşif Masrafları" || selectedGiderAltKategori == "İstimlak Masrafları" || selectedGiderAltKategori == "Umulmadık Masraflar")
                {
                    // Seçilen değişiklik id'sini ekle
                    yeniEkGider.DegisiklikId = ((Degisiklik)cmbDegisiklik.SelectedItem).Id;
                }

                // TahminiButceGelir tablosuna yeni kaydı ekle
                ekButceGiderManager.Add(yeniEkGider);

                // Temizle ve idari işleri güncelle
                EkButceGiderleri();

                // Eklenen satırı seç
                SelectRowInDataGridView(yeniEkGider.Id);

                Temizle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ek Bütçe için Gider Kaydı Yapılamadı !!! " + ex.GetType().ToString() + ": " + ex.Message);
            }
        }

        private void dgvTahminiEkGiderler_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Satırın indeksini al
                int rowIndex = e.RowIndex;

                // Seçili satırın verilerini al
                if (rowIndex >= 0 && rowIndex < dgvTahminiEkGiderler.Rows.Count)
                {
                    DataGridViewRow selectedRow = dgvTahminiEkGiderler.Rows[rowIndex];

                    // Gelir kategorisini seç
                    byte giderKategoriId = (byte)selectedRow.Cells["GiderKategoriId"].Value;
                    GiderKategori selectedGiderKategori = cmbGiderKategori.Items.Cast<GiderKategori>().FirstOrDefault(k => k.Id == giderKategoriId);
                    if (selectedGiderKategori != null)
                    {
                        cmbGiderKategori.SelectedItem = selectedGiderKategori;
                    }

                    byte giderAltKategoriId = (byte)selectedRow.Cells["GiderAltKategoriId"].Value;
                    GiderAltKategori selectedGiderAltKategori = cmbGiderAltKategori.Items.Cast<GiderAltKategori>().FirstOrDefault(k => k.Id == giderAltKategoriId);
                    if (selectedGiderAltKategori != null)
                    {
                        cmbGiderAltKategori.SelectedItem = selectedGiderAltKategori;
                    }

                    // Tutarı al
                    string tutar = selectedRow.Cells["EkGiderTutari"].Value.ToString();
                    txtTutar.Text = tutar;

                    // Değişiklik sütunu varsa ve GiderAltKategoriAdi belirli bir değerse
                    string giderAltKategoriAdi = selectedRow.Cells["GiderAltKategoriAdi"].Value.ToString();

                    if (selectedRow.Cells["DegisiklikId"].Value != DBNull.Value &&
                        (giderAltKategoriAdi == "Yangın Vesaiti Masrafı" || giderAltKategoriAdi == "Aydınlatma Masrafı" || giderAltKategoriAdi == "Vergi ve Sigorta Masrafı" || giderAltKategoriAdi == "Köy Borçları, İstikraz Taksit ve Faizleri" || giderAltKategoriAdi == "Mahkeme ve Keşif Masrafları" || giderAltKategoriAdi == "İstimlak Masrafları" || giderAltKategoriAdi == "Umulmadık Masraflar"))
                    {
                        byte degisiklikId = (byte)selectedRow.Cells["DegisiklikId"].Value;
                        Degisiklik selectedDegisiklik = cmbDegisiklik.Items.Cast<Degisiklik>().FirstOrDefault(d => d.Id == degisiklikId);
                        if (selectedDegisiklik != null)
                        {
                            cmbDegisiklik.SelectedItem = selectedDegisiklik;
                            cmbDegisiklik.Enabled = true; // Değişiklik ComboBox'ı etkinleştir
                        }
                    }
                    else
                    {
                        cmbDegisiklik.SelectedIndex = -1; // Varsayılan değeri seçmek için
                    }

                    // Seçili satırı işaretle
                    dgvTahminiEkGiderler.Rows[rowIndex].Selected = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void pcBoxGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                // Seçili satırın indeksini al
                if (dgvTahminiEkGiderler.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Güncellemek için bir satır seçiniz!");
                    return;
                }

                DataGridViewRow selectedRow = dgvTahminiEkGiderler.SelectedRows[0];
                int selectedRowIndex = selectedRow.Index;

                // Kategorinin seçili olup olmadığını kontrol et
                if (cmbGiderKategori.SelectedIndex < 0 || !(cmbGiderKategori.SelectedItem is GiderKategori))
                {
                    MessageBox.Show("Lütfen geçerli Gider Türü seçiniz!");
                    return;
                }

                // Gelir kategorisinin metinsel değerini al
                string selectedGiderAltKategori = ((GiderAltKategori)cmbGiderAltKategori.SelectedItem).GiderAltKategoriAdi;

                // Eğer seçilen gelir kategorisi belirli bir değer ise
                if (selectedGiderAltKategori == "Yangın Vesaiti Masrafı" || selectedGiderAltKategori == "Aydınlatma Masrafı" || selectedGiderAltKategori == "Vergi ve Sigorta Masrafı" || selectedGiderAltKategori == "Köy Borçları, İstikraz Taksit ve Faizleri" || selectedGiderAltKategori == "Aydınlatma Masrafı" || selectedGiderAltKategori == "Mahkeme ve Keşif Masrafları" || selectedGiderAltKategori == "İstimlak Masrafları" || selectedGiderAltKategori == "Umulmadık Masraflar")
                {
                    // Alt kategorinin seçili olup olmadığını kontrol et
                    if (cmbDegisiklik.SelectedIndex < 0 || !(cmbDegisiklik.SelectedItem is Degisiklik))
                    {
                        MessageBox.Show("Lütfen geçerli bir Değişiklik seçiniz!");
                        return;
                    }
                }

                // Tutarın boş olup olmadığını kontrol et
                if (string.IsNullOrEmpty(txtTutar.Text))
                {
                    MessageBox.Show("Lütfen Tutarı Giriniz !!!");
                    return;
                }

                // Girilen tutarı decimal tipine dönüştür
                if (!decimal.TryParse(txtTutar.Text, out decimal girilenTutar))
                {
                    MessageBox.Show("Lütfen geçerli bir tutar giriniz!");
                    return;
                }

                // Güncellenecek tahmini idari işleri oluştur
                EkButceGider guncellenecekEkGider = new EkButceGider
                {
                    Id = (int)selectedRow.Cells["EkButceGiderId"].Value, // EkButceGider kaydının Id'sini kullanarak güncelleme yapılacak
                    KoyId = _seciliKoyIndex,
                    DonemId = _seciliDonemIndex,
                    EkGiderTutari = girilenTutar,
                    GiderKategoriId = ((GiderKategori)cmbGiderKategori.SelectedItem).Id,
                    GiderAltKategoriId = ((GiderAltKategori)cmbGiderAltKategori.SelectedItem).Id,
                };

                // Eğer seçilen gelir kategorisi belirli bir değer ise
                if (selectedGiderAltKategori == "Yangın Vesaiti Masrafı" || selectedGiderAltKategori == "Aydınlatma Masrafı" || selectedGiderAltKategori == "Vergi ve Sigorta Masrafı" || selectedGiderAltKategori == "Köy Borçları, İstikraz Taksit ve Faizleri" || selectedGiderAltKategori == "Aydınlatma Masrafı" || selectedGiderAltKategori == "Mahkeme ve Keşif Masrafları" || selectedGiderAltKategori == "İstimlak Masrafları" || selectedGiderAltKategori == "Umulmadık Masraflar")
                {
                    // Seçilen değişiklik id'sini ekle
                    guncellenecekEkGider.DegisiklikId = ((Degisiklik)cmbDegisiklik.SelectedItem).Id;
                }
                else
                {
                    guncellenecekEkGider.DegisiklikId = null; // Diğer kategoriler için DegisiklikId null olabilir
                }

                // TahminiButceGelir tablosunda mevcut kaydı güncelle
                ekButceGiderManager.Update(guncellenecekEkGider);

                // Temizle ve idari işleri güncelle
                EkButceGiderleri();

                // Eklenen veya güncellenen satırı seç
                SelectRowInDataGridView(guncellenecekEkGider.Id);

                Temizle();

                MessageBox.Show("Kayıt başarıyla güncellendi!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ek Bütçe için Gider Kaydı Güncellenemedi !!! " + ex.Message);
            }
        }

        private void cmbGiderAltKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Seçilen alt kategori alınır ve GiderAltKategori tipine dönüştürülür.
                if (cmbGiderAltKategori.SelectedIndex > 0)
                {
                    GiderAltKategori secilenAltKategori = cmbGiderAltKategori.SelectedItem as GiderAltKategori;

                    if (secilenAltKategori != null &&
                        (secilenAltKategori.GiderAltKategoriAdi == "Yangın Vesaiti Masrafı" ||
                         secilenAltKategori.GiderAltKategoriAdi == "Aydınlatma Masrafı" ||
                         secilenAltKategori.GiderAltKategoriAdi == "Vergi ve Sigorta Masrafı" ||
                         secilenAltKategori.GiderAltKategoriAdi == "Köy Borçları, İstikraz Taksit ve Faizleri" ||
                         secilenAltKategori.GiderAltKategoriAdi == "Mahkeme ve Keşif Masrafları" ||
                         secilenAltKategori.GiderAltKategoriAdi == "İstimlak Masrafları" ||
                         secilenAltKategori.GiderAltKategoriAdi == "Umulmadık Masraflar"))
                    {
                        lblDegisiklik.Visible = true;
                        cmbDegisiklik.Visible = true;
                        lblTutar.Location = new Point(10, 181);
                        txtTutar.Location = new Point(217, 177);
                        pcBoxKaydet.Location = new Point(217, 216);
                        pcBoxSil.Location = new Point(308, 216);
                        pcBoxGuncelle.Location = new Point(399, 216);
                    }
                    else
                    {
                        lblDegisiklik.Visible = false;
                        cmbDegisiklik.Visible = false;
                        lblTutar.Location = new Point(10, 143);
                        txtTutar.Location = new Point(217, 140);
                        pcBoxKaydet.Location = new Point(217, 177);
                        pcBoxSil.Location = new Point(308, 177);
                        pcBoxGuncelle.Location = new Point(399, 177);
                    }
                }
            }
            catch (Exception)
            {
                // Hata durumunda hatayı yukarıya bildir.
                throw;
            }
        }

        private void pcBoxSil_Click(object sender, EventArgs e)
        {
            try
            {
                // Seçili satırın indeksini al
                if (dgvTahminiEkGiderler.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Silmek için bir satır seçiniz!");
                    return;
                }

                DataGridViewRow selectedRow = dgvTahminiEkGiderler.SelectedRows[0];
                int selectedRowIndex = selectedRow.Index;

                // Seçili satırdan Id değerini al
                int ekButceGiderId = (int)selectedRow.Cells["EkButceGiderId"].Value;

                // Kullanıcıdan silme işlemi için onay iste
                var confirmResult = MessageBox.Show("Bu kaydı silmek istediğinizden emin misiniz?",
                                                     "Silme Onayı",
                                                     MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    // Veritabanından kaydı sil
                    ekButceGiderManager.Delete(new EkButceGider { Id = ekButceGiderId });

                    // Kullanıcıya başarı mesajı göster
                    MessageBox.Show("Kayıt başarıyla silindi!");

                    // DataGridView'i güncelle
                    EkButceGiderleri();
                    Temizle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ek Bütçe için Gider Kaydı Silinemedi !!! " + ex.Message);
            }
        }
    }
}
