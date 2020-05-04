using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Runtime.Serialization;

namespace _2ndWeek
{
    /*Task 1, Week 3:
     "Open the last project you created, and add exception handling to your code. 
     Unless performance is a higher priority than reliability, 
     all code outside of value type declarations should be in a Try block"*/

        [Serializable]
    class ClassToSort : IComparable<ClassToSort>, IComparer<ClassToSort>, ISerializable
    {
        int someValue;

        public ClassToSort(int value)
        {
            someValue = value;
        }
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
        /* Task 8, Week 3 */
        public ClassToSort(SerializationInfo info, StreamingContext context)
        {
            someValue = (int)info.GetValue("someValue", typeof(int));
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("someValue", someValue);
        }
    }
}
