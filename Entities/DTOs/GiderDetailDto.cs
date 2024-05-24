using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class GiderDetailDto:IDto
    {
        public int GiderId { get; set; }
        public string KoyAdi { get; set; }
        public int KoyId { get; set; }
        public string DonemAdi { get; set; }
        public byte DonemId { get; set; }
        public string GiderKategoriAdi { get; set; }
        public byte GiderKategoriId { get; set; }
        public string GiderAltKategoriAdi { get; set; }
        public byte GiderAltKategoriId { get; set; }
        public decimal Tutar { get; set; }
        public string EvrakNo { get; set; }
        public DateTime Tarih { get; set; }
        public string Alan { get; set; }
    }
}
