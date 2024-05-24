using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUnvanService
    {
        List<Unvan> GetAll();
        Unvan GetByUnvanId(int unvanId);
        void Add(Unvan unvan);
        void Delete(Unvan unvan);
        void Update(Unvan unvan);
    }
}
