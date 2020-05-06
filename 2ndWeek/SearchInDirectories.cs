using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.IO.Compression;

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


        /* Task 15, Week 3:
         "Create an application which will enumerate drives on PC."*/
        public static string GetAllDrives()
        {
            string[] drives = Directory.GetLogicalDrives();
            string drivesString = "";
            foreach (string s in drives)
            {
                drivesString += s + "\n";
            }
            return drivesString;
        }

        /* Task 13, Week 3:
         "Add code to view the file by using the FileStream class to show the file in window"*/
        public static string OpenAndReadFile(string path)
        {
            string result = "";
            using(FileStream stream = new FileStream(path, FileMode.Open))
            {
                using(StreamReader reader = new StreamReader(stream))
                {
                    while(!reader.EndOfStream)
                    {
                        result += reader.ReadLine() + "\n";
                    }
                }
            }
            return result;
        }

        /* Task 14, Week 3:
         "Finally, add a feature to compress a file when it is found"*/
        public static void FileComporession(params string[] paths)
        {
            FileStream destination = File.Create(@"C:\Users\tetiana.kovalenko\source\repos\DotNetCourse\result.gz");

            using (GZipStream gZipStream = new GZipStream(destination, CompressionMode.Compress))
            {
                foreach (string source in paths)
                {
                    using (FileStream tempStream = File.OpenRead(source))
                    {
                        tempStream.CopyTo(gZipStream);
                    }
                }
            }
        }
    }
}
