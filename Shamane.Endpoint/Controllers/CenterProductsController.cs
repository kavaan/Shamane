﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shamane.Service.Authentication.Service;
using Shamane.Service.Definition;
using Shamane.Service.Definition.Dto;

namespace Shamane.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CenterProductsController : ControllerBase
    {
        private readonly ICenterProductService centerProductService;

        public CenterProductsController(ICenterProductService centerProductService)
        {
            this.centerProductService = centerProductService;
        }

        [HttpPost("[action]")]
        public IActionResult Post(CenterProductDto centerProductDto)
        {
            centerProductService.Add(centerProductDto);
            return Created("", centerProductDto);
        }

        [HttpPut("[action]")]
        public IActionResult Put(CenterProductDto centerProductDto)
        {
            centerProductService.Update(centerProductDto);
            return Ok(centerProductDto);
        }

        [HttpDelete("[action]")]
        public IActionResult Delete(string id)
        {
            centerProductService.Delete(id);
            return NotFound();
        }

        [HttpGet("[action]")]
        public IActionResult Get(string centerId, string parentId = null,
            string name = null, int? from = 0, int? count = 20)
        {
            var centerProducts = centerProductService.Get(centerId, parentId, name, from, count);
            if (centerProducts != null && centerProducts.Count() > 0)
            {
                return Ok(centerProducts);
            }
            return NotFound();
        }

        [HttpGet("{centerId}/Trees")]
        public IActionResult Get(string centerId)
        {
            var centerProducts = centerProductService.GetTrees(centerId);
            if (centerProducts != null && centerProducts.ProductTrees.Any())
            {
                return Ok(centerProducts);
            }
            return NotFound();
        }

    }
}