using Shamane.Service.Definition.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shamane.Service.Implementation.Services
{
    public interface IUserService
    {
        string GetUserId();
        UserDto Get(string id);
    }
}
