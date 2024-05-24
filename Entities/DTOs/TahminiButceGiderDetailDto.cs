using Core.Entities;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class TahminiButceGiderDetailDto:IDto
    {
        public int TahminiButceGiderId { get; set; }
        public string KoyAdi { get; set; }
        public string DonemAdi { get; set; }
        public string GiderKategoriAdi { get; set; }
        public string GiderAltKategoriAdi { get; set; }
        public string DegisiklikAdi { get; set; }
        public decimal Tutar { get; set; }
    }
}
