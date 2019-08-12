using Shamane.DataAccess.UnitOfWorks;
using Shamane.Service.Definition;
using Shamane.Service.Definition.Dto;
using Shamane.Service.Definition.Factories;
using Shamane.Service.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shamane.Service.Implementation.Services
{
    public class CenterProductService : ICenterProductService
    {
        private readonly ICenterProductFactory centerProductFactory;
        private readonly IUnitOfWork unitOfWork;
        public CenterProductService(IUnitOfWork unitOfWork,
            ICenterProductFactory centerProductFactory)
        {
            this.centerProductFactory = centerProductFactory;
            this.unitOfWork = unitOfWork;
        }
        public CenterProductDto Add(CenterProductDto centerProductDto)
        {
            var entity = centerProductFactory.CreateEntity(centerProductDto);
            unitOfWork.CenterProductRepository.Add(entity);
            unitOfWork.SaveChanges();
            var addedDto = centerProductFactory.CreateDto(entity);
            return addedDto;
        }

        public void Delete(string id)
        {
            unitOfWork.CenterProductRepository.Remove(id.ToGuid());
            unitOfWork.SaveChanges();
        }

        public IEnumerable<CenterProductDto> Get(string centerId, bool isParent = true,
            string name = null, int? from = 0, int? count = 20)
        {
            var entities = unitOfWork.CenterProductRepository.Get(centerId,
                isParent, name, from, count);
            var dtos = centerProductFactory.CreateDto(entities);

            return dtos;
        }

        public CenterProductDto Update(CenterProductDto centerProductDto)
        {
            var entity = centerProductFactory.CreateEntity(centerProductDto);
            unitOfWork.CenterProductRepository.Update(entity);
            unitOfWork.SaveChanges();
            var dto = centerProductFactory.CreateDto(entity);
            return dto;
        }
    }
}
