using System;
using System.Diagnostics;

namespace _4
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 2

            int i = 5;
            switch (i)
            {
                case 1:
                case 5:
                    i++; //it executes, as we have no statements in 'case 1' block
                    break;
                default: break;
            }
            // mistake, because it's no 'break' after the 'case 1' block
            //int i = 5;
            //switch (i)
            //{
            //    case 1: Console.WriteLine("Case 1");
            //    case 5:
            //        i++;
            //        break;
            //    default: break;
            //}

            // Task 3
            A a = new A();
            a.Method(ref A.sfield); //static field is passed succesfully
            // Task 4
            //a.Method(ref a.rfield); // mistake, because readonly values can be changed only in the constructor

            // Task 5
            i = a.Rfield; // successfully
            a.Rfield = 1; // the value of the readonly field isn't changed


            // Task 8 - speed test
            Stopwatch sw1, sw2, sw3;
            int ii;

            sw1 = Stopwatch.StartNew();
            if (i == 1) { ii = i; }
            else if (i == 3) { ii = i; }
            else { ii = i; }
            sw1.Stop();

            sw2 = Stopwatch.StartNew();
            switch (i)
            {
                case 1:
                    ii = i;
                    break;
                case 3:
                    ii = i;
                    break;
                default:
                    ii = i;
                    break;
            }
            sw2.Stop();

            sw3 = Stopwatch.StartNew();
            ii = i == 1 ? i : (i == 3 ? i : i);
            sw3.Stop();

            Console.WriteLine("if/else - {0}, switch - {1}, ?: - {2}", sw1.ElapsedTicks, sw2.ElapsedTicks, sw3.ElapsedTicks);
            Console.ReadKey();
        }
    }
}
