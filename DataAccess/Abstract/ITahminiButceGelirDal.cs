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
    public interface ITahminiButceGelirDal : IEntityRepository<TahminiButceGelir>
    {
        List<TahminiButceGelirDetailDto> GetTahminiButceGelirDetails(int koyId, byte donemId);
    }
}
