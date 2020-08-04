using System;

namespace lab_26b_delegates
{
    class Program
    {
        delegate void Delegate01();
        delegate string Delegate02(int x, bool y);
        static void Main(string[] args)
        {
            // shorter version
            // notice : no brackets in method ==> just placeholder, don't call right now

            Delegate01 delegateInstance = Method01;
            Action myOtherDelegateInstance = Method02;

            // Declare DelegateTest
            Delegate02 delegateTest = GetString;

            // run 
            delegateInstance();
            myOtherDelegateInstance();

            // run Delegate Test
            Console.WriteLine(delegateTest(20, false));
            Console.WriteLine(delegateTest(10, true));
        }

        static void Method01()
        {
            Console.WriteLine("Running Method 01");
        }

        static void Method02()
        {
            Console.WriteLine("Running Method 02");
        }

        static string GetString(int x, bool y)
        {
            string greeting = "";
            if (x == 10 & y == true)
            {
                return greeting += "Hello";
            }
            else
                greeting += "Hi";
            return greeting;
        }
    }
}