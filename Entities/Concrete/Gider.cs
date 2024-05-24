using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Gider : IEntity
    {
        public int Id { get; set; }
        public int KoyId { get; set; }
        public byte DonemId { get; set; }
        public byte GiderKategoriId { get; set; }
        public byte GiderAltKategoriId { get; set; }
        public decimal Tutar { get; set; }
        public string EvrakNo { get; set; }
        public DateTime Tarih { get; set; }
        public string Alan { get; set; }
    }
}
