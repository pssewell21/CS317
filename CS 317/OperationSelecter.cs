using System;

namespace CS317Program
{
    class OperationSelector : BaseClass
    {
        public int Run()
        {
            return ChooseOperation();
        }
        
        private int ChooseOperation()
        {
            DisplayMenu();

            Console.Write("\nChoose which operation to perform: ");

            return GetIntegerInput();
        }

        private void DisplayMenu()
        {
            string menu = "";

            menu += string.Format("\n{0}. {1}", Resources.FactorialCalculatorValue, Resources.FactorialCalculatorName);
            menu += string.Format("\n{0}. {1}", Resources.TelephoneDirectorySearchValue, Resources.TelephoneDirectorySearchName);
            menu += string.Format("\n{0}. {1}", Resources.ArrayIsSortedValue, Resources.ArrayIsSortedName);
            menu += string.Format("\n{0}. {1}", Resources.MergeSortValue, Resources.MergeSortName);
            menu += string.Format("\n{0}. {1}", Resources.BubbleSortValue, Resources.BubbleSortName);
            menu += string.Format("\n{0}. {1}", Resources.BruteForcePasswordGeneratorValue, Resources.BruteForcePasswordGeneratorName);
            menu += string.Format("\n{0}. {1}", Resources.BruteForcePasswordGeneratorCSharpValue, Resources.BruteForcePasswordGeneratorCSharpName);
            menu += string.Format("\n{0}. {1}", Resources.QuitValue, Resources.QuitName);

            Console.WriteLine(menu);
        }
    }
}
