using MySql.Data.MySqlClient;
using System.Data;

namespace EmlakOfisi.DAL
{
    public class GayrimenkulDAL
    {
        DbBaglanti db = new DbBaglanti();

        public void Ekle(int sahipId, string il, string ilce, string adres, string emlakTipi, string odaSayisi, int metrekare, decimal fiyat)
        {
            using (MySqlConnection conn = db.BaglantiGetir())
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("sp_GayrimenkulEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_sahip_id", sahipId);
                cmd.Parameters.AddWithValue("p_il", il);
                cmd.Parameters.AddWithValue("p_ilce", ilce);
                cmd.Parameters.AddWithValue("p_adres", adres);
                cmd.Parameters.AddWithValue("p_emlak_tipi", emlakTipi);
                cmd.Parameters.AddWithValue("p_oda_sayisi", odaSayisi);
                cmd.Parameters.AddWithValue("p_metrekare", metrekare);
                cmd.Parameters.AddWithValue("p_fiyat", fiyat);

                cmd.ExecuteNonQuery();
            }
        }

        public void Guncelle(int gayrimenkulId, string il, string ilce, string adres, string emlakTipi, string odaSayisi, int metrekare, decimal fiyat, string durum)
        {
            using (MySqlConnection conn = db.BaglantiGetir())
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("sp_GayrimenkulGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_gayrimenkul_id", gayrimenkulId);
                cmd.Parameters.AddWithValue("p_il", il);
                cmd.Parameters.AddWithValue("p_ilce", ilce);
                cmd.Parameters.AddWithValue("p_adres", adres);
                cmd.Parameters.AddWithValue("p_emlak_tipi", emlakTipi);
                cmd.Parameters.AddWithValue("p_oda_sayisi", odaSayisi);
                cmd.Parameters.AddWithValue("p_metrekare", metrekare);
                cmd.Parameters.AddWithValue("p_fiyat", fiyat);
                cmd.Parameters.AddWithValue("p_durum", durum);

                cmd.ExecuteNonQuery();
            }
        }

        public void Sil(int gayrimenkulId)
        {
            using (MySqlConnection conn = db.BaglantiGetir())
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("sp_GayrimenkulSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_gayrimenkul_id", gayrimenkulId);

                cmd.ExecuteNonQuery();
            }
        }

        public DataTable Listele()
        {
            using (MySqlConnection conn = db.BaglantiGetir())
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("sp_GayrimenkulListele", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }
    }
}
