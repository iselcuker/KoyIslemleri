using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class TahminiButceIdariIslerDetailDto : IDto
    {
        public int TahminiButceIdariIslerId { get; set; }
        public string KoyAdi { get; set; }
        public int KoyId { get; set; }
        public string DonemAdi { get; set; }
        public byte DonemId { get; set; }
        public string IdariIslerKategoriAdi { get; set; }
        public byte IdariIslerKategoriId { get; set; }
        public string IdariIslerAltKategoriAdi { get; set; }
        public byte IdariIslerAltKategoriId { get; set; }
        public decimal TahminiIdariIslarTutari { get; set; }

    }
}
