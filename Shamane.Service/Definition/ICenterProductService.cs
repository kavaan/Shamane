using System;
using System.Collections.Generic;
using System.Text;
using Shamane.Service.Definition.Dto;

namespace Shamane.Service.Definition
{
    public interface ICenterProductService
    {
        CenterProductDto Add(CenterProductDto centerProductDto);
        CenterProductDto Update(CenterProductDto centerProductDto);
        void Delete(string id);
        IEnumerable<CenterProductDto> Get(string centerId, string parentId = null,
                   string name = null, int? from = 0, int? count = 20);
        CenterProductTreeDto GetTrees(string centerId);
        Dictionary<Guid, long> GetPrice(IEnumerable<Guid> centerProductIds);
    }
}