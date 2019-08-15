using System;
using System.Collections.Generic;
using System.Text;

namespace Shamane.Common.Extensions
{
    public static class StringEx
    {
        public static bool HasValue(this string text)
        {
            return !string.IsNullOrEmpty(text) && !string.IsNullOrWhiteSpace(text);
        }
    }
}
