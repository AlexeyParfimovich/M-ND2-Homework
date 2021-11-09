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

            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            Console.WriteLine($"List all subdirectories in {path}:");

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

                foreach (var di in dirs)
                {
                    Console.WriteLine($"{di.name}");
                }


                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

                Console.WriteLine("Objects serialized to JSON:");
                Console.WriteLine($"{System.Text.Json.JsonSerializer.Serialize(dirs, new JsonSerializerOptions { WriteIndented = true })}");
            }
            catch(Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }
        

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
