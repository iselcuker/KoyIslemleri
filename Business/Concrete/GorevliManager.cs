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
    public class GorevliManager : IGorevliService
    {
        IGorevliDal _gorevliDal;

        public GorevliManager(IGorevliDal gorevliDal)
        {
            _gorevliDal = gorevliDal;
        }

        public void Add(Gorevli gorevli)
        {
            _gorevliDal.Add(gorevli);
        }

        public void Delete(Gorevli gorevli)
        {
            _gorevliDal.Delete(gorevli);
        }

        public Gorevli GetById(int gorevliId)
        {
            return _gorevliDal.Get(g => g.Id == gorevliId);
        }

        public List<GorevliDetailDto> GetGorevliDetails(int koyId, byte donemId)
        {
            return _gorevliDal.GetGorevliDetails(koyId, donemId);
        }

        public Gorevli GetKoyIdAndDonemId(int koyId, byte donemId)
        {
            return _gorevliDal.Get(g => g.KoyId == koyId && g.DonemId == donemId);
        }

        public List<Gorevli> GetListKoyIdAndDonemId(int koyId, byte donemId)
        {
            return _gorevliDal.GetAll(go => go.KoyId == koyId && go.DonemId == donemId);
        }

        public bool GorevliKontrol(int koyId, byte donemId, byte unvanId)
        {
            return _gorevliDal.Get(g => g.KoyId == koyId && g.DonemId == donemId && g.UnvanId == unvanId) != null;
        }

        public void Update(Gorevli gorevli)
        {
            _gorevliDal.Update(gorevli);
        }
    }
}
