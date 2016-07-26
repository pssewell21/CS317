using System;
using System.Collections.Generic;
using System.Linq;

namespace CS317Program.Data_Structures.Graph
{
    class Vertex
    {
        private readonly string _name;
        private List<Vertex> _adjacentVertexList;
        
        public int dfsStepDiscovered = 0;
        public int dfsStepProcessed = 0;

        public int bfsStepDiscovered = 0;
        public bool bfsVertexProcessed = false;

        public Vertex(string name)
        {
            _name = name;
            _adjacentVertexList = new List<Vertex>();
        }

        public bool AddAdjacentVertex(Vertex vertex)
        {
            var name = vertex.ToString();

            if (_adjacentVertexList.Any(o => o.ToString().Equals(name)))
            {
                Console.WriteLine("\n{0} has already been added to this adjacent vertex list", vertex.ToString());

                return false;
            }

            _adjacentVertexList.Add(vertex);

            return true;
        }

        public List<Vertex> GetAdjacentVertexList()
        {
            return _adjacentVertexList;
        }

        public override string ToString()
        {
            return _name;
        }

        public string GetAdjacentVertexListString()
        {
            var str = _name;

            foreach (var item in _adjacentVertexList)
            {
                str += string.Format(" -> {0}", item.ToString());
            }

            return str;
        }

        public string GetDfsStatusString()
        {
            return string.Format("{0}: {1}/{2}", _name, dfsStepDiscovered, dfsStepProcessed);
        }

        public string GetBfsStatusString()
        {
            return string.Format("{0}: {1}", _name, bfsStepDiscovered);
        }
    }
}
