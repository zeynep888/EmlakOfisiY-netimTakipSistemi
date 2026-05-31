using System;
using System.Drawing;
using System.Windows.Forms;

namespace EmlakOfisi.UI
{
    public class FrmAnaMenu : Form
    {
        public FrmAnaMenu()
        {
            Text = "Emlak Ofisi Yönetim ve Takip Sistemi";
            Width = 900;
            Height = 580;
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.White;

            Label baslik = new Label();
            baslik.Text = "EMLAK OFİSİ YÖNETİM VE TAKİP SİSTEMİ";
            baslik.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            baslik.AutoSize = true;
            baslik.Location = new Point(170, 35);
            Controls.Add(baslik);

            string[] butonlar = { "Müşteri İşlemleri", "Mülk Sahibi İşlemleri", "Danışman İşlemleri", "Gayrimenkul İşlemleri", "İlan İşlemleri", "Randevu İşlemleri", "Sözleşme İşlemleri", "Ödeme İşlemleri" };
            for (int i = 0; i < butonlar.Length; i++)
            {
                Button btn = new Button();
                btn.Text = butonlar[i];
                btn.Width = 250;
                btn.Height = 55;
                btn.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                btn.Location = new Point(170 + (i % 2) * 300, 110 + (i / 2) * 75);
                btn.Click += MenuButon_Click;
                Controls.Add(btn);
            }
        }
        private void MenuButon_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn.Text == "Müşteri İşlemleri")
            {
                new FrmMusteriler().ShowDialog();
            }
            else if (btn.Text == "Mülk Sahibi İşlemleri")
            {
                new FrmMulkSahipleri().ShowDialog();
            }
            else if (btn.Text == "Danışman İşlemleri")
            {
                new FrmDanismanlar().ShowDialog();
            }
            else if (btn.Text == "Gayrimenkul İşlemleri")
            {
                new FrmGayrimenkuller().ShowDialog();
            }
            else if (btn.Text == "İlan İşlemleri")
            {
                new FrmIlanlar().ShowDialog();
            }
            else if (btn.Text == "Randevu İşlemleri")
            {
                new FrmRandevular().ShowDialog();
            }
            else if (btn.Text == "Sözleşme İşlemleri")
            {
                new FrmSozlesmeler().ShowDialog();
            }
            else if (btn.Text == "Ödeme İşlemleri")
            {
                new FrmOdemeler().ShowDialog();
            }
            else
            {
                new FrmGenelEkran(btn.Text).ShowDialog();
            }
        }
    }
}



