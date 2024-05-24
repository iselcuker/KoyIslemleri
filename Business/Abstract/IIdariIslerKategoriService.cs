using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IIdariIslerKategoriService
    {
        List<IdariIslerKategori> GetAll();
        IdariIslerKategori GetById(int idariIslerKategoriId);
        void Add(IdariIslerKategori idariIslerKategori);
        void Delete(IdariIslerKategori idariIslerKategori);
        void Update(IdariIslerKategori idariIslerKategori);
    }
}
