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
    public partial class FrmKesinHesap1Y : Form
    {
        public FrmKesinHesap1Y()
        {
            InitializeComponent();
        }

        public void AylikHesap()
        {
            decimal munzamAylik;
            decimal tahakkukEdenAylik;
            decimal iptalAylik;

            if (Convert.ToDecimal(lblOdenenAylik.Text) < Convert.ToDecimal(lblBKAylik.Text))
            {
                lblMunzamAylik.Text = 0.ToString();
            }
            else
            {
                munzamAylik = Convert.ToDecimal(lblOdenenAylik.Text) - Convert.ToDecimal(lblBKAylik.Text);
                lblMunzamAylik.Text = munzamAylik.ToString();
            }

            tahakkukEdenAylik = Convert.ToDecimal(lblBKAylik.Text) + Convert.ToDecimal(lblMunzamAylik.Text);
            lblTahakkukAylik.Text = tahakkukEdenAylik.ToString();

            iptalAylik = Convert.ToDecimal(lblTahakkukAylik.Text) - Convert.ToDecimal(lblOdenenAylik.Text);
            lblIptalAylik.Text = iptalAylik.ToString();
        }

        public void IdariMasrafHesap()
        {
            decimal munzamIdariMasraf;
            decimal tahakkukEdenIdariMasraf;
            decimal iptalIdariMasraf;

            if (Convert.ToDecimal(lblOdenenIdariMasraf.Text) < Convert.ToDecimal(lblBKIdariMasraf.Text))
            {
                lblMunzamIdariMasraf.Text = 0.ToString();
            }
            else
            {
                munzamIdariMasraf = Convert.ToDecimal(lblOdenenIdariMasraf.Text) - Convert.ToDecimal(lblBKIdariMasraf.Text);
                lblMunzamIdariMasraf.Text = munzamIdariMasraf.ToString();
            }

            tahakkukEdenIdariMasraf = Convert.ToDecimal(lblBKIdariMasraf.Text) + Convert.ToDecimal(lblMunzamIdariMasraf.Text);
            lblTahakkukIdariMasraf.Text = tahakkukEdenIdariMasraf.ToString();

            iptalIdariMasraf = Convert.ToDecimal(lblTahakkukIdariMasraf.Text) - Convert.ToDecimal(lblOdenenIdariMasraf.Text);
            lblIptalIdariMasraf.Text = iptalIdariMasraf.ToString();
        }

        public void SulamaHesap()
        {
            decimal munzamSulama;
            decimal tahakkukEdenSulama;
            decimal iptalSulama;

            if (Convert.ToDecimal(lblOdenenSulama.Text) < Convert.ToDecimal(lblBKSulama.Text))
            {
                lblMunzamSulama.Text = 0.ToString();
            }
            else
            {
                munzamSulama = Convert.ToDecimal(lblOdenenSulama.Text) - Convert.ToDecimal(lblBKSulama.Text);
                lblMunzamSulama.Text = munzamSulama.ToString();
            }

            tahakkukEdenSulama = Convert.ToDecimal(lblBKSulama.Text) + Convert.ToDecimal(lblMunzamSulama.Text);
            lblTahakkukSulama.Text = tahakkukEdenSulama.ToString();

            iptalSulama = Convert.ToDecimal(lblTahakkukSulama.Text) - Convert.ToDecimal(lblOdenenSulama.Text);
            lblIptalSulama.Text = iptalSulama.ToString();
        }

        public void AgaclamaHesap()
        {
            decimal munzamAgaclama;
            decimal tahakkukEdenAgaclama;
            decimal iptalAgaclama;

            if (Convert.ToDecimal(lblOdenenAgaclama.Text) < Convert.ToDecimal(lblBKAgaclama.Text))
            {
                lblMunzamAgaclama.Text = 0.ToString();
            }
            else
            {
                munzamAgaclama = Convert.ToDecimal(lblOdenenAgaclama.Text) - Convert.ToDecimal(lblBKAgaclama.Text);
                lblMunzamAgaclama.Text = munzamAgaclama.ToString();
            }

            tahakkukEdenAgaclama = Convert.ToDecimal(lblBKAgaclama.Text) + Convert.ToDecimal(lblMunzamAgaclama.Text);
            lblTahakkukAgaclama.Text = tahakkukEdenAgaclama.ToString();

            iptalAgaclama = Convert.ToDecimal(lblTahakkukAgaclama.Text) - Convert.ToDecimal(lblOdenenAgaclama.Text);
            lblIptalAgaclama.Text = iptalAgaclama.ToString();
        }

        public void DamizlikHesap()
        {
            decimal munzamDamizlik;
            decimal tahakkukEdenDamizlik;
            decimal iptalDamizlik;

            if (Convert.ToDecimal(lblOdenenDamizlik.Text) < Convert.ToDecimal(lblBKDamizlik.Text))
            {
                lblMunzamDamizlik.Text = 0.ToString();
            }
            else
            {
                munzamDamizlik = Convert.ToDecimal(lblOdenenDamizlik.Text) - Convert.ToDecimal(lblBKDamizlik.Text);
                lblMunzamDamizlik.Text = munzamDamizlik.ToString();
            }

            tahakkukEdenDamizlik = Convert.ToDecimal(lblBKDamizlik.Text) + Convert.ToDecimal(lblMunzamDamizlik.Text);
            lblTahakkukDamizlik.Text = tahakkukEdenDamizlik.ToString();

            iptalDamizlik = Convert.ToDecimal(lblTahakkukDamizlik.Text) - Convert.ToDecimal(lblOdenenDamizlik.Text);
            lblIptalDamizlik.Text = iptalDamizlik.ToString();
        }

        public void OrnekTarlaHesap()
        {
            decimal munzamOrnekTarla;
            decimal tahakkukEdenOrnekTarla;
            decimal iptalOrnekTarla;

            if (Convert.ToDecimal(lblOdenenOrnekTarla.Text) < Convert.ToDecimal(lblBKOrnekTarla.Text))
            {
                lblMunzamOrnekTarla.Text = 0.ToString();
            }
            else
            {
                munzamOrnekTarla = Convert.ToDecimal(lblOdenenOrnekTarla.Text) - Convert.ToDecimal(lblBKOrnekTarla.Text);
                lblMunzamOrnekTarla.Text = munzamOrnekTarla.ToString();
            }

            tahakkukEdenOrnekTarla = Convert.ToDecimal(lblBKOrnekTarla.Text) + Convert.ToDecimal(lblMunzamOrnekTarla.Text);
            lblTahakkukOrnekTarla.Text = tahakkukEdenOrnekTarla.ToString();

            iptalOrnekTarla = Convert.ToDecimal(lblTahakkukOrnekTarla.Text) - Convert.ToDecimal(lblOdenenOrnekTarla.Text);
            lblIptalOrnekTarla.Text = iptalOrnekTarla.ToString();
        }

        public void ZiraiHayvanHesap()
        {
            decimal munzamZiraiHayvan;
            decimal tahakkukEdenZiraiHayvan;
            decimal iptalZiraiHayvan;

            if (Convert.ToDecimal(lblOdenenZiraiHayvan.Text) < Convert.ToDecimal(lblBKZiraiHayvan.Text))
            {
                lblMunzamZiraiHayvan.Text = 0.ToString();
            }
            else
            {
                munzamZiraiHayvan = Convert.ToDecimal(lblOdenenZiraiHayvan.Text) - Convert.ToDecimal(lblBKZiraiHayvan.Text);
                lblMunzamZiraiHayvan.Text = munzamZiraiHayvan.ToString();
            }

            tahakkukEdenZiraiHayvan = Convert.ToDecimal(lblBKZiraiHayvan.Text) + Convert.ToDecimal(lblMunzamZiraiHayvan.Text);
            lblTahakkukZiraiHayvan.Text = tahakkukEdenZiraiHayvan.ToString();

            iptalZiraiHayvan = Convert.ToDecimal(lblTahakkukZiraiHayvan.Text) - Convert.ToDecimal(lblOdenenZiraiHayvan.Text);
            lblIptalZiraiHayvan.Text = iptalZiraiHayvan.ToString();
        }

        public void PazarCarsiHesap()
        {
            decimal munzamPazarCarsi;
            decimal tahakkukEdenPazarCarsi;
            decimal iptalPazarCarsi;

            if (Convert.ToDecimal(lblOdenenPazarCarsi.Text) < Convert.ToDecimal(lblBKPazarCarsi.Text))
            {
                lblMunzamPazarCarsi.Text = 0.ToString();
            }
            else
            {
                munzamPazarCarsi = Convert.ToDecimal(lblOdenenPazarCarsi.Text) - Convert.ToDecimal(lblBKPazarCarsi.Text);
                lblMunzamPazarCarsi.Text = munzamPazarCarsi.ToString();
            }

            tahakkukEdenPazarCarsi = Convert.ToDecimal(lblBKPazarCarsi.Text) + Convert.ToDecimal(lblMunzamPazarCarsi.Text);
            lblTahakkukPazarCarsi.Text = tahakkukEdenPazarCarsi.ToString();

            iptalPazarCarsi = Convert.ToDecimal(lblTahakkukPazarCarsi.Text) - Convert.ToDecimal(lblOdenenPazarCarsi.Text);
            lblIptalPazarCarsi.Text = iptalPazarCarsi.ToString();
        }

        public void KucukEndustriHesap()
        {
            decimal munzamKucukEndustri;
            decimal tahakkukEdenKucukEndustri;
            decimal iptalKucukEndustri;

            if (Convert.ToDecimal(lblOdenenKucukEndustri.Text) < Convert.ToDecimal(lblBKKucukEndustri.Text))
            {
                lblMunzamKucukEndustri.Text = 0.ToString();
            }
            else
            {
                munzamKucukEndustri = Convert.ToDecimal(lblOdenenKucukEndustri.Text) - Convert.ToDecimal(lblBKKucukEndustri.Text);
                lblMunzamKucukEndustri.Text = munzamKucukEndustri.ToString();
            }

            tahakkukEdenKucukEndustri = Convert.ToDecimal(lblBKKucukEndustri.Text) + Convert.ToDecimal(lblMunzamKucukEndustri.Text);
            lblTahakkukKucukEndustri.Text = tahakkukEdenKucukEndustri.ToString();

            iptalKucukEndustri = Convert.ToDecimal(lblTahakkukKucukEndustri.Text) - Convert.ToDecimal(lblOdenenKucukEndustri.Text);
            lblIptalKucukEndustri.Text = iptalKucukEndustri.ToString();
        }

        public void OgretmeneviHesap()
        {
            decimal munzamOgretmenevi;
            decimal tahakkukEdenOgretmenevi;
            decimal iptalOgretmenevi;

            if (Convert.ToDecimal(lblOdenenOgretmenevi.Text) < Convert.ToDecimal(lblBKOgretmenevi.Text))
            {
                lblMunzamOgretmenevi.Text = 0.ToString();
            }
            else
            {
                munzamOgretmenevi = Convert.ToDecimal(lblOdenenOgretmenevi.Text) - Convert.ToDecimal(lblBKOgretmenevi.Text);
                lblMunzamOgretmenevi.Text = munzamOgretmenevi.ToString();
            }

            tahakkukEdenOgretmenevi = Convert.ToDecimal(lblBKOgretmenevi.Text) + Convert.ToDecimal(lblMunzamOgretmenevi.Text);
            lblTahakkukOgretmenevi.Text = tahakkukEdenOgretmenevi.ToString();

            iptalOgretmenevi = Convert.ToDecimal(lblTahakkukOgretmenevi.Text) - Convert.ToDecimal(lblOdenenOgretmenevi.Text);
            lblIptalOgretmenevi.Text = iptalOgretmenevi.ToString();
        }

        public void OkulDaimiHesap()
        {
            decimal munzamOkulDaimi;
            decimal tahakkukEdenOkulDaimi;
            decimal iptalOkulDaimi;

            if (Convert.ToDecimal(lblOdenenOkulDaimi.Text) < Convert.ToDecimal(lblBKOkulDaimi.Text))
            {
                lblMunzamOkulDaimi.Text = 0.ToString();
            }
            else
            {
                munzamOkulDaimi = Convert.ToDecimal(lblOdenenOkulDaimi.Text) - Convert.ToDecimal(lblBKOkulDaimi.Text);
                lblMunzamOkulDaimi.Text = munzamOkulDaimi.ToString();
            }

            tahakkukEdenOkulDaimi = Convert.ToDecimal(lblBKOkulDaimi.Text) + Convert.ToDecimal(lblMunzamOkulDaimi.Text);
            lblTahakkukOkulDaimi.Text = tahakkukEdenOkulDaimi.ToString();

            iptalOkulDaimi = Convert.ToDecimal(lblTahakkukOkulDaimi.Text) - Convert.ToDecimal(lblOdenenOkulDaimi.Text);
            lblIptalOkulDaimi.Text = iptalOkulDaimi.ToString();
        }

        public void KursHesap()
        {
            decimal munzamKurs;
            decimal tahakkukEdenKurs;
            decimal iptalKurs;

            if (Convert.ToDecimal(lblOdenenKurs.Text) < Convert.ToDecimal(lblBKKurs.Text))
            {
                lblMunzamKurs.Text = 0.ToString();
            }
            else
            {
                munzamKurs = Convert.ToDecimal(lblOdenenKurs.Text) - Convert.ToDecimal(lblBKKurs.Text);
                lblMunzamKurs.Text = munzamKurs.ToString();
            }

            tahakkukEdenKurs = Convert.ToDecimal(lblBKKurs.Text) + Convert.ToDecimal(lblMunzamKurs.Text);
            lblTahakkukKurs.Text = tahakkukEdenKurs.ToString();

            iptalKurs = Convert.ToDecimal(lblTahakkukKurs.Text) - Convert.ToDecimal(lblOdenenKurs.Text);
            lblIptalKurs.Text = iptalKurs.ToString();
        }

        public void OkumaOdasiHesap()
        {
            decimal munzamOkumaOdasi;
            decimal tahakkukEdenOkumaOdasi;
            decimal iptalOkumaOdasi;

            if (Convert.ToDecimal(lblOdenenOkumaOdasi.Text) < Convert.ToDecimal(lblBKOkumaOdasi.Text))
            {
                lblMunzamOkumaOdasi.Text = 0.ToString();
            }
            else
            {
                munzamOkumaOdasi = Convert.ToDecimal(lblOdenenOkumaOdasi.Text) - Convert.ToDecimal(lblBKOkumaOdasi.Text);
                lblMunzamOkumaOdasi.Text = munzamOkumaOdasi.ToString();
            }

            tahakkukEdenOkumaOdasi = Convert.ToDecimal(lblBKOkumaOdasi.Text) + Convert.ToDecimal(lblMunzamOkumaOdasi.Text);
            lblTahakkukOkumaOdasi.Text = tahakkukEdenOkumaOdasi.ToString();

            iptalOkumaOdasi = Convert.ToDecimal(lblTahakkukOkumaOdasi.Text) - Convert.ToDecimal(lblOdenenOkumaOdasi.Text);
            lblIptalOkumaOdasi.Text = iptalOkumaOdasi.ToString();
        }

        public void OkulUygulamaHesap()
        {
            decimal munzamOkulUygulama;
            decimal tahakkukEdenOkulUygulama;
            decimal iptalOkulUygulama;

            if (Convert.ToDecimal(lblOdenenOkulUygulama.Text) < Convert.ToDecimal(lblBKOkulUygulama.Text))
            {
                lblMunzamOkulUygulama.Text = 0.ToString();
            }
            else
            {
                munzamOkulUygulama = Convert.ToDecimal(lblOdenenOkulUygulama.Text) - Convert.ToDecimal(lblBKOkulUygulama.Text);
                lblMunzamOkulUygulama.Text = munzamOkulUygulama.ToString();
            }

            tahakkukEdenOkulUygulama = Convert.ToDecimal(lblBKOkulUygulama.Text) + Convert.ToDecimal(lblMunzamOkulUygulama.Text);
            lblTahakkukOkulUygulama.Text = tahakkukEdenOkulUygulama.ToString();

            iptalOkulUygulama = Convert.ToDecimal(lblTahakkukOkulUygulama.Text) - Convert.ToDecimal(lblOdenenOkulUygulama.Text);
            lblIptalOkulUygulama.Text = iptalOkulUygulama.ToString();
        }

        public void IcmeSulariHesap()
        {
            decimal munzamIcmeSulari;
            decimal tahakkukEdenIcmeSulari;
            decimal iptalIcmeSulari;

            if (Convert.ToDecimal(lblOdenenIcmeSulari.Text) < Convert.ToDecimal(lblBKIcmeSulari.Text))
            {
                lblMunzamIcmeSulari.Text = 0.ToString();
            }
            else
            {
                munzamIcmeSulari = Convert.ToDecimal(lblOdenenIcmeSulari.Text) - Convert.ToDecimal(lblBKIcmeSulari.Text);
                lblMunzamIcmeSulari.Text = munzamIcmeSulari.ToString();
            }

            tahakkukEdenIcmeSulari = Convert.ToDecimal(lblBKIcmeSulari.Text) + Convert.ToDecimal(lblMunzamIcmeSulari.Text);
            lblTahakkukIcmeSulari.Text = tahakkukEdenIcmeSulari.ToString();

            iptalIcmeSulari = Convert.ToDecimal(lblTahakkukIcmeSulari.Text) - Convert.ToDecimal(lblOdenenIcmeSulari.Text);
            lblIptalIcmeSulari.Text = iptalIcmeSulari.ToString();
        }

        public void TemizlikHesap()
        {
            decimal munzamTemizlik;
            decimal tahakkukEdenTemizlik;
            decimal iptalTemizlik;

            if (Convert.ToDecimal(lblOdenenTemizlik.Text) < Convert.ToDecimal(lblBKTemizlik.Text))
            {
                lblMunzamTemizlik.Text = 0.ToString();
            }
            else
            {
                munzamTemizlik = Convert.ToDecimal(lblOdenenTemizlik.Text) - Convert.ToDecimal(lblBKTemizlik.Text);
                lblMunzamTemizlik.Text = munzamTemizlik.ToString();
            }

            tahakkukEdenTemizlik = Convert.ToDecimal(lblBKTemizlik.Text) + Convert.ToDecimal(lblMunzamTemizlik.Text);
            lblTahakkukTemizlik.Text = tahakkukEdenTemizlik.ToString();

            iptalTemizlik = Convert.ToDecimal(lblTahakkukTemizlik.Text) - Convert.ToDecimal(lblOdenenTemizlik.Text);
            lblIptalTemizlik.Text = iptalTemizlik.ToString();
        }

        public void SporHesap()
        {
            decimal munzamSpor;
            decimal tahakkukEdenSpor;
            decimal iptalSpor;

            if (Convert.ToDecimal(lblOdenenSpor.Text) < Convert.ToDecimal(lblBKSpor.Text))
            {
                lblMunzamSpor.Text = 0.ToString();
            }
            else
            {
                munzamSpor = Convert.ToDecimal(lblOdenenSpor.Text) - Convert.ToDecimal(lblBKSpor.Text);
                lblMunzamSpor.Text = munzamSpor.ToString();
            }

            tahakkukEdenSpor = Convert.ToDecimal(lblBKSpor.Text) + Convert.ToDecimal(lblMunzamSpor.Text);
            lblTahakkukSpor.Text = tahakkukEdenSpor.ToString();

            iptalSpor = Convert.ToDecimal(lblTahakkukSpor.Text) - Convert.ToDecimal(lblOdenenSpor.Text);
            lblIptalSpor.Text = iptalSpor.ToString();
        }

        public void IctimaiHesap()
        {
            decimal munzamIctimai;
            decimal tahakkukEdenIctimai;
            decimal iptalIctimai;

            if (Convert.ToDecimal(lblOdenenIctimai.Text) < Convert.ToDecimal(lblBKIctimai.Text))
            {
                lblMunzamIctimai.Text = 0.ToString();
            }
            else
            {
                munzamIctimai = Convert.ToDecimal(lblOdenenIctimai.Text) - Convert.ToDecimal(lblBKIctimai.Text);
                lblMunzamIctimai.Text = munzamIctimai.ToString();
            }

            tahakkukEdenIctimai = Convert.ToDecimal(lblBKIctimai.Text) + Convert.ToDecimal(lblMunzamIctimai.Text);
            lblTahakkukIctimai.Text = tahakkukEdenIctimai.ToString();

            iptalIctimai = Convert.ToDecimal(lblTahakkukIctimai.Text) - Convert.ToDecimal(lblOdenenIctimai.Text);
            lblIptalIctimai.Text = iptalIctimai.ToString();
        }

        private void FrmKesinHesap1Y_Load(object sender, EventArgs e)
        {
            {
                AylikHesap();
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
                OkulUygulamaHesap();
                IcmeSulariHesap();
                TemizlikHesap();
                SporHesap();
                IctimaiHesap();
                KursHesap();

                //public void Hesap()
                //{
                //    decimal munzam;
                //    decimal tahakkukEden;
                //    decimal iptal;

                //    if (Convert.ToDecimal(lblOdenen.Text) < Convert.ToDecimal(lblBK.Text))
                //    {
                //        lblMunzam.Text = 0.ToString();
                //    }
                //    else
                //    {
                //        munzam = Convert.ToDecimal(lblOdenen.Text) - Convert.ToDecimal(lblBK.Text);
                //        lblMunzam.Text = munzam.ToString();
                //    }

                //    tahakkukEden = Convert.ToDecimal(lblBK.Text) + Convert.ToDecimal(lblMunzam.Text);
                //    lblTahakkuk.Text = tahakkukEden.ToString();

                //    iptal = Convert.ToDecimal(lblTahakkuk.Text) - Convert.ToDecimal(lblOdenen.Text);
                //    lblIptal.Text = iptal.ToString();
                //}
            }
        }
    }
}
