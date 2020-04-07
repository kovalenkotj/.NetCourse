using System;
using System.Collections;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            Int32Casting(150);
            Int32Casting(650);
            Int32Casting(123456);
            Int32Casting(-200);

            BoxingUnboxing();

            Console.ReadKey();
        }

        //1
        static void Int32Casting(int value)
        {
            Console.WriteLine("Int32 value: " + value);
            checked
            {
                long l1 = unchecked((long)value);
                Console.WriteLine("\nUnchecked cast to long: " + l1);
                long l2 = (long)value;
                Console.WriteLine("Checked cast to long: " + l2);

                double d1 = unchecked((double)value);
                Console.WriteLine("\nUnchecked cast to double: " + l1);
                double d2 = (double)value;
                Console.WriteLine("Checked cast to double: " + l2);

                try
                {
                    short s1 = unchecked((short)value);
                    Console.WriteLine("\nUnchecked cast to short: " + s1);
                    short s2 = (short)value;
                    Console.WriteLine("Checked cast to short: " + s2);
                }
                catch
                {
                    Console.WriteLine("The value can't be converted to short");
                }

                try
                {
                    byte b1 = unchecked((byte)value);
                    Console.WriteLine("\nUnchecked cast to byte: " + b1);
                    byte b2 = (byte)value;
                    Console.WriteLine("Checked cast to byte: " + b2);
                }
                catch
                {
                    Console.WriteLine("The value can't be converted to byte");
                }

                try
                {
                    uint ui1 = unchecked((uint)value);
                    Console.WriteLine("\nUnchecked cast to uint: " + ui1);
                    uint ui2 = (uint)value;
                    Console.WriteLine("Checked cast to uint: " + ui2);
                }
                catch
                {
                    Console.WriteLine("The value can't be converted to uint");
                }

                Console.WriteLine("\n");
            }
        }

        //3
        static void BoxingUnboxing()
        {
            int i = 32;
            char c = 'c';

            Object boxed_i = (Object)i;
            Object boxed_c = (Object)c;
            Console.WriteLine("Boxing is performed");

            int unboxed_i = (int)boxed_i;
            char unboxed_c = (char)boxed_c;
            Console.WriteLine("Unboxing is performed");
        }
    }
}
