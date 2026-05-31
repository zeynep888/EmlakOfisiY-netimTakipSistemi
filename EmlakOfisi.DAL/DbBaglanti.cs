using MySql.Data.MySqlClient;

namespace EmlakOfisi.DAL
{
    public class DbBaglanti
    {
        private readonly string connectionString =
            "Server=localhost;Database=emlak_ofisi_takip;Uid=root;Pwd=250405;SslMode=None;";

        public MySqlConnection BaglantiGetir()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
