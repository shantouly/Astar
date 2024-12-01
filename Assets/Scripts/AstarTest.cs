using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AstarTest : MonoBehaviour
{
	private Astar astar;
	
	[Header("≤‚ ‘AStar")]
	public Vector2Int startPos;
	public Vector2Int endPos;
	public Tilemap displayMap;
	public Tile displayTile;
	public Tile normalTile;
	public bool displayStartAndFinish;
	public bool displayPath;
	private List<Node> pathNodes = new List<Node>();
	
	void Awake()
	{
		astar = GetComponent<Astar>();
	}
	
	void Start()
	{
		astar.initMapInfo(astar.mapData_Obstacle.gridWidth,astar.mapData_Obstacle.gridHeight);
	}
	
	void Update()
	{
		ShowPathOnGridMap();
	}
	
	private void ShowPathOnGridMap()
	{
		if(displayMap !=null && displayTile != null)
		{
			if(displayStartAndFinish)
			{
				displayMap.SetTile((Vector3Int)startPos,displayTile);
				displayMap.SetTile((Vector3Int)endPos,displayTile);
			}else
			{
				displayMap.SetTile((Vector3Int)startPos,normalTile);
				displayMap.SetTile((Vector3Int)endPos,normalTile);
			}
			
			if(displayPath)
			{
				Vector2Int startpos1 = new Vector2Int(startPos.x - astar.mapData_Obstacle.originX,startPos.y - astar.mapData_Obstacle.originY);
				Vector2Int endpos1 = new Vector2Int(endPos.x - astar.mapData_Obstacle.originX,endPos.y - astar.mapData_Obstacle.originY);
				Debug.Log(startpos1);
				Debug.Log(endpos1);
				pathNodes = astar.FindPath(startpos1,endpos1);
				
				Debug.Log(pathNodes[0]);
				foreach(var item in pathNodes)
				{
					displayMap.SetTile(new Vector3Int(item.gridPosition.x + astar.mapData_Obstacle.originX,item.gridPosition.y + astar.mapData_Obstacle.originY),displayTile);
				}
			}else
			{
				if(pathNodes.Count > 0)
				{
					foreach(var item in pathNodes)
					{
						displayMap.SetTile(new Vector3Int(item.gridPosition.x + astar.mapData_Obstacle.originX,item.gridPosition.y + astar.mapData_Obstacle.originY),normalTile);
					}
					
					pathNodes.Clear();
				}
			}
		}
	}
}
