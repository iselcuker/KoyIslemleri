using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfGorevliDal : EfEntityRepositoryBase<Gorevli, KoyButcesiContext>, IGorevliDal
    {
        public List<GorevliDetailDto> GetGorevliDetails(int koyId, byte donemId)
        {
            using (KoyButcesiContext context = new KoyButcesiContext())
            {
                var result = from gorevli in context.Gorevlis
                             join koy in context.Koys on gorevli.KoyId equals koy.Id
                             join donem in context.Donems on gorevli.DonemId equals donem.Id
                             join unvan in context.Unvans on gorevli.UnvanId equals unvan.Id
                             where gorevli.KoyId == koyId && gorevli.DonemId == donemId
                             select new GorevliDetailDto
                             {
                                 GorevliId = gorevli.Id,
                                 KoyId = koy.Id,
                                 KoyAdi = koy.KoyAdi,
                                 DonemId = donem.Id,
                                 DonemAdi = donem.DonemAdi,
                                 Adi = gorevli.Adi,
                                 Soyadi = gorevli.Soyadi,
                                 TelefonNo = gorevli.TelefonNo,
                                 UnvanId = unvan.Id,
                                 UnvanAdi = unvan.UnvanAdi,
                             };
                return result.ToList();
            }
        }
    }
}
