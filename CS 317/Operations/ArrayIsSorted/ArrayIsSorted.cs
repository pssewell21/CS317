using System;

namespace CS317Program.Operations.ArrayIsSorted
{
    class ArrayIsSorted : BaseClass
    {
        private int[] _array;

        public void Run()
        {
            _array = ReadArray();
            PrintArray(_array);

            IsSorted(_array);
        }

        private void IsSorted(int[] array)
        {
            var isSorted = true;
            int? prevValue = null;
            
            foreach (var value in array)
            {
                if (prevValue == null)
                {
                    prevValue = value;
                }
                else
                {
                    if (prevValue > value)
                    {
                        isSorted = false;
                        break;
                    }
                    else
                    {
                        prevValue = value;
                    }
                }
            }

            if (isSorted && _array.Length > 0)
            {
                Console.WriteLine("\nArray is sorted");
            }
            else if (array.Length > 0)
            {
                Console.WriteLine("\nArray is not sorted");
            }
        }
    }
}
