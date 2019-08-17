using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shamane.Endpoint.ExceptionHandler
{
    public static class ExceptionDictionary
    {
        public static string DefaultLang = "FA";
        public static string GetMessage(int errorCode)
        {
            switch (DefaultLang)
            {
                default:
                case "FA":
                    var message = PersianExceptionDictionary.GetMessage(errorCode);
                    return message;
                case "EN":
                    return EnglishExceptionDictionary.GetMessage(errorCode);
            }
        }
    }
}
