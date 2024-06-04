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
    public class EfTahminiButceGiderDal : EfEntityRepositoryBase<TahminiButceGider, KoyButcesiContext>, ITahminiButceGiderDal
    {
        public List<TahminiButceGiderDetailDto> GetTahminiButceGiderDetails(int koyId, byte donemId)
        {
            using (KoyButcesiContext context = new KoyButcesiContext())
            {
                var result = from tahminiButceGider in context.TahminiButceGiders

                             join giderkategori in context.GiderKategoris
                             on tahminiButceGider.GiderKategoriId equals giderkategori.Id

                             join giderAltKategori in context.GiderAltKategoris
                             on tahminiButceGider.GiderAltKategoriId equals giderAltKategori.Id

                             join koy in context.Koys
                             on tahminiButceGider.KoyId equals koy.Id

                             join donem in context.Donems
                             on tahminiButceGider.DonemId equals donem.Id

                             join degisiklik in context.Degisikliks
                             on tahminiButceGider.DegisiklikId equals degisiklik.Id into degisiklikGroup

                             from degisiklik in degisiklikGroup.DefaultIfEmpty()
                             where tahminiButceGider.KoyId == koyId && tahminiButceGider.DonemId == donemId
                             select new TahminiButceGiderDetailDto
                             {
                                 TahminiButceGiderId = tahminiButceGider.Id,
                                 GiderKategoriAdi = giderkategori.GiderKategoriAdi,
                                 GiderKategoriId = tahminiButceGider.GiderKategoriId,
                                 GiderAltKategoriAdi = giderAltKategori.GiderAltKategoriAdi,
                                 GiderAltKategoriId = tahminiButceGider.GiderAltKategoriId,
                                 KoyAdi = koy.KoyAdi,
                                 KoyId = koy.Id,
                                 DonemAdi = donem.DonemAdi,
                                 DonemId = donem.Id,
                                 DegisiklikAdi = degisiklik != null ? degisiklik.DegisiklikAdi : "",
                                 DegisiklikId = tahminiButceGider.DegisiklikId,
                                 Tutar = tahminiButceGider.Tutar,
                             };
                return result.ToList();
            }
        }
    }
}
