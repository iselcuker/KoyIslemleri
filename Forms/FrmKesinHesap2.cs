using Business.Concrete;
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
    public partial class FrmKesinHesap2 : Form
    {
        IlceManager ilceManager;
        KoyManager koyManager;
        DonemManager donemManager;
        GorevliManager gorevliManager;

        //AnaSayfada comboboxlardan yapılan seçimlerin index lerini getirmek için
        int _seciliKoyIndex;
        byte _seciliDonemIndex;
        byte _seciliIlceIndex;
        private GelirManager _gelirManager;
        private GiderManager _giderManager;
        private TahminiButceGelirManager _tahminiButceGelirManager;
        private TahminiButceGiderManager _tahminiButceGiderManager;
        private GorevliManager _gorevliManager;

        public FrmKesinHesap2(int seciliKoyIndex, byte seciliDonemIndex, byte seciliIlceIndex)
        {
            InitializeComponent();
            this.BackColor = Color.White; // Formun arka plan rengini beyaz yap
            //Degisiklik labelları için
            this.Load += new System.EventHandler(this.FrmKesinHesap2_Load);

            _seciliKoyIndex = seciliKoyIndex;
            _seciliDonemIndex = seciliDonemIndex;
            _seciliIlceIndex = seciliIlceIndex;

            IlceManager _ilceManager = new IlceManager(new EfIlceDal());
            ilceManager = _ilceManager;

            KoyManager _koyManager = new KoyManager(new EfKoyDal());
            koyManager = _koyManager;

            _gelirManager = new GelirManager(new EfGelirDal()); // Burada uygun IGelirDal implementasyonunu geçmelisiniz
            _giderManager = new GiderManager(new EfGiderDal());
            _tahminiButceGelirManager = new TahminiButceGelirManager(new EfTahminiButceGelirDal());
            _tahminiButceGiderManager = new TahminiButceGiderManager(new EfTahminiButceGiderDal());
            _gorevliManager = new GorevliManager(new EfGorevliDal());

            donemManager = new DonemManager(new EfDonemDal());
        }

        private void AlignLabelsToRightInPanels()
        {
            for (int i = 1; i <= 143; i++)
            {
                string panelName = "p" + i;
                Panel panel = Controls.Find(panelName, true).FirstOrDefault() as Panel;
                if (panel != null)
                {
                    foreach (Control ctrl in panel.Controls)
                    {
                        if (ctrl is Label label)
                        {
                            int labelRight = panel.Width - label.Width - label.Margin.Right;
                            label.Location = new Point(labelRight, label.Location.Y);
                        }
                    }
                }
            }
        }

        public void DegisiklikLabellarıYaz()
        {
            // DataGridView satırlarını dolaş
            foreach (DataGridViewRow row in dgvTahminiGiderler.Rows)
            {
                // GelirKategoriAdi ve DegisiklikAdi sütunlarının değerlerini al
                var giderAltKategoriAdi = row.Cells["GiderAltKategoriAdi"].Value?.ToString();
                var degisiklikAdi = row.Cells["DegisiklikAdi"].Value?.ToString();

                //// Debug ile değerleri kontrol edin
                //Debug.WriteLine($"GelirKategoriAdi: {gelirKategoriAdi}, DegisiklikAdi: {degisiklikAdi}");

                // Koşullara göre label'ların Text değerlerini ayarla
                if (!string.IsNullOrEmpty(giderAltKategoriAdi) && giderAltKategoriAdi == "Yangın Vesaiti Masrafı")
                {
                    lblYanginDegisiklik.Text = degisiklikAdi;
                }
                else if (!string.IsNullOrEmpty(giderAltKategoriAdi) && giderAltKategoriAdi == "Aydınlatma Masrafı")
                {
                    lblAydinlatmaDegisiklik.Text = degisiklikAdi;
                }
                else if (!string.IsNullOrEmpty(giderAltKategoriAdi) && giderAltKategoriAdi == "Vergi ve Sigorta Masrafı")
                {
                    lblVergiDegisiklik.Text = degisiklikAdi;
                }
                else if (!string.IsNullOrEmpty(giderAltKategoriAdi) && giderAltKategoriAdi == "İstimlak Masrafları")
                {
                    lblIstimlakDegisiklik.Text = degisiklikAdi;
                }
                else if (!string.IsNullOrEmpty(giderAltKategoriAdi) && giderAltKategoriAdi == "Umulmadık Masraflar")
                {
                    lblUmulmadikDegisiklik.Text = degisiklikAdi;
                }
            }
        }

        public void TahminiGiderler()
        {
            try
            {
                // Tahmini gelirleri DataGridView'e yükler
                var tahminiButceGiderleri = _tahminiButceGiderManager.GetTahminiButceGiderDetails(_seciliKoyIndex, _seciliDonemIndex);

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
            }
            catch (Exception ex)
            {
                // Hata oluştuğunda kullanıcıya bilgi verir
                MessageBox.Show("Veri yüklenirken bir hata oluştu: " + ex.Message);
            }
        }

        public void AlanlariDoldur(int koyId, byte donemId)
        {
            Donem secilenDonem = donemManager.GetById(donemId);
            lblGelirYil.Text = secilenDonem.DonemAdi.ToString();
            lblGiderYil.Text = secilenDonem.DonemAdi.ToString();
        }
        private void FrmKesinHesap2_Load(object sender, EventArgs e)
        {
            AlignLabelsToRightInPanels();
            TahminiGiderler();
            DegisiklikLabellarıYaz();
            dgvTahminiGiderler.Visible = false;
            AlanlariDoldur(_seciliKoyIndex, _seciliDonemIndex);
        }
    }
}
