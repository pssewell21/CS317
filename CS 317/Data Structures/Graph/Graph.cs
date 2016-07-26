using System;
using System.Collections.Generic;
using System.Linq;

namespace CS317Program.Data_Structures.Graph
{
    class Graph : BaseClass
    {
        private List<Vertex> _vertexList;

        public Graph(int numberOfVertices)
        {
            _vertexList = new List<Vertex>();

            char name = 'A';

            for (int i = 0; i < numberOfVertices; i++)
            {
                var vertex = new Vertex(name.ToString());
                _vertexList.Add(vertex);

                name++;
            }
        }

        public void GetVertexInput()
        {
            var done = false;

            while (!done)
            {
                var selectedVertexName = GetVertexNameInput("\nEnter the name for a vertex to attach other vertices to. Enter \"Q\" to quit: ");

                if (selectedVertexName.Equals("Q"))
                {
                    done = true;
                }
                else
                {
                    var selectedVertex = _vertexList.FirstOrDefault(o => o.ToString().Equals(selectedVertexName));

                    if (selectedVertex != null)
                    {
                        var quit = false;

                        while (!quit)
                        {
                            var connectedVertexName = "";

                            var finished = false;

                            while (!finished)
                            {
                                var message = string.Format("\nEnter the name for a vertex connected to {0}. Enter \"Q\" to quit: ", selectedVertexName);

                                connectedVertexName = GetVertexNameInput(message);

                                if (connectedVertexName.Equals("Q"))
                                {
                                    quit = true;
                                    finished = true;
                                }
                                else if (!selectedVertexName.Equals(connectedVertexName))
                                {
                                    finished = true;

                                    var vertex = _vertexList.FirstOrDefault(o => o.ToString().Equals(connectedVertexName));

                                    if (vertex != null)
                                    {
                                        selectedVertex.AddAdjacentVertex(vertex);
                                    }
                                    else
                                    {
                                        Console.WriteLine("\n{0} does not exist in the graph. Failed to add adjacent vertex", connectedVertexName);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("\nA vertex cannot be connected to itself");
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n{0} does not exist in the graph. Select a vertex that exists in the graph", selectedVertexName);
                    }
                }
            }
        }

        public Vertex GetVertex(string vertexName)
        {
            var vertex = _vertexList.FirstOrDefault(o => o.ToString().Equals(vertexName));

            return vertex;
        }

        public string GetAdjacencyList()
        {
            var str = "\nContents of graph:\n";

            foreach (var item in _vertexList)
            {
                str += string.Format("\n{0}", item.GetAdjacentVertexListString());
            }

            return str;
        }
    }
}
