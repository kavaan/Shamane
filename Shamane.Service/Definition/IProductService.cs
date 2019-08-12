using System;
using System.Collections.Generic;
using System.Text;
using Shamane.Service.Definition.Dto;

namespace Shamane.Service.Definition
{
    public interface IProductService
    {
        ProductDto Add(ProductDto productDto);
        ProductDto Update(ProductDto productDto);
        void Delete(string id);
        void Active(string id, bool status);
        IEnumerable<ProductDto> SearchMenu(string name = null, string centerId = null,
            bool isParent = true, int? from = 0, int? count = 20);
        ProductDto AddSpcial(ProductDto productDto);
        ProductDto Get(string id);
        IEnumerable<ProductDto> GetParent(string centerId = null, string name = null,
            int? from = 0, int? count = 20);
        IEnumerable<ProductDto> GetSubMenu(string parentId, string centerId = null,
            string name = null, int? from = 0, int? count = 20);
        IEnumerable<ProductDto> GetSpecialParent(string centerId , string name = null,
            int? from = 0, int? count = 20);
        IEnumerable<ProductDto> GetSpecialSubMenu(string parentId, string centerId = null,
            string name = null, int? from = 0, int? count = 20);

    }
}
