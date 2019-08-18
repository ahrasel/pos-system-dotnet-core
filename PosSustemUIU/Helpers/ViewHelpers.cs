using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace PosSustemUIU.Helpers
{
    public class ViewHelpers
    {
        public static string GetPropertyValue(object obj, string propertyName)
        {
            var value =  obj.GetType().GetProperties()
               .Single(pi => pi.Name == propertyName)
               .GetValue(obj, null);
            
            if (value != null && propertyName == "IsActive")
            {
                return (bool)value == true ? "1" : "0";
            }
            else if (value != null)
            {
                return (string) value;
            }
            return "undefined";
        }

        public static string Check(Boolean condition, String ifTrue, String ifFalse)
        {
            return condition ? ifTrue : ifFalse;
        }
    }
}