using Shamane.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shamane.DataAccess.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetParents(Guid? centerId);
        IEnumerable<Product> GetSubMenus(Guid parentId, Guid? centerId = null);
    }
}
