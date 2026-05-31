using EmlakOfisi.DAL;
using System.Data;

namespace EmlakOfisi.BL
{
    public class DanismanBL
    {
        DanismanDAL dal = new DanismanDAL();

        public void Ekle(string ad, string soyad, string telefon, string eposta, string uzmanlikAlani)
        {
            dal.Ekle(ad, soyad, telefon, eposta, uzmanlikAlani);
        }

        public void Guncelle(int danismanId, string ad, string soyad, string telefon, string eposta, string uzmanlikAlani)
        {
            dal.Guncelle(danismanId, ad, soyad, telefon, eposta, uzmanlikAlani);
        }

        public void Sil(int danismanId)
        {
            dal.Sil(danismanId);
        }

        public DataTable Listele()
        {
            return dal.Listele();
        }
    }
}