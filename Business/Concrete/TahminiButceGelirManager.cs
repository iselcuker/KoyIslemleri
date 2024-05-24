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
    public class TahminiButceGelirManager : ITahminiButceGelirService
    {
        ITahminiButceGelirDal _tahminiButceGelirDal;

        public TahminiButceGelirManager(ITahminiButceGelirDal tahminiButceGelirDal)
        {
            _tahminiButceGelirDal = tahminiButceGelirDal;
        }

        public void Add(TahminiButceGelir tahminiButceGelir)
        {
            _tahminiButceGelirDal.Add(tahminiButceGelir);
        }

        public void Delete(TahminiButceGelir tahminiButceGelir)
        {
            _tahminiButceGelirDal.Delete(tahminiButceGelir);
        }

        public List<TahminiButceGelir> GetListByKoyIdAndDonemId(int koyId, byte donemId)
        {
            return _tahminiButceGelirDal.GetAll(tbge => tbge.KoyId == koyId && tbge.DonemId == donemId);
        }

        public List<TahminiButceGelir> GetListByKoyIdAndDonemIdAndGelirKategoriId(int koyId, byte donemId, byte gelirKategoriId)
        {
            return _tahminiButceGelirDal.GetAll(tbge => tbge.KoyId == koyId && tbge.DonemId == donemId && tbge.GelirKategoriId == gelirKategoriId);
        }

        public List<TahminiButceGelir> GetListKoyId(int koyId)
        {
            return _tahminiButceGelirDal.GetAll(tbge => tbge.KoyId == koyId);
        }

        public List<TahminiButceGelirDetailDto> GetTahminiButceGelirDetails(int koyId, byte donemId)
        {
            return _tahminiButceGelirDal.GetTahminiButceGelirDetails(koyId, donemId);
        }

        public TahminiButceGelir TahminiButceGelirGetById(int tahminiButceGelirId)
        {
            return _tahminiButceGelirDal.Get(tbge => tbge.Id == tahminiButceGelirId);
        }

        public void Update(TahminiButceGelir tahminiButceGelir)
        {
            _tahminiButceGelirDal.Update(tahminiButceGelir);
        }
    }
}
