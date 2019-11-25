
namespace ValidationAttributes
{
    using System;
    using System.Reflection;
    public static class Validator
    {
       public static bool IsValid(object obj)
        {
            var objProps = obj.GetType().GetProperties();
            foreach(var property in objProps)
            {
                var customAtributes = property.GetCustomAttributes<MyValidationAttribute>();
                foreach( var item in customAtributes)
                {
                    var currentObj = property.GetValue(obj);
                    if (!item.IsValid(property.GetValue(obj))) return false;
                }
            }
            return true;
        }
    }
}
