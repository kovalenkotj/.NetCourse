using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;


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
    }
}
