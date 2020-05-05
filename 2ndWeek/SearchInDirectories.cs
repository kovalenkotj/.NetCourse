using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace _2ndWeek
{
    /* Task 12, Week 3:
     "Create an application that will search a drive for a particular file."*/
    static class SearchInDirectories
    {
        public static string DriveSearch(string path)
        {
            return new DirectoryInfo(path).Root.ToString();
        }

        /* Task 16, Week 3:
         "Create an application which takes a path to some directory as parameter 
         and shows a list of directories which are inside of passed directory."*/
        public static string DirectoriesSearch(string path)
        {
            DirectoryInfo[] directories = new DirectoryInfo(path).GetDirectories();
            string dirs = "";

            foreach(DirectoryInfo dir in directories)
            {
                dirs += dir.ToString() + "\n";
            }

            return dirs;
        }

        /* Task 17, Week 3:
         "Modify previous application to show also list of files inside passed directory."*/
        public static string FilesAndDirectoriesSearch(string path)
        {
            DirectoryInfo[] directories = new DirectoryInfo(path).GetDirectories();
            FileInfo[] files = new DirectoryInfo(path).GetFiles();

            string dfs = "\nDirectories:\n";
            foreach (DirectoryInfo dir in directories)
            {
                dfs += dir.ToString() + "\n";
            }
            dfs += "\nFiles:\n";
            foreach (FileInfo f in files)
            {
                dfs += f.ToString() + "\n";
            }

            return dfs;
        }

    }
}
