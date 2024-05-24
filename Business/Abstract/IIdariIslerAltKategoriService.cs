using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IIdariIslerAltKategoriService
    {
        IdariIslerAltKategori GetByIdariIslerAltKategoriId(byte idariIslerAltKategoriId);
        List<IdariIslerAltKategori> GetAll();
        List<IdariIslerAltKategori> GetByIdariIslerKategoriId(byte idariIslerKategoriId);
        void Add(IdariIslerAltKategori idariIslerAltKategori);
        void Delete(IdariIslerAltKategori idariIslerAltKategori);
        void Update(IdariIslerAltKategori idariIslerAltKategori);
    }
}
