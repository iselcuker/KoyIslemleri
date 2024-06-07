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
    public partial class FrmKesinHesap1 : Form
    {
        private PrintDocument printDocument;
        private PrintPreviewDialog printPreviewDialog;
        private Bitmap memoryImage;

        public FrmKesinHesap1()
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

        private void CaptureFullScreen()
        {
            //// Formun tamamının ekran görüntüsünü yakala
            //Graphics myGraphics = this.CreateGraphics();
            //Size s = this.Size;
            //memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
            //Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            //Point screenPoint = this.PointToScreen(Point.Empty);
            //memoryGraphics.CopyFromScreen(screenPoint.X, screenPoint.Y, 0, 0, s);

            // Butonu geçici olarak gizle
            btnYazdir.Visible = false;

            // Formun tamamının ekran görüntüsünü yakala
            Graphics myGraphics = this.CreateGraphics();
            Size s = this.Size;
            memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            Point screenPoint = this.PointToScreen(Point.Empty);
            memoryGraphics.CopyFromScreen(screenPoint.X, screenPoint.Y, 0, 0, s);

            // Butonu tekrar göster
            btnYazdir.Visible = true;
        }

        private void CaptureArea(Rectangle captureRectangle)
        {
            //// Belirtilen dikdörtgen alanına göre bir bitmap oluşturulur
            //memoryImage = new Bitmap(captureRectangle.Width, captureRectangle.Height);
            //Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            //memoryGraphics.CopyFromScreen(captureRectangle.Location, Point.Empty, captureRectangle.Size);

            // Butonu geçici olarak gizle
            btnYazdir.Visible = false;

            // Belirtilen dikdörtgen alanına göre bir bitmap oluşturulur
            memoryImage = new Bitmap(captureRectangle.Width, captureRectangle.Height);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            memoryGraphics.CopyFromScreen(captureRectangle.Location, Point.Empty, captureRectangle.Size);

            // Butonu tekrar göster
            btnYazdir.Visible = true;
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Yakalanan ekran görüntüsünü yazdır
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }

        public void PrintForm()
        {
            // Formun tamamının ekran görüntüsünü yakala
            CaptureFullScreen();

            // Baskı önizlemesi için PrintPreviewDialog gösterilir
            DialogResult result = printPreviewDialog.ShowDialog();

            // Eğer kullanıcı önizlemeyi onayladıysa baskı işlemi gerçekleştirilir
            if (result == DialogResult.OK && printDocument.PrinterSettings.IsValid)
            {
                printDocument.Print();
            }
        }

        private void btnYazdir_Click(object sender, EventArgs e)
        {
            // Formun tamamının ekran görüntüsünü yakala
            CaptureFullScreen();

            // Baskı önizlemesi için PrintPreviewDialog gösterilir
            DialogResult result = printPreviewDialog.ShowDialog();

            // Eğer kullanıcı önizlemeyi onayladıysa baskı işlemi gerçekleştirilir
            if (result == DialogResult.OK && printDocument.PrinterSettings.IsValid)
            {
                printDocument.Print();
            }
        }
    }
}
