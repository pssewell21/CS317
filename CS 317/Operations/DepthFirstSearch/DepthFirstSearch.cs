using CS317Program.Data_Structures.Graph;

namespace CS317Program.Operations.DepthFirstSearch
{
    class DepthFirstSearch : BaseClass
    {
        private Graph _graph;
        
        public void Run()
        {
            _graph = ReadGraph();
            PrintGraphAdjacencyList(_graph);
        }
    }
}
