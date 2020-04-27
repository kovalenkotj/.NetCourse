using System;
using System.Collections.Generic;
using System.Text;

namespace _2ndWeek
{
    // Task 10
    class ClassWithPrivateConstructor
    {
        private ClassWithPrivateConstructor()
        {
            Console.WriteLine("The instance is created");
        }
    }
}
