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
    public class IdariIslerAltKategoriManager : IIdariIslerAltKategoriService
    {
        IIdariIslerAltKategoriDal _idariIslerAltKategoriDal;

        public IdariIslerAltKategoriManager(IIdariIslerAltKategoriDal idariIslerAltKategoriDal)
        {
            _idariIslerAltKategoriDal = idariIslerAltKategoriDal;
        }

        public void Add(IdariIslerAltKategori idariIslerAltKategori)
        {
            _idariIslerAltKategoriDal.Add(idariIslerAltKategori);
        }

        public void Delete(IdariIslerAltKategori idariIslerAltKategori)
        {
            _idariIslerAltKategoriDal.Delete(idariIslerAltKategori);
        }

        public List<IdariIslerAltKategori> GetAll()
        {
            return _idariIslerAltKategoriDal.GetAll();
        }

        public IdariIslerAltKategori GetByIdariIslerAltKategoriId(byte idariIslerAltKategoriId)
        {
            return _idariIslerAltKategoriDal.Get(iiak => iiak.Id == idariIslerAltKategoriId);
        }

        public List<IdariIslerAltKategori> GetByIdariIslerKategoriId(byte idariIslerKategoriId)
        {
            return _idariIslerAltKategoriDal.GetAll(iiak => iiak.IdariIslerKategoriId == idariIslerKategoriId);
        }

        public void Update(IdariIslerAltKategori idariIslerAltKategori)
        {
            _idariIslerAltKategoriDal.Update(idariIslerAltKategori);
        }
    }
}
