using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IGorevliService
    {
        List<Gorevli> GetListKoyIdAndDonemId(int koyId, byte donemId);
        Gorevli GetKoyIdAndDonemId(int koyId, byte donemId);
        public bool GorevliKontrol(int koyId, byte donemId, byte unvanId);
        Gorevli GetById(int gorevliId);
        void Add(Gorevli gorevli);
        void Delete(Gorevli gorevli);
        void Update(Gorevli gorevli);

        List<GorevliDetailDto> GetGorevliDetails(int koyId, byte donemId);
    }
}
