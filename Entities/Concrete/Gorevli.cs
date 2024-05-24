using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Gorevli:IEntity
    {
        public int Id { get; set; }
        public int KoyId { get; set; }
        public byte DonemId { get; set; }
        public byte UnvanId { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string TelefonNo { get; set; }
    }
}
