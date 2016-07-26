using CS317Program.Data_Structures.AdjacencyList;

namespace CS317Program.Operations.DepthFirstSearch
{
    class DepthFirstSearch : BaseClass
    {
        private AdjacencyList _list;
        
        public void Run()
        {
            _list = ReadAdjacencyList();
            PrintAdjacencyList(_list);
        }
    }
}
