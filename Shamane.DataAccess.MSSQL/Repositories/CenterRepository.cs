using Microsoft.EntityFrameworkCore;
using Shamane.DataAccess.Repositories;
using Shamane.Domain;
using Shamane.Domain.Conts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shamane.DataAccess.MSSQL.Repositories
{
    public class CenterRepository : BaseRepository<Center>, ICenterRepository
    {
        public CenterRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Center> Get(string title = null, Guid? provinceId = null,
            Guid? cityId = null, CenterType centerType = CenterType.Restaurant,
            DeliveryType deliveryType = DeliveryType.Null,
            CenterOrderBy centerOrderBy = CenterOrderBy.Null,
            int? from = 0, int? count = 20)
        {
            var result = set.Include("City").Include("City.Province").AsQueryable();
            if (!string.IsNullOrEmpty(title))
            {
                result = result.Where(x => x.Title.Contains(title));
            }
            if (provinceId != null)
            {
                result = result.Where(x => x.City.Province.Id == provinceId);
            }
            if (cityId != null)
            {
                result = result.Where(x => x.City.Id == cityId);
            }
            if (centerType != CenterType.Null)
            {
                result = result.Where(x => x.CenterType == centerType);
            }
            if (deliveryType != DeliveryType.Null)
            {
                result = result.Where(x => x.DeliveryType == deliveryType);
            }

            if (centerOrderBy != CenterOrderBy.Null)
            {
            }

            var _ = from.Value * count;
            result = result.Skip(_.Value).Take(count.Value);

            return result;
        }
    }
}
