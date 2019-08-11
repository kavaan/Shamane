using System;
using System.Collections.Generic;
using System.Text;
using Shamane.Service.Definition.Dto;

namespace Shamane.Service.Definition
{
    public interface ICenterProductService
    {
        void Add(CenterProductDto centerProductDto);
        void Update(CenterProductDto centerProductDto);
        void Delete(string id);
        IEnumerable<CenterDto> Get(string centerId, int? from, int? count);
    }
}
