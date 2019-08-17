using Shamane.Domain;
using Shamane.Service.Definition.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shamane.Service.Definition
{
    public interface IAddressService
    {
        IEnumerable<ProvinceDto> GetProvinces();
        IEnumerable<ProvinceDto> GetProvincesWithCitites();
        ProvinceDto GetProvince(string id);
        ProvinceDto GetProvinceWithCities(string id);
        IEnumerable<CityDto> GetCities();
        IEnumerable<CityDto> GetCities(string provinceId);
        CityDto GetCity(string id);
        ProvinceDto AddProvince(ProvinceDto provinceDto);
        ProvinceDto UpdateProvince(ProvinceDto provinceDto);
        void DeleteProvince(string id);
        CityDto AddCity(CityDto cityDto);
        CityDto UpdateCity(CityDto cityDto);
        void DeleteCity(string id);
        void ActiveProvince(string id, bool status);
        void ActiveCity(string id, bool status);
        bool IsCityExistsAndActive(string cityId);
    }
}
