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
    public class EkButceGelirManager : IEkButceGelirService
    {
        IEkButceGelirDal _ekButceGelir;

        public EkButceGelirManager(IEkButceGelirDal ekButceGelir)
        {
            _ekButceGelir = ekButceGelir;
        }

        public void Add(EkButceGelir ekButceGelir)
        {
            _ekButceGelir.Add(ekButceGelir);
        }

        public void Delete(EkButceGelir ekButceGelir)
        {
            _ekButceGelir.Delete(ekButceGelir);
        }

        public List<EkButceGelir> GetAllByKoyIdAndDonemId(int koyId, byte donemId)
        {
            return _ekButceGelir.GetAll(ebg => ebg.KoyId == koyId && ebg.DonemId == donemId);
        }

        public List<EkButceGelir> GetAllByKoyIdAndDonemIdAndGelirKategoriId(int koyId, byte donemId)
        {
            return _ekButceGelir.GetAll(ebge => ebge.KoyId == koyId && ebge.DonemId == donemId);
        }

        public EkButceGelir GetById(int ekbutceGelirId)
        {
            return _ekButceGelir.Get(ebge => ebge.Id == ekbutceGelirId);
        }

        public List<EkButceGelirDetailDto> GetEkButceGelirDetails(int koyId, byte donemId)
        {
            return _ekButceGelir.GetEkButceGelirDetails(koyId, donemId);
        }

        public void Update(EkButceGelir ekButceGelir)
        {
            _ekButceGelir.Update(ekButceGelir);
        }
    }
}
