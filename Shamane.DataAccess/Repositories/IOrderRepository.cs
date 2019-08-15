using Shamane.Domain;
using Shamane.Domain.Conts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shamane.DataAccess.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        Order GetByCode(string code);
        IEnumerable<Order> Get(bool isFullInfo, Guid centerId, Guid? id,
            string orderCode, OrderStaus orderStaus,
            DateTime? fromDate, DateTime? toDate,
            int? from, int? count);
    }
}
