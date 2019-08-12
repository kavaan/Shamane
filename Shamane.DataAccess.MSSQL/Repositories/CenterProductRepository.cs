using Microsoft.EntityFrameworkCore;
using Shamane.DataAccess.Repositories;
using Shamane.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shamane.DataAccess.MSSQL.Repositories
{
    public class CenterProductRepository : BaseRepository<CenterProduct>, ICenterProductRepository
    {
        public CenterProductRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<CenterProduct> Get(Guid centerId, Guid? parentId = null,
            string name = null, int? from = 0, int? count = 20)
        {
            var result = set.Where(x => x.CenterId == centerId &&
            x.Product.ParentId == parentId);
            if (!string.IsNullOrEmpty(name))
            {
                result = result.Where(x => x.Product.Name.Contains(name));
            }
            return result;
        }
    }
}
