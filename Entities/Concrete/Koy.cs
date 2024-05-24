using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Koy : IEntity
    {
        public int Id { get; set; }
        public byte IlceId { get; set; }
        public string KoyAdi { get; set; }

        public override string ToString()
        {
            return KoyAdi.ToString();
        }
    }
}
