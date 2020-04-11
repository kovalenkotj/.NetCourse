using System;

namespace _3
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Task 2 - we can't create the instance of the class, if it's static */
            /* Task 3 - the A constuctor is inaccessible when it's private */
            A a = new A();

            // private
            //a.field1 = 0;
            //a.Prop1 = 0;
            //a.Method1();

            // protected
            //a.field2 = 0;
            //a.Prop2 = 0;
            //a.Method2();

            /* Task1 - class 'Program' isn't inherited from 'A', so both private and protected members are inaccessible */
        }
    }
}
