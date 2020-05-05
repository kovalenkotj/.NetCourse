using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace _2ndWeek
{
    /* Task 12, Week 3:
     "Create an application that will search a drive for a particular file."*/
    static class DriveSearch
    {
        public static string Search(string path)
        {
            return new DirectoryInfo(path).Root.ToString();
        }
    }
}
