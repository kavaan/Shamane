using Shamane.DataAccess.MSSQL.Repositories;
using Shamane.Domain;
using Shamane.Service.Definition.Dto;
using Shamane.Service.Definition.Factories;
using Shamane.Service.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shamane.Service.Implementation.Factories
{
    public class ProductFactory : ModelFactory<Product, ProductDto>, IProductFactory
    {
        public override Product CreateEntity(ProductDto dto)
        {
            var result = base.CreateEntity(dto);
            if (dto.ParentId.IsValidGuid())
            {
                result.ParentId = dto.ParentId.ToGuid();
            }
            if (dto.EspeciallyForCenterId.IsValidGuid())
            {
                result.EspeciallyForCenterId = dto.EspeciallyForCenterId.ToGuid();
            }
            return result;
        }
        public override ProductDto CreateDto(Product entity)
        {
            var result = base.CreateDto(entity);
            if (entity.EspeciallyForCenter != null)
            {
                result.EspeciallyForCenterId = entity.EspeciallyForCenterId.ToString();
                result.EspeciallyForCenterName = entity.EspeciallyForCenter.Title;
            }
            if (entity.Parent != null)
            {
                result.ParentId = entity.ParentId.ToString();
                result.ParentName = entity.Parent.Name;
            }

            return result;
        }
    }
}
