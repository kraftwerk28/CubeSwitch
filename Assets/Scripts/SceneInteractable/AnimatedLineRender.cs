using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class AnimatedLineRender : MonoBehaviour
{
	//public Transform[] vertices;
	public float maxDist = 0.5f;
	public bool doRenderLine = false;

	private Vector3[] points;
	List<Vector3> p = new List<Vector3>();
	private LineRenderer lineRenderer;
	private Vector3 movPoint;
	private int curIndex = 0;

	public bool increasing = false;
	// Use this for initialization
	void Start()
	{
		List<Vector3> p = new List<Vector3>();
		foreach (Transform t in transform)
		{
			p.Add(t.position);
		}
		points = p.ToArray();


		movPoint = points[0];
		//if (curIndex < points.Length - 1)
		//	curIndex++;
		lineRenderer = GetComponent<LineRenderer>();
		lineRenderer.SetPosition(curIndex, points[curIndex]);
		lineRenderer.positionCount = 1;

	}

	// Update is called once per frame
	void Update()
	{
		if (movPoint != Vector3.zero)
		{
			movPoint = Vector3.MoveTowards(movPoint, points[curIndex], maxDist);
			lineRenderer.SetPosition(curIndex, movPoint);
		}
		

	}

	private void FixedUpdate()
	{
		if (increasing)
		{
			if (movPoint == points[curIndex])
			{
				if (curIndex < points.Length - 1)
				{
					curIndex++;
					lineRenderer.positionCount = curIndex + 1;
				}
				else
				{
					movPoint = Vector3.zero;
					curIndex = 0;
				}

			}
		}
		else
		{
			lineRenderer.positionCount = 1;
			lineRenderer.SetPosition(0, points[0]);
			movPoint = points[0];

			//if (movPoint == points[curIndex])
			//{
			//	if (curIndex > 0)
			//	{
			//		curIndex--;
			//		lineRenderer.positionCount = curIndex + 1;
			//	}
			//	else
			//	{
			//		movPoint = Vector3.zero;
			//		curIndex = 0;
			//	}

			//}
		}
	}

	
	private void OnDrawGizmos()
	{
		if (doRenderLine)
		{
			lineRenderer = GetComponent<LineRenderer>();
			foreach (Transform t in transform)
			{
				p.Add(t.position);
			}
			lineRenderer.positionCount = p.Count;
			lineRenderer.SetPositions(p.ToArray());
			p.Clear();
		}

	}

	void DrawBetween(int firstIndex)
	{
		Vector3.MoveTowards(points[firstIndex], points[firstIndex + 1], maxDist);

	}
}
