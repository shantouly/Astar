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
			// ��ȡ���ָ��������ռ��е�λ��
			Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			// ����������ת��Ϊ Tilemap ����������
			Vector3Int cellPosition = tilemap.WorldToCell(worldPos);

			// ��ȡ��ǰ��Ƭ��λ��
			TileBase tile = tilemap.GetTile(cellPosition);

			// �����Ƭ��Ϣ
			if (tile != null)
			{
				Debug.Log($"��Ƭλ��: {cellPosition}, ��Ƭ����: {tile.name}");
			}
			else
			{
				Debug.Log("��λ��û����Ƭ��");
			}
		}
	}
}
