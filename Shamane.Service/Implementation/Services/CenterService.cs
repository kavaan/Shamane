using Shamane.Common.Extensions;
using Shamane.DataAccess.UnitOfWorks;
using Shamane.Domain;
using Shamane.Domain.Conts;
using Shamane.Service.Definition;
using Shamane.Service.Definition.Dto;
using Shamane.Service.Definition.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shamane.Service.Implementation.Services
{
    public class CenterService : ICenterService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ICenterFatory centerFatory;

        public CenterService(IUnitOfWork unitOfWork, ICenterFatory centerFatory)
        {
            this.unitOfWork = unitOfWork;
            this.centerFatory = centerFatory;
        }
        public CenterDto Add(CenterDto centerDto)
        {
            var center = centerFatory.CreateEntity(centerDto);
            unitOfWork.CenterRepository.Add(center);
            unitOfWork.SaveChanges();
            var addedDto = centerFatory.CreateDto(center);
            return addedDto;
        }

        public void Delete(string id)
        {
            unitOfWork.CenterRepository.Remove(id.ToGuid());
            unitOfWork.SaveChanges();
        }

        //public IEnumerable<CenterDto> Get(string name, string cityId, int? from, int? count)
        //{
        //    var centers = unitOfWork.CenterRepository.Get(name, cityId);
        //    var centersDtos = centerFatory.CreateDto(centers);
        //    return centersDtos;
        //}

        public CenterDto Get(Guid id)
        {
            var model = unitOfWork.CenterRepository.Get(id);
            var dto = centerFatory.CreateDto(model);
            return dto;
        }

        public IEnumerable<CenterDto> Get(string title = null, string provinceId = null,
            string cityId = null, CenterType centerType = CenterType.Null,
            DeliveryType deliveryType = DeliveryType.Null,
            CenterOrderBy centerOrderBy = CenterOrderBy.Null,
            int? from = 0, int? count = 20)
        {
            var centers = unitOfWork.CenterRepository.Get(title,
                provinceId.ToNullableGuid(), cityId.ToNullableGuid(),
                centerType, deliveryType, centerOrderBy,
                from, count);
            var centersDtos = centerFatory.CreateDto(centers);
            return centersDtos;
        }

        public CenterDto Update(CenterDto centerDto)
        {
            throw new NotImplementedException();
        }
    }
}
