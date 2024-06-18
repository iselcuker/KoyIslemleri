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
        decimal BKYolKopru;
        decimal BKKoyAkar;
        decimal BKVesait;
        decimal BKAydinlatma;
        decimal BKMezarlik;
        decimal BKBayindirlikToplami;
        decimal BKVergi;
        decimal BKMahkemeKesif;
        decimal BKIstimlak;
        decimal BKUmulmadik;
        decimal BKTurluMasraf;
        decimal BKIlkogretim;
        decimal BKKHGB;
        decimal BKTurluIslerToplami;
        decimal BKAskerYardim;
        decimal BKAskerToplami;
        decimal BKIdariIslerToplami;
        decimal BKZiraatToplami;
        decimal BKKulturToplami;
        decimal BKSaglıkToplami;

        decimal OdenenYolKopru;
        decimal OdenenKoyAkar;
        decimal OdenenVesait;
        decimal OdenenAydinlatma;
        decimal OdenenMezarlik;
        decimal OdenenBayindirlikToplami;
        decimal OdenenVergi;
        decimal OdenenMahkemeKesif;
        decimal OdenenIstimlak;
        decimal OdenenUmulmadik;
        decimal OdenenTurluMasraf;
        decimal OdenenIlkogretim;
        decimal OdenenKHGB;
        decimal OdenenTurluIslerToplami;
        decimal OdenenAskerYardim;
        decimal OdenenAskerToplami;
        decimal OdenenIdariIslerToplami;
        decimal OdenenZiraatToplami;
        decimal OdenenKulturToplami;
        decimal OdenenSaglıkToplami;

        public FrmKesinHesap2()
        {
            InitializeComponent();
            this.BackColor = Color.White; // Formun arka plan rengini beyaz yap
        }

        public void YolKopruHesap()
        {
            decimal munzamYolKopru = 0;
            decimal tahakkukEdenYolKopru = 0;
            decimal iptalYolKopru = 0;

            if (Convert.ToDecimal(lblOdenenYolKopru.Text) < Convert.ToDecimal(lblBKYolKopru.Text))
            {
                lblMunzamYolKopru.Text = 0.ToString();
            }
            else
            {
                munzamYolKopru = Convert.ToDecimal(lblOdenenYolKopru.Text) - Convert.ToDecimal(lblBKYolKopru.Text);
                lblMunzamYolKopru.Text = munzamYolKopru.ToString();
            }

            tahakkukEdenYolKopru = Convert.ToDecimal(lblBKYolKopru.Text) + Convert.ToDecimal(lblMunzamYolKopru.Text);
            lblTahakkukYolKopru.Text = tahakkukEdenYolKopru.ToString();

            iptalYolKopru = Convert.ToDecimal(lblTahakkukYolKopru.Text) - Convert.ToDecimal(lblOdenenYolKopru.Text);
            lblIptalYolKopru.Text = iptalYolKopru.ToString();
        }

        public void KoyAkarHesap()
        {
            decimal munzamKoyAkar;
            decimal tahakkukEdenKoyAkar;
            decimal iptalKoyAkar;

            if (Convert.ToDecimal(lblOdenenKoyAkar.Text) < Convert.ToDecimal(lblBKKoyAkar.Text))
            {
                lblMunzamKoyAkar.Text = 0.ToString();
            }
            else
            {
                munzamKoyAkar = Convert.ToDecimal(lblOdenenKoyAkar.Text) - Convert.ToDecimal(lblBKKoyAkar.Text);
                lblMunzamKoyAkar.Text = munzamKoyAkar.ToString();
            }

            tahakkukEdenKoyAkar = Convert.ToDecimal(lblBKKoyAkar.Text) + Convert.ToDecimal(lblMunzamKoyAkar.Text);
            lblTahakkukKoyAkar.Text = tahakkukEdenKoyAkar.ToString();

            iptalKoyAkar = Convert.ToDecimal(lblTahakkukKoyAkar.Text) - Convert.ToDecimal(lblOdenenKoyAkar.Text);
            lblIptalKoyAkar.Text = iptalKoyAkar.ToString();
        }

        public void VesaitHesap()
        {
            decimal munzamVesait;
            decimal tahakkukEdenVesait;
            decimal iptalVesait;

            if (Convert.ToDecimal(lblOdenenVesait.Text) < Convert.ToDecimal(lblBKVesait.Text))
            {
                lblMunzamVesait.Text = 0.ToString();
            }
            else
            {
                munzamVesait = Convert.ToDecimal(lblOdenenVesait.Text) - Convert.ToDecimal(lblBKVesait.Text);
                lblMunzamVesait.Text = munzamVesait.ToString();
            }

            tahakkukEdenVesait = Convert.ToDecimal(lblBKVesait.Text) + Convert.ToDecimal(lblMunzamVesait.Text);
            lblTahakkukVesait.Text = tahakkukEdenVesait.ToString();

            iptalVesait = Convert.ToDecimal(lblTahakkukVesait.Text) - Convert.ToDecimal(lblOdenenVesait.Text);
            lblIptalVesait.Text = iptalVesait.ToString();
        }

        public void AydinlatmaHesap()
        {
            decimal munzamAydinlatma;
            decimal tahakkukEdenAydinlatma;
            decimal iptalAydinlatma;

            if (Convert.ToDecimal(lblOdenenAydinlatma.Text) < Convert.ToDecimal(lblBKAydinlatma.Text))
            {
                lblMunzamAydinlatma.Text = 0.ToString();
            }
            else
            {
                munzamAydinlatma = Convert.ToDecimal(lblOdenenAydinlatma.Text) - Convert.ToDecimal(lblBKAydinlatma.Text);
                lblMunzamAydinlatma.Text = munzamAydinlatma.ToString();
            }

            tahakkukEdenAydinlatma = Convert.ToDecimal(lblBKAydinlatma.Text) + Convert.ToDecimal(lblMunzamAydinlatma.Text);
            lblTahakkukAydinlatma.Text = tahakkukEdenAydinlatma.ToString();

            iptalAydinlatma = Convert.ToDecimal(lblTahakkukAydinlatma.Text) - Convert.ToDecimal(lblOdenenAydinlatma.Text);
            lblIptalAydinlatma.Text = iptalAydinlatma.ToString();
        }

        public void MezarlikHesap()
        {
            decimal munzamMezarlik;
            decimal tahakkukEdenMezarlik;
            decimal iptalMezarlik;

            if (Convert.ToDecimal(lblOdenenMezarlik.Text) < Convert.ToDecimal(lblBKMezarlik.Text))
            {
                lblMunzamMezarlik.Text = 0.ToString();
            }
            else
            {
                munzamMezarlik = Convert.ToDecimal(lblOdenenMezarlik.Text) - Convert.ToDecimal(lblBKMezarlik.Text);
                lblMunzamMezarlik.Text = munzamMezarlik.ToString();
            }

            tahakkukEdenMezarlik = Convert.ToDecimal(lblBKMezarlik.Text) + Convert.ToDecimal(lblMunzamMezarlik.Text);
            lblTahakkukMezarlik.Text = tahakkukEdenMezarlik.ToString();

            iptalMezarlik = Convert.ToDecimal(lblTahakkukMezarlik.Text) - Convert.ToDecimal(lblOdenenMezarlik.Text);
            lblIptalMezarlik.Text = iptalMezarlik.ToString();
        }

        public void VergiHesap()
        {
            decimal munzamVergi;
            decimal tahakkukEdenVergi;
            decimal iptalVergi;

            if (Convert.ToDecimal(lblOdenenVergi.Text) < Convert.ToDecimal(lblBKVergi.Text))
            {
                lblMunzamVergi.Text = 0.ToString();
            }
            else
            {
                munzamVergi = Convert.ToDecimal(lblOdenenVergi.Text) - Convert.ToDecimal(lblBKVergi.Text);
                lblMunzamVergi.Text = munzamVergi.ToString();
            }

            tahakkukEdenVergi = Convert.ToDecimal(lblBKVergi.Text) + Convert.ToDecimal(lblMunzamVergi.Text);
            lblTahakkukVergi.Text = tahakkukEdenVergi.ToString();

            iptalVergi = Convert.ToDecimal(lblTahakkukVergi.Text) - Convert.ToDecimal(lblOdenenVergi.Text);
            lblIptalVergi.Text = iptalVergi.ToString();
        }

        public void KoyBorcuHesap()
        {
            decimal munzamKoyBorcu;
            decimal tahakkukEdenKoyBorcu;
            decimal iptalKoyBorcu;

            if (Convert.ToDecimal(lblOdenenKoyBorcu.Text) < Convert.ToDecimal(lblBKKoyBorcu.Text))
            {
                lblMunzamKoyBorcu.Text = 0.ToString();
            }
            else
            {
                munzamKoyBorcu = Convert.ToDecimal(lblOdenenKoyBorcu.Text) - Convert.ToDecimal(lblBKKoyBorcu.Text);
                lblMunzamKoyBorcu.Text = munzamKoyBorcu.ToString();
            }

            tahakkukEdenKoyBorcu = Convert.ToDecimal(lblBKKoyBorcu.Text) + Convert.ToDecimal(lblMunzamKoyBorcu.Text);
            lblTahakkukKoyBorcu.Text = tahakkukEdenKoyBorcu.ToString();

            iptalKoyBorcu = Convert.ToDecimal(lblTahakkukKoyBorcu.Text) - Convert.ToDecimal(lblOdenenKoyBorcu.Text);
            lblIptalKoyBorcu.Text = iptalKoyBorcu.ToString();
        }

        public void MahkemeHesap()
        {
            decimal munzamMahkeme;
            decimal tahakkukEdenMahkeme;
            decimal iptalMahkeme;

            if (Convert.ToDecimal(lblOdenenMahkeme.Text) < Convert.ToDecimal(lblBKMahkeme.Text))
            {
                lblMunzamMahkeme.Text = 0.ToString();
            }
            else
            {
                munzamMahkeme = Convert.ToDecimal(lblOdenenMahkeme.Text) - Convert.ToDecimal(lblBKMahkeme.Text);
                lblMunzamMahkeme.Text = munzamMahkeme.ToString();
            }

            tahakkukEdenMahkeme = Convert.ToDecimal(lblBKMahkeme.Text) + Convert.ToDecimal(lblMunzamMahkeme.Text);
            lblTahakkukMahkeme.Text = tahakkukEdenMahkeme.ToString();

            iptalMahkeme = Convert.ToDecimal(lblTahakkukMahkeme.Text) - Convert.ToDecimal(lblOdenenMahkeme.Text);
            lblIptalMahkeme.Text = iptalMahkeme.ToString();
        }

        public void IstimlakHesap()
        {
            decimal munzamIstimlak;
            decimal tahakkukEdenIstimlak;
            decimal iptalIstimlak;

            if (Convert.ToDecimal(lblOdenenIstimlak.Text) < Convert.ToDecimal(lblBKIstimlak.Text))
            {
                lblMunzamIstimlak.Text = 0.ToString();
            }
            else
            {
                munzamIstimlak = Convert.ToDecimal(lblOdenenIstimlak.Text) - Convert.ToDecimal(lblBKIstimlak.Text);
                lblMunzamIstimlak.Text = munzamIstimlak.ToString();
            }

            tahakkukEdenIstimlak = Convert.ToDecimal(lblBKIstimlak.Text) + Convert.ToDecimal(lblMunzamIstimlak.Text);
            lblTahakkukIstimlak.Text = tahakkukEdenIstimlak.ToString();

            iptalIstimlak = Convert.ToDecimal(lblTahakkukIstimlak.Text) - Convert.ToDecimal(lblOdenenIstimlak.Text);
            lblIptalIstimlak.Text = iptalIstimlak.ToString();
        }

        public void UmulmadikHesap()
        {
            decimal munzamUmulmadik;
            decimal tahakkukEdenUmulmadik;
            decimal iptalUmulmadik;

            if (Convert.ToDecimal(lblOdenenUmulmadik.Text) < Convert.ToDecimal(lblBKUmulmadik.Text))
            {
                lblMunzamUmulmadik.Text = 0.ToString();
            }
            else
            {
                munzamUmulmadik = Convert.ToDecimal(lblOdenenUmulmadik.Text) - Convert.ToDecimal(lblBKUmulmadik.Text);
                lblMunzamUmulmadik.Text = munzamUmulmadik.ToString();
            }

            tahakkukEdenUmulmadik = Convert.ToDecimal(lblBKUmulmadik.Text) + Convert.ToDecimal(lblMunzamUmulmadik.Text);
            lblTahakkukUmulmadik.Text = tahakkukEdenUmulmadik.ToString();

            iptalUmulmadik = Convert.ToDecimal(lblTahakkukUmulmadik.Text) - Convert.ToDecimal(lblOdenenUmulmadik.Text);
            lblIptalUmulmadik.Text = iptalUmulmadik.ToString();
        }

        public void TurluMasrafHesap()
        {
            decimal munzamTurluMasraf;
            decimal tahakkukEdenTurluMasraf;
            decimal iptalTurluMasraf;

            if (Convert.ToDecimal(lblOdenenTurluMasraf.Text) < Convert.ToDecimal(lblBKTurluMasraf.Text))
            {
                lblMunzamTurluMasraf.Text = 0.ToString();
            }
            else
            {
                munzamTurluMasraf = Convert.ToDecimal(lblOdenenTurluMasraf.Text) - Convert.ToDecimal(lblBKTurluMasraf.Text);
                lblMunzamTurluMasraf.Text = munzamTurluMasraf.ToString();
            }

            tahakkukEdenTurluMasraf = Convert.ToDecimal(lblBKTurluMasraf.Text) + Convert.ToDecimal(lblMunzamTurluMasraf.Text);
            lblTahakkukTurluMasraf.Text = tahakkukEdenTurluMasraf.ToString();

            iptalTurluMasraf = Convert.ToDecimal(lblTahakkukTurluMasraf.Text) - Convert.ToDecimal(lblOdenenTurluMasraf.Text);
            lblIptalTurluMasraf.Text = iptalTurluMasraf.ToString();
        }

        public void IlkogretimHesap()
        {
            decimal munzamIlkogretim;
            decimal tahakkukEdenIlkogretim;
            decimal iptalIlkogretim;

            if (Convert.ToDecimal(lblOdenenIlkogretim.Text) < Convert.ToDecimal(lblBKIlkogretim.Text))
            {
                lblMunzamIlkogretim.Text = 0.ToString();
            }
            else
            {
                munzamIlkogretim = Convert.ToDecimal(lblOdenenIlkogretim.Text) - Convert.ToDecimal(lblBKIlkogretim.Text);
                lblMunzamIlkogretim.Text = munzamIlkogretim.ToString();
            }

            tahakkukEdenIlkogretim = Convert.ToDecimal(lblBKIlkogretim.Text) + Convert.ToDecimal(lblMunzamIlkogretim.Text);
            lblTahakkukIlkogretim.Text = tahakkukEdenIlkogretim.ToString();

            iptalIlkogretim = Convert.ToDecimal(lblTahakkukIlkogretim.Text) - Convert.ToDecimal(lblOdenenIlkogretim.Text);
            lblIptalIlkogretim.Text = iptalIlkogretim.ToString();
        }

        public void KHGBHesap()
        {
            decimal munzamKHGB;
            decimal tahakkukEdenKHGB;
            decimal iptalKHGB;

            if (Convert.ToDecimal(lblOdenenKHGB.Text) < Convert.ToDecimal(lblBKKHGB.Text))
            {
                lblMunzamKHGB.Text = 0.ToString();
            }
            else
            {
                munzamKHGB = Convert.ToDecimal(lblOdenenKHGB.Text) - Convert.ToDecimal(lblBKKHGB.Text);
                lblMunzamKHGB.Text = munzamKHGB.ToString();
            }

            tahakkukEdenKHGB = Convert.ToDecimal(lblBKKHGB.Text) + Convert.ToDecimal(lblMunzamKHGB.Text);
            lblTahakkukKHGB.Text = tahakkukEdenKHGB.ToString();

            iptalKHGB = Convert.ToDecimal(lblTahakkukKHGB.Text) - Convert.ToDecimal(lblOdenenKHGB.Text);
            lblIptalKHGB.Text = iptalKHGB.ToString();
        }

        public void AskerHesap()
        {
            decimal munzamAskerYardim;
            decimal tahakkukEdenAskerYardim;
            decimal iptalAskerYardim;

            if (Convert.ToDecimal(lblOdenenAskerYardim.Text) < Convert.ToDecimal(lblBKAskerYardim.Text))
            {
                lblMunzamAskerYardim.Text = 0.ToString();
            }
            else
            {
                munzamAskerYardim = Convert.ToDecimal(lblOdenenAskerYardim.Text) - Convert.ToDecimal(lblBKAskerYardim.Text);
                lblMunzamAskerYardim.Text = munzamAskerYardim.ToString();
            }

            tahakkukEdenAskerYardim = Convert.ToDecimal(lblBKAskerYardim.Text) + Convert.ToDecimal(lblMunzamAskerYardim.Text);
            lblTahakkukAskerYardim.Text = tahakkukEdenAskerYardim.ToString();

            iptalAskerYardim = Convert.ToDecimal(lblTahakkukAskerYardim.Text) - Convert.ToDecimal(lblOdenenAskerYardim.Text);
            lblIptalAskerYardim.Text = iptalAskerYardim.ToString();
        }

        private void CenterLabelHorizontally(Label label, Panel panel)
        {
            // Label'ın genişliğini al
            int labelWidth = label.PreferredWidth; // PreferedWidth metine göre genişliği döner.

            // Panel'in genişliğini al
            int panelWidth = panel.Width;

            // Eğer metin sığmazsa, label genişliğini ayarla ve sağa yasla
            if (labelWidth > panelWidth)
            {
                label.AutoSize = false;
                label.Width = panelWidth;
                label.TextAlign = ContentAlignment.MiddleRight;
                label.AutoEllipsis = true;
            }
            else
            {
                // Yeni X konumunu hesapla
                int newX = (panelWidth - labelWidth) / 2;

                // Label'ı orijinal genişliğinde ortala ve sağa yasla
                label.AutoSize = true;
                label.Location = new Point(newX, label.Location.Y);
                label.TextAlign = ContentAlignment.MiddleCenter; // İçeriği ortala
            }
        }


        public void Toplamlar()
        {
            decimal BayindirlikBKToplam = Convert.ToDecimal(lblBKYolKopru.Text) + Convert.ToDecimal(lblBKKoyAkar.Text) +
                                          Convert.ToDecimal(lblBKVesait.Text) + Convert.ToDecimal(lblBKAydinlatma.Text) + Convert.ToDecimal(lblBKMezarlik.Text);
            lblBKBayindirlikToplami.Text = BayindirlikBKToplam.ToString();

            decimal BayindirlikMunzamToplam = Convert.ToDecimal(lblMunzamYolKopru.Text) + Convert.ToDecimal(lblMunzamKoyAkar.Text) +
               Convert.ToDecimal(lblMunzamVesait.Text) + Convert.ToDecimal(lblMunzamAydinlatma.Text) + Convert.ToDecimal(lblMunzamMezarlik.Text);
            lblMunzamBayindirlikToplami.Text = BayindirlikMunzamToplam.ToString();

            decimal BayindirlikTahakkukToplam = Convert.ToDecimal(lblTahakkukYolKopru.Text) + Convert.ToDecimal(lblTahakkukKoyAkar.Text) +
               Convert.ToDecimal(lblTahakkukVesait.Text) + Convert.ToDecimal(lblTahakkukAydinlatma.Text) + Convert.ToDecimal(lblTahakkukMezarlik.Text);
            lblTahakkukBayindirlikToplami.Text = BayindirlikTahakkukToplam.ToString();

            decimal BayindirlikOdenenToplam = Convert.ToDecimal(lblOdenenYolKopru.Text) + Convert.ToDecimal(lblOdenenKoyAkar.Text) +
               Convert.ToDecimal(lblOdenenVesait.Text) + Convert.ToDecimal(lblOdenenAydinlatma.Text) + Convert.ToDecimal(lblOdenenMezarlik.Text);
            lblOdenenBayindirlikToplami.Text = BayindirlikOdenenToplam.ToString();

            decimal BayindirlikIptalToplam = Convert.ToDecimal(lblIptalYolKopru.Text) + Convert.ToDecimal(lblIptalKoyAkar.Text) +
               Convert.ToDecimal(lblIptalVesait.Text) + Convert.ToDecimal(lblIptalAydinlatma.Text) + Convert.ToDecimal(lblIptalMezarlik.Text);
            lblIptalBayindirlikToplami.Text = BayindirlikIptalToplam.ToString();

            decimal TurluIslerBKToplami = Convert.ToDecimal(lblBKVergi.Text) + Convert.ToDecimal(lblBKKoyBorcu.Text) +
                                          Convert.ToDecimal(lblBKMahkeme.Text) + Convert.ToDecimal(lblBKIstimlak.Text) + Convert.ToDecimal(lblBKUmulmadik.Text) +
                                          Convert.ToDecimal(lblBKTurluMasraf.Text) + Convert.ToDecimal(lblBKIlkogretim.Text) + Convert.ToDecimal(lblBKKHGB.Text);
            lblBKTurluIslerToplami.Text = TurluIslerBKToplami.ToString();

            decimal TurluIslerMunzamToplami = Convert.ToDecimal(lblMunzamVergi.Text) + Convert.ToDecimal(lblMunzamKoyBorcu.Text) +
                                              Convert.ToDecimal(lblMunzamMahkeme.Text) + Convert.ToDecimal(lblMunzamIstimlak.Text) + Convert.ToDecimal(lblMunzamUmulmadik.Text) +
                                              Convert.ToDecimal(lblMunzamTurluMasraf.Text) + Convert.ToDecimal(lblMunzamIlkogretim.Text) + Convert.ToDecimal(lblMunzamKHGB.Text);
            lblMunzamTurluIslerToplami.Text = TurluIslerMunzamToplami.ToString();

            decimal TurluIslerTahakkukToplami = Convert.ToDecimal(lblTahakkukVergi.Text) + Convert.ToDecimal(lblTahakkukKoyBorcu.Text) +
                                                Convert.ToDecimal(lblTahakkukMahkeme.Text) + Convert.ToDecimal(lblTahakkukIstimlak.Text) + Convert.ToDecimal(lblTahakkukUmulmadik.Text) +
                                                Convert.ToDecimal(lblTahakkukTurluMasraf.Text) + Convert.ToDecimal(lblTahakkukIlkogretim.Text) + Convert.ToDecimal(lblTahakkukKHGB.Text);
            lblTahakkukTurluIslerToplami.Text = TurluIslerTahakkukToplami.ToString();

            decimal TurluIslerOdenenToplami = Convert.ToDecimal(lblOdenenVergi.Text) + Convert.ToDecimal(lblOdenenKoyBorcu.Text) +
                                         Convert.ToDecimal(lblOdenenMahkeme.Text) + Convert.ToDecimal(lblOdenenIstimlak.Text) + Convert.ToDecimal(lblOdenenUmulmadik.Text) +
                                         Convert.ToDecimal(lblOdenenTurluMasraf.Text) + Convert.ToDecimal(lblOdenenIlkogretim.Text) + Convert.ToDecimal(lblOdenenKHGB.Text);
            lblOdenenTurluIslerToplami.Text = TurluIslerOdenenToplami.ToString();

            decimal TurluIslerIptalToplami = Convert.ToDecimal(lblIptalVergi.Text) + Convert.ToDecimal(lblIptalKoyBorcu.Text) +
                                         Convert.ToDecimal(lblIptalMahkeme.Text) + Convert.ToDecimal(lblIptalIstimlak.Text) + Convert.ToDecimal(lblIptalUmulmadik.Text) +
                                         Convert.ToDecimal(lblIptalTurluMasraf.Text) + Convert.ToDecimal(lblIptalIlkogretim.Text) + Convert.ToDecimal(lblIptalKHGB.Text);
            lblIptalTurluIslerToplami.Text = TurluIslerIptalToplami.ToString();

            lblBKAskerToplami.Text = lblBKAskerYardim.Text;
            lblMunzamAskerToplami.Text = lblMunzamAskerYardim.Text;
            lblTahakkukAskerToplami.Text = lblTahakkukAskerYardim.Text;
            lblOdenenAskerToplami.Text = lblOdenenAskerYardim.Text;
            lblIptalAskerToplami.Text = lblIptalAskerYardim.Text;

            decimal butceGenelToplami = Convert.ToDecimal(lblBKIdariIsler.Text) + Convert.ToDecimal(lblBKZiraat.Text) + Convert.ToDecimal(lblBKKultur.Text) +
                                      Convert.ToDecimal(lblBKSaglik.Text) + Convert.ToDecimal(lblBKBayindirlik.Text) + Convert.ToDecimal(lblBKTurluIsler.Text) + Convert.ToDecimal(lblBKAsker.Text);
            lblButceGenelToplami.Text = butceGenelToplami.ToString();

            decimal yekun = Convert.ToDecimal(lblDevir.Text) + Convert.ToDecimal(lblGelir.Text);
            lblYekun.Text = yekun.ToString();

            decimal butceSonucu = Convert.ToDecimal(lblYekun.Text) + Convert.ToDecimal(lblToplamGider.Text);
            lblButceSonucu.Text = butceSonucu.ToString();

            lblYilToplamGeliri.Text = lblYekun.Text;
            lblYilToplamGideri.Text = lblToplamGider.Text;
        }

        private void FrmKesinHesap2Y_Load(object sender, EventArgs e)
        {
            // AlignLabelsToRightInPanels();

            TurluMasrafHesap();
            YolKopruHesap();
            KoyAkarHesap();
            VesaitHesap();
            AydinlatmaHesap();
            MezarlikHesap();
            AskerHesap();
            KHGBHesap();
            IlkogretimHesap();
            UmulmadikHesap();
            IstimlakHesap();
            MahkemeHesap();
            KoyBorcuHesap();
            VergiHesap();
            Toplamlar();

            CenterLabelHorizontally(lblMuhtar, pMuhtar);
            CenterLabelHorizontally(lblMuhtarY, pMuhtar);

            CenterLabelHorizontally(lblMudur, pMudur);
            CenterLabelHorizontally(lblMudurY, pMudur);

            CenterLabelHorizontally(lblImam, pImam);
            CenterLabelHorizontally(lblImamY, pImam);

            CenterLabelHorizontally(lblAza1, pAza1);
            CenterLabelHorizontally(lblAza1Y, pAza1);

            CenterLabelHorizontally(lblAza2, pAza2);
            CenterLabelHorizontally(lblAza2Y, pAza2);

            CenterLabelHorizontally(lblAza3, pAza3);
            CenterLabelHorizontally(lblAza3Y, pAza3);

            CenterLabelHorizontally(lblAza4, pAza4);
            CenterLabelHorizontally(lblAza4Y, pAza4);

            CenterLabelHorizontally(lblKatip, pKatip);
            CenterLabelHorizontally(lblKatipY, pKatip);
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
    }
}
