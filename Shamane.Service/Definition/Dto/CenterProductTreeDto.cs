using System;
using System.Collections.Generic;
using System.Text;

namespace Shamane.Service.Definition.Dto
{
    public class CenterProductTreeDto
    {
        public string CenterId { get; set; }
        public string CenterName { get; set; }
        public List<CenterProductTreeDetial> ProductTrees { get; set; }
    }
    public class CenterProductTreeDetial
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<CenterProductDto> Products { get; set; }
    }
}
