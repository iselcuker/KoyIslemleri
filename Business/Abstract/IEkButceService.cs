using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IEkButceService
    {
        EkButce GetById(int ekButceId);
        List<EkButce>GetListKoyId(int koyId);
        List<EkButce> GetAllByKoyIdAndDonemId(int koyId, byte donemId);
        void Add(EkButce ekButce);
        void Delete(EkButce ekButce);
        void Update(EkButce ekButce);
    }
}
