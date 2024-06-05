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
        Bitmap memoryImage;

        public FrmKesinHesap1()
        {
            InitializeComponent();
        }

        private void FrmKesinHesap1_Load(object sender, EventArgs e)
        {

        }

        // Formun görüntüsünü yakalayan metot
        private void CaptureScreen()
        {
            // Ekran görüntüsünün tam form alanını kapsadığından emin olmak için formu yeniden çiziyoruz
            this.Refresh();
            // Formun client alanının boyutlarını alıyoruz
            Rectangle bounds = this.Bounds;

            // Formun içerik alanını yakalıyoruz
            memoryImage = new Bitmap(bounds.Width, bounds.Height);
            using (Graphics g = Graphics.FromImage(memoryImage))
            {
                g.CopyFromScreen(bounds.Location, Point.Empty, bounds.Size);
            }
        }

        private void KesinHesap1Yazdir_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Ekran görüntüsünü yazdırma alanına çiziyoruz
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }

        private void btnYazdir_Click(object sender, EventArgs e)
        {
            CaptureScreen();
            PrintDialog printDialog1 = new PrintDialog();
            printDialog1.Document = KesinHesap1Yazdir;

            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                KesinHesap1Yazdir.Print();
            }
        }

        //private void btnPrint_Click(object sender, EventArgs e)
        //{
        //    CaptureScreen();
        //    printDialog1.Document = printDocument1;

        //    if (printDialog1.ShowDialog() == DialogResult.OK)
        //    {
        //        printDocument1.Print();
        //    }
        //}
    }
}
