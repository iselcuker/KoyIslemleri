using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITahminiButceIdariIslerService
    {
        TahminiButceIdariIsler GetByTahminiButceIdariIslerId(int tahminiButceIdariIslerId);
        List<TahminiButceIdariIsler> GetListKoyId(int koyId);
        List<TahminiButceIdariIsler> GetListByKoyIdAndDonemId(int koyId, byte donemId);
        List<TahminiButceIdariIsler> GetListByKoyIdAndDonemIdAndIdariIslerKategoriId(int koyId, byte donemId, byte idariIslerKategoriId);
        List<TahminiButceIdariIsler> GetListByKoyIdAndDonemIdAndIdariIslerKategoriIdAndIdariIslerAltKategoriId(int koyId, byte donemId, byte idariIslerKategoriId, byte idariIslerAltKategoriId);
        void Add(TahminiButceIdariIsler tahminiButceİdariIsler);
        void Delete(TahminiButceIdariIsler tahminiButceİdariIsler);
        void Update(TahminiButceIdariIsler tahminiButceİdariIsler);
    }
}
