using Shamane.DataAccess.MSSQL.Repositories;
using Shamane.Domain;
using Shamane.Service.Definition.Dto;
using Shamane.Service.Definition.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shamane.Service.Implementation.Factories
{
    public class ProductFactory : ModelFactory<Product, ProductDto>, IProductFactory
    {
    }
}
