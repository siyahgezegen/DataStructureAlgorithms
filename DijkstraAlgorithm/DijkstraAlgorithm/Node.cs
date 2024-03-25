using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraAlgorithm

{

    internal class Node
    {
        public string Name { get; set; }
        public Dictionary<Node, int> Edges { get; set; }
        public Node(string name, Dictionary<Node, int>)
        {
            Name = name;
            Edges = edges;
        }
        public Node AddEdges(Node node ,int distance) {
            Edges ??= new Dictionary<Node, int>();
            Edges.Add(node, distance);
            return this;
        }
        public override string ToString()
        {
            return $"Node : {Name}, Edge : {Edges}";
        }
    }
}
