using System;
using System.Collections.Generic;
using System.Text;

namespace _2ndWeek
{
    /* Task 11, Week 3:
     "Create a custom class that can be disposed of using the IDisposable.Dispose method"*/
    public class DisposableClass : IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("Disposed!");
        }
    }
}
