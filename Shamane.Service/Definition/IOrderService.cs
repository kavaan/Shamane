using System;
using System.Collections.Generic;
using System.Text;
using Shamane.Domain.Conts;
using Shamane.Service.Definition.Dto;

namespace Shamane.Service.Definition
{
    public interface IOrderService
    {
        void Accept(string id);
        void Reject(string id, string rejectResoan);
        void SendToDelivery(string id);
        void Complete(string id);
        OrderDto Add(OrderDto orderDto);
        OrderDto GetStatus(string id);
        OrderDto GetStatusByCode(string code);
        IEnumerable<OrderDto> Get(string centerId, string id = null,
            string orderCode = null, OrderStaus orderStaus = OrderStaus.Null,
            DateTime? fromDate = null, DateTime? toDate = null, int? from = 0,
            int? count = 20);
        IEnumerable<OrderDto> GetTodayOrders(string centerId, string id = null,
            string orderCode = null, OrderStaus orderStaus = OrderStaus.Null,
            int? from = 0, int? count = 20);
        OrderDto GetFullInfo(string id);
        OrderDto GetFullInfoByCode(string code);
        IEnumerable<OrderDetailDto> GetOrderDetails( string id);
    }
}
