using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace Forms
{
    public partial class FrmAnaSayfa : Form
    {
        IlceManager ilceManager; //Business'deki ilgili managere gidiyoruz

        private GelirManager gelirManager;

        private KoyManager koyManager;
        private DonemManager donemManager;
        private TahminiButceGelirManager tahminiButceGelirManager;
        private TahminiButceGiderManager tahminiButceGiderManager;

        //BOTUN KONTROLÜ ÝÇÝN
        private FrmTahminiButce tahminiButceForm;
        private FrmTahminiGelir tahminiGelirForm;
        private FrmTahminiGider tahminiGiderForm;



        NotManager notManager;

        private FrmGelir _frmGelir;

        public ComboBox CmbKoy
        {
            get { return cmbKoy; }
        }

        public ComboBox CmbDonem
        {
            get { return cmbDonem; }
        }


        public FrmAnaSayfa()
        {
            InitializeComponent();

            // seciliKoyIndex ve seciliDonemIndex deðerlerini uygun þekilde ayarlayýn
            int seciliKoyIndex = 0; // Örneðin, ilk köy seçili
            byte seciliDonemIndex = 0; // Örneðin, ilk dönem seçili


            new FrmTahminiButce(seciliKoyIndex, seciliDonemIndex);


            // FrmTahminiGelir formunu oluþtur
            tahminiGelirForm = new FrmTahminiGelir(seciliKoyIndex, seciliDonemIndex);
            tahminiGiderForm = new FrmTahminiGider(seciliKoyIndex, seciliDonemIndex);

            koyManager = new KoyManager(new EfKoyDal());
            donemManager = new DonemManager(new EfDonemDal());

            IlceManager _ilceManager = new IlceManager(new EfIlceDal());
            ilceManager = _ilceManager;

            KoyManager _koyManager = new KoyManager(new EfKoyDal());
            koyManager = _koyManager;

            DonemManager _donemManager = new DonemManager(new EfDonemDal());
            donemManager = _donemManager;

            NotManager _notManager = new NotManager(new EfNotDal());
            notManager = _notManager;

            // PictureBox'larýn MouseEnter ve MouseLeave olaylarýný baðlayýn
            AttachMouseEvents(pcBoxGelir, new Size(157, 95), new Size(136, 90));
            AttachMouseEvents(pcBoxGider, new Size(157, 95), new Size(136, 90));
            AttachMouseEvents(pcBoxTahminiButce, new Size(157, 95), new Size(136, 90));
            AttachMouseEvents(pcBoxEkButce, new Size(157, 95), new Size(136, 90));
            AttachMouseEvents(pcBoxKesinHesap, new Size(157, 95), new Size(136, 90));
            AttachMouseEvents(pcBoxGorevliler, new Size(157, 95), new Size(136, 90));

            // Button'larýn MouseEnter ve MouseLeave olaylarýný baðlayýn
            AttachMouseEvents(pcBoxKaydet, new Size(100, 84), new Size(85, 65));
            AttachMouseEvents(pcBoxSil, new Size(100, 84), new Size(85, 65));
            AttachMouseEvents(pcBoxGuncelle, new Size(100, 84), new Size(85, 65));
        }
        #region Butonlarýn üzerine mouse geldiðinde ve ayrýldýðýnda boyut deðiþimi
        private void AttachMouseEvents(Control control, Size enterSize, Size leaveSize)
        {
            control.MouseEnter += (sender, e) => Control_MouseEnter(sender, e, enterSize);
            control.MouseLeave += (sender, e) => Control_MouseLeave(sender, e, leaveSize);
        }

        private void Control_MouseEnter(object sender, EventArgs e, Size size)
        {
            Control control = sender as Control;
            if (control != null)
            {
                control.Size = size;
            }
        }

        private void Control_MouseLeave(object sender, EventArgs e, Size size)
        {
            Control control = sender as Control;
            if (control != null)
            {
                control.Size = size;
            }
        }
        #endregion

        private decimal HesaplaToplamGelir(int seciliKoyIndex, byte seciliDonemIndex)
        {
            using (var context = new KoyButcesiContext())
            {
                // Gelir tablosunda seciliKoyIndex ve seciliDonemIndex'e göre toplam geliri hesapla
                var toplamGelir = context.Gelirs
                    .Where(g => g.KoyId == seciliKoyIndex && g.DonemId == seciliDonemIndex)
                    .Sum(g => (decimal?)g.Tutar) ?? 0; // Tutar alanýnýn null olmasý durumunda 0 olarak ele al
                return toplamGelir;
            }
        }

        private decimal HesaplaToplamGider(int seciliKoyIndex, byte seciliDonemIndex)
        {
            using (var context = new KoyButcesiContext())
            {
                // Gider tablosunda seciliKoyIndex ve seciliDonemIndex'e göre toplam gideri hesapla
                var toplamGider = context.Giders
                    .Where(g => g.KoyId == seciliKoyIndex && g.DonemId == seciliDonemIndex)
                    .Sum(g => (decimal?)g.Tutar) ?? 0; // Tutar alanýnýn null olmasý durumunda 0 olarak ele al
                return toplamGider;
            }
        }

        public void GuncelleGelirVeGider()
        {
            if (cmbKoy.SelectedIndex > 0)
            {
                Koy secilenKoy = cmbKoy.SelectedItem as Koy;
                int seciliKoyIndex = secilenKoy.Id;
                Donem secilenDonem = cmbDonem.SelectedItem as Donem;
                byte seciliDonemIndex = Convert.ToByte(secilenDonem.Id);

                decimal toplamGelir = HesaplaToplamGelir(seciliKoyIndex, seciliDonemIndex);
                decimal toplamGider = HesaplaToplamGider(seciliKoyIndex, seciliDonemIndex);

                FrmAnaSayfa frmAnaSayfa = Application.OpenForms["FrmAnaSayfa"] as FrmAnaSayfa;
                if (frmAnaSayfa != null)
                {
                    // Toplam gelir ve giderleri etiketlere ekleyerek yazdýralým
                    frmAnaSayfa.lblToplamGelir.Text = string.Format("{0:#,0.00}.-TL", toplamGelir);
                    frmAnaSayfa.lblToplamGider.Text = string.Format("{0:#,0.00}.-TL", toplamGider);
                }
            }
        }

        //ilçe verilerini kullanýcýya sunmak ve bir ComboBox içinde görüntülemek için IlceleriDoldur() adýnda bir metot yazýyoruz
        private void IlceleriDoldur()
        {
            try
            {
                List<Ilce> ilceler = ilceManager.GetAll(); //ilceManager üzerinden tüm ilçe verileri alýnýr ve ilceler adlý bir liste deðiþkenine atanýr.
                cmbIlce.Items.AddRange(ilceler.ToArray());// ilceler listesindeki ilçe verileri ComboBox'a eklenir. ToArray() yöntemi, ilceler listesini
                                                          // bir diziye dönüþtürür ve AddRange() yöntemi ile ComboBox'ýn öðelerine eklenir.
                cmbIlce.Items.Insert(0, "-Ýlçe Seçiniz-");//ComboBox'ýn ilk öðesi olarak bir varsayýlan deðer eklenir. Bu, kullanýcýya bir seçenek sunar
                                                          //ve varsayýlan olarak seçili olmayan bir deðer belirtir.
                cmbIlce.SelectedIndex = 0;//ComboBox'ýn varsayýlan olarak seçili olan öðesinin dizinini belirtir. Bu durumda, ilk öðe (-Dönem Seçiniz-) seçili olacaktýr.

                cmbKoy.Items.Insert(0, "-Köy Seçiniz-");
                cmbKoy.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Ýlçe Listesi Getirilirken Hata Oluþtu.");
                throw;
            }
        }

        private void DonemleriDoldur()
        {
            try
            {
                List<Donem> donemler = donemManager.GetAll();
                cmbDonem.Items.Clear(); // Önceki öðeleri temizle
                cmbDonem.Items.Add("-Dönem Seçiniz"); // Ýlk öðeyi ekle
                cmbDonem.Items.AddRange(donemler.ToArray()); // Diðer öðeleri ekle
                cmbDonem.SelectedIndex = 0; // Varsayýlan olarak ilk öðeyi seç
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dönem Listesi Getirilirken Hata Oluþtu: " + ex.Message);
            }
        }

        //FrmAnaSayfa formunun yüklenme olayý(Load event) gerçekleþtiðinde IlceleriDoldur() metodu çaðrýlýr
        private void FrmAnaSayfa_Load_1(object sender, EventArgs e)
        {
            try
            {
                IlceleriDoldur();
                DonemleriDoldur();
                OgeGizle();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void OgeGizle()
        {
            try
            {
                pnlBaslik.Visible = false;
                pnlButonlar.Visible = false;
                pnlFormlar.Visible = false;
                grpNot.Visible = false;
                grpSonDurum.Visible = false;
                lblKoy.Visible = false;
                cmbKoy.Visible = false;
                lblDonem.Visible = false;
                cmbDonem.Visible = false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void cmbIlce_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbKoy.Items.Clear();
                if (cmbIlce.SelectedIndex > 0)
                {
                    Ilce secilenIlce = cmbIlce.SelectedItem as Ilce;
                    List<Koy> secilenIlceninKoyleri = koyManager.GetAllByIlceId(secilenIlce.Id);
                    cmbKoy.Items.AddRange(secilenIlceninKoyleri.ToArray());
                    cmbKoy.Items.Insert(0, "-Köy Seçiniz-");
                    cmbKoy.SelectedIndex = 0;

                    lblKoy.Visible = true;
                    cmbKoy.Visible = true;

                    // Diðer elemanlarý gizle
                    lblDonem.Visible = false;
                    cmbDonem.Visible = false;
                    grpNot.Visible = false;
                    grpSonDurum.Visible = false;
                    pnlBaslik.Visible = false;
                    pnlButonlar.Visible = false;
                    pnlFormlar.Visible = false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void pcBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void load_form(object Form)
        {
            if (this.pnlFormlar.Controls.Count > 0)
                this.pnlFormlar.Controls.RemoveAt(0);

            Form frm = Form as Form;
            frm.TopLevel = false;
            this.pnlFormlar.Controls.Add(frm);
            this.pnlFormlar.Tag = frm;
            frm.Show();
        }

        //lblToplamSonuc'a Gelir ve Gider Farkýný Yazdýrma
        public void Sonuc()
        {
            // lblToplamGelir ve lblToplamGider deðerlerini decimal olarak parse et
            if (decimal.TryParse(lblToplamGelir.Text.Replace(".-TL", "").Trim(), NumberStyles.Currency, CultureInfo.CurrentCulture, out decimal toplamGelir) &&
                decimal.TryParse(lblToplamGider.Text.Replace(".-TL", "").Trim(), NumberStyles.Currency, CultureInfo.CurrentCulture, out decimal toplamGider))
            {
                decimal sonuc = toplamGelir - toplamGider;

                // Sonucu mutlak deðere çevir
                decimal pozitifSonuc = Math.Abs(sonuc);

                // Matematiksel iþlem sonucunu lblFark'a ekleyerek yazdýr
                lblFark.Text = string.Format("{0:#,0.00}.-TL", pozitifSonuc);

                // Sonucun iþleme göre metnini belirle
                string sonucMetni = "";
                if (sonuc > 0)
                {
                    sonucMetni = "BANKADA OLMASI GEREKEN";
                }
                else if (sonuc < 0)
                {
                    sonucMetni = "MUHTAR ALACAÐI";
                }
                else
                {
                    sonucMetni = "GELÝR VE GÝDER EÞÝT";
                }

                // Sonuc metnini lblGenelSonuc etiketine ata
                lblGenelSonuc.Text = sonucMetni;
            }
        }

        private void pcBoxGelir_Click(object sender, EventArgs e)
        {
            if (cmbKoy.SelectedIndex > 0)
            {
                Koy secilenKoy = cmbKoy.SelectedItem as Koy;
                int seciliKoyIndex = secilenKoy.Id;
                Donem secilenDonem = cmbDonem.SelectedItem as Donem;
                byte seciliDonemIndex = Convert.ToByte(secilenDonem.Id);

                FrmGelir frmGelir = new FrmGelir(seciliKoyIndex, seciliDonemIndex);
                load_form(frmGelir);
            }
            else
            {
                MessageBox.Show("Lütfen Ýþlem Yapacaðýnýz Köyü Seçiniz...");
            }
        }

        private void pcBoxGider_Click_1(object sender, EventArgs e)
        {
            if (cmbKoy.SelectedIndex > 0)
            {
                Koy secilenKoy = cmbKoy.SelectedItem as Koy;
                int seciliKoyIndex = secilenKoy.Id;
                Donem secilenDonem = cmbDonem.SelectedItem as Donem;
                byte seciliDonemIndex = Convert.ToByte(secilenDonem.Id);

                FrmGider frmGider = new FrmGider(seciliKoyIndex, seciliDonemIndex);
                load_form(frmGider);
            }
            else
            {
                MessageBox.Show("Lütfen Gider Ýþlemi Yapacaðýnýz Köyü Seçiniz...");
            }
        }

        private void pcBoxTahminiButce_Click_1(object sender, EventArgs e)
        {
            if (cmbKoy.SelectedIndex > 0)
            {
                Koy secilenKoy = cmbKoy.SelectedItem as Koy; // cmbKoy'den seçilen öge aslýnda bir Koy'dur
                int seciliKoyIndex = secilenKoy.Id;
                Donem secilenDonem = cmbDonem.SelectedItem as Donem;
                byte seciliDonemIndex = Convert.ToByte(secilenDonem.Id);
                FrmTahminiButce frmTahminiButce = new FrmTahminiButce(seciliKoyIndex, seciliDonemIndex);
                load_form(frmTahminiButce);
            }
            else
            {
                MessageBox.Show("Lütfen Ýþlem Yapacaðýnýz Köyü Seçiniz...");
            }
        }

        private void pcBoxKesinHesap_Click(object sender, EventArgs e)
        {
            if (cmbKoy.SelectedIndex > 0)
            {
                Ilce secilenIlce = cmbIlce.SelectedItem as Ilce;
                byte seciliIlceIndex = Convert.ToByte(secilenIlce.Id);
                Koy secilenKoy = cmbKoy.SelectedItem as Koy; // cmbKoy'den seçilen öge aslýnda bir Koy'dur
                int seciliKoyIndex = secilenKoy.Id;
                Donem secilenDonem = cmbDonem.SelectedItem as Donem;
                byte seciliDonemIndex = Convert.ToByte(secilenDonem.Id);
                FrmKesinHesap frmKesinHesap = new FrmKesinHesap(seciliKoyIndex, seciliDonemIndex, seciliIlceIndex); //seciliKoyIndex, seciliDonemIndex FrmKesinHesap'a gönderilecek              
                load_form(frmKesinHesap);
            }
            else
            {
                MessageBox.Show("Lütfen Kesin Hesap Ýþlemi Yapacaðýnýz Köyü Seçiniz...");
            }
        }

        private void pcBoxGorevliler_Click(object sender, EventArgs e)
        {
            if (cmbKoy.SelectedIndex > 0)
            {
                Koy secilenKoy = cmbKoy.SelectedItem as Koy;
                int seciliKoyIndex = secilenKoy.Id;
                Donem secilenDonem = cmbDonem.SelectedItem as Donem;
                byte seciliDonemIndex = secilenDonem.Id;
                FrmGorevli frmGorevli = new FrmGorevli(seciliKoyIndex, seciliDonemIndex);
                load_form(frmGorevli);
            }
            else
            {
                MessageBox.Show("Lütfen Görevlilerle Ýlgili Ýþlemi Yapacaðýnýz Köyü Seçiniz...");
            }
        }



        public void cmbKoy_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblDonem.Visible = true;
                cmbDonem.Visible = true;
                // Diðer elemanlarý gizle
                grpNot.Visible = false;
                grpSonDurum.Visible = false;
                pnlBaslik.Visible = false;
                pnlButonlar.Visible = false;
                pnlFormlar.Visible = false;
                Baslik();
                PaneldekiFormuKapat();
                rchBoxNot.Text = "";
                lblToplamGelir.Text = "";
                NotGetir();
                Sonuc();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluþtu: " + ex.Message);
            }
        }

        public void cmbDonem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                grpNot.Visible = true;
                grpSonDurum.Visible = true;
                pnlBaslik.Visible = true;
                pnlButonlar.Visible = true;
                pnlFormlar.Visible = true;
                Baslik();
                NotGetir();
                lblToplamGelir.Text = "";
                PaneldekiFormuKapat();
                GuncelleGelirVeGider();
                Sonuc();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluþtu: " + ex.Message);
            }
        }

        public void Baslik()
        {
            string Baslik = cmbKoy.Text;
            string Donem = cmbDonem.Text;
            lblBaslik.Text = Baslik + " Köyü " + Donem + " Yýlý Ýþlemleri";

            // lblBaslik'in yazý rengini kýrmýzý yap
            lblBaslik.ForeColor = Color.DarkTurquoise;
        }

        private void PaneldekiFormuKapat()
        {
            if (pnlFormlar.Controls.Count > 0)
            {
                Form openForm = pnlFormlar.Controls[0] as Form;
                openForm.Close();
            }
        }

        //LABEL'ÝN PANELÝN ORTASINDA OLMASINI SAÐLAYAN METOT
        private void CenterLabel()
        {
            // Label'in boyutunu al
            int labelWidth = lblBaslik.Width;
            int labelHeight = lblBaslik.Height;

            // Panelin boyutunu al
            int panelWidth = pnlBaslik.Width;
            int panelHeight = pnlBaslik.Height;

            // Label'i panelin ortasýna yerleþtir
            int x = (panelWidth - labelWidth) / 2;
            int y = (panelHeight - labelHeight) / 2;

            lblBaslik.Location = new Point(x, y);
        }

        //LABEL'ÝN PANEL ÝÇÝNE ORTALANMASI ÝÇÝN YAZILAN METOT PANELÝN PAÝNT IVENTÝNDE ÇAÐIRILIR
        private void pnlBaslik_Paint(object sender, PaintEventArgs e)
        {
            CenterLabel();
        }

        private void pcBoxKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                Not yeniNot = new Not();
                yeniNot.KoyId = cmbKoy.SelectedIndex;
                yeniNot.DonemId = Convert.ToByte(cmbDonem.SelectedIndex);
                yeniNot.Notu = rchBoxNot.Text.ToString();
                notManager.Add(yeniNot);

                MessageBox.Show("Not baþarýyla kaydedildi.");
            }
            catch (Exception)
            {
                MessageBox.Show("Not Kayýt Edilemedi");
                throw;
            }
        }

        private void NotGetir()
        {
            // cmbKoy ve cmbDonem combobox'larýndan seçilen indeksleri al
            int secilenKoyIndex = cmbKoy.SelectedIndex;
            int secilenDonemIndex = cmbDonem.SelectedIndex;

            // Eðer her iki combobox da bir deðer seçilmiþse
            if (secilenKoyIndex != -1 && secilenDonemIndex != -1)
            {
                // cmbKoy ve cmbDonem seçimine göre notu al
                List<Not> notlar = notManager.GetByKoyIdAndDonemId(secilenKoyIndex, (byte)secilenDonemIndex);

                // Notlarý rchBoxNot'a yaz
                if (notlar != null && notlar.Count > 0)
                {
                    rchBoxNot.Text = notlar[0].Notu;
                }
                else
                {
                    // Belirtilen koþullara uygun not bulunamadýysa
                    rchBoxNot.Text = "";
                }
            }
            else
            {
                // Her iki combobox'tan da seçim yapýlmamýþsa
                rchBoxNot.Clear(); // Notu temizle
            }
        }

        private void pcBoxGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                // cmbKoy ve cmbDonem combobox'larýndan seçilen indeksleri al
                int secilenKoyIndex = cmbKoy.SelectedIndex;
                int secilenDonemIndex = cmbDonem.SelectedIndex;

                // Eðer her iki combobox da bir deðer seçilmiþse
                if (secilenKoyIndex != -1 && secilenDonemIndex != -1)
                {
                    // cmbKoy ve cmbDonem seçimine göre notu al
                    List<Not> notlar = notManager.GetByKoyIdAndDonemId(secilenKoyIndex, (byte)secilenDonemIndex);

                    // Notlarý güncelle
                    if (notlar != null && notlar.Count > 0)
                    {
                        Not guncellenecekNot = notlar[0];
                        guncellenecekNot.Notu = rchBoxNot.Text;

                        // Notu güncelle
                        notManager.Update(guncellenecekNot);

                        MessageBox.Show("Not baþarýyla güncellendi.");
                    }
                    else
                    {
                        MessageBox.Show("");
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen Koy ve Dönem seçimi yapýnýz.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Not güncellenirken bir hata oluþtu: " + ex.Message);
            }
        }

        private void pcBoxSil_Click(object sender, EventArgs e)
        {
            try
            {
                // cmbKoy ve cmbDonem combobox'larýndan seçilen indeksleri al
                int secilenKoyIndex = cmbKoy.SelectedIndex;
                int secilenDonemIndex = cmbDonem.SelectedIndex;

                // Eðer her iki combobox da bir deðer seçilmiþse
                if (secilenKoyIndex != -1 && secilenDonemIndex != -1)
                {
                    // cmbKoy ve cmbDonem seçimine göre notu al
                    List<Not> notlar = notManager.GetByKoyIdAndDonemId(secilenKoyIndex, (byte)secilenDonemIndex);

                    // Notlarý sil
                    if (notlar != null && notlar.Count > 0)
                    {
                        Not silinecekNot = notlar[0];

                        // Notu sil
                        notManager.Delete(silinecekNot);

                        MessageBox.Show("Not baþarýyla silindi.");
                        rchBoxNot.Clear(); // Silindikten sonra notu temizle
                    }
                    else
                    {
                        MessageBox.Show("");
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen Koy ve Dönem seçimi yapýnýz.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Not silinirken bir hata oluþtu: " + ex.Message);
            }
        }

        private void pcBoxEkButce_Click(object sender, EventArgs e)
        {

            if (cmbKoy.SelectedIndex > 0)
            {
                Koy secilenKoy = cmbKoy.SelectedItem as Koy; // cmbKoy'den seçilen öge aslýnda bir Koy'dur
                int seciliKoyIndex = secilenKoy.Id;
                Donem secilenDonem = cmbDonem.SelectedItem as Donem;
                byte seciliDonemIndex = Convert.ToByte(secilenDonem.Id);
                FrmEkButce frmEkButce = new FrmEkButce(seciliKoyIndex, seciliDonemIndex);
                load_form(frmEkButce);
            }
            else
            {
                MessageBox.Show("Lütfen Ýþlem Yapacaðýnýz Köyü Seçiniz...");
            }
        }

        private void pcBoxKucult_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}

