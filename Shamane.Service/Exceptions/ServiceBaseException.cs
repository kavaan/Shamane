using Shamane.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shamane.Service.Exceptions
{
    public class ServiceBaseException : ApplicationBaseException
    {
        public int RoleId { get;protected set; }

        public ServiceBaseException()
        {
        }
    }
}
