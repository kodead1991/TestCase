using System;
using System.IO;

namespace TestCaseConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\SomeDir\hta.txt";

            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
    }
}
