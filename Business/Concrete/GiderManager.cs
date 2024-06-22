using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class GiderManager : IGiderService
    {
        IGiderDal _giderDal;

        public GiderManager(IGiderDal giderDal)
        {
            _giderDal = giderDal;
        }

        public void Add(Gider gider)
        {
            _giderDal.Add(gider);
        }

        public void Delete(Gider gider)
        {
            _giderDal.Delete(gider);
        }

        public Gider GetById(int giderId)
        {
            return _giderDal.Get(gi => gi.Id == giderId);
        }

        public List<GiderDetailDto> GetGiderDetails()
        {
            return _giderDal.GetGiderDetails();
        }

        public List<Gider> GetListDonemIdAndKoyIdAndGiderKategoriId(byte donemId, int koyId, byte giderKategoriId)
        {
            return _giderDal.GetAll(gi => gi.DonemId == donemId && gi.KoyId == koyId && gi.GiderKategoriId == giderKategoriId);
        }

        public List<Gider> GetListDonemIdAndKoyIdAndGiderKategoriIdAndGiderAltKategori(byte donemId, int koyId, byte giderKategoriId, byte giderAltKategoriId)
        {
            return _giderDal.GetAll(gi => gi.DonemId == donemId && gi.KoyId == koyId && gi.GiderKategoriId == giderKategoriId && gi.GiderAltKategoriId == giderAltKategoriId);
        }

        public List<GiderDetailDto> GetListGiderDetailsKoyAndDonemId(int koyId, byte donemId)
        {
            return _giderDal.GetListGiderDetailsKoyAndDonemId(koyId, donemId);
        }

        public List<Gider> GetListKoyId(int koyId)
        {
            return _giderDal.GetAll(gi => gi.KoyId == koyId);
        }

        public List<Gider> GetListKoyIdAndDonemId(int koyId, byte donemId)
        {
            return _giderDal.GetAll(gi => gi.DonemId == donemId && gi.KoyId == koyId);
        }

        public decimal GiderAltKategoriToplami(int koyId, byte donemId, byte giderAltKategoriId)
        {
            List<Gider> giderler = _giderDal.GetAll(gi => gi.KoyId == koyId && gi.DonemId == donemId && gi.GiderAltKategoriId == giderAltKategoriId);

            decimal toplamTutar = giderler.Sum(gi => gi.Tutar);

            return toplamTutar;
        }

        public void Update(Gider gider)
        {
            _giderDal.Update(gider);
        }
    }
}
