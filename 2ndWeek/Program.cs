using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Remoting;
using System.Threading;

namespace _2ndWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            //MyExceptionThrowing();
            //BinarySoapSerializationDemonstration();
            //BinaryFormatterEventsCall();
            /*Exceptions ->*/ //XmlSerializationDemonstration();

            //// Task 12, Week 3
            //Console.WriteLine(SearchInDirectories.DriveSearch("."));
            //Console.WriteLine(SearchInDirectories.DriveSearch("Untitled.png"));

            //// Task 16-17, Week 3
            //Console.Write(SearchInDirectories.DirectoriesSearch(@"C:\Users\tetiana.kovalenko\source\repos\DotNetCourse"));
            //Console.WriteLine();
            //Console.Write(SearchInDirectories.FilesAndDirectoriesSearch(@"C:\Users\tetiana.kovalenko\source\repos\DotNetCourse"));

            //// Task 15, Week 3
            //Console.Write(SearchInDirectories.GetAllDrives());

            ///* Task 13, Week 3:
            //"Add code to view the file by using the FileStream class to show the file in window"*/
            //Console.Write(SearchInDirectories.OpenAndReadFile(@"C:\Users\tetiana.kovalenko\source\repos\DotNetCourse\3\A.cs"));

            ///* Task 14, Week 3:
            //"Finally, add a feature to compress a file when it is found"*/
            //// tried to compress both one and several files, and decided to leave the second variant here
            //SearchInDirectories.FileComporession(@"C:\Users\tetiana.kovalenko\source\repos\DotNetCourse\file.txt",
            //    @"C:\Users\tetiana.kovalenko\source\repos\DotNetCourse\file1.txt");

            // Task 3, Week 3
            ThreadPoolUse();
        }

        /* Task 3, Week 3:
         "Create a test application that writes data out to the console, including the thread that the code is using.
         -Use the ThreadPool to queue up 20 instances of the data-writing code.
         -Note how many threads are used and how often they are reused from the pool 
         (by observing the ManagedThreadId being used on different instances of the code)"*/
        /* Task 4, Week 3
        "Show the size of the ThreadPool by calling the ThreadPool.GetMinThreads and ThreadPool.GetMaxThreads methods. 
        Change the number of the ThreadPools threads by increasing and decreasing the threads using the ThreadPool.SetMinThreads 
        and ThreadPool.SetMaxThreads methods. 
        Run the application with different settings to see how the thread pool operates differently"*/
        public static void ThreadPoolUse()
        {
            Threads.ManageThreadPoolSize(); // Task 4
            //Threads.ThreadPoolUse(); // Task 3
            Console.ReadKey();
        }

        public static void BinaryFormatterEventsCall()
        {
            ClassForBinaryFormatterEvents c = new ClassForBinaryFormatterEvents();
            BinarySerialization<ClassForBinaryFormatterEvents> serialization = new BinarySerialization<ClassForBinaryFormatterEvents>();
            serialization.Serialize(c);
            serialization.Deserialize();
        }

        public static void XmlSerializationDemonstration()
        {
            LinkedListClass<string> list = new LinkedListClass<string>();
            list.Add("str1");
            list.Add("str2");
            XmlSerialization<LinkedListClass<string>> serialization = new XmlSerialization<LinkedListClass<string>>();
            serialization.Serialize(list);
            LinkedListClass<string> list1 = serialization.Deserialize();
        }

        /* Task 5, Week 3:
         "Using the last custom class you created as part of your job, modify it so that it can be serialized. 
         Then write an application to serialize and deserialize it using BinaryFormatter. 
         Examine the serialized data. Then modify the application to use SoapFormatter. Examine the serialized data"*/
        /* Task 8, Week 3:
         "Using the last custom class you created as part of your job, 
         modify it so that it implements ISerialization and can be successfully serialized and deserialized."*/
        public static void BinarySoapSerializationDemonstration()
        {
            LinkedListClass<string> list = new LinkedListClass<string>();
            list.Add("str1");
            list.Add("str2");
            LinkedListClass<string> list1;
            BinarySerializationActions(list, out list1);
            /*XmlException (Task 8) -> */ //SoapSerializationActions(list, out list1);
            ClassToSort classToSort = new ClassToSort(5);
            ClassToSort classToSort1;
            SoapSerializationActions(classToSort, out classToSort1);
        }
        public static void BinarySerializationActions<T>(T obj, out T obj1)
        {
            BinarySerialization<T> serialization = new BinarySerialization<T>();

            serialization.Serialize(obj);

            obj1 = serialization.Deserialize();
        }

        public static void SoapSerializationActions<T>(T obj, out T obj1)
        {
            SoapSerialization<T> serialization = new SoapSerialization<T>();

            serialization.Serialize(obj);

            obj1 = serialization.Deserialize();
        }

        static void MyExceptionThrowing()
        {
            try
            {
                throw new MyException();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
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
