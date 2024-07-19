using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
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
    public partial class FrmEkGelir : Form
    {
        private GelirKategoriManager gelirKategoriManager;
        private DegisiklikManager degisiklikManager;
        private EkButceGelirManager ekButceGelirManager;
        private KoyManager koyManager;
        private DonemManager donemManager;

        // Ana sayfada comboboxlardan yapılan seçimlerin indexlerini getirmek için
        private int _seciliKoyIndex;
        private byte _seciliDonemIndex;

        public FrmEkGelir(int seciliKoyIndex, byte seciliDonemIndex)
        {
            InitializeComponent();

            ekButceGelirManager = new EkButceGelirManager(new EfEkButceGelirDal());
            gelirKategoriManager = new GelirKategoriManager(new EfGelirKategoriDal());
            degisiklikManager = new DegisiklikManager(new EfDegisiklikDal());
            koyManager = new KoyManager(new EfKoyDal());
            donemManager = new DonemManager(new EfDonemDal());

            // Ana sayfada comboboxlardan yapılan seçimlerin indexlerini getirmek için
            _seciliKoyIndex = seciliKoyIndex;
            _seciliDonemIndex = seciliDonemIndex;

            // Combobox'ları doldurma metotlarını çağır
            LoadGelirKategoriler();
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

        private void LoadGelirKategoriler()
        {
            var gelirKategoriler = gelirKategoriManager.GetAll();

            // ComboBox'ı boşaltın
            cmbGelirKategori.Items.Clear();

            // "-Gelir Türü Seçiniz-" öğesini oluşturun ve ComboBox'a ekleyin
            cmbGelirKategori.Items.Add(new GelirKategori { GelirKategoriAdi = "-Gelir Türü Seçiniz-", Id = 0 });

            // Diğer gelir kategorilerini ekleyin
            foreach (var kategori in gelirKategoriler)
            {
                cmbGelirKategori.Items.Add(kategori);
            }

            // Görüntülenecek özellik ve değer özelliğini ayarlayın
            cmbGelirKategori.DisplayMember = "GelirKategoriAdi";
            cmbGelirKategori.ValueMember = "Id";

            // Varsayılan olarak "-Gelir Türü Seçiniz-" öğesini seçin
            cmbGelirKategori.SelectedIndex = 0;
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

        //Degisiklik Doldurmak için Kullanıyorum
        public class ComboBoxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public ComboBoxItem(string text, object value)
            {
                Text = text;
                Value = value;
            }

            public override string ToString()
            {
                return Text;
            }
        }

        private void FrmEkGelir_Load(object sender, EventArgs e)
        {
            try
            {
                EkButceGelirleri();
                lblDegisiklik.Visible = false;
                cmbDegisiklik.Visible = false;

                lblTutar.Location = new Point(9, 111);
                txtTutar.Location = new Point(176, 106);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Temizle()
        {
            cmbGelirKategori.SelectedIndex = 0;
            lblDegisiklik.Visible = false;
            cmbDegisiklik.Visible = false;
            lblTutar.Location = new Point(9, 111);
            txtTutar.Location = new Point(176, 106);
            txtTutar.Text = string.Empty;

            cmbGelirKategori.Focus();

            // Degisiklik ComboBox'u sıfırlama
            cmbDegisiklik.SelectedIndex = -1;
        }

        //Yeni girilen ya da güncellenen satırın görünür ve seçili olması için kullanıyorum.
        private void SelectRowInDataGridView(int ekButceGelirId)
        {
            // Eklenen veya güncellenen satırı bul ve seç
            foreach (DataGridViewRow row in dgvTahminiEkGelirler.Rows)
            {
                if ((int)row.Cells["EkButceGelirId"].Value == ekButceGelirId)
                {
                    row.Selected = true;
                    dgvTahminiEkGelirler.FirstDisplayedScrollingRowIndex = row.Index;
                    break;
                }
            }
        }


        private void pcBoxKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                // Kategorinin seçili olup olmadığını kontrol et
                if (cmbGelirKategori.SelectedIndex < 0 || !(cmbGelirKategori.SelectedItem is GelirKategori))
                {
                    MessageBox.Show("Lütfen geçerli Gelir Türü seçiniz!");
                    return;
                }

                // Gelir kategorisinin metinsel değerini al
                string selectedGelirKategori = ((GelirKategori)cmbGelirKategori.SelectedItem).GelirKategoriAdi;

                // Eğer seçilen gelir kategorisi belirli bir değer ise
                if (selectedGelirKategori == "Hasılat" || selectedGelirKategori == "Resim ve harçlar" || selectedGelirKategori == "Köy vakıf ve avarız geliri" || selectedGelirKategori == "İstikrazlar")
                {
                    // Alt kategorinin seçili olup olmadığını kontrol et
                    if (cmbDegisiklik.SelectedIndex < 0 || !(cmbDegisiklik.SelectedItem is Degisiklik))
                    {
                        MessageBox.Show("Lütfen geçerli bir Değişiklik seçiniz!");
                        return;
                    }
                }
                else
                {
                    // Eğer seçilen gelir kategorisi belirli bir değer değilse ve cmbDegisiklik seçiliyse, uyarı ver ve işlemi durdur
                    if (cmbDegisiklik.SelectedIndex >= 0)
                    {
                        MessageBox.Show("Bu Gelir Türü için cmbDegisiklik'ten seçim yapmanıza gerek yok!");
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

                // Eğer cmbDegisiklik seçiliyse ve "-Değişiklik Seçiniz-" seçiliyse, uyarı ver ve işlemi durdur
                if (cmbDegisiklik.SelectedIndex >= 0 && cmbDegisiklik.SelectedItem.ToString() == "-Değişiklik Seçiniz-")
                {
                    MessageBox.Show("Lütfen bir Değişiklik seçiniz!");
                    return;
                }

                // Yeni tahmini idari işleri oluştur
                EkButceGelir yeniEkGelir = new EkButceGelir
                {
                    KoyId = _seciliKoyIndex,
                    DonemId = _seciliDonemIndex,
                    EkGelirTutari = girilenTutar,
                    GelirKategoriId = ((GelirKategori)cmbGelirKategori.SelectedItem).Id
                };

                // Eğer seçilen gelir kategorisi belirli bir değer ise
                if (selectedGelirKategori == "Hasılat" || selectedGelirKategori == "Resim ve harçlar" || selectedGelirKategori == "Köy vakıf ve avarız geliri" || selectedGelirKategori == "İstikrazlar")
                {
                    // Seçilen değişiklik id'sini ekle
                    yeniEkGelir.DegisiklikId = ((Degisiklik)cmbDegisiklik.SelectedItem).Id;
                }

                // TahminiButceGelir tablosuna yeni kaydı ekle
                ekButceGelirManager.Add(yeniEkGelir);

                // Temizle ve idari işleri güncelle
                EkButceGelirleri();

                // Eklenen satırı seç
                SelectRowInDataGridView(yeniEkGelir.Id);

                Temizle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ek Bütçe için Gelir Kaydı Yapılamadı !!! " + ex.Message);
            }
        }

        private void cmbGelirKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Seçili Gelir Kategorisini al
            GelirKategori selectedGelirKategori = (GelirKategori)cmbGelirKategori.SelectedItem;

            // Seçili Gelir Kategorisinin istenilen değerlerden biri olup olmadığını kontrol et
            if (selectedGelirKategori.GelirKategoriAdi == "Hasılat" ||
                selectedGelirKategori.GelirKategoriAdi == "Resim ve harçlar" ||
                selectedGelirKategori.GelirKategoriAdi == "Köy vakıf ve avarız geliri" ||
                selectedGelirKategori.GelirKategoriAdi == "İstikrazlar")
            {
                // cmbDegisiklik seçilebilir hale getir
                cmbDegisiklik.Visible = true;
                lblDegisiklik.Visible = true;

                lblTutar.Location = new Point(9, 148);
                txtTutar.Location = new Point(176, 146);
                pcBoxKaydet.Location = new Point(176, 185);
                pcBoxSil.Location = new Point(267, 185);
                pcBoxGuncelle.Location = new Point(358, 185);

                LoadDegisiklikler();
            }
            else
            {
                // cmbDegisiklik seçilemez hale getir ve varsayılan değeri seç
                cmbDegisiklik.Visible = false;
                lblDegisiklik.Visible = false;

                lblTutar.Location = new Point(9, 111);
                txtTutar.Location = new Point(176, 106);
                pcBoxKaydet.Location = new Point(176,146);
                pcBoxSil.Location = new Point(267,146);
                pcBoxGuncelle.Location = new Point(358,146);

                cmbDegisiklik.SelectedItem = null; // Seçili öğeyi temizle
            }
        }

        private void EkButceGelirleri()
        {
            try
            {
                // Tahmini gelirleri DataGridView'e yükler
                var ekButceGelirleri = ekButceGelirManager.GetEkButceGelirDetails(_seciliKoyIndex, _seciliDonemIndex);

                // Veriyi DataGridView'e bağla
                dgvTahminiEkGelirler.DataSource = ekButceGelirleri;

                // Gereksiz kolonları gizle
                dgvTahminiEkGelirler.Columns["EkButceGelirId"].Visible = false;
                dgvTahminiEkGelirler.Columns["KoyAdi"].Visible = false;
                dgvTahminiEkGelirler.Columns["DonemAdi"].Visible = false;
                dgvTahminiEkGelirler.Columns["KoyId"].Visible = false;
                dgvTahminiEkGelirler.Columns["DonemId"].Visible = false;
                dgvTahminiEkGelirler.Columns["GelirKategoriId"].Visible = false;
                dgvTahminiEkGelirler.Columns["DegisiklikId"].Visible = false; // Bu satırı kaldırın

                dgvTahminiEkGelirler.Columns["GelirKategoriAdi"].HeaderText = "Gelir Kategori Türü";
                dgvTahminiEkGelirler.Columns["DegisiklikAdi"].HeaderText = "Değişiklik";
                dgvTahminiEkGelirler.Columns["EkGelirTutari"].HeaderText = "Tutar";

                // Tutar kolonundaki sayıları formatlamak için
                dgvTahminiEkGelirler.Columns["EkGelirTutari"].DefaultCellStyle.Format = "#,0.00";

                // DataGridView'in görüntü ayarlarını yapar
                dgvTahminiEkGelirler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Tüm alanı kaplaması için
                dgvTahminiEkGelirler.RowHeadersVisible = false; // Sol baştaki boş satırları gizler
                dgvTahminiEkGelirler.ColumnHeadersDefaultCellStyle.Font = new Font("Impact", 14); // Başlık yazı fontu ve büyüklüğü
                dgvTahminiEkGelirler.ColumnHeadersHeight = 40; // Başlık yüksekliği
                dgvTahminiEkGelirler.EnableHeadersVisualStyles = false; // Başlık yazı rengini değiştirmek için
                dgvTahminiEkGelirler.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray; // Başlık arka plan rengi
            }
            catch (Exception ex)
            {
                // Hata oluştuğunda kullanıcıya bilgi verir
                MessageBox.Show("Veri yüklenirken bir hata oluştu: " + ex.Message);
            }
        }

        private void dgvTahminiEkGelirler_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Satırın indeksini al
                int rowIndex = e.RowIndex;

                // Seçili satırın verilerini al
                if (rowIndex >= 0 && rowIndex < dgvTahminiEkGelirler.Rows.Count)
                {
                    DataGridViewRow selectedRow = dgvTahminiEkGelirler.Rows[rowIndex];

                    // Gelir kategorisini seç
                    byte gelirKategoriId = (byte)selectedRow.Cells["GelirKategoriId"].Value;
                    GelirKategori selectedGelirKategori = cmbGelirKategori.Items.Cast<GelirKategori>().FirstOrDefault(k => k.Id == gelirKategoriId);
                    if (selectedGelirKategori != null)
                    {
                        cmbGelirKategori.SelectedItem = selectedGelirKategori;
                    }

                    // Tutarı al
                    string tutar = selectedRow.Cells["EkGelirTutari"].Value.ToString();
                    txtTutar.Text = tutar;

                    // Değişiklik sütunu varsa ve GelirKategoriAdi belirli bir değerse
                    string gelirKategoriAdi = selectedRow.Cells["GelirKategoriAdi"].Value.ToString();
                    if (selectedRow.Cells["DegisiklikId"].Value != DBNull.Value &&
                        (gelirKategoriAdi == "Hasılat" || gelirKategoriAdi == "Resim ve harçlar" || gelirKategoriAdi == "Köy vakıf ve avarız geliri" || gelirKategoriAdi == "İstikrazlar"))
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
                    dgvTahminiEkGelirler.Rows[rowIndex].Selected = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void cmbDegisiklik_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Seçili Değişiklik öğesini al
            Degisiklik selectedDegisiklik = (Degisiklik)cmbDegisiklik.SelectedItem;
        }

        private void pcBoxGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                // Seçili satırın indeksini al
                if (dgvTahminiEkGelirler.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Güncellemek için bir satır seçiniz!");
                    return;
                }

                DataGridViewRow selectedRow = dgvTahminiEkGelirler.SelectedRows[0];
                int selectedRowIndex = selectedRow.Index;

                // Kategorinin seçili olup olmadığını kontrol et
                if (cmbGelirKategori.SelectedIndex < 0 || !(cmbGelirKategori.SelectedItem is GelirKategori))
                {
                    MessageBox.Show("Lütfen geçerli Gelir Türü seçiniz!");
                    return;
                }

                // Gelir kategorisinin metinsel değerini al
                string selectedGelirKategori = ((GelirKategori)cmbGelirKategori.SelectedItem).GelirKategoriAdi;

                // Eğer seçilen gelir kategorisi belirli bir değer ise
                if (selectedGelirKategori == "Hasılat" || selectedGelirKategori == "Resim ve harçlar" || selectedGelirKategori == "Köy vakıf ve avarız geliri" || selectedGelirKategori == "İstikrazlar")
                {
                    // Alt kategorinin seçili olup olmadığını kontrol et
                    if (cmbDegisiklik.SelectedIndex < 0 || !(cmbDegisiklik.SelectedItem is Degisiklik))
                    {
                        MessageBox.Show("Lütfen geçerli bir Değişiklik seçiniz!");
                        return;
                    }
                }
                else
                {
                    // Eğer seçilen gelir kategorisi belirli bir değer değilse ve cmbDegisiklik seçiliyse, uyarı ver ve işlemi durdur
                    if (cmbDegisiklik.SelectedIndex >= 0)
                    {
                        MessageBox.Show("Bu Gelir Türü için cmbDegisiklik'ten seçim yapmanıza gerek yok!");
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

                // Eğer cmbDegisiklik seçiliyse ve "-Değişiklik Seçiniz-" seçiliyse, uyarı ver ve işlemi durdur
                if (cmbDegisiklik.SelectedIndex >= 0 && cmbDegisiklik.SelectedItem.ToString() == "-Değişiklik Seçiniz-")
                {
                    MessageBox.Show("Lütfen bir Değişiklik seçiniz!");
                    return;
                }

                // Güncellenecek tahmini idari işleri oluştur
                EkButceGelir guncellenecekEkGelir = new EkButceGelir
                {
                    Id = (int)selectedRow.Cells["EkButceGelirId"].Value, // EkButceGelir kaydının Id'sini kullanarak güncelleme yapılacak
                    KoyId = _seciliKoyIndex,
                    DonemId = _seciliDonemIndex,
                    EkGelirTutari = girilenTutar,
                    GelirKategoriId = ((GelirKategori)cmbGelirKategori.SelectedItem).Id
                };

                // Eğer seçilen gelir kategorisi belirli bir değer ise
                if (selectedGelirKategori == "Hasılat" || selectedGelirKategori == "Resim ve harçlar" || selectedGelirKategori == "Köy vakıf ve avarız geliri" || selectedGelirKategori == "İstikrazlar")
                {
                    // Seçilen değişiklik id'sini ekle
                    guncellenecekEkGelir.DegisiklikId = ((Degisiklik)cmbDegisiklik.SelectedItem).Id;
                }
                else
                {
                    guncellenecekEkGelir.DegisiklikId = null; // Değişiklik olmadığı durumda null ata
                }

                // TahminiButceGelir tablosunda güncelleme yap
                ekButceGelirManager.Update(guncellenecekEkGelir);

                // Güncellenen satırın bilgilerini yenile
                DataGridViewRow updatedRow = dgvTahminiEkGelirler.Rows[selectedRowIndex];
                updatedRow.Cells["GelirKategori"].Value = cmbGelirKategori.Text;//________________________________________________
                updatedRow.Cells["Tutar"].Value = girilenTutar.ToString("C2");

                // Temizle
                Temizle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ek Bütçe için Gelir Güncelleme Yapılamadı !!! " + ex.Message);
            }
        }

        private void pcBoxSil_Click(object sender, EventArgs e)
        {
            try
            {
                // Seçili satırın indeksini al
                if (dgvTahminiEkGelirler.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Silmek için bir satır seçiniz!");
                    return;
                }

                DataGridViewRow selectedRow = dgvTahminiEkGelirler.SelectedRows[0];
                int selectedRowIndex = selectedRow.Index;

                // Seçili satırdan Id değerini al
                int ekButceGelirId = (int)selectedRow.Cells["EkButceGelirId"].Value;

                // Kullanıcıdan silme işlemi için onay iste
                var confirmResult = MessageBox.Show("Bu kaydı silmek istediğinizden emin misiniz?",
                                                     "Silme Onayı",
                                                     MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    // Veritabanından kaydı sil
                    ekButceGelirManager.Delete(new EkButceGelir { Id = ekButceGelirId });

                    // Kullanıcıya başarı mesajı göster
                    MessageBox.Show("Kayıt başarıyla silindi!");

                    // DataGridView'i güncelle
                    EkButceGelirleri();
                    Temizle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ek Bütçe için Gelir Kaydı Silinemedi !!! " + ex.Message);
            }
        }
    }
}
