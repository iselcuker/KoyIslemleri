using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITahminiButceService
    {
        TahminiButce GetByTahminiButceId(int tahminiButceId);
        List<TahminiButce> GetListKoyId(int koyId);
        List<TahminiButce> GetListByKoyIdAndDonemId(int koyId, byte donemId);
        void Add(TahminiButce tahminiButce);
        void Delete(TahminiButce tahminiButce);
        void Update(TahminiButce tahminiButce);

        List<TahminiButceDetailDto> GetTahminiButceDetails();
    }
}
