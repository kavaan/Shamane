using System;
using System.Collections.Generic;
using System.Text;
using Shamane.Service.Definition.Dto;

namespace Shamane.Service.Implementation.Services
{
    public class UserService : IUserService
    {
        public UserDto Get(string id)
        {
            return new UserDto
            {
                Address = "بابل - چهارراه گله محله - کوچه مسجد امام حسن مجتبی - پلاک 7"
            };
        }

        public string GetUserId()
        {
            return "50299fd3-8f5d-4a01-a8e0-5d2f9746e393";
        }
    }
}
