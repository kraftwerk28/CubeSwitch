using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelHelp : MonoBehaviour {

	public void Show (bool show)
	{
		GetComponent<Animator>().SetBool("Show", show);
	}
}
