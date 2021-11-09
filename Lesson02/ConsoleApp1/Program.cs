using System;
using System.IO;

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

            Console.WriteLine($"List all subdirectories in {path}");

            try 
            { 
                var diList = (new DirectoryInfo(path)).EnumerateDirectories("*", SearchOption.TopDirectoryOnly);

                foreach (var di in diList)
                {
                    Console.WriteLine($"{di.FullName}");
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }
        }
    }
}
