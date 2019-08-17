using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Shamane.Domain.Exceptions;
using Shamane.Service.Exceptions;

namespace Shamane.Endpoint.ExceptionHandler
{
    public static class ExceptionManager
    {
        internal static bool IsCustomException(IExceptionHandlerFeature _error)
        {
            var error = _error.Error;
            if (error is ServiceBaseException)
            {
                return true;
            }
            else if (error is EntityNotFoundException)
            {
                return true;
            }
            return false;
        }

        internal static ExceptionInfo GetInfo(IExceptionHandlerFeature _error)
        {
            var error = _error.Error;
            var exInfo = new ExceptionInfo();
            if (error is ServiceBaseException)
            {
                if (error is CenterException)
                {
                    var ex = (CenterException)error;
                    exInfo.ExceptionType = ExceptionType.ServiceException;
                    exInfo.StatusCode = 400;
                    exInfo.Message = ExceptionDictionary.GetMessage(ex.RoleId);
                    return exInfo;
                }
                else if (error is AddressException)
                {
                    var ex = (AddressException)error;
                    exInfo.ExceptionType = ExceptionType.ServiceException;
                    exInfo.StatusCode = 400;
                    exInfo.Message = ExceptionDictionary.GetMessage(ex.RoleId);
                    return exInfo;
                }
            }
            else if (error is EntityNotFoundException)
            {
                exInfo.ExceptionType = ExceptionType.ResourceNotFoundException;
                exInfo.StatusCode = 404;
                exInfo.Message = ExceptionDictionary.GetMessage((int)ExceptionType.ResourceNotFoundException);
                return exInfo;
            }
            return new ExceptionInfo()
            {
                ExceptionType = ExceptionType.UnHandeledException,
                Message = ExceptionDictionary.GetMessage(-1),
                StatusCode = 500
            };
        }
    }
    public class ExceptionInfo
    {
        public ExceptionType ExceptionType { get; set; }
        public int StatusCode { get; internal set; }
        public string Message { get; internal set; }
    }
    public enum ExceptionType
    {
        Null = -1,
        ServiceException = 400,
        AuthorizationException = 403,
        ResourceNotFoundException = 404,
        ExternalSreviceException = 503,
        UnHandeledException = 500
    }
}
