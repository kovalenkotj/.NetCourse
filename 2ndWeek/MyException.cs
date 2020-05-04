using System;
using System.Collections.Generic;
using System.Text;

namespace _2ndWeek
{
    /* Task 2, Week 3:
     "Create your own exception. Try to throw it."*/
    public class MyException : ApplicationException
    {
        public override string Message
        {
            get
            {
                return "MyException is thrown";
            }
        }
    }
}
