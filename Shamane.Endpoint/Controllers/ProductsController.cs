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

        [HttpPost("{centerId}/SpecialProduct")]
        public IActionResult PostSpecialProduct(string centerId, ProductDto productDto)
        {
            productDto.EspeciallyForCenterId = centerId;
            productService.AddSpcial(productDto);
            return Created("", productDto);
        }

        [HttpPut("[action]")]
        public IActionResult Put(ProductDto productDto)
        {
            productService.Update(productDto);
            return Ok(productDto);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            productService.Delete(id);
            return NoContent();
        }

        [HttpGet("[action]")]
        public IActionResult Get(string name = null,
            int? from = 0, int? count = 20)
        {
            var products = productService.GetParent();
            if (products != null && products.Count() > 0)
            {
                return Ok(products);
            }
            return NotFound();
        }

        [HttpGet("{parentId}/Childs")]
        public IActionResult GetSubMenu(string parentId,string centerId = null, string name = null,
            int? from = 0, int? count = 20)
        {
            var products = productService.GetSubMenu(parentId,centerId);
            if (products != null && products.Count() > 0)
            {
                return Ok(products);
            }
            return NotFound();
        }

        [HttpGet("{centerId}/Special")]
        public IActionResult Get(string centerId, string name = null,
            int? from = 0, int? count = 20)
        {
            var products = productService.GetSpecialParent(centerId);
            if (products != null && products.Count() > 0)
            {
                return Ok(products);
            }
            return NotFound();
        }

        [HttpGet("{centerId}/Special/{parentId}")]
        public IActionResult Get(string centerId, string parentId, string name = null,
                int? from = 0, int? count = 20)
        {
            var products = productService.GetSpecialSubMenu(centerId, parentId);
            if (products != null && products.Count() > 0)
            {
                return Ok(products);
            }
            return NotFound();
        }

    }
}