using CS317Program.Data_Structures.Graph;
using System;
using System.Collections.Generic;

namespace CS317Program.Operations.DepthFirstSearch
{
    class DepthFirstSearch : BaseClass
    {
        private Graph _graph;
        
        public void Run()
        {
            _graph = GetGraphInput();
            PrintGraphAdjacencyList(_graph);

            Dfs(_graph);
        }

        private void Dfs(Graph graph)
        {
            var stack = new Stack<Vertex>();
            var step = 1;

            var vertex = GetStartingVertex();

            stack.Push(vertex);
            Console.WriteLine("\n{0}", vertex.GetDfsStatusString());

            while (stack.Count != 0)
            {
                vertex = stack.Pop();
                Console.WriteLine("{0}", vertex.GetDfsStatusString());

                if (vertex.dfsStepDiscovered == -1 && !stack.Contains(vertex))
                {
                    vertex.dfsStepDiscovered = step;
                    step++;

                    foreach(var item in vertex.GetAdjacentVertexList())
                    {
                        if (item.dfsStepDiscovered == -1)
                        {
                            stack.Push(item);
                            Console.WriteLine("{0}", vertex.GetDfsStatusString());
                        }
                    }
                }
            }
        }

        private Vertex GetStartingVertex()
        {
            var vertexName = "";
            Vertex vertex = new Vertex("0");

            var finished = false;

            while (!finished)
            {
                vertexName = GetVertexNameInput("\nSelect the vertex where the Depth First Search will begin: ");

                vertex = _graph.GetVertex(vertexName);

                if (vertex != null)
                {
                    finished = true;
                }
                else
                {
                    Console.WriteLine("\n{0} does not exist in the graph. Select a vertex that exists in the graph", vertexName);
                }
            }

            return vertex;
        }
    }
}
