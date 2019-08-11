using Shamane.Domain;
using Shamane.Service.Definition.Dto;
using Shamane.Service.Definition.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shamane.Service.Implementation.Factories
{
    public class ProvinceFactory : ModelFactory<Province, ProvinceDto>, IProvinceFactory
    {
        private readonly ICityFactory cityFactory;
        public ProvinceFactory(ICityFactory cityFactory)
        {
            this.cityFactory = cityFactory;
        }
        public override ProvinceDto CreateDto(Province entity)
        {
            var result = base.CreateDto(entity);
            if (entity.Cities != null && entity.Cities.Count() > 0)
            {
                result.Cities = cityFactory.CreateDto(entity.Cities);
            }
            return result;
        }
    }
}
