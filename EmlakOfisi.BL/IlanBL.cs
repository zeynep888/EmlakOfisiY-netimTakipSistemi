using EmlakOfisi.DAL;
using System.Data;

namespace EmlakOfisi.BL
{
    public class IlanBL
    {
        IlanDAL dal = new IlanDAL();

        public void Ekle(int gayrimenkulId, int danismanId, string baslik, string ilanTipi)
        {
            dal.Ekle(gayrimenkulId, danismanId, baslik, ilanTipi);
        }

        public void Guncelle(int ilanId, int danismanId, string baslik, string ilanTipi, string durum)
        {
            dal.Guncelle(ilanId, danismanId, baslik, ilanTipi, durum);
        }

        public void Sil(int ilanId)
        {
            dal.Sil(ilanId);
        }

        public DataTable Listele()
        {
            return dal.Listele();
        }
    }
}