using System;
using System.Collections.Generic;
using System.Text;

namespace Shamane.Service.Authentication.Dtos
{
    public class ProfileUpdateDto
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string Mobile { get; set; }
        public string Username { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Address { get; set; }
        public string CityId { get; set; }
        public string Image { get; set; }
    }
}
