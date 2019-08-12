using System;
using System.Collections.Generic;
using System.Text;

namespace Shamane.Service.Definition.Dto
{
    public class ProductDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string ParentId { get; set; }
        public string ParentName { get; set; }
        public string Formula { get; set; }
        public string Description { get; set; }
        public string EspeciallyForCenterId { get; set; }
        public string EspeciallyForCenterName { get; set; }
        public bool IsActive { get; set; }

    }
}
