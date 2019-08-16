using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shamane.Domain;
using Shamane.Domain.Conts;
using Shamane.Service.Definition;
using Shamane.Service.Definition.Dto;

namespace Shamane.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CentersController : ControllerBase
    {
        private readonly ICenterService centerService;
        public CentersController(ICenterService centerService)
        {
            this.centerService = centerService;
        }

        [HttpPost("[action]")]
        public IActionResult Post(CenterDto centerDto)
        {
            var result = centerService.Add(centerDto);
            return Created("", result);
        }

        [HttpPut("[action]")]
        public IActionResult Put(CenterDto centerDto)
        {
            centerService.Update(centerDto);
            return Ok(centerDto);
        }
        [HttpDelete("[action]")]
        public IActionResult Delete(string id)
        {
            centerService.Delete(id);
            return NoContent();
        }
        [HttpGet("[action]")]
        public IActionResult Get(string title = null, string provinceId = null,
            string cityId = null, CenterType centerType = CenterType.Null,
            DeliveryType deliveryType = DeliveryType.Null,
            int? from = 0, int? count = 20,
            CenterOrderBy centerOrderBy = CenterOrderBy.Null)
        {
            var centersDto = centerService.Get(title, provinceId, cityId,
                centerType, deliveryType, centerOrderBy, from, count);
            if (centersDto != null && centersDto.Count() > 0)
            {
                return Ok(centersDto);
            }
            return NotFound();
        }
    }
}