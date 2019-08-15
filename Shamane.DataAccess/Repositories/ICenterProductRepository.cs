using Shamane.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shamane.DataAccess.Repositories
{
    public interface ICenterProductRepository : IRepository<CenterProduct>
    {
        IEnumerable<CenterProduct> Get(Guid centerId,
            Guid? parentId = null, string name = null, int? from = 0, int? count = 20);
        IEnumerable<CenterProduct> GetTrees(Guid guid);
        Dictionary<Guid,long> GetPrice(IEnumerable<Guid> centerProductIds);
    }
}
