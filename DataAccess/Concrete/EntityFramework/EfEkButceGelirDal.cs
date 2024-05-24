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
        public List<EkButceGelirDetailDto> GetEkButceGelirDetails()
        {
            using (KoyButcesiContext context = new KoyButcesiContext())
            {
                var result = from ekButceGelir in context.EkButceGelirs

                             join gelirKategori in context.EkButceGelirs
                             on ekButceGelir.GelirKategoriId equals gelirKategori.Id

                             join koy in context.Koys
                             on ekButceGelir.KoyId equals koy.Id

                             join donem in context.Donems
                             on ekButceGelir.DonemId equals donem.Id
                             select new EkButceGelirDetailDto
                             {
                                 EkButceGelirId = ekButceGelir.Id,
                                 KoyAdi = ekButceGelir.KoyId,
                                 DonemAdi = ekButceGelir.DonemId,
                                 GelirKategoriAdi = ekButceGelir.GelirKategoriId,
                                 EkGelirTutari = ekButceGelir.EkGelirTutari,
                             };
                return result.ToList();
            }
        }
    }
}
