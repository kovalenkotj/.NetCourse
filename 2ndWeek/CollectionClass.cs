using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace _2ndWeek
{
    class CollectionClass
    {
        public static List<int> collection = new List<int>();

        static CollectionClass()
        {
            for(int i = 0; i < 10000; i++)
            {
                collection.Add(i);
            }
        }

        public static void Enumeration(out long result1, out long result2)
        {
            Stopwatch s1, s2;

            s1 = Stopwatch.StartNew();
            for(int i = 0; i < collection.Count; i++) { }
            s1.Stop();
            result1 = s1.ElapsedTicks;

            s2 = Stopwatch.StartNew();
            foreach(int i in collection) { }
            s2.Stop();
            result2 = s2.ElapsedTicks;
        }

        public static void Modifying(out List<int> collection1, out List<int> collection2)
        {
            collection1 = new List<int>(collection);
            collection2 = new List<int>(collection);
            for (int i = 0; i < collection.Count; i++)
            {
                collection1.RemoveAt(i);
                break;
            }

            foreach(int i in collection)
            {
                collection2.Remove(i);
                break;
            }
        }
    }
}
