using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class EkButceGelirDetailDto:IDto
    {
        public int EkButceGelirId { get; set; }
        public int KoyAdi { get; set; }
        public byte DonemAdi { get; set; }
        public byte GelirKategoriAdi { get; set; }
        public decimal EkGelirTutari { get; set; }
    }
}
