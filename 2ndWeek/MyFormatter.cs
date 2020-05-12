using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace _2ndWeek
{
    /* Task 10, Week 3:
         "Implement the IFormatter interface to create a custom formatter. 
         Use it during serialization and deserialization to understand the formatters role in serialization"*/
    class MyFormatter : IFormatter
    {
        public SerializationBinder Binder { get; set; }
        public StreamingContext Context { get; set; }
        public ISurrogateSelector SurrogateSelector { get; set; }

        BinaryFormatter formatter = new BinaryFormatter();

        public object Deserialize(Stream serializationStream)
        {
            return formatter.Deserialize(serializationStream);
        }

        public void Serialize(Stream serializationStream, object graph)
        {
            formatter.Serialize(serializationStream, graph);
        }
    }
}
