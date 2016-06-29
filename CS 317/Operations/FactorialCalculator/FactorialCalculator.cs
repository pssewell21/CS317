using System;

namespace CS317Program.Operations.FactorialCalculator
{
    class FactorialCalculator : BaseClass
    {        
        public void Run()
        {
            var input = GetUserInput();
            var result = Factorial(input);

            if (result == -1)
            {
                Console.WriteLine("Invalid value selected for n: {0}", input);
            }
            else
            {
                Console.WriteLine("{0}! = {1}", input, result);
            }
        }

        private int GetUserInput()
        {
            Console.Write("Enter the value of n: ");
            return GetIntegerInput();
        }

        // Calculates the value of n!
        // Input: An integer n
        // Output: -1 if an invalid value for n is passed in, else the value of n!
        private int Factorial(int n)
        {
            if (n < 0)
            {
                return -1;
            }

            var result = 1;

            while(n > 0)
            {
                result *= n;
                n--;
            }

            return result;
        }
    }
}
