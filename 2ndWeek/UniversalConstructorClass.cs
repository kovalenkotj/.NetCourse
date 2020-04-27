using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace _2ndWeek
{
    static class UniversalConstructorClass
    {
        public static object CreateInstance(string typeName)
        {
            Type type = Type.GetType(typeName);
            try
            {
                if (!type.IsClass)
                {
                    throw new Exception($"The passed type '{type.Name}' isn't a class");
                }
                else if (type.IsAbstract)
                {
                    Console.WriteLine($"The type '{type.Name}' is static. The instance is null");
                    return null;
                }
                else
                { 
                    object o = Activator.CreateInstance(type, true);
                    Console.WriteLine($"The instance of '{type.Name}' is created");
                    return o;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return new object();
        }
    }
}
