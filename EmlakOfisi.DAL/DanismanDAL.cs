using MySql.Data.MySqlClient;
using System.Data;

namespace EmlakOfisi.DAL
{
    public class DanismanDAL
    {
        DbBaglanti db = new DbBaglanti();

        public void Ekle(string ad, string soyad, string telefon, string eposta, string uzmanlikAlani)
        {
            using (MySqlConnection conn = db.BaglantiGetir())
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("sp_DanismanEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_ad", ad);
                cmd.Parameters.AddWithValue("p_soyad", soyad);
                cmd.Parameters.AddWithValue("p_telefon", telefon);
                cmd.Parameters.AddWithValue("p_eposta", eposta);
                cmd.Parameters.AddWithValue("p_uzmanlik_alani", uzmanlikAlani);

                cmd.ExecuteNonQuery();
            }
        }

        public void Guncelle(int danismanId, string ad, string soyad, string telefon, string eposta, string uzmanlikAlani)
        {
            using (MySqlConnection conn = db.BaglantiGetir())
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("sp_DanismanGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_danisman_id", danismanId);
                cmd.Parameters.AddWithValue("p_ad", ad);
                cmd.Parameters.AddWithValue("p_soyad", soyad);
                cmd.Parameters.AddWithValue("p_telefon", telefon);
                cmd.Parameters.AddWithValue("p_eposta", eposta);
                cmd.Parameters.AddWithValue("p_uzmanlik_alani", uzmanlikAlani);

                cmd.ExecuteNonQuery();
            }
        }

        public void Sil(int danismanId)
        {
            using (MySqlConnection conn = db.BaglantiGetir())
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("sp_DanismanSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_danisman_id", danismanId);

                cmd.ExecuteNonQuery();
            }
        }

        public DataTable Listele()
        {
            using (MySqlConnection conn = db.BaglantiGetir())
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("sp_DanismanListele", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }
    }
}
