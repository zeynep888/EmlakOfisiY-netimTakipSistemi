using MySql.Data.MySqlClient;
using System.Data;

namespace EmlakOfisi.DAL
{
    public class MusteriDAL
    {
        DbBaglanti db = new DbBaglanti();

        public void Ekle(string ad, string soyad, string telefon, string eposta, string arananTur, decimal butce)
        {
            using (MySqlConnection conn = db.BaglantiGetir())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("sp_MusteriEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_ad", ad);
                cmd.Parameters.AddWithValue("p_soyad", soyad);
                cmd.Parameters.AddWithValue("p_telefon", telefon);
                cmd.Parameters.AddWithValue("p_eposta", eposta);
                cmd.Parameters.AddWithValue("p_aranan_tur", arananTur);
                cmd.Parameters.AddWithValue("p_butce", butce);
                cmd.ExecuteNonQuery();
            }
        }

        public void Guncelle(int musteriId, string ad, string soyad, string telefon, string eposta, string arananTur, decimal butce)
        {
            using (MySqlConnection conn = db.BaglantiGetir())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("sp_MusteriGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_musteri_id", musteriId);
                cmd.Parameters.AddWithValue("p_ad", ad);
                cmd.Parameters.AddWithValue("p_soyad", soyad);
                cmd.Parameters.AddWithValue("p_telefon", telefon);
                cmd.Parameters.AddWithValue("p_eposta", eposta);
                cmd.Parameters.AddWithValue("p_aranan_tur", arananTur);
                cmd.Parameters.AddWithValue("p_butce", butce);
                cmd.ExecuteNonQuery();
            }
        }

        public void Sil(int musteriId)
        {
            using (MySqlConnection conn = db.BaglantiGetir())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("sp_MusteriSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_musteri_id", musteriId);
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable Listele()
        {
            using (MySqlConnection conn = db.BaglantiGetir())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("sp_MusteriListele", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
