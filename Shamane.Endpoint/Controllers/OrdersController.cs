using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shamane.Domain.Conts;
using Shamane.Service.Definition;
using Shamane.Service.Definition.Dto;

namespace Shamane.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrdersController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpPost("[action]")]
        public IActionResult Post(OrderDto order)
        {
            orderService.Add(order);
            return Created("", order);
        }

        [HttpPost("{id}/Accept")]
        public IActionResult Accept(string id)
        {
            orderService.Accept(id);
            return Ok();
        }

        [HttpPost("{id}/Reject")]
        public IActionResult Reject(string id, string reason)
        {
            orderService.Reject(id, reason);
            return Ok();
        }

        [HttpPost("{id}/SendToDelivery")]
        public IActionResult SendToDelivery(string id)
        {
            orderService.SendToDelivery(id);
            return Ok();
        }

        [HttpPost("{id}/Complete")]
        public IActionResult Complete(string id)
        {
            orderService.Complete(id);
            return Ok();
        }

        [HttpGet("{code}/Status")]
        public IActionResult StatusByCode(string code)
        {
            var orderStatus = orderService.GetStatusByCode(code);
            return Ok(orderStatus);
        }

        [HttpGet("{id}/Info")]
        public IActionResult StatusById(string id)
        {
            var orderStatus = orderService.GetStatus(id);
            return Ok(orderStatus);
        }

        [HttpGet("/api/{centerId}/[controller]")]
        public IActionResult Get(string centerId, string orderCode = null,
            OrderStaus orderStaus = OrderStaus.Null,
            DateTime? fromDate = null, DateTime? toDate = null,
            int? from = 0, int? count = 20)
        {
            var orders = orderService.Get(centerId, null, orderCode, orderStaus,
                fromDate, toDate, from, count);
            if (orders != null && orders.Count() > 0)
            {
                return Ok(orders);
            }
            return NotFound();
        }

        [HttpGet("{id}/Details")]
        public IActionResult GetDetails(string id)
        {
            var orders = orderService.GetOrderDetails(id);
            if (orders != null && orders.Count() > 0)
            {
                return Ok(orders);
            }
            return NotFound();
        }
    }
}