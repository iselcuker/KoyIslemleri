using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.SqlServer.Server;
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
    public partial class FrmKesinHesap1 : Form
    {
        IlceManager ilceManager;
        KoyManager koyManager;
        //DonemManager donemManager;

        //AnaSayfada comboboxlardan yapılan seçimlerin index lerini getirmek için
        int _seciliKoyIndex;
        byte _seciliDonemIndex;
        byte _seciliIlceIndex;
        private GelirManager _gelirManager;
        private GiderManager _giderManager;
        private TahminiButceGelirManager _tahminiButceGelirManager;
        private TahminiButceGiderManager _tahminiButceGiderManager;

        public FrmKesinHesap1(int seciliKoyIndex, byte seciliDonemIndex, byte seciliIlceIndex)
        {
            InitializeComponent();
            //Degisiklik labelları için
            this.Load += new System.EventHandler(this.FrmKesinHesap1_Load);

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
        }

 
        //Degisiklik labellarına veri yazdırma
        public void DegisiklikLabellarıYaz()
        {
            //// Label'ların başlangıç değerlerini boş olarak ayarla
            //lblHasilatDegisiklik.Text = String.Empty;
            //lblResimDegisiklik.Text = String.Empty;
            //lblKoyVakifDegisiklik.Text = String.Empty;
            //lblIstikrazDegisiklik.Text = String.Empty;
            //lblCezaDegisiklik.Text = String.Empty;

            // DataGridView satırlarını dolaş
            foreach (DataGridViewRow row in dgvTahminiGelir.Rows)
            {
                // GelirKategoriAdi ve DegisiklikAdi sütunlarının değerlerini al
                var gelirKategoriAdi = row.Cells["GelirKategoriAdi"].Value?.ToString();
                var degisiklikAdi = row.Cells["DegisiklikAdi"].Value?.ToString();

                //// Debug ile değerleri kontrol edin
                //Debug.WriteLine($"GelirKategoriAdi: {gelirKategoriAdi}, DegisiklikAdi: {degisiklikAdi}");

                // Koşullara göre label'ların Text değerlerini ayarla
                if (!string.IsNullOrEmpty(gelirKategoriAdi) && gelirKategoriAdi == "Hasılat")
                {
                    lblHasilatDegisiklik.Text = degisiklikAdi;
                }
                else if (!string.IsNullOrEmpty(gelirKategoriAdi) && gelirKategoriAdi == "Resim ve harçlar")
                {
                    lblResimDegisiklik.Text = degisiklikAdi;
                }
                else if (!string.IsNullOrEmpty(gelirKategoriAdi) && gelirKategoriAdi == "Köy vakıf ve avarız geliri")
                {
                    lblKoyVakifDegisiklik.Text = degisiklikAdi;
                }
                else if (!string.IsNullOrEmpty(gelirKategoriAdi) && gelirKategoriAdi == "İstikrazlar")
                {
                    lblIstikrazDegisiklik.Text = degisiklikAdi;
                }
                else if (!string.IsNullOrEmpty(gelirKategoriAdi) && gelirKategoriAdi == "Para Cezaları")
                {
                    lblCezaDegisiklik.Text = degisiklikAdi;
                }
            }

        }
        private void TahminiGelir()
        {
            try
            {
                // Tahmini gelirleri DataGridView'e yükler
                var gelirler = _tahminiButceGelirManager.GetTahminiButceGelirDetails(_seciliKoyIndex, _seciliDonemIndex);

                // Veriyi DataGridView'e bağla
                dgvTahminiGelir.DataSource = gelirler;

                // Gereksiz kolonları gizle
                dgvTahminiGelir.Columns["TahminiButceGelirId"].Visible = false;
                dgvTahminiGelir.Columns["KoyAdi"].Visible = false;
                dgvTahminiGelir.Columns["DonemAdi"].Visible = false;
                dgvTahminiGelir.Columns["KoyId"].Visible = false;
                dgvTahminiGelir.Columns["DonemId"].Visible = false;
                dgvTahminiGelir.Columns["GelirKategoriId"].Visible = false;
                dgvTahminiGelir.Columns["DegisiklikId"].Visible = false; // Bu satırı kaldırın

                // DataGridView'in görüntü ayarlarını yapar
                dgvTahminiGelir.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Tüm alanı kaplaması için
                dgvTahminiGelir.RowHeadersVisible = false; // Sol baştaki boş satırı gizler
            }
            catch (Exception ex)
            {
                // Hata oluştuğunda kullanıcıya bilgi verir
                MessageBox.Show("Veri yüklenirken bir hata oluştu: " + ex.Message);
            }
        }

        //Gelir kategorilerine göre toplam tutarları label'lara yazdır
        private void LoadGelirKategoriToplamlari()
        {
            try
            {
                GelirToplami(_seciliKoyIndex, _seciliDonemIndex, 1, lblTahsilHasilat); // Hasilat için
                GelirToplami(_seciliKoyIndex, _seciliDonemIndex, 2, lblTahsilResim); // Resim için
                GelirToplami(_seciliKoyIndex, _seciliDonemIndex, 3, lblTahsilCeza); // Ceza için
                GelirToplami(_seciliKoyIndex, _seciliDonemIndex, 4, lblTahsilYardim); // Yardım için
                GelirToplami(_seciliKoyIndex, _seciliDonemIndex, 5, lblTahsilKoyVakif); // Köy Vakıf için
                GelirToplami(_seciliKoyIndex, _seciliDonemIndex, 6, lblTahsilIstikraz); // İstikraz için
                GelirToplami(_seciliKoyIndex, _seciliDonemIndex, 7, lblTahsilTurluGelir); // Türlü Gelir için
                GelirToplami(_seciliKoyIndex, _seciliDonemIndex, 8, lblTahsilDevir); // Devir için
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gelir verilerini yüklerken bir hata oluştu: " + ex.Message);
            }
        }

        // Gelir Toplamı için Kullanıyorum
        private void GelirToplami(int koyId, byte donemId, byte gelirKategoriId, Label label)
        {
            try
            {
                decimal toplamTutar = _gelirManager.GelirKategoriToplam(koyId, donemId, gelirKategoriId);
                // Label'e toplam tutarı yazdır
                label.Text = string.Format("{0:#,0.00}", toplamTutar);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gelir Kategorisi {gelirKategoriId} için toplam tutar yüklenirken bir hata oluştu: " + ex.Message);
                // label.Text = "0.00"; // Hata durumunda varsayılan değeri yazdır
            }
        }

        //TahminiButceGelir'de yer alan kayıtları ilgili label'lara yazıdrma
        private void LoadGelirKategoriVerileri()
        {
            try
            {
                GelirKategoriLabellarAyarla(lblBKHasilat, 1);
                GelirKategoriLabellarAyarla(lblBKResim, 2); // lblTahsilResim için gelirKategoriId = 2 olan veriyi getir
                GelirKategoriLabellarAyarla(lblBKCeza, 3);
                GelirKategoriLabellarAyarla(lblBKYardim, 4);
                GelirKategoriLabellarAyarla(lblBKKoyVakif, 5);
                GelirKategoriLabellarAyarla(lblBKIstikraz, 6);
                GelirKategoriLabellarAyarla(lblBKTurluGelir, 7);
                GelirKategoriLabellarAyarla(lblBKDevir, 8);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Verileri yüklerken bir hata oluştu: " + ex.Message);
            }
        }

        private void GelirKategoriLabellarAyarla(Label label, byte gelirKategoriId)
        {
            try
            {
                //Debug.WriteLine($"GelirKategoriLabellarAyarla - gelirKategoriId: {gelirKategoriId}");

                // Veritabanından belirtilen gelir kategorisi için veriyi al
                var tahminiButceGelir = _tahminiButceGelirManager
                    .GetListByKoyIdAndDonemIdAndGelirKategoriId(_seciliKoyIndex, _seciliDonemIndex, gelirKategoriId)
                    .FirstOrDefault();

                //Debug.WriteLine($"lblBKResim.Text: {lblBKResim.Text}");
                //Debug.WriteLine($"lblTahsilResim.Text: {lblTahsilResim.Text}");


                if (tahminiButceGelir != null)
                {
                    //Debug.WriteLine($"GelirKategoriLabellarAyarla - Bulunan tahmini gelir: {tahminiButceGelir.TahimiGelirTutari}");
                    label.Text = string.Format("{0:#,0.00}", tahminiButceGelir.TahminiGelirTutari);
                }
                else
                {
                    //Debug.WriteLine($"GelirKategoriLabellarAyarla - Veri bulunamadı, Label 0.00 olarak ayarlandı.");
                    // label.Text = "0.00";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gelir Kategorisi {gelirKategoriId} verilerini yüklerken bir hata oluştu: " + ex.Message);
            }
        }

        // Gelir kategorilerine göre toplam tutarları label'lara yazdır
        private void LoadGiderAltKategoriToplamlari()
        {
            try
            {
                GiderToplami(_seciliKoyIndex, _seciliDonemIndex, 1, lblOdenenAylik);
                GiderToplami(_seciliKoyIndex, _seciliDonemIndex, 2, lblOdenenIdariMasraf);
                GiderToplami(_seciliKoyIndex, _seciliDonemIndex, 3, lblOdenenSulama);
                GiderToplami(_seciliKoyIndex, _seciliDonemIndex, 4, lblOdenenAgaclama);
                GiderToplami(_seciliKoyIndex, _seciliDonemIndex, 5, lblOdenenDamizlik);
                GiderToplami(_seciliKoyIndex, _seciliDonemIndex, 6, lblOdenenOrnekTarla);
                GiderToplami(_seciliKoyIndex, _seciliDonemIndex, 7, lblOdenenZiraiHayvan);
                GiderToplami(_seciliKoyIndex, _seciliDonemIndex, 8, lblOdenenPazarCarsi);
                GiderToplami(_seciliKoyIndex, _seciliDonemIndex, 9, lblOdenenKucukEndustri);
                GiderToplami(_seciliKoyIndex, _seciliDonemIndex, 10, lblOdenenOgretmenevi);
                GiderToplami(_seciliKoyIndex, _seciliDonemIndex, 11, lblOdenenOkulDaimi);
                GiderToplami(_seciliKoyIndex, _seciliDonemIndex, 12, lblOdenenOkumaOdasi);
                GiderToplami(_seciliKoyIndex, _seciliDonemIndex, 13, lblOdenenKurs);
                GiderToplami(_seciliKoyIndex, _seciliDonemIndex, 14, lblOdenenOkulUygulama);
                GiderToplami(_seciliKoyIndex, _seciliDonemIndex, 15, lblOdenenIcmeSulari);
                GiderToplami(_seciliKoyIndex, _seciliDonemIndex, 16, lblOdenenTemizlik);
                GiderToplami(_seciliKoyIndex, _seciliDonemIndex, 17, lblOdenenSpor);
                GiderToplami(_seciliKoyIndex, _seciliDonemIndex, 18, lblOdenenIctimai);
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
                GiderAltKategoriLabellarAyarla(lblBKAylik, 1);
                GiderAltKategoriLabellarAyarla(lblBKIdariMasraf, 2);
                GiderAltKategoriLabellarAyarla(lblBKSulama, 3);
                GiderAltKategoriLabellarAyarla(lblBKAgaclama, 4);
                GiderAltKategoriLabellarAyarla(lblBKDamizlik, 5);
                GiderAltKategoriLabellarAyarla(lblBKOrnekTarla, 6);
                GiderAltKategoriLabellarAyarla(lblBKZiraiHayvan, 7);
                GiderAltKategoriLabellarAyarla(lblBKPazarCarsi, 8);
                GiderAltKategoriLabellarAyarla(lblBKKucukEndustri, 9);
                GiderAltKategoriLabellarAyarla(lblBKOgretmenevi, 10);
                GiderAltKategoriLabellarAyarla(lblBKOkulDaimi, 11);
                GiderAltKategoriLabellarAyarla(lblBKOkumaOdasi, 12);
                GiderAltKategoriLabellarAyarla(lblBKKurs, 13);
                GiderAltKategoriLabellarAyarla(lblBKOkulUygulama, 14);
                GiderAltKategoriLabellarAyarla(lblBKIcmeSulari, 15);
                GiderAltKategoriLabellarAyarla(lblBKTemizlik, 16);
                GiderAltKategoriLabellarAyarla(lblBKSpor, 17);
                GiderAltKategoriLabellarAyarla(lblBKIctimai, 18);
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

        public void AlanlariDoldur(int koyId, byte donemId, byte ilceId)
        {
            Koy secilenKoy = koyManager.GetById(koyId);
            lblKoyAdi.Text = secilenKoy.KoyAdi;
            Ilce secilenIlce = ilceManager.GetById(ilceId);
            lblceAdi.Text = secilenIlce.IlceAdi;
        }

        private void GelirKategoriVerileriYukleVeToplamiHesapla()
        {
            try
            {
                // Gelir kategorisi verilerini ilgili label'lara yazdırma
                GelirKategoriLabellarAyarla(lblBKHasilat, 1);
                GelirKategoriLabellarAyarla(lblBKResim, 2);
                GelirKategoriLabellarAyarla(lblBKCeza, 3);
                GelirKategoriLabellarAyarla(lblBKYardim, 4);
                GelirKategoriLabellarAyarla(lblBKKoyVakif, 5);
                GelirKategoriLabellarAyarla(lblBKIstikraz, 6);
                GelirKategoriLabellarAyarla(lblBKTurluGelir, 7);
                GelirKategoriLabellarAyarla(lblBKDevir, 8);

                // Label'ların Text değerlerini decimal türüne dönüştür ve topla
                decimal toplam = 0;

                toplam += ParseDecimalFromLabel(lblBKHasilat);
                toplam += ParseDecimalFromLabel(lblBKResim);
                toplam += ParseDecimalFromLabel(lblBKCeza);
                toplam += ParseDecimalFromLabel(lblBKYardim);
                toplam += ParseDecimalFromLabel(lblBKKoyVakif);
                toplam += ParseDecimalFromLabel(lblBKIstikraz);
                toplam += ParseDecimalFromLabel(lblBKTurluGelir);
                toplam += ParseDecimalFromLabel(lblBKDevir);

                // Toplamı lblBKResimHarcToplami label'ına yazdır
                lblBKResimHarcToplami.Text = string.Format("{0:#,0.00}", toplam);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Verileri yüklerken veya BK Resim Harc Toplamı hesaplanırken bir hata oluştu: " + ex.Message);
            }
        }

        //AYLIK YILLIK TOPLAMLARINI ALMA
        private void AylikYillikVerileriYukleVeToplamiHesapla()
        {
            try
            {
                // Gider kategorisi verilerini ilgili label'lara yazdırma
                GiderAltKategoriLabellarAyarla(lblBKAylik, 1);
                GiderAltKategoriLabellarAyarla(lblBKIdariMasraf, 2);

                // Label'ların Text değerlerini decimal türüne dönüştür ve topla
                decimal toplam = 0;

                toplam += ParseDecimalFromLabel(lblBKAylik);
                toplam += ParseDecimalFromLabel(lblBKIdariMasraf);

                // Toplamı lblBKResimHarcToplami label'ına yazdır
                lblBKIdariToplami.Text = string.Format("{0:#,0.00}", toplam);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Verileri yüklerken veya BK Resim Harc Toplamı hesaplanırken bir hata oluştu: " + ex.Message);
            }
        }

        private void ZiraaVerileriYukleVeToplamiHesapla()
        {
            try
            {
                // Gider kategorisi verilerini ilgili label'lara yazdırma
                GiderAltKategoriLabellarAyarla(lblBKSulama, 3);
                GiderAltKategoriLabellarAyarla(lblBKAgaclama, 4);
                GiderAltKategoriLabellarAyarla(lblBKDamizlik, 5);
                GiderAltKategoriLabellarAyarla(lblBKOrnekTarla, 6);
                GiderAltKategoriLabellarAyarla(lblBKZiraiHayvan, 7);
                GiderAltKategoriLabellarAyarla(lblBKPazarCarsi, 8);
                GiderAltKategoriLabellarAyarla(lblBKKucukEndustri, 9);

                // Label'ların Text değerlerini decimal türüne dönüştür ve topla
                decimal toplam = 0;

                toplam += ParseDecimalFromLabel(lblBKSulama);
                toplam += ParseDecimalFromLabel(lblBKAgaclama);
                toplam += ParseDecimalFromLabel(lblBKDamizlik);
                toplam += ParseDecimalFromLabel(lblBKOrnekTarla);
                toplam += ParseDecimalFromLabel(lblBKZiraiHayvan);
                toplam += ParseDecimalFromLabel(lblBKPazarCarsi);
                toplam += ParseDecimalFromLabel(lblBKKucukEndustri);

                // Toplamı lblBKResimHarcToplami label'ına yazdır
                lblBKZiraatToplami.Text = string.Format("{0:#,0.00}", toplam);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Verileri yüklerken veya BK Resim Harc Toplamı hesaplanırken bir hata oluştu: " + ex.Message);
            }
        }
        private void KulturVerileriYukleVeToplamiHesapla()
        {
            try
            {
                // Gider kategorisi verilerini ilgili label'lara yazdırma
                GiderAltKategoriLabellarAyarla(lblBKOgretmenevi, 10);
                GiderAltKategoriLabellarAyarla(lblBKOkulDaimi, 11);
                GiderAltKategoriLabellarAyarla(lblBKOkumaOdasi, 12);
                GiderAltKategoriLabellarAyarla(lblBKKurs, 13);
                GiderAltKategoriLabellarAyarla(lblBKOkulUygulama, 14);

                // Label'ların Text değerlerini decimal türüne dönüştür ve topla
                decimal toplam = 0;

                toplam += ParseDecimalFromLabel(lblBKOgretmenevi);
                toplam += ParseDecimalFromLabel(lblBKOkulDaimi);
                toplam += ParseDecimalFromLabel(lblBKOkumaOdasi);
                toplam += ParseDecimalFromLabel(lblBKKurs);
                toplam += ParseDecimalFromLabel(lblBKOkulUygulama);


                // Toplamı lblBKResimHarcToplami label'ına yazdır
                lblBKKulturToplami.Text = string.Format("{0:#,0.00}", toplam);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Verileri yüklerken veya BK Resim Harc Toplamı hesaplanırken bir hata oluştu: " + ex.Message);
            }
        }

        private void SaglikVerileriYukleVeToplamiHesapla()
        {
            try
            {
                // Gider kategorisi verilerini ilgili label'lara yazdırma
                GiderAltKategoriLabellarAyarla(lblBKIcmeSulari, 15);
                GiderAltKategoriLabellarAyarla(lblBKTemizlik, 16);
                GiderAltKategoriLabellarAyarla(lblBKSpor, 17);
                GiderAltKategoriLabellarAyarla(lblBKIctimai, 18);

                // Label'ların Text değerlerini decimal türüne dönüştür ve topla
                decimal toplam = 0;

                toplam += ParseDecimalFromLabel(lblBKIcmeSulari);
                toplam += ParseDecimalFromLabel(lblBKTemizlik);
                toplam += ParseDecimalFromLabel(lblBKSpor);
                toplam += ParseDecimalFromLabel(lblBKIctimai);

                // Toplamı lblBKResimHarcToplami label'ına yazdır
                lblBKSaglikToplami.Text = string.Format("{0:#,0.00}", toplam);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Verileri yüklerken veya BK Resim Harc Toplamı hesaplanırken bir hata oluştu: " + ex.Message);
            }
        }

        // Bir label'ın Text değerini decimal olarak parse eder, hata olursa 0 döner
        private decimal ParseDecimalFromLabel(Label label)
        {
            if (decimal.TryParse(label.Text, out decimal value))
            {
                return value;
            }
            return 0m;
        }

        public void HasilatHesap()
        {
            try
            {
                decimal tahsilHasilat = 0;
                decimal bkHasilat = 0;
                decimal munzamHasilat = 0;
                decimal yekunHasilat = 0;
                decimal devredenHasilat = 0;

                if (!decimal.TryParse(lblTahsilHasilat.Text, NumberStyles.Number, new CultureInfo("tr-TR"), out tahsilHasilat))
                {
                    MessageBox.Show("lblTahsilHasilat.Text geçerli bir sayı değil: " + lblTahsilHasilat.Text);
                    return;
                }

                if (!decimal.TryParse(lblBKHasilat.Text, NumberStyles.Number, new CultureInfo("tr-TR"), out bkHasilat))
                {
                    MessageBox.Show("lblBKHasilat.Text geçerli bir sayı değil: " + lblBKHasilat.Text);
                    return;
                }

                if (tahsilHasilat < bkHasilat)
                {
                    lblMunzamHasilat.Text = "0";
                }
                else
                {
                    munzamHasilat = tahsilHasilat - bkHasilat;
                    lblMunzamHasilat.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", munzamHasilat);
                }

                yekunHasilat = bkHasilat + munzamHasilat;
                lblYekunHasilat.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", yekunHasilat);

                devredenHasilat = yekunHasilat - tahsilHasilat;
                lblDevredenHasilat.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", devredenHasilat);

                lblMunzamHasilat.Visible = !IsZeroOrEmpty(lblMunzamHasilat.Text);
                lblYekunHasilat.Visible = !IsZeroOrEmpty(lblYekunHasilat.Text);
                lblDevredenHasilat.Visible = !IsZeroOrEmpty(lblDevredenHasilat.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Resim, Harç hesapları yapılırken bir hata oluştu: " + ex.Message);
            }
        }

        public void ResimHesap()
        {
            //Debug.WriteLine("ResimHesap başladı");
            try
            {
                decimal tahsilResim = 0;
                decimal bkResim = 0;
                decimal munzamResim = 0;
                decimal yekunResim = 0;
                decimal devredenResim = 0;

                if (!decimal.TryParse(lblTahsilResim.Text, NumberStyles.Number, new CultureInfo("tr-TR"), out tahsilResim))
                {
                    MessageBox.Show("lblTahsilResim.Text geçerli bir sayı değil: " + lblTahsilResim.Text);
                    return;
                }
                //Debug.WriteLine($"tahsilResim: {tahsilResim}");

                if (!decimal.TryParse(lblBKResim.Text, NumberStyles.Number, new CultureInfo("tr-TR"), out bkResim))
                {
                    MessageBox.Show("lblBKResim.Text geçerli bir sayı değil: " + lblBKResim.Text);
                    return;
                }
                //Debug.WriteLine($"bkResim: {bkResim}");

                if (tahsilResim < bkResim)
                {
                    lblMunzamResim.Text = "0";
                    //                   Debug.WriteLine("Tahsil edilen resim BK Resimden küçük, Munzam Resim 0 olarak ayarlandı.");
                }
                else
                {
                    munzamResim = tahsilResim - bkResim;
                    lblMunzamResim.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", munzamResim);
                    //                   Debug.WriteLine($"munzamResim: {munzamResim}");
                }

                yekunResim = bkResim + munzamResim;
                lblYekunResim.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", yekunResim);
                //               Debug.WriteLine($"yekunResim: {yekunResim}");

                devredenResim = yekunResim - tahsilResim;
                lblDevredenResim1.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", devredenResim);
                //              Debug.WriteLine($"devredenResim: {devredenResim}");

                // Visible ayarlarını kontrol et
                lblMunzamResim.Visible = !IsZeroOrEmpty(lblMunzamResim.Text);
                lblYekunResim.Visible = !IsZeroOrEmpty(lblYekunResim.Text);
                lblDevredenResim1.Visible = !IsZeroOrEmpty(lblDevredenResim1.Text);

                //                Debug.WriteLine($"lblDevredenResim1.Text: {lblDevredenResim1.Text}, Visible: {lblDevredenResim1.Visible}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Resim, Harç hesapları yapılırken bir hata oluştu: " + ex.Message);
            }
        }

        public void CezaHesap()
        {
            try
            {
                decimal tahsilCeza = 0;
                decimal bkCeza = 0;
                decimal munzamCeza = 0;
                decimal yekunCeza = 0;
                decimal devredenCeza = 0;

                if (!decimal.TryParse(lblTahsilCeza.Text, out tahsilCeza))
                {
                    MessageBox.Show("lblTahsilCeza.Text geçerli bir sayı değil: " + lblTahsilCeza.Text);
                    return;
                }

                if (!decimal.TryParse(lblBKCeza.Text, out bkCeza))
                {
                    MessageBox.Show("lblBKCeza.Text geçerli bir sayı değil: " + lblBKCeza.Text);
                    return;
                }

                if (tahsilCeza < bkCeza)
                {
                    lblMunzamCeza.Text = "0";
                }
                else
                {
                    munzamCeza = tahsilCeza - bkCeza;
                    lblMunzamCeza.Text = string.Format("{0:#,0.00}", munzamCeza);
                }

                yekunCeza = bkCeza + munzamCeza;
                lblYekunCeza.Text = string.Format("{0:#,0.00}", yekunCeza);

                devredenCeza = yekunCeza - tahsilCeza;
                lblDevredenCeza.Text = string.Format("{0:#,0.00}", devredenCeza);

                lblMunzamCeza.Visible = !IsZeroOrEmpty(lblMunzamCeza.Text);
                lblYekunCeza.Visible = !IsZeroOrEmpty(lblYekunCeza.Text);
                lblDevredenCeza.Visible = !IsZeroOrEmpty(lblDevredenCeza.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ceza hesapları yapılırken bir hata oluştu: " + ex.Message);
            }
        }

        public void YardimHesap()
        {
            try
            {
                decimal tahsilYardim = 0;
                decimal bkYardim = 0;
                decimal munzamYardim = 0;
                decimal yekunYardim = 0;
                decimal devredenYardim = 0;

                if (!decimal.TryParse(lblTahsilYardim.Text, out tahsilYardim))
                {
                    MessageBox.Show("lblTahsilYardim.Text geçerli bir sayı değil: " + lblTahsilYardim.Text);
                    return;
                }

                if (!decimal.TryParse(lblBKYardim.Text, out bkYardim))
                {
                    MessageBox.Show("lblBKYardim.Text geçerli bir sayı değil: " + lblBKYardim.Text);
                    return;
                }

                if (tahsilYardim < bkYardim)
                {
                    lblMunzamYardim.Text = "0";
                }
                else
                {
                    munzamYardim = tahsilYardim - bkYardim;
                    lblMunzamYardim.Text = string.Format("{0:#,0.00}", munzamYardim);
                }

                yekunYardim = bkYardim + munzamYardim;
                lblYekunYardim.Text = string.Format("{0:#,0.00}", yekunYardim);

                devredenYardim = yekunYardim - tahsilYardim;
                lblDevredenYardim.Text = string.Format("{0:#,0.00}", devredenYardim);

                lblMunzamYardim.Visible = !IsZeroOrEmpty(lblMunzamYardim.Text);
                lblYekunYardim.Visible = !IsZeroOrEmpty(lblYekunYardim.Text);
                lblDevredenYardim.Visible = !IsZeroOrEmpty(lblDevredenYardim.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Yardim hesapları yapılırken bir hata oluştu: " + ex.Message);
            }
        }

        public void KoyVakifHesap()
        {
            try
            {
                decimal tahsilKoyVakif = 0;
                decimal bkKoyVakif = 0;
                decimal munzamKoyVakif = 0;
                decimal yekunKoyVakif = 0;
                decimal devredenKoyVakif = 0;

                if (!decimal.TryParse(lblTahsilKoyVakif.Text, out tahsilKoyVakif))
                {
                    MessageBox.Show("lblTahsilKoyVakif.Text geçerli bir sayı değil: " + lblTahsilKoyVakif.Text);
                    return;
                }

                if (!decimal.TryParse(lblBKKoyVakif.Text, out bkKoyVakif))
                {
                    MessageBox.Show("lblBKKoyVakif.Text geçerli bir sayı değil: " + lblBKKoyVakif.Text);
                    return;
                }

                if (tahsilKoyVakif < bkKoyVakif)
                {
                    lblMunzamKoyVakif.Text = "0";
                }
                else
                {
                    munzamKoyVakif = tahsilKoyVakif - bkKoyVakif;
                    lblMunzamKoyVakif.Text = string.Format("{0:#,0.00}", munzamKoyVakif);
                }

                yekunKoyVakif = bkKoyVakif + munzamKoyVakif;
                lblYekunKoyVakif.Text = string.Format("{0:#,0.00}", yekunKoyVakif);

                devredenKoyVakif = yekunKoyVakif - tahsilKoyVakif;
                lblDevredenKoyVakif.Text = string.Format("{0:#,0.00}", devredenKoyVakif);

                lblMunzamKoyVakif.Visible = !IsZeroOrEmpty(lblMunzamKoyVakif.Text);
                lblYekunKoyVakif.Visible = !IsZeroOrEmpty(lblYekunKoyVakif.Text);
                lblDevredenKoyVakif.Visible = !IsZeroOrEmpty(lblDevredenKoyVakif.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Köy Vakıf Avarız hesapları yapılırken bir hata oluştu: " + ex.Message);
            }
        }

        public void IstikrazHesap()
        {
            try
            {
                decimal tahsilIstikraz = 0;
                decimal bkIstikraz = 0;
                decimal munzamIstikraz = 0;
                decimal yekunIstikraz = 0;
                decimal devredenIstikraz = 0;

                if (!decimal.TryParse(lblTahsilIstikraz.Text, out tahsilIstikraz))
                {
                    MessageBox.Show("lblTahsilIstikraz.Text geçerli bir sayı değil: " + lblTahsilIstikraz.Text);
                    return;
                }

                if (!decimal.TryParse(lblBKIstikraz.Text, out bkIstikraz))
                {
                    MessageBox.Show("lblBKIstikraz.Text geçerli bir sayı değil: " + lblBKIstikraz.Text);
                    return;
                }

                if (tahsilIstikraz < bkIstikraz)
                {
                    lblMunzamIstikraz.Text = "0";
                }
                else
                {
                    munzamIstikraz = tahsilIstikraz - bkIstikraz;
                    lblMunzamIstikraz.Text = string.Format("{0:#,0.00}", munzamIstikraz);
                }

                yekunIstikraz = bkIstikraz + munzamIstikraz;
                lblYekunIstikraz.Text = string.Format("{0:#,0.00}", yekunIstikraz);

                devredenIstikraz = yekunIstikraz - tahsilIstikraz;
                lblDevredenIstikraz.Text = string.Format("{0:#,0.00}", devredenIstikraz);

                lblMunzamIstikraz.Visible = !IsZeroOrEmpty(lblMunzamIstikraz.Text);
                lblYekunIstikraz.Visible = !IsZeroOrEmpty(lblYekunIstikraz.Text);
                lblDevredenIstikraz.Visible = !IsZeroOrEmpty(lblDevredenIstikraz.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("İstikraz hesapları yapılırken bir hata oluştu: " + ex.Message);
            }
        }

        public void TurluGelirHesap()
        {
            try
            {
                decimal tahsilTurluGelir = 0;
                decimal bkTurluGelir = 0;
                decimal munzamTurluGelir = 0;
                decimal yekunTurluGelir = 0;
                decimal devredenTurluGelir = 0;

                if (!decimal.TryParse(lblTahsilTurluGelir.Text, out tahsilTurluGelir))
                {
                    MessageBox.Show("lblTahsilTurluGelir.Text geçerli bir sayı değil: " + lblTahsilTurluGelir.Text);
                    return;
                }

                if (!decimal.TryParse(lblBKTurluGelir.Text, out bkTurluGelir))
                {
                    MessageBox.Show("lblBKTurluGelir.Text geçerli bir sayı değil: " + lblBKTurluGelir.Text);
                    return;
                }

                if (tahsilTurluGelir < bkTurluGelir)
                {
                    lblMunzamTurluGelir.Text = "0";
                }
                else
                {
                    munzamTurluGelir = tahsilTurluGelir - bkTurluGelir;
                    lblMunzamTurluGelir.Text = string.Format("{0:#,0.00}", munzamTurluGelir);
                }

                yekunTurluGelir = bkTurluGelir + munzamTurluGelir;
                lblYekunTurluGelir.Text = string.Format("{0:#,0.00}", yekunTurluGelir);

                devredenTurluGelir = yekunTurluGelir - tahsilTurluGelir;
                lblDevredenTurluGelir.Text = string.Format("{0:#,0.00}", devredenTurluGelir);

                lblMunzamTurluGelir.Visible = !IsZeroOrEmpty(lblMunzamTurluGelir.Text);
                lblYekunTurluGelir.Visible = !IsZeroOrEmpty(lblYekunTurluGelir.Text);
                lblDevredenTurluGelir.Visible = !IsZeroOrEmpty(lblDevredenTurluGelir.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Türlü Gelir hesapları yapılırken bir hata oluştu: " + ex.Message);
            }
        }

        public void DevirHesap()
        {
            try
            {
                decimal tahsilDevir = 0;
                decimal bkDevir = 0;
                decimal munzamDevir = 0;
                decimal yekunDevir = 0;
                decimal devredenDevir = 0;

                if (!decimal.TryParse(lblTahsilDevir.Text, out tahsilDevir))
                {
                    MessageBox.Show("lblTahsilDevir.Text geçerli bir sayı değil: " + lblTahsilDevir.Text);
                    return;
                }

                if (!decimal.TryParse(lblBKDevir.Text, out bkDevir))
                {
                    MessageBox.Show("lblBKDevir.Text geçerli bir sayı değil: " + lblBKDevir.Text);
                    return;
                }

                if (tahsilDevir < bkDevir)
                {
                    lblMunzamDevir.Text = "0";
                }
                else
                {
                    munzamDevir = tahsilDevir - bkDevir;
                    lblMunzamDevir.Text = string.Format("{0:#,0.00}", munzamDevir);
                }

                yekunDevir = bkDevir + munzamDevir;
                lblYekunDevir.Text = string.Format("{0:#,0.00}", yekunDevir);

                devredenDevir = yekunDevir - tahsilDevir;
                lblDevredenDevir.Text = string.Format("{0:#,0.00}", devredenDevir);

                lblMunzamDevir.Visible = !IsZeroOrEmpty(lblMunzamDevir.Text);
                lblYekunDevir.Visible = !IsZeroOrEmpty(lblYekunDevir.Text);
                lblDevredenDevir.Visible = !IsZeroOrEmpty(lblDevredenDevir.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Geçen Seneden Devir hesapları yapılırken bir hata oluştu: " + ex.Message);
            }
        }

        private void FrmKesinHesap1_Load(object sender, EventArgs e)
        {
            try
            {
                //Koy, Donem ve İlçe isimlerini getiren metot
                AlanlariDoldur(_seciliKoyIndex, _seciliDonemIndex, _seciliIlceIndex);
                GelirKategoriVerileriYukleVeToplamiHesapla();

                //Gelir kategorilerine göre toplam tutarları label'lara yazdır
                LoadGelirKategoriToplamlari();
                GelirKategoriVerileriYukleVeToplamiHesapla();
                LoadGelirKategoriVerileri();

                LoadGiderAltKategoriVerileri();
                LoadGiderAltKategoriToplamlari();

                AylikYillikVerileriYukleVeToplamiHesapla();
                ZiraaVerileriYukleVeToplamiHesapla();
                KulturVerileriYukleVeToplamiHesapla();
                SaglikVerileriYukleVeToplamiHesapla();

                lblBKResimHarcGenelToplam.Text = lblBKResimHarcToplami.Text;

                //Degisiklik labellarını doldurmak için
                TahminiGelir();
                DegisiklikLabellarıYaz();
                dgvTahminiGelir.Visible = false;

                //              Debug.WriteLine("ResimHesap çağrılmadan önce");
                ResimHesap();
                //               Debug.WriteLine("ResimHesap çağrıldıktan sonra");

                HasilatHesap();
                //ResimHesap();
                CezaHesap();
                YardimHesap();
                KoyVakifHesap();
                IstikrazHesap();
                TurluGelirHesap();
                DevirHesap();

                TahsilToplami();
                YekunToplami();
                DevredenToplami();
                MunzamToplami();

                //GİDERLER
                AylikYillikHesap();
                IdariMasrafHesap();
                SulamaHesap();
                AgaclamaHesap();
                DamizlikHesap();
                OrnekTarlaHesap();
                ZiraiHayvanHesap();
                PazarCarsiHesap();
                KucukEndustriHesap();
                OgretmeneviHesap();
                OkulDaimiHesap();
                OkumaOdasiHesap();
                KursHesap();
                OkulUygulamaHesap();
                IcmeSulariHesap();
                TemizlikHesap();
                SporHesap();
                IctimaiHesap();

                IdariMunzamToplami();
                IdariTahakkukToplami();
                IdariOdenenToplami();
                IdariIptalToplami();
                ZiraatToplamlari();
                KulturToplamlari();
                SaglikToplamlari();

                RakamlariPanelinSaginaYasla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Form yüklenirken bir hata oluştu: " + ex.Message);
            }

        }

        private void RakamlariPanelinSaginaYasla()
        {
            for (int i = 1; i <= 200; i++)
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

        public void MunzamToplami()
        {
            try
            {
                decimal munzamHasilat, munzamResim, munzamCeza, munzamYardim, munzamKoyVakif, munzamIstikraz, munzamTurluGelir, munzamDevir;

                // Her metin kutusunu decimal olarak parse etmeyi deneyin
                if (!decimal.TryParse(lblMunzamHasilat.Text, out munzamHasilat))
                    munzamHasilat = 0;

                if (!decimal.TryParse(lblMunzamResim.Text, out munzamResim))
                    munzamResim = 0;

                if (!decimal.TryParse(lblMunzamCeza.Text, out munzamCeza))
                    munzamCeza = 0;

                if (!decimal.TryParse(lblMunzamYardim.Text, out munzamYardim))
                    munzamYardim = 0;

                if (!decimal.TryParse(lblMunzamKoyVakif.Text, out munzamKoyVakif))
                    munzamKoyVakif = 0;

                if (!decimal.TryParse(lblMunzamIstikraz.Text, out munzamIstikraz))
                    munzamIstikraz = 0;

                if (!decimal.TryParse(lblMunzamTurluGelir.Text, out munzamTurluGelir))
                    munzamTurluGelir = 0;

                if (!decimal.TryParse(lblMunzamDevir.Text, out munzamDevir))
                    munzamDevir = 0;

                // Toplamları hesaplayın
                decimal MunzamToplam = munzamHasilat + munzamResim + munzamCeza + munzamYardim + munzamKoyVakif + munzamIstikraz + munzamTurluGelir + munzamDevir;

                // Sonucu lblTahsilToplami etiketine yazdırın
                lblMunzamToplami.Text = MunzamToplam.ToString("#,0.00");

                lblMunzamGenelToplam.Text = lblMunzamToplami.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        public void YekunToplami()
        {
            try
            {
                decimal yekunHasilat, yekunResim, yekunCeza, yekunYardim, yekunKoyVakif, yekunIstikraz, yekunTurluGelir, yekunDevir;

                // Her metin kutusunu decimal olarak parse etmeyi deneyin
                if (!decimal.TryParse(lblYekunHasilat.Text, out yekunHasilat))
                    yekunHasilat = 0;

                if (!decimal.TryParse(lblYekunResim.Text, out yekunResim))
                    yekunResim = 0;

                if (!decimal.TryParse(lblYekunCeza.Text, out yekunCeza))
                    yekunCeza = 0;

                if (!decimal.TryParse(lblYekunYardim.Text, out yekunYardim))
                    yekunYardim = 0;

                if (!decimal.TryParse(lblYekunKoyVakif.Text, out yekunKoyVakif))
                    yekunKoyVakif = 0;

                if (!decimal.TryParse(lblYekunIstikraz.Text, out yekunIstikraz))
                    yekunIstikraz = 0;

                if (!decimal.TryParse(lblYekunTurluGelir.Text, out yekunTurluGelir))
                    yekunTurluGelir = 0;

                if (!decimal.TryParse(lblYekunDevir.Text, out yekunDevir))
                    yekunDevir = 0;

                // Toplamları hesaplayın
                decimal YekunToplam = yekunHasilat + yekunResim + yekunCeza + yekunYardim + yekunKoyVakif + yekunIstikraz + yekunTurluGelir + yekunDevir;

                // Sonucu lblTahsilToplami etiketine yazdırın
                lblYekunToplami.Text = YekunToplam.ToString("#,0.00");

                lblYekunGenelToplam.Text = lblYekunToplami.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        public void TahsilToplami()
        {
            try
            {
                decimal tahsilHasilat, tahsilResim, tahsilCeza, tahsilYardim, tahsilKoyVakif, tahsilIstikraz, tahsilTurluGelir, tahsilDevir;

                // Her metin kutusunu decimal olarak parse etmeyi deneyin
                if (!decimal.TryParse(lblTahsilHasilat.Text, out tahsilHasilat))
                    tahsilHasilat = 0;

                if (!decimal.TryParse(lblTahsilResim.Text, out tahsilResim))
                    tahsilResim = 0;

                if (!decimal.TryParse(lblTahsilCeza.Text, out tahsilCeza))
                    tahsilCeza = 0;

                if (!decimal.TryParse(lblTahsilYardim.Text, out tahsilYardim))
                    tahsilYardim = 0;

                if (!decimal.TryParse(lblTahsilKoyVakif.Text, out tahsilKoyVakif))
                    tahsilKoyVakif = 0;

                if (!decimal.TryParse(lblTahsilIstikraz.Text, out tahsilIstikraz))
                    tahsilIstikraz = 0;

                if (!decimal.TryParse(lblTahsilTurluGelir.Text, out tahsilTurluGelir))
                    tahsilTurluGelir = 0;

                if (!decimal.TryParse(lblTahsilDevir.Text, out tahsilDevir))
                    tahsilDevir = 0;

                // Toplamları hesaplayın
                decimal TahsilToplam = tahsilHasilat + tahsilResim + tahsilCeza + tahsilYardim + tahsilKoyVakif + tahsilIstikraz + tahsilTurluGelir + tahsilDevir;

                // Sonucu lblTahsilToplami etiketine yazdırın
                lblTahsilToplami.Text = TahsilToplam.ToString("#,0.00");

                lblTahsilGenelToplam.Text = lblTahsilToplami.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        public void DevredenToplami()
        {
            try
            {
                decimal devredenHasilat, devredenResim, devredenCeza, devredenYardim, devredenKoyVakif, devredenIstikraz, devredenTurluGelir, devredenDevir;

                // Her metin kutusunu decimal olarak parse etmeyi deneyin
                if (!decimal.TryParse(lblDevredenHasilat.Text, out devredenHasilat))
                    devredenHasilat = 0;

                if (!decimal.TryParse(lblDevredenResim1.Text, out devredenResim))
                    devredenResim = 0;

                if (!decimal.TryParse(lblDevredenCeza.Text, out devredenCeza))
                    devredenCeza = 0;

                if (!decimal.TryParse(lblDevredenYardim.Text, out devredenYardim))
                    devredenYardim = 0;

                if (!decimal.TryParse(lblDevredenKoyVakif.Text, out devredenKoyVakif))
                    devredenKoyVakif = 0;

                if (!decimal.TryParse(lblDevredenIstikraz.Text, out devredenIstikraz))
                    devredenIstikraz = 0;

                if (!decimal.TryParse(lblDevredenTurluGelir.Text, out devredenTurluGelir))
                    devredenTurluGelir = 0;

                if (!decimal.TryParse(lblDevredenDevir.Text, out devredenDevir))
                    devredenDevir = 0;

                // Toplamları hesaplayın
                decimal DevredenToplam = devredenHasilat + devredenResim + devredenCeza + devredenYardim + devredenKoyVakif + devredenIstikraz + devredenTurluGelir + devredenDevir;

                // Sonucu lblDevredenToplami etiketine yazdırın
                lblDevredenToplami.Text = DevredenToplam.ToString("#,0.00");

                lblDevredenGenelToplami.Text = lblDevredenToplami.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }

        }

        //labellerda 0 olanların visible=false yapmak için metot
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

        public void AylikYillikHesap()
        {
            //Debug.WriteLine("ResimHesap başladı");
            try
            {
                decimal odenenAylik = 0;
                decimal bkAylik = 0;
                decimal munzamAylik = 0;
                decimal tahakkukAylik = 0;
                decimal iptalAylik = 0;

                if (!decimal.TryParse(lblOdenenAylik.Text, NumberStyles.Number, new CultureInfo("tr-TR"), out odenenAylik))
                {
                    MessageBox.Show("lblOdenenAylik.Text geçerli bir sayı değil: " + lblOdenenAylik.Text);
                    return;
                }
                //Debug.WriteLine($"tahsilResim: {tahsilResim}");

                if (!decimal.TryParse(lblBKAylik.Text, NumberStyles.Number, new CultureInfo("tr-TR"), out bkAylik))
                {
                    MessageBox.Show("lblBKAylik.Text geçerli bir sayı değil: " + lblBKAylik.Text);
                    return;
                }
                //Debug.WriteLine($"bkResim: {bkResim}");

                if (bkAylik > odenenAylik)
                {
                    lblMunzamAylik.Text = "0";
                    //                   Debug.WriteLine("Tahsil edilen resim BK Resimden küçük, Munzam Resim 0 olarak ayarlandı.");
                }
                else
                {
                    munzamAylik = odenenAylik - bkAylik;
                    lblMunzamAylik.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", munzamAylik);
                    //                   Debug.WriteLine($"munzamResim: {munzamResim}");
                }

                tahakkukAylik = bkAylik + munzamAylik;
                lblTahakkukAylik.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", tahakkukAylik);
                //               Debug.WriteLine($"yekunResim: {yekunResim}");

                iptalAylik = tahakkukAylik - odenenAylik;
                lblIptalAylik.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", iptalAylik);
                //              Debug.WriteLine($"devredenResim: {devredenResim}");

                // Visible ayarlarını kontrol et
                lblMunzamAylik.Visible = !IsZeroOrEmpty(lblMunzamAylik.Text);
                lblTahakkukAylik.Visible = !IsZeroOrEmpty(lblTahakkukAylik.Text);
                lblIptalAylik.Visible = !IsZeroOrEmpty(lblIptalAylik.Text);

                //                Debug.WriteLine($"lblDevredenResim1.Text: {lblDevredenResim1.Text}, Visible: {lblDevredenResim1.Visible}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Aylik ve Yıllıklar hesapları yapılırken bir hata oluştu: " + ex.Message);
            }
        }

        public void IdariMasrafHesap()
        {
            try
            {
                decimal odenenIdariMasraf = 0;
                decimal bkIdariMasraf = 0;
                decimal munzamIdariMasraf = 0;
                decimal tahakkukIdariMasraf = 0;
                decimal iptalIdariMasraf = 0;

                // Parsing lblOdenenIdariMasraf.Text
                if (!decimal.TryParse(lblOdenenIdariMasraf.Text, NumberStyles.Number, new CultureInfo("tr-TR"), out odenenIdariMasraf))
                {
                    MessageBox.Show("lblOdenenIdariMasraf.Text geçerli bir sayı değil: " + lblOdenenIdariMasraf.Text);
                    return;
                }

                // Parsing lblBKIdariMasraf.Text
                if (!decimal.TryParse(lblBKIdariMasraf.Text, NumberStyles.Number, new CultureInfo("tr-TR"), out bkIdariMasraf))
                {
                    MessageBox.Show("lblBKIdariMasraf.Text geçerli bir sayı değil: " + lblBKIdariMasraf.Text);
                    return;
                }

                // Munzam Idari Masraf Hesaplama
                if (bkIdariMasraf > odenenIdariMasraf)
                {
                    munzamIdariMasraf = 0;
                    lblMunzamIdariMasraf.Text = "0";
                }
                else
                {
                    munzamIdariMasraf = odenenIdariMasraf - bkIdariMasraf;
                    lblMunzamIdariMasraf.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", munzamIdariMasraf);
                }

                // Tahakkuk Idari Masraf Hesaplama
                tahakkukIdariMasraf = bkIdariMasraf + munzamIdariMasraf;
                lblTahakkukIdariMasraf.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", tahakkukIdariMasraf);

                // Iptal Idari Masraf Hesaplama
                iptalIdariMasraf = tahakkukIdariMasraf - odenenIdariMasraf;
                lblIptalIdariMasraf.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", iptalIdariMasraf);

                // Visible ayarlarını kontrol et
                lblMunzamIdariMasraf.Visible = !IsZeroOrEmpty(lblMunzamIdariMasraf.Text);
                lblTahakkukIdariMasraf.Visible = !IsZeroOrEmpty(lblTahakkukIdariMasraf.Text);
                lblIptalIdariMasraf.Visible = !IsZeroOrEmpty(lblIptalIdariMasraf.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(" İdari Masraf hesapları yapılırken bir hata oluştu: " + ex.Message);
            }
        }

        public void SulamaHesap()
        {
            try
            {
                decimal odenenSulama = 0;
                decimal bkSulama = 0;
                decimal munzamSulama = 0;
                decimal tahakkukSulama = 0;
                decimal iptalSulama = 0;

                if (!decimal.TryParse(lblOdenenSulama.Text, NumberStyles.Number, new CultureInfo("tr-TR"), out odenenSulama))
                {
                    MessageBox.Show("lblOdenenSulama.Text geçerli bir sayı değil: " + lblOdenenSulama.Text);
                    return;
                }

                if (!decimal.TryParse(lblBKSulama.Text, NumberStyles.Number, new CultureInfo("tr-TR"), out bkSulama))
                {
                    MessageBox.Show("lblBKSulama.Text geçerli bir sayı değil: " + lblBKSulama.Text);
                    return;
                }

                if (bkSulama > odenenSulama)
                {
                    lblMunzamSulama.Text = "0";
                }
                else
                {
                    munzamSulama = odenenSulama - bkSulama;
                    lblMunzamSulama.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", munzamSulama);
                }

                tahakkukSulama = bkSulama + munzamSulama;
                lblTahakkukSulama.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", tahakkukSulama);

                iptalSulama = tahakkukSulama - odenenSulama;
                lblIptalSulama.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", iptalSulama);

                // Visible ayarlarını kontrol et
                lblMunzamSulama.Visible = !IsZeroOrEmpty(lblMunzamSulama.Text);
                lblTahakkukSulama.Visible = !IsZeroOrEmpty(lblTahakkukSulama.Text);
                lblIptalSulama.Visible = !IsZeroOrEmpty(lblIptalSulama.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Sulama hesapları yapılırken bir hata oluştu: " + ex.Message);
            }
        }

        public void AgaclamaHesap()
        {
            try
            {
                decimal odenenAgaclama = 0;
                decimal bkAgaclama = 0;
                decimal munzamAgaclama = 0;
                decimal tahakkukAgaclama = 0;
                decimal iptalAgaclama = 0;

                if (!decimal.TryParse(lblOdenenAgaclama.Text, NumberStyles.Number, new CultureInfo("tr-TR"), out odenenAgaclama))
                {
                    MessageBox.Show("lblOdenenAgaclama.Text geçerli bir sayı değil: " + lblOdenenAgaclama.Text);
                    return;
                }

                if (!decimal.TryParse(lblBKAgaclama.Text, NumberStyles.Number, new CultureInfo("tr-TR"), out bkAgaclama))
                {
                    MessageBox.Show("lblBKAgaclama.Text geçerli bir sayı değil: " + lblBKAgaclama.Text);
                    return;
                }

                if (bkAgaclama > odenenAgaclama)
                {
                    lblMunzamAgaclama.Text = "0";
                }
                else
                {
                    munzamAgaclama = odenenAgaclama - bkAgaclama;
                    lblMunzamAgaclama.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", munzamAgaclama);
                }

                tahakkukAgaclama = bkAgaclama + munzamAgaclama;
                lblTahakkukAgaclama.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", tahakkukAgaclama);

                iptalAgaclama = tahakkukAgaclama - odenenAgaclama;
                lblIptalAgaclama.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", iptalAgaclama);

                // Visible ayarlarını kontrol et
                lblMunzamAgaclama.Visible = !IsZeroOrEmpty(lblMunzamAgaclama.Text);
                lblTahakkukAgaclama.Visible = !IsZeroOrEmpty(lblTahakkukAgaclama.Text);
                lblIptalAgaclama.Visible = !IsZeroOrEmpty(lblIptalAgaclama.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Ağaclama hesapları yapılırken bir hata oluştu: " + ex.Message);
            }
        }

        public void DamizlikHesap()
        {
            try
            {
                decimal odenenDamizlik = 0;
                decimal bkDamizlik = 0;
                decimal munzamDamizlik = 0;
                decimal tahakkukDamizlik = 0;
                decimal iptalDamizlik = 0;

                if (!decimal.TryParse(lblOdenenDamizlik.Text, NumberStyles.Number, new CultureInfo("tr-TR"), out odenenDamizlik))
                {
                    MessageBox.Show("lblOdenenDamizlik.Text geçerli bir sayı değil: " + lblOdenenDamizlik.Text);
                    return;
                }

                if (!decimal.TryParse(lblBKDamizlik.Text, NumberStyles.Number, new CultureInfo("tr-TR"), out bkDamizlik))
                {
                    MessageBox.Show("lblBKDamizlik.Text geçerli bir sayı değil: " + lblBKDamizlik.Text);
                    return;
                }

                if (bkDamizlik > odenenDamizlik)
                {
                    lblMunzamDamizlik.Text = "0";
                }
                else
                {
                    munzamDamizlik = odenenDamizlik - bkDamizlik;
                    lblMunzamDamizlik.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", munzamDamizlik);
                }

                tahakkukDamizlik = bkDamizlik + munzamDamizlik;
                lblTahakkukDamizlik.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", tahakkukDamizlik);

                iptalDamizlik = tahakkukDamizlik - odenenDamizlik;
                lblIptalDamizlik.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", iptalDamizlik);

                // Visible ayarlarını kontrol et
                lblMunzamDamizlik.Visible = !IsZeroOrEmpty(lblMunzamDamizlik.Text);
                lblTahakkukDamizlik.Visible = !IsZeroOrEmpty(lblTahakkukDamizlik.Text);
                lblIptalDamizlik.Visible = !IsZeroOrEmpty(lblIptalDamizlik.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Damizlik hesapları yapılırken bir hata oluştu: " + ex.Message);
            }
        }

        public void OrnekTarlaHesap()
        {
            try
            {
                decimal odenenOrnekTarla = 0;
                decimal bkOrnekTarla = 0;
                decimal munzamOrnekTarla = 0;
                decimal tahakkukOrnekTarla = 0;
                decimal iptalOrnekTarla = 0;

                if (!decimal.TryParse(lblOdenenOrnekTarla.Text, NumberStyles.Number, new CultureInfo("tr-TR"), out odenenOrnekTarla))
                {
                    MessageBox.Show("lblOdenenOrnekTarla.Text geçerli bir sayı değil: " + lblOdenenOrnekTarla.Text);
                    return;
                }

                if (!decimal.TryParse(lblBKOrnekTarla.Text, NumberStyles.Number, new CultureInfo("tr-TR"), out bkOrnekTarla))
                {
                    MessageBox.Show("lblBKOrnekTarla.Text geçerli bir sayı değil: " + lblBKOrnekTarla.Text);
                    return;
                }

                if (bkOrnekTarla > odenenOrnekTarla)
                {
                    lblMunzamOrnekTarla.Text = "0";
                }
                else
                {
                    munzamOrnekTarla = odenenOrnekTarla - bkOrnekTarla;
                    lblMunzamOrnekTarla.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", munzamOrnekTarla);
                }

                tahakkukOrnekTarla = bkOrnekTarla + munzamOrnekTarla;
                lblTahakkukOrnekTarla.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", tahakkukOrnekTarla);

                iptalOrnekTarla = tahakkukOrnekTarla - odenenOrnekTarla;
                lblIptalOrnekTarla.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", iptalOrnekTarla);

                // Visible ayarlarını kontrol et
                lblMunzamOrnekTarla.Visible = !IsZeroOrEmpty(lblMunzamOrnekTarla.Text);
                lblTahakkukOrnekTarla.Visible = !IsZeroOrEmpty(lblTahakkukOrnekTarla.Text);
                lblIptalOrnekTarla.Visible = !IsZeroOrEmpty(lblIptalOrnekTarla.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Örnek Tarla hesapları yapılırken bir hata oluştu: " + ex.Message);
            }
        }

        public void ZiraiHayvanHesap()
        {
            try
            {
                decimal odenenZiraiHayvan = 0;
                decimal bkZiraiHayvan = 0;
                decimal munzamZiraiHayvan = 0;
                decimal tahakkukZiraiHayvan = 0;
                decimal iptalZiraiHayvan = 0;

                if (!decimal.TryParse(lblOdenenZiraiHayvan.Text, NumberStyles.Number, new CultureInfo("tr-TR"), out odenenZiraiHayvan))
                {
                    MessageBox.Show("lblOdenenZiraiHayvan.Text geçerli bir sayı değil: " + lblOdenenZiraiHayvan.Text);
                    return;
                }

                if (!decimal.TryParse(lblBKZiraiHayvan.Text, NumberStyles.Number, new CultureInfo("tr-TR"), out bkZiraiHayvan))
                {
                    MessageBox.Show("lblBKZiraiHayvan.Text geçerli bir sayı değil: " + lblBKZiraiHayvan.Text);
                    return;
                }

                if (bkZiraiHayvan > odenenZiraiHayvan)
                {
                    lblMunzamZiraiHayvan.Text = "0";
                }
                else
                {
                    munzamZiraiHayvan = odenenZiraiHayvan - bkZiraiHayvan;
                    lblMunzamZiraiHayvan.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", munzamZiraiHayvan);
                }

                tahakkukZiraiHayvan = bkZiraiHayvan + munzamZiraiHayvan;
                lblTahakkukZiraiHayvan.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", tahakkukZiraiHayvan);

                iptalZiraiHayvan = tahakkukZiraiHayvan - odenenZiraiHayvan;
                lblIptalZiraiHayvan.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", iptalZiraiHayvan);

                // Visible ayarlarını kontrol et
                lblMunzamZiraiHayvan.Visible = !IsZeroOrEmpty(lblMunzamZiraiHayvan.Text);
                lblTahakkukZiraiHayvan.Visible = !IsZeroOrEmpty(lblTahakkukZiraiHayvan.Text);
                lblIptalZiraiHayvan.Visible = !IsZeroOrEmpty(lblIptalZiraiHayvan.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Zirai Hayvan hesapları yapılırken bir hata oluştu: " + ex.Message);
            }
        }

        public void PazarCarsiHesap()
        {
            try
            {
                decimal odenenPazarCarsi = 0;
                decimal bkPazarCarsi = 0;
                decimal munzamPazarCarsi = 0;
                decimal tahakkukPazarCarsi = 0;
                decimal iptalPazarCarsi = 0;

                if (!decimal.TryParse(lblOdenenPazarCarsi.Text, NumberStyles.Number, new CultureInfo("tr-TR"), out odenenPazarCarsi))
                {
                    MessageBox.Show("lblOdenenPazarCarsi.Text geçerli bir sayı değil: " + lblOdenenPazarCarsi.Text);
                    return;
                }

                if (!decimal.TryParse(lblBKPazarCarsi.Text, NumberStyles.Number, new CultureInfo("tr-TR"), out bkPazarCarsi))
                {
                    MessageBox.Show("lblBKPazarCarsi.Text geçerli bir sayı değil: " + lblBKPazarCarsi.Text);
                    return;
                }

                if (bkPazarCarsi > odenenPazarCarsi)
                {
                    lblMunzamPazarCarsi.Text = "0";
                }
                else
                {
                    munzamPazarCarsi = odenenPazarCarsi - bkPazarCarsi;
                    lblMunzamPazarCarsi.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", munzamPazarCarsi);
                }

                tahakkukPazarCarsi = bkPazarCarsi + munzamPazarCarsi;
                lblTahakkukPazarCarsi.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", tahakkukPazarCarsi);

                iptalPazarCarsi = tahakkukPazarCarsi - odenenPazarCarsi;
                lblIptalPazarCarsi.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", iptalPazarCarsi);

                // Visible ayarlarını kontrol et
                lblMunzamPazarCarsi.Visible = !IsZeroOrEmpty(lblMunzamPazarCarsi.Text);
                lblTahakkukPazarCarsi.Visible = !IsZeroOrEmpty(lblTahakkukPazarCarsi.Text);
                lblIptalPazarCarsi.Visible = !IsZeroOrEmpty(lblIptalPazarCarsi.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Pazar Çarsi hesapları yapılırken bir hata oluştu: " + ex.Message);
            }
        }

        public void KucukEndustriHesap()
        {
            try
            {
                decimal odenenKucukEndustri = 0;
                decimal bkKucukEndustri = 0;
                decimal munzamKucukEndustri = 0;
                decimal tahakkukKucukEndustri = 0;
                decimal iptalKucukEndustri = 0;

                if (!decimal.TryParse(lblOdenenKucukEndustri.Text, NumberStyles.Number, new CultureInfo("tr-TR"), out odenenKucukEndustri))
                {
                    MessageBox.Show("lblOdenenKucukEndustri.Text geçerli bir sayı değil: " + lblOdenenKucukEndustri.Text);
                    return;
                }

                if (!decimal.TryParse(lblBKKucukEndustri.Text, NumberStyles.Number, new CultureInfo("tr-TR"), out bkKucukEndustri))
                {
                    MessageBox.Show("lblBKKucukEndustri.Text geçerli bir sayı değil: " + lblBKKucukEndustri.Text);
                    return;
                }

                if (bkKucukEndustri > odenenKucukEndustri)
                {
                    lblMunzamKucukEndustri.Text = "0";
                }
                else
                {
                    munzamKucukEndustri = odenenKucukEndustri - bkKucukEndustri;
                    lblMunzamKucukEndustri.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", munzamKucukEndustri);
                }

                tahakkukKucukEndustri = bkKucukEndustri + munzamKucukEndustri;
                lblTahakkukKucukEndustri.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", tahakkukKucukEndustri);

                iptalKucukEndustri = tahakkukKucukEndustri - odenenKucukEndustri;
                lblIptalKucukEndustri.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", iptalKucukEndustri);

                // Visible ayarlarını kontrol et
                lblMunzamKucukEndustri.Visible = !IsZeroOrEmpty(lblMunzamKucukEndustri.Text);
                lblTahakkukKucukEndustri.Visible = !IsZeroOrEmpty(lblTahakkukKucukEndustri.Text);
                lblIptalKucukEndustri.Visible = !IsZeroOrEmpty(lblIptalKucukEndustri.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Küçük Endustri hesapları yapılırken bir hata oluştu: " + ex.Message);
            }
        }

        public void OgretmeneviHesap()
        {
            try
            {
                decimal odenenOgretmenevi = 0;
                decimal bkOgretmenevi = 0;
                decimal munzamOgretmenevi = 0;
                decimal tahakkukOgretmenevi = 0;
                decimal iptalOgretmenevi = 0;

                if (!decimal.TryParse(lblOdenenOgretmenevi.Text, NumberStyles.Number, new CultureInfo("tr-TR"), out odenenOgretmenevi))
                {
                    MessageBox.Show("lblOdenenOgretmenevi.Text geçerli bir sayı değil: " + lblOdenenOgretmenevi.Text);
                    return;
                }

                if (!decimal.TryParse(lblBKOgretmenevi.Text, NumberStyles.Number, new CultureInfo("tr-TR"), out bkOgretmenevi))
                {
                    MessageBox.Show("lblBKOgretmenevi.Text geçerli bir sayı değil: " + lblBKOgretmenevi.Text);
                    return;
                }

                if (bkOgretmenevi > odenenOgretmenevi)
                {
                    lblMunzamOgretmenevi.Text = "0";
                }
                else
                {
                    munzamOgretmenevi = odenenOgretmenevi - bkOgretmenevi;
                    lblMunzamOgretmenevi.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", munzamOgretmenevi);
                }

                tahakkukOgretmenevi = bkOgretmenevi + munzamOgretmenevi;
                lblTahakkukOgretmenevi.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", tahakkukOgretmenevi);

                iptalOgretmenevi = tahakkukOgretmenevi - odenenOgretmenevi;
                lblIptalOgretmenevi.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", iptalOgretmenevi);

                // Visible ayarlarını kontrol et
                lblMunzamOgretmenevi.Visible = !IsZeroOrEmpty(lblMunzamOgretmenevi.Text);
                lblTahakkukOgretmenevi.Visible = !IsZeroOrEmpty(lblTahakkukOgretmenevi.Text);
                lblIptalOgretmenevi.Visible = !IsZeroOrEmpty(lblIptalOgretmenevi.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Öğretmenevi hesapları yapılırken bir hata oluştu: " + ex.Message);
            }
        }

        public void OkulDaimiHesap()
        {
            try
            {
                decimal odenenOkulDaimi = 0;
                decimal bkOkulDaimi = 0;
                decimal munzamOkulDaimi = 0;
                decimal tahakkukOkulDaimi = 0;
                decimal iptalOkulDaimi = 0;

                if (!decimal.TryParse(lblOdenenOkulDaimi.Text, NumberStyles.Number, new CultureInfo("tr-TR"), out odenenOkulDaimi))
                {
                    MessageBox.Show("lblOdenenOkulDaimi.Text geçerli bir sayı değil: " + lblOdenenOkulDaimi.Text);
                    return;
                }

                if (!decimal.TryParse(lblBKOkulDaimi.Text, NumberStyles.Number, new CultureInfo("tr-TR"), out bkOkulDaimi))
                {
                    MessageBox.Show("lblBKOkulDaimi.Text geçerli bir sayı değil: " + lblBKOkulDaimi.Text);
                    return;
                }

                if (bkOkulDaimi > odenenOkulDaimi)
                {
                    lblMunzamOkulDaimi.Text = "0";
                }
                else
                {
                    munzamOkulDaimi = odenenOkulDaimi - bkOkulDaimi;
                    lblMunzamOkulDaimi.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", munzamOkulDaimi);
                }

                tahakkukOkulDaimi = bkOkulDaimi + munzamOkulDaimi;
                lblTahakkukOkulDaimi.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", tahakkukOkulDaimi);

                iptalOkulDaimi = tahakkukOkulDaimi - odenenOkulDaimi;
                lblIptalOkulDaimi.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", iptalOkulDaimi);

                // Visible ayarlarını kontrol et
                lblMunzamOkulDaimi.Visible = !IsZeroOrEmpty(lblMunzamOkulDaimi.Text);
                lblTahakkukOkulDaimi.Visible = !IsZeroOrEmpty(lblTahakkukOkulDaimi.Text);
                lblIptalOkulDaimi.Visible = !IsZeroOrEmpty(lblIptalOkulDaimi.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Okul Daimi hesapları yapılırken bir hata oluştu: " + ex.Message);
            }
        }

        public void OkumaOdasiHesap()
        {
            try
            {
                decimal odenenOkumaOdasi = 0;
                decimal bkOkumaOdasi = 0;
                decimal munzamOkumaOdasi = 0;
                decimal tahakkukOkumaOdasi = 0;
                decimal iptalOkumaOdasi = 0;

                if (!decimal.TryParse(lblOdenenOkumaOdasi.Text, NumberStyles.Number, new CultureInfo("tr-TR"), out odenenOkumaOdasi))
                {
                    MessageBox.Show("lblOdenenOkumaOdasi.Text geçerli bir sayı değil: " + lblOdenenOkumaOdasi.Text);
                    return;
                }

                if (!decimal.TryParse(lblBKOkumaOdasi.Text, NumberStyles.Number, new CultureInfo("tr-TR"), out bkOkumaOdasi))
                {
                    MessageBox.Show("lblBKOkumaOdasi.Text geçerli bir sayı değil: " + lblBKOkumaOdasi.Text);
                    return;
                }

                if (bkOkumaOdasi > odenenOkumaOdasi)
                {
                    lblMunzamOkumaOdasi.Text = "0";
                }
                else
                {
                    munzamOkumaOdasi = odenenOkumaOdasi - bkOkumaOdasi;
                    lblMunzamOkumaOdasi.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", munzamOkumaOdasi);
                }

                tahakkukOkumaOdasi = bkOkumaOdasi + munzamOkumaOdasi;
                lblTahakkukOkumaOdasi.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", tahakkukOkumaOdasi);

                iptalOkumaOdasi = tahakkukOkumaOdasi - odenenOkumaOdasi;
                lblIptalOkumaOdasi.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", iptalOkumaOdasi);

                // Visible ayarlarını kontrol et
                lblMunzamOkumaOdasi.Visible = !IsZeroOrEmpty(lblMunzamOkumaOdasi.Text);
                lblTahakkukOkumaOdasi.Visible = !IsZeroOrEmpty(lblTahakkukOkumaOdasi.Text);
                lblIptalOkumaOdasi.Visible = !IsZeroOrEmpty(lblIptalOkumaOdasi.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Okuma Odası hesapları yapılırken bir hata oluştu: " + ex.Message);
            }
        }

        public void KursHesap()
        {
            try
            {
                decimal odenenKurs = 0;
                decimal bkKurs = 0;
                decimal munzamKurs = 0;
                decimal tahakkukKurs = 0;
                decimal iptalKurs = 0;

                if (!decimal.TryParse(lblOdenenKurs.Text, NumberStyles.Number, new CultureInfo("tr-TR"), out odenenKurs))
                {
                    MessageBox.Show("lblOdenenKurs.Text geçerli bir sayı değil: " + lblOdenenKurs.Text);
                    return;
                }

                if (!decimal.TryParse(lblBKKurs.Text, NumberStyles.Number, new CultureInfo("tr-TR"), out bkKurs))
                {
                    MessageBox.Show("lblBK.Text geçerli bir sayı değil: " + lblBKKurs.Text);
                    return;
                }

                if (bkKurs > odenenKurs)
                {
                    lblMunzamKurs.Text = "0";
                }
                else
                {
                    munzamKurs = odenenKurs - bkKurs;
                    lblMunzamKurs.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", munzamKurs);
                }

                tahakkukKurs = bkKurs + munzamKurs;
                lblTahakkukKurs.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", tahakkukKurs);

                iptalKurs = tahakkukKurs - odenenKurs;
                lblIptalKurs.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", iptalKurs);

                // Visible ayarlarını kontrol et
                lblMunzamKurs.Visible = !IsZeroOrEmpty(lblMunzamKurs.Text);
                lblTahakkukKurs.Visible = !IsZeroOrEmpty(lblTahakkukKurs.Text);
                lblIptalKurs.Visible = !IsZeroOrEmpty(lblIptalKurs.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kurs hesapları yapılırken bir hata oluştu: " + ex.Message);
            }
        }

        public void OkulUygulamaHesap()
        {
            try
            {
                decimal odenenOkulUygulama = 0;
                decimal bkOkulUygulama = 0;
                decimal munzamOkulUygulama = 0;
                decimal tahakkukOkulUygulama = 0;
                decimal iptalOkulUygulama = 0;

                if (!decimal.TryParse(lblOdenenOkulUygulama.Text, NumberStyles.Number, new CultureInfo("tr-TR"), out odenenOkulUygulama))
                {
                    MessageBox.Show("lblOdenenOkulUygulama.Text geçerli bir sayı değil: " + lblOdenenOkulUygulama.Text);
                    return;
                }

                if (!decimal.TryParse(lblBKOkulUygulama.Text, NumberStyles.Number, new CultureInfo("tr-TR"), out bkOkulUygulama))
                {
                    MessageBox.Show("lblBKOkulUygulama.Text geçerli bir sayı değil: " + lblBKOkulUygulama.Text);
                    return;
                }

                if (bkOkulUygulama > odenenOkulUygulama)
                {
                    lblMunzamOkulUygulama.Text = "0";
                }
                else
                {
                    munzamOkulUygulama = odenenOkulUygulama - bkOkulUygulama;
                    lblMunzamOkulUygulama.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", munzamOkulUygulama);
                }

                tahakkukOkulUygulama = bkOkulUygulama + munzamOkulUygulama;
                lblTahakkukOkulUygulama.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", tahakkukOkulUygulama);

                iptalOkulUygulama = tahakkukOkulUygulama - odenenOkulUygulama;
                lblIptalOkulUygulama.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", iptalOkulUygulama);

                // Visible ayarlarını kontrol et
                lblMunzamOkulUygulama.Visible = !IsZeroOrEmpty(lblMunzamOkulUygulama.Text);
                lblTahakkukOkulUygulama.Visible = !IsZeroOrEmpty(lblTahakkukOkulUygulama.Text);
                lblIptalOkulUygulama.Visible = !IsZeroOrEmpty(lblIptalOkulUygulama.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("OkulUygulama hesapları yapılırken bir hata oluştu: " + ex.Message);
            }
        }

        public void IcmeSulariHesap()
        {
            try
            {
                decimal odenenIcmeSulari = 0;
                decimal bkIcmeSulari = 0;
                decimal munzamIcmeSulari = 0;
                decimal tahakkukIcmeSulari = 0;
                decimal iptalIcmeSulari = 0;

                if (!decimal.TryParse(lblOdenenIcmeSulari.Text, NumberStyles.Number, new CultureInfo("tr-TR"), out odenenIcmeSulari))
                {
                    MessageBox.Show("lblOdenenIcmeSulari.Text geçerli bir sayı değil: " + lblOdenenIcmeSulari.Text);
                    return;
                }

                if (!decimal.TryParse(lblBKIcmeSulari.Text, NumberStyles.Number, new CultureInfo("tr-TR"), out bkIcmeSulari))
                {
                    MessageBox.Show("lblBKIcmeSulari.Text geçerli bir sayı değil: " + lblBKIcmeSulari.Text);
                    return;
                }

                if (bkIcmeSulari > odenenIcmeSulari)
                {
                    lblMunzamIcmeSulari.Text = "0";
                }
                else
                {
                    munzamIcmeSulari = odenenIcmeSulari - bkIcmeSulari;
                    lblMunzamIcmeSulari.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", munzamIcmeSulari);
                }

                tahakkukIcmeSulari = bkIcmeSulari + munzamIcmeSulari;
                lblTahakkukIcmeSulari.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", tahakkukIcmeSulari);

                iptalIcmeSulari = tahakkukIcmeSulari - odenenIcmeSulari;
                lblIptalIcmeSulari.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", iptalIcmeSulari);

                // Visible ayarlarını kontrol et
                lblMunzamIcmeSulari.Visible = !IsZeroOrEmpty(lblMunzamIcmeSulari.Text);
                lblTahakkukIcmeSulari.Visible = !IsZeroOrEmpty(lblTahakkukIcmeSulari.Text);
                lblIptalIcmeSulari.Visible = !IsZeroOrEmpty(lblIptalIcmeSulari.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("İçme Suları hesapları yapılırken bir hata oluştu: " + ex.Message);
            }
        }

        public void TemizlikHesap()
        {
            try
            {
                decimal odenenTemizlik = 0;
                decimal bkTemizlik = 0;
                decimal munzamTemizlik = 0;
                decimal tahakkukTemizlik = 0;
                decimal iptalTemizlik = 0;

                if (!decimal.TryParse(lblOdenenTemizlik.Text, NumberStyles.Number, new CultureInfo("tr-TR"), out odenenTemizlik))
                {
                    MessageBox.Show("lblOdenenTemizlik.Text geçerli bir sayı değil: " + lblOdenenTemizlik.Text);
                    return;
                }

                if (!decimal.TryParse(lblBKTemizlik.Text, NumberStyles.Number, new CultureInfo("tr-TR"), out bkTemizlik))
                {
                    MessageBox.Show("lblBKTemizlik.Text geçerli bir sayı değil: " + lblBKTemizlik.Text);
                    return;
                }

                if (bkTemizlik > odenenTemizlik)
                {
                    lblMunzamTemizlik.Text = "0";
                }
                else
                {
                    munzamTemizlik = odenenTemizlik - bkTemizlik;
                    lblMunzamTemizlik.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", munzamTemizlik);
                }

                tahakkukTemizlik = bkTemizlik + munzamTemizlik;
                lblTahakkukTemizlik.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", tahakkukTemizlik);

                iptalTemizlik = tahakkukTemizlik - odenenTemizlik;
                lblIptalTemizlik.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", iptalTemizlik);

                // Visible ayarlarını kontrol et
                lblMunzamTemizlik.Visible = !IsZeroOrEmpty(lblMunzamTemizlik.Text);
                lblTahakkukTemizlik.Visible = !IsZeroOrEmpty(lblTahakkukTemizlik.Text);
                lblIptalTemizlik.Visible = !IsZeroOrEmpty(lblIptalTemizlik.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Temizlik hesapları yapılırken bir hata oluştu: " + ex.Message);
            }
        }

        public void SporHesap()
        {
            try
            {
                decimal odenenSpor = 0;
                decimal bkSpor = 0;
                decimal munzamSpor = 0;
                decimal tahakkukSpor = 0;
                decimal iptalSpor = 0;

                if (!decimal.TryParse(lblOdenenSpor.Text, NumberStyles.Number, new CultureInfo("tr-TR"), out odenenSpor))
                {
                    MessageBox.Show("lblOdenenSpor.Text geçerli bir sayı değil: " + lblOdenenSpor.Text);
                    return;
                }

                if (!decimal.TryParse(lblBKSpor.Text, NumberStyles.Number, new CultureInfo("tr-TR"), out bkSpor))
                {
                    MessageBox.Show("lblBKSpor.Text geçerli bir sayı değil: " + lblBKSpor.Text);
                    return;
                }

                if (bkSpor > odenenSpor)
                {
                    lblMunzamSpor.Text = "0";
                }
                else
                {
                    munzamSpor = odenenSpor - bkSpor;
                    lblMunzamSpor.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", munzamSpor);
                }

                tahakkukSpor = bkSpor + munzamSpor;
                lblTahakkukSpor.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", tahakkukSpor);

                iptalSpor = tahakkukSpor - odenenSpor;
                lblIptalSpor.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", iptalSpor);

                // Visible ayarlarını kontrol et
                lblMunzamSpor.Visible = !IsZeroOrEmpty(lblMunzamSpor.Text);
                lblTahakkukSpor.Visible = !IsZeroOrEmpty(lblTahakkukSpor.Text);
                lblIptalSpor.Visible = !IsZeroOrEmpty(lblIptalSpor.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Spor hesapları yapılırken bir hata oluştu: " + ex.Message);
            }
        }

        public void IctimaiHesap()
        {
            try
            {
                decimal odenenIctimai = 0;
                decimal bkIctimai = 0;
                decimal munzamIctimai = 0;
                decimal tahakkukIctimai = 0;
                decimal iptalIctimai = 0;

                if (!decimal.TryParse(lblOdenenIctimai.Text, NumberStyles.Number, new CultureInfo("tr-TR"), out odenenIctimai))
                {
                    MessageBox.Show("lblOdenenIctimai.Text geçerli bir sayı değil: " + lblOdenenIctimai.Text);
                    return;
                }

                if (!decimal.TryParse(lblBKIctimai.Text, NumberStyles.Number, new CultureInfo("tr-TR"), out bkIctimai))
                {
                    MessageBox.Show("lblBK.Text geçerli bir sayı değil: " + lblBKIctimai.Text);
                    return;
                }

                if (bkIctimai > odenenIctimai)
                {
                    lblMunzamIctimai.Text = "0";
                }
                else
                {
                    munzamIctimai = odenenIctimai - bkIctimai;
                    lblMunzamIctimai.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", munzamIctimai);
                }

                tahakkukIctimai = bkIctimai + munzamIctimai;
                lblTahakkukIctimai.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", tahakkukIctimai);

                iptalIctimai = tahakkukIctimai - odenenIctimai;
                lblIptalIctimai.Text = string.Format(new CultureInfo("tr-TR"), "{0:#,0.00}", iptalIctimai);

                // Visible ayarlarını kontrol et
                lblMunzamIctimai.Visible = !IsZeroOrEmpty(lblMunzamIctimai.Text);
                lblTahakkukIctimai.Visible = !IsZeroOrEmpty(lblTahakkukIctimai.Text);
                lblIptalIctimai.Visible = !IsZeroOrEmpty(lblIptalIctimai.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("İçtimai hesapları yapılırken bir hata oluştu: " + ex.Message);
            }
        }

        public void IdariMunzamToplami()
        {
            try
            {
                decimal munzamAylik, munzamIdariMasraf;

                // Her metin kutusunu decimal olarak parse etmeyi deneyin
                if (!decimal.TryParse(lblMunzamAylik.Text, out munzamAylik))
                    munzamAylik = 0;

                if (!decimal.TryParse(lblMunzamIdariMasraf.Text, out munzamIdariMasraf))
                    munzamIdariMasraf = 0;

                // Toplamları hesaplayın
                decimal MunzamIdariToplami = munzamAylik + munzamIdariMasraf;

                // Sonucu lblTahsilToplami etiketine yazdırın
                lblMunzamIdariToplami.Text = MunzamIdariToplami.ToString("#,0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        public void IdariTahakkukToplami()
        {
            try
            {
                decimal tahakkukAylik, tahakkukIdariMasraf;

                // Her metin kutusunu decimal olarak parse etmeyi deneyin
                if (!decimal.TryParse(lblTahakkukAylik.Text, out tahakkukAylik))
                    tahakkukAylik = 0;

                if (!decimal.TryParse(lblTahakkukIdariMasraf.Text, out tahakkukIdariMasraf))
                    tahakkukIdariMasraf = 0;

                // Toplamları hesaplayın
                decimal TahakkukIdariToplami = tahakkukAylik + tahakkukIdariMasraf;

                // Sonucu lblTahsilToplami etiketine yazdırın
                lblTahakkukIdariToplami.Text = TahakkukIdariToplami.ToString("#,0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        public void IdariOdenenToplami()
        {
            try
            {
                decimal odenenAylik, odenenIdariMasraf;

                // Her metin kutusunu decimal olarak parse etmeyi deneyin
                if (!decimal.TryParse(lblOdenenAylik.Text, out odenenAylik))
                    odenenAylik = 0;

                if (!decimal.TryParse(lblOdenenIdariMasraf.Text, out odenenIdariMasraf))
                    odenenIdariMasraf = 0;

                // Toplamları hesaplayın
                decimal OdenenIdariToplami = odenenAylik + odenenIdariMasraf;

                // Sonucu lblTahsilToplami etiketine yazdırın
                lblOdenenIdariToplami.Text = OdenenIdariToplami.ToString("#,0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        public void IdariIptalToplami()
        {
            try
            {
                decimal iptalAylik, iptalIdariMasraf;

                // Her metin kutusunu decimal olarak parse etmeyi deneyin
                if (!decimal.TryParse(lblIptalAylik.Text, out iptalAylik))
                    iptalAylik = 0;

                if (!decimal.TryParse(lblIptalIdariMasraf.Text, out iptalIdariMasraf))
                    iptalIdariMasraf = 0;

                // Toplamları hesaplayın
                decimal IptalIdariToplami = iptalAylik + iptalIdariMasraf;

                // Sonucu lblTahsilToplami etiketine yazdırın
                lblIptalIdariToplami.Text = IptalIdariToplami.ToString("#,0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        public void ZiraatToplamlari()
        {
            try
            {
                decimal iptalSulama, iptalAgaclama, iptalDamizlik, iptalOrnekTarla, iptalZiraiHayvan, iptalPazarCarsi, iptalKucukEndustri,
                    odenenSulama, odenenAgaclama, odenenDamizlik, odenenOrnekTarla, odenenZiraiHayvan, odenenPazarCarsi, odenenKucukEndustri,
                    tahakkukSulama, tahakkukAgaclama, tahakkukDamizlik, tahakkukOrnekTarla, tahakkukZiraiHayvan, tahakkukPazarCarsi, tahakkukKucukEndustri,
                    munzamSulama, munzamAgaclama, munzamDamizlik, munzamOrnekTarla, munzamZiraiHayvan, munzamPazarCarsi, munzamKucukEndustri;

                //ZİRAAT İPTAL İŞLEMLERİ
                if (!decimal.TryParse(lblIptalSulama.Text, out iptalSulama))
                    iptalSulama = 0;
                if (!decimal.TryParse(lblIptalAgaclama.Text, out iptalAgaclama))
                    iptalAgaclama = 0;
                if (!decimal.TryParse(lblIptalDamizlik.Text, out iptalDamizlik))
                    iptalDamizlik = 0;
                if (!decimal.TryParse(lblIptalOrnekTarla.Text, out iptalOrnekTarla))
                    iptalOrnekTarla = 0;
                if (!decimal.TryParse(lblIptalZiraiHayvan.Text, out iptalZiraiHayvan))
                    iptalZiraiHayvan = 0;
                if (!decimal.TryParse(lblIptalPazarCarsi.Text, out iptalPazarCarsi))
                    iptalPazarCarsi = 0;
                if (!decimal.TryParse(lblIptalKucukEndustri.Text, out iptalKucukEndustri))
                    iptalKucukEndustri = 0;
                // Toplamları hesaplayın
                decimal IptalZiraatToplami = iptalSulama + iptalAgaclama + iptalDamizlik + iptalOrnekTarla + iptalZiraiHayvan + iptalPazarCarsi + iptalKucukEndustri;
                // Sonucu lblTahsilToplami etiketine yazdırın
                lblIptalZiraatToplami.Text = IptalZiraatToplami.ToString("#,0.00");

                //ZİRAAT ODENEN İŞLEMLERİ
                // Her metin kutusunu decimal olarak parse etmeyi deneyin
                if (!decimal.TryParse(lblOdenenSulama.Text, out odenenSulama))
                    odenenSulama = 0;

                if (!decimal.TryParse(lblOdenenAgaclama.Text, out odenenAgaclama))
                    odenenAgaclama = 0;

                if (!decimal.TryParse(lblOdenenDamizlik.Text, out odenenDamizlik))
                    odenenDamizlik = 0;

                if (!decimal.TryParse(lblOdenenOrnekTarla.Text, out odenenOrnekTarla))
                    odenenOrnekTarla = 0;

                if (!decimal.TryParse(lblOdenenZiraiHayvan.Text, out odenenZiraiHayvan))
                    odenenZiraiHayvan = 0;

                if (!decimal.TryParse(lblOdenenPazarCarsi.Text, out odenenPazarCarsi))
                    odenenPazarCarsi = 0;

                if (!decimal.TryParse(lblOdenenKucukEndustri.Text, out odenenKucukEndustri))
                    odenenKucukEndustri = 0;

                // Toplamları hesaplayın
                decimal OdenenZiraatToplami = odenenSulama + odenenAgaclama + odenenDamizlik + odenenOrnekTarla + odenenZiraiHayvan + odenenPazarCarsi + odenenKucukEndustri;

                lblOdenenZiraatToplami.Text = OdenenZiraatToplami.ToString("#,0.00");

                //ZİRAAT TAHAKKUK İŞLEMLERİ
                if (!decimal.TryParse(lblTahakkukSulama.Text, out tahakkukSulama))
                    tahakkukSulama = 0;
                if (!decimal.TryParse(lblTahakkukAgaclama.Text, out tahakkukAgaclama))
                    tahakkukAgaclama = 0;
                if (!decimal.TryParse(lblTahakkukDamizlik.Text, out tahakkukDamizlik))
                    tahakkukDamizlik = 0;
                if (!decimal.TryParse(lblTahakkukOrnekTarla.Text, out tahakkukOrnekTarla))
                    tahakkukOrnekTarla = 0;
                if (!decimal.TryParse(lblTahakkukZiraiHayvan.Text, out tahakkukZiraiHayvan))
                    tahakkukZiraiHayvan = 0;
                if (!decimal.TryParse(lblTahakkukPazarCarsi.Text, out tahakkukPazarCarsi))
                    tahakkukPazarCarsi = 0;
                if (!decimal.TryParse(lblTahakkukKucukEndustri.Text, out tahakkukKucukEndustri))
                    iptalKucukEndustri = 0;
                // Toplamları hesaplayın
                decimal TahakkukZiraatToplami = tahakkukSulama + tahakkukAgaclama + tahakkukDamizlik + tahakkukOrnekTarla + tahakkukZiraiHayvan + tahakkukPazarCarsi + tahakkukKucukEndustri;

                lblTahakkukZiraatToplami.Text = TahakkukZiraatToplami.ToString("#,0.00");

                //ZİRAAT MUNZAM İŞLEMLERİ
                if (!decimal.TryParse(lblMunzamSulama.Text, out munzamSulama))
                    munzamSulama = 0;
                if (!decimal.TryParse(lblMunzamAgaclama.Text, out munzamAgaclama))
                    munzamAgaclama = 0;
                if (!decimal.TryParse(lblMunzamDamizlik.Text, out munzamDamizlik))
                    munzamDamizlik = 0;
                if (!decimal.TryParse(lblMunzamOrnekTarla.Text, out munzamOrnekTarla))
                    munzamOrnekTarla = 0;
                if (!decimal.TryParse(lblMunzamZiraiHayvan.Text, out munzamZiraiHayvan))
                    munzamZiraiHayvan = 0;
                if (!decimal.TryParse(lblMunzamPazarCarsi.Text, out munzamPazarCarsi))
                    munzamPazarCarsi = 0;
                if (!decimal.TryParse(lblMunzamKucukEndustri.Text, out munzamKucukEndustri))
                    munzamKucukEndustri = 0;
                // Toplamları hesaplayın
                decimal MunzamZiraatToplami = munzamSulama + munzamAgaclama + munzamDamizlik + munzamOrnekTarla + munzamZiraiHayvan + munzamPazarCarsi + munzamKucukEndustri;

                lblMunzamZiraatToplami.Text = MunzamZiraatToplami.ToString("#,0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        public void KulturToplamlari()
        {
            try
            {
                decimal iptalOgretmenevi, iptalOkulDaimi, iptalOkumaOdasi, iptalKurs, iptalOkulUygulama,
                    odenenOgretmenevi, odenenOkulDaimi, odenenOkumaOdasi, odenenKurs, odenenOkulUygulama,
                    tahakkukOgretmenevi, tahakkukOkulDaimi, tahakkukOkumaOdasi, tahakkukKurs, tahakkukOkulUygulama,
                    munzamOgretmenevi, munzamOkulDaimi, munzamOkumaOdasi, munzamKurs, munzamOkulUygulama;

                //KULTUR İPTAL İŞLEMLERİ
                if (!decimal.TryParse(lblIptalOgretmenevi.Text, out iptalOgretmenevi))
                    iptalOgretmenevi = 0;
                if (!decimal.TryParse(lblIptalOkulDaimi.Text, out iptalOkulDaimi))
                    iptalOkulDaimi = 0;
                if (!decimal.TryParse(lblIptalOkumaOdasi.Text, out iptalOkumaOdasi))
                    iptalOkumaOdasi = 0;
                if (!decimal.TryParse(lblIptalKurs.Text, out iptalKurs))
                    iptalKurs = 0;
                if (!decimal.TryParse(lblIptalOkulUygulama.Text, out iptalOkulUygulama))
                    iptalOkulUygulama = 0;

                // Toplamları hesaplayın
                decimal IptalKulturToplami = iptalOgretmenevi + iptalOkulDaimi + iptalOkumaOdasi + iptalKurs + iptalOkulUygulama;
                lblIptalKulturToplami.Text = IptalKulturToplami.ToString("#,0.00");

                //KULTUR ODENEN İŞLEMLERİ
                // Her metin kutusunu decimal olarak parse etmeyi deneyin
                if (!decimal.TryParse(lblOdenenOgretmenevi.Text, out odenenOgretmenevi))
                    odenenOgretmenevi = 0;

                if (!decimal.TryParse(lblOdenenOkulDaimi.Text, out odenenOkulDaimi))
                    odenenOkulDaimi = 0;

                if (!decimal.TryParse(lblOdenenOkumaOdasi.Text, out odenenOkumaOdasi))
                    odenenOkumaOdasi = 0;

                if (!decimal.TryParse(lblOdenenKurs.Text, out odenenKurs))
                    odenenKurs = 0;

                if (!decimal.TryParse(lblOdenenOkulUygulama.Text, out odenenOkulUygulama))
                    odenenOkulUygulama = 0;

                // Toplamları hesaplayın
                decimal OdenenKulturToplami = odenenOgretmenevi + odenenOkulDaimi + odenenOkumaOdasi + odenenKurs + odenenOkulUygulama;
                lblOdenenKulturToplami.Text = OdenenKulturToplami.ToString("#,0.00");

                //KULTUR TAHAKKUK İŞLEMLERİ
                if (!decimal.TryParse(lblTahakkukOgretmenevi.Text, out tahakkukOgretmenevi))
                    tahakkukOgretmenevi = 0;
                if (!decimal.TryParse(lblTahakkukOkulDaimi.Text, out tahakkukOkulDaimi))
                    tahakkukOkulDaimi = 0;
                if (!decimal.TryParse(lblTahakkukOkumaOdasi.Text, out tahakkukOkumaOdasi))
                    tahakkukOkumaOdasi = 0;
                if (!decimal.TryParse(lblTahakkukKurs.Text, out tahakkukKurs))
                    tahakkukKurs = 0;
                if (!decimal.TryParse(lblTahakkukOkulUygulama.Text, out tahakkukOkulUygulama))
                    tahakkukOkulUygulama = 0;

                // Toplamları hesaplayın
                decimal TahakkukKulturToplami = tahakkukOgretmenevi + tahakkukOkulDaimi + tahakkukOkumaOdasi + tahakkukKurs + tahakkukOkulUygulama;
                lblTahakkukKulturToplami.Text = TahakkukKulturToplami.ToString("#,0.00");

                //KULTUR MUNZAM İŞLEMLERİ
                if (!decimal.TryParse(lblMunzamOgretmenevi.Text, out munzamOgretmenevi))
                    munzamOgretmenevi = 0;
                if (!decimal.TryParse(lblMunzamOkulDaimi.Text, out munzamOkulDaimi))
                    munzamOkulDaimi = 0;
                if (!decimal.TryParse(lblMunzamOkumaOdasi.Text, out munzamOkumaOdasi))
                    munzamOkumaOdasi = 0;
                if (!decimal.TryParse(lblMunzamKurs.Text, out munzamKurs))
                    munzamKurs = 0;
                if (!decimal.TryParse(lblMunzamOkulUygulama.Text, out munzamOkulUygulama))
                    munzamOkulUygulama = 0;

                // Toplamları hesaplayın
                decimal MunzamKulturToplami = munzamOgretmenevi + munzamOkulDaimi + munzamOkumaOdasi + munzamKurs + munzamOkulUygulama;
                lblMunzamKulturToplami.Text = MunzamKulturToplami.ToString("#,0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        public void SaglikToplamlari()
        {
            try
            {
                decimal iptalIcmeSulari, iptalTemizlik, iptalSpor, iptalIctimai,
                    odenenIcmeSulari, odenenTemizlik, odenenSpor, odenenIctimai,
                    tahakkukIcmeSulari, tahakkukTemizlik, tahakkukSpor, tahakkukIctimai,
                    munzamIcmeSulari, munzamTemizlik, munzamSpor, munzamIctimai;

                //SAGLIK İPTAL İŞLEMLERİ
                if (!decimal.TryParse(lblIptalIcmeSulari.Text, out iptalIcmeSulari))
                    iptalIcmeSulari = 0;
                if (!decimal.TryParse(lblIptalTemizlik.Text, out iptalTemizlik))
                    iptalTemizlik = 0;
                if (!decimal.TryParse(lblIptalSpor.Text, out iptalSpor))
                    iptalSpor = 0;
                if (!decimal.TryParse(lblIptalIctimai.Text, out iptalIctimai))
                    iptalIctimai = 0;

                // Toplamları hesaplayın
                decimal IptalSaglikToplami = iptalIcmeSulari + iptalTemizlik + iptalSpor + iptalIctimai;
                lblIptalSaglikToplami.Text = IptalSaglikToplami.ToString("#,0.00");

                //SAGLIK ODENEN İŞLEMLERİ
                // Her metin kutusunu decimal olarak parse etmeyi deneyin
                if (!decimal.TryParse(lblOdenenIcmeSulari.Text, out odenenIcmeSulari))
                    odenenIcmeSulari = 0;

                if (!decimal.TryParse(lblOdenenTemizlik.Text, out odenenTemizlik))
                    odenenTemizlik = 0;

                if (!decimal.TryParse(lblOdenenSpor.Text, out odenenSpor))
                    odenenSpor = 0;

                if (!decimal.TryParse(lblOdenenIctimai.Text, out odenenIctimai))
                    odenenIctimai = 0;

                // Toplamları hesaplayın
                decimal OdenenSaglikToplami = odenenIcmeSulari + odenenTemizlik + odenenSpor + odenenIctimai;
                lblOdenenSaglikToplami.Text = OdenenSaglikToplami.ToString("#,0.00");

                //SAGLIK TAHAKKUK İŞLEMLERİ
                if (!decimal.TryParse(lblTahakkukIcmeSulari.Text, out tahakkukIcmeSulari))
                    tahakkukIcmeSulari = 0;
                if (!decimal.TryParse(lblTahakkukTemizlik.Text, out tahakkukTemizlik))
                    tahakkukTemizlik = 0;
                if (!decimal.TryParse(lblTahakkukSpor.Text, out tahakkukSpor))
                    tahakkukSpor = 0;
                if (!decimal.TryParse(lblTahakkukIctimai.Text, out tahakkukIctimai))
                    tahakkukIctimai = 0;

                // Toplamları hesaplayın
                decimal TahakkukSaglikToplami = tahakkukIcmeSulari + tahakkukTemizlik + tahakkukSpor + tahakkukIctimai;
                lblTahakkukSaglikToplami.Text = TahakkukSaglikToplami.ToString("#,0.00");

                //SAGLIK MUNZAM İŞLEMLERİ
                if (!decimal.TryParse(lblMunzamIcmeSulari.Text, out munzamIcmeSulari))
                    munzamIcmeSulari = 0;
                if (!decimal.TryParse(lblMunzamTemizlik.Text, out munzamTemizlik))
                    munzamTemizlik = 0;
                if (!decimal.TryParse(lblMunzamSpor.Text, out munzamSpor))
                    munzamSpor = 0;
                if (!decimal.TryParse(lblMunzamIctimai.Text, out munzamIctimai))
                    munzamIctimai = 0;

                // Toplamları hesaplayın
                decimal MunzamSaglikToplami = munzamIcmeSulari + munzamTemizlik + munzamSpor + munzamIctimai;
                lblMunzamSaglikToplami.Text = MunzamSaglikToplami.ToString("#,0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        private void FrmKesinHesap1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //PaylasilanDegerleriAyarla();
        }
    }
}
