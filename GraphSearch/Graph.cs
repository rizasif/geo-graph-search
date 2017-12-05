using System;
using System.Collections.Generic;

namespace GraphSearch
{
	public class Graph
	{
		private Dictionary<String, Node> NodeList;
		private String TopNode;

		/// <summary>
		/// The top node or reference node.
		/// The first node appended is the graph is declared as Start.
		/// Generally used as entry point for search in graph. 
		/// </summary>
		public Node Start
		{
			get{
				if(TopNode != null)
				{
					return NodeList[TopNode];
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Total nodes in the graph.
		/// </summary>
		public int count
		{
			get{
				return NodeList.Count;
			}
		}

		/// <summary>
		/// Empty graph constructor
		/// </summary>
		public Graph ()
		{
			NodeList = new Dictionary<string, Node>();
			TopNode = null;
		}

		/// <summary>
		/// Find a node by id (GeoHash) in the list.
		/// Returns null if none found
		/// </summary>
		public Node find(string id)
		{
			if (NodeList.ContainsKey (id))
				return NodeList [id];
			else
				return null;
		}

		/// <summary>
		/// Find a node by (Lat,Lng) pair in the list.
		/// Returns null if none found.
		/// </summary>
		public Node find(double lat, double lng)
		{
			return find (new Node(lat, lng, false).id);
		}

		/// <summary>
		/// Range in which a node can be declared as goal during search.
		/// Unit = Meters
		/// </summary>
		public void setGoalCriteria(double distance)
		{
			Node.GoalCriteria = Math.Abs (distance);
		}

		/// <summary>
		/// Resets the nodes in graph to untouched state
		/// </summary>
		public void refresh()
		{
			foreach(KeyValuePair<string, Node> entry in NodeList)
			{
				// do something with entry.Value or entry.Key
				entry.Value.SetOpenList(false);
				entry.Value.SetClosedList (false);
			}
		}

		/// <summary>
		/// Add a node to the graph.
		/// The first node added into an empty graph will be declared as Start.
		/// Ignores existing ids (GeoHash).
		/// </summary>
		public void append(Node node)
		{
			if (!NodeList.ContainsKey (node.id)) {
				if (TopNode == null) {
					node.Parent = null;
					TopNode = node.id;
				} else {
					Node bud = NodeList [TopNode];
					while (true) {
						if (String.Compare (bud.id, node.id) > 0) {
							//The new node is smaller than bud
							//hence go right
							if (bud.RightChild == null) {
								//Right Child of bud is null 
								//place new node there
								node.Parent = bud;
								bud.RightChild = node;
								break;
							} 
							else if(String.Compare (bud.RightChild.id, node.id) < 0){
								//Right Child of bud is smaller than new node
								//Replace the right child with new node
								node.RightChild = bud.RightChild;
								node.Parent = bud;
								
								node.RightChild.Parent = node;
								bud.RightChild = node;

								NodeList [node.RightChild.id] = node.RightChild;
								break;
							}
							else {
								//Need to iterate further
								bud = NodeList [bud.RightChild.id];
							}
						} else {
							//The new node is greater than bud
							//hence go left
							if (bud.LeftChild == null) {
								//Left Child of bud is null 
								//place new node there
								node.Parent = bud;
								bud.LeftChild = node;
								break;
							} 
							else if(String.Compare (bud.LeftChild.id, node.id) > 0){
								//Left Child of bud is larger than new node
								//Replace the left child with new node
								node.LeftChild = bud.LeftChild;
								node.Parent = bud;
								
								node.LeftChild.Parent = node;
								bud.LeftChild = node;

								NodeList [node.LeftChild.id] = node.LeftChild;
								break;
							}
							else {
								//Need to iterate further
								bud = NodeList [bud.LeftChild.id];
							}
						}
					}

					//Update the bud since it has a new child now
					NodeList [bud.id] = bud;
				}

				NodeList.Add (node.id, node);
			}
		}
	}
}

