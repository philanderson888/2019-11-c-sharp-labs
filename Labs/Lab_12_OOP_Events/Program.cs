using System;

namespace Lab_12_OOP_Events
{
    class Program
    {
        static void Main(string[] args)
        {
            var James = new Child("James");
            James.Grow();
            James.Grow();
            James.Grow();
            James.Grow();
        }
    }


     class Child
    {
        // TRIVIAL EVENT ANNUAL BIRTHDAY!
        delegate void BirthdayDelegate();
        event BirthdayDelegate HaveABirthday;

        public string Name { get; set; }
        public int Age { get; set; }

        public void HaveAParty()
        {
            // this refers to the INSTANCE 
            this.Age++;
            Console.WriteLine("Hey celebrating another year!  " +
                $"Age is now {this.Age}");
        }
        public Child(string Name)
        {
            this.Name = Name;
            this.Age = 0;
            HaveABirthday += HaveAParty; // placeholder
        }

        public void Grow()
        {
            HaveABirthday(); // call the event
        }
    }

}
