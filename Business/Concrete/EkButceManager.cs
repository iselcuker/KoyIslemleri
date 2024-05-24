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
    public class EkButceManager : IEkButceService
    {
        IEkButceDal _ekButce;

        public EkButceManager(IEkButceDal ekButce)
        {
            _ekButce = ekButce;
        }

        public void Add(EkButce ekButce)
        {
            _ekButce.Add(ekButce);
        }

        public void Delete(EkButce ekButce)
        {
            _ekButce.Delete(ekButce);
        }

        public List<EkButce> GetAllByKoyIdAndDonemId(int koyId, byte donemId)
        {
            return _ekButce.GetAll(eb => eb.KoyId == koyId && eb.DonemId == donemId);
        }

        public EkButce GetById(int ekButceId)
        {
            return _ekButce.Get(eb => eb.Id == ekButceId);
        }

        public List<EkButce> GetListKoyId(int koyId)
        {
            return _ekButce.GetAll(eb => eb.KoyId == koyId);
        }

        public void Update(EkButce ekButce)
        {
            _ekButce.Update(ekButce);
        }
    }
}
