using System;
using System.Collections.Generic;
using System.Text;
using Shamane.Domain;
using Shamane.Domain.Conts;
using Shamane.Service.Definition.Dto;

namespace Shamane.Service.Definition
{
    public interface ICenterService
    {
        CenterDto Add(CenterDto centerDto);
        CenterDto Update(CenterDto centerDto);
        void Delete(string id);
        IEnumerable<CenterDto> Get(string Title = null, string provinceId = null,
            string cityId = null, CenterType centerType = CenterType.Null,
            DeliveryType deliveryType = DeliveryType.Null,
            CenterOrderBy centerOrderBy = CenterOrderBy.Null,
            int? from = 0, int? count = 20);
        CenterDto Get(Guid id);
    }
}
