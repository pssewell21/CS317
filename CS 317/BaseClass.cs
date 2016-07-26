using CS317Program.Data_Structures.Graph;
using System;
using System.Collections.Generic;

namespace CS317Program
{
    class BaseClass
    {
        protected int GetIntegerInput()
        {
            var input = Console.ReadLine();

            try
            {
                var choice = int.Parse(input);
                return choice;
            }
            catch (Exception e)
            {
                HandleException(e);
                return -1;
            }
        }

        protected string GetSingleCharacterInput()
        {
            var input = Console.ReadLine();

            try
            {
                if (input.Length > 1)
                {
                    throw new Exception("Invalid number of characters entered.  Only one character is accepted.");
                }

                input = input.ToUpper();
                
                return input;
            }
            catch (Exception e)
            {
                HandleException(e);
                return "1";
            }
        }

        protected int[] ReadArray()
        {
            Console.Write("\nEnter the numerical values to be entered into the array: ");
            var input = Console.ReadLine();

            char[] delimiterChars = { ' ', ',', '\t', '\n' };
            string[] strings = input.Split(delimiterChars);

            var list = new List<int>();
            for (int i = 0; i < strings.Length; i++)
            {
                int value;
                var parsed = int.TryParse(strings[i], out value);

                if (parsed)
                {
                    list.Add(value);
                }
            }

            return list.ToArray();
        }

        protected void PrintArray(int[] array, string description = null)
        {
            var descriptionStr = "";
                
            if (description != null)
            {
                descriptionStr = string.Format("{0} ", description);
            }

            Console.Write("\nContents of {0}array: ", descriptionStr);
            if (array.Length > 0)
            {
                foreach (var s in array)
                {
                    Console.Write("{0} ", s);
                }

                Console.Write("\n");
            }
            else
            {
                Console.WriteLine("Array is empty");
            }
        }

        protected Graph ReadGraph()
        {
            Console.Write("\nEnter the number of vertices in the Graph: ");
            var finished = false;
            int numVertices = 0;

            while (!finished)
            {
                numVertices = GetIntegerInput();

                if (numVertices < 1 || numVertices > 10)
                {
                    Console.WriteLine("\nInvalid input, valid values are integers 1 - 10");
                }
                else
                {
                    finished = true;
                }
            }

            var graph = new Graph(numVertices);

            char[] validVertexNames = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'Q' };

            graph.GetVertexInput(new List<char>(validVertexNames));

            return graph;
        }

        protected void PrintGraphAdjacencyList(Graph graph)
        {
            Console.WriteLine(graph.GetAdjacencyList());
        }

        protected void HandleException(Exception e)
        {
            Console.WriteLine("\nWARNING - Exception Occurred:\n\n{0}\n{1}", e.Message, e.StackTrace);
        }
    }
}
