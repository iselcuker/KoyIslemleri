using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class IdariIslerAltKategori : IEntity
    {
        public byte Id { get; set; }
        public byte IdariIslerKategoriId { get; set; }
        public string IdariIslerAltKategoriAdi { get; set; }

        public override string ToString()
        {
            return IdariIslerAltKategoriAdi;
        }
    }
}
