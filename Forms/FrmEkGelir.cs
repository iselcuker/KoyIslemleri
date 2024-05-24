using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
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
    public partial class FrmEkGelir : Form
    {
        GelirKategoriManager gelirKategoriManager;
        DegisiklikManager degisiklikManager;

        public FrmEkGelir()
        {
            InitializeComponent();

            GelirKategoriManager _gelirKategoriManager = new GelirKategoriManager(new EfGelirKategoriDal());
            gelirKategoriManager = _gelirKategoriManager;

            DegisiklikManager _degisiklikManager = new DegisiklikManager(new EfDegisiklikDal());
            degisiklikManager = _degisiklikManager;
        }

        private void GelirKategoriDoldur()
        {
            
            try
            {
                List<GelirKategori> gelirKategoriler = gelirKategoriManager.GetAll();
                cmbGelirKategori.Items.AddRange(gelirKategoriler.ToArray());
                cmbGelirKategori.Items.Insert(0, "-Gelir Türü Seçiniz-");
                cmbGelirKategori.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Gelir Türü Getirilirken Hata oluştur !");
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

        private void FrmEkGelir_Load(object sender, EventArgs e)
        {
            try
            {
                GelirKategoriDoldur();
                DegisiklikDoldur();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
