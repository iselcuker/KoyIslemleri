using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class GorevliDetailDto:IDto
    {
        public int GorevliId { get; set; }
        public int KoyId { get; set; }
        public string KoyAdi { get; set; }
        public string DonemAdi { get; set; }
        public byte DonemId { get; set; }
        public byte UnvanId { get; set; }
        public string UnvanAdi { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string TelefonNo { get; set; }
    }
}
