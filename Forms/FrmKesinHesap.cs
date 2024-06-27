using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms
{
    public partial class FrmKesinHesap : Form
    {
        private PrintDocument printDocument;
        private PrintPreviewDialog printPreviewDialog;
        private Bitmap memoryImage;

        TahminiButceGelirManager tahminiButceGelirManager;
        TahminiButceGiderManager tahminiButceGiderManager;
        GelirManager gelirManager;
        GiderManager giderManager;
        DegisiklikManager degisiklikManager;
        IlceManager ilceManager;
        KoyManager koyManager;
        DonemManager donemManager;
        //AnaSayfada comboboxlardan yapılan seçimlerin index lerini getirmek için
        byte _seciliIlceIndex;
        int _seciliKoyIndex;
        byte _seciliDonemIndex;

        public FrmKesinHesap(int seciliKoyIndex, byte seciliDonemIndex,byte seciliIlceIndex)
        {
            InitializeComponent();

            TahminiButceGelirManager _tahminiButceGelirManager = new TahminiButceGelirManager(new EfTahminiButceGelirDal());
            tahminiButceGelirManager = _tahminiButceGelirManager;

            TahminiButceGiderManager _tahminiButceGiderManager = new TahminiButceGiderManager(new EfTahminiButceGiderDal());
            tahminiButceGiderManager = _tahminiButceGiderManager;

            DegisiklikManager _degisiklikManager = new DegisiklikManager(new EfDegisiklikDal());
            degisiklikManager = _degisiklikManager;

            _seciliKoyIndex = seciliKoyIndex;
            _seciliDonemIndex = seciliDonemIndex;

            IlceManager _ilceManager = new IlceManager(new EfIlceDal());

            KoyManager _koyManager = new KoyManager(new EfKoyDal());
            koyManager = _koyManager;

            DonemManager _donemManager = new DonemManager(new EfDonemDal());
            donemManager = _donemManager;

            // Baskı işlemini gerçekleştirmek için bir PrintDocument nesnesi oluşturulur
            printDocument = new PrintDocument();
            printDocument.PrintPage += PrintDocument_PrintPage;

            // Kağıt boyutunu yatay olarak ayarlamak için DefaultPageSettings kullanılır
            printDocument.DefaultPageSettings.Landscape = true;

            // Baskı önizlemesi için bir PrintPreviewDialog nesnesi oluşturulur
            printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDocument;
        }

        public void load_form(object Form)
        {
            if (this.pnlKesinHesaplar.Controls.Count > 0)
                this.pnlKesinHesaplar.Controls.RemoveAt(0);

            Form frm = Form as Form;
            frm.TopLevel = false;
            this.pnlKesinHesaplar.Controls.Add(frm);
            this.pnlKesinHesaplar.Tag = frm;

            frm.Show();
        }

        private void btnYazdir_Click(object sender, EventArgs e)
        {
            // pnlKesinHesaplar panelinin ekran görüntüsünü yakala
            CapturePanel(pnlKesinHesaplar);

            // Baskı önizlemesi için PrintPreviewDialog gösterilir
            DialogResult result = printPreviewDialog.ShowDialog();

            // Eğer kullanıcı önizlemeyi onayladıysa baskı işlemi gerçekleştirilir
            if (result == DialogResult.OK && printDocument.PrinterSettings.IsValid)
            {
                printDocument.Print();
            }
        }

        private void CapturePanel(Panel panel)
        {
            // Panelin ekran görüntüsünü yakala
            Bitmap bitmap = new Bitmap(panel.Width, panel.Height);
            panel.DrawToBitmap(bitmap, new Rectangle(Point.Empty, panel.Size));

            // Ekran görüntüsünü belleğe al
            memoryImage = bitmap;
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Yakalanan ekran görüntüsünü yazdır
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }

        private void btnKesinHesap1_Click_1(object sender, EventArgs e)
        {
            // FrmAnaSayfa formunu bul ve seçili köy ve dönem indexlerini al
            FrmAnaSayfa frmAnaSayfa = Application.OpenForms["FrmAnaSayfa"] as FrmAnaSayfa;

            if (frmAnaSayfa != null)
            {
                // FrmAnaSayfa formundaki ComboBox'lardan seçili köy ve dönem indexlerini al
                Ilce secilenIlce = frmAnaSayfa.cmbIlce?.SelectedItem as Ilce;
                byte seciliIlceIndex = secilenIlce?.Id ?? _seciliIlceIndex;

                Koy secilenKoy = frmAnaSayfa.CmbKoy.SelectedItem as Koy;
                int seciliKoyIndex = secilenKoy?.Id ?? _seciliKoyIndex;

                Donem secilenDonem = frmAnaSayfa.CmbDonem.SelectedItem as Donem;
                byte seciliDonemIndex = secilenDonem != null ? Convert.ToByte(secilenDonem.Id) : _seciliDonemIndex;

                // FrmTahminiGelir formunu oluştur ve load_form metoduyla yükle
                FrmKesinHesap1 frmKesinHesap1Y = new FrmKesinHesap1(seciliKoyIndex, seciliDonemIndex,seciliIlceIndex);
                load_form(frmKesinHesap1Y);
            }
            //load_form(new FrmKesinHesap1Y(seciliKoyIndex,seciliDonemIndex));
        }

        private void btnKesinHesap2_Click_1(object sender, EventArgs e)
        {
            // FrmAnaSayfa formunu bul ve seçili köy ve dönem indexlerini al
            FrmAnaSayfa frmAnaSayfa = Application.OpenForms["FrmAnaSayfa"] as FrmAnaSayfa;

            if (frmAnaSayfa != null)
            {
                // FrmAnaSayfa formundaki ComboBox'lardan seçili köy ve dönem indexlerini al
                Ilce secilenIlce = frmAnaSayfa.cmbIlce?.SelectedItem as Ilce;
                byte seciliIlceIndex = secilenIlce?.Id ?? _seciliIlceIndex;

                Koy secilenKoy = frmAnaSayfa.CmbKoy.SelectedItem as Koy;
                int seciliKoyIndex = secilenKoy?.Id ?? _seciliKoyIndex;

                Donem secilenDonem = frmAnaSayfa.CmbDonem.SelectedItem as Donem;
                byte seciliDonemIndex = secilenDonem != null ? Convert.ToByte(secilenDonem.Id) : _seciliDonemIndex;

                // FrmTahminiGelir formunu oluştur ve load_form metoduyla yükle
                FrmKesinHesap2 frmKesinHesap2 = new FrmKesinHesap2(seciliKoyIndex, seciliDonemIndex, seciliIlceIndex);
                load_form(frmKesinHesap2);
            }
           // load_form(new FrmKesinHesap2());
        }
    }
}
