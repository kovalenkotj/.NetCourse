using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace _2ndWeek
{
    class BinarySerialization<T>
    {
        string file = typeof(T).Name + ".dat";
        BinaryFormatter formatter = new BinaryFormatter();

        public void Serialize(T obj)
        {
            using(FileStream fileStream = new FileStream(file, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fileStream, obj);
            }
        }

        public T Deserialize()
        {
            using(FileStream fileStream = new FileStream(file, FileMode.OpenOrCreate))
            {
                return (T)formatter.Deserialize(fileStream);
            }
        }
    }
}
