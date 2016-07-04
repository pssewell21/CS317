namespace CS317Program.Operations.QuickSort
{
    class QuickSort : BaseClass
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
            //Adding more of this stuff here

            return a;
        }
    }
}
