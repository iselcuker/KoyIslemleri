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
    public partial class FrmTahminiButce : Form
    {


        private TahminiButceManager tahminiButceManager;
        private TahminiButceGelirManager tahminiButceGelirManager;

        private KoyManager koyManager;
        private DonemManager donemManager;
        private int _seciliKoyIndex;
        private byte _seciliDonemIndex;

        private FrmAnaSayfa _anaSayfaForm;
        private FrmTahminiButce _tahminiButceForm;

        private decimal kalanButceTutari; // Kalan bütçe tutarını takip etmek için

        public FrmTahminiButce(int seciliKoyIndex, byte seciliDonemIndex)
        {
            InitializeComponent();

            // Parametre olarak alınan değerleri sınıf değişkenlerine atayın
            _seciliKoyIndex = seciliKoyIndex;
            _seciliDonemIndex = seciliDonemIndex;

            tahminiButceManager = new TahminiButceManager(new EfTahminiButceDal());

            koyManager = new KoyManager(new EfKoyDal());
            donemManager = new DonemManager(new EfDonemDal());



            pnlEkButceButonlari.Visible = false;


        }

        public void load_form(object Form)
        {
            try
            {
                // Kalan bütçeyi yükleme
                List<TahminiButce> tahminiButceList = tahminiButceManager.GetListByKoyIdAndDonemId(_seciliKoyIndex, _seciliDonemIndex);
                if (tahminiButceList != null && tahminiButceList.Count > 0)
                {
                    kalanButceTutari = tahminiButceList.Sum(tb => tb.TahminiButceTutari);
                }
                else
                {
                    MessageBox.Show("Tahmini bütçe bulunamadı!");
                }

                // Mevcut gelirleri topla ve kalan bütçeden çıkar
                List<TahminiButceGelir> mevcutGelirler = tahminiButceGelirManager.GetListByKoyIdAndDonemId(_seciliKoyIndex, _seciliDonemIndex);
                decimal toplamGelir = mevcutGelirler.Sum(g => g.TahimiGelirTutari);
                kalanButceTutari -= toplamGelir;

                if (kalanButceTutari <= 0)
                {
                    pcBoxTahminiGelir.Enabled = false; // Kalan bütçe sıfır veya negatif ise butonu devre dışı bırak
                    MessageBox.Show("Tahmini Bütçe Tutarına Ulaştınız. Yeni kayıt giremezsiniz.");
                }

                TahminiButceler();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tahmini bütçe yüklenirken bir hata oluştu: " + ex.Message);
            }
        }

        private void pcBoxTahminiGelir_Click(object sender, EventArgs e)
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
                FrmTahminiGelir frmTahminiGelir = new FrmTahminiGelir(seciliKoyIndex, seciliDonemIndex);
                load_form(frmTahminiGelir);
            }
        }

        private void pcBoxTahminiGider_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa frmAnaSayfa = Application.OpenForms["FrmAnaSayfa"] as FrmAnaSayfa;
            if (frmAnaSayfa != null)
            {
                Koy secilenKoy = frmAnaSayfa.CmbKoy.SelectedItem as Koy;
                int seciliKoyIndex = secilenKoy?.Id ?? _seciliKoyIndex;

                Donem secilenDonem = frmAnaSayfa.CmbDonem.SelectedItem as Donem;
                byte seciliDonemIndex = secilenDonem != null ? Convert.ToByte(secilenDonem.Id) : _seciliDonemIndex;
                FrmTahminiGider frmTahminiGider = new FrmTahminiGider(seciliKoyIndex, seciliDonemIndex);
                load_form(new FrmTahminiGider(seciliKoyIndex, seciliDonemIndex));
            }


        }

        private void pcBoxIdariIsler_Click(object sender, EventArgs e)
        {
            load_form(new FrmTahminiIdariIsler());
            // pnlButceFormlari.Location = new Point(200, 210);
        }

        private void pcBoxEkButce_Click(object sender, EventArgs e)
        {
            load_form(new FrmEkButce());
            pnlButceButonlari.Visible = false;
            //pnlButceFormlari.Location = new Point(200, 210);
            pnlEkButceButonlari.Visible = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            load_form(new FrmEkGelir());
            pnlButceButonlari.Visible = false;
            //pnlButceFormlari.Location = new Point(200, 210);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            load_form(new FrmEkGider());
            pnlButceButonlari.Visible = false;
            //pnlButceFormlari.Location = new Point(200, 210);
        }


        private bool tahminiButceIkınciKayitKontrolu = false;

        private void pcBoxKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                // İlgili _seciliKoyIndex ve _seciliDonemIndex'e ait bir kayıt var mı kontrol edelim
                var existingRecords = tahminiButceManager.GetListByKoyIdAndDonemId(_seciliKoyIndex, _seciliDonemIndex);
                if (existingRecords.Any())
                {
                    MessageBox.Show("Bu köy ve döneme ait tahmini bütçe zaten kaydedilmiş!");
                    return; // İşlemi sonlandır
                }

                if (!string.IsNullOrEmpty(txtButceTutari.Text))
                {
                    TahminiButce yeniTahminiButce = new TahminiButce();
                    yeniTahminiButce.KoyId = _seciliKoyIndex;
                    yeniTahminiButce.DonemId = _seciliDonemIndex;
                    yeniTahminiButce.TahminiButceTutari = Convert.ToDecimal(txtButceTutari.Text);

                    tahminiButceManager.Add(yeniTahminiButce);
                    tahminiButceIkınciKayitKontrolu = true; // aynı kaydın birden fazla girilememesi kontrolü
                    TahminiButceler();
                    MessageBox.Show("Tahmini Bütçe Kaydı Yapıldı");
                    txtButceTutari.Text = "";
                }
                else
                {
                    MessageBox.Show("Lütfen Boş Alanları Doldurunuz!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Tahmini Bütçe Kaydı Yapılamadı !!!");
                throw;
            }
        }

        private void TahminiButceler()
        {
            try
            {
                var tahminiButceListesi = tahminiButceManager.GetListByKoyIdAndDonemId(_seciliKoyIndex, _seciliDonemIndex);
                if (tahminiButceListesi != null)
                {
                    dgvTahminiButceler.DataSource = tahminiButceListesi;
                    dgvTahminiButceler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvTahminiButceler.Columns["Id"].Visible = false;
                    dgvTahminiButceler.Columns["KoyId"].Visible = false;
                    dgvTahminiButceler.Columns["DonemId"].Visible = false;
                    dgvTahminiButceler.EnableHeadersVisualStyles = false;
                    dgvTahminiButceler.RowHeadersVisible = false;
                    dgvTahminiButceler.ColumnHeadersDefaultCellStyle.Font = new Font("Impact", 14);
                    dgvTahminiButceler.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
                    dgvTahminiButceler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                    dgvTahminiButceler.ColumnHeadersHeight = 40;

                    // DataGridView'in sütunlarının yeniden düzenlenmesini engelle.
                    dgvTahminiButceler.AllowUserToOrderColumns = false;
                    // DataGridView'in kullanıcı tarafından sütun eklenmesini engelle.
                    dgvTahminiButceler.AllowUserToAddRows = false;
                    // DataGridView'in kullanıcı tarafından sütunların silinmesini engelle.
                    dgvTahminiButceler.AllowUserToDeleteRows = false;
                    // DataGridView'in hücrelerin düzenlenmesini engelle.
                    dgvTahminiButceler.ReadOnly = true;
                    // Kullanıcının sütun boyutlarını değiştirmesini engelle.
                    dgvTahminiButceler.AllowUserToResizeColumns = false;
                    // Kullanıcının satır boyutlarını değiştirmesini engelle.
                    dgvTahminiButceler.AllowUserToResizeRows = false;
                    // Kullanıcının sütun boyutlarını değiştirmesini engelle.
                    dgvTahminiButceler.AllowUserToResizeColumns = false;
                    // Kullanıcının satır boyutlarını değiştirmesini engelle.
                    dgvTahminiButceler.AllowUserToResizeRows = false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void FrmTahminiButce_Load(object sender, EventArgs e)
        {
            //TahminiButceler();
            try
            {
                // Kalan bütçeyi yükleme
                List<TahminiButce> tahminiButceList = tahminiButceManager.GetListByKoyIdAndDonemId(_seciliKoyIndex, _seciliDonemIndex);
                if (tahminiButceList != null && tahminiButceList.Count > 0)
                {
                    kalanButceTutari = tahminiButceList.Sum(tb => tb.TahminiButceTutari);
                }
                else
                {
                    MessageBox.Show("Tahmini bütçe bulunamadı!");
                }

                TahminiButceler();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tahmini bütçe yüklenirken bir hata oluştu: " + ex.Message);
            }
        }

        private void load_form(Form frm)
        {
            if (frm.IsDisposed) // Eğer form zaten atıldıysa işlem yapma
                return;

            if (this.pnlButceFormlari.Controls.Count > 0)
                this.pnlButceFormlari.Controls.RemoveAt(0);

            frm.TopLevel = false;
            this.pnlButceFormlari.Controls.Add(frm);
            this.pnlButceFormlari.Tag = frm;
            frm.Show();
        }

        private void dgvTahminiButceler_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Sadece double click yapılan satırı seç
                dgvTahminiButceler.Rows[e.RowIndex].Selected = true;

                // Seçilen satırın görünürlüğünü sağla
                dgvTahminiButceler.FirstDisplayedScrollingRowIndex = e.RowIndex;
                dgvTahminiButceler.Rows[e.RowIndex].Cells[0].Selected = true;

                // Seçilen satırın bilgilerini al ve ilgili alanlara aktar
                DataGridViewRow row = dgvTahminiButceler.Rows[e.RowIndex];

                // Diğer alanlar ilgili hücrelerden alınıyor
                txtButceTutari.Text = row.Cells["TahminiButceTutari"].Value.ToString();
            }
        }

        public void pcBoxGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                // Gerekli alanların dolu olup olmadığını kontrol eder
                if (!string.IsNullOrEmpty(txtButceTutari.Text))
                {
                    // Seçili satırı alır ve ilgili Gider nesnesini oluşturur
                    if (dgvTahminiButceler.SelectedRows.Count > 0)
                    {
                        int tahminiButceId = Convert.ToInt32(dgvTahminiButceler.SelectedRows[0].Cells["Id"].Value);

                        TahminiButce guncellenecekTahminiButce = new TahminiButce
                        {
                            Id = tahminiButceId,
                            KoyId = _seciliKoyIndex,
                            DonemId = _seciliDonemIndex,
                            TahminiButceTutari = Convert.ToDecimal(txtButceTutari.Text),
                        };

                        // Güncellenecek satırın indeksini sakla
                        int selectedRowIndex = dgvTahminiButceler.SelectedRows[0].Index;

                        // Gider güncellenir
                        tahminiButceManager.Update(guncellenecekTahminiButce);

                        // DataGridView'i yenile
                        TahminiButceler();
                        txtButceTutari.Text = string.Empty;

                        // Güncellenen satırı tekrar seç
                        if (dgvTahminiButceler.Rows.Count > selectedRowIndex)
                        {
                            // Seçili satırı tekrar seç
                            dgvTahminiButceler.Rows[selectedRowIndex].Selected = true;

                            // DataGridView'de bir hücreye odaklan
                            dgvTahminiButceler.Focus();

                            // Seçili satırın görünür alan içinde kalmasını sağla
                            dgvTahminiButceler.FirstDisplayedScrollingRowIndex = selectedRowIndex;
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
                MessageBox.Show("Gider Güncellenirken Bir Hata Oluştu: " + ex.Message);
            }
        }

        public void pcBoxSil_Click(object sender, EventArgs e)
        {
            try
            {
                // Seçili satırı alır ve ilgili GiderId'yi elde eder
                if (dgvTahminiButceler.SelectedRows.Count > 0)
                {
                    int silinecekTahminiButceId = Convert.ToInt32(dgvTahminiButceler.SelectedRows[0].Cells["Id"].Value);

                    // Gider silinir
                    tahminiButceManager.Delete(new TahminiButce { Id = silinecekTahminiButceId });
                    txtButceTutari.Text = string.Empty;
                    // Giderler listesi yenilenir
                    TahminiButceler();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gider silinirken bir hata oluştu: " + ex.Message);
            }
        }
    }
}
