using System;
using System.Collections.Generic;
using System.Text;

namespace Shamane.Service.Exceptions
{
    public class CenterException : ServiceBaseException
    {
        public CenterException(CenterExceptionRole centerExceptionRole)
        {
            this.RoleId = (int)centerExceptionRole;
        }
    }
    public enum CenterExceptionRole
    {
        Null = 0,
        InvalidType = 1000,
        InvalidDelivery= 1001,
        InvalidTitle = 1002,
    }
}
