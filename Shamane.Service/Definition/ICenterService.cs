using System;
using System.Collections.Generic;
using System.Text;
using Shamane.Service.Definition.Dto;

namespace Shamane.Service.Definition
{
    public interface ICenterService
    {
        CenterDto Add(CenterDto centerDto);
        CenterDto Update(CenterDto centerDto);
        void Delete(string id);
        IEnumerable<CenterDto> Get(string name, string cityId, int? from, int? count);
        CenterDto Get(Guid id);
    }
}
