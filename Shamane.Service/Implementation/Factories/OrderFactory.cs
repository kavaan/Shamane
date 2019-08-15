using Shamane.Common.Extensions;
using Shamane.Domain;
using Shamane.Service.Definition.Dto;
using Shamane.Service.Definition.Factories;
using Shamane.Service.Implementation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shamane.Service.Implementation.Factories
{
    public class OrderFactory : ModelFactory<Order, OrderDto>, IOrderFactory
    {
        private readonly IUserService userService;
        public OrderFactory(IUserService userService)
        {
            this.userService = userService;
        }
        public override Order CreateEntity(OrderDto dto)
        {
            var result = base.CreateEntity(dto);
            result.DeliveryPrice = null;
            result.Discount = null;
            result.OrderStaus = Domain.Conts.OrderStaus.Null;
            result.RejectReason = null;
            result.Tax = null;
            result.TotalPrice = null;
            result.OrderCode = null;
            if (dto.OrderDetailDtos != null && dto.OrderDetailDtos.Any())
            {
                var details = new List<OrderDetail>();
                foreach (var detial in dto.OrderDetailDtos)
                {
                    var orderDetail = new OrderDetail();
                    orderDetail.Id = Guid.NewGuid();
                    orderDetail.CenterProductId = detial.CenterProductId.ToGuid();
                    orderDetail.Count = detial.Count;
                    orderDetail.CreatedAt = DateTime.Now;
                    orderDetail.CreatedBy = userService.GetUserId().ToGuid();
                    details.Add(orderDetail);
                }
                result.OrderDetails = details;
            }
            result.CenterId = dto.CenterId.ToGuid();
            return result;
        }

        public override OrderDto CreateDto(Order entity)
        {
            var result = base.CreateDto(entity);
            result.CenterId = entity.CenterId.ToString();
            switch (entity.OrderStaus)
            {
                case Domain.Conts.OrderStaus.Null:
                    result.OrderStausString = "فاقد وضعیت";
                    break;
                case Domain.Conts.OrderStaus.NoState:
                    result.OrderStausString = "جدید";
                    break;
                case Domain.Conts.OrderStaus.Accepted:
                    result.OrderStausString = "پدیرفته شده";
                    break;
                case Domain.Conts.OrderStaus.SendToDelivery:
                    result.OrderStausString = "در حال ارسال";
                    break;
                case Domain.Conts.OrderStaus.Rejected:
                    result.OrderStausString = "رد شده";
                    break;
                case Domain.Conts.OrderStaus.Completed:
                    result.OrderStausString = "تمام شده";
                    break;
                default:
                    break;
            }
            switch (entity.OrderDeliverType)
            {
                case Domain.Conts.OrderDeliverType.Null:
                    result.OrderDeliverTypeString = "بدون مقدار";
                    break;
                case Domain.Conts.OrderDeliverType.InCenter:
                    result.OrderDeliverTypeString = "تحویل در محل";
                    break;
                case Domain.Conts.OrderDeliverType.WithDelivery:
                    result.OrderDeliverTypeString = "تحویل با پیک";
                    break;
                default:
                    break;
            }
            if (entity.Center != null)
            {
                result.CenterId = entity.CenterId.ToString();
                result.CenterName = entity.Center.Title;
            }
            if (entity.OrderDetails != null && entity.OrderDetails.Count() > 0)
            {
                var orderDetails = new List<OrderDetailDto>();
                foreach (var orderDetail in entity.OrderDetails)
                {
                    var detail = new OrderDetailDto();
                    detail.Id = orderDetail.Id.ToString();
                    detail.CenterProductId = orderDetail.CenterProductId.ToString();
                    detail.Count = orderDetail.Count;
                    detail.ProductName = orderDetail.CenterProduct.Product.Name;
                    detail.UnitPrice = orderDetail.UnitPrice;
                    detail.ProductId = orderDetail.CenterProduct.ProductId.ToString();
                    orderDetails.Add(detail);
                }
                result.OrderDetailDtos = orderDetails;
            }
            return result;
        }
    }
}
