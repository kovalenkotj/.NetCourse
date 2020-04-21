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

            // Task 7
            Console.WriteLine(GenericsClass<int>.FillTime(5) + " " + ObjectsClass.FillTime(5));

            // Task 6
            LinkedListClass<int> intList = new LinkedListClass<int>();
            intList.Add(5);
            intList.Add(8);
            intList.Remove(5);

            LinkedListClass<string> strList = new LinkedListClass<string>();
            strList.Add("str1");
            strList.Add("str2");
            strList.Remove("str2");
        }
    }
}
