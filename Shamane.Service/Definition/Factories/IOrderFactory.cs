using Shamane.Domain;
using Shamane.Service.Definition.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shamane.Service.Definition.Factories
{
    public interface IOrderFactory : IModelFactory<Order, OrderDto>
    {
    }
}
