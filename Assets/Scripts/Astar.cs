using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astar : MonoBehaviour
{
	public MapData_SO mapData_Obstacle;
	public static Astar instance;
	public static Astar Instance
	{
		get
		{
			if(instance == null)
			{
				instance = new Astar();
			}
			
			return instance;
		}
	}
	
	private int mapH;
	private int mapW;
	
	private Node[,] nodes;
	private List<Node> openList = new List<Node>();
	private List<Node> closeList = new List<Node>();
	
	public void initMapInfo(int w,int h)
	{
		mapH = h;
		mapW = w;
		nodes = new Node[w,h];
		for(int i = 0;i < w;++i)
		{
			for(int j = 0;j < h;++j)
			{
				Node newnode = new Node(new Vector2Int(i,j));
				if(mapData_Obstacle.IsObstacle(new Vector2Int(newnode.gridPosition.x + mapData_Obstacle.originX,newnode.gridPosition.y + mapData_Obstacle.originY)))
				{
					newnode.isObstacle = true;
				}
				nodes[i,j] = newnode;
			}
		}
	}
	
	public List<Node> FindPath(Vector2Int startPos,Vector2Int endPos)
	{
		
		if(startPos.x < 0|| startPos.x >= mapW||startPos.y < 0|| startPos.y >= mapH||endPos.x < 0|| endPos.x >=mapW||endPos.y < 0|| endPos.y >=mapH)
		{
			Debug.Log("³¬³ö·¶Î§£¡£¡");
			 return null;
		}
		   
		Node start = nodes[startPos.x,startPos.y];
		Node end = nodes[endPos.x,endPos.y];
		if(start.isObstacle || end.isObstacle)
		{
			Debug.Log("ÊÇÕÏ°­Îï£¡£¡");
			return null;
		}
			
			
		closeList.Clear();
		openList.Clear();
		
		start.parentNode = null;
		start.gCost = 0;
		start.hCost = 0;
		closeList.Add(start);
		
		while(true)
		{
			FindNearlyNode(new Vector2Int(start.gridPosition.x - 1,start.gridPosition.y -1 ),1.4f,start,end);
			FindNearlyNode(new Vector2Int(start.gridPosition.x,start.gridPosition.y -1 ),1,start,end);
			FindNearlyNode(new Vector2Int(start.gridPosition.x + 1,start.gridPosition.y -1 ),1.4f,start,end);
			FindNearlyNode(new Vector2Int(start.gridPosition.x - 1,start.gridPosition.y ),1,start,end);
			FindNearlyNode(new Vector2Int(start.gridPosition.x + 1,start.gridPosition.y),1,start,end);
			FindNearlyNode(new Vector2Int(start.gridPosition.x - 1,start.gridPosition.y + 1),1.4f,start,end);
			FindNearlyNode(new Vector2Int(start.gridPosition.x,start.gridPosition.y+1),1,start,end);
			FindNearlyNode(new Vector2Int(start.gridPosition.x + 1,start.gridPosition.y + 1),1.4f,start,end);
			
			
			if(openList.Count == 0)
			{
				return null;
			}
			openList.Sort();
			
			closeList.Add(openList[0]);
			start = openList[0];
			openList.RemoveAt(0);
			
			if(start == end)
			{
				List<Node> path = new List<Node>();
				path.Add(end);
				while(end.parentNode!=null)
				{
					path.Add(end.parentNode);
					end = end.parentNode;
				}
				
				path.Reverse();
				return path;
			}
		}
	}
	
	private void FindNearlyNode(Vector2Int pos,float g,Node father,Node endpos)
	{
		if(pos.x < 0 || pos.x >= mapW ||
			pos.y < 0 || pos.y >= mapH)
			return;
		
		Node node = nodes[pos.x,pos.y];
		
		if(node == null || node.isObstacle || closeList.Contains(node) ||
		openList.Contains(node))
			return;
			
		node.parentNode = father;
		node.gCost = father.gCost + g;
		node.hCost = Mathf.Abs(endpos.gridPosition.x - node.gridPosition.x) + Mathf.Abs(endpos.gridPosition.y - node.gridPosition.y);
		
		openList.Add(node);
	}
}
