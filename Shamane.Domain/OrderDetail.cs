using System;
using System.Collections.Generic;
using System.Text;

namespace Shamane.Domain
{
    public class OrderDetail : BaseEntity
    {
        public Guid CenterProductId { get; set; }
        public virtual CenterProduct CenterProduct { get; set; }
        public int Count { get; set; }
        public long UnitPrice { get; set; }

    }
}
