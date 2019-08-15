using System.Linq;

namespace PosSustemUIU.Helpers
{
    public class ViewHelpers
    {
        public static string GetPropertyValue(object obj, string propertyName)
        {
            var value =  obj.GetType().GetProperties()
               .Single(pi => pi.Name == propertyName)
               .GetValue(obj, null);
            if (value != null)
            {
                return (string) value;
            }
            return "undefined";
        }
    }
}