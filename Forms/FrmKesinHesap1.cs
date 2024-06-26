﻿using Business.Concrete;
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
                    label.Text = string.Format("{0:#,0.00}", tahminiButceGelir.TahimiGelirTutari);
                }
                else
                {
                    //Debug.WriteLine($"GelirKategoriLabellarAyarla - Veri bulunamadı, Label 0.00 olarak ayarlandı.");
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

                //Koy, Donem ve İlçe isimlerini getiren metot
                AlanlariDoldur(_seciliKoyIndex, _seciliDonemIndex, _seciliIlceIndex);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Form yüklenirken bir hata oluştu: " + ex.Message);
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
            //decimal value;
            //if (decimal.TryParse(text, out value))
            //{
            //    return value == 0;
            //}
            //return string.IsNullOrEmpty(text);

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
    }
}
