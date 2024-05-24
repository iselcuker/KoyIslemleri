using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IGelirDal : IEntityRepository<Gelir>
    {
        List<GelirDetailDto> GetGelirDetails();
        List<GelirDetailDto> GetListGelirDetailsKoyAndDonemId(int koyId, byte donemId);
    }
}
