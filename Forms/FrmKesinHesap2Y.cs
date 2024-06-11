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
    public partial class FrmKesinHesap2Y : Form
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

        public FrmKesinHesap2Y()
        {
            InitializeComponent();
            this.BackColor = Color.White; // Formun arka plan rengini beyaz yap
        }

        public void MunzamVergiHesap()
        {
            //if (lblOdenenVergi < lblBKVergi)
            //    lblMunzamVergi.Text = 0;
            //if (lblOdenenVergi > lblBKVergi)
            //    lblOdenenVergi - lblBKVergi
            decimal MunzamVergi;
            if (OdenenVergi<BKVergi)
            {
                lblMunzamVergi.Text = 0.ToString();
            }
            if (OdenenVergi > BKVergi)
            {
                MunzamVergi= Convert.ToDecimal(lblOdenenVergi.Text) - Convert.ToDecimal(lblBKVergi.Text);
                lblMunzamVergi.Text=MunzamVergi.ToString();
            }
        }

        public void MunzamTurluMasrafHesap()
        {
            //if (lblOdenenVergi < lblBKVergi)
            //    lblMunzamVergi.Text = 0;
            //if (lblOdenenVergi > lblBKVergi)
            //    lblOdenenVergi - lblBKVergi
            decimal MunzamTurluMasraf;
           
            if (Convert.ToDecimal(lblOdenenTurluMasraf.Text) < Convert.ToDecimal( lblBKTurluMasraf.Text))
            {
                lblMunzamTurluMasraf.Text = 0.ToString();
            }
            if (Convert.ToDecimal(lblOdenenTurluMasraf.Text) > Convert.ToDecimal(lblBKTurluMasraf.Text))
            {
                MunzamTurluMasraf = Convert.ToDecimal(lblOdenenTurluMasraf.Text) - Convert.ToDecimal(lblBKTurluMasraf.Text);
                lblMunzamTurluMasraf.Text = MunzamTurluMasraf.ToString();
            }

            decimal TahakkukTurluMasraf = Convert.ToDecimal(lblBKTurluMasraf.Text) + Convert.ToDecimal(lblMunzamTurluMasraf.Text);
            lblMunzamTurluMasraf.Text = TahakkukTurluMasraf.ToString();
          
            decimal IptalTurluMasraf = Convert.ToDecimal(lblTahakkukTurluMasraf.Text) - Convert.ToDecimal(lblOdenenTurluMasraf.Text);
            lblIptalTurluMasraf.Text = IptalTurluMasraf.ToString();
        }

        private void CenterLabelHorizontally(Label label, Panel panel)
        {
            // Label'ın genişliğini al
            int labelWidth = label.Width;

            // Panel'in genişliğini al
            int panelWidth = panel.Width;

            // Yeni X konumunu hesapla
            int newX = (panelWidth - labelWidth) / 2;

            // Label'ın yeni konumunu ayarla
            label.Location = new Point(newX, label.Location.Y);
        }


        private void FrmKesinHesap2Y_Load(object sender, EventArgs e)
        {
            MunzamTurluMasrafHesap();

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

            AlignLabelsToRightInPanels();
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
