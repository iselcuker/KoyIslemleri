using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class KesinHesap1DetailDto : IDto
    {
        public int Id { get; set; }
        public int KoyId { get; set; }
        public string KoyAdi { get; set; }
        public byte DonemId { get; set; }
        public string DonemAdi { get; set; }
        public byte? DegisiklikId { get; set; }
        public string DegisiklikAdi { get; set; }
        public byte GelirKategoriId { get; set; }
        public string GelirKategoriAdi { get; set; }
        public byte GiderAltKategoriId { get; set; }
        public string GiderAltKategoriAdi { get; set; }
        public decimal TahminiGelirTutari { get; set; }
        public decimal TahminiGiderTutari { get; set; }
        public decimal GelirTutari { get; set; }
        public decimal GiderTutari { get; set; }

    }
}
