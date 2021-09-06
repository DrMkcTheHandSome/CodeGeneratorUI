using System;
using System.Collections.Generic;
using System.Text;

namespace CatalystCodeGenerator.Shared
{
    public static class Helpers
    {
        public static string FormatLabelConfirmation(int pageCount, int totalCount)
        {
            return string.Format("{0} of {1}", pageCount, totalCount);
        }

        public static string GetDataTypeDefaultValue(string dataType)
        {
            switch (dataType)
            {
                case "string": return "''";
                case "number": return "0";
                case "boolean": return "false";
                default: return "''";
            }
        }
    }
}
