using Shamane.Common.Extensions;
using Shamane.DataAccess.UnitOfWorks;
using Shamane.Domain.Conts;
using Shamane.Service.Authentication.Service;
using Shamane.Service.Definition;
using Shamane.Service.Definition.Dto;
using Shamane.Service.Definition.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shamane.Service.Implementation.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderFactory orderFactory;
        private readonly IUnitOfWork unitOfWork;
        private readonly ICenterProductService centerProductService;
        private readonly IUserService userService;

        public OrderService(IOrderFactory orderFactory,
            IUnitOfWork unitOfWork,
            ICenterProductService centerProductService,
            IUserService userService)
        {
            this.userService = userService;
            this.centerProductService = centerProductService;
            this.unitOfWork = unitOfWork;
            this.orderFactory = orderFactory;
        }

        public void Accept(string id)
        {
            var order = unitOfWork.OrderRepository.Get(id.ToGuid());
            order.AcceptedBy = userService.GetCurrentUserId().ToGuid();
            order.AcceptedDateTime = DateTime.Now;
            order.OrderStaus = OrderStaus.Accepted;
            unitOfWork.OrderRepository.Update(order);
            unitOfWork.SaveChanges();
        }

        public OrderDto Add(OrderDto orderDto)
        {
            orderDto.RegisterdAt = DateTime.Now;
            var orderEntity = orderFactory.CreateEntity(orderDto);
            var orderDetailsPrice = centerProductService.GetPrice(
                orderEntity.OrderDetails.Select(x => x.CenterProductId));
            long totlaPrice = 0;
            foreach (var orderDetail in orderEntity.OrderDetails)
            {
                var unitPrice = orderDetailsPrice
                    .FirstOrDefault(x => x.Key == orderDetail.CenterProductId).Value;
                totlaPrice += (orderDetail.Count) * unitPrice;
                orderDetail.UnitPrice = unitPrice;
            }
            orderEntity.RegisterdBy = userService.GetCurrentUserId().ToGuid();
            orderEntity.TotalPrice = totlaPrice;
            orderEntity.OrderStaus = OrderStaus.NoState;
            if (orderEntity.TargetAddressIsUserProfileAddress)
            {
                orderEntity.Address = userService.Get(userService.GetCurrentUserId()).Address;
            }
            unitOfWork.OrderRepository.Add(orderEntity);
            unitOfWork.SaveChanges();
            var addedDto = orderFactory.CreateDto(orderEntity);
            return addedDto;
        }

        public void Complete(string id)
        {
            var order = unitOfWork.OrderRepository.Get(id.ToGuid());
            order.CompletedBy = userService.GetCurrentUserId().ToGuid();
            order.CompletedDateTime = DateTime.Now;
            order.OrderStaus = OrderStaus.Completed;
            unitOfWork.OrderRepository.Update(order);
            unitOfWork.SaveChanges();
        }

        public IEnumerable<OrderDto> Get(string centerId, string id = null,
            string orderCode = null, OrderStaus orderStaus = OrderStaus.Null,
            DateTime? fromDate = null, DateTime? toDate = null,
            int? from = 0, int? count = 20)
        {
            var entities = unitOfWork.OrderRepository.Get(false, centerId.ToGuid(),
                id.ToNullableGuid(), orderCode, orderStaus,
                fromDate, toDate, from, count);
            var dtos = orderFactory.CreateDto(entities);
            return dtos;
        }

        public IEnumerable<OrderDto> GetFullInfo(string centerId, string id = null,
            string orderCode = null, OrderStaus orderStaus = OrderStaus.Null,
            DateTime? fromDate = null, DateTime? toDate = null,
            int? from = 0, int? count = 20)
        {
            var entities = unitOfWork.OrderRepository.Get(true, centerId.ToGuid(),
                id.ToNullableGuid(),
                orderCode, orderStaus, fromDate, toDate, from, count);
            var dtos = orderFactory.CreateDto(entities);
            return dtos;
        }

        public OrderDto GetStatus(string id)
        {
            var order = unitOfWork.OrderRepository.Get(id.ToGuid());
            var dto = orderFactory.CreateDto(order);
            return dto;
        }

        public OrderDto GetStatusByCode(string code)
        {
            var order = unitOfWork.OrderRepository.GetByCode(code);
            var dto = orderFactory.CreateDto(order);
            return dto;
        }

        public OrderDto GetFullInfo(string id)
        {
            throw new NotImplementedException();
        }

        public OrderDto GetFullInfoByCode(string code)
        {
            throw new NotImplementedException();

        }

        public IEnumerable<OrderDto> GetTodayOrders(string centerId, string id = null,
            string orderCode = null, OrderStaus orderStaus = OrderStaus.Null,
            int? from = 0, int? count = 20)
        {
            var fromTimeSpan = new TimeSpan(0, 1, 1);
            var toTimeSpan = new TimeSpan(23, 59, 59);
            var fromDate = DateTime.Now + fromTimeSpan;
            var toDate = DateTime.Now + toTimeSpan;
            var result = Get(centerId, id, orderCode, orderStaus,
                fromDate, toDate, from, count);
            return result;
        }

        public void Reject(string id, string rejectResoan)
        {
            var order = unitOfWork.OrderRepository.Get(id.ToGuid());
            order.RegisterdBy = userService.GetCurrentUserId().ToGuid();
            order.RejectedDateTime = DateTime.Now;
            order.OrderStaus = OrderStaus.Rejected;
            order.RejectReason = rejectResoan;
            unitOfWork.OrderRepository.Update(order);
            unitOfWork.SaveChanges();
        }

        public void SendToDelivery(string id)
        {
            var order = unitOfWork.OrderRepository.Get(id.ToGuid());
            order.SendToDeliveryBy = userService.GetCurrentUserId().ToGuid();
            order.SendToDelivertDateTime = DateTime.Now;
            order.OrderStaus = OrderStaus.SendToDelivery;
            unitOfWork.OrderRepository.Update(order);
            unitOfWork.SaveChanges();
        }

        public IEnumerable<OrderDetailDto> GetOrderDetails(string id)
        {
            var centerId = Guid.Empty;
            var entities = unitOfWork.OrderRepository.Get(true, centerId,
                id.ToGuid(), null, OrderStaus.Null,
                null, null, 0, 1);
            var dtos = orderFactory.CreateDto(entities).FirstOrDefault();
            return dtos.OrderDetailDtos;
        }
    }
}
