using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shamane.Common.Extensions
{
    public static class EnumEx
    {
        public static bool IsDefined(this Enum _enum)
        {
            var type = _enum.GetType();
            object val = Convert.ChangeType(_enum, _enum.GetTypeCode());
            var values = Enum.GetValues(type).Cast<int>().OrderBy(x => x);
            return values.Contains((int)val);
        }

        public static int ToInt(this Enum _enum)
        {
            var type = _enum.GetType();
            object val = Convert.ChangeType(_enum, _enum.GetTypeCode());
            return (int)val;
        }

    }
}
