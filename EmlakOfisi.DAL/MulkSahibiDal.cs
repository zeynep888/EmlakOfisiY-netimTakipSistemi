using MySql.Data.MySqlClient;
using System.Data;

namespace EmlakOfisi.DAL
{
    public class MulkSahibiDAL
    {
        DbBaglanti db = new DbBaglanti();

        public void Ekle(string ad, string soyad, string tcNo, string telefon, string eposta, string adres)
        {
            using (MySqlConnection conn = db.BaglantiGetir())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("sp_MulkSahibiEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_ad", ad);
                cmd.Parameters.AddWithValue("p_soyad", soyad);
                cmd.Parameters.AddWithValue("p_tc_no", tcNo);
                cmd.Parameters.AddWithValue("p_telefon", telefon);
                cmd.Parameters.AddWithValue("p_eposta", eposta);
                cmd.Parameters.AddWithValue("p_adres", adres);

                cmd.ExecuteNonQuery();
            }
        }

        public void Guncelle(int sahipId, string ad, string soyad, string telefon, string eposta, string adres)
        {
            using (MySqlConnection conn = db.BaglantiGetir())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("sp_MulkSahibiGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_sahip_id", sahipId);
                cmd.Parameters.AddWithValue("p_ad", ad);
                cmd.Parameters.AddWithValue("p_soyad", soyad);
                cmd.Parameters.AddWithValue("p_telefon", telefon);
                cmd.Parameters.AddWithValue("p_eposta", eposta);
                cmd.Parameters.AddWithValue("p_adres", adres);

                cmd.ExecuteNonQuery();
            }
        }

        public void Sil(int sahipId)
        {
            using (MySqlConnection conn = db.BaglantiGetir())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("sp_MulkSahibiSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_sahip_id", sahipId);
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable Listele()
        {
            using (MySqlConnection conn = db.BaglantiGetir())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("sp_MulkSahibiListele", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}