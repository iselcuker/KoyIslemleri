using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
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
        private FrmKesinHesap1 frmKesinHesap1;

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
        private void GorevliPaneleOrtala()
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

        private void RakamlariPanelinSaginaYasla()
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
                            // Etiketin içeriğine göre genişliğini ayarla
                            Size textSize = TextRenderer.MeasureText(label.Text, label.Font);
                            label.Width = textSize.Width;

                            // Etiketi panelin sağ kenarına yasla
                            int labelLeft = panel.Width - label.Width;
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
                GiderToplami(_seciliKoyIndex, _seciliDonemIndex, 19, lblOdenenYolKopru);
                GiderToplami(_seciliKoyIndex, _seciliDonemIndex, 20, lblOdenenKoyAkar);
                GiderToplami(_seciliKoyIndex, _seciliDonemIndex, 21, lblOdenenVesait);
                GiderToplami(_seciliKoyIndex, _seciliDonemIndex, 22, lblOdenenAydinlatma);
                GiderToplami(_seciliKoyIndex, _seciliDonemIndex, 23, lblOdenenMezarlik);
                GiderToplami(_seciliKoyIndex, _seciliDonemIndex, 24, lblOdenenVergi);
                GiderToplami(_seciliKoyIndex, _seciliDonemIndex, 25, lblOdenenKoyBorcu);
                GiderToplami(_seciliKoyIndex, _seciliDonemIndex, 26, lblOdenenMahkeme);
                GiderToplami(_seciliKoyIndex, _seciliDonemIndex, 27, lblOdenenIstimlak);
                GiderToplami(_seciliKoyIndex, _seciliDonemIndex, 28, lblOdenenUmulmadik);
                GiderToplami(_seciliKoyIndex, _seciliDonemIndex, 29, lblOdenenTurluMasraf);
                GiderToplami(_seciliKoyIndex, _seciliDonemIndex, 30, lblOdenenIlkogretim);
                GiderToplami(_seciliKoyIndex, _seciliDonemIndex, 31, lblOdenenKHGB);
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

                GiderAltKategoriLabellarAyarla(lblBKVergi, 25);
                GiderAltKategoriLabellarAyarla(lblBKKoyBorcu, 26);
                GiderAltKategoriLabellarAyarla(lblBKMahkeme, 27);
                GiderAltKategoriLabellarAyarla(lblBKIstimlak, 28);
                GiderAltKategoriLabellarAyarla(lblBKUmulmadik, 29);
                GiderAltKategoriLabellarAyarla(lblBKTurluMasraf, 24);
                GiderAltKategoriLabellarAyarla(lblBKIlkogretim, 30);
                GiderAltKategoriLabellarAyarla(lblBKKHGB, 31);

                // Label'ların Text değerlerini decimal türüne dönüştür ve topla
                decimal toplamBayindirlik = 0;
                toplamBayindirlik += ParseDecimalFromLabel(lblBKYolKopru);
                toplamBayindirlik += ParseDecimalFromLabel(lblBKKoyAkar);
                toplamBayindirlik += ParseDecimalFromLabel(lblBKVesait);
                toplamBayindirlik += ParseDecimalFromLabel(lblBKAydinlatma);
                toplamBayindirlik += ParseDecimalFromLabel(lblBKMezarlik);

                decimal toplamTurluIsler = 0;

                toplamTurluIsler += ParseDecimalFromLabel(lblBKVergi);
                toplamTurluIsler += ParseDecimalFromLabel(lblBKKoyBorcu);
                toplamTurluIsler += ParseDecimalFromLabel(lblBKMahkeme);
                toplamTurluIsler += ParseDecimalFromLabel(lblBKIstimlak);
                toplamTurluIsler += ParseDecimalFromLabel(lblBKUmulmadik);
                toplamTurluIsler += ParseDecimalFromLabel(lblBKTurluMasraf);
                toplamTurluIsler += ParseDecimalFromLabel(lblBKIlkogretim);
                toplamTurluIsler += ParseDecimalFromLabel(lblBKKHGB);

                // Toplamı lblBKResimHarcToplami label'ına yazdır
                lblBKBayindirlikToplami.Text = string.Format("{0:#,0.00}", toplamBayindirlik);
                lblBKTurluIslerToplami.Text = string.Format("{0:#,0.00}", toplamTurluIsler);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Verileri yüklerken bir hata oluştu: " + ex.Message);
            }
        }

        private decimal ParseDecimalFromLabel(Label label)
        {
            if (decimal.TryParse(label.Text, out decimal value))
            {
                return value;
            }
            return 0m;
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

        public void YolKopruHesap()
        {
            try
            {
                decimal bkYolKopru = 0;
                decimal munzamYolKopru = 0;
                decimal tahakkukYolKopru = 0;
                decimal odenenYolKopru = 0;
                decimal iptalYolKopru = 0;

                if (!decimal.TryParse(lblOdenenYolKopru.Text, NumberStyles.Number, new CultureInfo("tr-TR"), out odenenYolKopru))
                {
                    MessageBox.Show("lblOdenenYolKopru.Text geçerli bir sayı değil: " + lblOdenenYolKopru.Text);
                    return;
                }

                if (!decimal.TryParse(lblBKYolKopru.Text, NumberStyles.Number, new CultureInfo("tr-TR"), out bkYolKopru))
                {
                    MessageBox.Show("lblBKYolKopru.Text geçerli bir sayı değil: " + lblBKYolKopru.Text);
                    return;
                }

                if (bkYolKopru > odenenYolKopru)
                {
                    lblMunzamYolKopru.Text = "0";
                }
                else
                {
                    munzamYolKopru = odenenYolKopru - bkYolKopru;
                    lblMunzamYolKopru.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", munzamYolKopru);
                }

                tahakkukYolKopru = bkYolKopru + munzamYolKopru;
                lblTahakkukYolKopru.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", tahakkukYolKopru);

                iptalYolKopru = tahakkukYolKopru - odenenYolKopru;
                lblIptalYolKopru.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", iptalYolKopru);

                // Visible ayarlarını kontrol et
                lblMunzamYolKopru.Visible = !IsZeroOrEmpty(lblMunzamYolKopru.Text);
                lblTahakkukYolKopru.Visible = !IsZeroOrEmpty(lblTahakkukYolKopru.Text);
                lblIptalYolKopru.Visible = !IsZeroOrEmpty(lblIptalYolKopru.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bütçeye Konan Bayındırlık  Toplamı yapılırken bir hata oluştu: " + ex.Message);
            }
        }

        public void KoyAkarHesap()
        {
            try
            {
                decimal bkKoyAkar = 0;
                decimal munzamKoyAkar = 0;
                decimal tahakkukKoyAkar = 0;
                decimal odenenKoyAkar = 0;
                decimal iptalKoyAkar = 0;

                if (!decimal.TryParse(lblOdenenKoyAkar.Text, NumberStyles.Number, new CultureInfo("tr-TR"), out odenenKoyAkar))
                {
                    MessageBox.Show("lblOdenenKoyAkar.Text geçerli bir sayı değil: " + lblOdenenKoyAkar.Text);
                    return;
                }

                if (!decimal.TryParse(lblBKKoyAkar.Text, NumberStyles.Number, new CultureInfo("tr-TR"), out bkKoyAkar))
                {
                    MessageBox.Show("lblBKKoyAkar.Text geçerli bir sayı değil: " + lblBKKoyAkar.Text);
                    return;
                }

                if (bkKoyAkar > odenenKoyAkar)
                {
                    lblMunzamKoyAkar.Text = "0";
                }
                else
                {
                    munzamKoyAkar = odenenKoyAkar - bkKoyAkar;
                    lblMunzamKoyAkar.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", munzamKoyAkar);
                }

                tahakkukKoyAkar = bkKoyAkar + munzamKoyAkar;
                lblTahakkukKoyAkar.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", tahakkukKoyAkar);

                iptalKoyAkar = tahakkukKoyAkar - odenenKoyAkar;
                lblIptalKoyAkar.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", iptalKoyAkar);

                // Visible ayarlarını kontrol et
                lblMunzamKoyAkar.Visible = !IsZeroOrEmpty(lblMunzamKoyAkar.Text);
                lblTahakkukKoyAkar.Visible = !IsZeroOrEmpty(lblTahakkukKoyAkar.Text);
                lblIptalKoyAkar.Visible = !IsZeroOrEmpty(lblIptalKoyAkar.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Köy Akar Hesabı yapılırken bir hata oluştu: " + ex.Message);
            }
        }

        public void VesaitHesap()
        {
            try
            {
                decimal bkVesait = 0;
                decimal munzamVesait = 0;
                decimal tahakkukVesait = 0;
                decimal odenenVesait = 0;
                decimal iptalVesait = 0;

                if (!decimal.TryParse(lblOdenenVesait.Text, NumberStyles.Number, new CultureInfo("tr-TR"), out odenenVesait))
                {
                    MessageBox.Show("lblOdenenVesait.Text geçerli bir sayı değil: " + lblOdenenVesait.Text);
                    return;
                }

                if (!decimal.TryParse(lblBKVesait.Text, NumberStyles.Number, new CultureInfo("tr-TR"), out bkVesait))
                {
                    MessageBox.Show("lblBKVesait.Text geçerli bir sayı değil: " + lblBKVesait.Text);
                    return;
                }

                if (bkVesait > odenenVesait)
                {
                    lblMunzamVesait.Text = "0";
                }
                else
                {
                    munzamVesait = odenenVesait - bkVesait;
                    lblMunzamVesait.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", munzamVesait);
                }

                tahakkukVesait = bkVesait + munzamVesait;
                lblTahakkukVesait.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", tahakkukVesait);

                iptalVesait = tahakkukVesait - odenenVesait;
                lblIptalVesait.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", iptalVesait);

                // Visible ayarlarını kontrol et
                lblMunzamVesait.Visible = !IsZeroOrEmpty(lblMunzamVesait.Text);
                lblTahakkukVesait.Visible = !IsZeroOrEmpty(lblTahakkukVesait.Text);
                lblIptalVesait.Visible = !IsZeroOrEmpty(lblIptalVesait.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vesait Hesabı yapılırken bir hata oluştu: " + ex.Message);
            }
        }

        public void AydinlatmaHesap()
        {
            try
            {
                decimal bkAydinlatma = 0;
                decimal munzamAydinlatma = 0;
                decimal tahakkukAydinlatma = 0;
                decimal odenenAydinlatma = 0;
                decimal iptalAydinlatma = 0;

                if (!decimal.TryParse(lblOdenenAydinlatma.Text, NumberStyles.Number, new CultureInfo("tr-TR"), out odenenAydinlatma))
                {
                    MessageBox.Show("lblOdenenAydinlatma.Text geçerli bir sayı değil: " + lblOdenenAydinlatma.Text);
                    return;
                }

                if (!decimal.TryParse(lblBKAydinlatma.Text, NumberStyles.Number, new CultureInfo("tr-TR"), out bkAydinlatma))
                {
                    MessageBox.Show("lblBKAydinlatma.Text geçerli bir sayı değil: " + lblBKAydinlatma.Text);
                    return;
                }

                if (bkAydinlatma > odenenAydinlatma)
                {
                    lblMunzamAydinlatma.Text = "0";
                }
                else
                {
                    munzamAydinlatma = odenenAydinlatma - bkAydinlatma;
                    lblMunzamAydinlatma.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", munzamAydinlatma);
                }

                tahakkukAydinlatma = bkAydinlatma + munzamAydinlatma;
                lblTahakkukAydinlatma.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", tahakkukAydinlatma);

                iptalAydinlatma = tahakkukAydinlatma - odenenAydinlatma;
                lblIptalAydinlatma.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", iptalAydinlatma);

                // Visible ayarlarını kontrol et
                lblMunzamAydinlatma.Visible = !IsZeroOrEmpty(lblMunzamAydinlatma.Text);
                lblTahakkukAydinlatma.Visible = !IsZeroOrEmpty(lblTahakkukAydinlatma.Text);
                lblIptalAydinlatma.Visible = !IsZeroOrEmpty(lblIptalAydinlatma.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Hesabı yapılırken bir hata oluştu: " + ex.Message);
            }
        }

        public void MezarlikHesap()
        {
            try
            {
                decimal bkMezarlik = 0;
                decimal munzamMezarlik = 0;
                decimal tahakkukMezarlik = 0;
                decimal odenenMezarlik = 0;
                decimal iptalMezarlik = 0;

                if (!decimal.TryParse(lblOdenenMezarlik.Text, NumberStyles.Number, new CultureInfo("tr-TR"), out odenenMezarlik))
                {
                    MessageBox.Show("lblOdenenMezarlik.Text geçerli bir sayı değil: " + lblOdenenMezarlik.Text);
                    return;
                }

                if (!decimal.TryParse(lblBKMezarlik.Text, NumberStyles.Number, new CultureInfo("tr-TR"), out bkMezarlik))
                {
                    MessageBox.Show("lblBKMezarlik.Text geçerli bir sayı değil: " + lblBKMezarlik.Text);
                    return;
                }

                if (bkMezarlik > odenenMezarlik)
                {
                    lblMunzamMezarlik.Text = "0";
                }
                else
                {
                    munzamMezarlik = odenenMezarlik - bkMezarlik;
                    lblMunzamMezarlik.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", munzamMezarlik);
                }

                tahakkukMezarlik = bkMezarlik + munzamMezarlik;
                lblTahakkukMezarlik.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", tahakkukMezarlik);

                iptalMezarlik = tahakkukMezarlik - odenenMezarlik;
                lblIptalMezarlik.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", iptalMezarlik);

                // Visible ayarlarını kontrol et
                lblMunzamMezarlik.Visible = !IsZeroOrEmpty(lblMunzamMezarlik.Text);
                lblTahakkukMezarlik.Visible = !IsZeroOrEmpty(lblTahakkukMezarlik.Text);
                lblIptalMezarlik.Visible = !IsZeroOrEmpty(lblIptalMezarlik.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mezarlık Hesabı yapılırken bir hata oluştu: " + ex.Message);
            }
        }

        public void VergiHesap()
        {
            try
            {
                decimal bkVergi = 0;
                decimal munzamVergi = 0;
                decimal tahakkukVergi = 0;
                decimal odenenVergi = 0;
                decimal iptalVergi = 0;

                if (!decimal.TryParse(lblOdenenVergi.Text, NumberStyles.Number, new CultureInfo("tr-TR"), out odenenVergi))
                {
                    MessageBox.Show("lblOdenenVergi.Text geçerli bir sayı değil: " + lblOdenenVergi.Text);
                    return;
                }

                if (!decimal.TryParse(lblBKVergi.Text, NumberStyles.Number, new CultureInfo("tr-TR"), out bkVergi))
                {
                    MessageBox.Show("lblBKVergi.Text geçerli bir sayı değil: " + lblBKVergi.Text);
                    return;
                }

                if (bkVergi > odenenVergi)
                {
                    lblMunzamVergi.Text = "0";
                }
                else
                {
                    munzamVergi = odenenVergi - bkVergi;
                    lblMunzamVergi.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", munzamVergi);
                }

                tahakkukVergi = bkVergi + munzamVergi;
                lblTahakkukVergi.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", tahakkukVergi);

                iptalVergi = tahakkukVergi - odenenVergi;
                lblIptalVergi.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", iptalVergi);

                // Visible ayarlarını kontrol et
                lblMunzamVergi.Visible = !IsZeroOrEmpty(lblMunzamVergi.Text);
                lblTahakkukVergi.Visible = !IsZeroOrEmpty(lblTahakkukVergi.Text);
                lblIptalVergi.Visible = !IsZeroOrEmpty(lblIptalVergi.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vergi Hesabı yapılırken bir hata oluştu: " + ex.Message);
            }
        }

        public void KoyBorcuHesap()
        {
            try
            {
                decimal bkKoyBorcu = 0;
                decimal munzamKoyBorcu = 0;
                decimal tahakkukKoyBorcu = 0;
                decimal odenenKoyBorcu = 0;
                decimal iptalKoyBorcu = 0;

                if (!decimal.TryParse(lblOdenenKoyBorcu.Text, NumberStyles.Number, new CultureInfo("tr-TR"), out odenenKoyBorcu))
                {
                    MessageBox.Show("lblOdenenKoyBorcu.Text geçerli bir sayı değil: " + lblOdenenKoyBorcu.Text);
                    return;
                }

                if (!decimal.TryParse(lblBKKoyBorcu.Text, NumberStyles.Number, new CultureInfo("tr-TR"), out bkKoyBorcu))
                {
                    MessageBox.Show("lblBKKoyBorcu.Text geçerli bir sayı değil: " + lblBKKoyBorcu.Text);
                    return;
                }

                if (bkKoyBorcu > odenenKoyBorcu)
                {
                    lblMunzamKoyBorcu.Text = "0";
                }
                else
                {
                    munzamKoyBorcu = odenenKoyBorcu - bkKoyBorcu;
                    lblMunzamKoyBorcu.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", munzamKoyBorcu);
                }

                tahakkukKoyBorcu = bkKoyBorcu + munzamKoyBorcu;
                lblTahakkukKoyBorcu.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", tahakkukKoyBorcu);

                iptalKoyBorcu = tahakkukKoyBorcu - odenenKoyBorcu;
                lblIptalKoyBorcu.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", iptalKoyBorcu);

                // Visible ayarlarını kontrol et
                lblMunzamKoyBorcu.Visible = !IsZeroOrEmpty(lblMunzamKoyBorcu.Text);
                lblTahakkukKoyBorcu.Visible = !IsZeroOrEmpty(lblTahakkukKoyBorcu.Text);
                lblIptalKoyBorcu.Visible = !IsZeroOrEmpty(lblIptalKoyBorcu.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Köy Borcu Hesabı yapılırken bir hata oluştu: " + ex.Message);
            }
        }

        public void MahkemeHesap()
        {
            try
            {
                decimal bkMahkeme = 0;
                decimal munzamMahkeme = 0;
                decimal tahakkukMahkeme = 0;
                decimal odenenMahkeme = 0;
                decimal iptalMahkeme = 0;

                if (!decimal.TryParse(lblOdenenMahkeme.Text, NumberStyles.Number, new CultureInfo("tr-TR"), out odenenMahkeme))
                {
                    MessageBox.Show("lblOdenenMahkeme.Text geçerli bir sayı değil: " + lblOdenenMahkeme.Text);
                    return;
                }

                if (!decimal.TryParse(lblBKMahkeme.Text, NumberStyles.Number, new CultureInfo("tr-TR"), out bkMahkeme))
                {
                    MessageBox.Show("lblBKMahkeme.Text geçerli bir sayı değil: " + lblBKMahkeme.Text);
                    return;
                }

                if (bkMahkeme > odenenMahkeme)
                {
                    lblMunzamMahkeme.Text = "0";
                }
                else
                {
                    munzamMahkeme = odenenMahkeme - bkMahkeme;
                    lblMunzamMahkeme.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", munzamMahkeme);
                }

                tahakkukMahkeme = bkMahkeme + munzamMahkeme;
                lblTahakkukMahkeme.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", tahakkukMahkeme);

                iptalMahkeme = tahakkukMahkeme - odenenMahkeme;
                lblIptalMahkeme.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", iptalMahkeme);

                // Visible ayarlarını kontrol et
                lblMunzamMahkeme.Visible = !IsZeroOrEmpty(lblMunzamMahkeme.Text);
                lblTahakkukMahkeme.Visible = !IsZeroOrEmpty(lblTahakkukMahkeme.Text);
                lblIptalMahkeme.Visible = !IsZeroOrEmpty(lblIptalMahkeme.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mahkeme Hesabı yapılırken bir hata oluştu: " + ex.Message);
            }
        }

        public void IstimlakHesap()
        {
            try
            {
                decimal bkIstimlak = 0;
                decimal munzamIstimlak = 0;
                decimal tahakkukIstimlak = 0;
                decimal odenenIstimlak = 0;
                decimal iptalIstimlak = 0;

                if (!decimal.TryParse(lblOdenenIstimlak.Text, NumberStyles.Number, new CultureInfo("tr-TR"), out odenenIstimlak))
                {
                    MessageBox.Show("lblOdenenIstimlak.Text geçerli bir sayı değil: " + lblOdenenIstimlak.Text);
                    return;
                }

                if (!decimal.TryParse(lblBKIstimlak.Text, NumberStyles.Number, new CultureInfo("tr-TR"), out bkIstimlak))
                {
                    MessageBox.Show("lblBKIstimlak.Text geçerli bir sayı değil: " + lblBKIstimlak.Text);
                    return;
                }

                if (bkIstimlak > odenenIstimlak)
                {
                    lblMunzamIstimlak.Text = "0";
                }
                else
                {
                    munzamIstimlak = odenenIstimlak - bkIstimlak;
                    lblMunzamIstimlak.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", munzamIstimlak);
                }

                tahakkukIstimlak = bkIstimlak + munzamIstimlak;
                lblTahakkukIstimlak.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", tahakkukIstimlak);

                iptalIstimlak = tahakkukIstimlak - odenenIstimlak;
                lblIptalIstimlak.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", iptalIstimlak);

                // Visible ayarlarını kontrol et
                lblMunzamIstimlak.Visible = !IsZeroOrEmpty(lblMunzamIstimlak.Text);
                lblTahakkukIstimlak.Visible = !IsZeroOrEmpty(lblTahakkukIstimlak.Text);
                lblIptalIstimlak.Visible = !IsZeroOrEmpty(lblIptalIstimlak.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Istimlak Hesabı yapılırken bir hata oluştu: " + ex.Message);
            }
        }

        public void UmulmadikHesap()
        {
            try
            {
                decimal bkUmulmadik = 0;
                decimal munzamUmulmadik = 0;
                decimal tahakkukUmulmadik = 0;
                decimal odenenUmulmadik = 0;
                decimal iptalUmulmadik = 0;

                if (!decimal.TryParse(lblOdenenUmulmadik.Text, NumberStyles.Number, new CultureInfo("tr-TR"), out odenenUmulmadik))
                {
                    MessageBox.Show("lblOdenenUmulmadik.Text geçerli bir sayı değil: " + lblOdenenUmulmadik.Text);
                    return;
                }

                if (!decimal.TryParse(lblBKUmulmadik.Text, NumberStyles.Number, new CultureInfo("tr-TR"), out bkUmulmadik))
                {
                    MessageBox.Show("lblBKUmulmadik.Text geçerli bir sayı değil: " + lblBKUmulmadik.Text);
                    return;
                }

                if (bkUmulmadik > odenenUmulmadik)
                {
                    lblMunzamUmulmadik.Text = "0";
                }
                else
                {
                    munzamUmulmadik = odenenUmulmadik - bkUmulmadik;
                    lblMunzamUmulmadik.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", munzamUmulmadik);
                }

                tahakkukUmulmadik = bkUmulmadik + munzamUmulmadik;
                lblTahakkukUmulmadik.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", tahakkukUmulmadik);

                iptalUmulmadik = tahakkukUmulmadik - odenenUmulmadik;
                lblIptalUmulmadik.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", iptalUmulmadik);

                // Visible ayarlarını kontrol et
                lblMunzamUmulmadik.Visible = !IsZeroOrEmpty(lblMunzamUmulmadik.Text);
                lblTahakkukUmulmadik.Visible = !IsZeroOrEmpty(lblTahakkukUmulmadik.Text);
                lblIptalUmulmadik.Visible = !IsZeroOrEmpty(lblIptalUmulmadik.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Umulmadık Masraflar Hesabı yapılırken bir hata oluştu: " + ex.Message);
            }
        }

        public void TurluMasrafHesap()
        {
            try
            {
                decimal bkTurluMasraf = 0;
                decimal munzamTurluMasraf = 0;
                decimal tahakkukTurluMasraf = 0;
                decimal odenenTurluMasraf = 0;
                decimal iptalTurluMasraf = 0;

                if (!decimal.TryParse(lblOdenenTurluMasraf.Text, NumberStyles.Number, new CultureInfo("tr-TR"), out odenenTurluMasraf))
                {
                    MessageBox.Show("lblOdenenTurluMasraf.Text geçerli bir sayı değil: " + lblOdenenTurluMasraf.Text);
                    return;
                }

                if (!decimal.TryParse(lblBKTurluMasraf.Text, NumberStyles.Number, new CultureInfo("tr-TR"), out bkTurluMasraf))
                {
                    MessageBox.Show("lblBKTurluMasraf.Text geçerli bir sayı değil: " + lblBKTurluMasraf.Text);
                    return;
                }

                if (bkTurluMasraf > odenenTurluMasraf)
                {
                    lblMunzamTurluMasraf.Text = "0";
                }
                else
                {
                    munzamTurluMasraf = odenenTurluMasraf - bkTurluMasraf;
                    lblMunzamTurluMasraf.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", munzamTurluMasraf);
                }

                tahakkukTurluMasraf = bkTurluMasraf + munzamTurluMasraf;
                lblTahakkukTurluMasraf.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", tahakkukTurluMasraf);

                iptalTurluMasraf = tahakkukTurluMasraf - odenenTurluMasraf;
                lblIptalTurluMasraf.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", iptalTurluMasraf);

                // Visible ayarlarını kontrol et
                lblMunzamTurluMasraf.Visible = !IsZeroOrEmpty(lblMunzamTurluMasraf.Text);
                lblTahakkukTurluMasraf.Visible = !IsZeroOrEmpty(lblTahakkukTurluMasraf.Text);
                lblIptalTurluMasraf.Visible = !IsZeroOrEmpty(lblIptalTurluMasraf.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("TürlüM asraf Hesabı yapılırken bir hata oluştu: " + ex.Message);
            }
        }

        public void IlkogretimHesap()
        {
            try
            {
                decimal bkIlkogretim = 0;
                decimal munzamIlkogretim = 0;
                decimal tahakkukIlkogretim = 0;
                decimal odenenIlkogretim = 0;
                decimal iptalIlkogretim = 0;

                if (!decimal.TryParse(lblOdenenIlkogretim.Text, NumberStyles.Number, new CultureInfo("tr-TR"), out odenenIlkogretim))
                {
                    MessageBox.Show("lblOdenenIlkogretim.Text geçerli bir sayı değil: " + lblOdenenIlkogretim.Text);
                    return;
                }

                if (!decimal.TryParse(lblBKIlkogretim.Text, NumberStyles.Number, new CultureInfo("tr-TR"), out bkIlkogretim))
                {
                    MessageBox.Show("lblBKIlkogretim.Text geçerli bir sayı değil: " + lblBKIlkogretim.Text);
                    return;
                }

                if (bkIlkogretim > odenenIlkogretim)
                {
                    lblMunzamIlkogretim.Text = "0";
                }
                else
                {
                    munzamIlkogretim = odenenIlkogretim - bkIlkogretim;
                    lblMunzamIlkogretim.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", munzamIlkogretim);
                }

                tahakkukIlkogretim = bkIlkogretim + munzamIlkogretim;
                lblTahakkukIlkogretim.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", tahakkukIlkogretim);

                iptalIlkogretim = tahakkukIlkogretim - odenenIlkogretim;
                lblIptalIlkogretim.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", iptalIlkogretim);

                // Visible ayarlarını kontrol et
                lblMunzamIlkogretim.Visible = !IsZeroOrEmpty(lblMunzamIlkogretim.Text);
                lblTahakkukIlkogretim.Visible = !IsZeroOrEmpty(lblTahakkukIlkogretim.Text);
                lblIptalIlkogretim.Visible = !IsZeroOrEmpty(lblIptalIlkogretim.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("İlköğretim Hesabı yapılırken bir hata oluştu: " + ex.Message);
            }
        }

        public void KHGBHesap()
        {
            try
            {
                decimal bkKHGB = 0;
                decimal munzamKHGB = 0;
                decimal tahakkukKHGB = 0;
                decimal odenenKHGB = 0;
                decimal iptalKHGB = 0;

                if (!decimal.TryParse(lblOdenenKHGB.Text, NumberStyles.Number, new CultureInfo("tr-TR"), out odenenKHGB))
                {
                    MessageBox.Show("lblOdenenKHGB.Text geçerli bir sayı değil: " + lblOdenenKHGB.Text);
                    return;
                }

                if (!decimal.TryParse(lblBKKHGB.Text, NumberStyles.Number, new CultureInfo("tr-TR"), out bkKHGB))
                {
                    MessageBox.Show("lblBKKHGB.Text geçerli bir sayı değil: " + lblBKKHGB.Text);
                    return;
                }

                if (bkKHGB > odenenKHGB)
                {
                    lblMunzamKHGB.Text = "0";
                }
                else
                {
                    munzamKHGB = odenenKHGB - bkKHGB;
                    lblMunzamKHGB.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", munzamKHGB);
                }

                tahakkukKHGB = bkKHGB + munzamKHGB;
                lblTahakkukKHGB.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", tahakkukKHGB);

                iptalKHGB = tahakkukKHGB - odenenKHGB;
                lblIptalKHGB.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", iptalKHGB);

                // Visible ayarlarını kontrol et
                lblMunzamKHGB.Visible = !IsZeroOrEmpty(lblMunzamKHGB.Text);
                lblTahakkukKHGB.Visible = !IsZeroOrEmpty(lblTahakkukKHGB.Text);
                lblIptalKHGB.Visible = !IsZeroOrEmpty(lblIptalKHGB.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("K.H.G.B. Hesabı yapılırken bir hata oluştu: " + ex.Message);
            }
        }

        public void BayindirlikToplamlari()
        {
            try
            {
                //BAYINDIRLIK İPTAL İŞLEMLERİ
                decimal iptalYolKopru, iptalKoyAkar, iptalVesait, iptalAydinlatma, iptalMezarlik,
                    odenenYolKopru, odenenKoyAkar, odenenVesait, odenenAydinlatma, odenenMezarlik,
                    tahakkukYolKopru, tahakkukKoyAkar, tahakkukVesait, tahakkukAydinlatma, tahakkukMezarlik,
                    munzamYolKopru, munzamKoyAkar, munzamVesait, munzamAydinlatma, munzamMezarlik;

                //BAYINDIRLIK İPTAL İŞLEMLERİ
                if (!decimal.TryParse(lblIptalYolKopru.Text, out iptalYolKopru))
                    iptalYolKopru = 0;
                if (!decimal.TryParse(lblIptalKoyAkar.Text, out iptalKoyAkar))
                    iptalKoyAkar = 0;
                if (!decimal.TryParse(lblIptalVesait.Text, out iptalVesait))
                    iptalVesait = 0;
                if (!decimal.TryParse(lblIptalAydinlatma.Text, out iptalAydinlatma))
                    iptalAydinlatma = 0;
                if (!decimal.TryParse(lblIptalMezarlik.Text, out iptalMezarlik))
                    iptalMezarlik = 0;

                // Toplamları hesaplayın
                decimal IptalBayindirlikToplami = iptalYolKopru + iptalKoyAkar + iptalVesait + iptalAydinlatma + iptalMezarlik;

                // Sonucu etikete atayın
                lblIptalBayindirlikToplami.Text = IptalBayindirlikToplami.ToString("#,0.00");
                lblIptalToplamBayindirlik.Text = lblIptalBayindirlikToplami.Text;

                ////BAYINDIRLIK ODENEN İŞLEMLERİ
                if (!decimal.TryParse(lblOdenenYolKopru.Text, out odenenYolKopru))
                    odenenYolKopru = 0;
                if (!decimal.TryParse(lblOdenenKoyAkar.Text, out odenenKoyAkar))
                    odenenKoyAkar = 0;
                if (!decimal.TryParse(lblOdenenVesait.Text, out odenenVesait))
                    odenenVesait = 0;
                if (!decimal.TryParse(lblOdenenAydinlatma.Text, out odenenAydinlatma))
                    odenenAydinlatma = 0;
                if (!decimal.TryParse(lblOdenenMezarlik.Text, out odenenMezarlik))
                    odenenMezarlik = 0;

                // Toplamları hesaplayın
                decimal OdenenBayindirlikToplami = odenenYolKopru + odenenKoyAkar + odenenVesait + odenenAydinlatma + odenenMezarlik;

                // Sonucu etikete atayın
                lblOdenenBayindirlikToplami.Text = OdenenBayindirlikToplami.ToString("#,0.00");
                lblOdenenToplamBayindirlik.Text = lblOdenenBayindirlikToplami.Text;

                ////BAYINDIRLIK TAHAKKUK İŞLEMLERİ
                if (!decimal.TryParse(lblTahakkukYolKopru.Text, out tahakkukYolKopru))
                    tahakkukYolKopru = 0;
                if (!decimal.TryParse(lblTahakkukKoyAkar.Text, out tahakkukKoyAkar))
                    tahakkukKoyAkar = 0;
                if (!decimal.TryParse(lblTahakkukVesait.Text, out tahakkukVesait))
                    tahakkukVesait = 0;
                if (!decimal.TryParse(lblTahakkukAydinlatma.Text, out tahakkukAydinlatma))
                    tahakkukAydinlatma = 0;
                if (!decimal.TryParse(lblTahakkukMezarlik.Text, out tahakkukMezarlik))
                    tahakkukMezarlik = 0;

                // Toplamları hesaplayın
                decimal TahakkukBayindirlikToplami = tahakkukYolKopru + tahakkukKoyAkar + tahakkukVesait + tahakkukAydinlatma + tahakkukMezarlik;

                // Sonucu etikete atayın
                lblTahakkukBayindirlikToplami.Text = TahakkukBayindirlikToplami.ToString("#,0.00");
                lblTahakkukToplamBayindirlik.Text = lblTahakkukBayindirlikToplami.Text;

                ////BAYINDIRLIK MUNZAM İŞLEMLERİ
                if (!decimal.TryParse(lblMunzamYolKopru.Text, out munzamYolKopru))
                    munzamYolKopru = 0;
                if (!decimal.TryParse(lblMunzamKoyAkar.Text, out munzamKoyAkar))
                    munzamKoyAkar = 0;
                if (!decimal.TryParse(lblMunzamVesait.Text, out munzamVesait))
                    munzamVesait = 0;
                if (!decimal.TryParse(lblMunzamAydinlatma.Text, out munzamAydinlatma))
                    munzamMezarlik = 0;
                if (!decimal.TryParse(lblMunzamMezarlik.Text, out munzamMezarlik))
                    munzamMezarlik = 0;

                // Toplamları hesaplayın
                decimal MunzamBayindirlikToplami = munzamYolKopru + munzamKoyAkar + munzamVesait + munzamAydinlatma + munzamMezarlik;

                // Sonucu etikete atayın
                lblMunzamBayindirlikToplami.Text = MunzamBayindirlikToplami.ToString("#,0.00");
                lblMunzamToplamBayindirlik.Text = lblMunzamBayindirlikToplami.Text;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        public void TurluIslerToplamlari()
        {
            try
            {
                //TurluIsler İPTAL İŞLEMLERİ
                decimal iptalVergi, iptalKoyBorcu, iptalMahkeme, iptalIstimlak, iptalUmulmadik, iptalTurluMasraf, iptalIlkogretim, iptalKHGB,
                        odenenVergi, odenenKoyBorcu, odenenMahkeme, odenenIstimlak, odenenUmulmadik, odenenTurluMasraf, odenenIlkogretim, odenenKHGB,
                        tahakkukVergi, tahakkukKoyBorcu, tahakkukMahkeme, tahakkukIstimlak, tahakkukUmulmadik, tahakkukTurluMasraf, tahakkukIlkogretim, tahakkukKHGB,
                        munzamVergi, munzamKoyBorcu, munzamMahkeme, munzamIstimlak, munzamUmulmadik, munzamTurluMasraf, munzamIlkogretim, munzamKHGB;

                //TurluIsler İPTAL İŞLEMLERİ
                if (!decimal.TryParse(lblIptalVergi.Text, out iptalVergi))
                    iptalVergi = 0;
                if (!decimal.TryParse(lblIptalKoyBorcu.Text, out iptalKoyBorcu))
                    iptalKoyBorcu = 0;
                if (!decimal.TryParse(lblIptalMahkeme.Text, out iptalMahkeme))
                    iptalMahkeme = 0;
                if (!decimal.TryParse(lblIptalIstimlak.Text, out iptalIstimlak))
                    iptalIstimlak = 0;
                if (!decimal.TryParse(lblIptalUmulmadik.Text, out iptalUmulmadik))
                    iptalUmulmadik = 0;
                if (!decimal.TryParse(lblIptalTurluMasraf.Text, out iptalTurluMasraf))
                    iptalTurluMasraf = 0;
                if (!decimal.TryParse(lblIptalIlkogretim.Text, out iptalIlkogretim))
                    iptalIlkogretim = 0;
                if (!decimal.TryParse(lblIptalKHGB.Text, out iptalKHGB))
                    iptalKHGB = 0;

                // Toplamları hesaplayın
                decimal IptalTurluIslerToplami = iptalVergi + iptalKoyBorcu + iptalMahkeme + iptalIstimlak + iptalUmulmadik + iptalTurluMasraf + iptalIlkogretim + iptalKHGB;

                // Sonucu etikete atayın
                lblIptalTurluIslerToplami.Text = IptalTurluIslerToplami.ToString("#,0.00");
                lblIptalToplamTurluIsler.Text = lblIptalTurluIslerToplami.Text;

                ////TurluIsler ODENEN İŞLEMLERİ
                if (!decimal.TryParse(lblOdenenVergi.Text, out odenenVergi))
                    odenenVergi = 0;
                if (!decimal.TryParse(lblOdenenKoyBorcu.Text, out odenenKoyBorcu))
                    odenenKoyBorcu = 0;
                if (!decimal.TryParse(lblOdenenMahkeme.Text, out odenenMahkeme))
                    odenenMahkeme = 0;
                if (!decimal.TryParse(lblOdenenIstimlak.Text, out odenenIstimlak))
                    odenenIstimlak = 0;
                if (!decimal.TryParse(lblOdenenUmulmadik.Text, out odenenUmulmadik))
                    odenenUmulmadik = 0;
                if (!decimal.TryParse(lblOdenenTurluMasraf.Text, out odenenTurluMasraf))
                    odenenTurluMasraf = 0;
                if (!decimal.TryParse(lblOdenenIlkogretim.Text, out odenenIlkogretim))
                    odenenIlkogretim = 0;
                if (!decimal.TryParse(lblOdenenKHGB.Text, out odenenKHGB))
                    odenenKHGB = 0;

                // Toplamları hesaplayın
                decimal OdenenTurluIslerToplami = odenenVergi + odenenKoyBorcu + odenenMahkeme + odenenIstimlak + odenenUmulmadik + odenenTurluMasraf + odenenIlkogretim + odenenKHGB;

                // Sonucu etikete atayın
                lblOdenenTurluIslerToplami.Text = OdenenTurluIslerToplami.ToString("#,0.00");
                lblOdenenToplamTurluİsler.Text = lblOdenenTurluIslerToplami.Text;

                ////TurluIsler TAHAKKUK İŞLEMLERİ tahakkukYolKopru, tahakkukKoyAkar, tahakkukVesait, tahakkukAydinlatma, tahakkukMezarlik,
                if (!decimal.TryParse(lblTahakkukVergi.Text, out tahakkukVergi))
                    tahakkukVergi = 0;
                if (!decimal.TryParse(lblTahakkukKoyBorcu.Text, out tahakkukKoyBorcu))
                    tahakkukKoyBorcu = 0;
                if (!decimal.TryParse(lblTahakkukMahkeme.Text, out tahakkukMahkeme))
                    tahakkukMahkeme = 0;
                if (!decimal.TryParse(lblTahakkukIstimlak.Text, out tahakkukIstimlak))
                    tahakkukIstimlak = 0;
                if (!decimal.TryParse(lblTahakkukUmulmadik.Text, out tahakkukUmulmadik))
                    tahakkukUmulmadik = 0;
                if (!decimal.TryParse(lblTahakkukTurluMasraf.Text, out tahakkukTurluMasraf))
                    tahakkukTurluMasraf = 0;
                if (!decimal.TryParse(lblTahakkukIlkogretim.Text, out tahakkukIlkogretim))
                    tahakkukIlkogretim = 0;
                if (!decimal.TryParse(lblTahakkukKHGB.Text, out tahakkukKHGB))
                    tahakkukKHGB = 0;

                // Toplamları hesaplayın
                decimal TahakkukTurluIslerToplami = tahakkukVergi + tahakkukKoyBorcu + tahakkukMahkeme + tahakkukIstimlak + tahakkukUmulmadik + tahakkukTurluMasraf + tahakkukIlkogretim + tahakkukKHGB;

                // Sonucu etikete atayın
                lblTahakkukTurluIslerToplami.Text = TahakkukTurluIslerToplami.ToString("#,0.00");
                lblTahakkukToplamTurluİsler.Text = lblTahakkukTurluIslerToplami.Text;

                ////TurluIsler MUNZAM İŞLEMLERİ
                if (!decimal.TryParse(lblMunzamVergi.Text, out munzamVergi))
                    munzamVergi = 0;
                if (!decimal.TryParse(lblMunzamKoyBorcu.Text, out munzamKoyBorcu))
                    munzamKoyBorcu = 0;
                if (!decimal.TryParse(lblMunzamMahkeme.Text, out munzamMahkeme))
                    munzamMahkeme = 0;
                if (!decimal.TryParse(lblMunzamIstimlak.Text, out munzamIstimlak))
                    munzamIstimlak = 0;
                if (!decimal.TryParse(lblMunzamUmulmadik.Text, out munzamUmulmadik))
                    munzamUmulmadik = 0;
                if (!decimal.TryParse(lblMunzamTurluMasraf.Text, out munzamTurluMasraf))
                    munzamTurluMasraf = 0;
                if (!decimal.TryParse(lblMunzamIlkogretim.Text, out munzamIlkogretim))
                    munzamIlkogretim = 0;
                if (!decimal.TryParse(lblMunzamKHGB.Text, out munzamKHGB))
                    munzamKHGB = 0;

                // Toplamları hesaplayın
                decimal MunzamTurluIslerToplami = munzamVergi + munzamKoyBorcu + munzamMahkeme + munzamIstimlak + munzamUmulmadik + munzamTurluMasraf + munzamIlkogretim + munzamKHGB;

                // Sonucu etikete atayın
                lblMunzamTurluIslerToplami.Text = MunzamTurluIslerToplami.ToString("#,0.00");
                lblMunzamToplamTurluİsler.Text = lblMunzamTurluIslerToplami.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        public void GiderlerToplamlari()
        {
            try
            {
                //TurluIsler İPTAL İŞLEMLERİ
                decimal bkIdariIsler, bkZiraat, bkKultur, bkSaglik, bkBayindirlik, bkTurluIsler, bkAsker,
                        munzamIdariIsler, munzamZiraat, munzamKultur, munzamSaglik, munzamBayindirlik, munzamTurluIsler, munzamAsker,
                        tahakkukIdariIsler, tahakkukZiraat, tahakkukKultur, tahakkukSaglik, tahakkukBayindirlik, tahakkukTurluIsler, tahakkukAsker,
                        odenenIdariIsler, odenenZiraat, odenenKultur, odenenSaglik, odenenBayindirlik, odenenTurluIsler, odenenAsker,
                        iptalIdariIsler, iptalZiraat, iptalKultur, iptalSaglik, iptalBayindirlik, iptalTurluIsler, iptalAsker;

                //BK İŞLEMLERİ
                if (!decimal.TryParse(lblBKIdariIsler.Text, out bkIdariIsler))
                    bkIdariIsler = 0;
                if (!decimal.TryParse(lblBKZiraat.Text, out bkZiraat))
                    bkZiraat = 0;
                if (!decimal.TryParse(lblBKKultur.Text, out bkKultur))
                    bkKultur = 0;
                if (!decimal.TryParse(lblBKSaglik.Text, out bkSaglik))
                    bkSaglik = 0;
                if (!decimal.TryParse(lblBKBayindirlik.Text, out bkBayindirlik))
                    bkBayindirlik = 0;
                if (!decimal.TryParse(lblBKTurluIsler.Text, out bkTurluIsler))
                    bkTurluIsler = 0;
                if (!decimal.TryParse(lblBKAsker.Text, out bkAsker))
                    bkAsker = 0;

                // Toplamları hesaplayın
                decimal BKGenelToplami = bkIdariIsler + bkZiraat + bkKultur + bkSaglik + bkBayindirlik + bkTurluIsler + bkAsker;

                // Sonucu etikete atayın
                lblButceGenelToplami.Text = BKGenelToplami.ToString("#,0.00");

                //MUNZAM İŞLEMLERİ
                if (!decimal.TryParse(lblMunzamIdariIslerToplami.Text, out munzamIdariIsler))
                    munzamIdariIsler = 0;
                if (!decimal.TryParse(lblMunzamZiraatToplami.Text, out munzamZiraat))
                    munzamZiraat = 0;
                if (!decimal.TryParse(lblMunzamKulturToplami.Text, out munzamKultur))
                    munzamKultur = 0;
                if (!decimal.TryParse(lblMunzamSaglikToplami.Text, out munzamSaglik))
                    munzamSaglik = 0;
                if (!decimal.TryParse(lblMunzamToplamBayindirlik.Text, out munzamBayindirlik))
                    munzamBayindirlik = 0;
                if (!decimal.TryParse(lblMunzamTurluIslerToplami.Text, out munzamTurluIsler))
                    munzamTurluIsler = 0;
                if (!decimal.TryParse(lblMunzamToplamAsker.Text, out munzamAsker))
                    munzamAsker = 0;

                // Toplamları hesaplayın
                decimal MunzamGenelToplami = munzamIdariIsler + munzamZiraat + munzamKultur + munzamSaglik + munzamBayindirlik + munzamTurluIsler + munzamAsker;

                // Sonucu etikete atayın
                lblMunzamGenelToplami.Text = MunzamGenelToplami.ToString("#,0.00");

                //TAHAKKUK İŞLEMLERİ
                if (!decimal.TryParse(lblTahakkukIdariIslerToplami.Text, out tahakkukIdariIsler))
                    tahakkukIdariIsler = 0;
                if (!decimal.TryParse(lblTahakkukZiraatToplami.Text, out tahakkukZiraat))
                    tahakkukZiraat = 0;
                if (!decimal.TryParse(lblTahakkukKulturToplami.Text, out tahakkukKultur))
                    tahakkukKultur = 0;
                if (!decimal.TryParse(lblTahakkukSaglikToplami.Text, out tahakkukSaglik))
                    tahakkukSaglik = 0;
                if (!decimal.TryParse(lblTahakkukBayindirlikToplami.Text, out tahakkukBayindirlik))
                    tahakkukBayindirlik = 0;
                if (!decimal.TryParse(lblTahakkukTurluIslerToplami.Text, out tahakkukTurluIsler))
                    tahakkukTurluIsler = 0;
                if (!decimal.TryParse(lblTahakkukAskerToplami.Text, out tahakkukAsker))
                    tahakkukAsker = 0;

                // Toplamları hesaplayın
                decimal TahakkukGenelToplami = tahakkukIdariIsler + tahakkukZiraat + tahakkukKultur + tahakkukSaglik + tahakkukBayindirlik + tahakkukTurluIsler + tahakkukAsker;

                // Sonucu etikete atayın
                lblTahakkukGenelToplam.Text = TahakkukGenelToplami.ToString("#,0.00");

                //ÖDENEN İŞLEMLERİ
                if (!decimal.TryParse(lblOdenenIdariIslerToplami.Text, out odenenIdariIsler))
                    odenenIdariIsler = 0;
                if (!decimal.TryParse(lblOdenenZiraatToplami.Text, out odenenZiraat))
                    odenenZiraat = 0;
                if (!decimal.TryParse(lblOdenenKulturToplami.Text, out odenenKultur))
                    odenenKultur = 0;
                if (!decimal.TryParse(lblOdenenSaglikToplami.Text, out odenenSaglik))
                    odenenSaglik = 0;
                if (!decimal.TryParse(lblOdenenToplamBayindirlik.Text, out odenenBayindirlik))
                    odenenBayindirlik = 0;
                if (!decimal.TryParse(lblOdenenToplamTurluİsler.Text, out odenenTurluIsler))
                    odenenTurluIsler = 0;
                if (!decimal.TryParse(lblOdenenToplamAsker.Text, out odenenAsker))
                    odenenAsker = 0;

                // Toplamları hesaplayın
                decimal OdenenGenelToplami = odenenIdariIsler + odenenZiraat + odenenKultur + odenenSaglik + odenenBayindirlik + odenenTurluIsler + odenenAsker;

                // Sonucu etikete atayın
                lblOdenenGenelToplami.Text = OdenenGenelToplami.ToString("#,0.00");
                lblToplamGider.Text = lblOdenenGenelToplami.Text;

                //İPTAL İŞLEMLERİ
                if (!decimal.TryParse(lblIptalIdariIslerToplami.Text, out iptalIdariIsler))
                    iptalIdariIsler = 0;
                if (!decimal.TryParse(lblIptalZiraatToplami.Text, out iptalZiraat))
                    iptalZiraat = 0;
                if (!decimal.TryParse(lblIptalKulturToplami.Text, out iptalKultur))
                    iptalKultur = 0;
                if (!decimal.TryParse(lblIptalSaglikToplami.Text, out iptalSaglik))
                    iptalSaglik = 0;
                if (!decimal.TryParse(lblIptalToplamBayindirlik.Text, out iptalBayindirlik))
                    iptalBayindirlik = 0;
                if (!decimal.TryParse(lblIptalToplamTurluIsler.Text, out iptalTurluIsler))
                    iptalTurluIsler = 0;
                if (!decimal.TryParse(lblIptalToplamAsker.Text, out iptalAsker))
                    iptalAsker = 0;

                // Toplamları hesaplayın
                decimal IptalGenelToplami = iptalIdariIsler + iptalZiraat + iptalKultur + iptalSaglik + iptalBayindirlik + iptalTurluIsler + iptalAsker;

                // Sonucu etikete atayın
                lblIptalGenelToplami.Text = IptalGenelToplami.ToString("#,0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        private bool IsZeroOrEmpty(string text)
        {
            //Debug.WriteLine($"IsZeroOrEmpty çağrıldı. Text: {text}");
            decimal value;
            if (decimal.TryParse(text, NumberStyles.Number, new CultureInfo("tr-TR"), out value))
            {
                //Debug.WriteLine($"Parsed value: {value}, IsZero: {value == 0}");
                return value == 0;
            }
            //Debug.WriteLine($"Parse edilemedi, IsNullOrEmpty: {string.IsNullOrEmpty(text)}");
            return string.IsNullOrEmpty(text);
        }

        //FrmTahminiButce'deki Tutarın %10'unun Ilkogretim ve KHGB'ne yazdıran metot.
        private void UpdateLabelsFromTahminiButce()
        {
            // FrmTahminButce formundaki DataGridView'e erişin
            FrmTahminiButce frmTahminButce = Application.OpenForms.OfType<FrmTahminiButce>().FirstOrDefault();
            if (frmTahminButce != null)
            {
                DataGridView dgvTahminiButceler = frmTahminButce.Controls.Find("dgvTahminiButceler", true).FirstOrDefault() as DataGridView;
                if (dgvTahminiButceler != null)
                {
                    decimal toplamButceTutari = 0;

                    // DataGridView'deki TahminiButceTutari sütunundaki değerleri toplayın
                    foreach (DataGridViewRow row in dgvTahminiButceler.Rows)
                    {
                        if (row.Cells["TahminiButceTutari"].Value != null)
                        {
                            toplamButceTutari += Convert.ToDecimal(row.Cells["TahminiButceTutari"].Value);
                        }
                    }

                    // Toplam bütçe tutarının %10'unu hesaplayın
                    decimal percentage = toplamButceTutari * 0.10m;
                    lblBKIlkogretim.Text = percentage.ToString(); // Para birimi formatında
                    lblBKKHGB.Text = percentage.ToString();
                }
            }
        }

        //KesinHesap1'den KesinHesap2 ye label aktarımı
        private void TransferLabelValuesFromKesinHesap1()
        {
            // FrmKesinHesap1 formunu kontrol edin, eğer null ise arka planda oluşturun
            if (frmKesinHesap1 == null)
            {
                frmKesinHesap1 = new FrmKesinHesap1(_seciliKoyIndex, _seciliDonemIndex, _seciliIlceIndex);
                frmKesinHesap1.StartPosition = FormStartPosition.Manual;
                frmKesinHesap1.Location = new Point(-frmKesinHesap1.Width - 100, -frmKesinHesap1.Height - 100); // Ekran dışında bir konum
                frmKesinHesap1.ShowInTaskbar = false; // Görev çubuğunda gösterme
                frmKesinHesap1.Visible = false; // Görünmez olarak ayarla
            }

            // FrmKesinHesap1 formu yüklenene kadar bekleyin
            frmKesinHesap1.Load += (sender, e) =>
            {
                // İlgili label değerlerini FrmKesinHesap2'ye kopyalayın
                lblBKIdariIsler.Text = frmKesinHesap1.lblBKIdariToplami.Text;
                lblMunzamIdariIslerToplami.Text = frmKesinHesap1.lblMunzamIdariToplami.Text;
                lblTahakkukIdariIslerToplami.Text = frmKesinHesap1.lblTahakkukIdariToplami.Text;
                lblOdenenIdariIslerToplami.Text = frmKesinHesap1.lblOdenenIdariToplami.Text;
                lblIptalIdariIslerToplami.Text = frmKesinHesap1.lblIptalIdariToplami.Text;

                lblBKZiraat.Text = frmKesinHesap1.lblBKZiraatToplami.Text;
                lblMunzamZiraatToplami.Text = frmKesinHesap1.lblMunzamZiraatToplami.Text;
                lblTahakkukZiraatToplami.Text = frmKesinHesap1.lblTahakkukZiraatToplami.Text;
                lblOdenenZiraatToplami.Text = frmKesinHesap1.lblOdenenZiraatToplami.Text;
                lblIptalZiraatToplami.Text = frmKesinHesap1.lblIptalZiraatToplami.Text;

                lblBKKultur.Text = frmKesinHesap1.lblBKKulturToplami.Text;
                lblMunzamKulturToplami.Text = frmKesinHesap1.lblMunzamKulturToplami.Text;
                lblTahakkukKulturToplami.Text = frmKesinHesap1.lblTahakkukKulturToplami.Text;
                lblOdenenKulturToplami.Text = frmKesinHesap1.lblOdenenKulturToplami.Text;
                lblIptalKulturToplami.Text = frmKesinHesap1.lblIptalKulturToplami.Text;

                lblBKSaglik.Text = frmKesinHesap1.lblBKKulturToplami.Text;
                lblMunzamSaglikToplami.Text = frmKesinHesap1.lblMunzamSaglikToplami.Text;
                lblTahakkukSaglikToplami.Text = frmKesinHesap1.lblTahakkukSaglikToplami.Text;
                lblOdenenSaglikToplami.Text = frmKesinHesap1.lblOdenenSaglikToplami.Text;
                lblIptalSaglikToplami.Text = frmKesinHesap1.lblIptalSaglikToplami.Text;

                // İşlem tamamlandıktan sonra formu kapatın
                frmKesinHesap1.Close();
                frmKesinHesap1 = null; // Referansı null yapın, bir sonraki işlem için tekrar oluşturulacak
            };
            // Formu göstermeden yükleyin
            frmKesinHesap1.Show();
        }

        private void LoadDevirToplami()
        {
            try
            {
                decimal devirToplami = GetGelirToplami(_seciliKoyIndex, _seciliDonemIndex, 8);
                lblDevir.Text = string.Format("{0:#,0.00}", devirToplami);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Devir geliri yüklenirken bir hata oluştu: " + ex.Message);
            }
        }

        private void LoadGelirKategoriToplamlari()
        {
            try
            {
                decimal toplamGelir = 0;

                // Diğer gelir kategorileri için toplamı hesapla
                toplamGelir += GetGelirToplami(_seciliKoyIndex, _seciliDonemIndex, 1); // Hasilat için
                toplamGelir += GetGelirToplami(_seciliKoyIndex, _seciliDonemIndex, 2); // Resim için
                toplamGelir += GetGelirToplami(_seciliKoyIndex, _seciliDonemIndex, 3); // Ceza için
                toplamGelir += GetGelirToplami(_seciliKoyIndex, _seciliDonemIndex, 4); // Yardım için
                toplamGelir += GetGelirToplami(_seciliKoyIndex, _seciliDonemIndex, 5); // Köy Vakıf için
                toplamGelir += GetGelirToplami(_seciliKoyIndex, _seciliDonemIndex, 6); // İstikraz için
                toplamGelir += GetGelirToplami(_seciliKoyIndex, _seciliDonemIndex, 7); // Türlü Gelir için

                // Toplamı lblGelir etiketine yazdır
                lblGelir.Text = string.Format("{0:#,0.00}", toplamGelir);

                //YEKÜN TOPLAMA İŞLEMİ
                decimal devir, gelir;
                if (!decimal.TryParse(lblDevir.Text, out devir))
                    devir = 0;
                if (!decimal.TryParse(lblGelir.Text, out gelir))
                    gelir = 0;

                // Toplamları hesaplayın
                decimal Yekun = devir + gelir;

                // Sonucu etikete atayın
                lblYekun.Text = Yekun.ToString("#,0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gelir verilerini yüklerken bir hata oluştu: " + ex.Message);
            }
        }

        private decimal GetGelirToplami(int koyId, byte donemId, byte gelirKategoriId)
        {
            try
            {
                return _gelirManager.GelirKategoriToplam(koyId, donemId, gelirKategoriId);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gelir Kategorisi {gelirKategoriId} için toplam tutar yüklenirken bir hata oluştu: " + ex.Message);
                return 0; // Hata durumunda varsayılan değeri döndür
            }
        }

        public void ButceSonucu()
        {
            try
            {
                decimal yekun, toplamGider;
                if (!decimal.TryParse(lblYekun.Text, out yekun))
                    yekun = 0;
                if (!decimal.TryParse(lblToplamGider.Text, out toplamGider))
                    toplamGider = 0;

                // Toplamları hesaplayın
                decimal ButceSonucu = yekun - toplamGider;

                // Sonucu etikete atayın, pozitif ise direkt olarak yazdırın
                lblButceSonucu.Text = ButceSonucu >= 0 ? ButceSonucu.ToString("#,0.00") : (-ButceSonucu).ToString("#,0.00");
                //lblButceSonucu.Text = ButceSonucu >= 0 ? ButceSonucu.ToString("#,0.00") : "+" + (-ButceSonucu).ToString("#,0.00");

                if (toplamGider < yekun)
                {
                    lblSonucMetni.Text = Convert.ToInt32(lblGelirYil.Text) + 1 + " YILINA GELİR DEVRİ";
                }
                if (toplamGider > yekun)
                {
                    lblSonucMetni.Text = "KÖY BORCU (MUHTAR ALACAĞI)";
                }
                if (toplamGider == yekun)
                {
                    lblSonucMetni.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veriler yüklenirken bir hata oluştu: " + ex.Message);
            }
        }

        private void FrmKesinHesap2_Load(object sender, EventArgs e)
        {
            TransferLabelValuesFromKesinHesap1();
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

            UpdateLabelsFromTahminiButce();

            YolKopruHesap();
            KoyAkarHesap();
            VesaitHesap();
            AydinlatmaHesap();
            MezarlikHesap();
            VergiHesap();
            KoyBorcuHesap();
            MahkemeHesap();
            IstimlakHesap();
            UmulmadikHesap();
            TurluMasrafHesap();
            IlkogretimHesap();
            KHGBHesap();
            BayindirlikToplamlari();
            TurluIslerToplamlari();
            GiderlerToplamlari();
            LoadDevirToplami(); //Devir toplamlarının lblDevir'in textine yazdıran metot
            LoadGelirKategoriToplamlari(); //Gelir Toplamlarının lblGelir textine yazdıran metot
            ButceSonucu();

            lblBKGelir.Text = lblButceGenelToplami.Text;
            lblBKGider.Text = lblButceGenelToplami.Text;
            lblYilToplamGeliri.Text = lblYekun.Text;
            lblYilToplamGideri.Text = lblToplamGider.Text;

            RakamlariPanelinSaginaYasla();
            GorevliPaneleOrtala();
        }
    }
}
