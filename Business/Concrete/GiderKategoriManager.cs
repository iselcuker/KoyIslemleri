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
    public class GiderKategoriManager : IGiderKategoriService
    {
        IGiderKategoriDal _giderKategoriDal;

        public GiderKategoriManager(IGiderKategoriDal giderKategoriDal)
        {
            _giderKategoriDal = giderKategoriDal;
        }

        public void Add(GiderKategori giderKategori)
        {
            _giderKategoriDal.Add(giderKategori);
        }

        public void Delete(GiderKategori giderKategori)
        {
            _giderKategoriDal.Delete(giderKategori); 
        }

        public List<GiderKategori> GetAll()
        {
            return _giderKategoriDal.GetAll();
        }

        public GiderKategori GetById(byte giderKategoriId)
        {
            return _giderKategoriDal.Get(gik=>gik.Id==giderKategoriId);
        }

        public void Update(GiderKategori giderKategori)
        {
            _giderKategoriDal.Update(giderKategori);
        }
    }
}
