using Shamane.Common.Extensions;
using Shamane.DataAccess.UnitOfWorks;
using Shamane.Service.Definition;
using Shamane.Service.Definition.Dto;
using Shamane.Service.Definition.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shamane.Service.Implementation.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IProductFactory productFactory;

        public ProductService(IUnitOfWork unitOfWork, IProductFactory productFactory)
        {
            this.unitOfWork = unitOfWork;
            this.productFactory = productFactory;
        }

        public void Active(string id, bool status)
        {
            var product = unitOfWork.ProductRepository.Get(id.ToGuid());
            product.IsActive = status;
            unitOfWork.SaveChanges();
        }

        public ProductDto Add(ProductDto productDto)
        {
            var product = productFactory.CreateEntity(productDto);
            unitOfWork.ProductRepository.Add(product);
            unitOfWork.SaveChanges();
            var addedDto = productFactory.CreateDto(product);
            return addedDto;
        }

        public ProductDto AddSpcial(ProductDto productDto)
        {
            return Add(productDto);
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public ProductDto Get(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductDto> GetParent(string centerId = null, 
            string name = null, int? from = 0, int? count = 20)
        {
            Guid? id = null;
            if (centerId.IsValidGuid())
            {
                id = centerId.ToGuid();
            }
            var products = unitOfWork.ProductRepository.GetParents(id);
            var dtos = productFactory.CreateDto(products);
            return dtos;
        }

        public IEnumerable<ProductDto> GetSpecialParent(string centerId, 
            string name = null, int? from = 0, int? count = 20)
        {
            var products = unitOfWork.ProductRepository.GetParents(centerId.ToGuid());
            var dtos = productFactory.CreateDto(products);
            return dtos;
        }

        public IEnumerable<ProductDto> GetSpecialSubMenu(string parentId, string centerId , 
            string name = null, int? from = 0, int? count = 20)
        {
            var products = unitOfWork.ProductRepository.GetSubMenus(parentId.ToGuid(), centerId.ToGuid());
            var dtos = productFactory.CreateDto(products);
            return dtos;
        }

        public IEnumerable<ProductDto> GetSubMenu(string parentId, string centerId = null, 
            string name = null, int? from = 0, int? count = 20)
        {
            Guid? centerGuid = null;
            if (centerId.IsValidGuid())
            {
                centerGuid = centerId.ToGuid();
            }
            var products = unitOfWork.ProductRepository.GetSubMenus(parentId.ToGuid(),centerGuid);
            var dtos = productFactory.CreateDto(products);
            return dtos;
        }

        public IEnumerable<ProductDto> SearchMenu(string name = null, string centerId = null, bool isParent = true, int? from = 0, int? count = 20)
        {
            throw new NotImplementedException();
        }

        //public IEnumerable<ProductDto> GetParent(string centerId = null,
        //    int? from = 0, int? count = 20)
        //{
        //    Guid? id = null;
        //    if (centerId.IsValidGuid())
        //    {
        //        id = centerId.ToGuid();
        //    }
        //    var products = unitOfWork.ProductRepository.GetParents(id);
        //    var dtos = productFactory.CreateDto(products);
        //    return dtos;
        //}

        //public IEnumerable<ProductDto> GetSubMenu(string parentId, int? from = 0, int? count = 20, string CenterId = null)
        //{
        //    var products = unitOfWork.ProductRepository.GetSubMenus(parentId.ToGuid());
        //    var dtos = productFactory.CreateDto(products);
        //    return dtos;
        //}

        //public IEnumerable<ProductDto> GetSubMenu(string centerId, string parentId)
        //{
        //    var products = unitOfWork.ProductRepository.GetSubMenus(centerId.ToGuid(),parentId.ToGuid());
        //    var dtos = productFactory.CreateDto(products);
        //    return dtos;
        //}

        //public IEnumerable<ProductDto> SearchMenu(string name = null, string centerId = null, bool isParent = true, int? from = 0, int? count = 20)
        //{
        //    throw new NotImplementedException();
        //}

        public ProductDto Update(ProductDto productDto)
        {
            var product = productFactory.CreateEntity(productDto);
            unitOfWork.ProductRepository.Update(product);
            unitOfWork.SaveChanges();
            return productDto;
        }
    }
}
