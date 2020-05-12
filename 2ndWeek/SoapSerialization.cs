using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;


namespace _2ndWeek
{
    /* Task 5, Week 3:
         "Using the last custom class you created as part of your job, modify it so that it can be serialized. 
         Then write an application to serialize and deserialize it using BinaryFormatter. 
         Examine the serialized data. Then modify the application to use SoapFormatter. Examine the serialized data"*/
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
