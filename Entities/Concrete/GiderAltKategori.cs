using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class GiderAltKategori : IEntity
    {
        public byte Id { get; set; }
        public byte GiderKategoriId { get; set; }
        public string GiderAltKategoriAdi { get; set; }

        public override string ToString()
        {
            return GiderAltKategoriAdi;
        }
    }
}
