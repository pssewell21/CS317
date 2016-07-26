using System.Collections.Generic;

namespace CS317Program.Data_Structures.AdjacencyList
{
    class AdjacencyList
    {
        List<AdjacencyListItem> _adjacencyListItems;

        public AdjacencyList(int numberOfVertices)
        {
            AdjacencyListItem[] array = new AdjacencyListItem[numberOfVertices];
            _adjacencyListItems = new List<AdjacencyListItem>(array);
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
