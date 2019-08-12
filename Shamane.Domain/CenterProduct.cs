using System;
using System.Collections.Generic;
using System.Text;

namespace Shamane.Domain
{
    public class CenterProduct : BaseEntity
    {
        public Guid CenterId { get; set; }
        public virtual Center Center { get; set; }
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
        public string Image { get; set; }
        public long Price { get; set; }
        public string Description { get; set; }

    }
}
