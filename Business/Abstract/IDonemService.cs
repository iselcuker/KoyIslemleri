using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IDonemService
    {
        List<Donem> GetAll();
        Donem GetById(int donemId);
        void Add(Donem donem);
        void Delete(Donem donem);
        void Update(Donem donem);
    }
}
