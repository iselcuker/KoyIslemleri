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
    public partial class FrmEkGider : Form
    {
        GiderKategoriManager giderKategoriManager;
        GiderAltKategoriManager giderAltKategoriManager;
        DegisiklikManager degisiklikManager;
        TahminiButceGelirManager tahminiButceGelirManager;
        KoyManager koyManager;
        DonemManager donemManager;
        //AnaSayfada comboboxlardan yapılan seçimlerin index lerini getirmek için
        int _seciliKoyIndex;
        byte _seciliDonemIndex;

        public FrmEkGider(int seciliKoyIndex, byte seciliDonemIndex)
        {
            InitializeComponent();
            GiderKategoriManager _giderKategoriManager = new GiderKategoriManager(new EfGiderKategoriDal());
            giderKategoriManager = _giderKategoriManager;

            GiderAltKategoriManager _giderAltKategoriManager = new GiderAltKategoriManager(new EfGiderAltKategoriDal());
            giderAltKategoriManager = _giderAltKategoriManager;

            TahminiButceGelirManager _tahminiButceGelirManager = new TahminiButceGelirManager(new EfTahminiButceGelirDal());
            tahminiButceGelirManager = _tahminiButceGelirManager;

            DegisiklikManager _degisiklikManager = new DegisiklikManager(new EfDegisiklikDal());
            degisiklikManager = _degisiklikManager;

            _seciliKoyIndex = seciliKoyIndex;
            _seciliDonemIndex = seciliDonemIndex;

            KoyManager _koyManager = new KoyManager(new EfKoyDal());
            koyManager = _koyManager;

            DonemManager _donemManager = new DonemManager(new EfDonemDal());
            donemManager = _donemManager;
        }

        private void GiderKategoriDoldur()
        {
            try
            {
                List<GiderKategori> giderKategorileri = giderKategoriManager.GetAll();
                cmbGiderKategori.Items.AddRange(giderKategorileri.ToArray());
                cmbGiderKategori.Items.Insert(0, "-Gider Türü Seçiniz-");
                cmbGiderKategori.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Gider Türü Yüklenemedi !");
                throw;
            }
        }

        private void FrmEkGider_Load(object sender, EventArgs e)
        {
            GiderKategoriDoldur();
        }

        private void cmbGiderKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Temizleme: cmbGiderAltKategori'nin içeriğini temizler.
                cmbGiderAltKategori.Items.Clear();

                // Seçilen kategori index'i kontrol edilir. 
                // Eğer 0'dan büyükse (yoksa "Seçiniz" gibi bir değer seçilmiştir), işlemlere devam edilir.
                if (cmbGiderKategori.SelectedIndex > 0)
                {
                    // Seçilen gider kategorisi cmbGiderKategori'den alınır ve GiderKategori tipine dönüştürülür.
                    GiderKategori secilenGiderKategori = cmbGiderKategori.SelectedItem as GiderKategori;

                    // Seçilen kategorinin alt kategorileri GetByGiderKategoriId metodu ile alınır.
                    List<GiderAltKategori> secilenKategorinAltKategorisi = giderAltKategoriManager.GetByGiderKategoriId(secilenGiderKategori.Id);

                    // cmbGiderAltKategori'nin öğeleri olarak seçilen kategorinin alt kategorileri eklenir.
                    cmbGiderAltKategori.Items.AddRange(secilenKategorinAltKategorisi.ToArray());
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
