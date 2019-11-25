using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_08_TDD_Collections
{
    class Program
    {
        static void Main(string[] args)
        {
           // TestCollections.ArrayListDictionaryGetTotal(1,2,3,4,5);
        }
    }


    public class TestCollections
    {
        /*
         
              

TDD Lab Exercise : Collections


Create a new project called Lab_08_TDD_Collections which is a 
  Console app in .NET Core


Add a class called Lab_08_Array_List_Dictionary


Add a method int Lab_08_Array_List_Dictionary_Get_Total(int a, b,c,d,e)


Create some code to take in 5 numbers as input


Take those numbers, add 5, and put into an Array


Iterate over the array, extract the numbers, square the numbers, and add to a List


Iterate over the list, subtract 10, add to a Dictionary<int,int>


Iterate over dictionary and return sum


Return the answer

             */
        public static int ArrayListDictionaryGetTotal(int a, int b, int c, int d, int e)
        {
            var myArray = new int[] { a+5, b+5, c+5, d+5, e+5 };
            var myList = new List<int>();
            var myList2 = new List<int>();
            foreach(var item in myArray)
            {
                myList.Add(item * item);
            }
            foreach(var item in myList)
            {
                myList2.Add(item - 10);
            }
            int total = 0;
            foreach(var item in myList2)
            {
                total += item;
            }
            return total;
        }
    }
}
