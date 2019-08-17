using System;
using System.Collections.Generic;
using System.Text;

namespace Shamane.Domain
{
    public class Center : BaseEntity
    {
        public string Title { get; set; }
        public CenterType CenterType { get; set; }
        public string Tellphone { get; set; }
        public string Mail { get; set; }
        public Guid CityId { get; set; }
        public virtual City City { get; set; }
        public string Address { get; set; }
        public DateTime ContractStartDate { get; set; }
        public DateTime ContractEndDate { get; set; }
        public string ContractNumber { get; set; }
        public int Tax { get; set; }
        public int Priority { get; set; }
        public DeliveryType DeliveryType { get; set; }
        public string DeliveryComment { get; set; }
        public long Lat { get; set; }
        public long Lng { get; set; }
        public string AttachmentImage { get; set; }
        public string LogoImage { get; set; }
        public string BannerImage { get; set; }
        public Guid OwnerId { get; set; }

    }
    public enum CenterType
    {
        Null,
        CoffeeShop,
        JuiceShop,
        Restaurant,
        Fastfood
    }
    public enum DeliveryType
    {
        Null,
        NoDelivery,
        Free,
        DependOnOrder
    }
}
