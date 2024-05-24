using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IGiderKategoriService
    {
        List<GiderKategori> GetAll();
        GiderKategori GetById(int giderKategoriId);
        void Add(GiderKategori giderKategori);
        void Delete(GiderKategori giderKategori);
        void Update(GiderKategori giderKategori);
    }
}
