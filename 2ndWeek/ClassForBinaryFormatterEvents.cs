using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace _2ndWeek
{
    /* Task 9, Week 3:
     "Create a class that provides methods for all four BinaryFormatter serialization events."*/
    [Serializable]
    class ClassForBinaryFormatterEvents
    {
        [OnSerializing]
        public void OnSerializingMethod(StreamingContext context)
        {
            Console.WriteLine("Serializing's in progress");
        }
        [OnSerialized]
        public void OnSerializedMethod(StreamingContext context)
        {
            Console.WriteLine("Serialized");
        }
        [OnDeserializing]
        public void OnDeserializingMethod(StreamingContext context)
        {
            Console.WriteLine("Deserializing's in progress");
        }
        [OnDeserialized]
        public void OnDeserializedMethod(StreamingContext context)
        {
            Console.WriteLine("Deserialized");
        }

        
        
        

    }
}
