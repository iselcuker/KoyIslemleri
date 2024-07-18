using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfTahminiButceGelirDal : EfEntityRepositoryBase<TahminiButceGelir, KoyButcesiContext>, ITahminiButceGelirDal
    {
        public List<TahminiButceGelirDetailDto> GetTahminiButceGelirDetails(int koyId, byte donemId)
        {
            using (KoyButcesiContext context = new KoyButcesiContext())
            {
                var result = from tahminiButceGelir in context.TahminiButceGelirs
                             join gelirkategori in context.GelirKategoris
                             on tahminiButceGelir.GelirKategoriId equals gelirkategori.Id
                             join koy in context.Koys
                             on tahminiButceGelir.KoyId equals koy.Id

                             join donem in context.Donems
                             on tahminiButceGelir.DonemId equals donem.Id

                             join degisiklik in context.Degisikliks
                             on tahminiButceGelir.DegisiklikId equals degisiklik.Id into degisiklikGroup
                             from degisiklik in degisiklikGroup.DefaultIfEmpty()
                             where tahminiButceGelir.KoyId == koyId && tahminiButceGelir.DonemId == donemId
                             select new TahminiButceGelirDetailDto
                             {
                                 TahminiButceGelirId = tahminiButceGelir.Id,
                                 GelirKategoriAdi = gelirkategori.GelirKategoriAdi,
                                 GelirKategoriId = tahminiButceGelir.GelirKategoriId,
                                 KoyAdi = koy.KoyAdi,
                                 KoyId = koy.Id,
                                 DonemAdi = donem.DonemAdi,
                                 DonemId = donem.Id,
                                 TahminiGelirTutari = tahminiButceGelir.TahminiGelirTutari,
                                 DegisiklikAdi = degisiklik != null ? degisiklik.DegisiklikAdi : "",
                                 DegisiklikId = tahminiButceGelir.DegisiklikId,
                             };
                return result.ToList();
            }
        }
    }
}
