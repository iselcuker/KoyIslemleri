using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class EkButceGelir : IEntity
    {
        public int Id { get; set; }
        public int KoyId { get; set; }
        public byte DonemId { get; set; }
        public byte GelirKategoriId { get; set; }
        public decimal EkGelirTutari { get; set; }
    }
}
