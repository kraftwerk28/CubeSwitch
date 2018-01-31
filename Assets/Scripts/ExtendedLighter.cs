using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendedLighter : MonoBehaviour {

	public GameObject Lighter;
	public float rotateSpeed = 0.5f;
	private float rad;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 rot = transform.eulerAngles;
		rot.y += rotateSpeed;
		transform.eulerAngles = rot;
	}
	private void OnDrawGizmosSelected()
	{
		rad = (Lighter.transform.position - transform.position).magnitude;
		Gizmos.DrawWireSphere(transform.position, rad);
	}
}
