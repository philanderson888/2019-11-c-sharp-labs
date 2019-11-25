using System;
using System.Linq;
using System.Collections.Generic;

namespace Lab_09_Rabbit_Test
{
    
    class Program
    {
        static void Main(string[] args)
        {
 
        }
    }

    public class Rabbit_Collection
    {
        public static List<Rabbit> rabbits = new List<Rabbit>();

        #region TestStandardRabbitGrowth
        /* 
         Input totalYears to run the system
         Output will be list of rabbits produced
         Every year, double number of rabbits
         Every year, increment age also of every rabbit
         Test data
         Year 0    1 rabbit age 0
         Year 1    2            1,0
              2    4            2,1,0,0
              3    8            3,2,1,1,0,0,0,0  ==> total age = 7 length 8                      
             */
        public static (int cumulativeRabbitAge,int rabbitCount) MultiplyRabbits(int totalYears)
        {
            #region InitialiseRabbitListToHaveOneRabbitAge0
            // first rabbit
            var rabbit0 = new Rabbit
            {
                RabbitId = 0,
                RabbitName = "Rabbit0",
                Age = 0
            };
            rabbits.Add(rabbit0);
            #endregion

            #region LoopThroughTheYears
            for (int year = 0; year < totalYears; year++)
            {
                #region ForEachRabbitGenerateANewOneAndAddOneYear
                // for each rabbit, generate a new one
                foreach( var rabbit in rabbits.ToArray())
                {
                    var newRabbit = new Rabbit();
                    rabbits.Add(newRabbit);
                    rabbit.Age++;
                }
                #endregion

            }
            #endregion

            #region SumRabbitAge
            int cumulativeRabbitAge = 0;
            rabbits.ForEach(r => cumulativeRabbitAge += r.Age);
            #endregion

            return (cumulativeRabbitAge,rabbits.Count);
        }
        #endregion

        #region TestRabbitGrowthToBeginAfter3Years
        /*
         Can we change the test or create a second one which only starts to add new rabbits
         if their age is >=3
                  Test data
         Year 0    1 rabbit age 0
         Year 1    1            1
              2    1            2
              3    1            3
              4    2            4,0
              5    3            5,1,0
              6    4            6,2,1,0
              7    5            7,3,2,1,0
              8    7            8,4,3,2,1,0,0  
                      
         */
        // HOMEWORK/STUFF TO DO WHEN YOU HAVEN'T GOT ANYTHING TO DO !!!
        public static (int cumulativeRabbitAge, int rabbitCount) 
            MultiplyRabbitsAfterAgeThreeReached(int totalYears)
        {
            return (-2, -2);
        }
        #endregion

    }

    #region RabbitsClass
    public class Rabbit
    {
        public int RabbitId { get; set; }
        public string RabbitName { get; set; }
        public int Age { get; set; }
        public Rabbit()
        {
            this.RabbitId = Rabbit_Collection.rabbits.Count + 1;
            RabbitName = "Rabbit" + this.RabbitId;
            Age = 0;
        }
    }
    #endregion

}
