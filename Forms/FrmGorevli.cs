using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
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
    public partial class FrmGorevli : Form
    {
        // Yöneticiler ve seçili indeksler için gerekli değişkenler tanımlanıyor
        private GorevliManager gorevliManager;
        private UnvanManager unvanManager;
        private KoyManager koyManager;
        private DonemManager donemManager;
        private int _seciliKoyIndex;
        private byte _seciliDonemIndex;

        public FrmGorevli(int seciliKoyIndex, byte seciliDonemIndex)
        {
            InitializeComponent();
            // Yöneticiler oluşturuluyor ve alanlara atanıyor
            gorevliManager = new GorevliManager(new EfGorevliDal());
            unvanManager = new UnvanManager(new EfUnvanDal());
            koyManager = new KoyManager(new EfKoyDal());
            donemManager = new DonemManager(new EfDonemDal());

            // Parametreler sınıfın alanlarına atanıyor
            _seciliKoyIndex = seciliKoyIndex;
            _seciliDonemIndex = seciliDonemIndex;

            // Form yüklenirken Gorevliler() metodunu çağır
            this.Load += new EventHandler(FrmGorevli_Load);

        }

        private void UnvanDoldur()
        {
            try
            {
                // ComboBox öğelerini temizle
                cmbUnvan.Items.Clear();

                // Ünvan listesini al
                List<Unvan> unvanListesi = unvanManager.GetAll();

                // Ünvan listesini ComboBox'a ekle
                cmbUnvan.Items.AddRange(unvanListesi.ToArray());

                // İlk öğeyi ekle ve seçili hale getir
                cmbUnvan.Items.Insert(0, "-Ünvan Seçiniz-");
                cmbUnvan.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Ünvan Listesi Getirilirken Hata Oluştu!");
                throw;
            }
        }

        private void FrmGorevli_Load(object sender, EventArgs e)
        {
            try
            {
                UnvanDoldur();
                Gorevliler();
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
                if (!string.IsNullOrEmpty(txtAdi.Text) && !string.IsNullOrEmpty(txtSoyadi.Text) && !string.IsNullOrEmpty(cmbUnvan.Text))
                {
                    // Yeni görevli bilgilerini oluştur
                    Gorevli yeniGorevli = new Gorevli
                    {
                        KoyId = _seciliKoyIndex,
                        DonemId = _seciliDonemIndex,
                        Adi = txtAdi.Text,
                        Soyadi = txtSoyadi.Text,
                        TelefonNo = mskTelefoNo.Text,
                        UnvanId = (cmbUnvan.SelectedItem as Unvan).Id
                    };

                    //// Aynı köy, aynı dönem ve aynı unvan kombinasyonunu kontrol et
                    //if (gorevliManager.GorevliKontrol(yeniGorevli.KoyId, yeniGorevli.DonemId, yeniGorevli.UnvanId))
                    //{
                    //    MessageBox.Show("Aynı köy, aynı dönem ve aynı unvan için zaten bir kayıt mevcut!");
                    //    return;
                    //}

                    // Yeni görevli ekle
                    gorevliManager.Add(yeniGorevli);
                    MessageBox.Show("Görevli Kaydı Yapıldı");
                    Gorevliler();
                    Temizle();
                }
                else
                {
                    MessageBox.Show("Lütfen Boş Alanları Doldurunuz!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Görevli Kaydı Yapılamadı: " + ex.Message);
            }
        }

        private void Temizle()
        {
            // Text alanlarını temizle
            txtAdi.Text = "";
            txtSoyadi.Text = "";
            mskTelefoNo.Text = "";
            cmbUnvan.SelectedIndex = -1;
        }

        private void Gorevliler()
        {
            try
            {
                var gorevliListesi = gorevliManager.GetGorevliDetails(_seciliKoyIndex, _seciliDonemIndex);
                if (gorevliListesi != null)
                    dgvGorevliler.DataSource = gorevliListesi;
                dgvGorevliler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvGorevliler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvGorevliler.EnableHeadersVisualStyles = false;
                dgvGorevliler.RowHeadersVisible = false;
                dgvGorevliler.ColumnHeadersDefaultCellStyle.Font = new Font("Impact", 14);
                dgvGorevliler.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
                dgvGorevliler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                dgvGorevliler.ColumnHeadersHeight = 40;
                dgvGorevliler.Columns["UnvanId"].Visible = false;
                dgvGorevliler.Columns["KoyId"].Visible = false;
                dgvGorevliler.Columns["KoyAdi"].Visible = false;
                dgvGorevliler.Columns["DonemAdi"].Visible = false;
                dgvGorevliler.Columns["DonemId"].Visible = false;
                dgvGorevliler.Columns["UnvanId"].Visible = false;
                dgvGorevliler.Columns["GorevliId"].Visible = false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void dgvGorevliler_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Satırın indeksini al
            int rowIndex = e.RowIndex;
            // Seçili satırın verilerini al
            if (rowIndex >= 0 && rowIndex < dgvGorevliler.Rows.Count)
            {
                DataGridViewRow selectedRow = dgvGorevliler.Rows[rowIndex];

                // Verileri ilgili alanlara aktar
                byte unvanId = (byte)selectedRow.Cells["UnvanId"].Value;
                string unvanAdi = selectedRow.Cells["UnvanAdi"].Value.ToString();

                // cmbUnvan'da uygun itemi seç
                for (int i = 0; i < cmbUnvan.Items.Count; i++)
                {
                    if (cmbUnvan.Items[i].ToString() == unvanAdi)
                    {
                        cmbUnvan.SelectedIndex = i;
                        break;
                    }
                }

                txtAdi.Text = selectedRow.Cells["Adi"].Value.ToString();
                txtSoyadi.Text = selectedRow.Cells["Soyadi"].Value.ToString();
                mskTelefoNo.Text = selectedRow.Cells["TelefonNo"].Value.ToString();

                // Seçili satırı işaretle
                dgvGorevliler.Rows[rowIndex].Selected = true;
            }
        }

        private void pcBoxGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                // Önceki seçili satırın indeksini sakla
                int previousRowIndex = dgvGorevliler.CurrentRow.Index;

                // Seçili satırın verilerini al
                GorevliDetailDto seciliGorevli = (GorevliDetailDto)dgvGorevliler.CurrentRow.DataBoundItem;
                // Güncellenecek verileri al
                int gorevliId = seciliGorevli.GorevliId;
                byte unvanId = (byte)cmbUnvan.SelectedIndex; // cmbGelirKategori'den seçilen öğenin Id'sini al
                string adi = txtAdi.Text;
                string soyadi = txtSoyadi.Text;
                string telefonNo = mskTelefoNo.Text;

                // Güncelleme işlemini yap
                Gorevli guncellenecekGorevli = new Gorevli
                {
                    Id = gorevliId,
                    Adi = adi,
                    Soyadi = soyadi,
                    TelefonNo = telefonNo,
                    KoyId = _seciliKoyIndex,
                    DonemId = _seciliDonemIndex,
                    UnvanId = unvanId,
                };

                // Güncelleme işlemini yapmak için GelirManager üzerinden Update metodunu çağır
                gorevliManager.Update(guncellenecekGorevli);

                // Başarılı bir şekilde güncelleme yapıldı mesajı göster
                MessageBox.Show("Görevli başarıyla güncellendi.");

                Temizle();

                // Yeniden yükleme işlemi (opsiyonel)
                Gorevliler();

                // Tüm satırların seçiliğini kaldır
                foreach (DataGridViewRow row in dgvGorevliler.Rows)
                {
                    row.Selected = false;
                }

                // Önceki seçili satırı tekrar seç
                dgvGorevliler.Rows[previousRowIndex].Selected = true;

                // DataGridView'in ilgili satırını görünür alan içine kaydır
                dgvGorevliler.FirstDisplayedScrollingRowIndex = previousRowIndex;
            }
            catch (Exception ex)
            {
                // Hata durumunda kullanıcıya bilgi ver
                MessageBox.Show("Görevli güncellenirken bir hata oluştu: " + ex.Message);
            }
        }

        private void pcBoxSil_Click(object sender, EventArgs e)
        {
            try
            {
                // Seçili satırı kontrol et
                if (dgvGorevliler.SelectedRows.Count > 0)
                {
                    // Kullanıcıya silme işlemini onaylamasını sor
                    var result = MessageBox.Show("Seçili satırı silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    // Eğer kullanıcı "Evet" derse
                    if (result == DialogResult.Yes)
                    {
                        // Seçili satırın bağlı olduğu veri nesnesini al
                        var selectedRow = dgvGorevliler.SelectedRows[0];
                        var gorevliDetailDto = (GorevliDetailDto)selectedRow.DataBoundItem;

                        // Silinecek Gelir nesnesini oluştur
                        var gorevli = new Gorevli
                        {
                            Id = gorevliDetailDto.GorevliId,
                            // Diğer özellikleri de buradan alabilirsiniz
                        };

                        // Silme işlemini gerçekleştir
                        gorevliManager.Delete(gorevli);

                        // Daha sonra DataGridView'i güncelleyebilirsiniz
                        Gorevliler();
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen silmek istediğiniz bir satır seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silme işlemi sırasında bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
