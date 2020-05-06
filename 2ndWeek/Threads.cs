using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2ndWeek
{
    class Threads
    {
        /* Task 3, Week 3:
         "Create a test application that writes data out to the console, including the thread that the code is using.
         -Use the ThreadPool to queue up 20 instances of the data-writing code.
         -Note how many threads are used and how often they are reused from the pool 
         (by observing the ManagedThreadId being used on different instances of the code)"*/
        public static void ThreadPoolUse()
        {
            for(int i = 0; i < 20; i++)
            {
                ThreadPool.QueueUserWorkItem(Output, i);
            }

        }

        public static void Output(Object state)
        {
            Console.WriteLine($"Position in queue: {state}, Thread id: {Thread.CurrentThread.ManagedThreadId}");
        }

        /* Task 4, Week 3
         "Show the size of the ThreadPool by calling the ThreadPool.GetMinThreads and ThreadPool.GetMaxThreads methods. 
         Change the number of the ThreadPools threads by increasing and decreasing the threads using the ThreadPool.SetMinThreads 
         and ThreadPool.SetMaxThreads methods. 
         Run the application with different settings to see how the thread pool operates differently"*/
        public static void ManageThreadPoolSize()
        {
            int maxWorkerThreads, maxPortThreads, minWorkerThreads, minPortThreads;
            ThreadPool.GetMinThreads(out minWorkerThreads, out minPortThreads);
            ThreadPool.GetMaxThreads(out maxWorkerThreads, out maxPortThreads);
            Console.WriteLine($"Minimum number of: worker threads - {minWorkerThreads}, completion port threads - {minPortThreads} ");
            Console.WriteLine($"Maximum number of: worker threads - {maxWorkerThreads}, completion port threads - {maxPortThreads} ");
            ThreadPoolUse();

            Thread.Sleep(2000);

            ThreadPool.SetMinThreads(321, 321);
            ThreadPool.GetMinThreads(out minWorkerThreads, out minPortThreads);
            ThreadPool.GetMaxThreads(out maxWorkerThreads, out maxPortThreads);
            Console.WriteLine($"Minimum number of: worker threads - {minWorkerThreads}, completion port threads - {minPortThreads} ");
            Console.WriteLine($"Maximum number of: worker threads - {maxWorkerThreads}, completion port threads - {maxPortThreads} ");
            ThreadPoolUse();

            Thread.Sleep(2000);

            ThreadPool.SetMinThreads(3, 3);
            ThreadPool.SetMaxThreads(4,4);
            ThreadPool.GetMinThreads(out minWorkerThreads, out minPortThreads);
            ThreadPool.GetMaxThreads(out maxWorkerThreads, out maxPortThreads);
            Console.WriteLine($"Minimum number of: worker threads - {minWorkerThreads}, completion port threads - {minPortThreads} ");
            Console.WriteLine($"Maximum number of: worker threads - {maxWorkerThreads}, completion port threads - {maxPortThreads} ");
            ThreadPoolUse();
        }
    }
}
