using System;
using System.Collections.Generic;
using System.Text;

namespace Shamane.Common.Extensions
{
    public static class GuidStringEX
    {
        public static string GToString(this Guid guid)
        {
            return guid.ToString();
        }
        public static Guid ToGuid(this string stringGuid)
        {
            if (Guid.TryParse(stringGuid, out var result))
            {
                return result;
            }
            return Guid.Empty;
        }
        public static Guid? ToNullableGuid(this string stringGuid)
        {
            if (Guid.TryParse(stringGuid, out var result))
            {
                return result;
            }
            return null;
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
