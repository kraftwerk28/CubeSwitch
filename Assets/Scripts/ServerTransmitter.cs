using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ServerTransmitter : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Transmit()
	{
		GetComponent<AudioSource>().Play();
		GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraNavigation>().ChangeTarget(transform);
		GetComponent<Animator>().enabled = true;
		StartCoroutine(LN());
	}
	IEnumerator LN()
	{
		yield return new WaitForSeconds(3);
		int index = SceneManager.GetActiveScene().buildIndex;
		if (index >= 3)
			SceneManager.LoadScene("Menu");
		else
			SceneManager.LoadScene(index + 1);
	}
}
