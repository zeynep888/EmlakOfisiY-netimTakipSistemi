using EmlakOfisi.BL;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace EmlakOfisi.UI
{
    public class FrmGayrimenkuller : Form
    {
        TextBox txtId, txtSahipId, txtIl, txtIlce, txtAdres, txtEmlakTipi, txtOdaSayisi, txtMetrekare, txtFiyat, txtDurum;
        DataGridView dataGridView1;
        GayrimenkulBL bl = new GayrimenkulBL();

        public FrmGayrimenkuller()
        {
            Text = "Gayrimenkul İşlemleri";
            Width = 1150;
            Height = 700;
            StartPosition = FormStartPosition.CenterScreen;

            Label baslik = new Label();
            baslik.Text = "Gayrimenkul İşlemleri";
            baslik.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            baslik.AutoSize = true;
            baslik.Location = new Point(25, 20);
            Controls.Add(baslik);

            int y = 75;
            txtId = Satir("Gayrimenkul ID", y, true); y += 34;
            txtSahipId = Satir("Sahip ID", y); y += 34;
            txtIl = Satir("İl", y); y += 34;
            txtIlce = Satir("İlçe", y); y += 34;
            txtAdres = Satir("Adres", y); y += 34;
            txtEmlakTipi = Satir("Emlak Tipi", y); y += 34;
            txtOdaSayisi = Satir("Oda Sayısı", y); y += 34;
            txtMetrekare = Satir("Metrekare", y); y += 34;
            txtFiyat = Satir("Fiyat", y); y += 34;
            txtDurum = Satir("Durum", y); y += 45;

            Button btnEkle = Buton("Ekle", 35, y);
            Button btnGuncelle = Buton("Güncelle", 145, y);
            Button btnSil = Buton("Sil", 255, y);
            Button btnListele = Buton("Listele", 365, y);

            btnEkle.Click += BtnEkle_Click;
            btnGuncelle.Click += BtnGuncelle_Click;
            btnSil.Click += BtnSil_Click;
            btnListele.Click += (s, e) => Listele();

            dataGridView1 = new DataGridView();
            dataGridView1.Location = new Point(35, 500);
            dataGridView1.Width = 1050;
            dataGridView1.Height = 150;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.CellClick += DataGridView1_CellClick;
            Controls.Add(dataGridView1);
        }

        TextBox Satir(string label, int y, bool readOnly = false)
        {
            Label lbl = new Label();
            lbl.Text = label;
            lbl.Location = new Point(35, y + 4);
            lbl.Width = 120;
            Controls.Add(lbl);

            TextBox txt = new TextBox();
            txt.Location = new Point(170, y);
            txt.Width = 260;
            txt.ReadOnly = readOnly;
            Controls.Add(txt);

            return txt;
        }

        Button Buton(string text, int x, int y)
        {
            Button btn = new Button();
            btn.Text = text;
            btn.Location = new Point(x, y);
            btn.Width = 100;
            btn.Height = 35;
            Controls.Add(btn);
            return btn;
        }

        void Listele()
        {
            dataGridView1.DataSource = bl.Listele();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                bl.Ekle(
                    Convert.ToInt32(txtSahipId.Text),
                    txtIl.Text,
                    txtIlce.Text,
                    txtAdres.Text,
                    txtEmlakTipi.Text,
                    txtOdaSayisi.Text,
                    Convert.ToInt32(txtMetrekare.Text),
                    Convert.ToDecimal(txtFiyat.Text)
                );

                MessageBox.Show("Gayrimenkul eklendi.");
                Listele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtId.Text == "")
                {
                    MessageBox.Show("Tablodan kayıt seçin.");
                    return;
                }

                bl.Guncelle(
                    Convert.ToInt32(txtId.Text),
                    txtIl.Text,
                    txtIlce.Text,
                    txtAdres.Text,
                    txtEmlakTipi.Text,
                    txtOdaSayisi.Text,
                    Convert.ToInt32(txtMetrekare.Text),
                    Convert.ToDecimal(txtFiyat.Text),
                    txtDurum.Text
                );

                MessageBox.Show("Gayrimenkul güncellendi.");
                Listele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtId.Text == "")
                {
                    MessageBox.Show("Tablodan kayıt seçin.");
                    return;
                }

                bl.Sil(Convert.ToInt32(txtId.Text));
                MessageBox.Show("Gayrimenkul silindi.");
                Listele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            txtId.Text = row.Cells["gayrimenkul_id"].Value.ToString();
            txtIl.Text = row.Cells["il"].Value.ToString();
            txtIlce.Text = row.Cells["ilce"].Value.ToString();
            txtEmlakTipi.Text = row.Cells["emlak_tipi"].Value.ToString();
            txtOdaSayisi.Text = row.Cells["oda_sayisi"].Value.ToString();
            txtMetrekare.Text = row.Cells["metrekare"].Value.ToString();
            txtFiyat.Text = row.Cells["fiyat"].Value.ToString();
            txtDurum.Text = row.Cells["durum"].Value.ToString();
        }
    }
}