using Business.Concrete;
using DataAccess.Abstract;
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
    public partial class FrmKesinHesap1 : Form
    {
        // TahminiButceGelirManager tahminiButceGelirManager;

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

        private void FrmKesinHesap1_Load(object sender, EventArgs e)
        {
            GelirKategoriVerileriYukleVeToplamiHesapla();
        }

        // Gelir kategorilerine göre toplam tutarları label'lara yazdır
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
                label.Text = toplamTutar.ToString(); // Currency formatında yazdırma
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gelir Kategorisi {gelirKategoriId} için toplam tutar yüklenirken bir hata oluştu: " + ex.Message);
                label.Text = "0.00"; // Hata durumunda varsayılan değeri yazdır
            }
        }

        //TahminiButceGelir'de yer alan kayıtları ilgili label'lara yazıdrma
        private void LoadGelirKategoriVerileri()
        {
            try
            {
                GelirKategoriLabellarAyarla(lblBKHasilat, 1);
                GelirKategoriLabellarAyarla(lblBKResim, 2);
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
                // Veritabanından belirtilen gelir kategorisi için veriyi al
                var tahminiButceGelir = _tahminiButceGelirManager
                    .GetListByKoyIdAndDonemIdAndGelirKategoriId(_seciliKoyIndex, _seciliDonemIndex, gelirKategoriId)
                    .FirstOrDefault();

                // Eğer veri bulunduysa, Label'e formatlı şekilde yazdır; yoksa "0.00" olarak ayarla
                if (tahminiButceGelir != null)
                {
                    label.Text = string.Format("{0:#,0.00}", tahminiButceGelir.TahimiGelirTutari);
                }
                else
                {
                    label.Text = "0.00";
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
                GiderToplami(_seciliKoyIndex, _seciliDonemIndex, 1, lblOdenenAylik); // Hasilat için
                GiderToplami(_seciliKoyIndex, _seciliDonemIndex, 2, lblOdenenIdariMasraf); // Resim için
                GiderToplami(_seciliKoyIndex, _seciliDonemIndex, 3, lblOdenenSulama); // Ceza için
                GiderToplami(_seciliKoyIndex, _seciliDonemIndex, 4, lblOdenenAgaclama); // Yardım için
                GiderToplami(_seciliKoyIndex, _seciliDonemIndex, 5, lblOdenenDamizlik); // Köy Vakıf için
                GiderToplami(_seciliKoyIndex, _seciliDonemIndex, 6, lblOdenenOrnekTarla); // İstikraz için
                GiderToplami(_seciliKoyIndex, _seciliDonemIndex, 7, lblOdenenZiraiHayvan); // Türlü Gelir için
                GiderToplami(_seciliKoyIndex, _seciliDonemIndex, 8, lblOdenenPazarCarsi); // Devir için
                GiderToplami(_seciliKoyIndex, _seciliDonemIndex, 9, lblOdenenKucukEndustri); // Hasilat için
                GiderToplami(_seciliKoyIndex, _seciliDonemIndex, 10, lblOdenenOgretmenevi); // Resim için
                GiderToplami(_seciliKoyIndex, _seciliDonemIndex, 11, lblOdenenOkulDaimi); // Ceza için
                GiderToplami(_seciliKoyIndex, _seciliDonemIndex, 12, lblOdenenOkumaOdasi); // Yardım için
                GiderToplami(_seciliKoyIndex, _seciliDonemIndex, 13, lblOdenenKurs); // Köy Vakıf için
                GiderToplami(_seciliKoyIndex, _seciliDonemIndex, 14, lblOdenenOkulUygulama); // İstikraz için
                GiderToplami(_seciliKoyIndex, _seciliDonemIndex, 15, lblOdenenIcmeSulari); // Türlü Gelir için
                GiderToplami(_seciliKoyIndex, _seciliDonemIndex, 16, lblOdenenTemizlik); // Devir için
                GiderToplami(_seciliKoyIndex, _seciliDonemIndex, 17, lblOdenenSpor);
                GiderToplami(_seciliKoyIndex, _seciliDonemIndex, 18, lblOdenenIctimai);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gider verilerini yüklerken bir hata oluştu: " + ex.Message);
            }
        }

        // Gelir Toplamı için Kullanıyorum
        private void GiderToplami(int koyId, byte donemId, byte giderAltKategoriId, Label label)
        {
            try
            {
                decimal toplamTutar = _giderManager.GiderAltKategoriToplami(koyId, donemId, giderAltKategoriId);

                // Label'e toplam tutarı yazdır
                label.Text = toplamTutar.ToString(); // Currency formatında yazdırma
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gider Kategorisi {giderAltKategoriId} için toplam tutar yüklenirken bir hata oluştu: " + ex.Message);
                label.Text = "0.00"; // Hata durumunda varsayılan değeri yazdır
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
                    label.Text = "0.00";
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

                // lblTahsilHasilat.Text'i decimal türüne dönüştür
                if (!decimal.TryParse(lblTahsilHasilat.Text, out tahsilHasilat))
                {
                    MessageBox.Show("lblTahsilHasilat.Text geçerli bir sayı değil: " + lblTahsilHasilat.Text);
                    return;
                }

                // lblBKHasilat.Text'i decimal türüne dönüştür
                if (!decimal.TryParse(lblBKHasilat.Text, out bkHasilat))
                {
                    MessageBox.Show("lblBKHasilat.Text geçerli bir sayı değil: " + lblBKHasilat.Text);
                    return;
                }

                Debug.WriteLine($"tahsilHasilat: {tahsilHasilat}, bkHasilat: {bkHasilat}");

                // munzamHasilat hesaplama
                if (tahsilHasilat < bkHasilat)
                {
                    lblMunzamHasilat.Text = "0.00";
                }
                else
                {
                    munzamHasilat = tahsilHasilat - bkHasilat;
                    lblMunzamHasilat.Text = string.Format("{0:#,0.00}", munzamHasilat);
                }

                Debug.WriteLine($"munzamHasilat: {munzamHasilat}");

                // yekunHasilat hesaplama
                yekunHasilat = bkHasilat + munzamHasilat;
                lblYekunHasilat.Text = string.Format("{0:#,0.00}", yekunHasilat);

                Debug.WriteLine($"yekunHasilat: {yekunHasilat}");

                // devredenHasilat hesaplama
                devredenHasilat = yekunHasilat - tahsilHasilat;
                lblDevredenHasilat.Text = string.Format("{0:#,0.00}", devredenHasilat);

                Debug.WriteLine($"devredenHasilat: {devredenHasilat}");

                // Label'ların Visible ayarı
                lblMunzamHasilat.Visible = !IsZeroOrEmpty(lblMunzamHasilat.Text);
                lblYekunHasilat.Visible = !IsZeroOrEmpty(lblYekunHasilat.Text);
                lblDevredenHasilat.Visible = !IsZeroOrEmpty(lblDevredenHasilat.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hasilat hesapları yapılırken bir hata oluştu: " + ex.Message);
            }
        }

        public void ResimHesap()
        {
            try
            {
                decimal tahsilResim = 0;
                decimal bkResim = 0;
                decimal munzamResim = 0;
                decimal yekunResim = 0;
                decimal devredenResim = 0;

                // lblTahsilResim.Text'i decimal türüne dönüştür
                if (!decimal.TryParse(lblTahsilResim.Text.Replace(".", ","), NumberStyles.Any, CultureInfo.InvariantCulture, out tahsilResim))
                {
                    MessageBox.Show("lblTahsilResim.Text geçerli bir sayı değil: " + lblTahsilResim.Text);
                    return;
                }

                // lblBKResim.Text'i decimal türüne dönüştür
                if (!decimal.TryParse(lblBKResim.Text.Replace(".", ","), NumberStyles.Any, CultureInfo.InvariantCulture, out bkResim))
                {
                    MessageBox.Show("lblBKResim.Text geçerli bir sayı değil: " + lblBKResim.Text);
                    return;
                }

                // Debug mesajları ekleyerek değerleri kontrol et
                Debug.WriteLine($"lblTahsilResim.Text: {lblTahsilResim.Text}");
                Debug.WriteLine($"lblBKResim.Text: {lblBKResim.Text}");

                // munzamResim hesaplama
                if (tahsilResim < bkResim)
                {
                    lblMunzamResim.Text = "0";
                }
                else
                {
                    munzamResim = tahsilResim - bkResim;
                    lblMunzamResim.Text = string.Format("{0:#,0.00}", munzamResim);
                }

                // yekunResim hesaplama
                yekunResim = bkResim + munzamResim;
                lblYekunResim.Text = string.Format("{0:#,0.00}", yekunResim);

                // devredenResim hesaplama
                devredenResim = yekunResim - tahsilResim;
                lblDevredenResim.Text = string.Format("{0:#,0.00}", devredenResim);

                // Text'i "0" olan labelların görünürlüğünü kapatma
                lblMunzamResim.Visible = !IsZeroOrEmpty(lblMunzamResim.Text);
                lblYekunResim.Visible = !IsZeroOrEmpty(lblYekunResim.Text);
                lblDevredenResim.Visible = !IsZeroOrEmpty(lblDevredenResim.Text);
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

                // lblTahsilHasilat.Text'i decimal türüne dönüştür
                if (!decimal.TryParse(lblTahsilCeza.Text, out tahsilCeza))
                {
                    MessageBox.Show("lblTahsilHasilat.Text geçerli bir sayı değil: " + lblTahsilCeza.Text);
                    return;
                }

                // lblBKHasilat.Text'i decimal türüne dönüştür
                if (!decimal.TryParse(lblBKCeza.Text, out bkCeza))
                {
                    MessageBox.Show("lblBKCeza.Text geçerli bir sayı değil: " + lblBKCeza.Text);
                    return;
                }

                Debug.WriteLine($"tahsilCeza: {tahsilCeza}, bkHasilat: {bkCeza}");

                // munzamHasilat hesaplama
                if (tahsilCeza < bkCeza)
                {
                    lblMunzamCeza.Text = "0.00";
                }
                else
                {
                    munzamCeza = tahsilCeza - bkCeza;
                    lblMunzamCeza.Text = string.Format("{0:#,0.00}", munzamCeza);
                }

                Debug.WriteLine($"munzamHasilat: {munzamCeza}");

                // yekunHasilat hesaplama
                yekunCeza = bkCeza + munzamCeza;
                lblYekunCeza.Text = string.Format("{0:#,0.00}", yekunCeza);

                Debug.WriteLine($"yekunCeza: {yekunCeza}");

                // devredenHasilat hesaplama
                devredenCeza = yekunCeza - tahsilCeza;
                lblDevredenCeza.Text = string.Format("{0:#,0.00}", devredenCeza);

                Debug.WriteLine($"devredenCeza: {devredenCeza}");

                // lblMunzamHasilat için Visible ayarı
                lblMunzamCeza.Visible = !IsZeroOrEmpty(lblMunzamHasilat.Text);

                // lblYekunHasilat için Visible ayarı
                lblYekunCeza.Visible = !IsZeroOrEmpty(lblYekunCeza.Text);

                // lblDevredenHasilat için Visible ayarı
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

                // lblTahsilHasilat.Text'i decimal türüne dönüştür
                if (!decimal.TryParse(lblTahsilYardim.Text, out tahsilYardim))
                {
                    MessageBox.Show("lblTahsilYardim.Text geçerli bir sayı değil: " + lblTahsilYardim.Text);
                    return;
                }

                // lblBKHasilat.Text'i decimal türüne dönüştür
                if (!decimal.TryParse(lblBKYardim.Text, out bkYardim))
                {
                    MessageBox.Show("lblBKYardim.Text geçerli bir sayı değil: " + lblBKYardim.Text);
                    return;
                }

                //Debug.WriteLine($"tahsilCeza: {tahsilCeza}, bkHasilat: {bkCeza}");

                // munzamHasilat hesaplama
                if (tahsilYardim < bkYardim)
                {
                    lblMunzamYardim.Text = "0.00";
                }
                else
                {
                    munzamYardim = tahsilYardim - bkYardim;
                    lblMunzamYardim.Text = string.Format("{0:#,0.00}", munzamYardim);
                }

                // yekunYardim hesaplama
                yekunYardim = bkYardim + munzamYardim;
                lblYekunYardim.Text = string.Format("{0:#,0.00}", yekunYardim);

                // devredenYardim hesaplama
                devredenYardim = yekunYardim - tahsilYardim;
                lblDevredenYardim.Text = string.Format("{0:#,0.00}", devredenYardim);

                // lblMunzamYardim için Visible ayarı
                lblMunzamYardim.Visible = !IsZeroOrEmpty(lblMunzamYardim.Text);

                // lblYekunHYardim için Visible ayarı
                lblYekunYardim.Visible = !IsZeroOrEmpty(lblYekunYardim.Text);

                // lblDevredenHYardim için Visible ayarı
                lblDevredenYardim.Visible = !IsZeroOrEmpty(lblDevredenYardim.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Yardim hesapları yapılırken bir hata oluştu: " + ex.Message);
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
                    lblMunzamKoyVakif.Text = "0.00";
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
                MessageBox.Show("Köy Vakıf hesapları yapılırken bir hata oluştu: " + ex.Message);
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
                    lblMunzamIstikraz.Text = "0.00";
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
                    lblMunzamIstikraz.Text = "0.00";
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
                    lblMunzamDevir.Text = "0.00";
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
                MessageBox.Show("Devir hesapları yapılırken bir hata oluştu: " + ex.Message);
            }
        }

        //public void AskerHesap()
        //{
        //    decimal munzamAsker;
        //    decimal yekunAsker;
        //    decimal devredenAsker;

        //    if (Convert.ToDecimal(lblTahsilAsker.Text) < Convert.ToDecimal(lblBKAsker.Text))
        //    {
        //        lblMunzamAsker.Text = 0.ToString();
        //    }
        //    else
        //    {
        //        munzamAsker = Convert.ToDecimal(lblTahsilAsker.Text) - Convert.ToDecimal(lblBKAsker.Text);
        //        lblMunzamAsker.Text = munzamAsker.ToString();
        //    }

        //    yekunAsker = Convert.ToDecimal(lblBKAsker.Text) + Convert.ToDecimal(lblMunzamAsker.Text);
        //    lblYekunAsker.Text = yekunAsker.ToString();

        //    devredenAsker = Convert.ToDecimal(lblYekunAsker.Text) - Convert.ToDecimal(lblTahsilAsker.Text);
        //    lblDevredenAsker.Text = devredenAsker.ToString();
        //}

        private void FrmKesinHesap1Y_Load(object sender, EventArgs e)
        {
            try
            {

                HasilatHesap();

                // Veri tabanından değerleri almak için gereken işlemleri yapın
                // Örneğin, burada lblBKResim ve lblTahsilResim etiketlerinin değerlerini sıfıra veya boş bir değere ayarlayabilirsiniz.
                //lblBKResim.Text = "0.00";
                //lblTahsilResim.Text = "0";

                ResimHesap();
                CezaHesap();
                YardimHesap();
                KoyVakifHesap();
                IstikrazHesap();
                TurluGelirHesap();
                DevirHesap();


                Toplamlar();

                AlanlariDoldur(_seciliKoyIndex, _seciliDonemIndex, _seciliIlceIndex);

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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Form yüklenirken bir hata oluştu: " + ex.Message);
            }

        }

        public void Toplamlar()
        {
            decimal ResimHarcBKToplam = Convert.ToDecimal(lblBKHasilat.Text) + Convert.ToDecimal(lblBKResim.Text) + Convert.ToDecimal(lblBKCeza.Text) +
                                        Convert.ToDecimal(lblBKCeza.Text) + Convert.ToDecimal(lblBKYardim.Text) + Convert.ToDecimal(lblBKKoyVakif.Text) +
                                        Convert.ToDecimal(lblBKIstikraz.Text) + Convert.ToDecimal(lblBKTurluGelir.Text) + Convert.ToDecimal(lblBKDevir.Text);
            lblBKResimHarcToplami.Text = ResimHarcBKToplam.ToString();

            decimal MunzamToplam = Convert.ToDecimal(lblMunzamHasilat.Text) + Convert.ToDecimal(lblMunzamResim.Text) + Convert.ToDecimal(lblMunzamCeza.Text) +
                                        Convert.ToDecimal(lblMunzamCeza.Text) + Convert.ToDecimal(lblMunzamYardim.Text) + Convert.ToDecimal(lblMunzamKoyVakif.Text) +
                                        Convert.ToDecimal(lblMunzamIstikraz.Text) + Convert.ToDecimal(lblMunzamTurluGelir.Text) + Convert.ToDecimal(lblMunzamDevir.Text);
            lblMunzamToplami.Text = MunzamToplam.ToString();

            decimal YekunToplam = Convert.ToDecimal(lblYekunHasilat.Text) + Convert.ToDecimal(lblYekunResim.Text) + Convert.ToDecimal(lblYekunCeza.Text) +
                                    Convert.ToDecimal(lblYekunCeza.Text) + Convert.ToDecimal(lblYekunYardim.Text) + Convert.ToDecimal(lblYekunKoyVakif.Text) +
                                    Convert.ToDecimal(lblYekunIstikraz.Text) + Convert.ToDecimal(lblYekunTurluGelir.Text) + Convert.ToDecimal(lblYekunDevir.Text);
            lblYekunToplami.Text = YekunToplam.ToString();

            decimal TahsilToplam = Convert.ToDecimal(lblTahsilHasilat.Text) + Convert.ToDecimal(lblTahsilResim.Text) + Convert.ToDecimal(lblTahsilCeza.Text) +
                                    Convert.ToDecimal(lblTahsilCeza.Text) + Convert.ToDecimal(lblTahsilYardim.Text) + Convert.ToDecimal(lblTahsilKoyVakif.Text) +
                                    Convert.ToDecimal(lblTahsilIstikraz.Text) + Convert.ToDecimal(lblTahsilTurluGelir.Text) + Convert.ToDecimal(lblTahsilDevir.Text);
            lblTahsilToplami.Text = TahsilToplam.ToString();

            decimal DevredenToplam = Convert.ToDecimal(lblDevredenHasilat.Text) + Convert.ToDecimal(lblDevredenResim.Text) + Convert.ToDecimal(lblDevredenCeza.Text) +
                                    Convert.ToDecimal(lblDevredenCeza.Text) + Convert.ToDecimal(lblDevredenYardim.Text) + Convert.ToDecimal(lblDevredenKoyVakif.Text) +
                                    Convert.ToDecimal(lblDevredenIstikraz.Text) + Convert.ToDecimal(lblDevredenTurluGelir.Text) + Convert.ToDecimal(lblDevredenDevir.Text);
            lblDevredenToplami.Text = DevredenToplam.ToString();

            lblBKAskerToplami.Text = lblBKAsker.Text;
            lblMunzamAskerToplami.Text = lblMunzamAsker.Text;
            lblYekunAskerToplami.Text = lblYekunAsker.Text;
            lblTahsilAskerToplami.Text = lblTahsilAsker.Text;
            lblDevredenAskerToplami.Text = lblDevredenAsker.Text;

            decimal ResimHarcGenelToplami = Convert.ToDecimal(lblBKResimHarcToplami.Text) + Convert.ToDecimal(lblBKAskerToplami.Text);
            lblBKResimHarcGenelToplam.Text = ResimHarcGenelToplami.ToString();

            decimal MunzamGenelToplami = Convert.ToDecimal(lblMunzamToplami.Text) + Convert.ToDecimal(lblMunzamAskerToplami.Text);
            lblMunzamGenelToplam.Text = MunzamGenelToplami.ToString();

            decimal YekunGenelToplami = Convert.ToDecimal(lblYekunToplami.Text) + Convert.ToDecimal(lblYekunAskerToplami.Text);
            lblYekunGenelToplam.Text = YekunGenelToplami.ToString();

            decimal TahsilGenelToplami = Convert.ToDecimal(lblTahsilToplami.Text) + Convert.ToDecimal(lblTahsilAskerToplami.Text);
            lblTahsilGenelToplam.Text = TahsilGenelToplami.ToString();

            decimal DevredenGenelToplami = Convert.ToDecimal(lblDevredenToplami.Text) + Convert.ToDecimal(lblDevredenAskerToplami.Text);
            lblDevredenGenelToplami.Text = DevredenGenelToplami.ToString();

            decimal BKIdariToplami = Convert.ToDecimal(lblBKAylik.Text) + Convert.ToDecimal(lblBKIdariMasraf.Text);
            lblBKIdariToplami.Text = BKIdariToplami.ToString();

            decimal MunzamIdariToplami = Convert.ToDecimal(lblMunzamAylik.Text) + Convert.ToDecimal(lblMunzamIdariMasraf.Text);
            lblMunzamIdariToplami.Text = MunzamIdariToplami.ToString();

            decimal TahakkukIdariToplami = Convert.ToDecimal(lblTahakkukAylik.Text) + Convert.ToDecimal(lblTahakkukIdariMasraf.Text);
            lblTahakkukIdariToplami.Text = TahakkukIdariToplami.ToString();

            decimal OdenenIdariToplami = Convert.ToDecimal(lblOdenenAylik.Text) + Convert.ToDecimal(lblOdenenIdariMasraf.Text);
            lblOdenenIdariToplami.Text = OdenenIdariToplami.ToString();

            decimal IptalIdariToplami = Convert.ToDecimal(lblIptalAylik.Text) + Convert.ToDecimal(lblIptalIdariMasraf.Text);
            lblIptalIdariToplami.Text = IptalIdariToplami.ToString();

            decimal BKZiraatToplami = Convert.ToDecimal(lblBKSulama.Text) + Convert.ToDecimal(lblBKAgaclama.Text) + Convert.ToDecimal(lblBKDamizlik.Text) +
                                      Convert.ToDecimal(lblBKOrnekTarla.Text) + Convert.ToDecimal(lblBKZiraiHayvan.Text) + Convert.ToDecimal(lblBKPazarCarsi.Text) +
                                      Convert.ToDecimal(lblBKKucukEndustri.Text);
            lblBKZiraatToplami.Text = BKZiraatToplami.ToString();

            decimal MunzamZiraatToplami = Convert.ToDecimal(lblMunzamSulama.Text) + Convert.ToDecimal(lblMunzamAgaclama.Text) + Convert.ToDecimal(lblMunzamDamizlik.Text) +
                                      Convert.ToDecimal(lblMunzamOrnekTarla.Text) + Convert.ToDecimal(lblMunzamZiraiHayvan.Text) + Convert.ToDecimal(lblMunzamPazarCarsi.Text) +
                                      Convert.ToDecimal(lblMunzamKucukEndustri.Text);
            lblMunzamZiraatToplami.Text = MunzamZiraatToplami.ToString();

            decimal TahakkukZiraatToplami = Convert.ToDecimal(lblTahakkukSulama.Text) + Convert.ToDecimal(lblTahakkukAgaclama.Text) + Convert.ToDecimal(lblTahakkukDamizlik.Text) +
                                      Convert.ToDecimal(lblTahakkukOrnekTarla.Text) + Convert.ToDecimal(lblTahakkukZiraiHayvan.Text) + Convert.ToDecimal(lblTahakkukPazarCarsi.Text) +
                                      Convert.ToDecimal(lblTahakkukKucukEndustri.Text);
            lblTahakkukZiraatToplami.Text = TahakkukZiraatToplami.ToString();

            decimal OdenenZiraatToplami = Convert.ToDecimal(lblOdenenSulama.Text) + Convert.ToDecimal(lblOdenenAgaclama.Text) + Convert.ToDecimal(lblOdenenDamizlik.Text) +
                                      Convert.ToDecimal(lblOdenenOrnekTarla.Text) + Convert.ToDecimal(lblOdenenZiraiHayvan.Text) + Convert.ToDecimal(lblOdenenPazarCarsi.Text) +
                                      Convert.ToDecimal(lblOdenenKucukEndustri.Text);
            lblOdenenZiraatToplami.Text = OdenenZiraatToplami.ToString();

            decimal IptalZiraatToplami = Convert.ToDecimal(lblIptalSulama.Text) + Convert.ToDecimal(lblIptalAgaclama.Text) + Convert.ToDecimal(lblIptalDamizlik.Text) +
                                      Convert.ToDecimal(lblIptalOrnekTarla.Text) + Convert.ToDecimal(lblIptalZiraiHayvan.Text) + Convert.ToDecimal(lblIptalPazarCarsi.Text) +
                                      Convert.ToDecimal(lblIptalKucukEndustri.Text);
            lblIptalZiraatToplami.Text = IptalZiraatToplami.ToString();

            decimal BKKulturToplami = Convert.ToDecimal(lblBKOgretmenevi.Text) + Convert.ToDecimal(lblBKOkulDaimi.Text) + +Convert.ToDecimal(lblOdenenOkumaOdasi.Text) +
                                      Convert.ToDecimal(lblBKKurs.Text) + Convert.ToDecimal(lblBKOkulUygulama.Text);
            lblBKKulturToplami.Text = BKKulturToplami.ToString();

            decimal MunzamKulturToplami = Convert.ToDecimal(lblMunzamOgretmenevi.Text) + Convert.ToDecimal(lblMunzamOkulDaimi.Text) + +Convert.ToDecimal(lblOdenenOkumaOdasi.Text) +
                                          Convert.ToDecimal(lblMunzamKurs.Text) + Convert.ToDecimal(lblMunzamOkulUygulama.Text);
            lblMunzamKulturToplami.Text = MunzamKulturToplami.ToString();

            decimal TahakkukKulturToplami = Convert.ToDecimal(lblTahakkukOgretmenevi.Text) + Convert.ToDecimal(lblTahakkukOkulDaimi.Text) + +Convert.ToDecimal(lblOdenenOkumaOdasi.Text) +
                                            Convert.ToDecimal(lblTahakkukKurs.Text) + Convert.ToDecimal(lblTahakkukOkulUygulama.Text);
            lblTahakkukKulturToplami.Text = TahakkukKulturToplami.ToString();

            decimal OdenenKulturToplami = Convert.ToDecimal(lblOdenenOgretmenevi.Text) + Convert.ToDecimal(lblOdenenOkulDaimi.Text) + Convert.ToDecimal(lblOdenenOkumaOdasi.Text) +
                                            Convert.ToDecimal(lblOdenenKurs.Text) + Convert.ToDecimal(lblOdenenOkulUygulama.Text);
            lblOdenenKulturToplami.Text = OdenenKulturToplami.ToString();

            decimal IptalKulturToplami = Convert.ToDecimal(lblIptalOgretmenevi.Text) + Convert.ToDecimal(lblIptalOkulDaimi.Text) + +Convert.ToDecimal(lblOdenenOkumaOdasi.Text) +
                                         Convert.ToDecimal(lblIptalKurs.Text) + Convert.ToDecimal(lblIptalOkulUygulama.Text);
            lblIptalKulturToplami.Text = IptalKulturToplami.ToString();

            decimal BKSaglikToplami = Convert.ToDecimal(lblBKIcmeSulari.Text) + Convert.ToDecimal(lblBKTemizlik.Text) + Convert.ToDecimal(lblBKSpor.Text) +
                                      Convert.ToDecimal(lblBKIctimai.Text);
            lblBKSaglikToplami.Text = BKSaglikToplami.ToString();

            decimal MunzamSaglikToplami = Convert.ToDecimal(lblMunzamIcmeSulari.Text) + Convert.ToDecimal(lblMunzamTemizlik.Text) + Convert.ToDecimal(lblMunzamSpor.Text) +
                                      Convert.ToDecimal(lblMunzamIctimai.Text);
            lblMunzamSaglikToplami.Text = MunzamSaglikToplami.ToString();

            decimal TahakkukSaglikToplami = Convert.ToDecimal(lblTahakkukIcmeSulari.Text) + Convert.ToDecimal(lblTahakkukTemizlik.Text) + Convert.ToDecimal(lblTahakkukSpor.Text) +
                                      Convert.ToDecimal(lblTahakkukIctimai.Text);
            lblTahakkukSaglikToplami.Text = TahakkukSaglikToplami.ToString();

            decimal OdenenSaglikToplami = Convert.ToDecimal(lblOdenenIcmeSulari.Text) + Convert.ToDecimal(lblOdenenTemizlik.Text) + Convert.ToDecimal(lblOdenenSpor.Text) +
                                      Convert.ToDecimal(lblOdenenIctimai.Text);
            lblOdenenSaglikToplami.Text = OdenenSaglikToplami.ToString();

            decimal IptalSaglikToplami = Convert.ToDecimal(lblIptalIcmeSulari.Text) + Convert.ToDecimal(lblIptalTemizlik.Text) + Convert.ToDecimal(lblIptalSpor.Text) +
                          Convert.ToDecimal(lblIptalIctimai.Text);
            lblIptalSaglikToplami.Text = IptalSaglikToplami.ToString();

            ////////////////////////////////////////
            decimal BKAylikToplami = Convert.ToDecimal(lblBKAylik.Text) + Convert.ToDecimal(lblBKIdariMasraf.Text);
            lblBKIdariToplami.Text = BKAylikToplami.ToString();

            //decimal MunzamSaglikToplami = Convert.ToDecimal(lblMunzamIcmeSulari.Text) + Convert.ToDecimal(lblMunzamTemizlik.Text) + Convert.ToDecimal(lblMunzamSpor.Text) +
            //                          Convert.ToDecimal(lblMunzamIctimai.Text);
            //lblMunzamSaglikToplami.Text = MunzamSaglikToplami.ToString();

            //decimal TahakkukSaglikToplami = Convert.ToDecimal(lblTahakkukIcmeSulari.Text) + Convert.ToDecimal(lblTahakkukTemizlik.Text) + Convert.ToDecimal(lblTahakkukSpor.Text) +
            //                          Convert.ToDecimal(lblTahakkukIctimai.Text);
            //lblTahakkukSaglikToplami.Text = TahakkukSaglikToplami.ToString();

            //decimal OdenenSaglikToplami = Convert.ToDecimal(lblOdenenIcmeSulari.Text) + Convert.ToDecimal(lblOdenenTemizlik.Text) + Convert.ToDecimal(lblOdenenSpor.Text) +
            //                          Convert.ToDecimal(lblOdenenIctimai.Text);
            //lblOdenenSaglikToplami.Text = OdenenSaglikToplami.ToString();

            //decimal IptalSaglikToplami = Convert.ToDecimal(lblIptalIcmeSulari.Text) + Convert.ToDecimal(lblIptalTemizlik.Text) + Convert.ToDecimal(lblIptalSpor.Text) +
            //              Convert.ToDecimal(lblIptalIctimai.Text);
            //lblIptalSaglikToplami.Text = IptalSaglikToplami.ToString();


        }

        //labellerda 0 olanların visible=false yapmak için metot
        private bool IsZeroOrEmpty(string text)
        {
            decimal value;
            if (decimal.TryParse(text.Replace(".", ","), NumberStyles.Any, CultureInfo.InvariantCulture, out value))
            {
                return value == 0m;
            }
            return string.IsNullOrEmpty(text);
        }
    }
}
