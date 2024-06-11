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

        public FrmKesinHesap()
        {
            InitializeComponent();

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

        private void btnKesinHesap1_Click(object sender, EventArgs e)
        {
            // load_form(new FrmKesinHesap1());
        }

        private void btnKesinHesap2_Click(object sender, EventArgs e)
        {
            load_form(new FrmKesinHesap2());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            load_form(new FrmKesinHesap2Y());
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
    }
}
