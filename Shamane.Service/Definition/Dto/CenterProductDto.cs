using System;
using System.Collections.Generic;
using System.Text;

namespace Shamane.Service.Definition.Dto
{
    public class CenterProductDto
    {
        public string Id { get; set; }
        public string CenterId { get; set; }
        public string CenterTitle { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public bool IsParent { get; set; }
        public string Image { get; set; }
        public long Price { get; set; }
        public string Description { get; set; }
    }
}
