using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TahminiButceManager : ITahminiButceService
    {
        ITahminiButceDal _tahminiButceDal;

        public TahminiButceManager(ITahminiButceDal tahminiButceDal)
        {
            _tahminiButceDal = tahminiButceDal;
        }
        //ITahminiButceDal _tahminiButceDal;

        //public TahminiButceManager(ITahminiButceDal tahminiButceDal)
        //{
        //    _tahminiButceDal = tahminiButceDal;
        //}

        public void Add(TahminiButce tahminiButce)
        {
            _tahminiButceDal.Add(tahminiButce);
        }

        public void Delete(TahminiButce tahminiButce)
        {
            _tahminiButceDal.Delete(tahminiButce);
        }

        public TahminiButce GetByTahminiButceId(int tahminiButceId)
        {
            return _tahminiButceDal.Get(tb => tb.Id == tahminiButceId);
        }

        public List<TahminiButce> GetListByKoyIdAndDonemId(int koyId, byte donemId)
        {
            return _tahminiButceDal.GetAll(tb => tb.KoyId == koyId && tb.DonemId == donemId);
        }

        public List<TahminiButce> GetListKoyId(int koyId)
        {
            return _tahminiButceDal.GetAll(tb => tb.KoyId == koyId);
        }

        public List<TahminiButceDetailDto> GetTahminiButceDetails()
        {
            return _tahminiButceDal.GetTahminiButceDetails();
        }

        public void Update(TahminiButce tahminiButce)
        {
            _tahminiButceDal.Update(tahminiButce);
        }
    }
}
