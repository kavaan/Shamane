using System;
using System.Collections.Generic;
using System.Text;

namespace Shamane.Service.Exceptions
{
    public class AddressException : ServiceBaseException
    {
        public AddressException(AddressExceptionRole role)
        {
            this.RoleId = (int)role;
        }
    }
    public enum AddressExceptionRole
    {
        Null,
        NotExistsCity = 2000,
        DeactivetedCity = 2001,
        NotExistsOrDeactived = 2002,
    }
}
