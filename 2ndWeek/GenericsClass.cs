using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace _2ndWeek
{
    class GenericsClass<T>
    {
        static List<T> list = new List<T>();

        public static long FillTime(T obj)
        {
            Stopwatch sw = Stopwatch.StartNew();
            //DateTime t1 = DateTime.Now;
            for (int i = 0; i < 5000; i++)
            {
                list.Add(obj);
            }
            //DateTime t2 = DateTime.Now;
            //return t2.Ticks - t1.Ticks;
            sw.Stop();
            return sw.ElapsedTicks;
        }
    }

    class ObjectsClass
    {
        static List<object> list = new List<object>();

        public static long FillTime(object obj)
        {
            //DateTime t1 = DateTime.Now;
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < 5000; i++)
            {
                list.Add(obj);
            }
            //DateTime t2 = DateTime.Now;
            //return t2.Ticks - t1.Ticks;
            sw.Stop();
            return sw.ElapsedTicks;
        }
    }
}
