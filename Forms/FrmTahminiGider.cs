using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
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
    public partial class FrmTahminiGider : Form
    {
        GiderKategoriManager giderKategoriManager;
        GiderAltKategoriManager giderAltKategoriManager;
        DegisiklikManager degisiklikManager;

        public FrmTahminiGider()
        {
            InitializeComponent();

            GiderKategoriManager _giderKategoriManager = new GiderKategoriManager(new EfGiderKategoriDal());
            giderKategoriManager = _giderKategoriManager;

            GiderAltKategoriManager _giderAltKategoriManager = new GiderAltKategoriManager(new EfGiderAltKategoriDal());
            giderAltKategoriManager = _giderAltKategoriManager;

            DegisiklikManager _degisiklikManager = new DegisiklikManager(new EfDegisiklikDal());
            degisiklikManager = _degisiklikManager;
        }

        private void FrmTahminiGider_Load(object sender, EventArgs e)
        {
            GiderKategoriDoldur();
            DegisiklikDoldur();
        }

        private void GiderKategoriDoldur()
        {
            try
            {
                List<GiderKategori> giderKategorileri = giderKategoriManager.GetAll();
                cmbGiderKategori.Items.AddRange(giderKategorileri.ToArray());
                cmbGiderKategori.Items.Insert(0, "-Gider Türünü Seçiniz_");
                cmbGiderKategori.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Gider Türleri Getirilirken Hata Ouştu !");
                throw;
            }

        }

        private void DegisiklikDoldur()
        {
            List<Degisiklik> degisiklikler = degisiklikManager.GetAll();
            try
            {
                cmbDegisiklik.Items.AddRange(degisiklikler.ToArray());
                cmbDegisiklik.Items.Insert(0, "-Değişiklik Gerekiyorsa Seçiniz-");
                cmbDegisiklik.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Değişiklikler Getirilirken Hata Oluştu !");
                throw;
            }
        }

        private void cmbGiderKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbGiderAltKategori.Items.Clear();
                if (cmbGiderKategori.SelectedIndex>0)
                {
                    GiderKategori secilenGiderKategori = cmbGiderKategori.SelectedItem as GiderKategori;
                    List<GiderAltKategori> secilenGiderinAltKategorileri = giderAltKategoriManager.GetByGiderKategoriId(secilenGiderKategori.Id);
                    cmbGiderAltKategori.Items.AddRange(secilenGiderinAltKategorileri.ToArray());
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
