using System;
using System.Collections.Generic;
using System.Text;

namespace _2ndWeek.PluginManagement.Plugins
{
    /* Task 21, Week 3:
         "Create plug-in manager application which scans directory for plug-ins and loads them. 
         Use shared interface to implement plug-in's and determine if assembly is a needed plug-in, 
         Define some action in plug-in. Plug-in manager should load all available plug-ins and perform actions defined in each plug-in."*/
    public class TextToUpperPlugin : IPlugin
    {
        public string Activate(string s)
        {
            return s.ToUpper();
        }
    }
}
