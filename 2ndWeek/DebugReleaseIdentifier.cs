using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace _2ndWeek
{
    static class DebugReleaseIdentifier
    {
        public static string Identify()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string[] s = assembly.Location.Split("\\");

            int i = 0;
            for (; i < s.Length; i++)
            {
                if (s[i] == "bin")
                {
                    break;
                }
            }
            return s[i + 1];
        }
    }
}
