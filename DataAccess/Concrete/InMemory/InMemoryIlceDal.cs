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
    public class InMemoryIlceDal : IIlceDal
    {
        List<Ilce> _ilces;

        public InMemoryIlceDal()
        {
            _ilces = new List<Ilce>
            {
                new Ilce{Id=1,IlceAdi="Merkez"},
                new Ilce{Id=2,IlceAdi="Güzelyurt"}
            };
        }

        public void Add(Ilce ilce)
        {
            _ilces.Add(ilce);
        }

        public void Delete(Ilce ilce)
        {
            throw new NotImplementedException();
        }

        public Ilce Get(Expression<Func<Ilce, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Ilce> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Ilce> GetAll(Expression<Func<Ilce, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Ilce ilce)
        {
            throw new NotImplementedException();
        }
    }
}
