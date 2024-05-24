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
    public class TahminiButceGiderManager : ITahminiButceGiderService
    {
        ITahminiButceGiderDal _tahminiButceGiderDal;

        public TahminiButceGiderManager(ITahminiButceGiderDal tahminiButceGiderDal)
        {
            _tahminiButceGiderDal = tahminiButceGiderDal;
        }

        public void Add(TahminiButceGider tahminiButceGider)
        {
            _tahminiButceGiderDal.Add(tahminiButceGider);
        }

        public void Delete(TahminiButceGider tahminiButceGider)
        {
            _tahminiButceGiderDal.Delete(tahminiButceGider);
        }

        public TahminiButceGider GetByTahminiButceGiderId(int tahminiButceGiderId)
        {
            return _tahminiButceGiderDal.Get(tbgi => tbgi.Id == tahminiButceGiderId);
        }

        public List<TahminiButceGider> GetListByKoyIdAndDonemId(int koyId, byte donemId)
        {
            return _tahminiButceGiderDal.GetAll(tbgi => tbgi.KoyId == koyId && tbgi.DonemId == donemId);
        }

        public List<TahminiButceGider> GetListByKoyIdAndDonemIdAndGiderKategoriId(int koyId, byte donemId, byte giderKategoriId)
        {
            return _tahminiButceGiderDal.GetAll(tbgi => tbgi.KoyId == koyId && tbgi.DonemId == donemId && tbgi.GiderKategoriId == giderKategoriId);
        }

        public List<TahminiButceGider> GetListByKoyIdAndDonemIdAndGiderKategoriIdAndGiderAltKategoriId(int koyId, byte donemId, byte giderKategoriId, byte giderAltKategoriId)
        {
            return _tahminiButceGiderDal.GetAll(tbgi => tbgi.KoyId == koyId && tbgi.DonemId == donemId && tbgi.GiderKategoriId == giderKategoriId && tbgi.GiderAltKategoriId == giderAltKategoriId);
        }

        public List<TahminiButceGider> GetListKoyId(int koyId)
        {
            return _tahminiButceGiderDal.GetAll(tbgi => tbgi.KoyId == koyId);
        }

        public List<TahminiButceGiderDetailDto> GetTahminiButceGiderDetails()
        {
            return _tahminiButceGiderDal.GetTahminiButceGiderDetails();
        }

        public void Update(TahminiButceGider tahminiButceGider)
        {
            _tahminiButceGiderDal.Update(tahminiButceGider);
        }
    }
}
