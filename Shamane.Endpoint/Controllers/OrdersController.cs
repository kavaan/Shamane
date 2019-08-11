using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shamane.Service.Definition;
using Shamane.Service.Definition.Conts;
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

        [HttpPost("Accept")]
        public IActionResult Accept(string id)
        {
            orderService.Accept(id);
            return Ok();
        }

        [HttpPost("Reject")]
        public IActionResult Reject(string id)
        {
            orderService.Reject(id);
            return Ok();
        }

        [HttpPost("Finish")]
        public IActionResult Finish(string id)
        {
            orderService.Finish(id);
            return Ok();
        }

        [HttpGet("Status")]
        public IActionResult Status(string id)
        {
            var orderStatus = orderService.GetStatus(id);
            return Ok(orderStatus);
        }
        [HttpGet("[action]")]
        public IActionResult Get(string centerId, OrderStaus orderStaus = OrderStaus.Null,
            DateTime? fromDate = null, DateTime? toDate = null,
            int? from = 0, int? count = 20)
        {
            var orders = orderService.Get(centerId, orderStaus, fromDate, toDate, from, count);
            if (orders != null && orders.Count() > 0)
            {
                return Ok(orders);
            }
            return NotFound();
        }
    }
}