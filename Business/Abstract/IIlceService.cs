using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IIlceService
    {
        List<Ilce> GetAll();
        Ilce GetById(byte ilceId);
       
        void Add(Ilce ilce);
        void Delete(Ilce ilce);
        void Update(Ilce ilce);
    }
}
