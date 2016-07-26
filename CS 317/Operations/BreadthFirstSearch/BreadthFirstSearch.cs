using CS317Program.Data_Structures.Graph;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CS317Program.Operations.BreadthFirstSearch
{
    class BreadthFirstSearch : BaseClass
    {
        private Graph _graph;

        public void Run()
        { 
            Console.WriteLine("NOTE: Enter the directed graph from the root down and add adjacent vertex names from left to right");
            _graph = GetGraphInput();
            PrintGraphAdjacencyList(_graph);

            Bfs(_graph);
        }

        private void Bfs(Graph graph)
        {
            var queue = new Queue<Vertex>();
            var visited = new List<Vertex>();
            var step = 1;

            var vertex = GetStartingVertex();
            queue.Enqueue(vertex);
            visited.Add(vertex);
            vertex.bfsStepDiscovered = step;
            step++;
            Console.WriteLine("\n{0}", vertex.GetBfsStatusString());

            while (queue.Count != 0)
            {
                var peekVertex = queue.Peek();
                var enqueueingOccurred = false;

                foreach (var v in peekVertex.GetAdjacentVertexList())
                {
                    if (visited.All(o => o.ToString() != v.ToString()))
                    {
                        queue.Enqueue(v);
                        visited.Add(v);
                        v.bfsStepDiscovered = step;
                        Console.WriteLine("{0}", v.GetBfsStatusString());
                        enqueueingOccurred = true;
                    }
                }

                queue.Dequeue();

                if (enqueueingOccurred)
                {
                    step++;
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
                vertexName = GetVertexNameInput("\nSelect the vertex where the Breadth First Search will begin: ");

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
