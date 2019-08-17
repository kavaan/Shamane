using Shamane.Common.Extensions;
using Shamane.DataAccess.UnitOfWorks;
using Shamane.Domain;
using Shamane.Domain.Conts;
using Shamane.Domain.Exceptions;
using Shamane.Service.Authentication.Service;
using Shamane.Service.Definition;
using Shamane.Service.Definition.Dto;
using Shamane.Service.Definition.Factories;
using Shamane.Service.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shamane.Service.Implementation.Services
{
    public class CenterService : ICenterService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ICenterFatory centerFatory;
        private readonly IAddressService addressService;
        private readonly IUserService userService;
        public CenterService(IUnitOfWork unitOfWork, 
            ICenterFatory centerFatory,
            IAddressService addressService,
            IUserService userService)
        {
            this.userService = userService;
            this.addressService = addressService;
            this.unitOfWork = unitOfWork;
            this.centerFatory = centerFatory;
        }

        private void centerValidator(CenterDto centerDto)
        {
            if (centerDto.CenterType == CenterType.Null ||
                !centerDto.CenterType.IsDefined())
            {
                throw new CenterException(CenterExceptionRole.InvalidType);
            }

            if (centerDto.DeliveryType == DeliveryType.Null ||
                !centerDto.DeliveryType.IsDefined())
            {
                throw new CenterException(CenterExceptionRole.InvalidDelivery);
            }

            if (string.IsNullOrEmpty(centerDto.Title) ||
                string.IsNullOrWhiteSpace(centerDto.Title))
            {
                throw new CenterException(CenterExceptionRole.InvalidTitle);
            }

            if (string.IsNullOrEmpty(centerDto.CityId) ||
                !centerDto.CityId.IsValidGuid() ||
                !addressService.IsCityExistsAndActive(centerDto.CityId))
            {
                throw new AddressException(AddressExceptionRole.NotExistsOrDeactived);
            }

            //if (string.IsNullOrEmpty(centerDto.OwnerId) ||
            //    !centerDto.OwnerId.IsValidGuid() ||
            //    !addressService.IsCityExistsAndActive(centerDto.CityId))
            //{
            //    throw new AddressException(AddressExceptionRole.NotExistsOrDeactived);
            //}

        }

        public CenterDto Add(CenterDto centerDto)
        {
            centerValidator(centerDto);
            var center = centerFatory.CreateEntity(centerDto);
            unitOfWork.CenterRepository.Add(center);
            unitOfWork.SaveChanges();
            var province = addressService.GetProvince(center.City.ProvinceId.ToString());
            center.City.Province = new Province()
            {
                Id = province.Id.ToGuid(),
                Name = province.Name
            };
            var addedDto = centerFatory.CreateDto(center);
            return addedDto;
        }

        public void Delete(string id)
        {
            if (!id.IsValidGuid())
            
            unitOfWork.CenterRepository.Remove(id.ToGuid());
            unitOfWork.SaveChanges();
        }

        //public IEnumerable<CenterDto> Get(string name, string cityId, int? from, int? count)
        //{
        //    var centers = unitOfWork.CenterRepository.Get(name, cityId);
        //    var centersDtos = centerFatory.CreateDto(centers);
        //    return centersDtos;
        //}

        public CenterDto Get(string id)
        {
            var model = unitOfWork.CenterRepository.Get(id.ToGuid());
            if (model == null)
                throw new EntityNotFoundException(typeof(CenterDto), id);
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

            if (centers == null || centers.Count() == 0)
                throw new EntityNotFoundException(typeof(CenterDto), "Query");

            var centersDtos = centerFatory.CreateDto(centers);
            return centersDtos;
        }

        public CenterDto Update(CenterDto centerDto)
        {
            centerValidator(centerDto);

            var center = centerFatory.CreateEntity(centerDto);
            unitOfWork.CenterRepository.Update(center);
            unitOfWork.SaveChanges();
            var updatedDto = centerFatory.CreateDto(center);
            return updatedDto;
        }

        public CenterDto Update(string id, CenterDto centerDto)
        {
            if (!id.IsValidGuid())
            {
                throw new EntityNotFoundException(typeof(CenterDto), id);
            }
            var centerForCheck = Get(id);
            //if (centerForCheck.)
            //{

            //}
            throw new NotImplementedException();
        }
    }
}
