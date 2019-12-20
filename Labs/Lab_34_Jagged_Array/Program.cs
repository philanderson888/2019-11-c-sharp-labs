using System;

namespace Lab_34_Jagged_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] myJaggedArray = new int[10][];
            myJaggedArray[0] = new int[10];
            myJaggedArray[1] = new int[10];
            int[][] myJaggedArray2 = new int[10][10];


            int[,] my2DArray = new int[10, 10];
            int[,,] myCube = new int[10, 10, 10];
        }
    }
}
