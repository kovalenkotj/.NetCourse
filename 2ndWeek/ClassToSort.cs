using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace _2ndWeek
{
    class ClassToSort : IComparable<ClassToSort>, IComparer<ClassToSort>
    {
        int someValue;
        public int Compare(ClassToSort x, ClassToSort y)
        {
            if (x.someValue < y.someValue)
            {
                return -1;
            }
            else if (x.someValue > y.someValue)
            {
                return 1;
            }
            return 0;
        }

        public int CompareTo(ClassToSort other)
        {
            if (someValue < other.someValue)
            {
                return -1;
            }
            else if (someValue > other.someValue)
            {
                return 1;
            }
            return 0;
        }
    }
}
