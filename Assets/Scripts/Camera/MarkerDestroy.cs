using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerDestroy : MonoBehaviour
{
	public float time = 0.3f;

	void Start()
	{
		StartCoroutine(SelfDestroy());
	}

	IEnumerator SelfDestroy()
	{
		yield return new WaitForSeconds(time);
		Destroy(gameObject);
	}
}
