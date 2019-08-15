using Shamane.Common.Extensions;
using Shamane.DataAccess.UnitOfWorks;
using Shamane.Service.Definition;
using Shamane.Service.Definition.Dto;
using Shamane.Service.Definition.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shamane.Service.Implementation.Services
{
    public class AddressService : IAddressService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IProvinceFactory provinceFactory;
        private readonly ICityFactory cityFactory;
        public AddressService(IUnitOfWork unitOfWork, ICityFactory cityFactory,
            IProvinceFactory provinceFactory)
        {
            this.unitOfWork = unitOfWork;
            this.provinceFactory = provinceFactory;
            this.cityFactory = cityFactory;
        }

        public void ActiveCity(string id, bool status)
        {
            var city = unitOfWork.CityRepository.Get(id.ToGuid());
            city.IsActive = status;
            unitOfWork.SaveChanges();
        }

        public void ActiveProvince(string id, bool status)
        {
            var province = unitOfWork.ProvinceRepository.Get(id.ToGuid());
            province.IsActive = status;
            unitOfWork.SaveChanges();
        }

        public CityDto AddCity(CityDto cityDto)
        {
            var city = cityFactory.CreateEntity(cityDto);
            city.IsActive = true;
            unitOfWork.CityRepository.Add(city);
            unitOfWork.SaveChanges();
            var addedDto = cityFactory.CreateDto(city);
            return addedDto;
        }

        public ProvinceDto AddProvince(ProvinceDto provinceDto)
        {
            var entity = provinceFactory.CreateEntity(provinceDto);
            entity.IsActive = true;
            unitOfWork.ProvinceRepository.Add(entity);
            unitOfWork.SaveChanges();
            var addedDto = provinceFactory.CreateDto(entity);
            return addedDto;
        }

        public void DeleteCity(string id)
        {
            throw new NotImplementedException();
        }

        public void DeleteProvince(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CityDto> GetCities()
        {
            var cities = unitOfWork.CityRepository.GetCities();
            var dtos = cityFactory.CreateDto(cities);
            return dtos;
        }

        public IEnumerable<CityDto> GetCities(string provinceId)
        {
            var cities = unitOfWork.CityRepository.GetCities(provinceId.ToGuid());
            var dtos = cityFactory.CreateDto(cities);
            return dtos;
        }

        public CityDto GetCity(string id)
        {
            var city = unitOfWork.CityRepository.Get(id.ToGuid());
            var dto = cityFactory.CreateDto(city);
            return dto;
        }

        public ProvinceDto GetProvince(string id)
        {
            var province = unitOfWork.ProvinceRepository.Get(id.ToGuid());
            var dto = provinceFactory.CreateDto(province);
            return dto;
        }

        public IEnumerable<ProvinceDto> GetProvinces()
        {
            var entities = unitOfWork.ProvinceRepository.Get();
            var dtos = provinceFactory.CreateDto(entities);
            return dtos;
        }

        public IEnumerable<ProvinceDto> GetProvincesWithCitites()
        {
            var entities = unitOfWork.ProvinceRepository.GetWithCities();
            var dtos = provinceFactory.CreateDto(entities);
            return dtos;
        }

        public ProvinceDto GetProvinceWithCities(string id)
        {
            throw new NotImplementedException();
        }

        public CityDto UpdateCity(CityDto cityDto)
        {
            throw new NotImplementedException();
        }

        public ProvinceDto UpdateProvince(ProvinceDto provinceDto)
        {
            throw new NotImplementedException();
        }
    }
}
