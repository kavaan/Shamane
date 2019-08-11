using System;
using System.Collections.Generic;
using System.Text;

namespace Shamane.Domain
{
    public interface IBaseEntity
    {
        Guid Id { get; set; }
        bool IsDeleted { get; set; }
        DateTime CreatedAt { get; set; }
        DateTime? UpdatedAt { get; set; }
        Guid CreatedBy { get; set; }
        Guid? UpdateBy { get; set; }
    }

}
