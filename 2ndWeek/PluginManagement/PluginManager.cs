using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using System.Linq;

namespace _2ndWeek.PluginManagement
{
    /* Task 21, Week 3:
         "Create plug-in manager application which scans directory for plug-ins and loads them. 
         Use shared interface to implement plug-in's and determine if assembly is a needed plug-in, 
         Define some action in plug-in. Plug-in manager should load all available plug-ins and perform actions defined in each plug-in."*/
    public class PluginManager
    {
        string pluginsPath;
        public List<IPlugin> pluginsList = new List<IPlugin>();
        public PluginManager()
        {
            pluginsPath = @"C:\Users\tetiana.kovalenko\source\repos\DotNetCourse\2ndWeek\bin\Debug\netcoreapp3.1"; 
            PluginsSearch();
        }

        public void PluginsSearch()
        {
            pluginsList.Clear();

            DirectoryInfo pluginDirectory = new DirectoryInfo(pluginsPath);
            if (!pluginDirectory.Exists)
                pluginDirectory.Create();

            var pluginFiles = Directory.GetFiles(pluginsPath, "*.dll");
            foreach (var file in pluginFiles)
            {
                Assembly asm = Assembly.LoadFrom(file);

                var types = asm.GetTypes().
                                Where(t => t.GetInterfaces().
                                Where(i => i.FullName == typeof(IPlugin).FullName).Any());

                foreach (var type in types)
                {
                    var plugin = asm.CreateInstance(type.FullName) as IPlugin;
                    pluginsList.Add(plugin);
                }
            }
        }
    }
}
