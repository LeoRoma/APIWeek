using System;

namespace lab_26c_delegates_with_lambda
{
    class Program
    {
        delegate string MyDelegate(string x, int y);
        static void Main(string[] args)
        {
            MyDelegate myInstance = MyMethod;


            // Use anonymous method instead with lambda
            MyDelegate instanceLambda = (name, y) =>
            {
                return $"Thanks, {name} you have entered number {y}";
            };
            Console.WriteLine(myInstance("Fred", 32));
            Console.WriteLine(instanceLambda("Bob", 33));
        }

        static string MyMethod(string name, int y)
        {
            return $"Thanks, {name} you have entered number {y}";
        }
    }
}