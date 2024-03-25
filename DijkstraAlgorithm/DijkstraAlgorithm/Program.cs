
using DijkstraAlgorithm;
using System.Security;

var nodes = new Dictionary<string, Node>
{
    ["A"] = new Node("A", null),
    ["B"] = new Node("B", null),
    ["C"] = new Node("C", null),
    ["D"] = new Node("D", null),
    ["E"] = new Node("E", null),
    ["F"] = new Node("F", null),
};
nodes["A"].AddEdges(nodes["B"], 2).AddEdges(nodes["D"], 8);
nodes["B"].AddEdges(nodes["A"], 2).AddEdges(nodes["D"], 5).AddEdges(nodes["E"], 6);
nodes["C"].AddEdges(nodes["E"], 9).AddEdges(nodes["F"], 3);
nodes["D"].AddEdges(nodes["A"], 8).AddEdges(nodes["B"], 5).AddEdges(nodes["E"], 3).AddEdges(nodes["F"], 2);
nodes["E"].AddEdges(nodes["B"], 6).AddEdges(nodes["C"], 9).AddEdges(nodes["D"], 3).AddEdges(nodes["F"], 1);
nodes["F"].AddEdges(nodes["D"], 2).AddEdges(nodes["E"], 1).AddEdges(nodes["C"], 3);


var finalNode = nodes["C"];
var distances = nodes.ToDictionary(kvp => kvp.Value, kvp => (int?)int.MaxValue);
var parent = new Dictionary<Node, Node>();
var unDiscoveredNode = new HashSet<Node>(nodes.Values);

distances[nodes["A"]] = 0;
while (unDiscoveredNode.Count > 0)
{
    var current = unDiscoveredNode.MinBy(node => distances[node]);
    if (current is null)
        break;

    unDiscoveredNode.Remove(current);
    if (current == finalNode)
        break;
    foreach (var (adjacentNode, distance) in current.Edges)
    {
        var subDistance = distances[current] + distance;
        if (subDistance < distances[adjacentNode])
        {
            distances[adjacentNode] = subDistance;
            parent[adjacentNode] = current;
        }
    }
}
var pathNodes = new List<Node>();
var currentNode = finalNode;
while (currentNode is not null)
{
    pathNodes.Insert(0, currentNode);
    currentNode = parent.TryGetValue(currentNode, out var parentNode) ? parentNode : null;

}

Console.WriteLine(string.Join("->", pathNodes.Select(i => i.Name)));
Console.WriteLine("Total Distance : {0}", distances[finalNode]);
Console.ReadLine();