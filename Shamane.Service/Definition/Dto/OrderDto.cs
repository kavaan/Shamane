using Shamane.Domain.Conts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shamane.Service.Definition.Dto
{
    public class OrderDto
    {
        public string Id { get; set; }
        public DateTime RegisterdAt { get; set; }
        public OrderStaus OrderStaus { get; set; }
        public string OrderStausString { get; set; }
        public OrderDeliverType OrderDeliverType { get; set; }
        public string OrderDeliverTypeString { get; set; }
        public string RejectReason { get; set; }
        public string Address { get; set; }
        public string CenterId { get; set; }
        public string CenterName { get; set; }
        public string Description { get; set; }
        public long? TotalPrice { get; set; }
        public long Discount { get; set; }
        public long Tax { get; set; }
        public long? DeliveryPrice { get; set; }
        public string OrderCode { get; set; }
        public virtual IEnumerable<OrderDetailDto> OrderDetailDtos { get; set; }

    }
}
