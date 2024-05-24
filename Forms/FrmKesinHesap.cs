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
    public partial class FrmKesinHesap : Form
    {
        public FrmKesinHesap()
        {
            InitializeComponent();
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
            load_form(new FrmKesinHesap1());
        }

        private void btnKesinHesap2_Click(object sender, EventArgs e)
        {
            load_form(new FrmKesinHesap2());
        }
    }
}
