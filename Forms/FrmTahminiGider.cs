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
            try
            {
                List<GiderKategori> giderKategorileri = giderKategoriManager.GetAll();
                cmbGiderKategori.Items.AddRange(giderKategorileri.ToArray());
                cmbGiderKategori.Items.Insert(0, "-Gider Türünü Seçiniz_");
                cmbGiderKategori.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Gider Türleri Getirilirken Hata Ouştu !");
                throw;
            }

        }

        private void DegisiklikDoldur()
        {
            List<Degisiklik> degisiklikler = degisiklikManager.GetAll();
            try
            {
                cmbDegisiklik.Items.AddRange(degisiklikler.ToArray());
                cmbDegisiklik.Items.Insert(0, "-Değişiklik Gerekiyorsa Seçiniz-");
                cmbDegisiklik.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Değişiklikler Getirilirken Hata Oluştu !");
                throw;
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
                    List<GiderAltKategori> secilenGiderinAltKategorileri = giderAltKategoriManager.GetByGiderKategoriId(secilenGiderKategori.Id);
                    cmbGiderAltKategori.Items.AddRange(secilenGiderinAltKategorileri.ToArray());

                    cmbDegisiklik.Visible = false;
                    lblDegisiklik.Visible = false;

                    ////Degisiklik görünmez olduğunda Tutar'ın lokasyonu
                    lblTutar.Location = new Point(10, 139);
                    txtTutar.Location = new Point(217, 134);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void pcBoxKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                // Gerekli alanların dolu olup olmadığını kontrol eder
                if (!string.IsNullOrEmpty(txtTutar.Text))
                {
                    // Yeni bir Gider nesnesi oluşturulur ve alanları doldurulur
                    TahminiButceGider yeniTahminiGider = new TahminiButceGider
                    {
                        KoyId = _seciliKoyIndex,
                        DonemId = _seciliDonemIndex,
                        GiderKategoriId = ((GiderKategori)cmbGiderKategori.SelectedItem).Id,
                        GiderAltKategoriId = ((GiderAltKategori)cmbGiderAltKategori.SelectedItem).Id,
                        Tutar = Convert.ToDecimal(txtTutar.Text),

                    };

                    // Yeni Gider nesnesi, GiderManager aracılığıyla veritabanına eklenir
                    tahminiButceGiderManager.Add(yeniTahminiGider);

                    // Kontroller temizlenir ve yeniden başlangıç durumuna getirilir
                    Temizle();
                    //AnaSayfaGuncelle();
                    //Giderler();
                    //HesaplaVeYazdir();
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

        private void cmbGiderAltKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGiderAltKategori.Text == "Yangın Vesaiti Masrafı" || cmbGiderAltKategori.Text == "Aydınlatma Masrafı" || cmbGiderAltKategori.Text == "Vergi ve Sigorta Masrafı vakıf ve avarız geliri" || cmbGiderAltKategori.Text == "Köy Borçları, İstikraz Taksit ve Faizleri"|| cmbGiderAltKategori.Text == "Mahkeme ve Keşif Masrafları" || cmbGiderAltKategori.Text == "İstimlak Masrafları" || cmbGiderAltKategori.Text == "Umulmadık Masraflar")
            {
                cmbDegisiklik.Visible = true;
                lblDegisiklik.Visible = true;

                ////Degisiklik görünür olduğunda Tutar'ın lokasyonu
                lblTutar.Location = new Point(10, 174);
                txtTutar.Location = new Point(217, 172);

                DegisiklikDoldur();
            }
            else
            {
                cmbDegisiklik.Visible = false;
                lblDegisiklik.Visible = false;

                ////Degisiklik görünmez olduğunda Tutar'ın lokasyonu
                lblTutar.Location = new Point(10, 139);
                txtTutar.Location = new Point(217, 134);

                cmbDegisiklik.SelectedIndex = -1;
            }
        }

        private void Temizle()
        {
            cmbGiderKategori.SelectedIndex = 0;
            cmbGiderAltKategori.SelectedIndex = 0;
            cmbDegisiklik.Visible = false;
            lblDegisiklik.Visible = false;
            txtTutar.Text = string.Empty;

            cmbGiderKategori.Focus();

            // Degisiklik ComboBox'u sıfırlama
            cmbDegisiklik.SelectedIndex = -1;
        }
    }
}
