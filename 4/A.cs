using System;
using System.Collections.Generic;
using System.Text;

namespace _4
{
    class A
    {
        // Task 1
        public int Prop { private get; set; }
        public int Prop1 { get; private set; }
        //public int Prop2 { private get; private set; } //mistake, because we can't apply access modifiers to both accessors
        public int Prop3 { get; protected set; }
        //protected int Prop4 { get; public set; } //mistake, because the accessor can't be more visible than the property in general
        protected int Prop5 { get; private set; }
        //protected int Prop6 { get; internal set; } 
        //internal int Prop7 { get; protected set; } //tha same mistakes as Prop4
        protected internal int Prop8 { get; protected set; }
        protected internal int Prop9 { get; internal set; }
        //public int Prop10 { public get; set; } //mistake, because accessor must be more restrictive than the property in general


        // Tasks 3, 4
        public static int sfield;
        public readonly int rfield;
        public void Method(ref int i) { }

    }
}
