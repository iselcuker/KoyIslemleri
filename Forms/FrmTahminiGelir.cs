using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms
{
    public partial class FrmTahminiGelir : Form
    {
        GelirKategoriManager gelirKategoriManager;
        DegisiklikManager degisiklikManager;
        //TahminiButceGelirManager tahminiButceGelirManager;
        private TahminiButceGelirManager tahminiButceGelirManager;
        KoyManager koyManager;
        DonemManager donemManager;
        //AnaSayfada comboboxlardan yapılan seçimlerin index lerini getirmek için
        int _seciliKoyIndex;
        byte _seciliDonemIndex;

        public event EventHandler TahminiButceTutariDegisti;

        //KAYDET BUTONU KONTROLÜ İÇİN
        private FrmTahminiButce frmTahminiButce;
        private FrmAnaSayfa frmAnaSayfa;
        private FrmTahminiButce _frmTahminiButce;
        private FrmAnaSayfa _frmAnaSayfa;

        public FrmTahminiGelir(int seciliKoyIndex, byte seciliDonemIndex)
        {
            InitializeComponent();


            TahminiButceGelirManager _tahminiButceGelirManager = new TahminiButceGelirManager(new EfTahminiButceGelirDal());
            tahminiButceGelirManager = _tahminiButceGelirManager;

            GelirKategoriManager _gelirKategoriManager = new GelirKategoriManager(new EfGelirKategoriDal());
            gelirKategoriManager = _gelirKategoriManager;

            DegisiklikManager _degisiklikManager = new DegisiklikManager(new EfDegisiklikDal());
            degisiklikManager = _degisiklikManager;

            _seciliKoyIndex = seciliKoyIndex;
            _seciliDonemIndex = seciliDonemIndex;

            KoyManager _koyManager = new KoyManager(new EfKoyDal());
            koyManager = _koyManager;

            DonemManager _donemManager = new DonemManager(new EfDonemDal());
            donemManager = _donemManager;

            //AŞAĞIDAKİLER KAYDET BUTONU KONTROLÜ İÇİN
            tahminiButceGelirManager = new TahminiButceGelirManager(new EfTahminiButceGelirDal());
            gelirKategoriManager = new GelirKategoriManager(new EfGelirKategoriDal());
            degisiklikManager = new DegisiklikManager(new EfDegisiklikDal());

            _seciliKoyIndex = seciliKoyIndex;
            _seciliDonemIndex = seciliDonemIndex;

            koyManager = new KoyManager(new EfKoyDal());
            donemManager = new DonemManager(new EfDonemDal());

            _frmTahminiButce = frmTahminiButce;
            _frmAnaSayfa = frmAnaSayfa;

            //TEXBOX'A BELİRLİ BİR FORMATTA VE SADECE RAKAM GİRİLMESİNİ SAĞLAMAK İÇİN
            txtTutar.KeyPress += new KeyPressEventHandler(txtTutar_KeyPress);
            txtTutar.Leave += new EventHandler(txtTutar_Leave);

        }

        private void GelirKategoriDoldur()
        {
            try
            {
                List<GelirKategori> gelirKategoriler = gelirKategoriManager.GetAll();
                cmbGelirKategori.Items.Clear();
                cmbGelirKategori.Items.Add("-Gelir Türü Seçiniz-");
                foreach (var kategori in gelirKategoriler)
                {
                    cmbGelirKategori.Items.Add(kategori);
                }
                cmbGelirKategori.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Gelir Türü Getirilirken Hata Oluştu!");
                throw;
            }
        }

        private void DegisiklikDoldur()
        {
            try
            {
                List<Degisiklik> degisiklikler = degisiklikManager.GetAll();
                cmbDegisiklik.Items.Clear();
                cmbDegisiklik.Items.Add(new ComboBoxItem("-Değişiklik Gerekiyorsa Seçiniz-", null));
                foreach (var degisiklik in degisiklikler)
                {
                    cmbDegisiklik.Items.Add(new ComboBoxItem(degisiklik.DegisiklikAdi, degisiklik));
                }
                cmbDegisiklik.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Değişiklikler Getirilirken Hata Oluştu!");
                throw;
            }
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

        private void FrmTahminiGelir_Load(object sender, EventArgs e)
        {
            cmbDegisiklik.Visible = false;
            lblDegisiklik.Visible = false;

            GelirKategoriDoldur();
            TahminiGelirler();

            lblTutar.Location = new Point(22, 97);//
            txtTutar.Location = new Point(180, 94);//
        }

        private void cmbGelirKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGelirKategori.Text == "Hasılat" || cmbGelirKategori.Text == "Resim ve harçlar" || cmbGelirKategori.Text == "Köy vakıf ve avarız geliri" || cmbGelirKategori.Text == "İstikrazlar" || cmbGelirKategori.Text == "Para Cezaları")
            {
                cmbDegisiklik.Visible = true;
                lblDegisiklik.Visible = true;

                ////Degisiklik görünür olduğunda Tutar'ın lokasyonu
                lblTutar.Location = new Point(22, 130);
                txtTutar.Location = new Point(180, 128);

                DegisiklikDoldur();
            }
            else
            {
                cmbDegisiklik.Visible = false;
                lblDegisiklik.Visible = false;
                //Degisiklik görünmez olduğunda Tutar'ın lokasyonu
                lblTutar.Location = new Point(22, 97);//
                txtTutar.Location = new Point(180, 94);//

                cmbDegisiklik.SelectedIndex = -1;
            }
        }

        private decimal KalanTutar(decimal tahminiButceTutari, decimal girilenTutar)
        {
            // Toplam tahmini geliri al
            decimal toplamTahminiGelir = GetToplamTahminiGelir(_seciliKoyIndex, _seciliDonemIndex);

            // Kalan tutarı hesapla
            decimal kalanTutar = tahminiButceTutari - toplamTahminiGelir - girilenTutar;

            return kalanTutar;
        }


        private void pcBoxKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                // TahminiButceTutari'nı al
                decimal tahminiButceTutari = GetTahminiButceTutari(_seciliKoyIndex, _seciliDonemIndex);

                // Kategorinin seçili olup olmadığını kontrol et
                if (cmbGelirKategori.SelectedIndex < 0 || !(cmbGelirKategori.SelectedItem is GelirKategori))
                {
                    MessageBox.Show("Lütfen geçerli bir gelir kategorisi seçiniz!");
                    return;
                }

                // Gelir kategorisi olarak dönüştür
                GelirKategori selectedGelirKategori = (GelirKategori)cmbGelirKategori.SelectedItem;

                // Tutarın boş olup olmadığını kontrol et
                if (string.IsNullOrEmpty(txtTutar.Text))
                {
                    MessageBox.Show("Lütfen Tahmini Gelir Miktarını Giriniz !!!");
                    return;
                }

                // Girilen tutarı decimal tipine dönüştür
                if (!decimal.TryParse(txtTutar.Text, out decimal girilenTutar))
                {
                    MessageBox.Show("Lütfen geçerli bir tutar giriniz!");
                    return;
                }

                // Kalan tutarı hesapla
                decimal kalanTutar = KalanTutar(tahminiButceTutari, girilenTutar);

                // Kalan tutarı mesaj olarak göster
                MessageBox.Show(girilenTutar + " girişi yapıldı. Tahmini bütçeden kalan tutar: " + kalanTutar);

                // Eğer kalan tutar 0 veya daha küçükse, yeni kayıt girmeyi engelle
                if (kalanTutar <= 0)
                {
                    pcBoxKaydet.Visible = false;
                    lblGelirKategori.Visible = false;
                    cmbGelirKategori.Visible = false;
                    lblDegisiklik.Visible = false;
                    cmbDegisiklik.Visible = false;
                    lblTutar.Visible = false;
                    txtTutar.Visible = false;
                }

                // Degisiklik seçiliyse, Degisiklik nesnesini al
                Degisiklik selectedDegisiklik = null;
                if (cmbDegisiklik.SelectedIndex > 0)
                {
                    var selectedItem = cmbDegisiklik.SelectedItem as ComboBoxItem;
                    if (selectedItem != null && selectedItem.Value is Degisiklik)
                    {
                        selectedDegisiklik = (Degisiklik)selectedItem.Value;
                    }
                    else
                    {
                        MessageBox.Show("Geçerli bir Degisiklik Türü seçiniz!");
                        return;
                    }
                }

                // Yeni tahmini gelir oluştur
                TahminiButceGelir yeniTahminiGelir = new TahminiButceGelir
                {
                    KoyId = _seciliKoyIndex,
                    DonemId = _seciliDonemIndex,
                    TahimiGelirTutari = girilenTutar,
                    GelirKategoriId = selectedGelirKategori.Id,
                    DegisiklikId = selectedDegisiklik?.Id
                };

                // TahminiButceGelir tablosuna yeni kaydı ekle
                tahminiButceGelirManager.Add(yeniTahminiGelir);

                // ComboBox'tan kaydedilen öğeyi kaldır
                cmbGelirKategori.Items.Remove(selectedGelirKategori);

                // Temizle ve gelirleri güncelle
                Temizle();
                TahminiGelirler();

                // Eklenen satırı seç ve görünür yap
                dgvTahminiGelirler.Rows[dgvTahminiGelirler.Rows.Count - 1].Selected = true;
                dgvTahminiGelirler.FirstDisplayedScrollingRowIndex = dgvTahminiGelirler.Rows.Count - 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tahmini Gelir Kaydı Yapılamadı !!! " + ex.Message);
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

        private decimal GetToplamTahminiGelir(int koyId, byte donemId)
        {
            using (KoyButcesiContext context = new KoyButcesiContext())
            {
                var toplamTahminiGelir = context.TahminiButceGelirs
                    .Where(tb => tb.KoyId == koyId && tb.DonemId == donemId)
                    .Sum(tb => (decimal?)tb.TahimiGelirTutari) ?? 0;

                return toplamTahminiGelir;
            }
        }

        private List<decimal> GetOncekiTahminiGelirMiktarlari(int koyId, byte donemId)
        {
            using (KoyButcesiContext context = new KoyButcesiContext())
            {
                return context.TahminiButceGelirs
                    .Where(tb => tb.KoyId == koyId && tb.DonemId == donemId)
                    .Select(tb => tb.TahimiGelirTutari)
                    .ToList();
            }
        }

        private void UpdateTahminiButceTutari(int koyId, byte donemId, decimal yeniTutar)
        {
            using (KoyButcesiContext context = new KoyButcesiContext())
            {
                var tahminiButce = context.TahminiButces.FirstOrDefault(tb => tb.KoyId == koyId && tb.DonemId == donemId);
                if (tahminiButce != null)
                {
                    tahminiButce.TahminiButceTutari = yeniTutar;
                    context.SaveChanges();
                }
            }
        }

        private void Temizle()
        {
            cmbGelirKategori.SelectedIndex = 0;
            cmbDegisiklik.Visible = false;
            lblDegisiklik.Visible = false;
            txtTutar.Text = string.Empty;

            cmbGelirKategori.Focus();

            // Degisiklik ComboBox'u sıfırlama
            cmbDegisiklik.SelectedIndex = -1;
        }

        //Gelirleri DatagridView'e yükleyecek metot
        private void TahminiGelirler()
        {
            try
            {
                // Tahmini gelirleri DataGridView'e yükler
                var gelirler = tahminiButceGelirManager.GetTahminiButceGelirDetails(_seciliKoyIndex, _seciliDonemIndex);

                // Veriyi DataGridView'e bağla
                dgvTahminiGelirler.DataSource = gelirler;

                // Gereksiz kolonları gizle
                dgvTahminiGelirler.Columns["TahminiButceGelirId"].Visible = false;
                dgvTahminiGelirler.Columns["KoyAdi"].Visible = false;
                dgvTahminiGelirler.Columns["DonemAdi"].Visible = false;
                dgvTahminiGelirler.Columns["KoyId"].Visible = false;
                dgvTahminiGelirler.Columns["DonemId"].Visible = false;
                dgvTahminiGelirler.Columns["GelirKategoriId"].Visible = false;
                dgvTahminiGelirler.Columns["DegisiklikId"].Visible = false; // Bu satırı kaldırın

                // DataGridView'in görüntü ayarlarını yapar
                dgvTahminiGelirler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Tüm alanı kaplaması için
                dgvTahminiGelirler.RowHeadersVisible = false; // Sol baştaki boş satırları gizler
                dgvTahminiGelirler.ColumnHeadersDefaultCellStyle.Font = new Font("Impact", 14); // Başlık yazı fontu ve büyüklüğü
                dgvTahminiGelirler.ColumnHeadersHeight = 40; // Başlık yüksekliği
                dgvTahminiGelirler.EnableHeadersVisualStyles = false; // Başlık yazı rengini değiştirmek için
                dgvTahminiGelirler.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray; // Başlık arka plan rengi

            }
            catch (Exception ex)
            {
                // Hata oluştuğunda kullanıcıya bilgi verir
                MessageBox.Show("Veri yüklenirken bir hata oluştu: " + ex.Message);
            }
        }

        //TEXBOX'A BELİRLİ BİR FORMATTA VE SADECE RAKAM GİRİLMESİNİ SAĞLAMAK İÇİN KEYPRESS IVENT
        private void txtTutar_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Sadece rakamlara ve kontrol tuşlarına izin ver
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            // Yalnızca bir tane nokta veya virgül olmasına izin ver
            if ((e.KeyChar == '.' || e.KeyChar == ',') && (sender as TextBox).Text.IndexOfAny(new char[] { '.', ',' }) > -1)
            {
                e.Handled = true;
            }

        }

        //TEXBOX'A BELİRLİ BİR FORMATTA VE SADECE RAKAM GİRİLMESİNİ SAĞLAMAK İÇİN LEAVE IVENT
        private void txtTutar_Leave(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (double.TryParse(txt.Text, out double value))
            {
                // Sayıyı formatla ve güncelle
                txt.Text = value.ToString("#,0.00", CultureInfo.InvariantCulture);
            }
            else
            {
                // Geçerli bir sayı değilse temizle
                txt.Text = string.Empty;
            }
        }

        private void dgvTahminiGelirler_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Satırın indeksini al
            int rowIndex = e.RowIndex;

            // Seçili satırın verilerini al
            if (rowIndex >= 0 && rowIndex < dgvTahminiGelirler.Rows.Count)
            {
                DataGridViewRow selectedRow = dgvTahminiGelirler.Rows[rowIndex];

                // Verileri ilgili alanlara aktar
                cmbGelirKategori.SelectedIndex = (byte)selectedRow.Cells["GelirKategoriId"].Value;
                cmbGelirKategori.SelectedText = selectedRow.Cells["GelirKategoriAdi"].Value.ToString();
                // cmbDegisiklik.SelectedIndex = (byte)selectedRow.Cells["DegisiklikId"].Value;
                cmbDegisiklik.SelectedText = selectedRow.Cells["DegisiklikAdi"].Value.ToString();
                //txtTutar.Text=selectedRow.Cells
                txtTutar.Text = selectedRow.Cells["TahimiGelirTutari"].Value.ToString();


                // Seçili satırı işaretle
                dgvTahminiGelirler.Rows[rowIndex].Selected = true;
            }
        }

        private void pcBoxGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                // Önceki seçili satırın indeksini sakla
                int previousRowIndex = dgvTahminiGelirler.CurrentRow.Index;

                // Seçili satırın verilerini al
                TahminiButceGelirDetailDto seciliTahminiGelir = (TahminiButceGelirDetailDto)dgvTahminiGelirler.CurrentRow.DataBoundItem;
                // Güncellenecek verileri al
                int tahminiButceGelirId = seciliTahminiGelir.TahminiButceGelirId;
                byte gelirKategoriId = (byte)cmbGelirKategori.SelectedIndex; // cmbGelirKategori'den seçilen öğenin Id'sini al
                byte degisiklikId = (byte)cmbDegisiklik.SelectedIndex;
                decimal tutar = Convert.ToDecimal(txtTutar.Text);

                // Güncelleme işlemini yap
                TahminiButceGelir guncellenecekTahminiGelir = new TahminiButceGelir
                {
                    Id = tahminiButceGelirId,
                    KoyId = _seciliKoyIndex,
                    DonemId = _seciliDonemIndex,
                    GelirKategoriId = gelirKategoriId,
                    DegisiklikId = degisiklikId,
                    TahimiGelirTutari = tutar,
                };

                // Güncelleme işlemini yapmak için GelirManager üzerinden Update metodunu çağır
                tahminiButceGelirManager.Update(guncellenecekTahminiGelir);

                // Başarılı bir şekilde güncelleme yapıldı mesajı göster
                MessageBox.Show("Tahimini Gelir başarıyla güncellendi.");

                Temizle();

                // Yeniden yükleme işlemi (opsiyonel)
                TahminiGelirler();

                Temizle();

                // Tüm satırların seçiliğini kaldır
                foreach (DataGridViewRow row in dgvTahminiGelirler.Rows)
                {
                    row.Selected = false;
                }

                // Önceki seçili satırı tekrar seç
                dgvTahminiGelirler.Rows[previousRowIndex].Selected = true;

                // DataGridView'in ilgili satırını görünür alan içine kaydır
                dgvTahminiGelirler.FirstDisplayedScrollingRowIndex = previousRowIndex;
            }
            catch (Exception ex)
            {
                // Hata durumunda kullanıcıya bilgi ver
                MessageBox.Show("Gelir güncellenirken bir hata oluştu: " + ex.Message);
            }
        }

        private void pcBoxSil_Click(object sender, EventArgs e)
        {
            try
            {
                // Seçili satırı kontrol et
                if (dgvTahminiGelirler.SelectedRows.Count > 0)
                {
                    // Kullanıcıya silme işlemini onaylamasını sor
                    var result = MessageBox.Show("Seçili satırı silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    // Eğer kullanıcı "Evet" derse
                    if (result == DialogResult.Yes)
                    {
                        // Seçili satırın bağlı olduğu veri nesnesini al
                        var selectedRow = dgvTahminiGelirler.SelectedRows[0];
                        var tahminiGelirDetailDto = (TahminiButceGelirDetailDto)selectedRow.DataBoundItem;

                        // Silinecek Gelir nesnesini oluştur
                        var silinecekTahminiGelir = new TahminiButceGelir
                        {
                            Id = tahminiGelirDetailDto.TahminiButceGelirId,
                            // Diğer özellikleri de buradan alabilirsiniz
                        };

                        // Silme işlemini gerçekleştir
                        tahminiButceGelirManager.Delete(silinecekTahminiGelir);

                        // Daha sonra DataGridView'i güncelleyebilirsiniz
                        TahminiGelirler();
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
    }
}
