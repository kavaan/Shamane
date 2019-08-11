using System;
using System.Collections.Generic;
using System.Text;
using Shamane.Service.Definition.Conts;
using Shamane.Service.Definition.Dto;

namespace Shamane.Service.Definition
{
    public interface IOrderService
    {
        void Accept(string id);
        void Reject(string id);
        void Finish(string id);
        OrderDto GetStatus(string id);
        IEnumerable<OrderDto> Get(string centerId, OrderStaus orderStaus, DateTime? fromDate, DateTime? toDate, int? from, int? count);
        void Add(OrderDto order);
    }
}
