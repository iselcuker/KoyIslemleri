using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IDegisiklikService
    {
        List<Degisiklik> GetAll();
        Degisiklik GetById(byte degisiklikId);//yap
        void Add(Degisiklik degisiklik);
        void Delete(Degisiklik degisiklik);
        void Update(Degisiklik degisiklik);
    }
}
