using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IKoyService
    {
        Koy GetById(int koyId);
        List<Koy> GetAllByIlceId(int ilceId);
        void Add(Koy koy);
        void Delete(Koy koy);
        void Update(Koy koy);
    }
}
