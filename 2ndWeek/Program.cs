using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Remoting;

namespace _2ndWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }

        static void From2ndWeek()
        {
            // Task 4
            Console.WriteLine("\tTask 4");
            long r1, r2;
            CollectionClass.Enumeration(out r1, out r2);
            Console.WriteLine(r1 + " " + r2);
            /* 'foreach' is slower than 'for', because creates and uses IEnumerator object during the execution*/

            // Task 5
            Console.WriteLine("\n\tTask 5");
            List<int> collection1, collection2;
            CollectionClass.Modifying(out collection1, out collection2);
            /* 'List<>' allows to use both 'for' and 'foreach' for modifying */

            // Task 7
            Console.WriteLine("\n\tTask 7");
            Console.WriteLine(GenericsClass<int>.FillTime(5) + " " + ObjectsClass.FillTime(5));

            // Task 6
            Console.WriteLine("\n\tTask 6");
            LinkedListClass<int> intList = new LinkedListClass<int>();
            intList.Add(5);
            intList.Add(8);
            intList.Remove(5);

            LinkedListClass<string> strList = new LinkedListClass<string>();
            strList.Add("str1");
            strList.Add("str2");
            strList.Remove("str2");

            // Task 3
            Console.WriteLine("\n\tTask 3");
            ClassForConvertion c = new ClassForConvertion(-5679999);
            Console.Write(c.ToString());
            Console.WriteLine();

            // Task 11
            Console.WriteLine("\n\tTask 11");
            Console.Write(c.CustomAttributedMethods());
            Console.WriteLine();


            // Task 10
            Console.WriteLine("\n\tTask 10");
            Type type = Type.GetType("_2ndWeek.ClassWithPrivateConstructor");
            // It works
            object obj = Activator.CreateInstance(type, true);

            //// It doesn't work
            //AppDomain appDomain = AppDomain.CurrentDomain;
            //object obj2 = appDomain.CreateInstance("2ndWeek", "_2ndWeek.ClassWithPrivateConstructor");

            // It already works))
            ConstructorInfo[] constructors = type.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (ConstructorInfo ci in constructors)
            {
                ci.Invoke(null);
            }

            // Task 9
            Console.WriteLine("\n\tTask 9");
            Type type1 = Type.GetType("_2ndWeek.StaticClass");
            MethodInfo[] methods = type1.GetMethods(BindingFlags.NonPublic | BindingFlags.Static);
            foreach (MethodInfo m in methods)
            {
                if (m.IsGenericMethod)
                {
                    m.MakeGenericMethod(Type.GetType("System.Int32")).Invoke(null, null);
                }
                else
                {
                    m.Invoke(null, null);
                }
            }
            Console.WriteLine();

            // Task 13
            Console.WriteLine("\n\tTask 13");
            object o = UniversalConstructorClass.CreateInstance("_2ndWeek.StaticClass");
            object o1 = UniversalConstructorClass.CreateInstance("_2ndWeek.ClassForConvertion");
            object o2 = UniversalConstructorClass.CreateInstance("System.Reflection.BindingFlags");
            object o3 = UniversalConstructorClass.CreateInstance("_2ndWeek.ClassWithPrivateConstructor");

            // Task 12
            Console.WriteLine("\n\tTask12");
            Console.WriteLine(DebugReleaseIdentifier.Identify());
        }
    }
}
