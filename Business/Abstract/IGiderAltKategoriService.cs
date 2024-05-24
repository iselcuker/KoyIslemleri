using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IGiderAltKategoriService
    {
        GiderAltKategori GetById(byte giderAltKategoriId);
        List<GiderAltKategori> GetAll();
        List<GiderAltKategori>GetByGiderKategoriId(byte giderKategoriId);
        void Add(GiderAltKategori giderAltKategori);
        void Delete(GiderAltKategori giderAltKategori);
        void Update(GiderAltKategori giderAltKategori);
    }
}
