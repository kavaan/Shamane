using Shamane.Domain;
using Shamane.Service.Definition.Dto;
using Shamane.Service.Definition.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shamane.Service.Implementation.Factories
{
    public class CityFactory : ModelFactory<City, CityDto>, ICityFactory
    {
        public override City CreateEntity(CityDto dto)
        {
            var result = base.CreateEntity(dto);
            if (!string.IsNullOrEmpty(dto.ProvinceId) &&
                Guid.TryParse(dto.ProvinceId, out var provinceId))
            {
                result.ProvinceId = provinceId;
            }

            return result;
        }
        public override CityDto CreateDto(City entity)
        {
            var result = base.CreateDto(entity);

            if (entity.Province != null)
            {
                result.ProvinceName = entity.Province.Name;
                result.ProvinceId = entity.ProvinceId.ToString();
            }

            return result;
        }
    }
}
