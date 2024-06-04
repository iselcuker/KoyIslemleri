using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class EkButceGiderDetailDto : IDto
    {
        public int EkButceGiderId { get; set; }
        public int KoyId { get; set; }
        public string KoyAdi { get; set; }
        public byte DonemId { get; set; }
        public string DonemAdi { get; set; }
        public byte GiderKategoriId { get; set; }
        public string GiderKategoriAdi { get; set; }
        public byte GiderAltKategoriId { get; set; }
        public string GiderAltKategoriAdi { get; set; }
        public decimal EkGiderTutari { get; set; }
        public byte? DegisiklikId { get; set; }
        public string DegisiklikAdi { get; set; }
    }
}
