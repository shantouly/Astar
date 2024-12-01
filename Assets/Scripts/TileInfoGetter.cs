using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public enum GridType
{
	walk,
	obstacle
}

[System.Serializable]
public class TileProperty
{
	public Vector2Int tileCordinate;
	public bool boolTypeValue;
	public GridType gridType;
}

public class TileInfoGetter : MonoBehaviour
{
	public Tilemap tilemap;
	
	void Update()
	{
		GetCellPosition();
	}
	
	private void GetCellPosition()
	{
		if(Input.GetMouseButton(0))
		{
			// 获取鼠标指针在世界空间中的位置
			Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			// 将世界坐标转换为 Tilemap 的网格坐标
			Vector3Int cellPosition = tilemap.WorldToCell(worldPos);

			// 获取当前瓦片的位置
			TileBase tile = tilemap.GetTile(cellPosition);

			// 输出瓦片信息
			if (tile != null)
			{
				Debug.Log($"瓦片位置: {cellPosition}, 瓦片类型: {tile.name}");
			}
			else
			{
				Debug.Log("该位置没有瓦片！");
			}
		}
	}
}
