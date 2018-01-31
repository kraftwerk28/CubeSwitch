using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Help : MonoBehaviour {

	public void ShowHelp(bool show)
	{
		GetComponent<Animator>().SetBool("Show", show);
		transform.GetChild(0).GetComponent<Image>().enabled = show;
	}
}

