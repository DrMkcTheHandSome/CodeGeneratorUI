using System;
using System.Collections.Generic;
using System.Text;

namespace CatalystCodeGenerator.Shared
{
   public static class Extensions
    {
        public static string[] LoadComponents()
        {
            string[] strComponents = {
        "login",
        "form",
        "ag-grid-table",
        "tree",
        "dashboard",
        "registration",
        "forgotPassword",
        "wizard",
        "widgets",
        "table"
    };
            return strComponents;
        }

        public static string[] LoadDataTypes()
        {
            string[] strDataTypes = {
               "number",
               "string",
               "boolean"
            };

            return strDataTypes;
        }
    }
}
