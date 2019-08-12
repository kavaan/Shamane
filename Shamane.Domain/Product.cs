using System;
using System.Collections.Generic;
using System.Text;

namespace Shamane.Domain
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public Guid? ParentId { get; set; }
        public virtual Product? Parent { get; set; }
        public string Formula { get; set; }
        public string Description { get; set; }
    }
}
