using Business.Abstract;
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
    public partial class FrmTahminiIdariIsler : Form
    {
        TahminiButceIdariIslerManager tahminiIdariIslerManager;
        IdarIslerKategoriManager idariIslerKategoriManager;
        IdariIslerAltKategoriManager idariIslerAltKategoriManager;

        KoyManager koyManager;
        DonemManager donemManager;

        //AnaSayfada comboboxlardan yapılan seçimlerin index lerini getirmek için
        int _seciliKoyIndex;
        byte _seciliDonemIndex;

        public FrmTahminiIdariIsler(int seciliKoyIndex, byte seciliDonemIndex)
        {
            InitializeComponent();

            IdarIslerKategoriManager _idarIslerKategoriManager = new IdarIslerKategoriManager(new EfIdariIslerKategoriDal());
            idariIslerKategoriManager = _idarIslerKategoriManager;

            IdariIslerAltKategoriManager _idariIslerAltKategoriManager = new IdariIslerAltKategoriManager(new EfIdariIslerAltKategoriDal());
            idariIslerAltKategoriManager = _idariIslerAltKategoriManager;

            TahminiButceIdariIslerManager _tahminiIdariIslerManager = new TahminiButceIdariIslerManager(new EfTahminiButceIdariIslerDal());
            tahminiIdariIslerManager = _tahminiIdariIslerManager;

            KoyManager _koyManager = new KoyManager(new EfKoyDal());
            koyManager = _koyManager;

            DonemManager _donemManager = new DonemManager(new EfDonemDal());
            donemManager = _donemManager;

            //AnaSayfada comboboxlardan yapılan seçimlerin index lerini getirmek için
            _seciliKoyIndex = seciliKoyIndex;
            _seciliDonemIndex = seciliDonemIndex;
        }

        private void FrmTahminiIdariIsler_Load(object sender, EventArgs e)
        {
            try
            {
                IdariIslerDoldur();
                TahminiIdariIsler();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void IdariIslerDoldur()
        {
            try
            {
                List<IdariIslerKategori> idariIslerKategorileri = idariIslerKategoriManager.GetAll();

                // Placeholder öğesini listenin başına eklemek için yeni bir liste oluşturun
                var placeholderItem = new IdariIslerKategori { Id = 0, IdariIslerKategoriAdi = "-İdari İşler Türünü Seçiniz-" };
                idariIslerKategorileri.Insert(0, placeholderItem);

                // BindingSource kullanarak ComboBox'u doldur
                var bindingSource = new BindingSource();
                bindingSource.DataSource = idariIslerKategorileri;

                cmbIdariIslerKategori.DisplayMember = "IdariIslerKategoriAdi"; // Görüntülenecek alan
                cmbIdariIslerKategori.ValueMember = "Id"; // Değer olarak kullanılacak alan
                cmbIdariIslerKategori.DataSource = bindingSource;

                cmbIdariIslerKategori.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("İdari İşler Türü Getirilirken Hata Oluştu");
                throw;
            }
        }

        private void cmbIdariIslerKategori_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                //  cmbIdariIslerAltKategori.Items.Clear();

                // Seçilen kategori index'i kontrol edilir. 
                // Eğer 0'dan büyükse (yoksa "Seçiniz" gibi bir değer seçilmiştir), işlemlere devam edilir.
                if (cmbIdariIslerKategori.SelectedIndex > 0)
                {
                    // Seçilen gider kategorisi cmbIdariIslerKategori'den alınır ve GiderKategori tipine dönüştürülür.
                    IdariIslerKategori secilenGiderKategori = cmbIdariIslerKategori.SelectedItem as IdariIslerKategori;

                    if (secilenGiderKategori != null)
                    {
                        // Seçilen kategorinin alt kategorileri GetByIdariIslerKategoriId metodu ile alınır.
                        List<IdariIslerAltKategori> secilenKategorinAltKategorisi = idariIslerAltKategoriManager.GetByIdariIslerKategoriId(secilenGiderKategori.Id);

                        // Alt kategorileri eklemeden önce DisplayMember ve ValueMember ayarlarını yap
                        cmbIdariIslerAltKategori.DisplayMember = "AltKategoriAdi"; // Görüntülenecek alan
                        cmbIdariIslerAltKategori.ValueMember = "Id"; // Değer olarak kullanılacak alan
                        cmbIdariIslerAltKategori.DataSource = secilenKategorinAltKategorisi;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Alt kategoriler getirilirken hata oluştu");
                throw;
            }
        }

        // Yeni kaydı ekledikten veya güncelledikten sonra ilgili satırı seçin ve görünür hale getirin
        private void SelectAndScrollToRow(int rowIndex)
        {
            dgvTahminiIdariIsler.ClearSelection(); // Mevcut seçimi kaldırın
            dgvTahminiIdariIsler.Rows[rowIndex].Selected = true; // İlgili satırı seçin
            dgvTahminiIdariIsler.FirstDisplayedScrollingRowIndex = rowIndex; // İlgili satırı görünür hale getirin
        }

        private void pcBoxKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                // Kategorinin seçili olup olmadığını kontrol et
                if (cmbIdariIslerKategori.SelectedIndex < 0 || !(cmbIdariIslerKategori.SelectedItem is IdariIslerKategori))
                {
                    MessageBox.Show("Lütfen geçerli bir kategori seçiniz!");
                    return;
                }

                // Alt kategorinin seçili olup olmadığını kontrol et
                if (cmbIdariIslerAltKategori.SelectedIndex < 0 || !(cmbIdariIslerAltKategori.SelectedItem is IdariIslerAltKategori))
                {
                    MessageBox.Show("Lütfen geçerli bir alt kategori seçiniz!");
                    return;
                }

                // Gelir kategorisi olarak dönüştür
                IdariIslerKategori selectedIdariIslerKategori = (IdariIslerKategori)cmbIdariIslerKategori.SelectedItem;
                IdariIslerAltKategori selectedIdariIslerAltKategori = (IdariIslerAltKategori)cmbIdariIslerAltKategori.SelectedItem;

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
                TahminiButceIdariIsler yeniIdariIsler = new TahminiButceIdariIsler
                {
                    KoyId = _seciliKoyIndex,
                    DonemId = _seciliDonemIndex,
                    TahminiIdariIslarTutari = girilenTutar,
                    IdariIslerKategoriId = selectedIdariIslerKategori.Id,
                    IdariIslerAltKategoriId = selectedIdariIslerAltKategori.Id
                };

                // TahminiButceGelir tablosuna yeni kaydı ekle
                tahminiIdariIslerManager.Add(yeniIdariIsler);

                // Yeni eklenen kaydın indeksini alın
                int newRowIndex = dgvTahminiIdariIsler.Rows.Count - 1;
                // Yeni eklenen satırı seçin ve görünür hale getirin
                SelectAndScrollToRow(newRowIndex);

                // Temizle ve idari işleri güncelle
                Temizle();
                TahminiIdariIsler();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tahmini İdari İşler Kaydı Yapılamadı !!! " + ex.Message);
            }
        }

        private void Temizle()
        {
            cmbIdariIslerKategori.SelectedIndex = -1;
            cmbIdariIslerAltKategori.SelectedIndex = -1;
            txtTutar.Text = "";
            cmbIdariIslerKategori.Focus();
        }

        private void TahminiIdariIsler()
        {
            try
            {
                // Tahmini gelirleri DataGridView'e yükler
                var idariIsler = tahminiIdariIslerManager.GetTahminiButceIdariIslerDetails(_seciliKoyIndex, _seciliDonemIndex);

                // Veriyi DataGridView'e bağla
                dgvTahminiIdariIsler.DataSource = idariIsler;

                //// Gereksiz kolonları gizle
                dgvTahminiIdariIsler.Columns["TahminiButceIdariIslerId"].Visible = false;
                dgvTahminiIdariIsler.Columns["KoyAdi"].Visible = false;
                dgvTahminiIdariIsler.Columns["DonemAdi"].Visible = false;
                dgvTahminiIdariIsler.Columns["KoyId"].Visible = false;
                dgvTahminiIdariIsler.Columns["DonemId"].Visible = false;
                dgvTahminiIdariIsler.Columns["IdariIslerKategoriId"].Visible = false;
                dgvTahminiIdariIsler.Columns["IdariIslerAltKategoriId"].Visible = false; // Bu satırı kaldırın

                // Tutar kolonundaki sayıları formatlamak için
                dgvTahminiIdariIsler.Columns["TahminiIdariIslarTutari"].DefaultCellStyle.Format = "#,0.00";

                // DataGridView'in görüntü ayarlarını yapar
                dgvTahminiIdariIsler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Tüm alanı kaplaması için
                dgvTahminiIdariIsler.RowHeadersVisible = false; // Sol baştaki boş satırları gizler
                dgvTahminiIdariIsler.ColumnHeadersDefaultCellStyle.Font = new Font("Impact", 14); // Başlık yazı fontu ve büyüklüğü
                dgvTahminiIdariIsler.ColumnHeadersHeight = 40; // Başlık yüksekliği
                dgvTahminiIdariIsler.EnableHeadersVisualStyles = false; // Başlık yazı rengini değiştirmek için
                dgvTahminiIdariIsler.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray; // Başlık arka plan rengi

                dgvTahminiIdariIsler.Columns["IdariIslerKategoriAdi"].HeaderText = "Kategori";
                dgvTahminiIdariIsler.Columns["IdariIslerAltKategoriAdi"].HeaderText = "Alt Kategori";
                dgvTahminiIdariIsler.Columns["TahminiIdariIslarTutari"].HeaderText = "Tutar";
            }
            catch (Exception ex)
            {
                // Hata oluştuğunda kullanıcıya bilgi verir
                MessageBox.Show("Veri yüklenirken bir hata oluştu: " + ex.Message);
            }
        }

        private int _selectedTahminiIdariIslerId;
        private void dgvTahminiIdariIsler_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Sadece double click yapılan satırı seç
                dgvTahminiIdariIsler.Rows[e.RowIndex].Selected = true;

                // Seçilen satırın görünürlüğünü sağla
                dgvTahminiIdariIsler.FirstDisplayedScrollingRowIndex = e.RowIndex;
                dgvTahminiIdariIsler.Rows[e.RowIndex].Cells[0].Selected = true;

                // Seçilen satırın bilgilerini al ve ilgili alanlara aktar
                DataGridViewRow row = dgvTahminiIdariIsler.Rows[e.RowIndex];

                // Seçilen kaydın ID'sini sakla
                _selectedTahminiIdariIslerId = Convert.ToInt32(row.Cells["TahminiButceIdariIslerId"].Value);

                // cmbIdariIslerKategori için
                byte idariIslerKategoriId = Convert.ToByte(row.Cells["IdariIslerKategoriId"].Value);
                cmbIdariIslerKategori.SelectedValue = idariIslerKategoriId;

                // Seçilen kategoriye bağlı alt kategorileri doldur
                IdariIslerKategori secilenIdariIslerKategori = cmbIdariIslerKategori.SelectedItem as IdariIslerKategori;
                if (secilenIdariIslerKategori != null)
                {
                    List<IdariIslerAltKategori> secilenKategorinAltKategorisi = idariIslerAltKategoriManager.GetByIdariIslerKategoriId(secilenIdariIslerKategori.Id);
                    cmbIdariIslerAltKategori.DisplayMember = "AltKategoriAdi"; // Görüntülenecek alan
                    cmbIdariIslerAltKategori.ValueMember = "Id"; // Değer olarak kullanılacak alan
                    cmbIdariIslerAltKategori.DataSource = secilenKategorinAltKategorisi;
                }

                // cmbIdariIslerAltKategori için
                byte IdariIslerAltKategoriId = Convert.ToByte(row.Cells["IdariIslerAltKategoriId"].Value);
                cmbIdariIslerAltKategori.SelectedValue = IdariIslerAltKategoriId;

                // Diğer alanlar ilgili hücrelerden alınıyor
                txtTutar.Text = row.Cells["TahminiIdariIslarTutari"].Value.ToString();
            }
        }

        private void pcBoxSil_Click(object sender, EventArgs e)
        {
            try
            {
                // DataGridView'de seçili olan satırları al
                if (dgvTahminiIdariIsler.SelectedRows.Count > 0)
                {
                    // Sadece ilk seçili satırı işleme al
                    DataGridViewRow selectedRow = dgvTahminiIdariIsler.SelectedRows[0];

                    // Seçili satırdan gerekli bilgileri al
                    int tahminiButceIdariIslerId = Convert.ToInt32(selectedRow.Cells["TahminiButceIdariIslerId"].Value);

                    // Kullanıcıdan silme işlemini onaylamasını iste
                    DialogResult result = MessageBox.Show("Seçili kaydı silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        // Seçili kaydı sil
                        tahminiIdariIslerManager.Delete(new TahminiButceIdariIsler { Id = tahminiButceIdariIslerId });

                        // DataGridView'i güncelle
                        TahminiIdariIsler();

                        // Kullanıcıya silme işleminin başarılı olduğunu bildir
                        MessageBox.Show("Kayıt başarıyla silindi.");
                        Temizle();
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen silmek istediğiniz kaydı seçiniz.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kayıt silinirken bir hata oluştu: " + ex.Message);
            }
        }

        private void pcBoxGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                // Güncelleme için gerekli kontroller
                if (cmbIdariIslerKategori.SelectedIndex < 0 || !(cmbIdariIslerKategori.SelectedItem is IdariIslerKategori))
                {
                    MessageBox.Show("Lütfen geçerli bir kategori seçiniz!");
                    return;
                }

                if (cmbIdariIslerAltKategori.SelectedIndex < 0 || !(cmbIdariIslerAltKategori.SelectedItem is IdariIslerAltKategori))
                {
                    MessageBox.Show("Lütfen geçerli bir alt kategori seçiniz!");
                    return;
                }

                if (string.IsNullOrEmpty(txtTutar.Text))
                {
                    MessageBox.Show("Lütfen Tutarı Giriniz !!!");
                    return;
                }

                if (!decimal.TryParse(txtTutar.Text, out decimal girilenTutar))
                {
                    MessageBox.Show("Lütfen geçerli bir tutar giriniz!");
                    return;
                }

                IdariIslerKategori selectedIdariIslerKategori = (IdariIslerKategori)cmbIdariIslerKategori.SelectedItem;
                IdariIslerAltKategori selectedIdariIslerAltKategori = (IdariIslerAltKategori)cmbIdariIslerAltKategori.SelectedItem;

                // Güncellenmiş tahmini idari işleri oluştur
                TahminiButceIdariIsler guncellenmisIdariIsler = new TahminiButceIdariIsler
                {
                    Id = _selectedTahminiIdariIslerId,
                    KoyId = _seciliKoyIndex,
                    DonemId = _seciliDonemIndex,
                    TahminiIdariIslarTutari = girilenTutar,
                    IdariIslerKategoriId = selectedIdariIslerKategori.Id,
                    IdariIslerAltKategoriId = selectedIdariIslerAltKategori.Id
                };

                // TahminiButceIdariIsler tablosundaki kaydı güncelle
                tahminiIdariIslerManager.Update(guncellenmisIdariIsler);

                // Güncellenen satırın indeksini alın
                int updatedRowIndex = dgvTahminiIdariIsler.CurrentRow.Index;
                // Güncellenen satırı seçin ve görünür hale getirin
                SelectAndScrollToRow(updatedRowIndex);

                // Temizle ve idari işleri güncelle
                Temizle();
                TahminiIdariIsler();

                MessageBox.Show("Tahmini İdari İşler Kaydı Güncellendi !!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tahmini İdari İşler Güncellenemedi !!! " + ex.Message);
            }
        }
    }
}



