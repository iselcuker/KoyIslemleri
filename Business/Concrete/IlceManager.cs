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

        public List<Ilce> GetAll()
        {
            return _ilceDal.GetAll();
        }

        void IIlceService.Add(Ilce ilce)
        {
            _ilceDal.Add(ilce);
        }

        void IIlceService.Delete(Ilce ilce)
        {
           _ilceDal.Delete(ilce);
        }

        List<Ilce> IIlceService.GetAll()
        {
            return _ilceDal.GetAll();
        }

        Ilce IIlceService.GetById(int ilceId)
        {
            return _ilceDal.Get(i=>i.Id== ilceId);   
        }

        void IIlceService.Update(Ilce ilce)
        {
            _ilceDal.Update(ilce);
        }
    }
}
