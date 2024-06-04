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
    public class EfEkButceGiderDal : EfEntityRepositoryBase<EkButceGider, KoyButcesiContext>, IEkButceGiderDal
    {
        public List<EkButceGiderDetailDto> GetEkButceGiderDetails(int koyId, byte donemId)
        {
            using (KoyButcesiContext context = new KoyButcesiContext())
            {
                var result = from ekButceGider in context.EkButceGiders

                             join giderkategori in context.GiderKategoris
                             on ekButceGider.GiderKategoriId equals giderkategori.Id

                             join giderAltKategori in context.GiderAltKategoris
                             on ekButceGider.GiderAltKategoriId equals giderAltKategori.Id

                             join koy in context.Koys
                             on ekButceGider.KoyId equals koy.Id

                             join donem in context.Donems
                             on ekButceGider.DonemId equals donem.Id

                             join degisiklik in context.Degisikliks
                             on ekButceGider.DegisiklikId equals degisiklik.Id into degisiklikGroup

                             from degisiklik in degisiklikGroup.DefaultIfEmpty()
                             where ekButceGider.KoyId == koyId && ekButceGider.DonemId == donemId
                             select new EkButceGiderDetailDto
                             {
                                 EkButceGiderId = ekButceGider.Id,
                                 GiderKategoriAdi = giderkategori.GiderKategoriAdi,
                                 GiderKategoriId = ekButceGider.GiderKategoriId,
                                 GiderAltKategoriAdi = giderAltKategori.GiderAltKategoriAdi,
                                 GiderAltKategoriId = ekButceGider.GiderAltKategoriId,
                                 KoyAdi = koy.KoyAdi,
                                 KoyId = koy.Id,
                                 DonemAdi = donem.DonemAdi,
                                 DonemId = donem.Id,
                                 DegisiklikAdi = degisiklik != null ? degisiklik.DegisiklikAdi : "",
                                 DegisiklikId = ekButceGider.DegisiklikId,
                                 EkGiderTutari = ekButceGider.EkGiderTutari,
                             };
                return result.ToList();
            }
        }
    }
}
