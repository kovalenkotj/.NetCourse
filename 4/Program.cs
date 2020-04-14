using System;

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

        }
    }
}
