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
    public class DonemManager : IDonemService
    {
        IDonemDal _donemDal;

        public DonemManager(IDonemDal donemDal)
        {
            _donemDal = donemDal;
        }

        public void Add(Donem donem)
        {
            _donemDal.Add(donem);
        }

        public void Delete(Donem donem)
        {
            _donemDal.Delete(donem);
        }

        public List<Donem> GetAll()
        {
            return _donemDal.GetAll();
        }

        public Donem GetById(int donemId)
        {
            return _donemDal.Get(d=>d.Id==donemId);
        }

        public void Update(Donem donem)
        {
            _donemDal.Update(donem);
        }
    }
}
