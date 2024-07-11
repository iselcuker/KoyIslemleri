using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IGiderService
    {
        Gider GetById(int giderId);
        List<Gider> GetListKoyId(int koyId);
        List<Gider> GetListKoyIdAndDonemId(int koyId, byte donemId);
        List<Gider> GetListDonemIdAndKoyIdAndGiderKategoriId(byte donemId, int koyId, byte giderKategoriId);
        List<Gider> GetListDonemIdAndKoyIdAndGiderKategoriIdAndGiderAltKategori(byte donemId, int koyId, byte giderKategoriId, byte giderAltKategoriId);
        void Add(Gider gider);
        void Delete(Gider gider);
        void Update(Gider gider);
        decimal GiderAltKategoriToplami(int koyId, byte donemId, byte giderAltKategoriId);

        List<GiderDetailDto> GetGiderDetails();
        List<GiderDetailDto> GetListGiderDetailsKoyAndDonemId(int koyId, byte donemId);

        List<Gider> GetListByAlan(int koyId, byte donemId, string alan); //ARAMA İŞLEMİ İÇİN
    }
}
