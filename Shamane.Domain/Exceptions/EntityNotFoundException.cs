using System;
using System.Collections.Generic;
using System.Text;

namespace Shamane.Domain.Exceptions
{
    public class EntityNotFoundException : ApplicationBaseException
    {
        public string RequestedType { get; protected set; }
        public string EntityId { get; protected set; }
        public EntityNotFoundException(Type reuestedType, string entityId)
        {
            this.EntityId = entityId;
            RequestedType = reuestedType.Name;
        }
    }
}
