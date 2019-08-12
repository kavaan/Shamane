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
    public class ProductService :IProductService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IProductFactory productFactory;

        public ProductService(IUnitOfWork unitOfWork, IProductFactory productFactory)
        {
            this.unitOfWork = unitOfWork;
            this.productFactory = productFactory;
        }
        public ProductDto Add(ProductDto productDto)
        {
            var product = productFactory.CreateEntity(productDto);
            unitOfWork.ProductRepository.Add(product);
            unitOfWork.SaveChanges();
            var addedDto = productFactory.CreateDto(product);
            return addedDto;
        }

        public void Delete(string id)
        {
            unitOfWork.ProductRepository.Remove(id.ToGuid());
            unitOfWork.SaveChanges();
        }

        public IEnumerable<ProductDto> Get(string name, string cityId, int? from, int? count)
        {
            var centers = unitOfWork.CenterRepository.Get();
            var centersDtos = centerFatory.CreateDto(centers);
            return centersDtos;
        }

        public ProductDto Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public ProductDto Update(ProductDto centerDto)
        {
            throw new NotImplementedException();
        }

    }
}
