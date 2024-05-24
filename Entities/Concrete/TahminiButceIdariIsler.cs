using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class TahminiButceIdariIsler : IEntity
    {
        public int Id { get; set; }
        public int KoyId { get; set; }
        public byte DonemId { get; set; }
        public byte IdariIslerKategoriId { get; set; }
        public byte IdariIslerAltKategoriId { get; set; }
        public decimal TahminiIdariIslarTutari { get; set; }
    }
}
