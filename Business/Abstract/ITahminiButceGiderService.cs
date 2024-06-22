using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITahminiButceGiderService
    {
        TahminiButceGider GetByTahminiButceGiderId(int tahminiButceGiderId);
        List<TahminiButceGider> GetListKoyId(int koyId);
        List<TahminiButceGider> GetListByKoyIdAndDonemId(int koyId, byte donemId);
        List<TahminiButceGider> GetListByKoyIdAndDonemIdAndGiderKategoriId(int koyId, byte donemId, byte giderKategoriId);
        List<TahminiButceGider> GetListByKoyIdAndDonemIdAndGiderAltKategoriId(int koyId, byte donemId, byte giderAltKategoriId);
        List<TahminiButceGider> GetListByKoyIdAndDonemIdAndGiderKategoriIdAndGiderAltKategoriId(int koyId, byte donemId, byte giderKategoriId, byte giderAltKategoriId);
        void Add(TahminiButceGider tahminiButceGider);
        void Delete(TahminiButceGider tahminiButceGider);
        void Update(TahminiButceGider tahminiButceGider);

        List<TahminiButceGiderDetailDto> GetTahminiButceGiderDetails(int koyId, byte donemId);
    }
}
