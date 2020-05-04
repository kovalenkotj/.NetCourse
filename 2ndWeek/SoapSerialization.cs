using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;


namespace _2ndWeek
{
    class SoapSerialization<T>
    {
        string file = typeof(T).Name + ".soap";
        SoapFormatter formatter = new SoapFormatter();

        public void Serialize(T obj)
        {
            using (FileStream fileStream = new FileStream(file, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fileStream, obj);
            }
        }

        public T Deserialize()
        {
            using (FileStream fileStream = new FileStream(file, FileMode.OpenOrCreate))
            {
                return (T)formatter.Deserialize(fileStream);
            }
        }
    }
}
