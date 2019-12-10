using System;

namespace Lab_29_Simpsons_Rule_Area_Under_Graph
{
    class Program
    {
        static void Main(string[] args)
        {
          
        }
    }

    public class SimsonsRule
    {
        /*
         Homework!
         Graph of Y=X*X  (can hard code this in)
         Points 0,1,2,3,4,5,6=N  (value of X)
         Value of Y : 0,1,4,9,16,25,36
         Goal : approximate AREA UNDER GRAPH
         Simpsons Rule : 
         Area =  ( (MAX X - MIN X)/ 3 N ) * 
            [ Y(zeroth item)  + Y(last item) 
              + 4(odd-indexed items ie N=1,3,5) 
              + 2(even-indexed items ie N=2,4)
          ]
          https://www.intmath.com/integration/6-simpsons-rule.php
          Because it's a double you can't test for exact value
          But can test <> upper/lower bound which you can fix to 2 decimal places
         * */

        public double GetAreaUnderGraphUsingSimpsonsRule(int n, int min, int max)
        {
            // n=6, min=0, max=6, difference =(max-min/n)
            return -1.0;
        }
    }
}
