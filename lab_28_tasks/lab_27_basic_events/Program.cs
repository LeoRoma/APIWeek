using System;

namespace lab_27_basic_event
{
    class Program
    {
        delegate void MyDelegate();
        static event MyDelegate MyEvent;

        delegate string NameDelegate(string fName, string lName);
        static event NameDelegate EventName;

        static void Main(string[] args)
        {
            // Events ==> link to multiple Methods
            // Event ==> external to program

            // User events - onclick, onkeydown/up/press, double click, mouse over, mouse out

            // Data events - onload, onpageload, ondata arrive, track % complete (map to progress bar), on data complete
            //             - notification of email/chat message

            // 1. Create delegate (specify methods which can run)
            // 2. Create 'null' event
            // 3. Add methods using += or -=. Order natters => methods fire in this order
            MyEvent += Method01;
            MyEvent += Method02;
            MyEvent += Method03;

            MyEvent();

            EventName += GetName;

            Console.WriteLine(EventName("Leo", "Xia"));
        }

        static void Method01()
        {
            Console.WriteLine("Running Method01");
        }

        static void Method02()
        {
            Console.WriteLine("Running Method02");
        }

        static void Method03()
        {
            Console.WriteLine("Running Method03");
        }

        static string GetName(string fName, string lName)
        {
            return $"First name: {fName}, Last name: {lName}";
        }
    }
}