using System;
using System.Collections.Generic;
using System.Text;

namespace _5
{
    class CollectionWrapper
    {
        List<int> list = new List<int>();

        public static CollectionWrapper operator +(CollectionWrapper firstlist, CollectionWrapper secondlist)
        {
            foreach(int i in secondlist.list)
            {
                firstlist.list.Add(i);
            }
            return firstlist;
        }

        public static bool operator ==(CollectionWrapper first, CollectionWrapper second)
        {
            if (first.list.Count != second.list.Count)
            {
                return false;
            }
            
            for(int i = 0; i < first.list.Count; i++)
            {
                if (!first.list[i].Equals(second.list[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool operator !=(CollectionWrapper first, CollectionWrapper second)
        {
            if (first.list.Count != second.list.Count)
            {
                return true;
            }

            for (int i = 0; i < first.list.Count; i++)
            {
                if (!first.list[i].Equals(second.list[i]))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool operator <(CollectionWrapper first, CollectionWrapper second)
        {
            return first.list.Count < second.list.Count;
        }

        public static bool operator >(CollectionWrapper first, CollectionWrapper second)
        {
            return first.list.Count > second.list.Count;
        }
    }
}
