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
    public class EfTahminiButceDal : EfEntityRepositoryBase<TahminiButce, KoyButcesiContext>, ITahminiButceDal
    {
        public List<TahminiButceDetailDto> GetTahminiButceDetails()
        {
            using (KoyButcesiContext context = new KoyButcesiContext())
            {
                var result = from tahminiButce in context.TahminiButces

                             join koy in context.Koys
                             on tahminiButce.KoyId equals koy.Id

                             join donem in context.Donems
                             on tahminiButce.DonemId equals donem.Id

                             select new TahminiButceDetailDto
                             {
                                 TahminiButceId = tahminiButce.Id,
                                 KoyAdi = koy.KoyAdi,
                                 DonemAdi = donem.DonemAdi,
                                 TahminiButceTutari = tahminiButce.TahminiButceTutari,
                             };
                return result.ToList();
            }
        }
    }
}
