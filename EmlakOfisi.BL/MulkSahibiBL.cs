using EmlakOfisi.DAL;
using System.Data;

namespace EmlakOfisi.BL
{
    public class MulkSahibiBL
    {
        MulkSahibiDAL dal = new MulkSahibiDAL();

        public void Ekle(string ad, string soyad, string tcNo, string telefon, string eposta, string adres)
        {
            dal.Ekle(ad, soyad, tcNo, telefon, eposta, adres);
        }

        public void Guncelle(int sahipId, string ad, string soyad, string telefon, string eposta, string adres)
        {
            dal.Guncelle(sahipId, ad, soyad, telefon, eposta, adres);
        }

        public void Sil(int sahipId)
        {
            dal.Sil(sahipId);
        }

        public DataTable Listele()
        {
            return dal.Listele();
        }
    }
}
