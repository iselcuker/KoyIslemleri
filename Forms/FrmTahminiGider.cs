using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Forms.FrmTahminiGelir;

namespace Forms
{
    public partial class FrmTahminiGider : Form
    {
        private GiderKategoriManager giderKategoriManager;
        private GiderAltKategoriManager giderAltKategoriManager;
        private DegisiklikManager degisiklikManager;
        private TahminiButceGiderManager tahminiButceGiderManager;
        private KoyManager koyManager;
        private DonemManager donemManager;

        //AnaSayfada comboboxlardan yapılan seçimlerin index lerini getirmek için
        private int _seciliKoyIndex;
        private byte _seciliDonemIndex;

        public FrmTahminiGider(int seciliKoyIndex, byte seciliDonemIndex)
        {
            InitializeComponent();

            tahminiButceGiderManager = new TahminiButceGiderManager(new EfTahminiButceGiderDal());
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
        }

        private void OgeYerlestir()
        {
            lblDegisiklik.Visible = false;
            cmbDegisiklik.Visible = false;
            lblTutar.Location = new Point(10, 139);
            txtTutar.Location = new Point(217, 134);

            pcBoxKaydet.Location = new Point(217, 171);
            pcBoxSil.Location = new Point(308, 171);
            pcBoxGuncelle.Location = new Point(399, 171);
        }

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

