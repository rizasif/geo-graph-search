using System;
using AStar;
using System.Collections.Generic;

namespace GraphSearch
{
	public class tests
	{
		static int Main(string[] args)
		{
//			GraphTest.buildGraphTest();
//			GraphTest.getFirstChildTest();
			//SearchTest.searchGraph();
//			GraphTest.duplicateTest();
			SearchTest.searchGraphTwice();
			return 0;
		}

		class GraphTest
		{
			public static void buildGraphTest()
			{
				double [] lats = {33.662315, 33.662394, 33.662376, 33.662383, 33.662327, 33.662372, 33.662388, 33.662361, 33.662379};
				double [] lngs = {73.045756, 73.045739, 73.045750, 73.045755, 73.045718, 73.045742, 73.045797, 73.045733, 73.045754};

				Graph mGraph = new Graph();

				for(int i=0; i< 9; i++)
				{
					mGraph.append(new Node(lats[i], lngs[i]));
				}

				Console.Out.WriteLine("Node Count: " + mGraph.count);
			}

			public static void getFirstChildTest()
			{
				double [] lats = {33.662315, 33.662394, 33.662376, 33.662383, 33.662327, 33.662372, 33.662388, 33.662361, 33.662379};
				double [] lngs = {73.045756, 73.045739, 73.045750, 73.045755, 73.045718, 73.045742, 73.045797, 73.045733, 73.045754};

				Graph mGraph = new Graph();

				for(int i=0; i< 9; i++)
				{
					mGraph.append(new Node(lats[i], lngs[i]));
				}

				Console.Out.WriteLine("Node Count: " + mGraph.count);

				Console.Out.WriteLine("Node Left Child: " + mGraph.Start.LeftChild.Lat + ", " + mGraph.Start.LeftChild.Lng);
//				Console.Out.WriteLine("Node Right Child: " + mGraph.Start.RightChild.Lat + ", " + mGraph.Start.RightChild.Lng);

			}

			public static void duplicateTest()
			{
				double [] lats = {33.662315, 33.662394, 33.662394, 33.662376, 33.662383, 33.662327, 33.662372, 33.662388, 33.662361, 33.662379};
				double [] lngs = {73.045756, 73.045739, 73.045739, 73.045750, 73.045755, 73.045718, 73.045742, 73.045797, 73.045733, 73.045754};

				Graph mGraph = new Graph();

				for(int i=0; i< 10; i++)
				{
					mGraph.append(new Node(lats[i], lngs[i]));
				}

				Console.Out.WriteLine("Node Count: " + mGraph.count);
			}
		}

		class SearchTest
		{
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

				Node.GoalCriteria = 0.300;
				var astar = new AStar.AStar(mGraph.Start, new Node(33.6623885, 73.0457975));

				var result = astar.Run();

				Console.Out.WriteLine(result);

				Print (astar.GetPath ());

				Console.ReadLine();
			}

			public static void searchGraphTwice()
			{
				double [] lats = {33.662315, 33.662394, 33.662376, 33.662383, 33.662327, 33.662372, 33.662388, 33.662361, 33.662379};
				double [] lngs = {73.045756, 73.045739, 73.045750, 73.045755, 73.045718, 73.045742, 73.045797, 73.045733, 73.045754};

				Graph mGraph = new Graph();

				for(int i=0; i< 9; i++)
				{
					mGraph.append(new Node(lats[i], lngs[i]));
				}

				Console.Out.WriteLine("Node Count: " + mGraph.count);

				Node.GoalCriteria = 0.300;
				var astar = new AStar.AStar(mGraph.Start, new Node(33.6623885, 73.0457975));

				var result = astar.Run();

				Console.Out.WriteLine(result);

				Print (astar.GetPath ());
				Console.Out.WriteLine (mGraph.Start.LeftChild.Lng);


				Console.Out.WriteLine ("2 iteration");

				mGraph.refresh ();

				Console.Out.WriteLine("Node Count: " + mGraph.count);
				Node.GoalCriteria = 0.300;

				var astar2 = new AStar.AStar(mGraph.Start, new Node(33.6623885, 73.0457975));
				//astar.Reset(mGraph.Start, new Node(33.6623885, 73.0457975));

				var result2 = astar2.Run();

				Console.Out.WriteLine(result2);
				Console.Out.WriteLine("Steps: " + astar2.Steps);

				Print (astar2.GetPath ());
				Console.Out.WriteLine (mGraph.Start.LeftChild.Lng);

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
		}
	}
}

