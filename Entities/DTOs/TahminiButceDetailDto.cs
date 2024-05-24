using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class TahminiButceDetailDto : IDto
    {
        public int TahminiButceId { get; set; }
        public string KoyAdi { get; set; }
        public string DonemAdi { get; set; }
        public decimal TahminiButceTutari { get; set; }

    }
}
