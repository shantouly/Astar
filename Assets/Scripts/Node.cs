using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : IComparable<Node>
{
		public Vector2Int gridPosition;			// 网格坐标
		public float gCost;						// 距离：距离start格子的距离
		public float hCost;						// 距离：距离target格子的距离
		public float FCost=>gCost+hCost;			// 当前格子的值
		public bool isObstacle = false;			// 当前格子是否是障碍
		public Node parentNode;
		// 构造方法
		public Node(Vector2Int pos)
		{
			gridPosition = pos;
			parentNode = null;
		}

		// 比较两个网格之间的FCost，如果FCost相等，则比较hCost
		public int CompareTo(Node other)
		{
			int result = FCost.CompareTo(other.FCost);
			if(result == 0)
			{
				return hCost.CompareTo(other.hCost);
			}
			
			return result;
		}
}
