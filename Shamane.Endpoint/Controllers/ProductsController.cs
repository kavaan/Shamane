using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shamane.Service.Definition;
using Shamane.Service.Definition.Dto;

namespace Shamane.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;
        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpPost("[action]")]
        public IActionResult Post(ProductDto productDto)
        {
            productService.Add(productDto);
            return Created("", productDto);
        }
        [HttpPut("[action]")]
        public IActionResult Put(ProductDto productDto)
        {
            productService.Update(productDto);
            return Ok(productDto);
        }

        [HttpDelete("[action]")]
        public IActionResult Delete(string id)
        {
            productService.Delete(id);
            return NoContent();
        }
        [HttpGet("[action]")]
        public IActionResult Get(string name = null, long? price = null,
            int? from = 0, int? count = 20)
        {
            var products = productService.Get(name, price, from, count);
            if (products == null && products.Count() > 0)
            {
                return Ok(products);
            }
            return NotFound();
        }
    }
}