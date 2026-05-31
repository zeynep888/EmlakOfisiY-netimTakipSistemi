using System.Drawing;
using System.Windows.Forms;

namespace EmlakOfisi.UI
{
    public class FrmGenelEkran : Form
    {
        public FrmGenelEkran(string ekranAdi)
        {
            Text = ekranAdi;
            Width = 1050;
            Height = 620;
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.White;

            Label baslik = new Label();
            baslik.Text = ekranAdi;
            baslik.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            baslik.AutoSize = true;
            baslik.Location = new Point(25, 20);
            Controls.Add(baslik);

            string[] alanlar = { "ID", "Ad / Başlık", "Telefon / Tür", "Tarih / Durum", "Açıklama" };
            int y = 75;
            foreach (string alan in alanlar)
            {
                Label lbl = new Label();
                lbl.Text = alan;
                lbl.Location = new Point(35, y + 4);
                lbl.Width = 110;
                Controls.Add(lbl);
                TextBox txt = new TextBox();
                txt.Location = new Point(160, y);
                txt.Width = 260;
                Controls.Add(txt);
                y += 38;
            }

            string[] butonlar = { "Ekle", "Güncelle", "Sil", "Listele" };
            for (int i = 0; i < butonlar.Length; i++)
            {
                Button btn = new Button();
                btn.Text = butonlar[i];
                btn.Location = new Point(35 + i * 110, y + 15);
                btn.Width = 100;
                btn.Height = 35;
                Controls.Add(btn);
            }

            DataGridView grid = new DataGridView();
            grid.Location = new Point(35, 350);
            grid.Width = 950;
            grid.Height = 190;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.Columns.Add("col1", "ID");
            grid.Columns.Add("col2", "Ad / Başlık");
            grid.Columns.Add("col3", "Tür");
            grid.Columns.Add("col4", "Durum");
            grid.Columns.Add("col5", "Açıklama");
            Controls.Add(grid);

            Label not = new Label();
            not.Text = "Bu ekran rapora ekran görüntüsü eklemek için hazırlanmış örnek arayüzdür.";
            not.Location = new Point(35, 555);
            not.AutoSize = true;
            Controls.Add(not);
        }
    }
}
