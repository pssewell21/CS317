using CS317Program.Data_Structures.Graph;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CS317Program.Data_Structures.AdjacencyList
{
    class AdjacencyList : BaseClass
    {
        List<AdjacencyListItem> _adjacencyListItems;
        List<Vertex> _vertexList;

        public AdjacencyList(int numberOfVertices)
        {
            AdjacencyListItem[] array = new AdjacencyListItem[numberOfVertices];

            char name = 'A';

            for (int i = 0; i < numberOfVertices; i++)
            {
                var vertex = new Vertex(name.ToString());
                _vertexList.Add(vertex);
                array[i] = new AdjacencyListItem(vertex);

                name++;
            }
                        
            _adjacencyListItems = new List<AdjacencyListItem>(array);
        }

        public void ReadConnectedVertices(List<char> validVertexNameList)
        {
            var done = false;

            while (!done)
            {
                Console.WriteLine("\nEnter the name for a vertex to attach other vertices to. Enter \"Q\" to quit: ");

                var selecedVertexName = GetVertexNameInput(validVertexNameList);
                
                var quit = false;

                while (!quit)
                {
                    var connectedVertexName = "";

                    var finished = false;

                    while (!finished)
                    {
                        Console.WriteLine("\nEnter the name for a vertex connected to {0}. Enter \"Q\" to quit: ", selecedVertexName);

                        connectedVertexName = GetVertexNameInput(validVertexNameList);

                        if (connectedVertexName.Equals("Q"))
                        {
                            quit = true;
                        }
                        else if (!selecedVertexName.Equals(connectedVertexName))
                        {
                            finished = true;

                            var item = _adjacencyListItems.FirstOrDefault(o => o.GetVertexName().Equals(selecedVertexName));
                            var vertex = _vertexList.FirstOrDefault(o => o.ToString().Equals(connectedVertexName));

                            if (item != null && vertex != null)
                            {
                                item.AddAttachedVertex(vertex);
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nA Vertex cannot be connected to itself");
                        }
                    }
                }
            }
        }

        private string GetVertexNameInput(List<char> validVertexNameList)
        {
            Console.WriteLine("\nSelect a vertex: ");

            var finished = false;
            var selectedVertex = "";

            while (!finished)
            {
                selectedVertex = GetSingleCharInput();

                if (validVertexNameList.Any(o => o.ToString().Equals(selectedVertex)))
                {
                    finished = true;
                }
                else
                {
                    Console.WriteLine("\nInvalid Vertex name selected");
                }
            }

            return selectedVertex;
        }

        public override string ToString()
        {
            var str = "";

            foreach (var item in _adjacencyListItems)
            {
                str += string.Format("\n{0}", item.ToString());
            }

            return str;
        }
    }
}
