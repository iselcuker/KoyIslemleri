using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class EkButceGider : IEntity
    {
        public int Id { get; set; }
        public int KoyId { get; set; }
        public byte DonemId { get; set; }
        public byte GiderKategoriId { get; set; }
        public byte GiderAltKategoriId { get; set; }
        public byte? DegisiklikId { get; set; }
        public decimal EkGiderTutari { get; set; }
    }
}
