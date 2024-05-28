using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Degisiklik : IEntity
    {
        //public byte Id { get; set; }
        //public string DegisiklikAdi { get; set; }

        //public override string ToString()
        //{
        //    return DegisiklikAdi;
        //}

        public byte Id { get; set; }
        public string DegisiklikAdi { get; set; }

        public override string ToString()
        {
            return DegisiklikAdi;
        }
    }
}
