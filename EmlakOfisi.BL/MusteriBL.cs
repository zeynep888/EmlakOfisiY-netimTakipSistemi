using EmlakOfisi.DAL;
using System.Data;

namespace EmlakOfisi.BL
{
    public class MusteriBL
    {
        MusteriDAL dal = new MusteriDAL();

        public void Ekle(string ad, string soyad, string telefon, string eposta, string arananTur, decimal butce)
        {
            dal.Ekle(ad, soyad, telefon, eposta, arananTur, butce);
        }

        public void Guncelle(int musteriId, string ad, string soyad, string telefon, string eposta, string arananTur, decimal butce)
        {
            dal.Guncelle(musteriId, ad, soyad, telefon, eposta, arananTur, butce);
        }

        public void Sil(int musteriId)
        {
            dal.Sil(musteriId);
        }

        public DataTable Listele()
        {
            return dal.Listele();
        }
    }
}
