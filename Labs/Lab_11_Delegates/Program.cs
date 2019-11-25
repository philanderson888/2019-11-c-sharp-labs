using System;

namespace Lab_11_Delegates
{
    class Program
    {
        // matching delegate
        public delegate void Delegate01();

        // non-trivial delegate
        delegate int Delegate02(int  x);

        static void Main(string[] args)
        {

            // delegate CAN BE REFERENCED AS A CLASS
            // use new keyword
            var delegateInstance = new Delegate01(MyMethod01);
            // call this
            delegateInstance(); // call the method

            // trivial cases can simplify (same result)
            // 1. omit 'new'
            Delegate01 delegateInstance2 = MyMethod01; // same as above
            delegateInstance2();   // call 

            // final trivial case
            // ACTION DELEGATE IS VOID AND TAKES NO PARAMETERS
            Action delegateInstance3 = MyMethod01;  // same as above

            delegateInstance3();  // call

            // will never work !!!!    Action delegateInstance4 = MyMethod02;


            Delegate02 delegateInstance4 = (x)   =>  { return (x * x * x); };    // LAMBDA
                                                                                 // INPUT PARAMS   { // CODE BODY       }
            Delegate02 delegateInstance5 =  x    =>             x * x * x;    // LAMBDA

            checked
            {
                Console.WriteLine(MyMethod03(delegateInstance5(delegateInstance5(10))));
            }


        }

        static void MyMethod01()
        {
            Console.WriteLine("Running Method01");
        }
        static string MyMethod02()
        {
            return "Running Method02";
        }
        static int MyMethod03(int x)
        {
            return x * x;
        }
    }
        
}
