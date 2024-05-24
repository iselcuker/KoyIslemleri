using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class GelirDetailDto : IDto
    {
        public int GelirId { get; set; }
        public string GelirKategoriAdi { get; set; }
        public string KoyAdi { get; set; }
        public string DonemAdi { get; set; }
        public decimal Tutar { get; set; }
        public DateTime Tarih { get; set; }
        public string EvrakNo { get; set; }
        public string Veren { get; set; }
        public int KoyId { get; set; }
        public byte DonemId { get; set; }     
        public byte GelirKategoriId { get; set; }
    }
}
