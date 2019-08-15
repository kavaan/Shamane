using Shamane.Domain;
using Shamane.Domain.Conts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shamane.DataAccess.Repositories
{
    public interface ICenterRepository : IRepository<Center>
    {
        IEnumerable<Center> Get(string title = null, Guid? provinceId = null,
            Guid? cityId = null, CenterType centerType = CenterType.Restaurant,
            DeliveryType deliveryType = DeliveryType.Null,
            CenterOrderBy centerOrderBy = CenterOrderBy.Null, int? from = 0, int? count = 20);
    }
}
