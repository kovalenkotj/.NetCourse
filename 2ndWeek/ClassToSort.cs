using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace _2ndWeek
{
    /*Task 1, Week 3:
     "Open the last project you created, and add exception handling to your code. 
     Unless performance is a higher priority than reliability, 
     all code outside of value type declarations should be in a Try block"*/

    /* Task 7, Week 3:
     "Write an application that uses XML serialization to serialize and deserialize the last class you created as part of your job"*/

     // Task 8 is below

    [Serializable]
    public class ClassToSort : IComparable<ClassToSort>, IComparer<ClassToSort>, ISerializable
    {
        [XmlAttribute]
        public int someValue;

        public ClassToSort() { }
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

        /* Task 8, Week 3:
         "Using the last custom class you created as part of your job, modify it so that it implements ISerialization 
         and can be successfully serialized and deserialized."*/
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
