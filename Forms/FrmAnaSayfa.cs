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

        //BOTUN KONTROL� ���N
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

            // seciliKoyIndex ve seciliDonemIndex de�erlerini uygun �ekilde ayarlay�n
            int seciliKoyIndex = 0; // �rne�in, ilk k�y se�ili
            byte seciliDonemIndex = 0; // �rne�in, ilk d�nem se�ili


            new FrmTahminiButce(seciliKoyIndex, seciliDonemIndex);


            // FrmTahminiGelir formunu olu�tur
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

            // PictureBox'lar�n MouseEnter ve MouseLeave olaylar�n� ba�lay�n
            AttachMouseEvents(pcBoxGelir, new Size(157, 95), new Size(136, 90));
            AttachMouseEvents(pcBoxGider, new Size(157, 95), new Size(136, 90));
            AttachMouseEvents(pcBoxTahminiButce, new Size(157, 95), new Size(136, 90));
            AttachMouseEvents(pcBoxEkButce, new Size(157, 95), new Size(136, 90));
            AttachMouseEvents(pcBoxKesinHesap, new Size(157, 95), new Size(136, 90));
            AttachMouseEvents(pcBoxGorevliler, new Size(157, 95), new Size(136, 90));

            // Button'lar�n MouseEnter ve MouseLeave olaylar�n� ba�lay�n
            AttachMouseEvents(pcBoxKaydet, new Size(100, 84), new Size(85, 65));
            AttachMouseEvents(pcBoxSil, new Size(100, 84), new Size(85, 65));
            AttachMouseEvents(pcBoxGuncelle, new Size(100, 84), new Size(85, 65));
        }
        #region Butonlar�n �zerine mouse geldi�inde ve ayr�ld���nda boyut de�i�imi
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
                // Gelir tablosunda seciliKoyIndex ve seciliDonemIndex'e g�re toplam geliri hesapla
                var toplamGelir = context.Gelirs
                    .Where(g => g.KoyId == seciliKoyIndex && g.DonemId == seciliDonemIndex)
                    .Sum(g => (decimal?)g.Tutar) ?? 0; // Tutar alan�n�n null olmas� durumunda 0 olarak ele al
                return toplamGelir;
            }
        }

        private decimal HesaplaToplamGider(int seciliKoyIndex, byte seciliDonemIndex)
        {
            using (var context = new KoyButcesiContext())
            {
                // Gider tablosunda seciliKoyIndex ve seciliDonemIndex'e g�re toplam gideri hesapla
                var toplamGider = context.Giders
                    .Where(g => g.KoyId == seciliKoyIndex && g.DonemId == seciliDonemIndex)
                    .Sum(g => (decimal?)g.Tutar) ?? 0; // Tutar alan�n�n null olmas� durumunda 0 olarak ele al
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
                    // Toplam gelir ve giderleri etiketlere ekleyerek yazd�ral�m
                    frmAnaSayfa.lblToplamGelir.Text = string.Format("{0:#,0.00}.-TL", toplamGelir);
                    frmAnaSayfa.lblToplamGider.Text = string.Format("{0:#,0.00}.-TL", toplamGider);
                }
            }
        }

        //il�e verilerini kullan�c�ya sunmak ve bir ComboBox i�inde g�r�nt�lemek i�in IlceleriDoldur() ad�nda bir metot yaz�yoruz
        private void IlceleriDoldur()
        {
            try
            {
                List<Ilce> ilceler = ilceManager.GetAll(); //ilceManager �zerinden t�m il�e verileri al�n�r ve ilceler adl� bir liste de�i�kenine atan�r.
                cmbIlce.Items.AddRange(ilceler.ToArray());// ilceler listesindeki il�e verileri ComboBox'a eklenir. ToArray() y�ntemi, ilceler listesini
                                                          // bir diziye d�n��t�r�r ve AddRange() y�ntemi ile ComboBox'�n ��elerine eklenir.
                cmbIlce.Items.Insert(0, "-�l�e Se�iniz-");//ComboBox'�n ilk ��esi olarak bir varsay�lan de�er eklenir. Bu, kullan�c�ya bir se�enek sunar
                                                          //ve varsay�lan olarak se�ili olmayan bir de�er belirtir.
                cmbIlce.SelectedIndex = 0;//ComboBox'�n varsay�lan olarak se�ili olan ��esinin dizinini belirtir. Bu durumda, ilk ��e (-D�nem Se�iniz-) se�ili olacakt�r.

                cmbKoy.Items.Insert(0, "-K�y Se�iniz-");
                cmbKoy.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("�l�e Listesi Getirilirken Hata Olu�tu.");
                throw;
            }
        }

        private void DonemleriDoldur()
        {
            try
            {
                List<Donem> donemler = donemManager.GetAll();
                cmbDonem.Items.Clear(); // �nceki ��eleri temizle
                cmbDonem.Items.Add("-D�nem Se�iniz"); // �lk ��eyi ekle
                cmbDonem.Items.AddRange(donemler.ToArray()); // Di�er ��eleri ekle
                cmbDonem.SelectedIndex = 0; // Varsay�lan olarak ilk ��eyi se�
            }
            catch (Exception ex)
            {
                MessageBox.Show("D�nem Listesi Getirilirken Hata Olu�tu: " + ex.Message);
            }
        }

        //FrmAnaSayfa formunun y�klenme olay�(Load event) ger�ekle�ti�inde IlceleriDoldur() metodu �a�r�l�r
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
                    cmbKoy.Items.Insert(0, "-K�y Se�iniz-");
                    cmbKoy.SelectedIndex = 0;

                    lblKoy.Visible = true;
                    cmbKoy.Visible = true;

                    // Di�er elemanlar� gizle
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

        //lblToplamSonuc'a Gelir ve Gider Fark�n� Yazd�rma
        public void Sonuc()
        {
            // lblToplamGelir ve lblToplamGider de�erlerini decimal olarak parse et
            if (decimal.TryParse(lblToplamGelir.Text.Replace(".-TL", "").Trim(), NumberStyles.Currency, CultureInfo.CurrentCulture, out decimal toplamGelir) &&
                decimal.TryParse(lblToplamGider.Text.Replace(".-TL", "").Trim(), NumberStyles.Currency, CultureInfo.CurrentCulture, out decimal toplamGider))
            {
                decimal sonuc = toplamGelir - toplamGider;

                // Sonucu mutlak de�ere �evir
                decimal pozitifSonuc = Math.Abs(sonuc);

                // Matematiksel i�lem sonucunu lblFark'a ekleyerek yazd�r
                lblFark.Text = string.Format("{0:#,0.00}.-TL", pozitifSonuc);

                // Sonucun i�leme g�re metnini belirle
                string sonucMetni = "";
                if (sonuc > 0)
                {
                    sonucMetni = "BANKADA OLMASI GEREKEN";
                }
                else if (sonuc < 0)
                {
                    sonucMetni = "MUHTAR ALACA�I";
                }
                else
                {
                    sonucMetni = "GEL�R VE G�DER E��T";
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
                MessageBox.Show("L�tfen ��lem Yapaca��n�z K�y� Se�iniz...");
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
                MessageBox.Show("L�tfen Gider ��lemi Yapaca��n�z K�y� Se�iniz...");
            }
        }

        private void pcBoxTahminiButce_Click_1(object sender, EventArgs e)
        {
            if (cmbKoy.SelectedIndex > 0)
            {
                Koy secilenKoy = cmbKoy.SelectedItem as Koy; // cmbKoy'den se�ilen �ge asl�nda bir Koy'dur
                int seciliKoyIndex = secilenKoy.Id;
                Donem secilenDonem = cmbDonem.SelectedItem as Donem;
                byte seciliDonemIndex = Convert.ToByte(secilenDonem.Id);
                FrmTahminiButce frmTahminiButce = new FrmTahminiButce(seciliKoyIndex, seciliDonemIndex);
                load_form(frmTahminiButce);
            }
            else
            {
                MessageBox.Show("L�tfen ��lem Yapaca��n�z K�y� Se�iniz...");
            }
        }

        private void pcBoxKesinHesap_Click(object sender, EventArgs e)
        {
            if (cmbKoy.SelectedIndex > 0)
            {
                Ilce secilenIlce = cmbIlce.SelectedItem as Ilce;
                byte seciliIlceIndex = Convert.ToByte(secilenIlce.Id);
                Koy secilenKoy = cmbKoy.SelectedItem as Koy; // cmbKoy'den se�ilen �ge asl�nda bir Koy'dur
                int seciliKoyIndex = secilenKoy.Id;
                Donem secilenDonem = cmbDonem.SelectedItem as Donem;
                byte seciliDonemIndex = Convert.ToByte(secilenDonem.Id);
                FrmKesinHesap frmKesinHesap = new FrmKesinHesap(seciliKoyIndex, seciliDonemIndex, seciliIlceIndex); //seciliKoyIndex, seciliDonemIndex FrmKesinHesap'a g�nderilecek              
                load_form(frmKesinHesap);
            }
            else
            {
                MessageBox.Show("L�tfen Kesin Hesap ��lemi Yapaca��n�z K�y� Se�iniz...");
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
                MessageBox.Show("L�tfen G�revlilerle �lgili ��lemi Yapaca��n�z K�y� Se�iniz...");
            }
        }



        public void cmbKoy_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblDonem.Visible = true;
                cmbDonem.Visible = true;
                // Di�er elemanlar� gizle
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
                MessageBox.Show("Bir hata olu�tu: " + ex.Message);
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
                MessageBox.Show("Bir hata olu�tu: " + ex.Message);
            }
        }

        public void Baslik()
        {
            string Baslik = cmbKoy.Text;
            string Donem = cmbDonem.Text;
            lblBaslik.Text = Baslik + " K�y� " + Donem + " Y�l� ��lemleri";

            // lblBaslik'in yaz� rengini k�rm�z� yap
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

        //LABEL'�N PANEL�N ORTASINDA OLMASINI SA�LAYAN METOT
        private void CenterLabel()
        {
            // Label'in boyutunu al
            int labelWidth = lblBaslik.Width;
            int labelHeight = lblBaslik.Height;

            // Panelin boyutunu al
            int panelWidth = pnlBaslik.Width;
            int panelHeight = pnlBaslik.Height;

            // Label'i panelin ortas�na yerle�tir
            int x = (panelWidth - labelWidth) / 2;
            int y = (panelHeight - labelHeight) / 2;

            lblBaslik.Location = new Point(x, y);
        }

        //LABEL'�N PANEL ���NE ORTALANMASI ���N YAZILAN METOT PANEL�N PA�NT IVENT�NDE �A�IRILIR
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

                MessageBox.Show("Not ba�ar�yla kaydedildi.");
            }
            catch (Exception)
            {
                MessageBox.Show("Not Kay�t Edilemedi");
                throw;
            }
        }

        private void NotGetir()
        {
            // cmbKoy ve cmbDonem combobox'lar�ndan se�ilen indeksleri al
            int secilenKoyIndex = cmbKoy.SelectedIndex;
            int secilenDonemIndex = cmbDonem.SelectedIndex;

            // E�er her iki combobox da bir de�er se�ilmi�se
            if (secilenKoyIndex != -1 && secilenDonemIndex != -1)
            {
                // cmbKoy ve cmbDonem se�imine g�re notu al
                List<Not> notlar = notManager.GetByKoyIdAndDonemId(secilenKoyIndex, (byte)secilenDonemIndex);

                // Notlar� rchBoxNot'a yaz
                if (notlar != null && notlar.Count > 0)
                {
                    rchBoxNot.Text = notlar[0].Notu;
                }
                else
                {
                    // Belirtilen ko�ullara uygun not bulunamad�ysa
                    rchBoxNot.Text = "";
                }
            }
            else
            {
                // Her iki combobox'tan da se�im yap�lmam��sa
                rchBoxNot.Clear(); // Notu temizle
            }
        }

        private void pcBoxGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                // cmbKoy ve cmbDonem combobox'lar�ndan se�ilen indeksleri al
                int secilenKoyIndex = cmbKoy.SelectedIndex;
                int secilenDonemIndex = cmbDonem.SelectedIndex;

                // E�er her iki combobox da bir de�er se�ilmi�se
                if (secilenKoyIndex != -1 && secilenDonemIndex != -1)
                {
                    // cmbKoy ve cmbDonem se�imine g�re notu al
                    List<Not> notlar = notManager.GetByKoyIdAndDonemId(secilenKoyIndex, (byte)secilenDonemIndex);

                    // Notlar� g�ncelle
                    if (notlar != null && notlar.Count > 0)
                    {
                        Not guncellenecekNot = notlar[0];
                        guncellenecekNot.Notu = rchBoxNot.Text;

                        // Notu g�ncelle
                        notManager.Update(guncellenecekNot);

                        MessageBox.Show("Not ba�ar�yla g�ncellendi.");
                    }
                    else
                    {
                        MessageBox.Show("");
                    }
                }
                else
                {
                    MessageBox.Show("L�tfen Koy ve D�nem se�imi yap�n�z.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Not g�ncellenirken bir hata olu�tu: " + ex.Message);
            }
        }

        private void pcBoxSil_Click(object sender, EventArgs e)
        {
            try
            {
                // cmbKoy ve cmbDonem combobox'lar�ndan se�ilen indeksleri al
                int secilenKoyIndex = cmbKoy.SelectedIndex;
                int secilenDonemIndex = cmbDonem.SelectedIndex;

                // E�er her iki combobox da bir de�er se�ilmi�se
                if (secilenKoyIndex != -1 && secilenDonemIndex != -1)
                {
                    // cmbKoy ve cmbDonem se�imine g�re notu al
                    List<Not> notlar = notManager.GetByKoyIdAndDonemId(secilenKoyIndex, (byte)secilenDonemIndex);

                    // Notlar� sil
                    if (notlar != null && notlar.Count > 0)
                    {
                        Not silinecekNot = notlar[0];

                        // Notu sil
                        notManager.Delete(silinecekNot);

                        MessageBox.Show("Not ba�ar�yla silindi.");
                        rchBoxNot.Clear(); // Silindikten sonra notu temizle
                    }
                    else
                    {
                        MessageBox.Show("");
                    }
                }
                else
                {
                    MessageBox.Show("L�tfen Koy ve D�nem se�imi yap�n�z.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Not silinirken bir hata olu�tu: " + ex.Message);
            }
        }

        private void pcBoxEkButce_Click(object sender, EventArgs e)
        {

            if (cmbKoy.SelectedIndex > 0)
            {
                Koy secilenKoy = cmbKoy.SelectedItem as Koy; // cmbKoy'den se�ilen �ge asl�nda bir Koy'dur
                int seciliKoyIndex = secilenKoy.Id;
                Donem secilenDonem = cmbDonem.SelectedItem as Donem;
                byte seciliDonemIndex = Convert.ToByte(secilenDonem.Id);
                FrmEkButce frmEkButce = new FrmEkButce(seciliKoyIndex, seciliDonemIndex);
                load_form(frmEkButce);
            }
            else
            {
                MessageBox.Show("L�tfen ��lem Yapaca��n�z K�y� Se�iniz...");
            }
        }

        private void pcBoxKucult_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}

