using CS317Program.Data_Structures.Graph;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CS317Program.Data_Structures.AdjacencyList
{
    class AdjacencyListItem
    {
        private Vertex _vertex;
        private List<Vertex> _attachedVertexList;

        public AdjacencyListItem(Vertex vertex)
        {
            _vertex = vertex;
        }

        public Vertex GetVertex()
        {
            return _vertex;
        }

        public string GetVertexName()
        {
            return _vertex.ToString();
        }
        
        public bool AddAttachedVertex(Vertex vertex)
        {
            var name = vertex.ToString();

            if(_attachedVertexList.Any(o => o.ToString().Equals(name)))
            {
                Console.WriteLine("\nThis Vertex has already been added to this Adjacency List Item");

                return false;
            }

            _attachedVertexList.Add(vertex);

            return true;
        }

        public bool DeleteAttachedVertex(string name)
        {
            var vertex = _attachedVertexList.FirstOrDefault(o => o.ToString().Equals(name));

            if (vertex != null)
            {
                _attachedVertexList.Remove(vertex);

                return true;
            }

            return false;
        }

        public override string ToString()
        {
            var str = _vertex.ToString();

            foreach (var item in _attachedVertexList)
            {
                str += string.Format(" -> {0}", item.ToString());
            }

            return str;
        }
    }
}
