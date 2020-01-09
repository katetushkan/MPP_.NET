using System;

using System.IO;
using System.Linq;
using System.Reflection;

namespace Lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter path:");
            var path = Console.ReadLine();

            if ((!File.Exists(path)) || (path == null))
            {
                Console.WriteLine($"there is no such path  {path} .");
                return;
            }

            foreach (var dataType in Assembly.LoadFrom(path)
                                             .GetTypes()
                                             .Where(x => x.IsPublic)?.OrderBy(x => x.Namespace)
                                                                     .ThenBy(x => x.Name))
            {
                Console.WriteLine(dataType.FullName);
            }
            Console.WriteLine();
            Console.Read();
        }
    }
}
