using System;
using System.Collections.Generic;
using System.Text;

namespace Shamane.Service.Authentication.Dtos
{
    public class ProfileDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string FullName { get; set; }
        public string Mobile { get; set; }
        public string Username { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Address { get; set; }
        public string CityName { get; set; }
        public string CityId { get; set; }
        public string ProvinceName { get; set; }
        public string ProvinceId { get; set; }
    }
}
