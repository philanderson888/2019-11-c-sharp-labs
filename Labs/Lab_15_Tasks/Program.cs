using System;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Lab_15_Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            // inside can go a DELEGATE OR ANONYMOUS METHOD USING LAMBDA
            // SYNTAX

            var task01 = new Task(
                () => { }                  // lambda anonymous method
            );

            var task02 = new Task(
                () => { Console.WriteLine("In Task 02"); }                  
            );
            task02.Start();



            // slicker way
            var task03 = Task.Run(() => { Console.WriteLine("In Task 03"); });
            var task04 = Task.Run(() => { Console.WriteLine("In Task 04"); });
            var task05 = Task.Run(() => { Console.WriteLine("In Task 05"); });

            // stopwatch
            // array of tasks
            // wait for one to complete / all to complete

            Console.WriteLine(stopwatch.ElapsedMilliseconds);
            Console.ReadLine();
        }
    }
}
