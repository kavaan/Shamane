using System;
using System.Collections.Generic;
using System.Text;

namespace Shamane.Service.Authentication.Dtos
{
    public class ChangePasswordDto
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
