using Business.Concrete;
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

        public void HasilatHesap()
        {
            decimal munzamHasilat;
            decimal yekunHasilat;
            decimal devredenHasilat;

            if (Convert.ToDecimal(lblTahsilHasilat.Text) < Convert.ToDecimal(lblBKHasilat.Text))
            {
                lblMunzamHasilat.Text = 0.ToString();
            }
            else
            {
                munzamHasilat = Convert.ToDecimal(lblTahsilHasilat.Text) - Convert.ToDecimal(lblBKHasilat.Text);
                lblMunzamHasilat.Text = munzamHasilat.ToString();
            }

            yekunHasilat = Convert.ToDecimal(lblBKHasilat.Text) + Convert.ToDecimal(lblMunzamHasilat.Text);
            lblYekunHasilat.Text = yekunHasilat.ToString();

            devredenHasilat = Convert.ToDecimal(lblYekunHasilat.Text) - Convert.ToDecimal(lblTahsilHasilat.Text);
            lblDevredenHasilat.Text = devredenHasilat.ToString();

            if (lblMunzamHasilat.Text == "0")
            {
                lblMunzamHasilat.Visible = false;
            }
        }

        public void ResimHesap()
        {
            decimal munzamResim;
            decimal yekunResim;
            decimal devredenResim;

            if (Convert.ToDecimal(lblTahsilResim.Text) < Convert.ToDecimal(lblBKResim.Text))
            {
                lblMunzamResim.Text = 0.ToString();
            }
            else
            {
                munzamResim = Convert.ToDecimal(lblTahsilResim.Text) - Convert.ToDecimal(lblBKResim.Text);
                lblMunzamResim.Text = munzamResim.ToString();
            }

            yekunResim = Convert.ToDecimal(lblBKResim.Text) + Convert.ToDecimal(lblMunzamResim.Text);
            lblYekunResim.Text = yekunResim.ToString();

            devredenResim = Convert.ToDecimal(lblYekunResim.Text) - Convert.ToDecimal(lblTahsilResim.Text);
            lblDevredenResim.Text = devredenResim.ToString();
        }

        public void CezaHesap()
        {
            decimal munzamCeza;
            decimal yekunCeza;
            decimal devredenCeza;

            if (Convert.ToDecimal(lblTahsilCeza.Text) < Convert.ToDecimal(lblBKCeza.Text))
            {
                lblMunzamCeza.Text = 0.ToString();
            }
            else
            {
                munzamCeza = Convert.ToDecimal(lblTahsilCeza.Text) - Convert.ToDecimal(lblBKCeza.Text);
                lblMunzamCeza.Text = munzamCeza.ToString();
            }

            yekunCeza = Convert.ToDecimal(lblBKCeza.Text) + Convert.ToDecimal(lblMunzamCeza.Text);
            lblYekunCeza.Text = yekunCeza.ToString();

            devredenCeza = Convert.ToDecimal(lblYekunCeza.Text) - Convert.ToDecimal(lblTahsilCeza.Text);
            lblDevredenCeza.Text = devredenCeza.ToString();
        }

        public void YardimHesap()
        {
            decimal munzamYardim;
            decimal yekunYardim;
            decimal devredenYardim;

            if (Convert.ToDecimal(lblTahsilYardim.Text) < Convert.ToDecimal(lblBKYardim.Text))
            {
                lblMunzamYardim.Text = 0.ToString();
            }
            else
            {
                munzamYardim = Convert.ToDecimal(lblTahsilYardim.Text) - Convert.ToDecimal(lblBKYardim.Text);
                lblMunzamYardim.Text = munzamYardim.ToString();
            }

            yekunYardim = Convert.ToDecimal(lblBKYardim.Text) + Convert.ToDecimal(lblMunzamYardim.Text);
            lblYekunYardim.Text = yekunYardim.ToString();

            devredenYardim = Convert.ToDecimal(lblYekunYardim.Text) - Convert.ToDecimal(lblTahsilYardim.Text);
            lblDevredenYardim.Text = devredenYardim.ToString();
        }

        public void KoyVakifHesap()
        {
            decimal munzamKoyVakif;
            decimal yekunKoyVakif;
            decimal devredenKoyVakif;

            if (Convert.ToDecimal(lblTahsilKoyVakif.Text) < Convert.ToDecimal(lblBKKoyVakif.Text))
            {
                lblMunzamKoyVakif.Text = 0.ToString();
            }
            else
            {
                munzamKoyVakif = Convert.ToDecimal(lblTahsilKoyVakif.Text) - Convert.ToDecimal(lblBKKoyVakif.Text);
                lblMunzamKoyVakif.Text = munzamKoyVakif.ToString();
            }

            yekunKoyVakif = Convert.ToDecimal(lblBKKoyVakif.Text) + Convert.ToDecimal(lblMunzamKoyVakif.Text);
            lblYekunKoyVakif.Text = yekunKoyVakif.ToString();

            devredenKoyVakif = Convert.ToDecimal(lblYekunKoyVakif.Text) - Convert.ToDecimal(lblTahsilKoyVakif.Text);
            lblDevredenKoyVakif.Text = devredenKoyVakif.ToString();
        }

        public void IstikrazHesap()
        {
            decimal munzamIstikraz;
            decimal yekunIstikraz;
            decimal devredenIstikraz;

            if (Convert.ToDecimal(lblTahsilIstikraz.Text) < Convert.ToDecimal(lblBKIstikraz.Text))
            {
                lblMunzamIstikraz.Text = 0.ToString();
            }
            else
            {
                munzamIstikraz = Convert.ToDecimal(lblTahsilIstikraz.Text) - Convert.ToDecimal(lblBKIstikraz.Text);
                lblMunzamIstikraz.Text = munzamIstikraz.ToString();
            }

            yekunIstikraz = Convert.ToDecimal(lblBKIstikraz.Text) + Convert.ToDecimal(lblMunzamIstikraz.Text);
            lblYekunIstikraz.Text = yekunIstikraz.ToString();

            devredenIstikraz = Convert.ToDecimal(lblYekunIstikraz.Text) - Convert.ToDecimal(lblTahsilIstikraz.Text);
            lblDevredenIstikraz.Text = devredenIstikraz.ToString();
        }

        public void TurluGelirHesap()
        {
            decimal munzamTurluGelir;
            decimal yekunTurluGelir;
            decimal devredenTurluGelir;

            if (Convert.ToDecimal(lblTahsilTurluGelir.Text) < Convert.ToDecimal(lblBKTurluGelir.Text))
            {
                lblMunzamTurluGelir.Text = 0.ToString();
            }
            else
            {
                munzamTurluGelir = Convert.ToDecimal(lblTahsilTurluGelir.Text) - Convert.ToDecimal(lblBKTurluGelir.Text);
                lblMunzamTurluGelir.Text = munzamTurluGelir.ToString();
            }

            yekunTurluGelir = Convert.ToDecimal(lblBKTurluGelir.Text) + Convert.ToDecimal(lblMunzamTurluGelir.Text);
            lblYekunTurluGelir.Text = yekunTurluGelir.ToString();

            devredenTurluGelir = Convert.ToDecimal(lblYekunTurluGelir.Text) - Convert.ToDecimal(lblTahsilTurluGelir.Text);
            lblDevredenTurluGelir.Text = devredenTurluGelir.ToString();
        }

        public void DevirHesap()
        {
            decimal munzamDevir;
            decimal yekunDevir;
            decimal devredenDevir;

            if (Convert.ToDecimal(lblTahsilDevir.Text) < Convert.ToDecimal(lblBKDevir.Text))
            {
                lblMunzamDevir.Text = 0.ToString();
            }
            else
            {
                munzamDevir = Convert.ToDecimal(lblTahsilDevir.Text) - Convert.ToDecimal(lblBKDevir.Text);
                lblMunzamDevir.Text = munzamDevir.ToString();
            }

            yekunDevir = Convert.ToDecimal(lblBKDevir.Text) + Convert.ToDecimal(lblMunzamDevir.Text);
            lblYekunDevir.Text = yekunDevir.ToString();

            devredenDevir = Convert.ToDecimal(lblYekunDevir.Text) - Convert.ToDecimal(lblTahsilDevir.Text);
            lblDevredenDevir.Text = devredenDevir.ToString();
        }

        public void AskerHesap()
        {
            decimal munzamAsker;
            decimal yekunAsker;
            decimal devredenAsker;

            if (Convert.ToDecimal(lblTahsilAsker.Text) < Convert.ToDecimal(lblBKAsker.Text))
            {
                lblMunzamAsker.Text = 0.ToString();
            }
            else
            {
                munzamAsker = Convert.ToDecimal(lblTahsilAsker.Text) - Convert.ToDecimal(lblBKAsker.Text);
                lblMunzamAsker.Text = munzamAsker.ToString();
            }

            yekunAsker = Convert.ToDecimal(lblBKAsker.Text) + Convert.ToDecimal(lblMunzamAsker.Text);
            lblYekunAsker.Text = yekunAsker.ToString();

            devredenAsker = Convert.ToDecimal(lblYekunAsker.Text) - Convert.ToDecimal(lblTahsilAsker.Text);
            lblDevredenAsker.Text = devredenAsker.ToString();
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

                HasilatHesap();
                ResimHesap();
                CezaHesap();
                YardimHesap();
                KoyVakifHesap();
                IstikrazHesap();
                TurluGelirHesap();
                DevirHesap();
                AskerHesap();

                Toplamlar();
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
        }
    }
}
