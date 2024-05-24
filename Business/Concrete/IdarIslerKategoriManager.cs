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
    public class IdarIslerKategoriManager : IIdariIslerKategoriService
    {
        IIdariIslerKategoriDal _idariIslerKategoriDal;

        public IdarIslerKategoriManager(IIdariIslerKategoriDal idariIslerKategoriDal)
        {
            _idariIslerKategoriDal = idariIslerKategoriDal;
        }

        public void Add(IdariIslerKategori idariIslerKategori)
        {
            _idariIslerKategoriDal.Add(idariIslerKategori);
        }

        public void Delete(IdariIslerKategori idariIslerKategori)
        {
            _idariIslerKategoriDal.Delete(idariIslerKategori);
        }

        public List<IdariIslerKategori> GetAll()
        {
            return _idariIslerKategoriDal.GetAll();
        }

        public IdariIslerKategori GetById(int idariIslerKategoriId)
        {
            return _idariIslerKategoriDal.Get(iik => iik.Id == idariIslerKategoriId);
        }

        public void Update(IdariIslerKategori idariIslerKategori)
        {
            _idariIslerKategoriDal.Update(idariIslerKategori);
        }
    }
}
