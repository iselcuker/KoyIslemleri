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
        public List<TahminiButceGiderDetailDto> GetTahminiButceGiderDetails()
        {
            using (KoyButcesiContext context = new KoyButcesiContext())
            {
                var result = from tahminiButceGider in context.TahminiButceGiders

                             join koy in context.Koys
                             on tahminiButceGider.KoyId equals koy.Id

                             join donem in context.Donems
                             on tahminiButceGider.DonemId equals donem.Id

                             join giderKategori in context.GiderKategoris
                             on tahminiButceGider.GiderKategoriId equals giderKategori.Id

                             join giderAltKategori in context.GiderAltKategoris
                             on tahminiButceGider.GiderAltKategoriId equals giderAltKategori.Id

                             join degisiklik in context.Degisikliks
                             on tahminiButceGider.DegisiklikId equals degisiklik.Id

                             select new TahminiButceGiderDetailDto
                             {
                                 TahminiButceGiderId = tahminiButceGider.Id,
                                 KoyAdi = koy.KoyAdi,
                                 DonemAdi = donem.DonemAdi,
                                 GiderKategoriAdi = giderKategori.GiderKategoriAdi,
                                 GiderAltKategoriAdi = giderAltKategori.GiderAltKategoriAdi,
                                 DegisiklikAdi = degisiklik.DegisiklikAdi,
                                 Tutar = tahminiButceGider.Tutar,
                             };
                return result.ToList();
            }
        }
    }
}
