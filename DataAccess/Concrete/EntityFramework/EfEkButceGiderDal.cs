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
        public List<EkButceGiderDetailDto> GetEkButceGiderDetails()
        {
            using (KoyButcesiContext context = new KoyButcesiContext())
            {
                var result = from ekButceGider in context.EkButceGiders

                             join koy in context.Koys
                             on ekButceGider.KoyId equals koy.Id

                             join donem in context.Donems
                             on ekButceGider.DonemId equals donem.Id

                             join giderKategori in context.GelirKategoris
                             on ekButceGider.GiderKategoriId equals giderKategori.Id

                             join giderAltKategori in context.GiderAltKategoris
                             on ekButceGider.GiderAltKategoriId equals giderAltKategori.Id

                             select new EkButceGiderDetailDto
                             {
                                 EkButceGiderId = ekButceGider.Id,
                                 KoyAdi = koy.KoyAdi,
                                 DonemAdi = donem.DonemAdi,
                                 GiderKategoriAdi = giderKategori.GelirKategoriAdi,
                                 GiderAltKategoriAdi = giderAltKategori.GiderAltKategoriAdi,
                                 EkGiderTutari = ekButceGider.EkGiderTutari,
                             };
                return result.ToList();
            }
        }
    }
}
