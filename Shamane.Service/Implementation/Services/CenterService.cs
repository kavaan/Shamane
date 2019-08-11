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

        public IEnumerable<CenterDto> Get(string name, string cityId, int? from, int? count)
        {
            var centers = unitOfWork.CenterRepository.Get();
            var centersDtos = centerFatory.CreateDto(centers);
            return centersDtos;
        }

        public CenterDto Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public CenterDto Update(CenterDto centerDto)
        {
            throw new NotImplementedException();
        }
    }
}
