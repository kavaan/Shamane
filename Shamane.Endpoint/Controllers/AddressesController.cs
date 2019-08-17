using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shamane.Service.Authentication.Service;
using Shamane.Service.Definition;
using Shamane.Service.Definition.Dto;

namespace Shamane.Endpoint.Controllers
{

    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize]
    public class AddressesController : ControllerBase
    {
        private readonly IAddressService addressService;

        public AddressesController(IAddressService addressService)
        {
            this.addressService = addressService;
        }

        [HttpPost("[action]")]
        public IActionResult PostProvince(ProvinceDto province)
        {
            var result = addressService.AddProvince(province);
            return Created("", result);
        }
        [HttpGet("[action]")]
        public IActionResult GetProvinces()
        {
            var provinces = addressService.GetProvinces();
            if (provinces != null && provinces.Count() > 0)
            {
                return Ok(provinces);
            }
            return NotFound();
        }
        [HttpPost("[action]")]
        public IActionResult PostCity(CityDto city)
        {
            var result = addressService.AddCity(city);
            return Created("", result);
        }
        [HttpGet("Cities/{provinceId}")]
        public IActionResult GetCities(string provinceId)
        {
            var cities = addressService.GetCities(provinceId);
            if (cities != null && cities.Count() > 0)
            {
                return Ok(cities);
            }
            return NotFound();
        }
        [HttpGet("Cities")]
        public IActionResult GetCities()
        {
            var cities = addressService.GetCities();
            if (cities != null && cities.Count() > 0)
            {
                return Ok(cities);
            }
            return NotFound();
        }
        [HttpGet("Provinces")]
        public IActionResult GetProvincesWithCities()
        {
            var provinces = addressService.GetProvincesWithCitites();
            if (provinces != null && provinces.Count() > 0)
            {
                return Ok(provinces);
            }
            return NotFound();
        }
        [HttpPut("ActiveProvince/{id}/{status}")]
        public IActionResult ActiveProvince(string id, bool status)
        {
            addressService.ActiveProvince(id, status);
            return NoContent();
        }
        [HttpPut("ActiveCity/{id}/{status}")]
        public IActionResult ActiveCity(string id, bool status)
        {
            addressService.ActiveCity(id, status);
            return NoContent();
        }


    }
}