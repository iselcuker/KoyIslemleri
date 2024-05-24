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
    public class UnvanManager : IUnvanService
    {
        IUnvanDal _unvanDal;

        public UnvanManager(IUnvanDal unvanDal)
        {
            _unvanDal = unvanDal;
        }

        public void Add(Unvan unvan)
        {
            _unvanDal.Add(unvan);
        }

        public void Delete(Unvan unvan)
        {
            _unvanDal.Delete(unvan);
        }

        public List<Unvan> GetAll()
        {
            return _unvanDal.GetAll();
        }

        public Unvan GetByUnvanId(int unvanId)
        {
            return _unvanDal.Get(u => u.Id == unvanId);
        }

        public void Update(Unvan unvan)
        {
            _unvanDal.Update(unvan);
        }
    }
}
