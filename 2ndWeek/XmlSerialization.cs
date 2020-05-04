using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace _2ndWeek
{
    /* Task 7, Week 3:
     "Write an application that uses XML serialization to serialize and deserialize the last class you created as part of your job"*/
    class XmlSerialization<T>
    {
        string file = typeof(T).Name + ".xml";
        XmlSerializer serializer = new XmlSerializer(typeof(T));

        public void Serialize(T obj)
        {
            using (FileStream fileStream = new FileStream(file, FileMode.OpenOrCreate))
            {
                serializer.Serialize(fileStream, obj);
            }
        }

        public T Deserialize()
        {
            using (FileStream fileStream = new FileStream(file, FileMode.OpenOrCreate))
            {
                return (T)serializer.Deserialize(fileStream);
            }
        }

    }
}
