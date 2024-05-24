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
    public class NotManager : INotService
    {
        INotDal _notDal;

        public NotManager(INotDal notDal)
        {
            _notDal = notDal;
        }

        public void Add(Not not)
        {
            _notDal.Add(not);
        }

        public void Delete(Not not)
        {
            _notDal.Delete(not);
        }

        public Not GetById(int notId)
        {
            return _notDal.Get(n => n.Id == notId);
        }

        public List<Not> GetByKoyId(int koyId)
        {
            return _notDal.GetAll(n => n.KoyId == koyId);
        }

        public List<Not> GetByKoyIdAndDonemId(int koyId, byte donemId)
        {
            return _notDal.GetAll(n => n.KoyId == koyId && n.DonemId == donemId);
        }

        public void Update(Not not)
        {
            _notDal.Update(not);
        }
    }
}