        private void FrmTahminiGider_Load(object sender, EventArgs e)
        {
            FillGiderKategori();
            LoadDegisiklikler();
            TahminiButceGiderleri();
            OgeYerlestir();
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
                    }
                    else
                    {
                        OgeYerlestir();
                    }
                }
            }
            catch (Exception)
            {
                // Hata durumunda hatayı yukarıya bildir.
                throw;
            }
        }

        //BURADA KALDIM
        private void TahminiButceGiderleri()
        {
            try
            {
                // Tahmini gelirleri DataGridView'e yükler
                var tahminiButceGiderleri = tahminiButceGiderManager.GetTahminiButceGiderDetails(_seciliKoyIndex, _seciliDonemIndex);

                // Veriyi DataGridView'e bağla
                dgvTahminiGiderler.DataSource = tahminiButceGiderleri;

                // Gereksiz kolonları gizle
                dgvTahminiGiderler.Columns["TahminiButceGiderId"].Visible = false;
                dgvTahminiGiderler.Columns["KoyAdi"].Visible = false;
                dgvTahminiGiderler.Columns["DonemAdi"].Visible = false;
                dgvTahminiGiderler.Columns["KoyId"].Visible = false;
                dgvTahminiGiderler.Columns["DonemId"].Visible = false;
                dgvTahminiGiderler.Columns["GiderKategoriId"].Visible = false;
                dgvTahminiGiderler.Columns["GiderAltKategoriId"].Visible = false;
                dgvTahminiGiderler.Columns["DegisiklikId"].Visible = false; // Bu satırı kaldırın

                // Tutar kolonundaki sayıları formatlamak için
                dgvTahminiGiderler.Columns["Tutar"].DefaultCellStyle.Format = "#,0.00";

                // DataGridView'in görüntü ayarlarını yapar
                dgvTahminiGiderler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Tüm alanı kaplaması için
                dgvTahminiGiderler.RowHeadersVisible = false; // Sol baştaki boş satırları gizler
                dgvTahminiGiderler.ColumnHeadersDefaultCellStyle.Font = new Font("Impact", 14); // Başlık yazı fontu ve büyüklüğü
                dgvTahminiGiderler.ColumnHeadersHeight = 40; // Başlık yüksekliği
                dgvTahminiGiderler.EnableHeadersVisualStyles = false; // Başlık yazı rengini değiştirmek için
                dgvTahminiGiderler.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray; // Başlık arka plan rengi
                dgvTahminiGiderler.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;

                dgvTahminiGiderler.Columns["GiderKategoriAdi"].HeaderText = "KATEGORİ";
                dgvTahminiGiderler.Columns["GiderAltKategoriAdi"].HeaderText = "ALT KATEGORİ";
                dgvTahminiGiderler.Columns["DegisiklikAdi"].HeaderText = "DEĞİŞİKLİK";
            }
            catch (Exception ex)
            {
                // Hata oluştuğunda kullanıcıya bilgi verir
                MessageBox.Show("Veri yüklenirken bir hata oluştu: " + ex.Message);
            }
        }

        private void SelectRowInDataGridView(int tahminiButceGiderId)
        {
            // Eklenen veya güncellenen satırı bul ve seç
            foreach (DataGridViewRow row in dgvTahminiGiderler.Rows)
            {
                if ((int)row.Cells["TahminiButceGiderId"].Value == tahminiButceGiderId)
                {
                    row.Selected = true;
                    dgvTahminiGiderler.FirstDisplayedScrollingRowIndex = row.Index;
                    break;
                }
            }
        }

        public decimal GetTahminiButceTutari(int koyId, byte donemId)
        {
            using (var context = new KoyButcesiContext())
            {
                var tahminiButce = context.TahminiButces
                                        .FirstOrDefault(tb => tb.KoyId == koyId && tb.DonemId == donemId);

                if (tahminiButce != null)
                {
                    return tahminiButce.TahminiButceTutari;
                }
                else
                {
                    // İlgili kayıt bulunamadı, burada bir hata işlemi yapılabilir
                    // Örneğin, bir hata mesajı döndürülebilir veya bir varsayılan değer atanabilir.
                    return 0; // Veya başka bir varsayılan değer
                }
            }
        }

        //cmbGiderAlKategori seçimini görmediği için eklenen kodlar
        private void FillGiderKategoriComboBox()
        {
            // GiderKategori verilerini çekme ve ComboBox'a ekleme
            var giderKategorileri = giderKategoriManager.GetAll(); // Veritabanından veya başka bir kaynaktan veri çekme
            cmbGiderKategori.Items.AddRange(giderKategorileri.ToArray());
        }

        private void FillGiderAltKategoriComboBox(byte giderKategoriId)
        {
            // Seçilen GiderKategori'ye bağlı Alt Kategori verilerini çekme ve ComboBox'a ekleme
            var giderAltKategorileri = giderAltKategoriManager.GetByGiderKategoriId(giderKategoriId); // Veritabanından veya başka bir kaynaktan veri çekme
            cmbGiderAltKategori.Items.AddRange(giderAltKategorileri.ToArray());
        }

        private decimal GetToplamTahminiGider(int koyId, byte donemId)
        {
            using (KoyButcesiContext context = new KoyButcesiContext())
            {
                var toplamTahminiGider = context.TahminiButceGiders
                    .Where(tb => tb.KoyId == koyId && tb.DonemId == donemId)
                    .Sum(tb => (decimal?)tb.Tutar) ?? 0;

                return toplamTahminiGider;
            }
        }

        private decimal KalanTutar(decimal tahminiButceTutari, decimal girilenTutar)
        {
            // Toplam tahmini geliri al
            decimal toplamTahminiGider = GetToplamTahminiGider(_seciliKoyIndex, _seciliDonemIndex);

            // Kalan tutarı hesapla
            decimal kalanTutar = tahminiButceTutari - toplamTahminiGider - girilenTutar;

            return kalanTutar;
        }

        private void pcBoxKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                // TahminiButceTutari'nı al
                decimal tahminiButceTutari = GetTahminiButceTutari(_seciliKoyIndex, _seciliDonemIndex);

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
                if (selectedGiderAltKategori == "Yangın Vesaiti Masrafı" || selectedGiderAltKategori == "Aydınlatma Masrafı" || selectedGiderAltKategori == "Vergi ve Sigorta Masrafı" || selectedGiderAltKategori == "Mahkeme ve Keşif Masrafları" || selectedGiderAltKategori == "İstimlak Masrafları" || selectedGiderAltKategori == "Umulmadık Masraflar")
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

                // Yeni tahmini Gider oluştur
                TahminiButceGider yeniTahminiGider = new TahminiButceGider
                {
                    KoyId = _seciliKoyIndex,
                    DonemId = _seciliDonemIndex,
                    Tutar = girilenTutar,
                    GiderKategoriId = ((GiderKategori)cmbGiderKategori.SelectedItem).Id,
                    GiderAltKategoriId = ((GiderAltKategori)cmbGiderAltKategori.SelectedItem).Id,
                };

                // Eğer seçilen gelir kategorisi belirli bir değer ise
                if (selectedGiderAltKategori == "Yangın Vesaiti Masrafı" || selectedGiderAltKategori == "Aydınlatma Masrafı" || selectedGiderAltKategori == "Vergi ve Sigorta Masrafı" || selectedGiderAltKategori == "Köy Borçları, İstikraz Taksit ve Faizleri" || selectedGiderAltKategori == "Mahkeme ve Keşif Masrafları" || selectedGiderAltKategori == "İstimlak Masrafları" || selectedGiderAltKategori == "Umulmadık Masraflar")
                {
                    // Seçilen değişiklik id'sini ekle
                    yeniTahminiGider.DegisiklikId = ((Degisiklik)cmbDegisiklik.SelectedItem).Id;
                }


                // Kalan tutarı hesapla
                decimal kalanTutar = KalanTutar(tahminiButceTutari, girilenTutar);

                // Kalan tutarı mesaj olarak göster
                MessageBox.Show(girilenTutar + " girişi yapıldı. Tahmini bütçeden kalan tutar: " + kalanTutar);
                lblYeniTutar.Text = kalanTutar.ToString();

                // Eğer kalan tutar 0 veya daha küçükse, yeni kayıt girmeyi engelle
                if (kalanTutar <= 0 )
                {
                    pcBoxKaydet.Visible = false;
                    lblGiderKategori.Visible = false;
                    cmbGiderKategori.Visible = false;
                    lblGiderAltKategori.Visible = false;
                    cmbGiderAltKategori.Visible = false;
                    lblDegisiklik.Visible = false;
                    cmbDegisiklik.Visible = false;
                    lblTutar.Visible = false;
                    txtTutar.Visible = false;
                    lblYeniTutar.Visible = false;
                    lblYeniTutarYazisi.Visible = false;
                }

                // TahminiButceGelir tablosuna yeni kaydı ekle
                tahminiButceGiderManager.Add(yeniTahminiGider);
                OgeYerlestir();

                // Temizle ve idari işleri güncelle
                TahminiButceGiderleri();

                // Eklenen satırı seç
                SelectRowInDataGridView(yeniTahminiGider.Id);

                Temizle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ek Bütçe için Gider Kaydı Yapılamadı !!! " + ex.GetType().ToString() + ": " + ex.Message);
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

                        lblTutar.Location = new Point(10, 174);
                        txtTutar.Location = new Point(217, 172);
                        pcBoxKaydet.Location = new Point(217, 211);
                        pcBoxSil.Location = new Point(308, 211);
                        pcBoxGuncelle.Location = new Point(399, 211);
                    }
                    else
                    {
                        lblDegisiklik.Visible = false;
                        cmbDegisiklik.Visible = false;
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
            txtTutar.Text = string.Empty;
            cmbGiderKategori.Focus();
            // Degisiklik ComboBox'u sıfırlama
            cmbDegisiklik.SelectedIndex = -1;
        }

        private void dgvTahminiGiderler_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Satırın indeksini al
                int rowIndex = e.RowIndex;

                // Seçili satırın verilerini al
                if (rowIndex >= 0 && rowIndex < dgvTahminiGiderler.Rows.Count)
                {
                    DataGridViewRow selectedRow = dgvTahminiGiderler.Rows[rowIndex];

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
                    string tutar = selectedRow.Cells["Tutar"].Value.ToString();
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
                    dgvTahminiGiderler.Rows[rowIndex].Selected = true;
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
                if (dgvTahminiGiderler.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Güncellemek için bir satır seçiniz!");
                    return;
                }

                DataGridViewRow selectedRow = dgvTahminiGiderler.SelectedRows[0];
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
                TahminiButceGider guncellenecekTahminiGider = new TahminiButceGider
                {
                    Id = (int)selectedRow.Cells["TahminiButceGiderId"].Value, // EkButceGider kaydının Id'sini kullanarak güncelleme yapılacak
                    KoyId = _seciliKoyIndex,
                    DonemId = _seciliDonemIndex,
                    Tutar = girilenTutar,
                    GiderKategoriId = ((GiderKategori)cmbGiderKategori.SelectedItem).Id,
                    GiderAltKategoriId = ((GiderAltKategori)cmbGiderAltKategori.SelectedItem).Id,
                };

                // Eğer seçilen gelir kategorisi belirli bir değer ise
                if (selectedGiderAltKategori == "Yangın Vesaiti Masrafı" || selectedGiderAltKategori == "Aydınlatma Masrafı" || selectedGiderAltKategori == "Vergi ve Sigorta Masrafı" || selectedGiderAltKategori == "Köy Borçları, İstikraz Taksit ve Faizleri" || selectedGiderAltKategori == "Aydınlatma Masrafı" || selectedGiderAltKategori == "Mahkeme ve Keşif Masrafları" || selectedGiderAltKategori == "İstimlak Masrafları" || selectedGiderAltKategori == "Umulmadık Masraflar")
                {
                    // Seçilen değişiklik id'sini ekle
                    guncellenecekTahminiGider.DegisiklikId = ((Degisiklik)cmbDegisiklik.SelectedItem).Id;
                }
                else
                {
                    guncellenecekTahminiGider.DegisiklikId = null; // Diğer kategoriler için DegisiklikId null olabilir
                }

                // TahminiButceGelir tablosunda mevcut kaydı güncelle
                tahminiButceGiderManager.Update(guncellenecekTahminiGider);
                lblDegisiklik.Visible = false;
                cmbDegisiklik.Visible = false;
                lblTutar.Location = new Point(10, 139);
                txtTutar.Location = new Point(217, 134);

                pcBoxKaydet.Location = new Point(217, 171);
                pcBoxSil.Location = new Point(308, 171);
                pcBoxGuncelle.Location = new Point(399, 171);

                // Temizle ve idari işleri güncelle
                TahminiButceGiderleri();

                // Eklenen veya güncellenen satırı seç
                SelectRowInDataGridView(guncellenecekTahminiGider.Id);

                Temizle();

                MessageBox.Show("Kayıt başarıyla güncellendi!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tahmini Bütçe için Gider Kaydı Güncellenemedi !!! " + ex.Message);
            }
        }

        private void pcBoxSil_Click(object sender, EventArgs e)
        {
            try
            {
                // Seçili satırın indeksini al
                if (dgvTahminiGiderler.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Silmek için bir satır seçiniz!");
                    return;
                }

                DataGridViewRow selectedRow = dgvTahminiGiderler.SelectedRows[0];
                int selectedRowIndex = selectedRow.Index;

                // Seçili satırdan Id değerini al
                int tahminiButceGiderId = (int)selectedRow.Cells["TahminiButceGiderId"].Value;

                // Kullanıcıdan silme işlemi için onay iste
                var confirmResult = MessageBox.Show("Bu kaydı silmek istediğinizden emin misiniz?",
                                                     "Silme Onayı",
                                                     MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    // Veritabanından kaydı sil
                    tahminiButceGiderManager.Delete(new TahminiButceGider { Id = tahminiButceGiderId });
                    OgeYerlestir();

                    // Kullanıcıya başarı mesajı göster
                    MessageBox.Show("Kayıt başarıyla silindi!");

                    // DataGridView'i güncelle
                    TahminiButceGiderleri();
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
