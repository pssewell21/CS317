using System;

namespace CS317Program.Operations.MergeSort
{
    class MergeSort : BaseClass
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
            if (length > 1)
            {
                var bSize = (int)Math.Floor(length / 2.0);
                var cSize = (int)Math.Ceiling(length / 2.0);
                int[] b = new int[bSize];
                int[] c = new int[cSize];
                
                for (int i = 0; i < length / 2; i++)
                {
                    b[i] = a[i];
                }

                var index = 0;
                for (int j = length / 2; j < length; j++)
                {
                    c[index] = a[j];
                    index++;
                }

                b = Sort(b);
                c = Sort(c);

                Merge(b, c, a);
            }

            return a;
        }

        private int[] Merge(int[] b, int[] c, int[] a)
        {
            var i = 0;
            var j = 0;
            var k = 0;

            while (i < b.Length && j < c.Length)
            {
                if (b[i] <= c[j])
                {
                    a[k] = b[i];
                    i++;
                    k++;
                }
                else
                {
                    a[k] = c[j];
                    j++;
                    k++;
                }
            }

            if (i == b.Length)
            {
                for(int l = j; l < c.Length; l++)
                {
                    a[k] = c[l];
                    k++;
                }
            }
            else
            {
                for (int m = i; m < b.Length; m++)
                {
                    a[k] = b[m];
                    k++;
                }
            }

            return a;
        }
    }
}
