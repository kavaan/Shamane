using System;
using System.Collections.Generic;
using System.Text;

namespace Shamane.Service.Definition.Dto
{
    public class ProvinceDto
    {
        public string Id { get; set; } = null;
        public string Name { get; set; }
        public IEnumerable<CityDto> Cities { get; set; }
        public bool IsActive { get; set; }
    }
}
