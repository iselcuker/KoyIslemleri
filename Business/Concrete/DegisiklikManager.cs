using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class DegisiklikManager : IDegisiklikService
    {
        IDegisiklikDal _degisiklikDal;

        public DegisiklikManager(IDegisiklikDal degisiklikDal)
        {
            _degisiklikDal = degisiklikDal;
        }

        public void Add(Degisiklik degisiklik)
        {
            _degisiklikDal.Add(degisiklik);
        }

        public void Delete(Degisiklik degisiklik)
        {
            _degisiklikDal.Delete(degisiklik);
        }

        public List<Degisiklik> GetAll()
        {
            return _degisiklikDal.GetAll();
        }

        public List<Degisiklik> GetById(byte degisiklikId)
        {
            return _degisiklikDal.GetAll(u => u.Id == degisiklikId);
        }

        public void Update(Degisiklik degisiklik)
        {
            _degisiklikDal.Update(degisiklik);
        }

        Degisiklik IDegisiklikService.GetById(byte degisiklikId)
        {
            return _degisiklikDal.Get(d => d.Id == degisiklikId);
        }
    }
}
