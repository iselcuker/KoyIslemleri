using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IEkButceGelirService
    {
        EkButceGelir GetById(int ekbutceGelirId);
        List<EkButceGelir> GetAllByKoyIdAndDonemId(int koyId, byte donemId);
        List<EkButceGelir> GetAllByKoyIdAndDonemIdAndGelirKategoriId(int koyId, byte donemId);
        void Add(EkButceGelir ekButceGelir);
        void Delete(EkButceGelir ekButceGelir);
        void Update(EkButceGelir ekButceGelir);

        List<EkButceGelirDetailDto> GetEkButceGelirDetails();
    }
}
