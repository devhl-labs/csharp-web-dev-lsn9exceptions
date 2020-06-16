using System;
using System.Collections.Generic;
using System.Linq;

namespace csharp_web_dev_lsn9exceptions
{
    class Program
    {
        static double Divide(double x, double y)
        {
            if (y == 0)
                throw new ArgumentOutOfRangeException(nameof(y));

            return x / y;
        }

        static int CheckFileExtension(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentException("Parameter was null or empty.", nameof(fileName));

            if (fileName.EndsWith(".cs"))
                return 1;

            return 0;
        }


        static void Main(string[] args)
        {
            if (args.Count() > 0)
                Console.WriteLine(args);

            try
            {
                Divide(1, 0);
            }
            catch(ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }

            Dictionary<string, string> students = new Dictionary<string, string>
            {
                { "Carl", "Program.cs" },
                { "Brad", "" },
                { "Elizabeth", "MyCode.cs" },
                { "Stefanie", "CoolProgram.cs" }
            };

            foreach(KeyValuePair<string, string> entry in students)
            {
                try
                {
                    Console.WriteLine($"{entry.Key}: {CheckFileExtension(entry.Value)}");
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"{entry.Key}: {e.Message}");
                }
            }
        }
    }
}
