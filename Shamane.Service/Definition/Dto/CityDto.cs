using System;
using System.Collections.Generic;
using System.Text;

namespace Shamane.Service.Definition.Dto
{
    public class CityDto
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string ProvinceName { get; set; }
        public string ProvinceId { get; set; }
        public bool IsActive { get; set; }

    }
}
