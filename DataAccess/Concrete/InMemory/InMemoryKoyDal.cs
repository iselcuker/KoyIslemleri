using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryKoyDal : IKoyDal
    {
        List<Koy> _koys;

        public InMemoryKoyDal()
        {
            _koys = new List<Koy>
            {
                new Koy{Id=1,IlceId=1,KoyAdi="Yalman"},
                 new Koy{Id=2,IlceId=1,KoyAdi="Yapılcan"},
                 new Koy{Id=3,IlceId=2,KoyAdi="Belisırma"},
                 new Koy{Id=4,IlceId=2,KoyAdi="Yaprakhisar"}
            };
        }

        public void Add(Koy koy)
        {
            _koys.Add(koy);
        }

        public void Delete(Koy koy)
        {
            Koy koyToDelete = _koys.SingleOrDefault(k => k.Id == koy.Id);
            _koys.Remove(koyToDelete);
        }

        public Koy Get(Expression<Func<Koy, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Koy> GetAll()
        {
            return _koys;
        }

        public List<Koy> GetAll(Expression<Func<Koy, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Koy> GetAllByIlceId(int ilceId)
        {
            return _koys.Where(k => k.IlceId == ilceId).ToList();
        }

        public void Update(Koy koy)
        {
            Koy koyToUpdate = _koys.SingleOrDefault(k => k.Id == koy.Id);
            koyToUpdate.KoyAdi = koy.KoyAdi;
            koyToUpdate.IlceId = koy.IlceId;
        }
    }
}
