using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace _2ndWeek
{
    class Program
    {
        [DllImport("kernel32.dll", SetLastError = true)] // Task 19, Week 3
        static extern bool Beep(uint dwFreq, uint dwDuration);

        [DllImport("user32.dll", SetLastError = true)]// Task 20, Week 3
        static extern bool LockWorkStation();

        static void Main(string[] args)
        {
            Threads.ManageThreadPoolSize();
            Console.ReadKey();
        }

        


        /* Task 2, Week 3:
         "Create your own exception. Try to throw it."*/
        #region Task 2, Week 3
        static void MyExceptionThrowing()
        {
            try
            {
                throw new MyException(); // my own exception
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        #endregion


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
        #region Task 3-4, Week 3
        public static void ThreadPoolUse()
        {
            Threads.ManageThreadPoolSize(); // Task 4
            //Threads.ThreadPoolUse(); // Task 3
            Console.ReadKey();
        }
        #endregion

        
        /* Task 5, Week 3:
         "Using the last custom class you created as part of your job, modify it so that it can be serialized. 
         Then write an application to serialize and deserialize it using BinaryFormatter. 
         Examine the serialized data. Then modify the application to use SoapFormatter. Examine the serialized data"*/
        /* Task 8, Week 3:
         "Using the last custom class you created as part of your job, 
         modify it so that it implements ISerialization and can be successfully serialized and deserialized."*/
         #region Task 5,8, Week 3
        public static void BinarySoapSerializationDemonstration()
        {
            ClassToSort classToSort = new ClassToSort(5);
            ClassToSort classToSort1;
            SoapSerializationActions(classToSort, out classToSort1);
            BinarySerializationActions(classToSort, out classToSort1);
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
        #endregion

        /* Task 7, Week 3:
         "Write an application that uses XML serialization to serialize and deserialize the last class you created as part of your job"*/
        #region Task 7, Week 3
        public static void XmlSerializationDemonstration()
        {
            ClassToSort classToSort = new ClassToSort(5);
            XmlSerialization<ClassToSort> xmlSerialization = new XmlSerialization<ClassToSort>();
            xmlSerialization.Serialize(classToSort);
            ClassToSort classToSort1 = xmlSerialization.Deserialize();
        }
        #endregion

        /* Task 9, Week 3:
         "Create a class that provides methods for all four BinaryFormatter serialization events."*/
        #region Task 9, Week 3
        public static void BinaryFormatterEventsCall()
        {
            ClassForBinaryFormatterEvents c = new ClassForBinaryFormatterEvents();
            BinarySerialization<ClassForBinaryFormatterEvents> serialization = new BinarySerialization<ClassForBinaryFormatterEvents>();
            serialization.Serialize(c);
            serialization.Deserialize();
        }
        #endregion

        /* Task 10, Week 3:
         "Implement the IFormatter interface to create a custom formatter. 
         Use it during serialization and deserialization to understand the formatters role in serialization"*/
        #region Task 10, Week 3
        private static void UseMyFormatter()
        {
            ClassToSort classToSort = new ClassToSort(5);
            MyFormatter formatter = new MyFormatter();
            using (FileStream stream = new FileStream("myformatter.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(stream, classToSort);
            }
            ClassToSort classToSort1;
            using (FileStream stream = new FileStream("myformatter.dat", FileMode.OpenOrCreate))
            {
                classToSort1 = (ClassToSort)formatter.Deserialize(stream);
            }
        }
        #endregion

        /* Task 11, Week 3:
         "Create a custom class that can be disposed of using the IDisposable.Dispose method"*/
        #region Task 11, Week 3
        private static void Dispose()
        {
            DisposableClass dc = null;
            try
            {
                dc = new DisposableClass();
            }
            finally
            {
                dc.Dispose();
            }
        }
        #endregion
        
        /* Task 12, Week 3:
         "Create an application that will search a drive for a particular file."*/
        #region Task 12, Week 3
        
        private static void DriveSearch()
        {
            Console.WriteLine(SearchInDirectories.DriveSearch("."));
            Console.WriteLine(SearchInDirectories.DriveSearch("Untitled.png"));
        }
        #endregion

        /* Task 13, Week 3:
         "Add code to view the file by using the FileStream class to show the file in window"*/
        #region Task 13, Week 3
        private static void OpenAndReadFile()
        {

            Console.Write(SearchInDirectories.OpenAndReadFile(@"C:\Users\tetiana.kovalenko\source\repos\DotNetCourse\3\A.cs"));
        }
        #endregion

        /* Task 14, Week 3:
         "Finally, add a feature to compress a file when it is found"*/
        #region Task 14, Week 3
        private static void FileCompression()
        {

            // tried to compress both one and several files, and decided to leave the second variant here
            SearchInDirectories.FileComporession(@"C:\Users\tetiana.kovalenko\source\repos\DotNetCourse\file.txt",
                @"C:\Users\tetiana.kovalenko\source\repos\DotNetCourse\file1.txt");
        }
        #endregion

        /* Task 15, Week 3:
         "Create an application which will enumerate drives on PC."*/
        #region Task 15, Week 3
        private static void GetAllDrives()
        {
            Console.Write(SearchInDirectories.GetAllDrives());
        }
        #endregion

        /* Task 16-17, Week 3:
         "Create an application which takes a path to some directory as parameter 
         and shows a list of directories which are inside of passed directory."
         "Modify previous application to show also list of files inside passed directory."*/
        #region Task 16-17, Week 3
        private static void FilesAndDirectoriesSearch()
        {
            Console.Write(SearchInDirectories.DirectoriesSearch(@"C:\Users\tetiana.kovalenko\source\repos\DotNetCourse"));
            Console.WriteLine();
            Console.Write(SearchInDirectories.FilesAndDirectoriesSearch(@"C:\Users\tetiana.kovalenko\source\repos\DotNetCourse"));
        }
        #endregion

        //

        /* Task 19, Week 3:
         "Create a simple console application which can "Beep"  if user press key. 
         (use beep function of kernel32.dll)"*/
        #region Task 19, Week 3
        private static void BeepMethod()
        {
            Console.WriteLine("Press any key to hear the 'beep' sound. Press 'Enter' to exit");
            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {
                Beep(1678, 500);
            }
        }
        #endregion

        /* Task 20, Week 3:
         "Create a simple application which can lock PC (the same way as Win+L keys). 
         (use LockWorkStation function from user32.dll)"*/
        #region Task 20, Week 3
        private static void LockPC()
        {
            Console.WriteLine("Press any key to lock the PC");
            Console.ReadKey();
            LockWorkStation();
        }
        #endregion

        //




















        #region 2nd week
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
        #endregion
        #region Task 8, Week 2
        /* Task 8, Week 2:
         "Imagine that your application use NotifyClient event to notify remote clients. 
         In case if client is disconnected exception will be thrown and other delegates will not be invoke, 
         so other clients will not be notified. 
         Implement a method which will fire NotifyClient event and will be free of this problem."*/
        static event Action NotifyClient;
        public static void Notification(Client c)
        {
            Client c1 = new Client(SubscribeOrNot.No, ref NotifyClient);
            Client c2 = new Client(SubscribeOrNot.Yes, ref NotifyClient);
            Client c3 = new Client(SubscribeOrNot.Yes, ref NotifyClient);

            //NotifyClient();
            foreach (Action e in NotifyClient.GetInvocationList())
            {
                try
                {
                    e.Invoke();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }
        #endregion
    }
}
