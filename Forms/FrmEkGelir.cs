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
        }

        private void LoadGelirKategoriler()
        {
            var gelirKategoriler = gelirKategoriManager.GetAll();

            cmbGelirKategori.DisplayMember = "GelirKategoriAdi"; // GelirKategori nesnesinde görüntülenecek özellik
            cmbGelirKategori.ValueMember = "Id"; // GelirKategori nesnesinde seçildiğinde kullanılacak özellik
            cmbGelirKategori.DataSource = gelirKategoriler;
        }

        private void LoadDegisiklikler()
        {
            var degisiklikler = degisiklikManager.GetAll();

            cmbDegisiklik.DisplayMember = "DegisiklikAdi"; // Degisiklik nesnesinde görüntülenecek özellik
            cmbDegisiklik.ValueMember = "Id"; // Degisiklik nesnesinde seçildiğinde kullanılacak özellik
            cmbDegisiklik.DataSource = degisiklikler;
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
            cmbDegisiklik.Visible = false;
            lblDegisiklik.Visible = false;
            txtTutar.Text = string.Empty;

            cmbGelirKategori.Focus();

            // Degisiklik ComboBox'u sıfırlama
            cmbDegisiklik.SelectedIndex = -1;
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

                // Alt kategorinin seçili olup olmadığını kontrol et
                if (cmbDegisiklik.SelectedIndex < 0 || !(cmbDegisiklik.SelectedItem is Degisiklik))
                {
                    MessageBox.Show("Lütfen geçerli bir Değişiklik seçiniz!");
                    return;
                }

                // Gelir kategorisi olarak dönüştür
                GelirKategori selectedGelirKategori = (GelirKategori)cmbGelirKategori.SelectedItem;
                Degisiklik selectedDegisiklik = (Degisiklik)cmbDegisiklik.SelectedItem;

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
                EkButceGelir yeniEkGelir = new EkButceGelir
                {
                    KoyId = _seciliKoyIndex,
                    DonemId = _seciliDonemIndex,
                    EkGelirTutari = girilenTutar,
                    GelirKategoriId = selectedGelirKategori.Id,
                    DegisiklikId = selectedDegisiklik.Id
                };

                // TahminiButceGelir tablosuna yeni kaydı ekle
                ekButceGelirManager.Add(yeniEkGelir);

                // Temizle ve idari işleri güncelle
                Temizle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ek Bütçe için Gelir Kaydı Yapılamadı !!! " + ex.Message);
            }
        }

        private void cmbGelirKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGelirKategori.Text == "Hasılat" || cmbGelirKategori.Text == "Resim ve harçlar" || cmbGelirKategori.Text == "Köy vakıf ve avarız geliri" || cmbGelirKategori.Text == "İstikrazlar")
            {
                cmbDegisiklik.Visible = true;
                lblDegisiklik.Visible = true;

                ////Degisiklik görünür olduğunda Tutar'ın lokasyonu
                lblTutar.Location = new Point(9, 148);
                txtTutar.Location = new Point(176, 146);

                LoadDegisiklikler();
            }
            else
            {
                lblDegisiklik.Visible = false;
                cmbDegisiklik.Visible = false;
                lblTutar.Location = new Point(9, 111);
                txtTutar.Location = new Point(176, 106);

                cmbDegisiklik.SelectedIndex = -1;
            }
        }
    }
}
