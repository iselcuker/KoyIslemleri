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
    public class EfTahminiButceIdariIslerDal : EfEntityRepositoryBase<TahminiButceIdariIsler, KoyButcesiContext>, ITahminiButceIdariIslerDal
    {
        public List<TahminiButceIdariIslerDetailDto> GetTahminiButceIdariIslerDetails(int koyId, byte donemId)
        {
            using (KoyButcesiContext context = new KoyButcesiContext())
            {
                var result = from tahminiButceIdariIsler in context.TahminiButceIdariIslers

                             join koy in context.Koys
                             on tahminiButceIdariIsler.KoyId equals koy.Id

                             join donem in context.Donems
                             on tahminiButceIdariIsler.DonemId equals donem.Id

                             join idariIslerKategori in context.IdariIslerKategoris
                             on tahminiButceIdariIsler.IdariIslerKategoriId equals idariIslerKategori.Id

                             join idariIslerAltKategori in context.IdariIslerAltKategoris
                             on tahminiButceIdariIsler.IdariIslerAltKategoriId equals idariIslerAltKategori.Id

                             select new TahminiButceIdariIslerDetailDto
                             {
                                 TahminiButceIdariIslerId = tahminiButceIdariIsler.Id,
                                 KoyAdi = koy.KoyAdi,
                                 KoyId=koy.Id,
                                 DonemAdi = donem.DonemAdi,
                                 DonemId=donem.Id,
                                 IdariIslerKategoriAdi = idariIslerKategori.IdariIslerKategoriAdi,
                                 IdariIslerKategoriId=idariIslerKategori.Id,
                                 IdariIslerAltKategoriAdi = idariIslerAltKategori.IdariIslerAltKategoriAdi,
                                 IdariIslerAltKategoriId=idariIslerAltKategori.Id,
                                 TahminiIdariIslarTutari = tahminiButceIdariIsler.TahminiIdariIslarTutari,

                             };
                return result.ToList();
            }
        }
    }
}
