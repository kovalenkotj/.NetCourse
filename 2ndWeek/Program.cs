using System;
using System.Collections.Generic;

namespace _2ndWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 4
            long r1, r2;
            CollectionClass.Enumeration(out r1, out r2);
            Console.WriteLine(r1 + " " + r2);
            /* 'foreach' is slower than 'for', because creates and uses IEnumerator object during the execution*/

            // Task 5
            List<int> collection1, collection2;
            CollectionClass.Modifying(out collection1, out collection2);
            /* 'List<>' allows to use both 'for' and 'foreach' for modifying */
        }
    }
}
