using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

//[ExecuteInEditMode]
public class WirePath : MonoBehaviour {

	public Transform[] WirePoints;
	private LineRenderer lineRenderer;


	// Use this for initialization
	void Start () {
		lineRenderer = GetComponent<LineRenderer>();
		List<Vector3> points = new List<Vector3>();
		foreach (Transform t in WirePoints)
		{
			points.Add(t.position);
		}
		lineRenderer.positionCount = points.Count;
		lineRenderer.SetPositions(points.ToArray());
	}
	
	//private void OnDrawGizmosSelected()
	//{
	//	lineRenderer = GetComponent<LineRenderer>();
	//}
	//private void OnDrawGizmos()
	//{
	//	List<Vector3> points = new List<Vector3>();
	//	foreach (Transform t in WirePoints)
	//	{
	//		points.Add(t.position);
	//	}
	//	lineRenderer.positionCount = points.Count;
	//	lineRenderer.SetPositions(points.ToArray());
	//}
	// Update is called once per frame
	void Update () {
		
	}
}
