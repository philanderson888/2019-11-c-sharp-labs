﻿using System;

namespace Lab_01
{
    class Program
    {
        static int[] myArray;
        static void Main()
        {
            Console.WriteLine("Hello World!");
            Method01();
        }

        static void Method01() { 
            int x = 100;
            Method02();
        }

        static void Method02() { 
            bool y = false; 
        }
    }
}
