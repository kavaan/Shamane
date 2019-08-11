using System;
using System.Collections.Generic;
using System.Text;

namespace Shamane.Domain
{
    public class BaseEntity : IBaseEntity
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid? UpdateBy { get; set; }
    }
}
