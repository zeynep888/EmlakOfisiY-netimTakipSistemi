using EmlakOfisi.BL;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace EmlakOfisi.UI
{
    public class FrmIlanlar : Form
    {
        TextBox txtId, txtGayrimenkulId, txtDanismanId, txtBaslik, txtIlanTipi, txtDurum;
        DataGridView dataGridView1;
        IlanBL bl = new IlanBL();

        public FrmIlanlar()
        {
            Text = "İlan İşlemleri";
            Width = 1100;
            Height = 650;
            StartPosition = FormStartPosition.CenterScreen;

            Label baslik = new Label();
            baslik.Text = "İlan İşlemleri";
            baslik.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            baslik.AutoSize = true;
            baslik.Location = new Point(25, 20);
            Controls.Add(baslik);

            int y = 75;
            txtId = Satir("İlan ID", y, true); y += 38;
            txtGayrimenkulId = Satir("Gayrimenkul ID", y); y += 38;
            txtDanismanId = Satir("Danışman ID", y); y += 38;
            txtBaslik = Satir("Başlık", y); y += 38;
            txtIlanTipi = Satir("İlan Tipi", y); y += 38;
            txtDurum = Satir("Durum", y); y += 50;

            Button btnEkle = Buton("Ekle", 35, y);
            Button btnGuncelle = Buton("Güncelle", 145, y);
            Button btnSil = Buton("Sil", 255, y);
            Button btnListele = Buton("Listele", 365, y);

            btnEkle.Click += BtnEkle_Click;
            btnGuncelle.Click += BtnGuncelle_Click;
            btnSil.Click += BtnSil_Click;
            btnListele.Click += (s, e) => Listele();

            dataGridView1 = new DataGridView();
            dataGridView1.Location = new Point(35, 390);
            dataGridView1.Width = 1000;
            dataGridView1.Height = 190;
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
            txt.Width = 270;
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
                    Convert.ToInt32(txtGayrimenkulId.Text),
                    Convert.ToInt32(txtDanismanId.Text),
                    txtBaslik.Text,
                    txtIlanTipi.Text
                );

                MessageBox.Show("İlan eklendi.");
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
                    Convert.ToInt32(txtDanismanId.Text),
                    txtBaslik.Text,
                    txtIlanTipi.Text,
                    txtDurum.Text
                );

                MessageBox.Show("İlan güncellendi.");
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
                MessageBox.Show("İlan silindi.");
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

            txtId.Text = row.Cells["ilan_id"].Value.ToString();
            txtBaslik.Text = row.Cells["baslik"].Value.ToString();
            txtIlanTipi.Text = row.Cells["ilan_tipi"].Value.ToString();
            txtDurum.Text = row.Cells["durum"].Value.ToString();
        }
    }
}
