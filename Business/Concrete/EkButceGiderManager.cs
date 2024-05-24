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
    public class EkButceGiderManager : IEkButceGiderService
    {
        IEkButceGiderDal _ekButceGiderDal;

        public EkButceGiderManager(IEkButceGiderDal ekButceGiderDal)
        {
            _ekButceGiderDal = ekButceGiderDal;
        }

        public void Add(EkButceGider ekButceGider)
        {
            _ekButceGiderDal.Add(ekButceGider);
        }

        public void Delete(EkButceGider ekButceGider)
        {
            _ekButceGiderDal.Delete(ekButceGider);
        }

        public List<EkButceGider> GetAllByKoyIdAndDonemId(int koyId, byte donemId)
        {
            return _ekButceGiderDal.GetAll(ebgi => ebgi.KoyId == koyId && ebgi.DonemId == donemId);
        }

        public List<EkButceGider> GetAllByKoyIdAndDonemIdAndGiderKategoriId(int koyId, byte donemId, byte giderKategoriId)
        {
            return _ekButceGiderDal.GetAll(ebgi => ebgi.KoyId == koyId && ebgi.DonemId == donemId && ebgi.GiderKategoriId == giderKategoriId);
        }

        public List<EkButceGider> GetAllByKoyIdAndDonemIdAndGiderKategoriIdAndGiderAltKategoriId(int koyId, byte donemId, byte giderKategoriId, byte giderAltKategoriId)
        {
            return _ekButceGiderDal.GetAll(ebgi => ebgi.KoyId == koyId && ebgi.DonemId == donemId && ebgi.GiderKategoriId == giderKategoriId && ebgi.GiderAltKategoriId == giderAltKategoriId);
        }

        public EkButceGider GetById(int ekButceGiderId)
        {
            return _ekButceGiderDal.Get(ebgi => ebgi.Id == ekButceGiderId);
        }

        public List<EkButceGiderDetailDto> GetEkButceGiderDetails()
        {
            return _ekButceGiderDal.GetEkButceGiderDetails();
        }

        public void Update(EkButceGider ekButceGider)
        {
            _ekButceGiderDal.Update(ekButceGider);
        }
    }
}
