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
    }
}
