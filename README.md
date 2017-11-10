# geo-graph-search

This library helps in creating a graph of geo coordinates and find a path between them.

Provided is an exmaple to search among a graph. More can be found in GraphSearch/tests.cs

```
public static void searchGraph()
{
  double [] lats = {33.662315, 33.662394, 33.662376, 33.662383, 33.662327, 33.662372, 33.662388, 33.662361, 33.662379};
  double [] lngs = {73.045756, 73.045739, 73.045750, 73.045755, 73.045718, 73.045742, 73.045797, 73.045733, 73.045754};
  
  Graph mGraph = new Graph();
  for(int i=0; i< 9; i++)
  {
    mGraph.append(new Node(lats[i], lngs[i]));
  }
   
  Console.Out.WriteLine("Node Count: " + mGraph.count);
   
  var astar = new AStar.AStar(mGraph.Start, new Node(33.662327, 73.045718));
  var result = astar.Run();
   
  Console.Out.WriteLine(result);
   
  Print (astar.GetPath ());
   
  Console.ReadLine();
   
}

public static void Print(IEnumerable<INode> path)
{
  foreach (INode node in path) 
  {
    Node n = (Node)node;
    Console.Out.WriteLine (n.Lat + " , " + n.Lng);
  }
}
```
