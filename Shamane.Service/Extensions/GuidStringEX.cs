using System;
using System.Collections.Generic;
using System.Text;

namespace Shamane.Service.Extensions
{
    public static class GuidStringEX
    {
        public static string GToString(this Guid guid)
        {
            return guid.ToString();
        }
        public static Guid ToGuid(this string stringGuid)
        {
            Guid result = Guid.Empty;
            if (Guid.TryParse(stringGuid, out result))
            {
                return result;
            }
            return result;
        }

        public static bool IsValidGuid(this string value)
        {
            if (value.HasValue() && Guid.TryParse(value, out var guid))
            {
                return true;
            }
            return false;
        }
    }
}
