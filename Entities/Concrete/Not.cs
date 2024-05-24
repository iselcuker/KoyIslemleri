using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Not : IEntity
    {
        public int Id { get; set; }
        public int KoyId { get; set; }
        public byte DonemId { get; set; }
        public string Notu { get; set; }
    }
}
