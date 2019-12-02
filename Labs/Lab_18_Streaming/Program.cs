using System;
using System.IO;   // INPUT OUTPUT 
using System.Linq;
using System.Diagnostics;
using System.Text;

namespace Lab_18_Streaming
{
    class Program
    {
        static void Main(string[] args)
        {

            // system.io WRITING FILES
            File.WriteAllText("data.txt", "Hello this is some data");

            var myArray = new string[] { "Hello","This","is","Some","Data"};
            File.WriteAllLines("ArrayData.txt", myArray);



            // append data
            for (int i = 0; i < 10; i++)
            {
                File.AppendAllText("data.txt", $"\nAdding line {i} at {DateTime.Now}");
            }

            for (int i = 0; i < 10; i++)
            {
                File.AppendAllText("data.txt", Environment.NewLine + $"Adding line {i} at {DateTime.Now}");
            }
            Console.WriteLine(File.ReadAllText("data.txt"));

            var output = File.ReadAllLines("ArrayData.txt").ToList();
            output.ForEach(line => Console.WriteLine(line));

            Directory.CreateDirectory("Here Is A Folder");
            File.Create("Here Is A Folder\\myfile.txt");
            File.Create(@"Here Is A Folder\myfile2.txt");

            Directory.CreateDirectory(@"C:\RootFolder");
            Console.WriteLine(Directory.Exists(@"C:\RootFolder"));

            // Stream some data to a file
            // system can cope with large files : breaks them down into blocks and sends them
            var numberOfLines = 20_000;
            var s = new Stopwatch();
            s.Start();

            using (var stream01 = new StreamWriter("output.dat"))
            {
                for (int i = 0; i< numberOfLines;i++)
                {
                    stream01.WriteLine($"Logging some data at {DateTime.Now}");
                }
            }

            var writeTime = s.ElapsedMilliseconds;
            Console.WriteLine($"It took {s.ElapsedMilliseconds} to write {numberOfLines} lines");

            // read the data
            string nextline;

            using (var reader = new StreamReader("output.dat"))
            {
                // READER DOES NOT KNOW HOW BIG FILE IS
                // READ UNTIL reader.READLINE is NULL
                while ((nextline = reader.ReadLine()) != null)
                {
                    //Console.WriteLine(nextline);
                }
                reader.Close();
            }
            
            Console.WriteLine($"It took {s.ElapsedMilliseconds-writeTime} to read {numberOfLines} lines");

            // building a string
            // regular string building with + GENERATE A NEW INSTANCE EVERY TIME
            // STRINGS ARE IMMUTABLE (CANNOT CHANGE THEM)
            // t   ==>   th   ==>    thi
            s.Restart();
            var longString = "";
            using (var reader = new StreamReader("output.dat"))
            {
                while ((nextline = reader.ReadLine()) != null)
                {
                    longString += nextline;
                }
                reader.Close();
            }
            Console.WriteLine($"It took {s.ElapsedMilliseconds} to add {numberOfLines} strings together");
            //Console.WriteLine(longString);

            s.Restart();
            longString = "";
            var stringBuilder = new StringBuilder();
            using (var reader = new StreamReader("output.dat"))
            {
                while ((nextline = reader.ReadLine()) != null)
                {
                    stringBuilder.Append(nextline);
                }
                reader.Close();
            }
            Console.WriteLine($"It took {s.ElapsedMilliseconds} to add {numberOfLines} strings together using StringBuilder");

        }
    }
}
