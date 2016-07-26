using CS317Program.Data_Structures.Graph;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CS317Program.Operations.DepthFirstSearch
{
    class DepthFirstSearch : BaseClass
    {
        private Graph _graph;
        
        public void Run()
        {
            Console.WriteLine("NOTE: Enter the directed graph from the root down and add adjacent vertex names from left to right");
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
            vertex.dfsStepDiscovered = step;
            step++;
            Console.WriteLine("\n{0}", vertex.GetDfsStatusString());

            while (stack.Count != 0)
            {
                var peekVertex = stack.Peek();

                var adjacentVertexList = peekVertex.GetAdjacentVertexList();
                var adjacentVertex = adjacentVertexList.FirstOrDefault(o => o.dfsStepDiscovered == 0);

                if (adjacentVertex != null)
                {
                    stack.Push(adjacentVertex);
                    adjacentVertex.dfsStepDiscovered = step;
                    step++;
                    Console.WriteLine("{0}", adjacentVertex.GetDfsStatusString());
                }
                else
                {
                    var popVertex = stack.Pop();
                    popVertex.dfsStepProcessed = step;
                    step++;
                    Console.WriteLine("{0}", popVertex.GetDfsStatusString());
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
