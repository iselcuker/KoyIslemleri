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
    public class GelirManager : IGelirService
    {
        IGelirDal _gelirDal;

        public GelirManager(IGelirDal gelirDal)
        {
            _gelirDal = gelirDal;
        }

        public void Add(Gelir gelir)
        {
            _gelirDal.Add(gelir);
        }

        public void Delete(Gelir gelir)
        {
            _gelirDal.Delete(gelir);
        }

        public Gelir GetById(int gelirId)
        {
            return _gelirDal.Get(ge => ge.Id == gelirId);
        }

        public List<GelirDetailDto> GetGelirDetails()
        {
            return _gelirDal.GetGelirDetails();
        }

        public List<Gelir> GetListDonemIdAndKoyIdAndGelirKategoriId(byte donemId, int koyId, byte gelirKategoriId)
        {
            return _gelirDal.GetAll(ge => ge.DonemId == donemId && ge.KoyId == koyId && ge.GelirKategoriId == gelirKategoriId);
        }

        public List<GelirDetailDto> GetListGelirDetailsKoyAndDonemId(int koyId, byte donemId)
        {
            return _gelirDal.GetListGelirDetailsKoyAndDonemId(koyId,donemId);
        }

        public List<Gelir> GetListKoyId(int koyId)
        {
            return _gelirDal.GetAll(ge=>ge.KoyId==koyId);
        }

        public List<Gelir> GetListKoyIdAndDonemId(int koyId, byte donemId)
        {
            return _gelirDal.GetAll(ge => ge.KoyId == koyId && ge.DonemId == donemId);
        }

        public void Update(Gelir gelir)
        {
            _gelirDal.Update(gelir);
        }
    }
}
