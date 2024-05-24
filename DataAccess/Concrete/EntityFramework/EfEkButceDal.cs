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
    public class EfEkButceDal : EfEntityRepositoryBase<EkButce, KoyButcesiContext>, IEkButceDal
    {
        public List<EkButceDetailDto> GetEkButceDetails()
        {
            using (KoyButcesiContext context = new KoyButcesiContext())
            {
                var result = from ekButce in context.EkButces

                             join koy in context.Koys
                             on ekButce.KoyId equals koy.Id

                             join donem in context.Donems
                             on ekButce.DonemId equals donem.Id

                             select new EkButceDetailDto
                             {
                                 EkButceId = ekButce.Id,
                                 KoyAdi = koy.KoyAdi,
                                 DonemAdi = donem.DonemAdi,
                                 EkButceTutari = ekButce.EkButceTutari,
                             };
                return result.ToList();
            }
        }
    }
}
