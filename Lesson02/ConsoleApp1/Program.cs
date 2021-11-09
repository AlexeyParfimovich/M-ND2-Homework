using System;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace ConsoleApp1
{
    class Program
    {
        /// <summary>
		/// App starting
		/// </summary>
		/// <param name="args">Command line args to start.</param>
        static void Main(string[] args)
        {
            /*TODO: 
             * Implement getting the path to the initial directory 
             * and search and display parameters 
             * through command line arguments
             */

            string path;

            // Реализовать обработку исключений в методе Main 
            try
            {
                path = getInitialPath();
            }
            catch
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                Console.WriteLine($"No start directory is specified, the default is {path}");
            }

            try
            {
                var dirs = from dir in (new DirectoryInfo(path)).EnumerateDirectories("*", SearchOption.TopDirectoryOnly)
                           where dir.Exists
                           select new
                           {
                               name = dir.Name,
                               root = dir.Root.Name,
                               parent = dir.Parent.Name
                           };

                // Перебор коллекции в цикле foreach
                Console.WriteLine("\nDirectories started with 'P':");

                foreach (var di in dirs)
                {
                    if (di.name.StartsWith('P'))
                    {
                        Console.WriteLine($"{di.root}{di.parent}\\{di.name}");
                    }
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

                // Перебор коллекции в цикле for
                Console.WriteLine("\nDirectories started with 'M':");

                for (var i = 0; i < dirs.Count(); i++)
                {
                    var di = dirs.ElementAt(i);

                    if (di.name.StartsWith('M'))
                    {
                        Console.WriteLine($"{di.root}{di.parent}\\{di.name}");
                    }
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

                // Перебор коллекции в цикле while
                Console.WriteLine("\nDirectories started with 'V':");

                int position = 0;
                while (position < dirs.Count())
                {
                    var di = dirs.ElementAt(position);

                    if (di.name.StartsWith('V'))
                    {
                        Console.WriteLine($"{di.root}{di.parent}\\{di.name}");
                    }

                    position++;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

                // Сериализация и вывод коллекции как JSON
                Console.WriteLine("\nObjects serialized to JSON:");
                Console.WriteLine($"{System.Text.Json.JsonSerializer.Serialize(dirs, new JsonSerializerOptions { WriteIndented = true })}");

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
            catch(Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }
        }

        /// <summary>
		/// test method to throw an exception
		/// </summary>
        private static string getInitialPath()
        {
            throw new NotImplementedException();
        }
    }
}
