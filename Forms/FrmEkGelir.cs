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
        GelirKategoriManager gelirKategoriManager;
        DegisiklikManager degisiklikManager;
        EkButceGelirManager ekButceGelirManager;
        KoyManager koyManager;
        DonemManager donemManager;
        //AnaSayfada comboboxlardan yapılan seçimlerin index lerini getirmek için
        int _seciliKoyIndex;
        byte _seciliDonemIndex;

        public FrmEkGelir(int seciliKoyIndex, byte seciliDonemIndex)
        {
            InitializeComponent();

            EkButceGelirManager _ekButceGelirManager = new EkButceGelirManager(new EfEkButceGelirDal());
            ekButceGelirManager = _ekButceGelirManager;

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

        private void FrmEkGelir_Load(object sender, EventArgs e)
        {
            try
            {
                GelirKategoriDoldur();
                DegisiklikDoldur();
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

                // Girilen tutarı decimal tipine dönüştür
                if (!decimal.TryParse(txtTutar.Text, out decimal girilenTutar))
                {
                    MessageBox.Show("Lütfen geçerli bir tutar giriniz!");
                    return;
                }

                // Yeni tahmini gelir oluştur
                EkButceGelir yeniEkButceGelir = new EkButceGelir
                {
                    KoyId = _seciliKoyIndex,
                    DonemId = _seciliDonemIndex,
                    EkGelirTutari = girilenTutar,
                    GelirKategoriId = selectedGelirKategori.Id,
                    DegisiklikId = selectedDegisiklik?.Id
                };
                //EkTahminiButceGelir tablosuna yeni kaydı ekle
                ekButceGelirManager.Add(yeniEkButceGelir);

                // ComboBox'tan kaydedilen öğeyi kaldır
                cmbGelirKategori.Items.Remove(selectedGelirKategori);

                // Temizle ve gelirleri güncelle
                Temizle();
                //TahminiGelirler();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tahmini Gelir Kaydı Yapılamadı !!! " + ex.Message);
            }
        }
    }
}
