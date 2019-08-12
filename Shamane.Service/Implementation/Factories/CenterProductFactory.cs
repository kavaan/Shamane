using Shamane.Domain;
using Shamane.Service.Definition.Dto;
using Shamane.Service.Definition.Factories;
using Shamane.Service.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shamane.Service.Implementation.Factories
{
    public class CenterProductFactory : ModelFactory<CenterProduct, CenterProductDto>, ICenterProductFactory
    {
        public override CenterProduct CreateEntity(CenterProductDto dto)
        {
            var result = base.CreateEntity(dto);

            if (dto.CenterId.IsValidGuid())
            {
                result.CenterId = dto.CenterId.ToGuid();
            }
            if (dto.ProductId.HasValue())
            {
                result.ProductId = dto.ProductId.ToGuid();
            }
            return result;
        }
        public override CenterProductDto CreateDto(CenterProduct entity)
        {
            var result = base.CreateDto(entity);

            if (entity.Center != null)
            {
                result.CenterId = entity.CenterId.ToString();
                result.CenterTitle = entity.Center.Title;
            }

            if (entity.Product != null)
            {
                result.ProductId = entity.ProductId.ToString();
                result.ProductName = entity.Product.Name;
                result.IsParent = !entity.Product.ParentId.HasValue;
                if (string.IsNullOrEmpty(entity.Image))
                {
                    result.Image = entity.Product.Image;
                }
            }

            return result;
        }
    }
}
