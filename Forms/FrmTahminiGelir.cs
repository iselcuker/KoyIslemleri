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

namespace Forms
{
    public partial class FrmTahminiGelir : Form
    {
        GelirKategoriManager gelirKategoriManager;
        DegisiklikManager degisiklikManager;
        TahminiButceGelirManager tahminiButceGelirManager;
        KoyManager koyManager;
        DonemManager donemManager;
        //AnaSayfada comboboxlardan yapılan seçimlerin index lerini getirmek için
        int _seciliKoyIndex;
        byte _seciliDonemIndex;

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
                MessageBox.Show("Gelir Türü Getirilirken Hata oluştur !");
                throw;
            }
        }

        private void DegisiklikDoldur()
        {
            List<Degisiklik> degisiklikler = degisiklikManager.GetAll();
            try
            {
                cmbDegisiklik.Items.AddRange(degisiklikler.ToArray());
                cmbDegisiklik.Visible = true;
                lblDegisiklik.Visible = true;
                cmbDegisiklik.Items.Insert(0, "-Değişiklik Gerekiyorsa Seçiniz-");
                cmbDegisiklik.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Değişiklikler Getirilirken Hata Oluştu !");
                throw;
            }
        }

        private void FrmTahminiGelir_Load(object sender, EventArgs e)
        {
            cmbDegisiklik.Visible = false;
            lblDegisiklik.Visible = false;

            GelirKategoriDoldur();
            TahminiGelirler();

        }

        private void cmbGelirKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGelirKategori.Text == "Hasılat" || cmbGelirKategori.Text == "Resim ve harçlar" || cmbGelirKategori.Text == "Köy vakıf ve avarız geliri" || cmbGelirKategori.Text == "İstikrazlar")
            {
                cmbDegisiklik.Visible = true;
                lblDegisiklik.Visible = true;
                DegisiklikDoldur();
            }
        }

        private void pcBoxKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtTutar.Text) && !string.IsNullOrEmpty(cmbGelirKategori.Text) )
                {
                    TahminiButceGelir yeniTahminiGelir = new TahminiButceGelir();
                    yeniTahminiGelir.KoyId = _seciliKoyIndex;
                    yeniTahminiGelir.DonemId = _seciliDonemIndex;
                    yeniTahminiGelir.GelirKategoriId = (cmbGelirKategori.SelectedItem as GelirKategori).Id;//cmbGelirKategori'den seçilen öge GelirKategori türüne dönüştürülür, yoksa null değeri alır.
                    yeniTahminiGelir.DegisiklikId = (cmbDegisiklik.SelectedItem as Degisiklik).Id;
                    yeniTahminiGelir.TahimiGelirTutari = Convert.ToDecimal(txtTutar.Text);
                    tahminiButceGelirManager.Add(yeniTahminiGelir);

                    //Gelirler();
                    Temizle();
                    TahminiGelirler();

                    //ToplamGelir();
                    //HesaplaVeYazdir();
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
            cmbDegisiklik.Visible = false;
            lblDegisiklik.Visible=false;
            txtTutar.Text = string.Empty;
            cmbGelirKategori.Focus();
        }
         
        //Gelirleri DatagridView'e yükleyecek metot
        private void TahminiGelirler()
        {
            try
            {
                // Tahmini gelirleri DataGridView'e yükler
                dgvTahminiGelirler.DataSource = tahminiButceGelirManager.GetTahminiButceGelirDetails(_seciliKoyIndex, _seciliDonemIndex);
                dgvTahminiGelirler.Columns["TahminiButceGelirId"].Visible = false;
                dgvTahminiGelirler.Columns["KoyAdi"].Visible = false;
                dgvTahminiGelirler.Columns["DonemAdi"].Visible = false;
                dgvTahminiGelirler.Columns["KoyId"].Visible = false;
                dgvTahminiGelirler.Columns["DonemId"].Visible = false;
                dgvTahminiGelirler.Columns["GelirKategoriId"].Visible = false;
                dgvTahminiGelirler.Columns["DegisiklikId"].Visible = false;
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
    }
}
