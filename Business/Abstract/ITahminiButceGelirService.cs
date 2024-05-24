using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITahminiButceGelirService
    {
        TahminiButceGelir TahminiButceGelirGetById(int tahminiButceGelirId);
        List<TahminiButceGelir> GetListKoyId(int koyId);
        List<TahminiButceGelir> GetListByKoyIdAndDonemId(int koyId, byte donemId);
        List<TahminiButceGelir> GetListByKoyIdAndDonemIdAndGelirKategoriId(int koyId, byte donemId, byte gelirKategoriId);
        void Add(TahminiButceGelir tahminiButceGelir);
        void Delete(TahminiButceGelir tahminiButceGelir);
        void Update(TahminiButceGelir tahminiButceGelir);

        List<TahminiButceGelirDetailDto> GetTahminiButceGelirDetails(int koyId, byte donemId);
    }
}
