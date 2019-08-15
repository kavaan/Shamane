using Shamane.Domain.Conts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shamane.Domain
{
    public class Order : BaseEntity
    {
        public Guid AcceptedBy { get; set; }
        public Guid RejectedBy { get; set; }
        public Guid CompletedBy { get; set; }
        public DateTime? AcceptedDateTime { get; set; }
        public DateTime? RejectedDateTime { get; set; }
        public DateTime? CompletedDateTime { get; set; }
        public DateTime? SendToDelivertDateTime { get; set; }
        public Guid SendToDeliveryBy { get; set; }
        public OrderStaus OrderStaus { get; set; }
        public OrderDeliverType OrderDeliverType { get; set; }
        public string RejectReason { get; set; }
        public bool TargetAddressIsUserProfileAddress { get; set; }
        public string Address { get; set; }
        public Guid CenterId { get; set; }
        public virtual Center Center { get; set; }
        public string Description { get; set; }
        public long? TotalPrice { get; set; }
        public long? Discount { get; set; }
        public long? Tax { get; set; }
        public long? DeliveryPrice { get; set; }
        public string OrderCode { get; set; }
        public virtual IEnumerable<OrderDetail> OrderDetails { get; set; }
        public DateTime RegisterdAt { get; set; }
        public Guid RegisterdBy { get; set; }
    }
}
