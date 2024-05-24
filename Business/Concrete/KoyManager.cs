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
    public class KoyManager : IKoyService
    {
        IKoyDal _koyDal;

        public KoyManager(IKoyDal koyDal)
        {
            _koyDal = koyDal;
        }

        public void Add(Koy koy)
        {
            _koyDal.Add(koy);
        }

        public void Delete(Koy koy)
        {
            _koyDal.Delete(koy);
        }

        public List<Koy> GetAllByIlceId(int ilceId)
        {
            return _koyDal.GetAll(k => k.IlceId == ilceId);
        }

        public Koy GetById(int koyId)
        {
            return _koyDal.Get(k => k.Id == koyId);
        }

        public void Update(Koy koy)
        {
            _koyDal.Update(koy);
        }
    }
}
