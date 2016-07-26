namespace CS317Program.Data_Structures.Graph
{
    class Vertex
    {
        private readonly string _name;

        public Vertex(string name)
        {
            _name = name;
        }

        public override string ToString()
        {
            return _name;
        }
    }
}
