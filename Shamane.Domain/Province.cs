using System;
using System.Collections.Generic;
using System.Text;

namespace Shamane.Domain
{
    public class Province : BaseEntity
    {
        public string Name { get; set; }
        public virtual IEnumerable<City> Cities { get; set; }
        public bool IsActive { get; set; }

    }
}
