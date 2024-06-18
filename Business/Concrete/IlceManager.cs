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
    public class IlceManager : IIlceService
    {
        IIlceDal _ilceDal;

        public IlceManager(IIlceDal ilceDal)
        {
            _ilceDal = ilceDal;
        }

        public void Add(Ilce ilce)
        {
            _ilceDal.Add(ilce);
        }

        public void Delete(Ilce ilce)
        {
            _ilceDal.Delete(ilce);
        }

        public List<Ilce> GetAll()
        {
            return _ilceDal.GetAll();
        }

        public Ilce GetById(byte ilceId)
        {
            return _ilceDal.Get(i => i.Id == ilceId);
        }

        public void Update(Ilce ilce)
        {
            _ilceDal.Update(ilce);
        }
    }
}
