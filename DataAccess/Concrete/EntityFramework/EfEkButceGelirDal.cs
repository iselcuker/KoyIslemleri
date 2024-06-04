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
    public class EfEkButceGelirDal : EfEntityRepositoryBase<EkButceGelir, KoyButcesiContext>, IEkButceGelirDal
    {
        public List<EkButceGelirDetailDto> GetEkButceGelirDetails(int koyId, byte donemId)
        {
            using (KoyButcesiContext context = new KoyButcesiContext())
            {
                var result = from ekButceGelir in context.EkButceGelirs
                             join gelirkategori in context.GelirKategoris
                             on ekButceGelir.GelirKategoriId equals gelirkategori.Id
                             join koy in context.Koys
                             on ekButceGelir.KoyId equals koy.Id

                             join donem in context.Donems
                             on ekButceGelir.DonemId equals donem.Id

                             join degisiklik in context.Degisikliks
                             on ekButceGelir.DegisiklikId equals degisiklik.Id into degisiklikGroup
                             from degisiklik in degisiklikGroup.DefaultIfEmpty()
                             where ekButceGelir.KoyId == koyId && ekButceGelir.DonemId == donemId
                             select new EkButceGelirDetailDto
                             {
                                 EkButceGelirId = ekButceGelir.Id,
                                 GelirKategoriAdi = gelirkategori.GelirKategoriAdi,
                                 GelirKategoriId = ekButceGelir.GelirKategoriId,
                                 KoyAdi = koy.KoyAdi,
                                 KoyId = koy.Id,
                                 DonemAdi = donem.DonemAdi,
                                 DonemId = donem.Id,
                                 DegisiklikAdi = degisiklik != null ? degisiklik.DegisiklikAdi : "",
                                 DegisiklikId = ekButceGelir.DegisiklikId,
                                 EkGelirTutari = ekButceGelir.EkGelirTutari,
                             };
                return result.ToList();
            }
        }
    }
}
