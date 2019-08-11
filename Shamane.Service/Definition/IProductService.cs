using System;
using System.Collections.Generic;
using System.Text;
using Shamane.Service.Definition.Dto;

namespace Shamane.Service.Definition
{
    public interface IProductService
    {
        void Add(ProductDto productDto);
        void Update(ProductDto productDto);
        void Delete(string id);
        IEnumerable<ProductDto> Get(string name, long? price, int? from, int? count);
    }
}
