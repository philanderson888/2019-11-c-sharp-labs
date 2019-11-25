using System;

namespace Lab_02_OOP_Mammals_With_Interface
{
    class Program
    {
        static void Main(string[] args)
        {
            Lion lion = new Lion();
            Tiger tiger = new Tiger();

        }
    }


    interface IUseVision {
        void SeeMyPrey();
    }

    interface IUseSmell {
        void SmellMyPrey();

    }


    class Mammal {
        bool isWarmBlooded = true;
        int height;
        int weight;
        int length;

        public int Height { get => height; set => height = value; }
        public int Weight { get => weight; set => weight = value; }
        public int Length { get => length; set => length = value; }


    }
    class Cat : Mammal, IUseSmell, IUseVision { 
        public virtual void Roar()
        {

        }

        public virtual void SeeMyPrey()
        {
            
        }

        public virtual void SmellMyPrey()
        {
            
        }
    }
    class Lion : Cat {
        public override void Roar()
        {
            Console.WriteLine("Lion is roaring");
        }

        public override void SeeMyPrey()
        {
            Console.WriteLine("Lion is seeing its prey");

        }

        public override void SmellMyPrey()
        {
            Console.WriteLine("Lion is smelling its prey");

        }
    }
    class Tiger : Cat {
        public override void Roar()
        {
            Console.WriteLine("Tiger is roaring");

        }

        public override void SeeMyPrey()
        {
            Console.WriteLine("Tiger is seeing its prey");

        }

        public override void SmellMyPrey()
        {
            Console.WriteLine("Tiger is smelling its prey");

        }
    }



}
