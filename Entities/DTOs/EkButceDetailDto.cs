using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class EkButceDetailDto : IDto
    {
        public int EkButceId { get; set; }
        public string KoyAdi { get; set; }
        public string DonemAdi { get; set; }
        public decimal EkButceTutari { get; set; }
    }
}
