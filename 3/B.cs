using System;
using System.Collections.Generic;
using System.Text;

namespace _3
{
    class B:A
    {
        public void Method()
        {
            // mistakes, because these A class members are private
            //field1 = 0; 
            //Prop1 = 0;
            //Method1();

            // everything's ok, because the members are protected
            field2 = 0;
            Prop2 = 0;
            Method2();
        }
    }
}
