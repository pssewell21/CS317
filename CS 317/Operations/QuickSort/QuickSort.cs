namespace CS317Program.Operations.QuickSort
{
    class QuickSort : BaseClass
    {
        private int[] _array;

        public void Run()
        {
            _array = ReadArray();
            PrintArray(_array);

            var result = Sort(_array, 0, _array.Length - 1);

            PrintArray(result, "sorted");
        }

        private int[] Sort(int[] list, int first, int last)
        {
            if (first < last)
            {
                var pivotIndex = Partition(list, first, last);
                list = Sort(list, first, pivotIndex - 1);
                list = Sort(list, pivotIndex + 1, last);
            }

            return list;
        }

        private int Partition(int[] list, int first, int last)
        {
            var pivotValue = list[first];
            var left = first + 1;
            var right = last;

            var finished = false;

            while (!finished)
            {
                while (left <= right && list[left] <= pivotValue)
                {
                    left++;
                }
                while (right >= left && list[right] >= pivotValue)
                {
                    right--;
                }

                if (right < left)
                {
                    finished = true;
                }
                else
                {
                    list = Swap(list, left, right);
                }
            }

            list = Swap(list, first, right);

            return right;
        }

        private int[] Swap(int[] list, int first, int second)
        {
            var temp = list[second];
            list[second] = list[first];
            list[first] = temp;

            return list;
        }
    }
}
