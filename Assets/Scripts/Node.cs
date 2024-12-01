using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : IComparable<Node>
{
		public Vector2Int gridPosition;			// ��������
		public float gCost;						// ���룺����start���ӵľ���
		public float hCost;						// ���룺����target���ӵľ���
		public float FCost=>gCost+hCost;			// ��ǰ���ӵ�ֵ
		public bool isObstacle = false;			// ��ǰ�����Ƿ����ϰ�
		public Node parentNode;
		// ���췽��
		public Node(Vector2Int pos)
		{
			gridPosition = pos;
			parentNode = null;
		}

		// �Ƚ���������֮���FCost�����FCost��ȣ���Ƚ�hCost
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
