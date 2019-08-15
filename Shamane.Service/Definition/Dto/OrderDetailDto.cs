using System;
using System.Collections.Generic;
using System.Text;

namespace Shamane.Service.Definition.Dto
{
    public class OrderDetailDto
    {
        public string Id { get; set; }
        public string CenterProductId { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public long UnitPrice { get; set; }
        public int Count { get; set; }

    }
}
