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
        GiderKategoriManager giderKategoriManager;
        GiderAltKategoriManager giderAltKategoriManager;
        DegisiklikManager degisiklikManager;
        TahminiButceGiderManager tahminiButceGiderManager;
        KoyManager koyManager;
        DonemManager donemManager;
        //AnaSayfada comboboxlardan yapılan seçimlerin index lerini getirmek için
        int _seciliKoyIndex;
        byte _seciliDonemIndex;

        public FrmTahminiGider(int seciliKoyIndex, byte seciliDonemIndex)
        {
            InitializeComponent();

            GiderKategoriManager _giderKategoriManager = new GiderKategoriManager(new EfGiderKategoriDal());
            giderKategoriManager = _giderKategoriManager;

            GiderAltKategoriManager _giderAltKategoriManager = new GiderAltKategoriManager(new EfGiderAltKategoriDal());
            giderAltKategoriManager = _giderAltKategoriManager;

            DegisiklikManager _degisiklikManager = new DegisiklikManager(new EfDegisiklikDal());
            degisiklikManager = _degisiklikManager;

            TahminiButceGiderManager _tahminiButceGiderManager = new TahminiButceGiderManager(new EfTahminiButceGiderDal());
            tahminiButceGiderManager = _tahminiButceGiderManager;

            _seciliKoyIndex = seciliKoyIndex;
            _seciliDonemIndex = seciliDonemIndex;

            KoyManager _koyManager = new KoyManager(new EfKoyDal());
            koyManager = _koyManager;

            DonemManager _donemManager = new DonemManager(new EfDonemDal());
            donemManager = _donemManager;

            koyManager = new KoyManager(new EfKoyDal());
            donemManager = new DonemManager(new EfDonemDal());

        }

        private void FrmTahminiGider_Load(object sender, EventArgs e)
        {
            cmbDegisiklik.Visible = false;
            lblDegisiklik.Visible = false;

            GiderKategoriDoldur();
            DegisiklikDoldur();

            lblTutar.Location = new Point(10, 139);
            txtTutar.Location = new Point(217, 134);
        }

        private void GiderKategoriDoldur()
        {
            //try
            //{
            //    List<GiderKategori> giderKategorileri = giderKategoriManager.GetAll();
            //    cmbGiderKategori.Items.AddRange(giderKategorileri.ToArray());
            //    cmbGiderKategori.Items.Insert(0, "-Gider Türünü Seçiniz_");
            //    cmbGiderKategori.SelectedIndex = 0;
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Gider Türleri Getirilirken Hata Ouştu !");
            //    throw;
            //}


            try
            {
                List<GiderKategori> giderKategorileri = giderKategoriManager.GetAll();
                cmbGiderKategori.Items.AddRange(giderKategorileri.ToArray());
                cmbGiderKategori.Items.Insert(0, "-Gider Türünü Seçiniz-");
                cmbGiderKategori.SelectedIndex = 0;
                // Debug için içerikleri yazdır
                foreach (var item in cmbGiderKategori.Items)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gider Türleri Getirilirken Hata Oluştu: " + ex.Message);
            }

        }

        private void DegisiklikDoldur()
        {
            //try
            //{
            //    cmbDegisiklik.Items.Clear();
            //    List<Degisiklik> degisiklikler = degisiklikManager.GetAll();
            //    cmbDegisiklik.Items.AddRange(degisiklikler.ToArray());
            //    cmbDegisiklik.Items.Insert(0, "-Değişiklik Gerekiyorsa Seçiniz-");
            //    cmbDegisiklik.SelectedIndex = 0;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Değişiklikler Getirilirken Hata Oluştu: " + ex.Message);
            //}

            try
            {
                cmbDegisiklik.Items.Clear();
                List<Degisiklik> degisiklikler = degisiklikManager.GetAll();
                cmbDegisiklik.Items.AddRange(degisiklikler.ToArray());
                cmbDegisiklik.Items.Insert(0, "-Değişiklik Gerekiyorsa Seçiniz-");
                cmbDegisiklik.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Değişiklikler Getirilirken Hata Oluştu: " + ex.Message);
            }
        }

        private void cmbGiderKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbGiderAltKategori.Items.Clear();
                if (cmbGiderKategori.SelectedIndex > 0)
                {
                    GiderKategori secilenGiderKategori = cmbGiderKategori.SelectedItem as GiderKategori;
                    if (secilenGiderKategori != null)
                    {
                        List<GiderAltKategori> secilenGiderinAltKategorileri = giderAltKategoriManager.GetByGiderKategoriId(secilenGiderKategori.Id);

                        if (secilenGiderinAltKategorileri != null && secilenGiderinAltKategorileri.Count > 0)
                        {
                            cmbGiderAltKategori.Items.AddRange(secilenGiderinAltKategorileri.ToArray());
                        }
                        else
                        {
                            MessageBox.Show("Seçili gider kategorisi için alt kategori bulunamadı!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Geçerli bir gider kategorisi seçiniz!");
                    }

                    cmbDegisiklik.Visible = false;
                    lblDegisiklik.Visible = false;

                    lblTutar.Location = new Point(10, 139);
                    txtTutar.Location = new Point(217, 134);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gider alt kategorileri yüklenirken hata oluştu: " + ex.Message);
            }

            if (cmbGiderAltKategori.Text == "Yangın Vesaiti Masrafı" || cmbGiderAltKategori.Text == "Aydınlatma Masrafı" || cmbGiderAltKategori.Text == "Vergi ve Sigorta Masrafı vakıf ve avarız geliri" || cmbGiderAltKategori.Text == "Köy Borçları, İstikraz Taksit ve Faizleri" || cmbGiderAltKategori.Text == "Mahkeme ve Keşif Masrafları" || cmbGiderAltKategori.Text == "İstimlak Masrafları" || cmbGiderAltKategori.Text == "Umulmadık Masraflar")
            {
                cmbDegisiklik.Visible = true;
                lblDegisiklik.Visible = true;

                lblTutar.Location = new Point(10, 174);
                txtTutar.Location = new Point(217, 172);

                DegisiklikDoldur();
            }
            else
            {
                cmbDegisiklik.Visible = false;
                lblDegisiklik.Visible = false;

                lblTutar.Location = new Point(10, 139);
                txtTutar.Location = new Point(217, 134);

                cmbDegisiklik.SelectedIndex = -1;
            }

            //if (cmbGiderKategori.SelectedItem is GiderKategori selectedGiderKategori)
            //{
            //    // Seçilen Gider Kategori'ye göre Alt Kategori ComboBox'ını doldur
            //    giderAltKategoriManager.GetByGiderKategoriId(selectedGiderKategori.Id);

            //    FillGiderAltKategoriComboBox(selectedGiderKategori.Id);
            //}
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
            decimal toplamTahminiGelir = GetToplamTahminiGider(_seciliKoyIndex, _seciliDonemIndex);

            // Kalan tutarı hesapla
            decimal kalanTutar = tahminiButceTutari - toplamTahminiGelir - girilenTutar;

            return kalanTutar;
        }

        //// Kalan tutarı hesapla
        //decimal kalanTutar = KalanTutar(tahminiButceTutari, girilenTutar);

        //// Kalan tutarı mesaj olarak göster
        //MessageBox.Show(girilenTutar + " girişi yapıldı. Tahmini bütçeden kalan tutar: " + kalanTutar);

        //cmbGiderAlKategori seçimini görmediği için eklenen kodlar
        private void FillGiderKategoriComboBox()
        {
            // GiderKategori verilerini çekme ve ComboBox'a ekleme
            var giderKategorileri =giderKategoriManager.GetAll(); // Veritabanından veya başka bir kaynaktan veri çekme
            cmbGiderKategori.Items.AddRange(giderKategorileri.ToArray());
        }

        private void FillGiderAltKategoriComboBox(byte giderKategoriId)
        {
            // Seçilen GiderKategori'ye bağlı Alt Kategori verilerini çekme ve ComboBox'a ekleme
            var giderAltKategorileri = giderAltKategoriManager.GetByGiderKategoriId(giderKategoriId); // Veritabanından veya başka bir kaynaktan veri çekme
            cmbGiderAltKategori.Items.AddRange(giderAltKategorileri.ToArray());
        }

        private void pcBoxKaydet_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    // Tahmini bütçe tutarını al
            //    decimal tahminiButceTutari = GetTahminiButceTutari(_seciliKoyIndex, _seciliDonemIndex);

            //    // Gider Kategori kontrolü
            //    if (cmbGiderKategori.SelectedIndex <= 0 || !(cmbGiderKategori.SelectedItem is GiderKategori selectedGiderKategori))
            //    {
            //        MessageBox.Show("Lütfen geçerli bir Gider Türü seçiniz!");
            //        return;
            //    }

            //    // Gider Alt Kategori kontrolü
            //    if (cmbGiderAltKategori.SelectedIndex <= 0 || !(cmbGiderAltKategori.SelectedItem is GiderAltKategori selectedGiderAltKategori))
            //    {
            //        // Debug mesajı
            //        MessageBox.Show($"Alt Kategori Hatası: SelectedIndex={cmbGiderAltKategori.SelectedIndex}, SelectedItem={cmbGiderAltKategori.SelectedItem}");
            //        MessageBox.Show("Lütfen geçerli bir Alt Gider Türü seçiniz!");
            //        return;
            //    }

            //    // Debug mesajları ekleme
            //    MessageBox.Show($"Gider Kategori: {selectedGiderKategori.GiderKategoriAdi}, Gider Alt Kategori: {selectedGiderAltKategori.GiderAltKategoriAdi}");

            //    // Tutar kontrolü
            //    if (string.IsNullOrEmpty(txtTutar.Text))
            //    {
            //        MessageBox.Show("Lütfen Tahmini Gider Miktarını Giriniz!");
            //        return;
            //    }

            //    if (!decimal.TryParse(txtTutar.Text, out decimal girilenTutar))
            //    {
            //        MessageBox.Show("Lütfen geçerli bir tutar giriniz!");
            //        return;
            //    }

            //    // Değişiklik kontrolü
            //    if (cmbDegisiklik.Visible && (cmbDegisiklik.SelectedIndex <= 0 || cmbDegisiklik.SelectedItem == null))
            //    {
            //        MessageBox.Show("Lütfen geçerli bir Değişiklik seçiniz!");
            //        return;
            //    }

            //    Degisiklik selectedDegisiklik = null;
            //    if (cmbDegisiklik.Visible && cmbDegisiklik.SelectedIndex > 0)
            //    {
            //        selectedDegisiklik = (Degisiklik)cmbDegisiklik.SelectedItem;
            //    }

            //    decimal kalanTutar = KalanTutar(tahminiButceTutari, girilenTutar);
            //    MessageBox.Show($"{girilenTutar} girişi yapıldı. Tahmini bütçeden kalan tutar: {kalanTutar}");

            //    if (kalanTutar <= 0)
            //    {
            //        pcBoxKaydet.Visible = false;
            //        lblGiderKategori.Visible = false;
            //        cmbGiderKategori.Visible = false;
            //        lblGiderAltKategori.Visible = false;
            //        cmbGiderAltKategori.Visible = false;
            //        lblDegisiklik.Visible = false;
            //        cmbDegisiklik.Visible = false;
            //        lblTutar.Visible = false;
            //        txtTutar.Visible = false;
            //    }

            //    // Tahmini gider kaydı oluşturma ve veri tabanına ekleme
            //    TahminiButceGider yeniTahminiGider = new TahminiButceGider
            //    {
            //        KoyId = _seciliKoyIndex,
            //        DonemId = _seciliDonemIndex,
            //        GiderKategoriId = selectedGiderKategori.Id,
            //        GiderAltKategoriId = selectedGiderAltKategori.Id,
            //        DegisiklikId = selectedDegisiklik?.Id,
            //        Tutar = girilenTutar
            //    };

            //    tahminiButceGiderManager.Add(yeniTahminiGider);

            //    cmbGiderAltKategori.Items.Remove(selectedGiderAltKategori);
            //    Temizle();
            //}
            //catch (ArgumentException argEx)
            //{
            //    MessageBox.Show("Argument Exception: " + argEx.Message);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Tahmini Gider Kaydı Yapılamadı: " + ex.Message);
            //}

            try
            {
                // Tahmini bütçe tutarını al
                decimal tahminiButceTutari = GetTahminiButceTutari(_seciliKoyIndex, _seciliDonemIndex);

                // Gider Kategori kontrolü
                if (cmbGiderKategori.SelectedIndex <= 0 || !(cmbGiderKategori.SelectedItem is GiderKategori selectedGiderKategori))
                {
                    MessageBox.Show("Lütfen geçerli bir Gider Türü seçiniz!");
                    return;
                }

                // Debug: Gider Kategori ve Alt Kategori ComboBox değerlerini göster
                MessageBox.Show($"Gider Kategori SelectedIndex: {cmbGiderKategori.SelectedIndex}, SelectedItem: {cmbGiderKategori.SelectedItem}");
                MessageBox.Show($"Gider Alt Kategori SelectedIndex: {cmbGiderAltKategori.SelectedIndex}, SelectedItem: {cmbGiderAltKategori.SelectedItem}");

                // Gider Alt Kategori kontrolü
                if (cmbGiderAltKategori.SelectedIndex <= 0 || !(cmbGiderAltKategori.SelectedItem is GiderAltKategori selectedGiderAltKategori))
                {
                    MessageBox.Show($"Alt Kategori Hatası: SelectedIndex={cmbGiderAltKategori.SelectedIndex}, SelectedItem={cmbGiderAltKategori.SelectedItem}");
                    MessageBox.Show("Lütfen geçerli bir Alt Gider Türü seçiniz!");
                    return;
                }

                MessageBox.Show($"Gider Kategori: {selectedGiderKategori.GiderKategoriAdi}, Gider Alt Kategori: {selectedGiderAltKategori.GiderAltKategoriAdi}");

                // Tutar kontrolü
                if (string.IsNullOrEmpty(txtTutar.Text))
                {
                    MessageBox.Show("Lütfen Tahmini Gider Miktarını Giriniz!");
                    return;
                }

                if (!decimal.TryParse(txtTutar.Text, out decimal girilenTutar))
                {
                    MessageBox.Show("Lütfen geçerli bir tutar giriniz!");
                    return;
                }

                // Değişiklik kontrolü
                if (cmbDegisiklik.Visible && (cmbDegisiklik.SelectedIndex <= 0 || cmbDegisiklik.SelectedItem == null))
                {
                    MessageBox.Show("Lütfen geçerli bir Değişiklik seçiniz!");
                    return;
                }

                Degisiklik selectedDegisiklik = null;
                if (cmbDegisiklik.Visible && cmbDegisiklik.SelectedIndex > 0)
                {
                    selectedDegisiklik = (Degisiklik)cmbDegisiklik.SelectedItem;
                }

                decimal kalanTutar = KalanTutar(tahminiButceTutari, girilenTutar);
                MessageBox.Show($"{girilenTutar} girişi yapıldı. Tahmini bütçeden kalan tutar: {kalanTutar}");

                if (kalanTutar <= 0)
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
                }

                // Tahmini gider kaydı oluşturma ve veri tabanına ekleme
                TahminiButceGider yeniTahminiGider = new TahminiButceGider
                {
                    KoyId = _seciliKoyIndex,
                    DonemId = _seciliDonemIndex,
                    GiderKategoriId = selectedGiderKategori.Id,
                    GiderAltKategoriId = selectedGiderAltKategori.Id,
                    DegisiklikId = selectedDegisiklik?.Id,
                    Tutar = girilenTutar
                };

                tahminiButceGiderManager.Add(yeniTahminiGider);

                cmbGiderAltKategori.Items.Remove(selectedGiderAltKategori);
                Temizle();
            }
            catch (ArgumentException argEx)
            {
                MessageBox.Show("Argument Exception: " + argEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tahmini Gider Kaydı Yapılamadı: " + ex.Message);
            }
        }

        private void cmbGiderAltKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGiderAltKategori.Text == "Yangın Vesaiti Masrafı" || cmbGiderAltKategori.Text == "Aydınlatma Masrafı" || cmbGiderAltKategori.Text == "Vergi ve Sigorta Masrafı vakıf ve avarız geliri" || cmbGiderAltKategori.Text == "Köy Borçları, İstikraz Taksit ve Faizleri" || cmbGiderAltKategori.Text == "Mahkeme ve Keşif Masrafları" || cmbGiderAltKategori.Text == "İstimlak Masrafları" || cmbGiderAltKategori.Text == "Umulmadık Masraflar")
                //{
                //    cmbDegisiklik.Visible = true;
                //    lblDegisiklik.Visible = true;

                //    lblTutar.Location = new Point(10, 174);
                //    txtTutar.Location = new Point(217, 172);

                //    DegisiklikDoldur();
                //}
                //else
                //{
                //    cmbDegisiklik.Visible = false;
                //    lblDegisiklik.Visible = false;

                //    lblTutar.Location = new Point(10, 139);
                //    txtTutar.Location = new Point(217, 134);

                //    cmbDegisiklik.SelectedIndex = -1;
                //}

                //if (cmbGiderAltKategori.Text == "Yangın Vesaiti Masrafı" || cmbGiderAltKategori.Text == "Aydınlatma Masrafı" || cmbGiderAltKategori.Text == "Vergi ve Sigorta Masrafı vakıf ve avarız geliri" || cmbGiderAltKategori.Text == "Köy Borçları, İstikraz Taksit ve Faizleri" || cmbGiderAltKategori.Text == "Mahkeme ve Keşif Masrafları" || cmbGiderAltKategori.Text == "İstimlak Masrafları" || cmbGiderAltKategori.Text == "Umulmadık Masraflar")
                //{
                //    cmbDegisiklik.Visible = true;
                //    lblDegisiklik.Visible = true;

                //    lblTutar.Location = new Point(10, 174);
                //    txtTutar.Location = new Point(217, 172);

                //    DegisiklikDoldur();
                //}
                //else
                //{
                //    cmbDegisiklik.Visible = false;
                //    lblDegisiklik.Visible = false;

                //    lblTutar.Location = new Point(10, 139);
                //    txtTutar.Location = new Point(217, 134);

                //    cmbDegisiklik.SelectedIndex = 0;
                //}

                //if (cmbGiderAltKategori.SelectedItem != null)
                //{
                //    var selectedAltKategori = cmbGiderAltKategori.SelectedItem as GiderAltKategori;

                //    if (selectedAltKategori != null)
                //    {
                //        // Seçilen Alt Kategori'nin değerlerini yazdıralım (bu sadece bir debug işlemi)
                //        MessageBox.Show($"Selected Alt Kategori: {selectedAltKategori.GiderAltKategoriAdi}, ID: {selectedAltKategori.Id}");
                //    }
                //    else
                //    {
                //        MessageBox.Show("Lütfen geçerli bir Alt Gider Türü seçiniz!");
                //    }
                //}

                if (cmbGiderAltKategori.SelectedItem != null)
                {
                    var selectedAltKategori = cmbGiderAltKategori.SelectedItem as GiderAltKategori;

                    if (selectedAltKategori != null)
                    {
                        // Seçilen öğenin index numarasını alıp selectedIndex'e atayın
                        cmbGiderAltKategori.SelectedIndex = cmbGiderAltKategori.Items.IndexOf(selectedAltKategori);
                        MessageBox.Show($"Selected Alt Kategori: {selectedAltKategori.GiderAltKategoriAdi}, ID: {selectedAltKategori.Id}");
                    }
                    else
                    {
                        MessageBox.Show("Lütfen geçerli bir Alt Gider Türü seçiniz!");
                    }
                }
        }

        private void Temizle()
        {
            //cmbGiderKategori.SelectedIndex = -1;
            //cmbGiderAltKategori.SelectedIndex = -1;
            //cmbDegisiklik.Visible = false;
            //lblDegisiklik.Visible = false;
            //txtTutar.Text = string.Empty;

            //cmbGiderKategori.Focus();

            //// Degisiklik ComboBox'u sıfırlama
            //cmbDegisiklik.SelectedIndex = -1;

            cmbGiderKategori.SelectedIndex = 0;
            cmbGiderAltKategori.SelectedIndex = 0;
            cmbDegisiklik.Visible = false;
            lblDegisiklik.Visible = false;
            txtTutar.Text = "";

            cmbGiderKategori.Focus();

            cmbDegisiklik.SelectedIndex = -1;
        }
    }
}
