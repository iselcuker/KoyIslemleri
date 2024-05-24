using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface INotService
    {
        Not GetById(int notId);
        List<Not> GetByKoyId(int koyId);
        List<Not>GetByKoyIdAndDonemId(int koyId,byte donemId);
        void Add(Not not);
        void Delete(Not not);
        void Update(Not not);
    }
}
