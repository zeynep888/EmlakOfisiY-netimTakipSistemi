using MySql.Data.MySqlClient;
using System.Data;

namespace EmlakOfisi.DAL
{
    public class IlanDAL
    {
        DbBaglanti db = new DbBaglanti();

        public void Ekle(int gayrimenkulId, int danismanId, string baslik, string ilanTipi)
        {
            using (MySqlConnection conn = db.BaglantiGetir())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("sp_IlanEkle", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_gayrimenkul_id", gayrimenkulId);
                cmd.Parameters.AddWithValue("p_danisman_id", danismanId);
                cmd.Parameters.AddWithValue("p_baslik", baslik);
                cmd.Parameters.AddWithValue("p_ilan_tipi", ilanTipi);

                cmd.ExecuteNonQuery();
            }
        }

        public void Guncelle(int ilanId, int danismanId, string baslik, string ilanTipi, string durum)
        {
            using (MySqlConnection conn = db.BaglantiGetir())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("sp_IlanGuncelle", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_ilan_id", ilanId);
                cmd.Parameters.AddWithValue("p_danisman_id", danismanId);
                cmd.Parameters.AddWithValue("p_baslik", baslik);
                cmd.Parameters.AddWithValue("p_ilan_tipi", ilanTipi);
                cmd.Parameters.AddWithValue("p_durum", durum);

                cmd.ExecuteNonQuery();
            }
        }

        public void Sil(int ilanId)
        {
            using (MySqlConnection conn = db.BaglantiGetir())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("sp_IlanSil", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_ilan_id", ilanId);
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable Listele()
        {
            using (MySqlConnection conn = db.BaglantiGetir())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("sp_IlanListele", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
