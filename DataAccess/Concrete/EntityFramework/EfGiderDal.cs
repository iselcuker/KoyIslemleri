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
    public class EfGiderDal : EfEntityRepositoryBase<Gider, KoyButcesiContext>, IGiderDal
    {
        public List<GiderDetailDto> GetGiderDetails()
        {
            using (KoyButcesiContext context = new KoyButcesiContext())
            {
                var result = from gider in context.Giders

                             join koy in context.Koys
                             on gider.KoyId equals koy.Id

                             join donem in context.Donems
                             on gider.DonemId equals donem.Id

                             join giderKategori in context.GiderKategoris
                             on gider.GiderKategoriId equals giderKategori.Id

                             join giderAltKategori in context.GiderAltKategoris
                             on gider.GiderAltKategoriId equals giderAltKategori.Id

                             select new GiderDetailDto
                             {
                                 GiderId = gider.Id,
                                 GiderKategoriAdi = giderKategori.GiderKategoriAdi,
                                 GiderAltKategoriAdi = giderAltKategori.GiderAltKategoriAdi,
                                 Tutar = gider.Tutar,
                                 Tarih = gider.Tarih,
                                 EvrakNo = gider.EvrakNo,
                                 Alan = gider.Alan,
                             };
                return result.ToList();
            }
        }

        public List<GiderDetailDto> GetListGiderDetailsKoyAndDonemId(int koyId, byte donemId)
        {
            using (KoyButcesiContext context = new KoyButcesiContext())
            {
                var result = from gider in context.Giders
                             join giderKategori in context.GiderKategoris on gider.GiderKategoriId equals giderKategori.Id
                             join giderAltKategori in context.GiderAltKategoris on gider.GiderAltKategoriId equals giderAltKategori.Id
                             join koy in context.Koys on gider.KoyId equals koy.Id
                             join donem in context.Donems on gider.DonemId equals donem.Id
                             where gider.KoyId == koyId && gider.DonemId == donemId
                             select new GiderDetailDto
                             {
                                 GiderId = gider.Id,
                                 GiderKategoriAdi = giderKategori.GiderKategoriAdi,
                                 GiderAltKategoriAdi = giderAltKategori.GiderAltKategoriAdi,
                                 KoyAdi = koy.KoyAdi,
                                 DonemAdi = donem.DonemAdi,
                                 Tutar = gider.Tutar,
                                 Tarih = gider.Tarih,
                                 EvrakNo = gider.EvrakNo,
                                 Alan = gider.Alan,
                                 KoyId = koy.Id,
                                 DonemId = donem.Id,
                                 GiderKategoriId = gider.GiderKategoriId,
                                 GiderAltKategoriId = gider.GiderAltKategoriId,
                             };
                return result.ToList();
            }
        }
    }
}
