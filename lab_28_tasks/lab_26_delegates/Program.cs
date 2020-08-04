using System;

namespace lab_26_delegates
{
    class Program
    {
        delegate void MyDelegate01();

        static void Main(string[] args)
        {
            // Delegates

            // 1. Placeholders for one or more methods
            // 2. Can use in anonymous 'lambda' expressions, very useful particularly with 'async' web calls
            // 3. Link to events ==> EVENT FIRES EG BUTTON CLICK ==> All methods must match pattern in our delegate
            //              void MyDelegate01(); Any methods match pattern void MyMethod();
            //              string      (int)                              string   (int);

            // Create event ==> run given methods
            // 1. Create delegate (top)

            // 2. Create delegate instance
            var delegateInstance = new MyDelegate01(Method01);

            // 3. run delegate instance ==> call our method
            delegateInstance();

        }

        // These are Action Methods
        static void Method01()
        {
            Console.WriteLine("I am Method01");
        }

        void Method02()
        {
            Console.WriteLine("I am Method02");
        }
    }
}