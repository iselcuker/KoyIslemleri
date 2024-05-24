using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IEkButceGiderService
    {
        EkButceGider GetById(int ekButceGiderId);
        List<EkButceGider> GetAllByKoyIdAndDonemId(int koyId, byte donemId);
        List<EkButceGider> GetAllByKoyIdAndDonemIdAndGiderKategoriId(int koyId, byte donemId, byte giderKategoriId);
        List<EkButceGider> GetAllByKoyIdAndDonemIdAndGiderKategoriIdAndGiderAltKategoriId(int koyId, byte donemId, byte giderKategoriId, byte giderAltKategoriId);
        void Add(EkButceGider ekButceGider);
        void Delete(EkButceGider ekButceGider);
        void Update(EkButceGider ekButceGider);

        List<EkButceGiderDetailDto> GetEkButceGiderDetails();
    }
}
