using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class EkButceGelirDetailDto : IDto
    {
        public int EkButceGelirId { get; set; }
        public int KoyId { get; set; }
        public string KoyAdi { get; set; }
        public byte DonemId { get; set; }
        public string DonemAdi { get; set; }
        public byte GelirKategoriId { get; set; }
        public string GelirKategoriAdi { get; set; }
        public byte? DegisiklikId { get; set; }
        public string DegisiklikAdi { get; set; }
        public decimal EkGelirTutari { get; set; }
    }
}
