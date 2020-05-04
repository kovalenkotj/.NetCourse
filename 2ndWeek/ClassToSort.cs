using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace _2ndWeek
{
    /*Task 1, Week 3:
     "Open the last project you created, and add exception handling to your code. 
     Unless performance is a higher priority than reliability, 
     all code outside of value type declarations should be in a Try block"*/

    class ClassToSort : IComparable<ClassToSort>, IComparer<ClassToSort>
    {
        int someValue;
        public int Compare(ClassToSort x, ClassToSort y)
        {
            try
            {
                if (x.someValue < y.someValue)
                {
                    return -1;
                }
                else if (x.someValue > y.someValue)
                {
                    return 1;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return 0;
        }

        public int CompareTo(ClassToSort other)
        {
            try
            {
                if (someValue < other.someValue)
                {
                    return -1;
                }
                else if (someValue > other.someValue)
                {
                    return 1;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return 0;
        }
    }
}
