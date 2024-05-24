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
    public class GiderAltKategoriManager : IGiderAltKategoriService
    {
        IGiderAltKategoriDal _giderAltKategoriDal;

        public GiderAltKategoriManager(IGiderAltKategoriDal giderAltKategoriDal)
        {
            _giderAltKategoriDal = giderAltKategoriDal;
        }

        public void Add(GiderAltKategori giderAltKategori)
        {
            _giderAltKategoriDal.Add(giderAltKategori);
        }

        public void Delete(GiderAltKategori giderAltKategori)
        {
            _giderAltKategoriDal.Delete(giderAltKategori);
        }

        public List<GiderAltKategori> GetAll()
        {
            return _giderAltKategoriDal.GetAll();
        }

        public List<GiderAltKategori> GetByGiderKategoriId(byte giderKategoriId)
        {
            return _giderAltKategoriDal.GetAll(gak => gak.GiderKategoriId == giderKategoriId);
        }

        public GiderAltKategori GetById(byte giderAltKategoriId)
        {
            return _giderAltKategoriDal.Get(gak => gak.Id == giderAltKategoriId);
        }

        public void Update(GiderAltKategori giderAltKategori)
        {
            _giderAltKategoriDal.Update(giderAltKategori);
        }
    }
}
