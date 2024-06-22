using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IGelirService
    {
        Gelir GetById(int gelirId);
        List<Gelir> GetListKoyId(int koyId);
        List<Gelir> GetListKoyIdAndDonemId(int koyId, byte donemId);
        List<Gelir> GetListDonemIdAndKoyIdAndGelirKategoriId(byte donemId, int koyId, byte gelirKategoriId);//bir köyün bir dönemine ait bir Gelir Kategorisindeki bütün gelirleri listeleyecek
        
        void Add(Gelir gelir);
        void Delete(Gelir gelir);
        void Update(Gelir gelir);

        decimal GelirKategoriToplam(int koyId, byte donemId, byte gelirKategoriId);
       


        //Gelir GetToplamByKoyIdAndDonemIdAndGelirKategoriId(int koyId, byte donemId,byte gelirKategoriId);

        List<GelirDetailDto> GetGelirDetails();
        List<GelirDetailDto> GetListGelirDetailsKoyAndDonemId(int koyId, byte donemId);

    }
}
