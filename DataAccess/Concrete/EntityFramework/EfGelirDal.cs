using Core.DataAccess;
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
    public class EfGelirDal : EfEntityRepositoryBase<Gelir, KoyButcesiContext>, IGelirDal
    {
        public List<GelirDetailDto> GetGelirDetails()
        {
            using (KoyButcesiContext context = new KoyButcesiContext())
            {
                var result = from g in context.Gelirs //veri tabanındaki Gelirs ile

                             join gelirkategori in context.GelirKategoris //veri tabanındaki GelirKategoris
                             on g.GelirKategoriId equals gelirkategori.Id

                             join koy in context.Koys
                             on g.KoyId equals koy.Id

                             join donem in context.Donems
                             on g.DonemId equals donem.Id

                             select new GelirDetailDto
                             {
                                 GelirId = g.Id, //GelirDetailDto'daki Id'yi Gelirs'deki Id'den al
                                 KoyAdi = koy.KoyAdi, //GelirDetailDto'daki KoyAdi'ni Koys'deki KoyAdi'ndan al
                                 DonemAdi = donem.DonemAdi,
                                 Tutar = g.Tutar,
                                 Tarih = g.Tarih,
                                 EvrakNo = g.EvrakNo,
                                 Veren = g.Veren,
                             };
                return result.ToList();
            }
        }

        //public List<GelirDetailDto> GetListGelirDetailsKoyAndDonemId(int koyId, byte donemId)
        //{
        //    using (KoyButcesiContext context = new KoyButcesiContext())
        //    {
        //        var result = from g in context.Gelirs
        //                     join gelirkategori in context.GelirKategoris on g.GelirKategoriId equals gelirkategori.Id
        //                     join koy in context.Koys on g.KoyId equals koy.Id
        //                     join donem in context.Donems on g.DonemId equals donem.Id
        //                     where g.KoyId == koyId && g.DonemId == donemId
        //                     select new GelirDetailDto
        //                     {
        //                         GelirId = g.Id,
        //                         GelirKategoriAdi = gelirkategori.GelirKategoriAdi,
        //                         KoyAdi = koy.KoyAdi,
        //                         DonemAdi = donem.DonemAdi,
        //                         Tutar = g.Tutar,
        //                         Tarih = g.Tarih,
        //                         EvrakNo = g.EvrakNo,
        //                         Veren = g.Veren,
        //                         KoyId = koy.Id,
        //                         DonemId = donem.Id,
        //                         GelirKategoriId = g.GelirKategoriId
        //                     };
        //        return result.ToList();
        //    }
        //}

        public List<GelirDetailDto> GetListGelirDetailsKoyAndDonemId(int koyId, byte donemId)
        {
            using (var context = new KoyButcesiContext())
            {
                var result = from g in context.Gelirs
                             join gelirkategori in context.GelirKategoris on g.GelirKategoriId equals gelirkategori.Id
                             join koy in context.Koys on g.KoyId equals koy.Id
                             join donem in context.Donems on g.DonemId equals donem.Id
                             where g.KoyId == koyId && g.DonemId == donemId
                             select new GelirDetailDto
                             {
                                 GelirId = g.Id,
                                 GelirKategoriAdi = gelirkategori.GelirKategoriAdi,
                                 KoyAdi = koy.KoyAdi,
                                 DonemAdi = donem.DonemAdi,
                                 Tutar = g.Tutar,
                                 Tarih = g.Tarih,
                                 EvrakNo = g.EvrakNo,
                                 Veren = g.Veren,
                                 KoyId = koy.Id,
                                 DonemId = donem.Id,
                                 GelirKategoriId = g.GelirKategoriId
                             };
                return result.ToList();
            }
        }

    }
}
