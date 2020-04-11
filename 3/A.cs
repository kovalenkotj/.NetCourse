using System;
using System.Collections.Generic;
using System.Text;

namespace _3
{
    // the example of partial class
    public partial class A
    {
        private readonly int val = 5;
        public A()
        {
            val = 1; // it's the final result, because we can change the value of a readonly field in the constructor
        }

        
    }

    ////static class A - mistakes: "'A.*any member of A*': cannot declare instance members in a static class"
    //class A
    //{
    //    //private A() { } - mistakes, as we can't inherit A and create instances

    //    private int field1;
    //    protected int field2;

    //    private int Prop1 { get; set; }
    //    protected int Prop2 { get; set; }

    //    private void Method1() { }
    //    protected void Method2() { }
    //}
}
