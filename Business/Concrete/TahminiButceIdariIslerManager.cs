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
    public class TahminiButceIdariIslerManager : ITahminiButceIdariIslerService
    {
        ITahminiButceIdariIslerDal _tahminiButceIdariIslerDal;

        public TahminiButceIdariIslerManager(ITahminiButceIdariIslerDal tahminiButceIdariIslerDal)
        {
            _tahminiButceIdariIslerDal = tahminiButceIdariIslerDal;
        }

        public void Add(TahminiButceIdariIsler tahminiButceİdariIsler)
        {
            _tahminiButceIdariIslerDal.Add(tahminiButceİdariIsler);
        }

        public void Delete(TahminiButceIdariIsler tahminiButceİdariIsler)
        {
            _tahminiButceIdariIslerDal.Delete(tahminiButceİdariIsler);
        }

        public TahminiButceIdariIsler GetByTahminiButceIdariIslerId(int tahminiButceIdariIslerId)
        {
            return _tahminiButceIdariIslerDal.Get(tbiis => tbiis.Id==tahminiButceIdariIslerId);
        }

        public List<TahminiButceIdariIsler> GetListByKoyIdAndDonemId(int koyId, byte donemId)
        {
            return _tahminiButceIdariIslerDal.GetAll(tbiis => tbiis.KoyId == koyId && tbiis.DonemId == donemId);
        }

        public List<TahminiButceIdariIsler> GetListByKoyIdAndDonemIdAndIdariIslerKategoriId(int koyId, byte donemId, byte idariIslerKategoriId)
        {
            return _tahminiButceIdariIslerDal.GetAll(tbiis => tbiis.KoyId == koyId && tbiis.DonemId == donemId && tbiis.IdariIslerKategoriId == idariIslerKategoriId);
        }

        public List<TahminiButceIdariIsler> GetListByKoyIdAndDonemIdAndIdariIslerKategoriIdAndIdariIslerAltKategoriId(int koyId, byte donemId, byte idariIslerKategoriId, byte idariIslerAltKategoriId)
        {
            return _tahminiButceIdariIslerDal.GetAll(tbiis => tbiis.KoyId == koyId && tbiis.DonemId == donemId && tbiis.IdariIslerKategoriId == idariIslerKategoriId && tbiis.IdariIslerAltKategoriId == idariIslerKategoriId);
        }

        public List<TahminiButceIdariIsler> GetListKoyId(int koyId)
        {
            return _tahminiButceIdariIslerDal.GetAll(tbiis => tbiis.KoyId == koyId);
        }

        public void Update(TahminiButceIdariIsler tahminiButceİdariIsler)
        {
            _tahminiButceIdariIslerDal.Update(tahminiButceİdariIsler);
        }
    }
}
