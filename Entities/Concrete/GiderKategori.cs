using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class GiderKategori:IEntity
    {
        public byte Id { get; set; }
        public string GiderKategoriAdi { get; set; }

        public override string ToString()
        {
            return GiderKategoriAdi;
        }
    }
}
