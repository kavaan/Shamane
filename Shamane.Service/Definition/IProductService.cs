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
        ProductDto Get(string id);
        IEnumerable<ProductDto> GetSubMenu(string parentId, int? from, int? count);
        IEnumerable<ProductDto> GetParent(int? from, int? count);
        IEnumerable<ProductDto> SearchSubMenu(string name, int? from, int? count);
    }
}
