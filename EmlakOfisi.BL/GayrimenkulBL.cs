using EmlakOfisi.DAL;
using System.Data;

namespace EmlakOfisi.BL
{
    public class GayrimenkulBL
    {
        GayrimenkulDAL dal = new GayrimenkulDAL();

        public void Ekle(int sahipId, string il, string ilce, string adres,
                         string emlakTipi, string odaSayisi,
                         int metrekare, decimal fiyat)
        {
            dal.Ekle(sahipId, il, ilce, adres,
                     emlakTipi, odaSayisi,
                     metrekare, fiyat);
        }

        public void Guncelle(int gayrimenkulId,
                             string il,
                             string ilce,
                             string adres,
                             string emlakTipi,
                             string odaSayisi,
                             int metrekare,
                             decimal fiyat,
                             string durum)
        {
            dal.Guncelle(gayrimenkulId,
                         il,
                         ilce,
                         adres,
                         emlakTipi,
                         odaSayisi,
                         metrekare,
                         fiyat,
                         durum);
        }

        public void Sil(int gayrimenkulId)
        {
            dal.Sil(gayrimenkulId);
        }

        public DataTable Listele()
        {
            return dal.Listele();
        }
    }
}