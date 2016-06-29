namespace CS317Program.Operations.BubbleSort
{
    class BubbleSort : BaseClass
    {
        private int[] _array;

        public void Run()
        {
            _array = ReadArray();
            PrintArray(_array);

            var result = Sort(_array);

            PrintArray(result, "sorted");
        }

        private int[] Sort(int[] a)
        {
            var length = a.Length;

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length - 1 - i; j++)
                {
                    if(a[j + 1] < a[j])
                    {
                        var temp = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = temp;
                    }
                }
            }

            return a;
        }
    }
}
