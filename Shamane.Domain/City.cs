using System;
using System.Collections.Generic;
using System.Text;

namespace Shamane.Domain
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public virtual Province Province { get; set; }
        public Guid ProvinceId { get; set; }
        public bool IsActive { get; set; }

    }
}
