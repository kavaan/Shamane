using System;
using System.Collections.Generic;
using System.Text;

namespace Shamane.Service.Definition.Dto
{
    public class UserRegisterDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string CityId { get; set; }
        public string IntroCode { get; set; }
        public string Image { get; set; }
        public string Password { get; set; }

    }
}
