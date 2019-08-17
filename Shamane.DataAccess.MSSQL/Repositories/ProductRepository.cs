using Microsoft.EntityFrameworkCore;
using Shamane.DataAccess.Repositories;
using Shamane.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace Shamane.DataAccess.MSSQL.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(DbContext dbContext, IPrincipal principal) : base(dbContext,principal)
        {
        }

        public IEnumerable<Product> GetParents(Guid? centerId)
        {
            return set.Include("EspeciallyForCenter").
                Where(x => x.ParentId == null &&
                (x.EspeciallyForCenterId == centerId || x.EspeciallyForCenterId == null));
        }

        public IEnumerable<Product> GetSubMenus(Guid parentId, Guid? centerId = null)
        {
            if (centerId == null)
                return set.Include("Parent").Include("EspeciallyForCenter").
                    Where(x => x.ParentId == parentId && x.EspeciallyForCenterId == null);
            else
                return set.Include("Parent").Include("EspeciallyForCenter").
                    Where(x => x.ParentId == parentId &&
                    (x.EspeciallyForCenterId == null || x.EspeciallyForCenterId == centerId));
        }

    }
}
