using Shamane.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shamane.Service.Definition.Dto
{
    public class CenterDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public CenterType CenterType { get; set; }
        public string CenterTypeString { get; set; }
        public string Tellphone { get; set; }
        public string Mail { get; set; }
        public string CityId { get; set; }
        public string City { get; set; }
        public string Province{ get; set; }
        public string ProvinceId { get; set; }
        public string Address { get; set; }
        public DateTime ContractStartDate { get; set; }
        public DateTime ContractEndDate { get; set; }
        public string ContractNumber { get; set; }
        public int Tax { get; set; }
        public int Priority { get; set; }
        public DeliveryType DeliveryType { get; set; }
        public string DeliveryTypeString { get; set; }
        public string DeliveryComment { get; set; }
        public long Lat { get; set; }
        public long Lng { get; set; }
        public string AttachmentImage { get; set; }
        public string LogoImage { get; set; }
        public string BannerImage { get; set; }

    }
}
