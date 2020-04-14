using System;

namespace _5
{
    enum E
    {
        Item1,
        Item2
    }
    [Flags]
    enum BitFlags
    {
        Item1 = 0x0001,
        Item2 = 0x0002
    }
    class Program
    {
        static E e;
        static BitFlags b = BitFlags.Item1;
        static void Main(string[] args)
        {
            MethodEnum(ref e);
            MethodBitFlag(ref b);
        }

        static void MethodEnum(ref E e) // Task 1 method
        {
            Console.WriteLine(e);
        }

        static void MethodBitFlag(ref BitFlags b) // Task 2 method
        {
            Console.WriteLine(b);
        }

        static bool MethodBitFlag(BitFlags sequence, BitFlags flag) // Task 3
        {
            return (sequence & flag) == flag;
        }
    }
}
