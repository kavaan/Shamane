using Shamane.Common.Extensions;
using Shamane.Domain;
using Shamane.Service.Definition.Dto;
using Shamane.Service.Definition.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shamane.Service.Implementation.Factories
{
    public class CenterFactory : ModelFactory<Center, CenterDto>, ICenterFatory
    {
        public override CenterDto CreateDto(Center entity)
        {
            var dto =  base.CreateDto(entity);
            if (entity.City !=null)
            {
                dto.City = entity.City.Name;
                dto.CityId = entity.CityId.ToString();
                dto.ProvinceId = entity.City.ProvinceId.ToString();
                dto.Province = entity.City.Province.Name;
            }
            switch (dto.CenterType)
            {
                case CenterType.Null:
                    dto.CenterTypeString = "بدون اطلاعات";
                    break;
                case CenterType.CoffeeShop:
                    dto.CenterTypeString = "کافی شاپ";
                    break;
                case CenterType.JuiceShop:
                    dto.CenterTypeString = "آبمیوه و بستنی";
                    break;
                case CenterType.Restaurant:
                    dto.CenterTypeString = "رستوران";
                    break;
                case CenterType.Fastfood:
                    dto.CenterTypeString = "فست فود";
                    break;
                default:
                    break;
            }
            switch (dto.DeliveryType)
            {
                case DeliveryType.Null:
                    dto.DeliveryTypeString = "بدون اطلاعات";
                    break;
                case DeliveryType.NoDelivery:
                    dto.DeliveryTypeString = "بدون پیک";
                    break;
                case DeliveryType.Free:
                    dto.DeliveryTypeString = "رایگان";
                    break;
                case DeliveryType.DependOnOrder:
                    dto.DeliveryTypeString = "بر اساس سفارش";
                    break;
                default:
                    break;
            }
            return dto;
        }
        public override Center CreateEntity(CenterDto dto)
        {
            var result  = base.CreateEntity(dto);

            if (dto.City.HasValue())
            {
                result.CityId = dto.CityId.ToGuid();
            }

            return result;
        }
    }
}
