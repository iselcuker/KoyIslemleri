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
    public partial class FrmTahminiIdariIsler : Form
    {
        IdarIslerKategoriManager idariIslerKategoriManager;
        IdariIslerAltKategoriManager idariIslerAltKategoriManager;

        public FrmTahminiIdariIsler()
        {
            InitializeComponent();

            IdarIslerKategoriManager _idarIslerKategoriManager = new IdarIslerKategoriManager(new EfIdariIslerKategoriDal());
            idariIslerKategoriManager = _idarIslerKategoriManager;

            IdariIslerAltKategoriManager _idariIslerAltKategoriManager = new IdariIslerAltKategoriManager(new EfIdariIslerAltKategoriDal());
            idariIslerAltKategoriManager = _idariIslerAltKategoriManager;
        }

        private void FrmTahminiIdariIsler_Load(object sender, EventArgs e)
        {
            try
            {
                IdariIslerDoldur();

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void IdariIslerDoldur()
        {
            try
            {
                List<IdariIslerKategori> idariIslerKategorileri = idariIslerKategoriManager.GetAll();
                cmbIdariIslerKategori.Items.AddRange(idariIslerKategorileri.ToArray());
                cmbIdariIslerKategori.Items.Insert(0, "-İdari İşler Türünü Seçiniz-");
                cmbIdariIslerKategori.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("İdari İşler Türü Getirilirken Hata Oluştu");
                throw;
            }
        }

        private void cmbIdariIslerKategori_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                cmbIdariIslerAltKategori.Items.Clear();

                // Seçilen kategori index'i kontrol edilir. 
                // Eğer 0'dan büyükse (yoksa "Seçiniz" gibi bir değer seçilmiştir), işlemlere devam edilir.
                if (cmbIdariIslerKategori.SelectedIndex > 0)
                {
                    // Seçilen gider kategorisi cmbIdariIslerKategori'den alınır ve GiderKategori tipine dönüştürülür.
                    IdariIslerKategori secilenGiderKategori = cmbIdariIslerKategori.SelectedItem as IdariIslerKategori;

                    // Seçilen kategorinin alt kategorileri GetByIdariIslerKategoriId metodu ile alınır.
                    List<IdariIslerAltKategori> secilenKategorinAltKategorisi = idariIslerAltKategoriManager.GetByIdariIslerKategoriId(secilenGiderKategori.Id);

                    // cmbIdariIslerAltKategori'nin öğeleri olarak seçilen kategorinin alt kategorileri eklenir.
                    cmbIdariIslerAltKategori.Items.AddRange(secilenKategorinAltKategorisi.ToArray());
                }
            }
            catch (Exception)
            {
                // Hata durumunda hatayı yukarıya bildir.
                throw;
            }
        }
    }
}

