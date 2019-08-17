using Shamane.Common.Extensions;
using Shamane.DataAccess.UnitOfWorks;
using Shamane.Service.Definition;
using Shamane.Service.Definition.Dto;
using Shamane.Service.Definition.Factories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shamane.Service.Implementation.Services
{
    public class CenterProductService : ICenterProductService
    {
        private readonly ICenterProductFactory centerProductFactory;
        private readonly IUnitOfWork unitOfWork;
        private readonly ICenterService centerService;
        public CenterProductService(IUnitOfWork unitOfWork,
            ICenterProductFactory centerProductFactory,
            ICenterService centerService)
        {
            this.centerProductFactory = centerProductFactory;
            this.unitOfWork = unitOfWork;
            this.centerService = centerService;
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

        public IEnumerable<CenterProductDto> Get(string centerId, string parentId = null,
            string name = null, int? from = 0, int? count = 20)
        {
            Guid? parentGuid = null;
            if (parentId.IsValidGuid())
            {
                parentGuid = parentId.ToGuid();
            }
            var entities = unitOfWork.CenterProductRepository.Get(centerId.ToGuid(),
               parentGuid, name, from, count);
            var dtos = centerProductFactory.CreateDto(entities);

            return dtos;
        }

        public Dictionary<Guid,long> GetPrice(IEnumerable<Guid> centerProductIds)
        {
            var result = unitOfWork.CenterProductRepository.GetPrice(centerProductIds);
            return result;
        }

        public CenterProductTreeDto GetTrees(string centerId)
        {
            var centerDto = centerService.Get(centerId);
            var result = new CenterProductTreeDto()
            {
                CenterId = centerId,
                CenterName = centerDto.Title,
                ProductTrees = new List<CenterProductTreeDetial>()
            };
            var products = unitOfWork.
                CenterProductRepository.GetTrees(centerId.ToGuid());
            var parents = products.Where(x => x.Product.ParentId == null);
            foreach (var item in parents)
            {
                var cp = products.Where(x => x.Product.ParentId == item.ProductId);
                result.ProductTrees.Add(new CenterProductTreeDetial()
                {
                    Id = item.Id.ToString(),
                    Name = item.Product.Name,
                    Products = cp.Select(x => new CenterProductDto()
                    {
                        Id = x.Id.ToString(),
                        CenterId = x.CenterId.ToString(),
                        CenterTitle = centerDto.Title,
                        Description = x.Description,
                        Image = x.Image,
                        IsParent = false,
                        Price = x.Price,
                        ProductId = x.ProductId.ToString(),
                        ProductName = x.Product.Name
                    })
                });
            }
            return result;
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
