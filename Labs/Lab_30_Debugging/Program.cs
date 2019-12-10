#define PHILSTESTCODE
using System;
using System.Diagnostics;
using System.IO;

namespace Lab_30_Debugging
{
    class Program
    {
        static void Main(string[] args)
        {
           for (int i = 0; i < 20; i++)
            {
                var j = $"Your number doubled is {i*2}";
                DoThis();
                Console.Write($"{i}  ");
            }

#if DEBUG
            Console.WriteLine("\n\nYour Program Is In Debug Mode");
#endif

#if PHILSTESTCODE
            Console.WriteLine("\n\nPhil's Test Code Is Running");
#endif

            Debug.WriteLine("We are in debug mode");

            int z = 100;
            Debug.WriteLineIf(z == 100, "z is 100");

            Trace.WriteLine("Tracing some output");
            Trace.WriteLineIf(z == 100, "z is 100 on Trace WriteLine");

            File.AppendAllText("Events.log", $"z has value {z} at {DateTime.Now}");

            // Real hackers begin here

        }
        static void DoThis()
        {
            Console.WriteLine("I am doing something");
        }
    }
}
