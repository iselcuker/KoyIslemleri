using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class GelirKategoriManager : IGelirKategoriService
    {
        IGelirKategoriDal _gelirKategoriDal;

        public GelirKategoriManager(IGelirKategoriDal gelirKategoriDal)
        {
            _gelirKategoriDal = gelirKategoriDal;
        }

        public void Add(GelirKategori gelirKategori)
        {
            _gelirKategoriDal.Add(gelirKategori);
        }

        public void Delete(GelirKategori gelirKategori)
        {
            _gelirKategoriDal.Delete(gelirKategori);
        }

        public List<GelirKategori> GetAll()
        {
            return _gelirKategoriDal.GetAll();
        }

        public GelirKategori GetById(int gelirKategoriId)
        {
            return _gelirKategoriDal.Get(gek => gek.Id == gelirKategoriId);
        }

        public void Update(GelirKategori gelirKategori)
        {
            _gelirKategoriDal.Update(gelirKategori);
        }
    }
}
