using System;
using System.Collections.Generic;
using System.Text;

namespace Shamane.Service.Definition.Dto
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string FullName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Username { get; set; }
        public string Address { get; internal set; }
    }
}
