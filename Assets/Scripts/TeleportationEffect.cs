using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationEffect : MonoBehaviour {

	public GameObject yellow;
	public GameObject magenta;
	public float lifeTime = 1f;
	// Use this for initialization
	void Start () {
		StartCoroutine(Emit());
	}
	
	IEnumerator Emit()
	{
		yield return new WaitForSeconds(.5f);
		Destroy(yellow);
		magenta.GetComponent<ParticleSystem>().Stop();
		yield return new WaitForSeconds(1);

		Destroy(gameObject);
	}
}
