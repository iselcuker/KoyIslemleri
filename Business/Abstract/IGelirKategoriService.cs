using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IGelirKategoriService
    {
        GelirKategori GetById(int gelirKategoriId);
        List<GelirKategori> GetAll();
        //List<GelirKategori>GetGelirKategoriAdiById()
        void Add(GelirKategori gelirKategori);
        void Delete(GelirKategori gelirKategori);
        void Update(GelirKategori gelirKategori);
    }
}
