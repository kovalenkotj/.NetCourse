using System;
using System.Collections.Generic;
using System.Text;

namespace _3
{
    //static class A - mistakes: "'A.*any member of A*': cannot declare instance members in a static class"
    class A
    {
        //private A() { } - mistakes, as we can't inherit A and create instances

        private int field1;
        protected int field2;

        private int Prop1 { get; set; }
        protected int Prop2 { get; set; }

        private void Method1() { }
        protected void Method2() { }
    }
}
