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
            //_gorevliManager = new GorevliManager(new EfGorevliDal());

            donemManager = new DonemManager(new EfDonemDal());
            gorevliManager = new GorevliManager(new EfGorevliDal());

            this.Load += new System.EventHandler(this.FrmKesinHesap2_Load);
        }

        //LABELLARIN BULUNDUĞU PANELLERDE ORTALANMASINI SAĞLIYOR
        private void AlignLabelsToRightInPanels()
        {
            for (int i = 1; i <= 143; i++)
            {
                string panelName = "g" + i;
                Panel panel = Controls.Find(panelName, true).FirstOrDefault() as Panel;
                if (panel != null)
                {
                    foreach (Control ctrl in panel.Controls)
                    {
                        if (ctrl is Label label)
                        {
                            // Etiketin içeriğine göre genişliğini ayarla
                            Size textSize = TextRenderer.MeasureText(label.Text, label.Font);
                            label.Width = textSize.Width;

                            // Etiketin konumunu panelin ortasına göre ayarla
                            int labelLeft = (panel.Width - label.Width) / 2;
                            label.Location = new Point(labelLeft, label.Location.Y);
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

            List<Gorevli> gorevliler = gorevliManager.GetListKoyIdAndDonemId(koyId, donemId);

            Gorevli muhtar = gorevliler.FirstOrDefault(g => g.UnvanId == 1);
            if (muhtar != null) lblMuhtar.Text = $"{muhtar.Adi} {muhtar.Soyadi}";

            Gorevli mudur = gorevliler.FirstOrDefault(g => g.UnvanId == 6);
            if (mudur != null) lblMudur.Text = $"{mudur.Adi} {mudur.Soyadi}";

            Gorevli imam = gorevliler.FirstOrDefault(g => g.UnvanId == 7);
            if (imam != null) lblImam.Text = $"{imam.Adi} {imam.Soyadi}";

            Gorevli aza1 = gorevliler.FirstOrDefault(g => g.UnvanId == 2);
            if (aza1 != null) lblAza1.Text = $"{aza1.Adi} {aza1.Soyadi}";

            Gorevli aza2 = gorevliler.FirstOrDefault(g => g.UnvanId == 3);
            if (aza2 != null) lblAza2.Text = $"{aza2.Adi} {aza2.Soyadi}";

            Gorevli aza3 = gorevliler.FirstOrDefault(g => g.UnvanId == 4);
            if (aza3 != null) lblAza3.Text = $"{aza3.Adi} {aza3.Soyadi}";

            Gorevli aza4 = gorevliler.FirstOrDefault(g => g.UnvanId == 5);
            if (aza4 != null) lblAza4.Text = $"{aza4.Adi} {aza4.Soyadi}";

            Gorevli katip = gorevliler.FirstOrDefault(g => g.UnvanId == 8);
            if (katip != null) lblKatip.Text = $"{katip.Adi} {katip.Soyadi}";
        }

        private void LoadGiderAltKategoriToplamlari()
        {
            try
            {
                GiderToplami(_seciliKoyIndex, _seciliDonemIndex, 1, lblOdenenYolKopru);
                GiderToplami(_seciliKoyIndex, _seciliDonemIndex, 2, lblOdenenKoyAkar);
                GiderToplami(_seciliKoyIndex, _seciliDonemIndex, 3, lblOdenenVesait);
                GiderToplami(_seciliKoyIndex, _seciliDonemIndex, 4, lblOdenenAydinlatma);
                GiderToplami(_seciliKoyIndex, _seciliDonemIndex, 5, lblOdenenMezarlik);
                GiderToplami(_seciliKoyIndex, _seciliDonemIndex, 6, lblOdenenVergi);
                GiderToplami(_seciliKoyIndex, _seciliDonemIndex, 7, lblOdenenKoyBorcu);
                GiderToplami(_seciliKoyIndex, _seciliDonemIndex, 8, lblOdenenMahkeme);
                GiderToplami(_seciliKoyIndex, _seciliDonemIndex, 9, lblOdenenIstimlak);
                GiderToplami(_seciliKoyIndex, _seciliDonemIndex, 10, lblOdenenUmulmadik);
                GiderToplami(_seciliKoyIndex, _seciliDonemIndex, 11, lblOdenenTurluMasraf);
                GiderToplami(_seciliKoyIndex, _seciliDonemIndex, 12, lblOdenenIlkogretim);
                GiderToplami(_seciliKoyIndex, _seciliDonemIndex, 13, lblOdenenKHGB);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gider verilerini yüklerken bir hata oluştu: " + ex.Message);
            }
        }

        // Gider Toplamı için Kullanıyorum
        private void GiderToplami(int koyId, byte donemId, byte giderAltKategoriId, Label label)
        {
            try
            {
                decimal toplamTutar = _giderManager.GiderAltKategoriToplami(koyId, donemId, giderAltKategoriId);
                // Label'e toplam tutarı yazdır
                label.Text = string.Format("{0:#,0.00}", toplamTutar);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gider Kategorisi {giderAltKategoriId} için toplam tutar yüklenirken bir hata oluştu: " + ex.Message);
                // label.Text = "0.00"; // Hata durumunda varsayılan değeri yazdır
            }
        }

        private void LoadGiderAltKategoriVerileri()
        {
            try
            {
                GiderAltKategoriLabellarAyarla(lblBKYolKopru, 19);
                GiderAltKategoriLabellarAyarla(lblBKKoyAkar, 20);
                GiderAltKategoriLabellarAyarla(lblBKVesait, 21);
                GiderAltKategoriLabellarAyarla(lblBKAydinlatma, 22);
                GiderAltKategoriLabellarAyarla(lblBKMezarlik, 23);
                GiderAltKategoriLabellarAyarla(lblBKVergi, 24);
                GiderAltKategoriLabellarAyarla(lblBKKoyBorcu, 25);
                GiderAltKategoriLabellarAyarla(lblBKMahkeme, 26);
                GiderAltKategoriLabellarAyarla(lblBKIstimlak, 27);
                GiderAltKategoriLabellarAyarla(lblBKUmulmadik, 28);
                GiderAltKategoriLabellarAyarla(lblBKTurluMasraf, 29);
                GiderAltKategoriLabellarAyarla(lblBKIlkogretim, 30);
                GiderAltKategoriLabellarAyarla(lblBKKHGB, 31);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Verileri yüklerken bir hata oluştu: " + ex.Message);
            }
        }

        private void GiderAltKategoriLabellarAyarla(Label label, byte giderAltKategoriId)
        {
            try
            {
                // Veritabanından belirtilen gelir kategorisi için veriyi al
                var tahminiButceGider = _tahminiButceGiderManager
                    .GetListByKoyIdAndDonemIdAndGiderAltKategoriId(_seciliKoyIndex, _seciliDonemIndex, giderAltKategoriId)
                    .FirstOrDefault();

                // Eğer veri bulunduysa, Label'e formatlı şekilde yazdır; yoksa "0.00" olarak ayarla
                if (tahminiButceGider != null)
                {
                    label.Text = string.Format("{0:#,0.00}", tahminiButceGider.Tutar);
                }
                else
                {
                    // label.Text = "0.00";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gelir Kategorisi {giderAltKategoriId} verilerini yüklerken bir hata oluştu: " + ex.Message);
            }
        }
        private void FrmKesinHesap2_Load(object sender, EventArgs e)
        {
            LoadGiderAltKategoriVerileri();
            LoadGiderAltKategoriToplamlari();
            TahminiGiderler();
            DegisiklikLabellarıYaz();
            dgvTahminiGiderler.Visible = false;
            AlanlariDoldur(_seciliKoyIndex, _seciliDonemIndex);

            lblBKBayindirlik.Text = lblBKBayindirlikToplami.Text;
            lblBKTurluIsler.Text = lblBKTurluIslerToplami.Text;
            lblOdenenBayindirlikToplami.Text = lblOdenenToplamBayindirlik.Text;
            lblOdenenTurluIslerToplami.Text = lblOdenenGenelToplami.Text;

            AlignLabelsToRightInPanels();
        }
    }
}
