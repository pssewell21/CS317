using System;

namespace CS317Program
{
    class CS317Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the CS 317 program. Author: Patrick Sewell");

            var operationSelector = new OperationSelector();
            var operationRunner = new OperationRunner();

            var quit = false;
            while (!quit)
            {
                var choice = operationSelector.Run();
                quit = operationRunner.RunOperation(choice);
            }
        }
    }
}
