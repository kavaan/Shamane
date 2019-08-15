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
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Order> Get(bool isFullInfo, Guid centerId, Guid? id,
            string orderCode, OrderStaus orderStaus, DateTime? fromDate,
            DateTime? toDate, int? from = 0, int? count = 20)
        {
            var result = set.AsQueryable();
            if (isFullInfo)
            {
                result = result.Include("Center")
                    .Include("OrderDetails")
                    .Include("OrderDetails.CenterProduct")
                    .Include("OrderDetails.CenterProduct.Product");
            }
            else
            {
                result = result.Include("Center");
            }
            if (centerId != Guid.Empty)
                result = result.Where(x => x.CenterId == centerId);

            if (id != null && id != Guid.Empty)
            {
                result = result.Where(x => x.Id == id);
            }
            if (!string.IsNullOrEmpty(orderCode))
            {
                result = result.Where(x => x.OrderCode == orderCode);
            }
            if (orderStaus != OrderStaus.Null)
            {
                result = result.Where(x => x.OrderStaus == orderStaus);
            }
            if (fromDate != null && toDate != null)
            {
                result = result.Where(x => x.RegisterdAt > fromDate && x.RegisterdAt <= toDate);
            }

            result = result.Skip((from * count).Value).Take(count.Value);

            return result;

        }

        public Order GetByCode(string code)
        {
            var result = set.FirstOrDefault(x => x.OrderCode == code);
            return result;
        }
    }
}
