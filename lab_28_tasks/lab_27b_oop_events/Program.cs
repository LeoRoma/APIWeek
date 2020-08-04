using System;
using System.Drawing;

namespace lab_27b_oop_events
{
    class Program
    {
        static void Main(string[] args)
        {
            // goal: annual event (triggered by calendar) - have a birthday party
            var james = new Child("James");

            // Events ==> not reachable externally, so have to call from a method in the class
            for (int i = 0; i < 20; i++)
            {
                james.AnotherYearOlder();
            }


        }
    }

    public class Child
    {
        public string Name { get; set; }
        public int Age { get; set; }

        delegate void BirthdayDelegate(int age);

        event BirthdayDelegate BirthdayEvent; // Null right now

        public Child(string name)
        {
            // New person => allocate a name but age = 0
            this.Name = name;
            this.Age = 0;
            // Fill event
            BirthdayEvent += Celebrate; // Event no longer null
        }

        // The event can't be called externally, so we create a new method for helping us with the purpose
        public void AnotherYearOlder()
        {
            this.Age++;
            BirthdayEvent(this.Age);
        }
        // Method
        void Celebrate(int age)
        {
            Console.WriteLine($"Congratulations!!! You have reached the age of {age}");
        }
    }
}