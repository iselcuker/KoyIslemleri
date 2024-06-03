using Business.Abstract;
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
    public partial class FrmEkButce : Form
    {
        private EkButceManager ekButceManager;

        private KoyManager koyManager;
        private DonemManager donemManager;
        private int _seciliKoyIndex;
        private byte _seciliDonemIndex;

        private FrmAnaSayfa _anaSayfaForm;
        private FrmTahminiButce _tahminiButceForm;

        private EkButceManager _ekButceManager;

        public FrmEkButce(int seciliKoyIndex, byte seciliDonemIndex)
        {
            InitializeComponent();

            //// Parametre olarak alınan değerleri sınıf değişkenlerine atayın
            //_seciliKoyIndex = seciliKoyIndex;
            //_seciliDonemIndex = seciliDonemIndex;

            //ekButceManager = new EkButceManager(new EfEkButceDal());

            //koyManager = new KoyManager(new EfKoyDal());
            //donemManager = new DonemManager(new EfDonemDal());,

            // Parametre olarak alınan değerleri sınıf değişkenlerine atayın
            _seciliKoyIndex = seciliKoyIndex;
            _seciliDonemIndex = seciliDonemIndex;

            _ekButceManager = ekButceManager;

            ekButceManager = new EkButceManager(new EfEkButceDal());

            koyManager = new KoyManager(new EfKoyDal());
            donemManager = new DonemManager(new EfDonemDal());
        }

        private void load_form(Form frm)
        {
            if (frm.IsDisposed) // Eğer form zaten atıldıysa işlem yapma
                return;

            if (this.pnlEkButceFormlari.Controls.Count > 0)
                this.pnlEkButceFormlari.Controls.RemoveAt(0);

            frm.TopLevel = false;
            this.pnlEkButceFormlari.Controls.Add(frm);
            this.pnlEkButceFormlari.Tag = frm;
            frm.Show();
        }

        private void pcBoxEkGelir_Click(object sender, EventArgs e)
        {
            // FrmAnaSayfa formunu bul ve seçili köy ve dönem indexlerini al
            FrmAnaSayfa frmAnaSayfa = Application.OpenForms["FrmAnaSayfa"] as FrmAnaSayfa;

            if (frmAnaSayfa != null)
            {
                // FrmAnaSayfa formundaki ComboBox'lardan seçili köy ve dönem indexlerini al
                Koy secilenKoy = frmAnaSayfa.CmbKoy.SelectedItem as Koy;
                int seciliKoyIndex = secilenKoy?.Id ?? _seciliKoyIndex;

                Donem secilenDonem = frmAnaSayfa.CmbDonem.SelectedItem as Donem;
                byte seciliDonemIndex = secilenDonem != null ? Convert.ToByte(secilenDonem.Id) : _seciliDonemIndex;

                // FrmTahminiGelir formunu oluştur ve load_form metoduyla yükle
                FrmEkGelir frmEkGelir = new FrmEkGelir(seciliKoyIndex, seciliDonemIndex);
                load_form(frmEkGelir);
            }
        }

        private void pcBoxEkGider_Click(object sender, EventArgs e)
        {
            // FrmAnaSayfa formunu bul ve seçili köy ve dönem indexlerini al
            FrmAnaSayfa frmAnaSayfa = Application.OpenForms["FrmAnaSayfa"] as FrmAnaSayfa;

            if (frmAnaSayfa != null)
            {
                // FrmAnaSayfa formundaki ComboBox'lardan seçili köy ve dönem indexlerini al
                Koy secilenKoy = frmAnaSayfa.CmbKoy.SelectedItem as Koy;
                int seciliKoyIndex = secilenKoy?.Id ?? _seciliKoyIndex;

                Donem secilenDonem = frmAnaSayfa.CmbDonem.SelectedItem as Donem;
                byte seciliDonemIndex = secilenDonem != null ? Convert.ToByte(secilenDonem.Id) : _seciliDonemIndex;

                // FrmTahminiGelir formunu oluştur ve load_form metoduyla yükle
                FrmEkGider frmEkGider = new FrmEkGider(seciliKoyIndex, seciliDonemIndex);
                load_form(frmEkGider);
            }
        }

        private void FrmEkButce_Load(object sender, EventArgs e)
        {
            EkButceler();
        }

        private void dgvEkButceler_DataSourceChanged(object sender, EventArgs e)
        {
            // DataGridView'deki satır sayısına bakarak pnlButceButonlari'nı gizle veya göster
            pnlEkButceButonlari.Visible = dgvEkButceler.RowCount > 0;
        }

        private void EkButceler()
        {
            try
            {
                var ekButceListesi = ekButceManager.GetAllByKoyIdAndDonemId(_seciliKoyIndex, _seciliDonemIndex);
                if (ekButceListesi != null)
                {
                    dgvEkButceler.DataSource = ekButceListesi;
                    dgvEkButceler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvEkButceler.Columns["Id"].Visible = false;
                    dgvEkButceler.Columns["KoyId"].Visible = false;
                    dgvEkButceler.Columns["DonemId"].Visible = false;
                    dgvEkButceler.EnableHeadersVisualStyles = false;
                    dgvEkButceler.RowHeadersVisible = false;
                    dgvEkButceler.ColumnHeadersDefaultCellStyle.Font = new Font("Impact", 14);
                    dgvEkButceler.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
                    dgvEkButceler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                    dgvEkButceler.ColumnHeadersHeight = 40;

                    dgvEkButceler.Columns["EkButceTutari"].HeaderText = "Tutar";

                    // DataGridView'in sütunlarının yeniden düzenlenmesini engelle.
                    dgvEkButceler.AllowUserToOrderColumns = false;
                    // DataGridView'in kullanıcı tarafından sütun eklenmesini engelle.
                    dgvEkButceler.AllowUserToAddRows = false;
                    // DataGridView'in kullanıcı tarafından sütunların silinmesini engelle.
                    dgvEkButceler.AllowUserToDeleteRows = false;
                    // DataGridView'in hücrelerin düzenlenmesini engelle.
                    dgvEkButceler.ReadOnly = true;
                    // Kullanıcının sütun boyutlarını değiştirmesini engelle.
                    dgvEkButceler.AllowUserToResizeColumns = false;
                    // Kullanıcının satır boyutlarını değiştirmesini engelle.
                    dgvEkButceler.AllowUserToResizeRows = false;
                    // Kullanıcının sütun boyutlarını değiştirmesini engelle.
                    dgvEkButceler.AllowUserToResizeColumns = false;
                    // Kullanıcının satır boyutlarını değiştirmesini engelle.
                    dgvEkButceler.AllowUserToResizeRows = false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void pcBoxKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtTutar.Text))
                {
                    EkButce yeniEkButce = new EkButce();
                    yeniEkButce.KoyId = _seciliKoyIndex;
                    yeniEkButce.DonemId = _seciliDonemIndex;
                    yeniEkButce.EkButceTutari = Convert.ToDecimal(txtTutar.Text);

                    //ekButceManager.Add(yeniEkButce);
                    ekButceManager.Add(yeniEkButce);
                    //tahminiButceIkınciKayitKontrolu = true; // aynı kaydın birden fazla girilememesi kontrolü
                    EkButceler();
                    MessageBox.Show("Ek Bütçe Kaydı Yapıldı");
                    txtTutar.Text = "";
                }
                else
                {
                    MessageBox.Show("Lütfen Boş Alanları Doldurunuz!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ek Bütçe Kaydı Yapılamadı !!!");
                throw;
            }
        }

        private void dgvEkButceler_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Sadece double click yapılan satırı seç
                dgvEkButceler.Rows[e.RowIndex].Selected = true;

                // Seçilen satırın görünürlüğünü sağla
                dgvEkButceler.FirstDisplayedScrollingRowIndex = e.RowIndex;
                dgvEkButceler.Rows[e.RowIndex].Cells[0].Selected = true;

                // Seçilen satırın bilgilerini al ve ilgili alanlara aktar
                DataGridViewRow row = dgvEkButceler.Rows[e.RowIndex];

                // Diğer alanlar ilgili hücrelerden alınıyor
                txtTutar.Text = row.Cells["EkButceTutari"].Value.ToString();
            }
        }

        private void pcBoxSil_Click(object sender, EventArgs e)
        {
            try
            {
                // Seçili satırı alır ve ilgili GiderId'yi elde eder
                if (dgvEkButceler.SelectedRows.Count > 0)
                {
                    int silinecekEkButceId = Convert.ToInt32(dgvEkButceler.SelectedRows[0].Cells["Id"].Value);

                    // Gider silinir
                    ekButceManager.Delete(new EkButce { Id = silinecekEkButceId });
                    txtTutar.Text = string.Empty;
                    // Giderler listesi yenilenir
                    EkButceler();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ek Bütçe silinirken bir hata oluştu: " + ex.Message);
            }
        }

        private void pcBoxGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                // Gerekli alanların dolu olup olmadığını kontrol eder
                if (!string.IsNullOrEmpty(txtTutar.Text))
                {
                    // Seçili satırı alır ve ilgili Gider nesnesini oluşturur
                    if (dgvEkButceler.SelectedRows.Count > 0)
                    {
                        int ekButceId = Convert.ToInt32(dgvEkButceler.SelectedRows[0].Cells["Id"].Value);

                        EkButce guncellenecekEkButce = new EkButce
                        {
                            Id = ekButceId,
                            KoyId = _seciliKoyIndex,
                            DonemId = _seciliDonemIndex,
                            EkButceTutari = Convert.ToDecimal(txtTutar.Text),
                        };

                        // Güncellenecek satırın indeksini sakla
                        int selectedRowIndex = dgvEkButceler.SelectedRows[0].Index;

                        // Gider güncellenir
                        ekButceManager.Update(guncellenecekEkButce);

                        // DataGridView'i yenile
                        EkButceler();
                        txtTutar.Text = string.Empty;

                        // Güncellenen satırı tekrar seç
                        if (dgvEkButceler.Rows.Count > selectedRowIndex)
                        {
                            // Seçili satırı tekrar seç
                            dgvEkButceler.Rows[selectedRowIndex].Selected = true;

                            // DataGridView'de bir hücreye odaklan
                            dgvEkButceler.Focus();

                            // Seçili satırın görünür alan içinde kalmasını sağla
                            dgvEkButceler.FirstDisplayedScrollingRowIndex = selectedRowIndex;
                        }
                    }
                }
                else
                {
                    // Gerekli alanların doldurulmadığı durumda kullanıcıya uyarı verilir
                    MessageBox.Show("Lütfen Boş Alanları Doldurunuz!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ek Bütçe Güncellenirken Bir Hata Oluştu: " + ex.Message);
            }
        }
    }
}
