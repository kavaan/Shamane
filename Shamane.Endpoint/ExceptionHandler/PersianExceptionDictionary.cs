using Shamane.Service.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shamane.Common.Extensions;
namespace Shamane.Endpoint.ExceptionHandler
{
    public static class PersianExceptionDictionary
    {
        public static string GetMessage(int errorCode)
        {
            if (errorCode == -1)
            {
                return "متاسفانه خطای غیر منتظره ای بوجود آمده است، لطفا با پشتیبانی تماس بگیرید.";
            }
            switch (errorCode)
            {
                case (int)ExceptionType.ResourceNotFoundException:
                    return "اطلاعات مورد نظر پیدا نشد";
                case (int)CenterExceptionRole.InvalidType:
                    return "نوع مرکز معتبر نمی باشد";
                case (int)CenterExceptionRole.InvalidTitle:
                    return "عنوان مرکز معتبر نمی باشد";
                case (int)CenterExceptionRole.InvalidDelivery:
                    return "نوع پیک معتبر نمی باشد";
                case (int)AddressExceptionRole.NotExistsOrDeactived:
                    return "شهر انتخاب شده معتبر نمی باشد";
                default:
                    return "خطای غیر منتظره ای رخ داده است، لطفا با پشتیبانی تماس بگیرید";
            }
        }
    }
}
