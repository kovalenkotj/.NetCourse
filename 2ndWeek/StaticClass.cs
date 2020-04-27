using System;
using System.Collections.Generic;
using System.Text;

namespace _2ndWeek
{
    static class StaticClass
    {
        private static void Method()
        {
            Console.WriteLine("The method is invoked");
        }

        private static void SecondMethod()
        {
            Console.WriteLine("The second method is invoked");
        }

        private static void Method<T>()
        {
            Console.WriteLine("The generic method is invoked. Type - " + typeof(T));
        }
    }
}
