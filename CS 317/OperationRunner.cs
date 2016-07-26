using CS317Program.Operations.ArrayIsSorted;
using CS317Program.Operations.BubbleSort;
using CS317Program.Operations.DepthFirstSearch;
using CS317Program.Operations.FactorialCalculator;
using CS317Program.Operations.MergeSort;
using CS317Program.Operations.QuickSort;
using CS317Program.Operations.TelephoneDirectorySearch;
using System;
using BruteForcePasswordGenerator = Library.Operations.BruteForcePasswordGenerator;
using BruteForcePasswordGeneratorCSharp = CS317Program.Operations.BruteForcePasswordGenerator;

namespace CS317Program
{
    class OperationRunner : BaseClass
    {
        public bool RunOperation(int choice)
        {
            switch (choice)
            {
                case 1:
                    var t1 = new FactorialCalculator();
                    t1.Run();
                    break;
                case 2:
                    var t2 = new TelephoneDirectorySearch();
                    t2.Run();
                    break;
                case 3:
                    var t3 = new ArrayIsSorted();
                    t3.Run();
                    break;
                case 4:
                    var t4 = new MergeSort();
                    t4.Run();
                    break;
                case 5:
                    var t5 = new BubbleSort();
                    t5.Run();
                    break;
                case 6:
                    var t6 = new BruteForcePasswordGenerator.BruteForcePasswordGenerator();
                    t6.Run();
                    break;
                case 7:
                    var t7 = new BruteForcePasswordGeneratorCSharp.BruteForcePasswordGenerator();
                    t7.Run();
                    break;
                case 8:
                    var t8 = new QuickSort();
                    t8.Run();
                    break;
                case 9:
                    var t9 = new DepthFirstSearch();
                    t9.Run();
                    break;
                // Quit case
                case 0:
                    return true;
                // Invalid choice case
                default:
                    Console.WriteLine("\nInvalid menu choice selected");
                    break;
            }

            return false;
        }
    }
}
