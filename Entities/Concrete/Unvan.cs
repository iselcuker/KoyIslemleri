using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Unvan : IEntity
    {
        public byte Id { get; set; }
        public string UnvanAdi { get; set; }

        public override string ToString()
        {
            return UnvanAdi;
        }
    }
}
